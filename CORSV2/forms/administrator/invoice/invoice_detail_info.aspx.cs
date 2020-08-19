using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.invoice
{
    public partial class invoice_detail_info : System.Web.UI.Page
    {
        public static string invoice_path = "";
        public static string contract_path = "";

        public static int  invoiceListId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["action"].ToString()=="transferInvoiceListId"&&Request["id"]!=null)
            {
                contract.Style.Add("display","none");
                submitContractFile.Style.Add("display","none");
                string ff = Request["id"].ToString();
                invoiceListId = Convert.ToInt32(Request["id"].ToString());
                Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
                invoiceHead.Value = DAL.InvoiceInfo.GetModel(Convert.ToInt32(invoiceList.InvoiceInfoIndex)).Invoice;
                taxNum.Value = DAL.InvoiceInfo.GetModel(Convert.ToInt32(invoiceList.InvoiceInfoIndex)).TaxNum;

                if (invoiceList.Status==4&&invoiceList.InvoiceFile!="")
                {
                    invoiceFile.Src = invoiceList.InvoiceFile;
                    invoiceFile.Height = 500;
                    invoiceFile.Width = 1000;
                }
            }
            //else if (Request["action"].ToString() == "transferContractListId" && Request["id"] != null)
            //{
            //    invoice.Style.Add("display", "none");
            //    submitInvoiceFile.Style.Add("display", "none");

            //    string ff = Request["id"].ToString();
            //    invoiceListId = Convert.ToInt32(Request["id"].ToString());
            //    Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
            //    invoiceHead.Value = DAL.InvoiceInfo.GetModel(Convert.ToInt32(invoiceList.InvoiceInfoIndex)).Invoice;
            //    taxNum.Value = DAL.InvoiceInfo.GetModel(Convert.ToInt32(invoiceList.InvoiceInfoIndex)).TaxNum;
            //    if (invoiceList.Status==4)
            //    {
            //        invoiceFile.Src = invoiceList.ContractFile;
            //        invoiceFile.Height = 500;
            //        invoiceFile.Width = 1000;
            //    }
            //}
                
            else
            {

            }
            if (Request["action"] != null && Request["action"] == "AddData")
            {
                AddData();
            }
            if(Request["action"]!=null&&Request["action"]=="OK")
            {
                Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
                invoiceList.InvoiceFile = invoice_path;
                invoiceList.Status = 4;
                DAL.InvoiceList.Update(invoiceList);
                Response.Write("1");
                Response.End();
            }
            //if (Request["action"] != null && Request["action"] == "OK" && invoice_path == "")
            //{
            //    Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
            //    invoiceList.ContractFile = invoice_path;
            //    invoiceList.ContractStatus = 4;
            //    DAL.InvoiceList.Update(invoiceList);
            //    Response.Write("1");
            //    Response.End();
            //}
            
        }
        private int AddData()
        {
            string fileid = Request["field"];
            string filename = Request.Files[0].FileName;
            string[] extname = filename.Split('.');
            string temptime = DateTime.Now.ToString("yyyMMddhhmmssfff");
            string savepath = Server.MapPath("~/upload/Invoice/") + temptime + "." + extname[extname.Length - 1];
            Request.Files[0].SaveAs(savepath);
            switch (Request["field"])
            {
                case "invoice_path":
                    invoice_path = "/upload/Invoice/" + temptime + "." + extname[extname.Length - 1];
                    break;
                //case "contract_path":
                //    contract_path = "/upload/Invoice/" + temptime + "." + extname[extname.Length - 1];
                //    break;
                default:
                    break;
            }
            return 1;
        }
    }
}