using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Web.Services;

namespace CORSV2.forms.administrator.users
{
    public partial class UserManage : System.Web.UI.Page
    {
        public static string belongArea = "";
        public static int rtkID=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] != null && Session["UserType"].ToString() == "2")
            {
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                cityType.Items.Clear();
                cityType.Items.Add(registerUser.BelongArea);
                cityType.Value = registerUser.BelongArea;
                belongArea = registerUser.BelongArea;
            }
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetData())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                DeleteCors();
            }
            if (Request["qualificationCertifyId"] != null && Request["status"] != null)
            {
                qualificationCertifyCheck(Request["qualificationCertifyId"].ToString(), Request["status"].ToString());
            }
            if (Request["action"] != null && Request["action"] == "DownloadAll")
            {
                DownloadAll();
            }


        }
        private void DownloadAll()
        {
            if (Session["UserName"] == null)
            { }
            else
            {
                DataTable dt = DAL.RegisterUser.GetList("1=1 order by id asc").Tables[0];
                //foreach (DataRow dr in dt.Rows)
                //{

                //}

                //  PassWord.Value = AES_Key.AESDecrypt(mrtk.PassWord, mrtk.UserName.PadLeft(16, '0'));
                WriteExcelWithNPOI(dt, "xls");
                // WriteExcelWithNPOI(dt1, "xls");
            }
        }
        public void WriteExcelWithNPOI(DataTable dt, String extension)
        {

            IWorkbook workbook;

            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "CORS注册用户.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "CORS注册用户.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }

        private void qualificationCertifyCheck(string qualificationCertifyId, string status)
        {
            rtkID = Convert.ToInt32(qualificationCertifyId);
            Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(Convert.ToInt32(qualificationCertifyId));
            if (status == "OK")
            {
                //1为单位认证中，加1就是2认证通过  3为个人认证中，加1就是4认证通过
                if (registerUser.CertifiationStatus==1)
                {
                    registerUser.CertifiationStatus = 2;
                }
                if (registerUser.CertifiationStatus ==6)
                {
                    registerUser.CertifiationStatus = 2;
               
                }
                
              
                //
                string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                string message = "用户您好：您的CORS账号资质认证申请已通过，可以登录系统进行查看!";

                SMS = SMS.Replace("@message", message);
                SMS = SMS.Replace("@phone", registerUser.Phone);

                if (cs.HttpHelper.SendSMS(SMS))
                {

                }
                else
                {
                    cs.WebLogger.WriteErroLog("资质认证审核成功短信发送错误");    //输出到文件中
                }
            }
            else
            {
                //认证失败就是5
                registerUser.CertifiationStatus = 5;
                //string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                //string message = "用户您好：您的CORS账号资质认证申请未通过，可以登录系统进行查看!";

                //SMS = SMS.Replace("@message", message);
                //SMS = SMS.Replace("@phone", registerUser.Phone);

                //if (cs.HttpHelper.SendSMS(SMS))
                //{

                //}
                //else
                //{
                //    cs.WebLogger.WriteErroLog("资质认证审未通过核短信发送错误");    //输出到文件中
                //}
            }
            DAL.RegisterUser.Update(registerUser);

        }
        private void adminCity(string adminUserName)
        {
            cityType.Items.Clear();
            cityType.Items.Add(adminUserName);
            cityType.Value = adminUserName;
            belongArea = adminUserName;
        }
        public  bool GetData()
        {
            string sort = "RegTime";
            string order = "DESC";
            string search = "";
            int offset = 0;
            int limit = 10;
            string strwhere = "1=1";
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();
            if (Request["dataType"] != null && Request["cityType"] != null)
            {
                //int dataTypenum = int.Parse(Request["dataType"].ToString());
                if (Request["cityType"].ToString() != "全部")
                {
                    strwhere = "BelongArea ='" + Request["cityType"].ToString() + "'";
                }
                else
                {

                }
            }
            else
            {
                if (belongArea != "")
                    strwhere = "BelongArea ='" + belongArea + "'";
            }
            //平台用户管理只包括 UserType = 1 的用户
            strwhere = strwhere + " and UserType = 1 ";

            if (Request["sort"] != null)
            {
                if (Request["sort"].ToString() == "reRegTime")
                {
                    sort = "RegTime";
                }
                else if (Request["sort"].ToString() == "reLastLoginTime")
                {
                    sort = "LastLoginTime";

                }
                else if (Request["sort"].ToString() == "qualificationCertifyCheck")
                {
                    sort = "CertifiationStatus";
                }
                else
                {
                    sort = Request["sort"].ToString();

                }
                order = Request["order"].ToString();

            }
            int totalCount = DAL.RegisterUser.GetRecordCount(search, strwhere);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            //strwhere = "UserName='" + Session["UserName"].ToString() + "'";
            DataSet ds = DAL.RegisterUser.GetBriefList1(offset, limit, sort, order, search, strwhere);
            //ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("reRegTime", typeof(string));
            ds.Tables[0].Columns.Add("reLastLoginTime", typeof(string));
            ds.Tables[0].Columns.Add("qualificationCertifyShow", typeof(string));
            ds.Tables[0].Columns.Add("qualificationCertifyCheck", typeof(string));
            ds.Tables[0].Columns.Add("RTKNum", typeof(string));
            ds.Tables[0].Columns.Add("Company", typeof(string));
            ds.Tables[0].Columns.Add("rtkInsert", typeof(string));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["PassWord"] = AES_Key.AESDecrypt(dr["PassWord"].ToString(), dr["UserName"].ToString().PadLeft(16, '0'));
                // string temp_time=((DateTime)dr["SubmitTime"]).ToString("yyyy-MM-dd");
                dr["reRegTime"] = dr["RegTime"].ToString();
                dr["reLastLoginTime"] = dr["LastLoginTime"].ToString();
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
                dr["qualificationCertifyShow"] = "<a id='" + dr["ID"] + "' onclick=view(this.id) >查看</a>";
                dr["Company"] = "尚未认证";
                DataSet dsRtkUserInfo = DAL.RTKUserInfo.GetList("RegisterUserName = '" + dr["UserName"].ToString() + "'");
                dr["RTKNum"] = dsRtkUserInfo.Tables[0].Rows.Count;
               
                if (DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationStatus == 0)
                {
                    dr["qualificationCertifyShow"] = "<a style='color:blue;' id='" + dr["ID"] + "'  >尚未认证</a>";
                    dr["qualificationCertifyCheck"] = "<a style='color:blue;' id='" + dr["ID"] + "'  >尚未认证</a>";
                }
                else if (DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationStatus == 1)
                {
                    dr["qualificationCertifyCheck"] = "<a style='color:red;' id='" + dr["ID"] + "' onclick=qualificationCertifyCheck(this.id) >待审核</a>";
                }
                else if (DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationStatus == 2)
                {
                    int tempIndex = Convert.ToInt32(DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationIndex);
                    dr["Company"] = DAL.CompanyInfo.GetModel(tempIndex).Company;
                    dr["qualificationCertifyCheck"] = "<a style='color:limegreen;' id='" + dr["ID"] + "'  >认证通过</a>";
                    dr["rtkInsert"] = "<a style = 'color:#357CE3;' href='/forms/administrator/users/AddRTKInfo.aspx?name=" + dr["UserName"].ToString() + "' > 账号添加 </a>";
                }
                else if (DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationStatus == 3)
                {
                    dr["qualificationCertifyCheck"] = "<a style='color:red;' id='" + dr["ID"] + "' onclick=qualificationCertifyCheck(this.id) >待审核</a>";
                }
                else if (DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationStatus == 4)
                {
                    dr["qualificationCertifyCheck"] = "<a style='color:limegreen;' id='" + dr["ID"] + "'  >认证通过</a>";
                }
                else if (DAL.RegisterUser.GetModel(Convert.ToInt32(dr["ID"])).CertifiationStatus == 6)
                {
                    dr["qualificationCertifyCheck"] = "<a style='color:red;' id='" + dr["ID"] + "' onclick=qualificationCertifyCheck(this.id) >待审核</a>";
                }

                else
                {
                    dr["qualificationCertifyCheck"] = "<a style='color:black;' id='" + dr["ID"] + "'  >认证失败</a>";
                }
                if (true)
                {
                   
                }
               
            }
            string result = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }
        private void DeleteCors()
        {
            int[] ids;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            ids = new int[temp.Length];
            try
            {
                for (int m = 0; m < temp.Length; m++)
                {
                    ids[m] = Convert.ToInt32(temp[m]);
                    //删除该用户
                    bool result = DAL.RegisterUser.Delete(ids[m]);
                    string strwhere = "RegisterUserName = '" + DAL.RegisterUser.GetModel(ids[m]).UserName + "'";
                    DataSet dsRtkUser = DAL.RTKUserInfo.GetList(strwhere);
                    foreach (DataRow dr in dsRtkUser.Tables[0].Rows)
                    {
                        DAL.RTKUserInfo.Delete(dr["UserName"].ToString());
                    }
                }
                Response.Clear();
                Response.Write("1");
                Response.End();
            }
            catch (Exception ex)
            {
                cs.WebLogger.WriteErroLog(ex.ToString());    //输出到文件中
                                                             //Response.Write("<script>alert(\"1\")</script>");
                return;
            }
        }
        [WebMethod]//方法前边必须添加 [WebMethod]      
        public static string GetValueAjax(string t)//这个方法需要是静态的方法要用到关键字static       
        {
            //在这里可以对传进来的参数进行任何操作  
            string text = t;
            string strJson1 = string.Empty;
            Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(rtkID);
            registerUser.CertifiationStatus = 5;
            DAL.RegisterUser.Update(registerUser);
          
            string aa="";


            string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
            string message = "用户您好：您的CORS账号资质认证申请未通过原因是："+ t;

            SMS = SMS.Replace("@message", message);
            SMS = SMS.Replace("@phone", registerUser.Phone);

            if (cs.HttpHelper.SendSMS(SMS))
            {
                aa = "发送成功！";
            }
            else
            {
                aa = "发送失败！";
                cs.WebLogger.WriteErroLog("资质认证审未通过核短信发送错误");    //输出到文件中
            }
        
            
            return aa;
        }
           

        }
    }
