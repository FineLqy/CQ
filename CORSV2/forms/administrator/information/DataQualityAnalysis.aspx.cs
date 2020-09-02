using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class DataQualityAnalysis : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["UserName"] == null)
            //{

            //    Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
            //    Response.End();
            //}



            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetStas())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "GetData1")
            {
                
                    DateTime st = Convert.ToDateTime(Request["data1"].ToString());
                    DateTime et = DateTime.Now;
                    int days = (et - st).Days;

              
                    Dictionary<DateTime, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> r = new Dictionary<DateTime, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>();
                    HttpServerUtility server = System.Web.HttpContext.Current.Server;
                    string url = server.MapPath("/ObsQuality/");
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(url);
                    FileInfo[] ff = di.GetFiles("*.result");//只取文本文du档
                    for (int i = 0; i < days; i++)
                    {
                        Dictionary<string, Dictionary<string, Dictionary<string, string>>> d = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
                        DateTime dateTime = st.AddDays(i);
                  
                    string fileG = server.MapPath("/ObsQuality/" + dateTime.Year + "/" + dateTime.DayOfYear + "/");
                 
                    DirectoryInfo folder = new DirectoryInfo(fileG);
                    if (!Directory.Exists(fileG))
                    {
                        break;
                    }
                    // List<object> s = new List<object>();
                    foreach (FileInfo file in folder.GetFiles("*.result"))
                        {
                            string fullName = file.FullName;
                            // Console.WriteLine(file.FullName);
                            string abc = Path.GetFileNameWithoutExtension(fullName);

                            string sname = abc.Substring(0, abc.Length - 4);
                            Dictionary<string, Dictionary<string, string>> sn = new Dictionary<string, Dictionary<string, string>>();
                            if (d.ContainsKey(sname))
                            {
                                d.TryGetValue(sname, out sn);
                                d.Remove(sname);
                            }

                            string dayName = abc.Substring(sname.Length, 3);
                            string cegrNmae = abc.Substring(abc.Length - 1, 1);

                         
                            // string dddddd  = file.ToString();

                            StreamReader fillds = new StreamReader(fullName);
                            string ddddddddd = fillds.ReadToEnd();
                            string[] arr = ddddddddd.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] temp = new string[] { "First epoch", "Last epoch", "Interval", "Mp1", "Mp2", "O/Slps", "SN1", "SN2", "ObsCount", "DIR" };
                            int[] temp2 = new int[] { 2, 2, 1, 1, 1, 1, 1, 1, 1, 1 };
                            Dictionary<string, string> hashMap = new Dictionary<string, string>();
                            for (int index = 0; index < arr.Length; index++)
                            {
                                for (int tempIndex = 0; tempIndex < temp.Length; tempIndex++)
                                {
                                    if (arr[index].Contains(temp[tempIndex]))
                                    {
                                        string[] arr222 = arr[index].Split(new string[] { temp[tempIndex] }, StringSplitOptions.RemoveEmptyEntries);
                                        string[] arr223 = arr222[0].Split(new char[] { ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                                        string res = "";
                                        int flag = 0;
                                        for (int xa = temp2[index]; xa > 0; xa--)
                                        {

                                            if (flag == 0)
                                            {
                                                res += arr223[arr223.Length - xa];
                                            }
                                            else
                                            {
                                                res += " " + arr223[arr223.Length - xa];
                                            }
                                            flag++;

                                        }
                                        hashMap.Add(temp[index], res);

                                    

                                    }
                                }
                            }
                            sn.Add(cegrNmae, hashMap);
                            d.Add(sname, sn);
                        }
                        r.Add(dateTime, d);

                        //string fileGz = di + "/"+ dateTime.Year + "/" + dateTime.DayOfYear + "/" + "*C.result";
                        //string fileC = di + "/" + dateTime.Year + "/" + dateTime.DayOfYear + "/" + "E.result";
                        //string fileE = di + "/" + dateTime.Year + "/" + dateTime.DayOfYear + "/" + "G.result";
                        //string fileR = di + "/" + dateTime.Year + "/" + dateTime.DayOfYear + "/" + "R.result";
                        //if(!File.Exists(fileG))
                        //{
                        //    continue;
                        //}
                        //StreamReader streamReaderG = new StreamReader(fileG);

                        //data data = new data();
                        //data.Mp1 = 1;
                        //d.Add("G", data);


                        //data dataC = new data();
                        //dataC.Mp1 = 0;
                        //d.Add("C", dataC);

                        ////d.ContainsKey();

                        //r.Add(dateTime, d);
                    }

                    string strJson = string.Empty;

                    strJson = JsonConvert.SerializeObject(new { dt2 = r });
                    var serializer = new JavaScriptSerializer();

                    serializer.MaxJsonLength = Int32.MaxValue;
                    serializer.Serialize(strJson);
                Response.Write(strJson);

                //Model.SysLog syslog = new Model.SysLog();
                //syslog.LogTime = DateTime.Now;
                //syslog.LogType = 5;
                //syslog.Remark = "申请的服务订单待处理";
                //syslog.UserName = orderlist.UserName;
                //DAL.SysLog.Add(syslog);
                Response.End();




            }


        }
        private bool GetStas()
        {
            string search = "";
            int offset = 0;
            int limit = 25;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();


            int totalCount = DAL.CORSStationInfo.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.CORSStationInfo.GetBriefList(offset, limit, search);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("deIsOK", typeof(string));
            ds.Tables[0].Columns.Add("buttonequip", typeof(string));
            ds.Tables[0].Columns.Add("SiteMonitoring", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";

                if (dr["IsOK"].ToString() == "1")
                {
                    dr["deIsOK"] = "正常";
                }
                else
                {
                    dr["deIsOK"] = "<a style = 'color:red;'>异常</a>";
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }

        ///// <summary>
        ///// 显示故障总数
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //[System.Web.Services.WebMethod()]
        //public static string lodaa3(string t)
        //{
        //    HttpResponse resp = System.Web.HttpContext.Current.Response;
        //    HttpRequest req = System.Web.HttpContext.Current.Request;
         



        //    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(url);
        //    FileInfo[] ff = di.GetFiles("*.result");//只取文本文du档
        //    string CC = "";//存放内容
        //    string EE = "";//存放内容
        //    string GG = "";//存放内容
        //    string RR = "";//存放内容
        //    foreach (FileInfo temp in ff)
        //    {



        //        using (StreamReader sr = temp.OpenText())
        //        {
        //            if (temp.ToString().Contains("C."))
        //            {
        //                List<string[]> list = new List<string[]>();

        //                CC += sr.ReadToEnd();//内容追加到zhiss中
        //                string[] arr = CC.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        //                if (arr.Length > 0)
        //                {
        //                    list.Add(arr);
                           
                           
        //                }
        //                for (int i = 0; i < arr.Length; i++)
        //                {
                            
        //                }



        //            }
        //            if (temp.ToString().Contains("E."))
        //            {
        //                // string[] Ename = temp.ToString().Replace("E.result", "");
        //                EE += sr.ReadToEnd();//内容追加到zhiss中
        //                string[] H_data2 = EE.Split(new char[] { '\n', '\r' });//这样就可以把每行放到数组中的一项里

        //            }
        //            if (temp.ToString().Contains("G."))
        //            {
        //                GG += sr.ReadToEnd();//内容追加到zhiss中
        //                string[] H_data2 = GG.Split(new char[] { '\n', '\r' });//这样就可以把每行放到数组中的一项里

        //            }
        //            if (temp.ToString().Contains("R."))
        //            {
        //                RR += sr.ReadToEnd();//内容追加到zhiss中
        //                string[] H_data2 = RR.Split(new char[] { '\n', '\r' });//这样就可以把每行放到数组中的一项里

        //            }




        //        }
        //    }

        //    string strJson = string.Empty;

        //    strJson = JsonConvert.SerializeObject(new { dt2 = CC });
        //    var serializer = new JavaScriptSerializer();

        //    serializer.MaxJsonLength = Int32.MaxValue;
        //    serializer.Serialize(strJson);
        //    return strJson;
        //}

      
        


    }
    class data
    {
       public double Mp1{ set; get; }
        public double Mp2 { get; set; }
        public double Slps  { get; set; }
        public double SN1 { get; set; }
        public double SN2 { get; set; }
        public double DIR { get; set; }
                 
        
        
           
 

    }
}