using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.invoice
{
    public partial class EndContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ID"] != "" && Request["ID"] != null)
            {
                Session["id"] = Request.QueryString["ID"].ToString();
                Model.ContractApplication contractApplication = DAL.ContractApplication.GetModel(Session["id"].ToString());
                ContractId.Text = contractApplication.ID;


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

                Model.ContractApplication contractApplication = DAL.ContractApplication.GetModel(Session["id"].ToString());

                try
                {
                    string fullPathUrl = Server.MapPath(contractApplication.ContractFile);//获取下载文件的路劲
                    System.IO.FileInfo file = new System.IO.FileInfo(fullPathUrl);
                    if (file.Exists)//判断文件是否存在
                    {
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.Buffer = false;
                        Response.AddHeader("content-disposition", "attachment;filename=" + file.Name);
                        Response.AddHeader("cintent_length", "attachment;filename=" + HttpUtility.UrlDecode(file.Name));
                        Response.AddHeader("cintent_length", file.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(file.FullName);//通过response对象，执行下载操作
                        Response.Flush();
                        Response.End();


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "dd", "alert('文件不存在')", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dd", "alert('下载成功')", true);
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

         Model.ContractApplication contractApplication = DAL.ContractApplication.GetModel(Session["id"].ToString());
            Response.Redirect("FormalContract.aspx?id=" +contractApplication.ID);
           
        }
    }
}