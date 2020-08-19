using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.administrator.system
{
    public partial class ResourcesDownload : System.Web.UI.Page
    {
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }

            if (Request["action"] != null)
            {
                switch (Request["action"])
                {
                    case "GetData":
                        GetData();
                        break;
                    case "AddData":
                        Response.ContentType = "text/plain";
                        Response.Write(AddData());
                        Response.End();
                        break;
                    case "Delete":
                        DeleteById();
                        break;
                    case "Update":
                        UpdateData();
                        if (flag == -1)
                        {
                            Response.ContentType = "text/plain";
                            Response.Write("-1");
                            Response.End();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void GetData()
        {
            DataSet ds = DAL.ResourcesDownload.GetList("1=1");
            string jsonArea = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
            //int total = ds.Tables[0].Rows.Count;
            //string response = "{\"total\":@total,\"rows\":@rows}";
            //response = response.Replace("@total", total.ToString());
            //response = response.Replace("@rows", jsonArea);
            Response.ContentType = "application/Json";
            Response.Write(jsonArea);
            Response.End();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void DeleteById()
        {
            int id;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            for (int j = 0; j < temp.Length; j++)
            {
                id = Convert.ToInt32(temp[j]);
                DAL.ResourcesDownload.Delete(id);
            }
        }


        private int AddData()
        {
            if (DAL.ResourcesDownload.Exists(Request["resource"].ToString()))
            {
                return -3;
            }
            string savepath = Server.MapPath("~/upload/ResourceDownload/");
            string extension = Request.Files[0].FileName.Substring(Request.Files[0].FileName.LastIndexOf('.'));
            string filename = Request["resource"].ToString() + extension;
            try
            {
                Request.Files[0].SaveAs(savepath + filename);
                Model.ResourcesDownload rd = new Model.ResourcesDownload();
                rd.ResourceName = Request["resource"].ToString();
                rd.ResourcePath = savepath + filename;
                rd.UploadUser = Session["UserName"].ToString();
                rd.UploadTime = DateTime.Now;
                rd.Remark = "";
                DAL.ResourcesDownload.Add(rd);
                return 1;
            }
            catch
            {
                return -1;
            }




        }

        private void UpdateData()
        {

            int id = Convert.ToInt32(Request["ID"].ToString());
            Model.ResourcesDownload rd = DAL.ResourcesDownload.GetModel(id);
            rd.ResourceName = Request["resourcename"].Trim();
            flag = 1;
            DAL.ResourcesDownload.Update(rd);
            Response.ContentType = "text/plain";
            Response.Write("0");
            Response.End();
        }
    }
}