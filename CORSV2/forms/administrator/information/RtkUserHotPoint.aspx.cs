using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace CORSV2.forms.administrator.information
{
    public partial class RtkUserHotPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }

        }
        public string hotpointlat;
        public string hotpointlon;

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if ((sd.Value == "") || (ed.Value == ""))
            {
                sd.Value = (DateTime.Now.Year).ToString() + "-1";
                ed.Value = (DateTime.Now.Year + 1).ToString() + "-1";
            }

            DateTime StartTime = DateTime.Parse(sd.Value);//开始时间
            DateTime EndTime = DateTime.Parse(ed.Value);//结束时间

            if (DateTime.Compare(StartTime, EndTime) > 0)
            {
                Response.Write("<script>alert('请输入正确截止时间!')</script>");
                ed.Value = null;
                return;
            }
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // 实例化数据库连接对象
            SqlConnection conn = new SqlConnection(strConnection);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select Time,Lat,Lon from RTKUserPosiRec";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            List<List<string>> hotpoint = new List<List<string>>();//保存数据库提取的数据
            List<List<string>> HotPoint = new List<List<string>>();//保存选择时间内的经纬度，先纬度，后经度
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                List<string> hp = new List<string>();
                hp.Add(reader[0].ToString());//时间
                hp.Add(reader[1].ToString());//维度
                hp.Add(reader[2].ToString());//经度
                hotpoint.Add(hp);
            }
            for (int i = 0; i < hotpoint.Count; i++)
            {
                DateTime t = DateTime.Parse(hotpoint[i][0]);
                if (DateTime.Compare(StartTime, t) <= 0 && DateTime.Compare(t, EndTime) <= 0)
                {
                    List<string> HP = new List<string>();
                    HP.Add(hotpoint[i][1]);
                    HP.Add(hotpoint[i][2]);
                    HotPoint.Add(HP);
                }
            }
            for (int j = 0; j < HotPoint.Count; j++)
            {
                hotpointlat = hotpointlat + HotPoint[j][0] + ',';
                hotpointlon = hotpointlon + HotPoint[j][1] + ',';
            }
            if (hotpointlat != null)
            {
                hotpointlat = hotpointlat.Remove(hotpointlat.Length - 1);
                hotpointlon = hotpointlon.Remove(hotpointlon.Length - 1);
            }
            conn.Close();
        }
    }
}