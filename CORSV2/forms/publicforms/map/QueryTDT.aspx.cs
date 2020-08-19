using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;

namespace CORSV2.forms.publicforms.map
{
    public partial class QueryTDT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] == "loadsta")
            {
                DataSet ds = DAL.CORSStationInfo.GetList("1=1");
                ds.Tables[0].Columns.Add("L", typeof(string));
                ds.Tables[0].Columns.Add("B", typeof(string));

                foreach (DataRow dr in ds.Tables[0].Rows)//行
                {

                    cs.GEODETIC b = new cs.GEODETIC();
                    b.latdms = double.Parse(dr["Lat"].ToString());
                    b.londms = double.Parse(dr["Lon"].ToString());

                    //dr["B"] = b.lat.ToString("0.000000");
                    //dr["L"] = b.lon.ToString("0.000000");
                    dr["B"] = dr["Lat"].ToString();
                    dr["L"] = dr["Lon"].ToString();
                    dr["B"] = ((int)(double.Parse(dr["B"].ToString()) * 10000) / 10000.0).ToString();
                    dr["L"] = ((int)(double.Parse(dr["L"].ToString()) * 10000) / 10000.0).ToString();
                }
                Response.Clear();
                Response.Write(CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]));
                Response.End();
            }

            if (Request["action"] == "loaddelaynay")
            {
                List<cs.Point> PL = new List<cs.Point>();
                DataSet ds = DAL.CORSStationInfo.GetList("1=1");
                ds.Tables[0].Columns.Add("L", typeof(string));
                ds.Tables[0].Columns.Add("B", typeof(string));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //GEODETIC b = new GEODETIC();
                    //b.latdms = double.Parse(dr["Lat"].ToString());
                    //b.londms = double.Parse(dr["Lon"].ToString());

                    //dr["B"] = b.lat.ToString("0.000000");
                    //dr["L"] = b.lon.ToString("0.000000");
                    dr["B"] = dr["Lat"].ToString();
                    dr["L"] = dr["Lon"].ToString();

                    int a = (int)(double.Parse(dr["B"].ToString()) * 10000);
                    int b = (int)(double.Parse(dr["L"].ToString()) * 10000);
                    cs.Point p = new cs.Point(a, b);
                    PL.Add(p);
                }
                cs.Delaunay da = new cs.Delaunay();

                ArrayList arr = da.create(PL);


                DataTable dt = new DataTable();
                dt.Columns.Add("spB", typeof(string));
                dt.Columns.Add("spL", typeof(string));
                dt.Columns.Add("epB", typeof(string));
                dt.Columns.Add("epL", typeof(string));
                for (int i = 0; i < arr.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["spB"] = ((cs.Line)arr[i]).Begin.X / 10000.0;
                    dr["spL"] = ((cs.Line)arr[i]).Begin.Y / 10000.0;
                    dr["epB"] = ((cs.Line)arr[i]).End.X / 10000.0;
                    dr["epL"] = ((cs.Line)arr[i]).End.Y / 10000.0;
                    dt.Rows.Add(dr);

                }
                string re = CORSV2.cs.JSONHelper.DataTableToJSON(dt);
                Response.Clear();
                Response.Write(re);
                Response.End();
            }

        }
    }
}