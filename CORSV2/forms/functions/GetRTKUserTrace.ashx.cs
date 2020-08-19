using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
namespace CORSV2.forms.functions
{
    /// <summary>
    /// GetRTKUserTrace 的摘要说明
    /// </summary>
    public class GetRTKUserTrace : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
            string xuqiu = context.Request.Form["q"].ToString();
            string SelectedUserName = Convert.ToString(context.Request["users"].ToString());
            string[] strs = SelectedUserName.Split(';'); string sqlq = "";
            foreach (string username in strs)
            {
                if (username.Trim() != "")
                {
                    sqlq += "UserName='" + username + "' or ";
                }
                if (username.Trim() == "所有用户")
                {
                    sqlq += "1=1 or ";
                }
            }
            sqlq += "UserName='!@#$'";
            string StartTime = Convert.ToString(context.Request["startTime"].ToString());
            string EndTime = Convert.ToString(context.Request["endTime"].ToString());
            if (SelectedUserName == "")
            {

            }
            else
            {
                string sql = "select * from RTKUserPosiRec where (" + sqlq + ") and (Time>='" + StartTime + "' and Time<='" + EndTime + "') order by Time";
                DataSet ds = DBUtility.DBHelperSQL.GetDataSet(sql, connectionString);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    context.Response.Write("");
                }
                else
                {
                    ArrayList xal = new ArrayList(); ArrayList yal = new ArrayList(); ArrayList Tal = new ArrayList();
                    ArrayList Sxal = new ArrayList(); ArrayList Syal = new ArrayList(); ArrayList STal = new ArrayList();
                    int ConverIndex = 0;
                    int ConverNum = 0;
                    while (ConverIndex < ds.Tables[0].Rows.Count)
                    {
                        if (ConverNum >= 100)
                        {
                            ConverNum = 0;
                            System.Threading.Thread.Sleep(1);
                        }
                        int Nums = 100;
                        //转换WGS84坐标为百度坐标系坐标
                        string x = ""; string y = ""; string xy = "";
                        Sxal = new ArrayList(); Syal = new ArrayList(); STal = new ArrayList();
                        for (int i = 0; i < Nums; i++)
                        {

                            if (ConverIndex >= ds.Tables[0].Rows.Count)
                            {
                                break;
                            }
                            try
                            {
                                double Lon = Convert.ToDouble(ds.Tables[0].Rows[ConverIndex]["Lon"]);
                                double Lat = Convert.ToDouble(ds.Tables[0].Rows[ConverIndex]["Lat"]);
                                if (Lon < 60 || Lon > 140 || Lat < 10 || Lat > 70)
                                {
                                    ConverIndex = ConverIndex + 1;
                                    ConverNum = ConverNum + 1;
                                    continue;
                                }
                            }
                            catch
                            {
                                ConverIndex = ConverIndex + 1;
                                ConverNum = ConverNum + 1;
                                continue;
                            }
                            if ((ConverIndex == ds.Tables[0].Rows.Count - 1) || i == (Nums - 1))
                            {
                                x = x + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString();
                                y = y + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString();
                                xy = xy + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString() + "," + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString();
                            }
                            else
                            {
                                x = x + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString() + ",";
                                y = y + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString() + ",";
                                xy = xy + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString() + "," + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString() + ";";
                            }
                            STal.Add(ds.Tables[0].Rows[ConverIndex]["UserName"].ToString() + "_" + ds.Tables[0].Rows[ConverIndex]["Time"].ToString());
                            ConverIndex = ConverIndex + 1;
                            ConverNum = ConverNum + 1;

                        }
                        string uri = "http://api.map.baidu.com/ag/coord/convert?from=0&to=4&x=" + x + "&y=" + y + "&mode=1";
                        uri = "http://api.map.baidu.com/geoconv/v1/?coords=" + xy + "&from=1&to=5&ak=7bGCq1WUPVv5H4LDIpH7u12v";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                Stream stream = response.GetResponseStream();
                                StreamReader srr = new StreamReader(stream, Encoding.Default);
                                string linedata = srr.ReadLine();
                                JsonData jd = JsonMapper.ToObject(linedata);

                                JsonData jdres = jd["result"];
                                foreach (JsonData jdre in jdres)
                                {
                                    Sxal.Add(jdre["x"].ToString());
                                    Syal.Add(jdre["y"].ToString());
                                }


                            }
                        }
                        catch (Exception er)
                        {
                            Sxal = new ArrayList(); Syal = new ArrayList(); STal = new ArrayList();
                            //xal = new ArrayList();
                            //yal = new ArrayList();
                            //Tal = new ArrayList();
                        }
                        finally
                        {
                            xal.AddRange(Sxal); yal.AddRange(Syal); Tal.AddRange(STal);
                        }

                    }
                    string jieguo = "";

                    if (xal.Count > 0)
                    {
                        for (int i = 0; i < xal.Count; i++)
                        {
                            if (jieguo == "")
                            {
                                jieguo = jieguo + xal[i].ToString() + "?" + yal[i].ToString() + "?" + Tal[i].ToString();
                            }
                            else
                            {
                                jieguo = jieguo + "?" + xal[i].ToString() + "?" + yal[i].ToString() + "?" + Tal[i].ToString();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (jieguo == "")
                            {
                                jieguo = jieguo + ds.Tables[0].Rows[i]["Lon"].ToString() + "?" + ds.Tables[0].Rows[i]["Lat"].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + "_" + ds.Tables[0].Rows[i]["Time"].ToString();
                            }
                            else
                            {
                                jieguo = jieguo + "?" + ds.Tables[0].Rows[i]["Lon"].ToString() + "?" + ds.Tables[0].Rows[i]["Lat"].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + "_" + ds.Tables[0].Rows[i]["Time"].ToString();
                            }
                        }
                    }
                    context.Response.Write(jieguo);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}