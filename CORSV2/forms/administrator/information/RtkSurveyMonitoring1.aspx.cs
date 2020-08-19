using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class RtkSurveyMonitoring1 : System.Web.UI.Page
    {
        public string result = "";
        public string username = "";
        public string userCount = "";
        public string rate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
          
         
            DataSet ds = DAL.RTKUserStatus.GetList1(Session["UserName"].ToString());

            userCount = ds.Tables[0].Rows.Count.ToString();
            rate = Math.Round(GetGDL(ds) * 100.0, 1).ToString() + "%";

            if (Request["action"] != null)
            {
                switch (Request["action"])
                {
                    case "GetData":
                        if (!GetworkData())
                        {
                            Response.ContentType = "text/plain";
                            Response.Write("0");
                            Response.End();
                        }
                        break;
                    case "GetType":
                        GetType();
                        break;
                    case "GetUF":
                        GetUserCountAndFixedRate();
                        break;
                    case "GetAF":
                        GetAllCountAndFixedRate();
                        break;
                    case "disconnect":
                        Disconnect();
                        break;
                }

            }

        }


        private bool GetAllCountAndFixedRate()
        {
            DataSet ds = DAL.RTKUserStatus.GetList("IsOnline='1'and Company <> 'GW'");

            userCount = ds.Tables[0].Rows.Count.ToString();
            rate = Math.Round(GetGDL(ds) * 100.0, 1).ToString() + "%";
            Response.Clear();
            Response.Write(userCount + "_" + rate);
            Response.End();
            return true;
        }

        /// <summary>
        /// 从SourceTable中取得数据
        /// </summary>
        /// <returns></returns>
        private bool GetType()
        {
            DataSet ds = DAL.SourceTable.GetList("1=1");
            Response.ContentType = "application/Json";
            Response.Write(cs.JSONHelper.DataTableToJSON(ds.Tables[0]));
            Response.End();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetworkData()
        {


            DataSet ds = DAL.RTKUserStatus.GetList("IsOnline='1' and Company <>'GW'");

            // userCount = ds.Tables[0].Rows.Count.ToString();
            rate = Math.Round(GetGDL(ds) * 100.0, 1).ToString() + "%";
            int totalCount = ds.Tables[0].Rows.Count;

            ds.Tables[0].Columns.Add("Status", typeof(string));
            ds.Tables[0].Columns.Add("OnlineSpan", typeof(string));
            ds.Tables[0].Columns.Add("UseStarts", typeof(string));
            ds.Tables[0].Columns.Add("Source", typeof(string));
            ds.Tables[0].Columns.Add("LoginTime", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    //登陆时间
                    dr["LoginTime"] = dr["StartTime"].ToString();
                    //在线时长
                    DateTime starttime = DateTime.Parse(dr["StartTime"].ToString());
                    TimeSpan ontime = DateTime.Now - starttime;
                    dr["OnlineSpan"] = (ontime.Minutes / 60).ToString() + ":" + (ontime.Minutes % 60).ToString();
                    //状态
                    string[] state = dr["Remark"].ToString().Split('，');
                    dr["Status"] = state[1];
                    //卫星数
                    dr["UseStarts"] = state[2].Substring(state[2].Length - 2, 2);
                    //接入源
                    dr["Source"] = state[0];
                }
                catch (Exception)
                {

                }

            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonNews = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
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

        /// <summary>
        /// 获得用户数和固定率
        /// </summary>
        /// <returns></returns>
        private bool GetUserCountAndFixedRate()
        {
            int userCount = 0;
            DataSet ds = DAL.RTKUserStatus.GetList("IsOnline =1");
            double fixedRate = GetNumsGDL(ds, Request["Source"], ref userCount);
            string response = "{\"UserCount\":\"@UserCount\",\"FixedRate\":\"@FixedRate\"}";
            response = response.Replace("@UserCount", userCount.ToString());
            response = response.Replace("@FixedRate", Math.Round(fixedRate * 100.0, 1).ToString() + "%");
            Response.ContentType = "application/Json";
            Response.Write(response);
            Response.End();
            return true;
        }

 


        private double GetNumsGDL(DataSet ds, string Source, ref int Nums)
        {
            double gdl = 0.0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string remark = ds.Tables[0].Rows[i]["Remark"].ToString().Trim();
                string[] strs = remark.Split('-');
                if (strs.Length > 0)
                {
                    if (strs[0].Trim() == Source)
                    {
                        Nums += 1;
                        if (remark.Contains("RTK固定整数"))
                        {
                            gdl += 1;
                        }
                    }
                }
            }
            if (Nums != 0)
            {
                gdl = gdl / (double)Nums;
            }
            return gdl;
        }

        private double GetGDL(DataSet ds)
        {
            double gdl = 0.0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string remark = ds.Tables[0].Rows[i]["Remark"].ToString().Trim();
                if (remark.Contains("RTK固定整数"))
                {
                    gdl += 1;
                }
            }
            if (ds.Tables[0].Rows.Count != 0)
            {
                gdl = gdl / (double)ds.Tables[0].Rows.Count;
            }
            return gdl;
        }

        private void Disconnect()
        {
            string[] users = Request["users[]"].ToString().Split(',');
            foreach (string UserName in users)
            {
                Model.RTKUserStatus mrs = DAL.RTKUserStatus.GetModel(UserName);
                mrs.IsOnline = 0;
                DAL.RTKUserStatus.Update(mrs);
            }

        }
    }
}