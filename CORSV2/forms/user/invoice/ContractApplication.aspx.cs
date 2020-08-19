using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.invoice
{
    public partial class ContractApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != "" && Request["id"] != null)
            {
                Session["id"] = Request["id"].ToString();
              Model.InvoiceList invoiceList= DAL.InvoiceList.GetModel(Convert.ToInt32(Session["id"]));
                UserNmae.Value = invoiceList.UserName;

            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string fullPathUrl = Server.MapPath(aaPh);//获取下载文件的路劲
            //    System.IO.FileInfo file = new System.IO.FileInfo(fullPathUrl);
            //    if (file.Exists)//判断文件是否存在
            //    {
            //        Response.Clear();
            //        Response.ClearHeaders();
            //        Response.Buffer = false;
            //        Response.AddHeader("content-disposition", "attachment;filename=" + file.Name);
            //        Response.AddHeader("cintent_length", "attachment;filename=" + HttpUtility.UrlDecode(file.Name));
            //        Response.AddHeader("cintent_length", file.Length.ToString());
            //        Response.ContentType = "application/octet-stream";
            //        Response.WriteFile(file.FullName);//通过response对象，执行下载操作
            //        Response.Flush();
            //        Response.End();


            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "dd", "alert('文件不存在')", true);
            //    }
            //}
            //catch
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "dd", "alert('下载成功')", true);
            //}


            Model.ContractApplication contractApplication = new Model.ContractApplication();
            Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(Convert.ToInt32(Session["id"]));
            invoiceList.ContractStatus = 4;
            DAL.InvoiceList.Update(invoiceList);
            string num= cs.VerifyCodeHelper.Number(4, true);
            contractApplication.ID =  invoiceList.UserName + DateTime.Now.Year + "0"+DateTime.Now.Month+ num;
          
            contractApplication.UserName = invoiceList.UserName;
            string id = contractApplication.ID;
             contractApplication.Address= this.address.Value;
            contractApplication.Contacts= this.contacts.Value;
            contractApplication.Phone= this.phone.Value;
            contractApplication.Price= invoiceList.Price;
            contractApplication.Type = "0";
             string aaPh= "/upload/Invoice/合同.docx";
            // System.IO.FileInfo file = new System.IO.FileInfo(aaPh);
            //contractApplication.ContractFile = file;
            contractApplication.ContractFile = aaPh;
            DAL.ContractApplication.Add(contractApplication);
            Response.Redirect("EndContract.aspx?ID=" + id + "");

        }
       
    }
}