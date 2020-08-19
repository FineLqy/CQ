using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (Request["PostBack"] != null && Request["PostBack"].ToString() == "true")
            {
                if (Request["Title"] != null && Request["Title"] != "")
                    if (NewNews())
                    {
                        Response.Write("成功添加新闻");
                    }
                    else
                    {
                    }
            }
        }
        private bool NewNews()
        {
            try
            {
                string Title = Request["Title"];
                string Details = Request["Details"];
                DateTime dt = DateTime.Now;
                //string Author = Session["user"].ToString();
                string Author = "admin";
                Model.News news = new Model.News();
                news.Title = Title;
                news.Author = Author;
                news.Time = dt;
                news.Details = Details;
                return DAL.News.Add(news);
            }
            catch (Exception e)
            {
                Response.Write("新闻信息不完整，可能是缺少标题或者身份信息已过期，请尝试重新登录");
                return false;
            }
        }
    }
}