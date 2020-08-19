using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.invoice
{
    public partial class set_invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            if(Request["action"]!=null && Request["action"]=="invoiceInfoSubmit")
            {
                Model.InvoiceInfo invoiceInfo = new Model.InvoiceInfo();
                invoiceInfo.UserName = Session["UserName"].ToString();
                invoiceInfo.Invoice = Request.Form["invoice_header"].ToString();
                if (Request.Form["user_type"].ToString()=="2")
                {
                    invoiceInfo.AccountNum = Request.Form["bank_account"].ToString();
                    invoiceInfo.Bank = Request.Form["bank_name"].ToString();
                    invoiceInfo.TaxNum = Request.Form["registration_certification"].ToString();
                    invoiceInfo.Tel = Request.Form["tel"].ToString();
                    invoiceInfo.UnitAddress = Request.Form["address"].ToString();
                }
                try
                {
                    DAL.InvoiceInfo.Add(invoiceInfo);
                }
                catch
                {
                    return;
                }
                string json = "{\"code\":200}";
                Response.Write(json);
                Response.End();
            }
        }
    }
}