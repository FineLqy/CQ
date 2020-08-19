using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;


namespace CORSV2.forms.administrator.information
{
    public partial class RtkSurveyRecording : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            //第一次加载的时候
            if (!IsPostBack)
            {

            }
            if (Request["action"] != null)
            {
                switch (Request["action"].ToString())
                {
                    case "GetData":
                        GetData();
                        break;
                    case "DownloadAll":
                        DownloadAll();
                        break;
                    case "GetJsonCompany":
                        GetJsonCompany();
                        break;
                    default:
                        break;
                }
            }
        }

        private bool GetData()
        {
            try
            {
                int offset = 0;
                int limit = 15;
                string sort = "StartTime";
                string order = "DESC";
                string search = "";

                #region 拼接查询字段
                if (Request["search"] != null && Request["search"].Trim() != "")
                    search += "UserName like '%" + Request["search"].ToString() + "%' and ";
                if (Request["company"] != null && Request["company"].Trim() != "")
                    search += "Company = '" + Request["company"].ToString() + "' and ";
                if (Request["startTime"] != null && Request["startTime"].Trim() != "")
                    search += "StartTime>='" + Request["startTime"].ToString() + "' and ";
                if (Request["endTime"] != null && Request["endTime"].Trim() != "")
                    search += "StartTime<='" + Request["endTime"].ToString() + "' and ";
                search += "1=1";
                #endregion
                if (Request["sort"] != null)
                {
                    sort = Request["sort"].ToString().ToLower() == "destarttime" ? "StartTime" : Request["sort"].ToString();
                    order = Request["order"].ToString();
                }

                if (Request["offset"] != null)
                {
                    offset = Convert.ToInt32(Request["offset"]);
                    limit = Convert.ToInt32(Request["limit"]);
                }

                DataSet ds = DAL.RTKSurveyRec.GetListByPage(offset, limit, sort, order, search);
                int total = DAL.RTKSurveyRec.GetRecordCount(search, "haha");
                ds.Tables[0].Columns.Add("deStartTime", typeof(string));
                foreach (DataRow dr in ds.Tables[0].Rows)
                    dr["deStartTime"] = dr["StartTime"].ToString();
                if (total > 0)
                {
                    string jsonNews = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                    result = "{\"total\":" + total.ToString() + ",\"rows\":" + jsonNews + "}";
                    Response.ContentType = "application/Json";
                    Response.Write(result);
                    Response.End();
                    return true;
                }
                else
                {
                    result = null;
                    Response.ContentType = "application/Json";
                    Response.Write(result);
                    Response.End();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool GetJsonCompany()
        {
            DataSet ds = DAL.RTKSurveyRec.GetCompany("1=1");
            int total = ds.Tables[0].Rows.Count;
            if (total > 0)
            {
                string jsonCompany = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"message\":" + total.ToString() + ",\"value\":" + jsonCompany + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                result = null;
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }


        private void DownloadAll()
        {
            DataTable dt = DAL.RTKSurveyRec.GetList("1=1 order by id asc").Tables[0];
            WriteExcelWithNPOI(dt, "xls");
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
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "测量作业记录.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "测量作业记录.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
    }
}