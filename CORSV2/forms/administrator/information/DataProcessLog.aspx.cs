using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;

namespace CORSV2.forms.administrator.information
{
    public partial class DataProcessLog : System.Web.UI.Page
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
                string sort = "Time";
                string order = "DESC";
                string search = "";
                if (Request["search"] != null)
                    search = Request["search"].ToString();
                if (Request["sort"] != null)
                {
                    sort = Request["sort"].ToString().ToLower() == "detime" ? "Time" : Request["sort"].ToString();
                    order = Request["order"].ToString();
                }

                if (Request["offset"] != null)
                {
                    offset = Convert.ToInt32(Request["offset"]);
                    limit = Convert.ToInt32(Request["limit"]);
                }

                DataSet ds = DAL.CoorTransRec.GetListByPage(offset, limit, sort, order, search);
                int total = DAL.CoorTransRec.GetRecordCountBySearch(search);
                ds.Tables[0].Columns.Add("deTime", typeof(string));
                foreach (DataRow dr in ds.Tables[0].Rows)
                    dr["deTime"] = dr["Time"].ToString();
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


        private void DownloadAll()
        {
            DataTable dt = DAL.CoorTransRec.GetList("1=1 order by id asc").Tables[0];
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
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "事后坐标记录.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "事后坐标记录.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
    }
}