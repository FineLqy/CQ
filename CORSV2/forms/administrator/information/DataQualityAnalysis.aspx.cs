using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class DataQualityAnalysis : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["UserName"] == null)
            //{

            //    Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
            //    Response.End();
            //}
            if (!IsPostBack)
            {

            }
        

            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetStas())
                {
                    Response.Write("0");

                }
            }
         
        }
        private bool GetStas()
        {
            string search = "";
            int offset = 0;
            int limit = 25;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();


            int totalCount = DAL.CORSStationInfo.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.CORSStationInfo.GetBriefList(offset, limit, search);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("deIsOK", typeof(string));
            ds.Tables[0].Columns.Add("buttonequip", typeof(string));
            ds.Tables[0].Columns.Add("SiteMonitoring", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
               
                if (dr["IsOK"].ToString() == "1")
                {
                    dr["deIsOK"] = "正常";
                }
                else
                {
                    dr["deIsOK"] = "<a style = 'color:red;'>异常</a>";
                }
            }
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
     
       
    }
}