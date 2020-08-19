using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using LitJson;
using System.Data;

namespace CORSV2.forms.functions
{
    public partial class GetOnlineUserDt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
            string xuqiu = Request.Form["q"].ToString();
            string sql = "select * from RTKUserStatus where IsOnline =1";
            DataSet ds = DBUtility.DBHelperSQL.GetDataSet(sql, connectionString);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("");
            }
            else
            {
                //转换WGS84坐标为百度坐标系坐标
                ArrayList xal = new ArrayList(); ArrayList yal = new ArrayList();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    xal.Add(ds.Tables[0].Rows[i]["Lon"].ToString());
                    yal.Add(ds.Tables[0].Rows[i]["Lat"].ToString());
                }


                string jieguo = "";
                if (xal.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (jieguo == "")
                        {
                            jieguo = jieguo + xal[i].ToString() + "?" + yal[i].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + ":" + ds.Tables[0].Rows[i]["Remark"].ToString();
                        }
                        else
                        {
                            jieguo = jieguo + "?" + xal[i].ToString() + "?" + yal[i].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + ":" + ds.Tables[0].Rows[i]["Remark"].ToString();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (jieguo == "")
                        {
                            jieguo = jieguo + ds.Tables[0].Rows[i]["Lon"].ToString() + "?" + ds.Tables[0].Rows[i]["Lat"].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + ":" + ds.Tables[0].Rows[i]["Remark"].ToString();
                        }
                        else
                        {
                            jieguo = jieguo + "?" + ds.Tables[0].Rows[i]["Lon"].ToString() + "?" + ds.Tables[0].Rows[i]["Lat"].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + ":" + ds.Tables[0].Rows[i]["Remark"].ToString();
                        }
                    }
                }
                Response.Write(jieguo);
            }
        }
    }
}