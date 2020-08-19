using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class SystemOperationLog1 : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //第一次加载的时候
            if (!IsPostBack)
            {

            }
            if (Request["action"] != null)
            {
                switch (Request["action"].ToString())
                {
                    case "GetData":
                        GetData();
                        break;
                }
            }
        }


        private bool GetData()
        {
            try
            {
                int LogType = Convert.ToInt32(Request["dataType"]);
                int offset = 0;
                int limit = 15;
                string sort = "LogTime";
                string order = "DESC";
                if (Request["sort"] != null)
                {
                    sort = Request["sort"].ToString().ToLower() == "detime" ? "LogTime" : Request["sort"].ToString();
                    order = Request["order"].ToString();
                }

                if (Request["offset"] != null)
                {
                    offset = Convert.ToInt32(Request["offset"]);
                    limit = Convert.ToInt32(Request["limit"]);
                }

                DataSet ds = DAL.SysLog.GetListByPage1(offset, limit, LogType, Session["UserName"].ToString(), sort, order);
                int total = DAL.SysLog.GetRecordCount();
                ds.Tables[0].Columns.Add("deTime", typeof(string));
                foreach (DataRow dr in ds.Tables[0].Rows)
                    dr["deTime"] = dr["LogTime"].ToString();
                if (total > 0)
                {
                    string jsonNews = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                    result = "{\"total\":" + total.ToString() + ",\"rows\":" + jsonNews + "}";
                    Response.ContentType = "application/Json";
                    Response.Write(result);
                    Response.End();
                    return true;
                }
                else
                {
                    result = null;
                    Response.ContentType = "application/Json";
                    Response.Write(result);
                    Response.End();
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}