using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CORSV2.forms.administrator.system
{
    public partial class NewsManage : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
            }
            if (Convert.ToInt32(Session["UserType"]) != 3)
            {
                Response.Write("<script>alert(\"没有权限！\");location.href = location.origin+\"/Index.aspx\";</script>");
            }
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetNews())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteNews")
            {
                DeleteNews();
            }


        }
        private bool GetNews()
        {
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            DataSet ds = DAL.News.GetBriefList(offset, limit);
            int totalCount = DAL.News.GetRecordCount();
            ds.Tables[0].Columns.Add("deTime", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
                dr["deTime"] = dr["Time"].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonNews = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonNews + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DeleteNews()
        {
            int[] ids;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            ids = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                ids[i] = Convert.ToInt32(temp[i]);
            DAL.News.DeleteByIDs(ids);

        }
    }
}