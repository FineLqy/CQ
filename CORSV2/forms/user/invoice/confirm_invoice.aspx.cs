using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.invoice
{
    public partial class confirm_invoice : System.Web.UI.Page
    {
        public static int invoiceListId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "xcq";
            //Session["UserType"] = "3";

            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] != null && Request["action"] == "GetData")
            {
             
                if (!getInvoiceInfo())
                {
     
                }
        
            }
            if (Request["invoiceListId"] != null)
            {
                invoiceListId = Convert.ToInt32(Request["invoiceListId"]);
                int ff = 4;
            }
            //else
            //{
            //    Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
            //    Response.End();
            //}

      
            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                deleteInvoiceInfo();
            }

            if (Request["invoiceInfoId"] != null)
            {
                submitInvoiceInfo();
            }

        }
        private void submitInvoiceInfo()
        {
           // string a = Request["invoiceInfoId"];
            Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
            invoiceList.InvoiceInfoIndex = Request["invoiceInfoId"].ToString();
            invoiceList.Status = 2;
            DAL.InvoiceList.Update(invoiceList);
                Response.Clear();
                Response.Write("OK");
                Response.End();

        }
        private bool getInvoiceInfo()
        {
            string sort = "UserName";
            string order = "DESC";
            string search = "";
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            //定义查询条件语句
            string strwhere = "1=1";
            strwhere = "UserName='" + Session["UserName"].ToString() + "'";

            int totalCount = DAL.InvoiceInfo.GetRecordCount(search);
            //toolbar.Style.Add(HtmlTextWriterStyle.Display, "none");
            //fd.Attributes.CssStyle.Value = "display:none";
            //fd.Visible = false;
            //if (totalCount>0)
            //{
            //    message_info.Style.Add(HtmlTextWriterStyle.Display, "none");
            //    message_info.Style["display"] = "none";
            //    //message_info.Visible = false;
            //}
            //if (totalCount >5)
            //{
            //    add_message_info.Style.Add(HtmlTextWriterStyle.Display, "none");
            //   // add_message_info.Visible = false;//Style["display"] = "none";
            //}
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.InvoiceInfo.GetBriefList1(offset, limit, sort, order, search);
            ds.Tables[0].Columns.Add("button", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
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
        private void deleteInvoiceInfo()
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
                    //删除该发票信息
                    bool result = DAL.InvoiceInfo.Delete(ids[m]);
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