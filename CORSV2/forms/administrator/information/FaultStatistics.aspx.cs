using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class FaultStatistics : System.Web.UI.Page
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
            int limit = 15;
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

        /// <summary>
        /// 显示故障次数
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod()]
        public static string lodaa1(string t)
        {
            string strJson = string.Empty;
            DataSet ds1= DAL.StationDownLog.GetNum();
            strJson = JsonConvert.SerializeObject(new { dt1 = ds1.Tables[0]});
            var serializer = new JavaScriptSerializer();

            serializer.MaxJsonLength = Int32.MaxValue;
            serializer.Serialize(strJson);
            return strJson;
        }


        /// <summary>
        /// 显示故障总数
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod()]
        public static string lodaa2(string t)
        {
            string strJson = string.Empty;
            DataSet ds2 = DAL.StationDownLog.GetCount();
            strJson = JsonConvert.SerializeObject(new { dt2 = ds2.Tables[0] });
            var serializer = new JavaScriptSerializer();

            serializer.MaxJsonLength = Int32.MaxValue;
            serializer.Serialize(strJson);
            return strJson;
        }




    }
}