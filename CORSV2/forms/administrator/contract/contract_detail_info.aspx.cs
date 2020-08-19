using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.contract
{
    public partial class contract_detail_info : System.Web.UI.Page
    {
        public static string invoice_path = "";
        public static string contract_path = "";
        public static string linkContractFile = "";
        public static int invoiceListId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               if (Request["action"].ToString() == "transferContractListId" && Request["id"] != null)
                {
                    invoice.Style.Add("display", "none");
                    submitInvoiceFile.Style.Add("display", "none");

                    string ff = Request["id"].ToString();
                    invoiceListId = Convert.ToInt32(Request["id"].ToString());

                    string template = " <li><a id=\"contract_file_symbol\" href=\"@href\"download=\"@download\" style=\"font-size: x-large\">@content</a></li>";


                    Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
                    invoiceHead.Value = DAL.InvoiceInfo.GetModel(Convert.ToInt32(invoiceList.InvoiceInfoIndex)).Invoice;
                    taxNum.Value = DAL.InvoiceInfo.GetModel(Convert.ToInt32(invoiceList.InvoiceInfoIndex)).TaxNum;
                    if (invoiceList.ContractStatus == 4&&invoiceList.ContractFile!="")
                    {
                        //invoiceFile.Src = invoiceList.ContractFile;
                        //invoiceFile.Height = 500;
                        //invoiceFile.Width = 1000;
                        string temp = template;
                        //temp = temp.Replace("@href",url+port+@"\ResourceDownload\"+rsFullName);
                        temp = temp.Replace("@href", invoiceList.ContractFile);
                        temp = temp.Replace("@download", invoiceList.ContractFile);
                        temp = temp.Replace("@content", "合同文件");
                        linkContractFile = temp;
                    }
                    else
                    {
                        //linkContractFile = "";
                    }
                }

                else
                {

                }
            }

            if (Request["action"] != null && Request["action"] == "AddData")
            {
                AddData();
            }
            if (Request["action"] != null && Request["action"] == "OK")
            {
                Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(invoiceListId);
                invoiceList.ContractFile = contract_path;
                invoiceList.ContractStatus = 4;
                DAL.InvoiceList.Update(invoiceList);
                Response.Write("1");
                Response.End();
            }

        }
        private int AddData()
        {
            string fileid = Request["field"];
            string filename = Request.Files[0].FileName;
            string[] extname = filename.Split('.');
            string temptime = DateTime.Now.ToString("yyyMMddhhmmssfff");
            string savepath = Server.MapPath("~/upload/Contract/") + temptime + "." + extname[extname.Length - 1];
            Request.Files[0].SaveAs(savepath);
            string template = " <li><a id=\"contract_file_symbol\" href=\"@href\"download=\"@download\" style=\"font-size: x-large\">@content</a></li>";
            switch (Request["field"])
            {
                case "contract_path":
                    contract_path = "/upload/Contract/" + temptime + "." + extname[extname.Length - 1];
                    string temp = template;
                    //temp = temp.Replace("@href",url+port+@"\ResourceDownload\"+rsFullName);
                    temp = temp.Replace("@href", contract_path);
                    temp = temp.Replace("@download", contract_path);
                    temp = temp.Replace("@content", temptime);
                    linkContractFile = temp;
                    break;
                default:
                    break;
            }
            Response.ContentType = "text/plain";
            Response.Write("1");
            Response.End();
            return 1;
        }
    }
}