using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Text;
using LitJson;
namespace CORSV2.forms.functions
{
    /// <summary>
    /// GetWorkingArea 的摘要说明
    /// get working area list
    /// </summary>
    public class GetWorkingArea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
            //string xuqiu = Request.Form["q"].ToString();
            string jieguo = context.Request["AreaString"].ToString();
            string[] jgs = jieguo.Split(',');
            string x = ""; string y = "";
            for (int i = 0; i < jgs.Length / 2; i++)
            {
                if (i == jgs.Length / 2)
                {
                    x = x + jgs[2 * i + 0];
                    y = y + jgs[2 * i + 1];
                }
                else
                {
                    x = x + jgs[2 * i + 0] + ",";
                    y = y + jgs[2 * i + 1] + ",";
                }
            }

            ArrayList xal = new ArrayList(); ArrayList yal = new ArrayList(); ArrayList Tal = new ArrayList();
            ArrayList Sxal = new ArrayList(); ArrayList Syal = new ArrayList(); ArrayList STal = new ArrayList();
            int ConverIndex = 0;
            int ConverNum = 0;
            while (ConverIndex < jgs.Length / 2)
            {
                if (ConverNum >= 30)
                {
                    ConverNum = 0;
                    System.Threading.Thread.Sleep(100);
                }
                //转换WGS84坐标为百度坐标系坐标
                x = ""; y = "";
                Sxal = new ArrayList(); Syal = new ArrayList(); STal = new ArrayList();
                for (int i = 0; i < 5; i++)
                {

                    if (ConverIndex >= jgs.Length / 2)
                    {
                        break;
                    }
                    if ((ConverIndex == jgs.Length / 2 - 1) || i == 4)
                    {
                        x = x + jgs[2 * ConverIndex + 0];
                        y = y + jgs[2 * ConverIndex + 1];
                    }
                    else
                    {
                        x = x + jgs[2 * ConverIndex + 0] + ",";
                        y = y + jgs[2 * ConverIndex + 1] + ",";
                    }
                    //STal.Add(ds.Tables[0].Rows[ConverIndex]["UserName"].ToString() + "_" + ds.Tables[0].Rows[ConverIndex]["Time"].ToString());
                    ConverIndex = ConverIndex + 1;
                    ConverNum = ConverNum + 1;

                }
                string uri = "http://api.map.baidu.com/ag/coord/convert?from=0&to=4&x=" + x + "&y=" + y + "&mode=1";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream stream = response.GetResponseStream();
                        StreamReader srr = new StreamReader(stream, Encoding.Default);
                        string linedata = srr.ReadLine();
                        JsonData jd = JsonMapper.ToObject(linedata);
                        foreach (JsonData eachjd in jd)
                        {
                            //调用FromBase64String()返回解密后的byte数组
                            byte[] temps = Convert.FromBase64String((String)eachjd["x"]);
                            //把byte数组转化为String类型
                            String tempd = System.Text.Encoding.Default.GetString(temps);
                            Sxal.Add(tempd);
                            temps = Convert.FromBase64String((String)eachjd["y"]);
                            //把byte数组转化为String类型
                            tempd = System.Text.Encoding.Default.GetString(temps);
                            Syal.Add(tempd);

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
            if (xal.Count > 0)
            {
                jieguo = "";
                for (int i = 0; i < xal.Count; i++)
                {
                    if (i == xal.Count - 1)
                    {
                        jieguo = jieguo + xal[i].ToString() + "," + yal[i].ToString();
                    }
                    else
                    {
                        jieguo = jieguo + xal[i].ToString() + "," + yal[i].ToString() + ",";
                    }
                }
            }
            else
            {

            }
            context.Response.Write(jieguo);
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