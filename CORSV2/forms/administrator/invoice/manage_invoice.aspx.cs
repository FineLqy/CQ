using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;

namespace CORSV2.forms.administrator.invoice
{
    public partial class manage_invoice : System.Web.UI.Page
    {
        /// <summary>
        /// 设置全局静态变量belongArea
        /// </summary>
        public static string belongArea = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "xcq";
            //Session["UserType"] = "3";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 2 || Convert.ToInt32(Session["UserType"]) > 3)
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
                if (!Get_invoice())
                {
                    Response.Write("0");
                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                DeleteCors();
            }

            if (Request["verify"] != null && Request["status"] != null)
            {
                int invoiceListID = Convert.ToInt32(Request["verify"]);
                string status = Request["status"].ToString();
                verify(invoiceListID, status);
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
                DataTable dt = DAL.InvoiceList.GetList("1=1 order by id asc").Tables[0];
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
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "用户发票列表.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "用户发票列表.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
        /// <summary>
        /// 更新发票的申请处理状态
        /// </summary>
        /// <param name="invoiceListID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private bool verify(int invoiceListID, string status)
        {
            Model.InvoiceList invoicelist = DAL.InvoiceList.GetModel(invoiceListID);
            if (status == "OK")
            {
                invoicelist.Status = 3;

            }
            else
            {
                invoicelist.Status = -1;
            }

            DAL.InvoiceList.Update(invoicelist);
            return true;
        }
        private bool Get_invoice()
        {
            string sort = "SubmitTime";
            string order = "DESC";
            string search = "";
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();
            string strwhere = "1=1";
            if (Request["dataType"] != null && Request["cityType"] != null)
            {
                //int dataTypenum = int.Parse(Request["dataType"].ToString());
                if (Request["cityType"].ToString() != "全部")
                {
                    strwhere = "Status ='" + Request["cityType"].ToString() + "'";
                }
                else
                {

                }
            }
            //else
            //{
            //    if (belongArea != "")
            //        strwhere = "BelongArea ='" + belongArea + "'";
            //}
            if (Request["sort"] != null)
            {
                if (Request["sort"].ToString() == "verify")
                {
                    sort = "Status";
                }
                else if (Request["sort"].ToString() == "reSubmitTime")
                {
                    sort = "SubmitTime";

                }

                else if (Request["sort"].ToString() == "ReInvoiceType")
                {
                    sort = "InvoiceType";

                }
                else
                {
                    sort = Request["sort"].ToString();
                }
                order = Request["order"].ToString();

            }
            //strwhere =strwhere+ "and UserName='" + Session["UserName"].ToString() + "'";
            strwhere = strwhere + "and (Status= 2 or Status=3 or Status=4 or Status=-1)  ";
            int totalCount = DAL.InvoiceList.GetRecordCount(search, strwhere);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.InvoiceList.GetBriefList1(offset, limit, sort, order, search, strwhere);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("uploadfile", typeof(string));
            ds.Tables[0].Columns.Add("reSubmitTime", typeof(string));
            ds.Tables[0].Columns.Add("verify", typeof(string));

            ds.Tables[0].Columns.Add("Invoice", typeof(string));
            ds.Tables[0].Columns.Add("TaxNum", typeof(string));
            ds.Tables[0].Columns.Add("ReInvoiceType", typeof(string));
            ds.Tables[0].Columns.Add("invoiceStatus", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.InvoiceInfo invoiceInfo = DAL.InvoiceInfo.GetModel(Convert.ToInt32(dr["InvoiceInfoIndex"]));
                dr["Invoice"] = invoiceInfo.Invoice;
                dr["TaxNum"] = invoiceInfo.TaxNum;
                if (Convert.ToInt32(dr["InvoiceType"]) == 0)
                {
                    dr["ReInvoiceType"] = "普通发票";

                }
                else
                {
                    dr["ReInvoiceType"] = "增值税发票";

                }


                // string temp_time=((DateTime)dr["SubmitTime"]).ToString("yyyy-MM-dd");
                dr["reSubmitTime"] = dr["SubmitTime"].ToString();
                dr["uploadfile"] = "<a id='" + dr["ID"] + "' onclick= uploadfile(this.id) >查看详情</a>";


                if (dr["Status"].ToString() == "2")
                {
                    dr["verify"] = "<a style='color:red;' id='" + dr["ID"] + "' onclick= verify(this.id) >待审核</a>";
                }
                else if (dr["Status"].ToString() == "3")
                {
                    dr["verify"] = "<a style='color:red;' id='" + dr["ID"] + "'>待上传发票</a>";
                }
                else if (dr["Status"].ToString() == "4")
                {
                    dr["verify"] = "<a id='" + dr["ID"] + "'>已上传发票</a>";
                }
                //为-1的情况下则是已经驳回
                else if (dr["Status"].ToString() == "-1")
                {
                    dr["verify"] = "<a style='color:black;' id='" + dr["ID"] + "'>已驳回</a>";
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
                    string ordernumber = DAL.InvoiceList.GetModel(ids[m]).OrderNumber;
                    //Model.OrderList orderList = DAL.OrderList.GetModel(ordernumber);
                    //删除该订单
                    bool result = DAL.InvoiceList.Delete(ids[m]);
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