using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.map
{
    public partial class Amap : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetStas())
                {
                    Response.Write("0");

                }
            }

        }
        /// <summary>
        /// 显示Map坐标点
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod()]
        public static string lodaa1(string t)
        {
            string strJson = string.Empty;
            DataSet ds1 = DAL.RTKUserStatus.GetMap();//单点坐标
          
            strJson = JsonConvert.SerializeObject(new { dt1 = ds1.Tables[0] });
            var serializer = new JavaScriptSerializer();

            serializer.MaxJsonLength = Int32.MaxValue;
            serializer.Serialize(strJson);
            return strJson;
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


            //int totalCount = DAL.CORSStationInfo.GetRecordCount(search);
            //if (offset + limit > totalCount)
            //{
            //    limit = totalCount - offset;
            //}
            DataSet ds = DAL.RTKUserStatus.GetOnline1();
          
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
               
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }
    }
}