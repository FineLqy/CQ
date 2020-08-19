using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class Ephemeris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] != null)
            {
                switch (Request["action"])
                {
                    case "GetGPSDate":
                        GetGPSDate();
                        break;
                }
            }
        }

        private void GetGPSDate()
        {
            string date = Request["date"].ToString();
            DateTime dt = Convert.ToDateTime(date);
            int doy = dt.DayOfYear;
            TIME ttime = new TIME();
            ttime.wYear = dt.Year;
            ttime.byMonth = dt.Month;
            ttime.byDay = dt.Day;
            GPSTIME gpstime = new GPSTIME();
            time.tmTimeToGPSTime(ref ttime, ref gpstime);
            time.tmGPSTimeToTime(ref gpstime, ref ttime);
            int gpsweek = Convert.ToInt32(gpstime.lWeek);
            int dayofweek = Convert.ToInt32(ttime.byDayOfWeek);
            Response.ContentType = "text/plain";
            Response.Write("1;" + gpsweek + ";" + dayofweek + ";" + doy);
            Response.End();
        }
    }
}