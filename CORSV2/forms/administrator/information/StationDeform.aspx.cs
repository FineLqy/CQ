using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;


namespace CORSV2.forms.administrator.information
{
    public partial class StationDeform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            DataSet ds = DAL.CORSStationInfo.GetList("1=1");

            year.Items.Add(DateTime.Now.Year.ToString());
            year.Items.Add((DateTime.Now.Year - 1).ToString());
            month.SelectedIndex = DateTime.Now.Month - 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                station.Items.Add(dr["StationName"].ToString());
            }
            if (Request["action"] == "load")
            {
                string time = Request["year"].ToString().Trim() + "/" + Request["Month"].ToString().Trim() + "/" + 1;
                DateTime dt = DateTime.Parse(time);
                int day = dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1).Day;

                string x = "";
                string ee = "";
                string nn = "";
                string uu = "";
                try
                {
                    for (int i = 1; i <= day; i++)
                    {
                        x += (i + ",");
                        string newtime = Request["year"].ToString().Trim() + "/" + Request["Month"].ToString().Trim() + "/" + i;
                        DateTime newtt = DateTime.Parse(newtime);
                        string stachange = newtt.AddHours(-32).Year.ToString() + newtt.AddHours(-32).DayOfYear.ToString("000") + ".cmp";//基站偏移文件        
                        bool exit = false;
                        List<List<string>> stationneu = new List<List<string>>();

                        if (File.Exists(Server.MapPath("~/Product/station/") + stachange))
                        {
                            exit = true;
                            StreamReader readerchange = new StreamReader(Server.MapPath("~/Product/station/") + stachange);
                            for (string line = readerchange.ReadLine(); line != null; line = readerchange.ReadLine())
                            {
                                string[] neu = getnewstr(line).Split(' ');
                                List<string> stneu = new List<string>();
                                stneu.Add(neu[0]);
                                stneu.Add(neu[1]);
                                stneu.Add(neu[2]);
                                stneu.Add(neu[3]);
                                stationneu.Add(stneu);
                            }
                            readerchange.Close();
                        }
                        else
                        {
                            string[] files = Directory.GetFiles(Server.MapPath("~/Product/station/"), "*.cmp");
                            if (files.Length > 0)
                            {
                                exit = true;
                                StreamReader readerchange = new StreamReader(files[0]);
                                for (string line = readerchange.ReadLine(); line != null; line = readerchange.ReadLine())
                                {
                                    string[] neu = getnewstr(line).Split(' ');
                                    List<string> stneu = new List<string>();
                                    stneu.Add(neu[0]);
                                    stneu.Add(neu[1]);
                                    stneu.Add(neu[2]);
                                    stneu.Add(neu[3]);
                                    stationneu.Add(stneu);
                                }
                                readerchange.Close();
                            }
                        }
                        Model.CORSStationInfo ss = DAL.CORSStationInfo.GetModel(Request["station"].ToString().Trim());
                        ee += StaNEU(ss.StationOName, stationneu)[0] + ",";
                        nn += StaNEU(ss.StationOName, stationneu)[1] + ",";
                        uu += StaNEU(ss.StationOName, stationneu)[2] + ",";


                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    cs.WebLogger.WriteErroLog(ex.ToString());    //输出到文件中
                    Response.Write("200");
                    Response.End();
                    //Response.Write("<script>alert(\"1\")</script>");
                    return;
                }

                x = x.Substring(0, x.Length - 1) + ";";
                ee = ee.Substring(0, ee.Length - 1) + ";";
                nn = nn.Substring(0, nn.Length - 1) + ";";
                uu = uu.Substring(0, uu.Length - 1) + ";";
                //ee = "-1.7,2.1,0.5,-1.2,-2.3,2,4,1,2,1.4,-1,3,-1.1,0.4,-0.8,1.1,2.0,-3.7,5,2,1,-4,3,-3.2,4,1.2,3.4,-5.1,-1,2.1,-4.6;";
                //nn = "-2.3,2,4,1,2,1.4,-1,3,-0.8,1.1,2.0,-3.7,5,-1.7,2.1,0.5,1.1,2.0,-3.7,1,-4,3,2.1,0.5,-1.2,3.2,4.3,-5.6,2.4,-1.1,3;";
                //uu = "-1.2,-2.3,2,4,1,7.8,-13,2.4,3.1,-11.6,-4,1.4,-1,5.3,1.2,-8.6,3,-2,1,2.3,-2.1,7,-1,-6,8,2,11,-2,4.1,2,-1";


                string data = x + ee + nn + uu;

                Response.Clear();
                Response.Write(data);
                Response.End();
            }
        }
        //进行基站匹配
        protected string[] StaNEU(string stationoname, List<List<string>> stalist)
        {
            string[] stneu = new string[3] { "-", "-", "-" };
            for (int i = 0; i < stalist.Count; i++)
            {
                if (stalist[i][0] == stationoname)
                {
                    stneu[0] = stalist[i][1];
                    stneu[1] = stalist[i][2];
                    stneu[2] = stalist[i][3];
                    break;
                }
            }
            return stneu;
        }
        public string getnewstr(string str)
        {
            return Regex.Replace(str.Trim(), "\\s+", " ");
        }
    }
}