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

namespace CORSV2.forms.publicforms.mailbox
{
    public partial class mail_manage : System.Web.UI.Page
    {
        public static string belongArea = "";
        public static string unreadMailNum = "";

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
            if (Request["sysLogId"] != null && Request["status"] != null)
            {
                identifyHaveRead(Request["sysLogId"].ToString(), Request["status"].ToString());
            }
            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                DeleteCors();
            }

            if (Request["action"] != null && Request["action"] == "DownloadAll")
            {
                DownloadAll();
            }
        }
        private void identifyHaveRead(string sysLogId, string status)
        {
            if (Convert.ToInt32(Session["UserType"]) == 1)  
            {
               
                Model.UserMessage sysLog = DAL.UserMessage.GetModel(Convert.ToInt32(sysLogId));
                if (status == "identifyHaveRead")
                {
                    //消息已读则IsRead=1
                    sysLog.IsRead = 1;
                    sysLog.ReadTime = DateTime.Now;
                }
                DAL.UserMessage.Update(sysLog);

                string strwhere = "ToUser = '全部用户' or ToUser ='" + Session["UserName"].ToString() + "' and IsRead=0 ";

                //查询该用户收件箱里里面未读信个数

                unreadMailNum = DAL.UserMessage.GetRecordCountNew("", strwhere).ToString();

                if (unreadMailNum == "0")
                {
                    unreadMailNum = "";
                }
            }
            else
            {
                Model.SysLog sysLog = DAL.SysLog.GetModel(Convert.ToInt32(sysLogId));
                if (status == "identifyHaveRead")
                {
                    //消息已读则LogType=6
                    sysLog.LogType = 6;
                }
                DAL.SysLog.Update(sysLog);
                string search = ""; string strwhere = "";
                strwhere = " LogType= 5 ";
                unreadMailNum = DAL.SysLog.GetRecordCount(search, strwhere).ToString();
                if (unreadMailNum == "0")
                {
                    unreadMailNum = "";
                }
            }


        }
        private void DownloadAll()
        {
            if (Session["UserName"] == null)
            { }
            else
            {
                DataTable dt = DAL.SysLog.GetList("1=1 and LogType= 5 or LogType= 6 order by id asc").Tables[0];
                WriteExcelWithNPOI(dt, "xls");
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
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "邮件信息统计表.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "邮件信息统计表.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
        private bool GetData()
        {
            string sort = "LogTime";
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


            DataSet ds; int totalCount;
            if (Convert.ToInt32(Session["UserType"]) == 1)
            {
                sort = "SentTime";
                if (Request["sort"] != null)
                {

                }
                strwhere += " and ToUser = '全部用户' or ToUser ='" + Session["UserName"].ToString() + "'";
                totalCount = DAL.UserMessage.GetRecordCountNew(search, strwhere);
                if (offset + limit > totalCount)
                {
                    limit = totalCount - offset;
                }
                //strwhere = "UserName='" + Session["UserName"].ToString() + "'";

                ds = DAL.UserMessage.GetBriefListNew(offset, limit, sort, order, search, strwhere);
                //ds.Tables[0].Columns.Add("button", typeof(string));
                ds.Tables[0].Columns.Add("reLogTime", typeof(string));
                ds.Tables[0].Columns.Add("readSymbol", typeof(string));
                ds.Tables[0].Columns.Add("UserName", typeof(string));

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["reLogTime"] = dr["SentTime"].ToString();
                    dr["UserName"] = dr["FromUser"].ToString();
                    if (Convert.ToInt32(dr["IsRead"]) == 0)
                    {
                        dr["readSymbol"] = "<a style='color:red;' id='" + dr["ID"] + "'onclick=identifyHaveRead(this.id)  >未读</a>";
                    }
                    else if (Convert.ToInt32(dr["IsRead"]) == 1)
                    {
                        dr["readSymbol"] = "<a style='color:blue;' id='" + dr["ID"] + "'  >已读</a>";
                    }
                }
            }
            else
            {
                //邮件信息只包括 LogType = 5 的信息
                strwhere = strwhere + " and LogType = 5 or LogType=6 ";


                if (Request["sort"] != null)
                {
                    if (Request["sort"].ToString() == "reLogTime")
                    {
                        sort = "LogTime";
                    }
                    else if (Request["sort"].ToString() == "Symbol")
                    {
                        sort = "LogType";
                    }
                    else
                    {
                        sort = Request["sort"].ToString();
                    }
                    order = Request["order"].ToString();
                }
                totalCount = DAL.SysLog.GetRecordCount(search, strwhere);
                if (offset + limit > totalCount)
                {
                    limit = totalCount - offset;
                }
                //strwhere = "UserName='" + Session["UserName"].ToString() + "'";
                ds = DAL.SysLog.GetBriefList1(offset, limit, sort, order, search, strwhere);
                //ds.Tables[0].Columns.Add("button", typeof(string));
                ds.Tables[0].Columns.Add("reLogTime", typeof(string));
                ds.Tables[0].Columns.Add("readSymbol", typeof(string));
                ds.Tables[0].Columns.Add("qualificationCertifyCheck", typeof(string));

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["reLogTime"] = dr["LogTime"].ToString();
                    dr["qualificationCertifyCheck"] = "<a style='color:blue;'  >尚未认证</a>";

                    if (Convert.ToInt32(dr["LogType"]) == 5)
                    {
                        dr["readSymbol"] = "<a style='color:red;' id='" + dr["ID"] + "'onclick=identifyHaveRead(this.id)  >未读</a>";
                    }
                    else if (Convert.ToInt32(dr["LogType"]) == 6)
                    {
                        dr["readSymbol"] = "<a style='color:blue;' id='" + dr["ID"] + "'  >已读</a>";
                    }
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
            if (Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
            {
                try
                {
                    for (int m = 0; m < temp.Length; m++)
                    {
                        ids[m] = Convert.ToInt32(temp[m]);
                        //删除该用户
                        bool result = DAL.SysLog.Delete(ids[m]);
                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    for (int m = 0; m < temp.Length; m++)
                    {
                        ids[m] = Convert.ToInt32(temp[m]);
                        //删除该用户
                        bool result = DAL.UserMessage.Delete(ids[m]);
                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                catch (Exception)
                {
                }
            }

        }
    }
}