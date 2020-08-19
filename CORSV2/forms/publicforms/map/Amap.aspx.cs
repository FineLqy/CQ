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
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}