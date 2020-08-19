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


namespace CORSV2.forms.administrator.users
{
    public partial class rtkUserManage_Admin : System.Web.UI.Page
    {
        public static string belongArea = "";
        //public static string[] zhengzhouCity = { "郑州市", "开封市", "三门峡市", "洛阳市", "焦作市", "新乡市", "鹤壁市", "安阳市", "濮阳市", "商丘市", "许昌市", "漯河市", "平顶山市", "南阳市", "信阳市", "周口市", "驻马店市" };

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "qjzql";
            //Session["UserType"] = "1";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 1 || Convert.ToInt32(Session["UserType"]) > 3)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            //如果是用户登录，则隐藏分区域栏
            if (Session["UserType"].ToString() == "1")
            {
                cityType.Items.Clear();
                cityType.Items.Add("全部");
                cityType.Value = "全部";
                dataType.Items.Clear();
                dataType.Items.Add("企业用户");
                dataType.Value = "企业用户";

                rtkUserNum.InnerText = DAL.RTKUserInfo.GetList("RegisterUserName='" + Session["UserName"].ToString() + "'").Tables[0].Rows.Count.ToString();
                normalRtkUserNum.Visible = false;
                //toolbar.Attributes.CssStyle.Value = "display:none";
            }
            else
            {
                rtkUserNum.InnerText = DAL.RTKUserInfo.GetList("1=1").Tables[0].Rows.Count.ToString();
                normalRtkUserNum.InnerText = DAL.RTKUserPurview.GetList("EndTime>'" + DateTime.Now + "'").Tables[0].Rows.Count.ToString();

            }
            //fd.Visible = false;
            //toolbar.Attributes.CssStyle.Value = "display:none";
            //toolbar.Visible = false;
            //toolbar.Style.Add(HtmlTextWriterStyle.Display, "none");
            //toolbar.Style["display"] = "none";
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
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "RTK注册用户.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "RTK注册用户.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
        private void adminCity(string adminUserName)
        {
            cityType.Items.Clear();
            cityType.Items.Add(adminUserName);
            cityType.Value = adminUserName;
            belongArea = adminUserName;
        }
        private bool GetData()
        {
            string sort = "UserName";
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
            if (Request["sort"] != null)
            {
                //sort = Request["sort"].ToString() == "reRegTime" ? "RegTime" : Request["sort"].ToString();
                if (Request["sort"].ToString() == "reRegTime")
                {
                    sort = "RegTime";
                }
                else if (Request["sort"].ToString() == "reLastLoginTime")
                {
                    sort = "LastLoginTime";

                }
                else if (Request["sort"].ToString() == "reEndTime")
                {
                    sort = "EndTime";

                }
                else
                {
                    sort = Request["sort"].ToString();

                }
                order = Request["order"].ToString();

            }
            if (Session["UserType"].ToString() == "1")
            {
                strwhere = strwhere + " and RegisterUserName ='" + Session["UserName"].ToString() + "'";
            }

            int totalCount = DAL.RTKUserInfo.GetRecordCount(search, strwhere);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            //strwhere = "UserName='" + Session["UserName"].ToString() + "'";
            DataSet ds = DAL.RTKUserInfo.GetBriefList1(offset, limit, sort, order, search, strwhere);
            //ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("reStartTime", typeof(string));
            ds.Tables[0].Columns.Add("reEndTime", typeof(string));
            ds.Tables[0].Columns.Add("reRegTime", typeof(string));
            ds.Tables[0].Columns.Add("detailInfo", typeof(string));
            ds.Tables[0].Columns.Add("accountState", typeof(string));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                // string temp_time=((DateTime)dr["SubmitTime"]).ToString("yyyy-MM-dd");
                dr["detailInfo"] = "<a id='" + dr["ID"] + "' onclick= rtkUserDetailInfoView(this.id) >查看</a>";
                dr["reRegTime"] = dr["RegTime"].ToString();
                dr["PassWord"] = AES_Key.AESDecrypt(dr["PassWord"].ToString(), dr["UserName"].ToString().PadLeft(16, '0'));
                dr["reEndTime"] = DAL.RTKUserPurview.GetModel(dr["UserName"].ToString()).EndTime;

                DateTime dt1 = Convert.ToDateTime(dr["reEndTime"].ToString());

                DateTime dt2 = DateTime.Now;
                TimeSpan deta = DateTime.Now - dt1;

                if (DateTime.Compare(dt1, dt2) > 0)
                {
                    dr["accountState"] = "正常";

                }
                if (Math.Abs(deta.TotalDays) <= 31)
                {
                    dr["accountState"] = "<a style = 'color:red;' > 即将到期 </a>";
                }
                if (DateTime.Compare(dt1, dt2) < 0)
                {
                    dr["accountState"] = "<a style = 'color:red;' > 欠费 </a>";
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
                    bool result = DAL.RTKUserInfo.Delete(ids[m]);
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
    }
}