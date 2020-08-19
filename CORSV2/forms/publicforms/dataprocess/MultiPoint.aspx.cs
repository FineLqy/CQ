using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Annotations.Appearance;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace CORSV2.forms.publicforms.dataprocess
{
    public partial class MultiPoint : System.Web.UI.Page
    {
        private string result = "";
        private string username = "";
        private static string path = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] != null)
            {
                //只允许管理员和rtk用户登录
                if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 3 || Convert.ToInt32(Session["UserType"]) == 1)
                {
                    Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                    Response.End();
                }
                username = Session["UserName"].ToString();
                if (Request["action"] == "Trans")
                {
                    Trans();

                }
                if (Request["action"] != null && Request["action"] == "GetData")
                {
                    if (!GetworkData())
                    {
                        Response.Clear();
                        Response.Write("0");
                        Response.End();
                    }
                }
                if (Request["action"] != null && Request["action"] == "DownloadAll")
                {
                    try
                    {
                        FileInfo fi = new FileInfo(Request["data"].ToString());
                        //Response.Clear();
                        //Response.ClearHeaders();
                        //Response.ClearContent();
                        //Response.Buffer = true;
                        //Response.ContentType = "application/octet-stream";
                        //Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                        //Response.AppendHeader("Content-Length", fi.Length.ToString());
                        //Response.WriteFile(fi.FullName);
                        //Response.Flush();
                        //Response.End();
                        FileInfo fileInfo = new FileInfo(Request["data"].ToString());
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                        Response.AddHeader("Content-Transfer-Encoding", "binary");
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                        Response.WriteFile(fileInfo.FullName);
                        Response.Flush();
                        Response.End();
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;

                    }
                }

                if (Request["action"] != null && Request["action"] == "DownLoad")
                {
                    if (Request["id"] != null)
                    {
                        try
                        {
                            int id = int.Parse(Request["id"].ToString());
                            Model.CoorTransRec cr = DAL.CoorTransRec.GetModel(id);
                            if (cr != null && File.Exists(Server.MapPath("~/TransResult/") + cr.ResultPath))
                            {
                                download(cr.ResultPath);
                            }
                            else
                            {
                                Response.Write("<script>alert(\"文件不存在无法下载！\");</script>");
                            }

                        }
                        catch (Exception)
                        {
                            // Response.Write("<script>alert(\"下载失败，请重试！\");</script>");

                        }

                    }
                    else
                    {
                        Response.Write("<script>alert(\"下载失败，请重试！\");</script>");
                    }

                }
            }

        }
        private bool GetworkData()
        {

            if (Session["UserName"] == null)
                return false;
            username = Session["UserName"].ToString();

            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            int totalCount = DAL.CoorTransRec.GetRecordCount(username, "多点转换");
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.CoorTransRec.GetBriefList(offset, limit, username, "多点转换");

            ds.Tables[0].Columns.Add("deTime", typeof(string));
            ds.Tables[0].Columns.Add("BtnDownload", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["BtnDownload"] = "<a id='" + dr["ID"] + "' onclick= downloads(this.id) >下载</a>";
                dr["deTime"] = dr["Time"].ToString();
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
        public string getnewstr(string str)
        {
            return Regex.Replace(str.Trim(), "\\s+", " ");
        }
        private void Trans()
        {
            //只允许管理员和rtk用户登录
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 3||Convert.ToInt32(Session["UserType"])==1)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            //记录下登录的RTK用户名
            string rtkUserName = Session["UserName"].ToString();
            //判断RTK用户的坐标转换权限
            if (Convert.ToInt32(Session["UserType"]) == 0 && DAL.RTKPostPurview.GetModel(rtkUserName).CoorTransEnable == 0)
            {
                //坐标转换不可用
                Response.Clear();
                Response.Write("-1");
                Response.End();
                return;
            }
            //如果是管理员登录，则获取其注册信息
            if (Convert.ToInt32(Session["UserType"]) == 2 || Convert.ToInt32(Session["UserType"])==3)
            {
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(rtkUserName);
            }
            else
            {
                Model.RTKUserInfo rtkUserInfo = DAL.RTKUserInfo.GetModel(rtkUserName);
            }

            string Projectname = Request.Form["ProjectName"].ToString();
            string filename = Request.Files["DUODFILE"].FileName;
            string[] filenames = filename.Split('.');
            string name = Server.MapPath("~/upload/TransResult/") + rtkUserName + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + "." + filenames[filenames.Length - 1];
            Request.Files["DUODFILE"].SaveAs(name);
            string TargetS = Request.Form["model"].ToString();
            string coortype = "";
            double mlon = -9999;
            double oe = -9999;
            double on = -9999;
            double projele = -9999;

            string cmselect = Request.Form["CMSelect"].ToString().Trim();
            if (cmselect == "默认")
            {
                mlon = 123456;
            }
            else
            {

            }
            try
            {
                coortype = Request.Form["CoorType"].ToString().Trim();
            }
            catch (Exception)
            {


            }
            try
            {
                mlon = double.Parse(Request.Form["OM"].ToString().Trim());
            }
            catch (Exception)
            {


            }
            try
            {
                oe = double.Parse(Request.Form["OY"].ToString().Trim());
            }
            catch (Exception)
            {


            }
            try
            {
                on = double.Parse(Request.Form["OX"].ToString().Trim());
            }
            catch (Exception)
            {


            }
            try
            {
                projele = double.Parse(Request.Form["OZ"].ToString().Trim());
            }
            catch (Exception)
            {


            }
            StreamReader reader = new StreamReader(name);
            bool datastart = false;
            List<List<string>> OrgCoor = new List<List<string>>();
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                #region 信息获取
                if (line.Contains("#START"))
                {
                    datastart = true;
                    continue;
                }
                if (line.Contains("#END"))
                {
                    datastart = false;
                    continue;
                }
                try
                {
                    //if (line.Contains("TYPE:"))
                    //{
                    //    string[] nls = getnewstr(line).Split(' ');
                    //    coortype = nls[1].Trim();
                    //    continue;

                    //}
                    //if (line.Contains("CM:"))
                    //{
                    //    string[] cm = getnewstr(line).Split(' ');
                    //    mlon = double.Parse(cm[1].Trim());
                    //    continue;
                    //}
                    //if (line.Contains("OEAST:"))
                    //{
                    //    string[] oes = getnewstr(line).Split(' ');
                    //    oe = double.Parse(oes[1].Trim());
                    //    continue;
                    //}
                    //if (line.Contains("ONORTH"))
                    //{
                    //    string[] ons = getnewstr(line).Split(' ');
                    //    on = double.Parse(ons[1].Trim());
                    //    continue;
                    //}
                    //if (line.Contains("PROJELE"))
                    //{
                    //    string[] projeles = getnewstr(line).Split(' ');
                    //    projele = double.Parse(projeles[1].Trim());
                    //    continue;
                    //}
                    if (datastart)
                    {
                        List<string> orgcoor = new List<string>();
                        string[] coors = getnewstr(line).Split(',');// 点名 X Y Z 
                        if (coors.Length == 4)
                        {
                            orgcoor.Add(coors[1].Trim());
                            orgcoor.Add(coors[2].Trim());
                            orgcoor.Add(coors[3].Trim());
                            orgcoor.Add(coors[0].Trim());
                            OrgCoor.Add(orgcoor);
                        }
                        else
                        {
                            Response.Clear();
                            Response.Write("0");
                            Response.End();
                            return;
                        }
                        continue;
                    }

                }
                catch (Exception)
                {
                    //文件格式错误
                    Response.Clear();
                    Response.Write("0");
                    Response.End();
                    return;
                }
                #endregion

            }
            reader.Close();



            double pay = 300;//所需费用

            if (OrgCoor.Count > 10)
            {
                pay += (OrgCoor.Count - 10) * 30;
            }

            //int enablecount = 0;
            //try
            //{
            //    enablecount = DAL.CompanyPurview.GetModel(Company).PostCoorTransCount;
            //}
            //catch (Exception)
            //{


            //}
            //if (enablecount < OrgCoor.Count)
            //{
            //    //可转个数不足
            //    Response.Clear();
            //    Response.Write("1");
            //    Response.End();
            //    return;
            //}

            if ((coortype != "BLH" && coortype != "XYZ" && coortype != "xyh") || mlon == -9999 || oe == -9999 || on == -9999 || projele == -9999 || OrgCoor.Count <= 0)
            {
                //初始数据错误请检查
                Response.Clear();
                Response.Write("2");
                Response.End();
                return;
            }
            else
            {
                //File.Delete(name);


                #region 文件格式判断
                if (coortype == "xyh")
                {
                    bool isok = true;
                    try
                    {

                        foreach (var a in OrgCoor)
                        {
                            if (double.Parse(a[0]) < 1000000)
                            {
                                isok = false;
                            }
                            if (double.Parse(a[1]) < 10000000)
                            {
                                isok = false;
                            }
                            if (double.Parse(a[2]) < 0)
                            {
                                isok = false;
                            }
                        }

                    }
                    catch (Exception)
                    {

                        isok = false;
                    }
                    if (!isok)
                    {
                        Response.Clear();
                        Response.Write("2");
                        Response.End();
                        return;
                    }
                }
                if (coortype == "BLH")
                {
                    bool isok = true;
                    try
                    {

                        foreach (var a in OrgCoor)
                        {
                            if (double.Parse(a[0]) > 90 || double.Parse(a[0]) < 0)
                            {
                                isok = false;
                            }
                            if (double.Parse(a[1]) < -180 || double.Parse(a[1]) > 180)
                            {
                                isok = false;
                            }

                        }

                    }
                    catch (Exception)
                    {

                        isok = false;
                    }
                    if (!isok)
                    {
                        Response.Clear();
                        Response.Write("2");
                        Response.End();
                        return;
                    }
                }
                if (coortype == "XYZ")
                {
                    //bool isok = true;
                    //try
                    //{

                    //    foreach (var a in OrgCoor)
                    //    {
                    //        if (double.Parse(a[0]) < 100000)
                    //        {
                    //            isok = false;
                    //        }
                    //        if (double.Parse(a[1]) < 100000)
                    //        {
                    //            isok = false;
                    //        }

                    //    }

                    //}
                    //catch (Exception)
                    //{

                    //    isok = false;
                    //}
                    //if (!isok)
                    //{
                    //    Response.Clear();
                    //    Response.Write("2");
                    //    Response.End();
                    //    return;
                    //}
                }
                #endregion




                switch (TargetS)
                {

                    #region CGCS2000_TO_XIAN1980
                    case "CGCS2000_TO_XIAN1980":
                        {
                            string GeoidFilename = Server.MapPath("~/cs/") + "geoid.mskE";
                            cs.Geoid geoid = new cs.Geoid();
                            geoid.ReadGrid(GeoidFilename);
                            Model.OFormerCoorSysPars CoorSysPars2000_80 = new Model.OFormerCoorSysPars();
                            CoorSysPars2000_80.X = 65.720427767314;
                            CoorSysPars2000_80.Y = 135.030946810581;
                            CoorSysPars2000_80.Z = -79.761165553685;
                            CoorSysPars2000_80.aa = -3.6765745;
                            CoorSysPars2000_80.bb = -0.8652169;
                            CoorSysPars2000_80.cc = 0.6213358;
                            CoorSysPars2000_80.m = -3.238888;

                            CoorSysPars2000_80.CMeridian = mlon;
                            CoorSysPars2000_80.MDDAlpha = 1.0 / 298.257;
                            CoorSysPars2000_80.MDe2 = 0.006694384999588;
                            CoorSysPars2000_80.MDMajorAxis = 6378140.0;
                            CoorSysPars2000_80.YSDAlpha = 1.0 / 298.257222101;
                            CoorSysPars2000_80.YSe2 = 0.00669438002290;
                            CoorSysPars2000_80.YSMajorAxis = 6378137.0;
                            CoorSysPars2000_80.OriginEast = oe;
                            CoorSysPars2000_80.OriginNorth = on;
                            CoorSysPars2000_80.ProjElevation = projele;
                            string resultfile = Server.MapPath("~/TransResult/") + rtkUserName + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".result";
                            File.Create(resultfile).Close();
                            StreamWriter sw = new StreamWriter(resultfile);
                            sw.WriteLine("#单位：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#操作人：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#项目名称：".PadRight(10, ' ') + Projectname);
                            sw.WriteLine("#转点时间：".PadRight(10, ' ') + DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日");
                            sw.WriteLine("#转换类型：".PadRight(10, ' ') + coortype + "->xyh");
                            sw.WriteLine("#转换坐标系：".PadRight(10, ' ') + TargetS);
                            sw.WriteLine("#转点个数：".PadRight(10, ' ') + OrgCoor.Count);
                            sw.WriteLine("#起始北坐标：".PadRight(10, ' ') + on);
                            sw.WriteLine("#起始东坐标：".PadRight(10, ' ') + oe);
                            sw.WriteLine("#投影抬高：".PadRight(10, ' ') + projele);
                            // sw.WriteLine("#中央子午线经度：".PadRight(10, ' ') + mlon);

                            sw.WriteLine("#原始数据".PadRight(10, ' '));
                            sw.WriteLine("--".PadRight(95, '-'));
                            if (coortype == "BLH")
                            {
                                sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(13) + "经度".PadRight(13) + "大地高".PadRight(12));

                            }
                            if (coortype == "XYZ")
                            {
                                sw.WriteLine("点名".PadRight(8) + "X".PadRight(13) + "Y".PadRight(13) + "Z".PadRight(12));
                            }
                            if (coortype == "xyh")
                            {
                                sw.WriteLine("点名".PadRight(8) + "北坐标".PadRight(13) + "东坐标".PadRight(13) + "大地高".PadRight(12));
                            }
                            foreach (var d in OrgCoor)
                            {
                                sw.WriteLine(d[3].ToString().PadRight(10) + d[0].PadRight(15) + d[1].PadRight(15) + d[2].PadRight(15));

                            }
                            sw.WriteLine("   ");
                            sw.WriteLine("#成果数据".PadRight(10, ' '));

                            sw.WriteLine("--".PadRight(95, '-'));
                            sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(13) + "经度".PadRight(13) + "北坐标".PadRight(12) + "东坐标".PadRight(12) + "正常高".PadRight(12) + "中央子午线".PadRight(10));

                            if (coortype == "BLH")
                            {
                                for (int i = 0; i < OrgCoor.Count; i++)
                                {

                                    cs.GEODETIC BLH = new cs.GEODETIC();
                                    cs.PLANECOOR xyh = new cs.PLANECOOR();
                                    BLH.latdms = double.Parse(OrgCoor[i][0]);
                                    BLH.londms = double.Parse(OrgCoor[i][1]);
                                    BLH.height = double.Parse(OrgCoor[i][2]);
                                    if (mlon == 123456)
                                    {
                                        CoorSysPars2000_80.CMeridian = getcm(BLH.londms);
                                    }



                                    double e2 = CoorSysPars2000_80.MDDAlpha * (2 - CoorSysPars2000_80.MDDAlpha);
                                    cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                    cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                    cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                    cs.PostCoorTrans.Geo2Car(CoorSysPars2000_80.YSMajorAxis, CoorSysPars2000_80.YSDAlpha, BLH, ref XYZ);
                                    cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars2000_80, ref XYZ_temp);
                                    cs.PostCoorTrans.Car2Geo(CoorSysPars2000_80.MDMajorAxis, CoorSysPars2000_80.MDDAlpha, XYZ_temp, ref BLH_temp);
                                    cs.PostCoorTrans.BL2xy(CoorSysPars2000_80.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_80.CMeridian), CoorSysPars2000_80.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                    xyh.h = BLH_temp.height;


                                    // PostCoorTrans.BLHtoxyh(BLH, CoorSysPars2000_80, ref xyh);
                                    xyh.x = xyh.x + CoorSysPars2000_80.OriginNorth; xyh.y = xyh.y + CoorSysPars2000_80.OriginEast;
                                    double H = 0;

                                    double dh = CoorSysPars2000_80.CMeridian / 3;// getcm(BLH.londms) / 3;
                                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                    {
                                        xyh.h = BLH.height - H;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(15) + BLH_temp.londms.ToString("F8").PadRight(15) + xyh.x.ToString("F4").PadRight(15) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(13) + xyh.h.ToString("F4").PadRight(15) + CoorSysPars2000_80.CMeridian.ToString("F4").PadRight(15));

                                    }
                                    else
                                    {
                                        xyh.h = BLH.height;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(15) + BLH_temp.londms.ToString("F8").PadRight(15) + xyh.x.ToString("F4").PadRight(15) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(13) + (xyh.h.ToString("F4") + "-大地高").PadRight(15) + CoorSysPars2000_80.CMeridian.ToString("F4").PadRight(15));

                                    }
                                }
                            }
                            else
                            {
                                if (coortype == "XYZ")
                                {
                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        XYZ.X = double.Parse(OrgCoor[i][0]);
                                        XYZ.Y = double.Parse(OrgCoor[i][1]);
                                        XYZ.Z = double.Parse(OrgCoor[i][2]);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars2000_80.YSMajorAxis, CoorSysPars2000_80.YSDAlpha, XYZ, ref BLH); double H = 0;
                                        if (mlon == 123456)
                                        {
                                            CoorSysPars2000_80.CMeridian = getcm(BLH.londms);
                                        }
                                        double e2 = CoorSysPars2000_80.MDDAlpha * (2 - CoorSysPars2000_80.MDDAlpha);
                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();


                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars2000_80, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars2000_80.MDMajorAxis, CoorSysPars2000_80.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars2000_80.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_80.CMeridian), CoorSysPars2000_80.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                        xyh.h = BLH_temp.height;

                                        //PostCoorTrans.XYZtoxyh(XYZ, CoorSysPars2000_80, ref xyh);
                                        xyh.x = xyh.x + CoorSysPars2000_80.OriginNorth; xyh.y = xyh.y + CoorSysPars2000_80.OriginEast;
                                        double dh = CoorSysPars2000_80.CMeridian / 3;// getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh.h = BLH.height - H;

                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + xyh.h.ToString("F4").PadRight(20) + CoorSysPars2000_80.CMeridian.ToString("F4").PadRight(20));
                                        }
                                        else
                                        {
                                            xyh.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + (xyh.h.ToString("F4") + "-大地高").PadRight(20) + CoorSysPars2000_80.CMeridian.ToString("F4").PadRight(20));
                                        }
                                    }
                                }
                                else
                                {

                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        //xyh

                                        //前面有带号，提取出来算中央子午线
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        xyh.x = double.Parse(OrgCoor[i][0]);
                                        xyh.y = double.Parse(OrgCoor[i][1].Substring(2, OrgCoor[i][1].Length - 2)) - 500000;
                                        xyh.h = double.Parse(OrgCoor[i][2]);
                                        if (mlon == 123456)
                                        {
                                            CoorSysPars2000_80.CMeridian = double.Parse(OrgCoor[i][1].Substring(0, 2)) * 3;
                                        }
                                        double e2 = CoorSysPars2000_80.YSDAlpha * (2 - CoorSysPars2000_80.YSDAlpha);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        double b = 0;
                                        double l = 0;

                                        cs.PostCoorTrans.xy2BL(CoorSysPars2000_80.YSMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_80.CMeridian), xyh.x, xyh.y, ref b, ref l);

                                        BLH.lat = b * 180 / Math.PI;
                                        BLH.lon = l * 180 / Math.PI;
                                        BLH.height = xyh.h;



                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                        cs.PLANECOOR xyh_temp = new cs.PLANECOOR();
                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PostCoorTrans.Geo2Car(CoorSysPars2000_80.YSMajorAxis, CoorSysPars2000_80.YSDAlpha, BLH, ref XYZ);
                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars2000_80, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars2000_80.MDMajorAxis, CoorSysPars2000_80.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        e2 = CoorSysPars2000_80.MDDAlpha * (2 - CoorSysPars2000_80.MDDAlpha);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars2000_80.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_80.CMeridian), CoorSysPars2000_80.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh_temp.x, ref xyh_temp.y);
                                        xyh_temp.h = BLH_temp.height;


                                        // PostCoorTrans.BLHtoxyh(BLH, CoorSysPars2000_80, ref xyh);
                                        xyh_temp.x = xyh_temp.x + CoorSysPars2000_80.OriginNorth; xyh_temp.y = xyh_temp.y + CoorSysPars2000_80.OriginEast;

                                        double H = 0;
                                        double dh = CoorSysPars2000_80.CMeridian / 3;// getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh_temp.h = BLH.height - H;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(18) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(20) + xyh_temp.h.ToString("F4").PadRight(20) + CoorSysPars2000_80.CMeridian.ToString("F4").PadRight(20));

                                        }
                                        else
                                        {
                                            xyh_temp.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + (xyh_temp.h.ToString("F4") + "-大地高").PadRight(20) + CoorSysPars2000_80.CMeridian.ToString("F4").PadRight(20));

                                        }
                                    }

                                }
                            }
                            sw.Close();
                            //转换完成
                            Model.CoorTransRec coorTransRec = new Model.CoorTransRec();
                            try
                            {
                                coorTransRec.ProjectName = Request.Form["ProjectName"].ToString();
                            }
                            catch (Exception)
                            {


                            }
                            coorTransRec.Time = DateTime.Now;
                            coorTransRec.Remark = "多点转换";
                            coorTransRec.Type = TargetS;
                            coorTransRec.UserName = username;


                            path = resultfile;


                            #region pdf测试
                            //cs.Pdf.TXT2PDF(path, Server.MapPath("~/upload/Fonts/") + "simkai.ttf");
                            //path = path.ToString().Substring(0, path.ToString().Length - 7) + ".pdf";
                            //cs.Pdf.WaterMarkPDF(path, Server.MapPath("~/themes/images/") + "APP.png", path.ToString().Substring(0, path.ToString().Length - 4) + "result.pdf");
                            //path = path.ToString().Substring(0, path.ToString().Length - 4) + "result.pdf";
                            //cs.Pdf.MergePdfFilesWithBookMark(new string[1] { path }, path.ToString().Substring(0, path.ToString().Length - 4) + "s.pdf");
                            //path = path.ToString().Substring(0, path.ToString().Length - 4) + "s.pdf";

                            #endregion

                            if (Request.Form["Encryption"].ToString().Trim() == "不压缩")
                            {
                            }
                            else
                            {
                                if (Request.Form["Encryption"].ToString().Trim() == "采用用户名进行加密压缩")
                                {
                                    cs.clsWinRar.CompressRar(path, "", rtkUserName);
                                }
                                path += ".rar";
                            }

                            coorTransRec.ResultPath = Path.GetFileName(path);
                            DAL.CoorTransRec.Add(coorTransRec);

                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;


                            Response.Clear();
                            Response.Write(resultfile);
                            Response.End();
                            break;
                        }
                    #endregion
                    #region CGCS2000_TO_BEIJING1954
                    case "CGCS2000_TO_BEIJING1954":
                        {
                            string GeoidFilename = Server.MapPath("~/cs/") + "geoid.mskE";
                            cs.Geoid geoid = new cs.Geoid();
                            geoid.ReadGrid(GeoidFilename);
                            Model.OFormerCoorSysPars CoorSysPars2000_54 = new Model.OFormerCoorSysPars();
                            CoorSysPars2000_54.X = -22.765721456953;
                            CoorSysPars2000_54.Y = 183.517678879571;
                            CoorSysPars2000_54.Z = 79.698328216242;
                            CoorSysPars2000_54.aa = -0.596558;
                            CoorSysPars2000_54.bb = -0.0671555;
                            CoorSysPars2000_54.cc = 0.2432772;
                            CoorSysPars2000_54.m = -3.743629;

                            CoorSysPars2000_54.CMeridian = mlon;
                            CoorSysPars2000_54.MDDAlpha = 1.0 / 298.3;
                            CoorSysPars2000_54.MDe2 = 0.006693421622966;
                            CoorSysPars2000_54.MDMajorAxis = 6378245.0;
                            CoorSysPars2000_54.YSDAlpha = 1.0 / 298.257222101;
                            CoorSysPars2000_54.YSe2 = 0.00669438002290;
                            CoorSysPars2000_54.YSMajorAxis = 6378137.0;
                            CoorSysPars2000_54.OriginEast = oe;
                            CoorSysPars2000_54.OriginNorth = on;
                            CoorSysPars2000_54.ProjElevation = projele;
                            string resultfile = Server.MapPath("~/upload/TransResult/") + rtkUserName + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".result";
                            File.Create(resultfile).Close();
                            StreamWriter sw = new StreamWriter(resultfile);
                            sw.WriteLine("#单位：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#操作人：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#项目名称：".PadRight(10, ' ') + Projectname);
                            sw.WriteLine("#转点时间：".PadRight(10, ' ') + DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日");
                            sw.WriteLine("#转换类型：".PadRight(10, ' ') + coortype + "->xyh");
                            sw.WriteLine("#转换坐标系：".PadRight(10, ' ') + TargetS);
                            sw.WriteLine("#转点个数：".PadRight(10, ' ') + OrgCoor.Count);
                            sw.WriteLine("#起始北坐标：".PadRight(10, ' ') + on);
                            sw.WriteLine("#起始东坐标：".PadRight(10, ' ') + oe);
                            sw.WriteLine("#投影抬高：".PadRight(10, ' ') + projele);
                            //sw.WriteLine("#中央子午线经度：".PadRight(10, ' ') + mlon);

                            sw.WriteLine("#原始数据".PadRight(10, ' '));
                            sw.WriteLine("--".PadRight(120, '-'));
                            if (coortype == "BLH")
                            {
                                sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(18) + "经度".PadRight(18) + "大地高".PadRight(17));

                            }
                            if (coortype == "XYZ")
                            {
                                sw.WriteLine("点名".PadRight(8) + "X".PadRight(18) + "Y".PadRight(18) + "Z".PadRight(17));
                            }
                            if (coortype == "xyh")
                            {
                                sw.WriteLine("点名".PadRight(8) + "北坐标".PadRight(18) + "东坐标".PadRight(18) + "大地高".PadRight(17));
                            }
                            foreach (var d in OrgCoor)
                            {
                                sw.WriteLine(d[3].ToString().PadRight(10) + d[0].PadRight(20) + d[1].PadRight(20) + d[2].PadRight(20));

                            }
                            sw.WriteLine("   ");
                            sw.WriteLine("#成果数据".PadRight(10, ' '));

                            sw.WriteLine("--".PadRight(120, '-'));
                            sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(18) + "经度".PadRight(18) + "北坐标".PadRight(17) + "东坐标".PadRight(17) + "正常高".PadRight(17) + "中央子午线".PadRight(15));

                            if (coortype == "BLH")
                            {
                                for (int i = 0; i < OrgCoor.Count; i++)
                                {
                                   cs.GEODETIC BLH = new cs.GEODETIC();
                                   cs.PLANECOOR xyh = new cs.PLANECOOR();
                                    BLH.latdms = double.Parse(OrgCoor[i][0]);
                                    BLH.londms = double.Parse(OrgCoor[i][1]);
                                    BLH.height = double.Parse(OrgCoor[i][2]);


                                    if (mlon == 123456)
                                    {
                                        CoorSysPars2000_54.CMeridian = getcm(BLH.londms);
                                    }

                                    double e2 = CoorSysPars2000_54.MDDAlpha * (2 - CoorSysPars2000_54.MDDAlpha);
                                    cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                    cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                    cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                    cs.PostCoorTrans.Geo2Car(CoorSysPars2000_54.YSMajorAxis, CoorSysPars2000_54.YSDAlpha, BLH, ref XYZ);
                                    cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars2000_54, ref XYZ_temp);
                                    cs.PostCoorTrans.Car2Geo(CoorSysPars2000_54.MDMajorAxis, CoorSysPars2000_54.MDDAlpha, XYZ_temp, ref BLH_temp);
                                    cs.PostCoorTrans.BL2xy(CoorSysPars2000_54.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_54.CMeridian), CoorSysPars2000_54.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                    xyh.h = BLH_temp.height;


                                    //PostCoorTrans.BLHtoxyh(BLH, CoorSysPars2000_54, ref xyh);
                                    xyh.x = xyh.x + CoorSysPars2000_54.OriginNorth; xyh.y = xyh.y + CoorSysPars2000_54.OriginEast;
                                    double H = 0;
                                    double dh = CoorSysPars2000_54.CMeridian / 3;// getcm(BLH.londms) / 3;
                                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                    {
                                        xyh.h = BLH.height - H;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + xyh.h.ToString("F4").PadRight(20) + CoorSysPars2000_54.CMeridian.ToString("F4").PadRight(20));

                                    }
                                    else
                                    {
                                        xyh.h = BLH.height;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + (xyh.h.ToString("F4") + "-大地高").PadRight(20) + CoorSysPars2000_54.CMeridian.ToString("F4").PadRight(20));

                                    }
                                }
                            }
                            else
                            {
                                if (coortype == "XYZ")
                                {
                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        XYZ.X = double.Parse(OrgCoor[i][0]);
                                        XYZ.Y = double.Parse(OrgCoor[i][1]);
                                        XYZ.Z = double.Parse(OrgCoor[i][2]);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars2000_54.YSMajorAxis, CoorSysPars2000_54.YSDAlpha, XYZ, ref BLH); double H = 0;


                                        if (mlon == 123456)
                                        {
                                            CoorSysPars2000_54.CMeridian = getcm(BLH.londms);
                                        }
                                        double e2 = CoorSysPars2000_54.MDDAlpha * (2 - CoorSysPars2000_54.MDDAlpha);
                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();

                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars2000_54, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars2000_54.MDMajorAxis, CoorSysPars2000_54.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars2000_54.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_54.CMeridian), CoorSysPars2000_54.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                        xyh.h = BLH_temp.height;

                                        //PostCoorTrans.XYZtoxyh(XYZ, CoorSysPars2000_54, ref xyh);
                                        xyh.x = xyh.x + CoorSysPars2000_54.OriginNorth; xyh.y = xyh.y + CoorSysPars2000_54.OriginEast;
                                        double dh = CoorSysPars2000_54.CMeridian / 3;// getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh.h = BLH.height - H;

                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + xyh.h.ToString("F4").PadRight(20) + CoorSysPars2000_54.CMeridian.ToString("F4").PadRight(20));
                                        }
                                        else
                                        {
                                            xyh.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + (xyh.h.ToString("F4") + "-大地高").PadRight(20) + CoorSysPars2000_54.CMeridian.ToString("F4").PadRight(20));
                                        }
                                    }
                                }
                                else
                                {
                                    //xyh
                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        //xyh

                                        //前面有带号，提取出来算中央子午线
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        xyh.x = double.Parse(OrgCoor[i][0]);
                                        xyh.y = double.Parse(OrgCoor[i][1].Substring(2, OrgCoor[i][1].Length - 2)) - 500000;
                                        xyh.h = double.Parse(OrgCoor[i][2]);
                                        if (mlon == 123456)
                                        {
                                            CoorSysPars2000_54.CMeridian = double.Parse(OrgCoor[i][1].Substring(0, 2)) * 3;
                                        }
                                        double e2 = CoorSysPars2000_54.YSDAlpha * (2 - CoorSysPars2000_54.YSDAlpha);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        double b = 0;
                                        double l = 0;

                                       cs.PostCoorTrans.xy2BL(CoorSysPars2000_54.YSMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_54.CMeridian), xyh.x, xyh.y, ref b, ref l);

                                        BLH.lat = b * 180 / Math.PI;
                                        BLH.lon = l * 180 / Math.PI;
                                        BLH.height = xyh.h;



                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                        cs.PLANECOOR xyh_temp = new cs.PLANECOOR();
                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PostCoorTrans.Geo2Car(CoorSysPars2000_54.YSMajorAxis, CoorSysPars2000_54.YSDAlpha, BLH, ref XYZ);
                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars2000_54, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars2000_54.MDMajorAxis, CoorSysPars2000_54.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        e2 = CoorSysPars2000_54.MDDAlpha * (2 - CoorSysPars2000_54.MDDAlpha);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars2000_54.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars2000_54.CMeridian), CoorSysPars2000_54.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh_temp.x, ref xyh_temp.y);
                                        xyh_temp.h = BLH_temp.height;


                                        // PostCoorTrans.BLHtoxyh(BLH, CoorSysPars2000_54, ref xyh);
                                        xyh_temp.x = xyh_temp.x + CoorSysPars2000_54.OriginNorth; xyh_temp.y = xyh_temp.y + CoorSysPars2000_54.OriginEast;

                                        double H = 0;
                                        double dh = CoorSysPars2000_54.CMeridian / 3;// getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh_temp.h = BLH.height - H;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + xyh_temp.h.ToString("F4").PadRight(20) + CoorSysPars2000_54.CMeridian.ToString("F4").PadRight(20));

                                        }
                                        else
                                        {
                                            xyh_temp.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + (xyh_temp.h.ToString("F4") + "-大地高").PadRight(20) + CoorSysPars2000_54.CMeridian.ToString("F4").PadRight(20));

                                        }
                                    }


                                }

                            }
                            sw.Close();
                            //转换完成
                            Model.CoorTransRec coorTransRec = new Model.CoorTransRec();
                            try
                            {
                                coorTransRec.ProjectName = Request.Form["ProjectName"].ToString();
                            }
                            catch (Exception)
                            {


                            }
                            coorTransRec.Time = DateTime.Now;
                            coorTransRec.Remark = "多点转换";
                            coorTransRec.Type = TargetS;
                            coorTransRec.UserName = username;

                            coorTransRec.Amount = OrgCoor.Count;
                            coorTransRec.Cost = pay;
                            coorTransRec.Result = "转换成功";


                            path = resultfile;
                            if (Request.Form["Encryption"].ToString().Trim() == "不压缩")
                            {
                            }
                            else
                            {
                                if (Request.Form["Encryption"].ToString().Trim() == "采用用户名进行加密压缩")
                                {
                                    cs.clsWinRar.CompressRar(path, "", rtkUserName);
                                }
                                //else
                                //{
                                //    cs.clsWinRar.CompressRar(path, "", AES_Key.AESDecrypt(duinfo.GetModelu(UserName).PassWord, UserName.PadLeft(16, '0')));
                                //}
                                path += ".rar";
                            }
                            coorTransRec.ResultPath = Path.GetFileName(path);
                            DAL.CoorTransRec.Add(coorTransRec);
                            //Model.CompanyPurview mcp = DAL.CompanyPurview.GetModel(Company);
                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;
                            //DAL.CompanyPurview.Update(mcp);
                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;
                            Response.Clear();
                            Response.Write(resultfile);
                            Response.End();
                            break;
                        }
                    #endregion
                    #region BEIJING1954_TO_CGCS2000
                    case "BEIJING1954_TO_CGCS2000":
                        {
                            string GeoidFilename = Server.MapPath("~/cs/") + "geoid.mskE";
                            cs.Geoid geoid = new cs.Geoid();
                            geoid.ReadGrid(GeoidFilename);
                            Model.OFormerCoorSysPars CoorSysPars54_2000 = new Model.OFormerCoorSysPars();
                            CoorSysPars54_2000.X = 22.7666;
                            CoorSysPars54_2000.Y = -183.520;
                            CoorSysPars54_2000.Z = -79.6965;
                            CoorSysPars54_2000.aa = 0.5966353121;
                            CoorSysPars54_2000.bb = 0.0671732945;
                            CoorSysPars54_2000.cc = -0.2432889367;
                            CoorSysPars54_2000.m = 3.7436635742;
                            CoorSysPars54_2000.CMeridian = mlon;
                            CoorSysPars54_2000.MDDAlpha = 1.0 / 298.257223563;
                            CoorSysPars54_2000.MDe2 = 0.00669438000426083;
                            CoorSysPars54_2000.MDMajorAxis = 6378137.0;
                            CoorSysPars54_2000.YSDAlpha = 1.0 / 298.3;
                            CoorSysPars54_2000.YSe2 = 0.00669342161454287;
                            CoorSysPars54_2000.YSMajorAxis = 6378245.0;
                            CoorSysPars54_2000.OriginEast = oe;
                            CoorSysPars54_2000.OriginNorth = on;
                            CoorSysPars54_2000.ProjElevation = projele;
                            string resultfile = Server.MapPath("~/upload/TransResult/") + rtkUserName + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".result";
                            File.Create(resultfile).Close();
                            StreamWriter sw = new StreamWriter(resultfile);
                            sw.WriteLine("#单位：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#操作人：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#项目名称：".PadRight(10, ' ') + Projectname);
                            sw.WriteLine("#转点时间：".PadRight(10, ' ') + DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日");
                            sw.WriteLine("#转换类型：".PadRight(10, ' ') + coortype + "->xyh");
                            sw.WriteLine("#转换坐标系：".PadRight(10, ' ') + TargetS);
                            sw.WriteLine("#转点个数：".PadRight(10, ' ') + OrgCoor.Count);
                            sw.WriteLine("#起始北坐标：".PadRight(10, ' ') + on);
                            sw.WriteLine("#起始东坐标：".PadRight(10, ' ') + oe);
                            sw.WriteLine("#投影抬高：".PadRight(10, ' ') + projele);
                            //sw.WriteLine("#中央子午线经度：".PadRight(10, ' ') + mlon);

                            sw.WriteLine("#原始数据".PadRight(10, ' '));
                            sw.WriteLine("--".PadRight(120, '-'));
                            if (coortype == "BLH")
                            {
                                sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(18) + "经度".PadRight(18) + "大地高".PadRight(17));

                            }
                            if (coortype == "XYZ")
                            {
                                sw.WriteLine("点名".PadRight(8) + "X".PadRight(18) + "Y".PadRight(18) + "Z".PadRight(17));
                            }
                            if (coortype == "xyh")
                            {
                                sw.WriteLine("点名".PadRight(8) + "北坐标".PadRight(18) + "东坐标".PadRight(18) + "大地高".PadRight(17));
                            }
                            foreach (var d in OrgCoor)
                            {
                                sw.WriteLine(d[3].ToString().PadRight(10) + d[0].PadRight(20) + d[1].PadRight(20) + d[2].PadRight(20));

                            }
                            sw.WriteLine("   ");
                            sw.WriteLine("#成果数据".PadRight(10, ' '));

                            sw.WriteLine("--".PadRight(100, '-'));
                            sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(18) + "经度".PadRight(18) + "北坐标".PadRight(17) + "东坐标".PadRight(17) + "中央子午线".PadRight(15));


                            if (coortype == "BLH")
                            {
                                for (int i = 0; i < OrgCoor.Count; i++)
                                {
                                    cs.GEODETIC BLH = new cs.GEODETIC();
                                    cs.PLANECOOR xyh = new cs.PLANECOOR();
                                    BLH.latdms = double.Parse(OrgCoor[i][0]);
                                    BLH.londms = double.Parse(OrgCoor[i][1]);
                                    BLH.height = double.Parse(OrgCoor[i][2]);

                                    if (mlon == 123456)
                                    {
                                        CoorSysPars54_2000.CMeridian = getcm(BLH.londms);
                                    }


                                    double e2 = CoorSysPars54_2000.MDDAlpha * (2 - CoorSysPars54_2000.MDDAlpha);
                                    cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                    cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                    cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                    cs.PostCoorTrans.Geo2Car(CoorSysPars54_2000.YSMajorAxis, CoorSysPars54_2000.YSDAlpha, BLH, ref XYZ);
                                    cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars54_2000, ref XYZ_temp);
                                    cs.PostCoorTrans.Car2Geo(CoorSysPars54_2000.MDMajorAxis, CoorSysPars54_2000.MDDAlpha, XYZ_temp, ref BLH_temp);
                                    cs.PostCoorTrans.BL2xy(CoorSysPars54_2000.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars54_2000.CMeridian), CoorSysPars54_2000.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                    xyh.h = BLH_temp.height;

                                    //PostCoorTrans.BLHtoxyh(BLH, CoorSysPars54_2000, ref xyh);
                                    xyh.x = xyh.x + CoorSysPars54_2000.OriginNorth; xyh.y = xyh.y + CoorSysPars54_2000.OriginEast;
                                    double H = 0;
                                    double dh = CoorSysPars54_2000.CMeridian / 3;// getcm(BLH.londms) / 3;
                                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                    {
                                        xyh.h = BLH.height - H;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars54_2000.CMeridian.ToString("F4").PadRight(20));

                                    }
                                    else
                                    {
                                        xyh.h = BLH.height;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars54_2000.CMeridian.ToString("F4").PadRight(20));

                                    }
                                }
                            }
                            else
                            {
                                if (coortype == "XYZ")
                                {
                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        XYZ.X = double.Parse(OrgCoor[i][0]);
                                        XYZ.Y = double.Parse(OrgCoor[i][1]);
                                        XYZ.Z = double.Parse(OrgCoor[i][2]);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars54_2000.YSMajorAxis, CoorSysPars54_2000.YSDAlpha, XYZ, ref BLH); double H = 0;


                                        if (mlon == 123456)
                                        {
                                            CoorSysPars54_2000.CMeridian = getcm(BLH.londms);
                                        }
                                        double e2 = CoorSysPars54_2000.MDDAlpha * (2 - CoorSysPars54_2000.MDDAlpha);
                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();


                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars54_2000, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars54_2000.MDMajorAxis, CoorSysPars54_2000.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars54_2000.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars54_2000.CMeridian), CoorSysPars54_2000.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                        xyh.h = BLH_temp.height;

                                        //PostCoorTrans.XYZtoxyh(XYZ, CoorSysPars2000_80, ref xyh);
                                        xyh.x = xyh.x + CoorSysPars54_2000.OriginNorth; xyh.y = xyh.y + CoorSysPars54_2000.OriginEast;
                                        double dh = CoorSysPars54_2000.CMeridian / 3;//  getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh.h = BLH.height - H;

                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars54_2000.CMeridian.ToString("F4").PadRight(20));
                                        }
                                        else
                                        {
                                            xyh.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars54_2000.CMeridian.ToString("F4").PadRight(20));
                                        }

                                    }
                                }
                                else
                                {
                                    //xyh


                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        //xyh

                                        //前面有带号，提取出来算中央子午线
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        xyh.x = double.Parse(OrgCoor[i][0]);
                                        xyh.y = double.Parse(OrgCoor[i][1].Substring(2, OrgCoor[i][1].Length - 2)) - 500000;
                                        xyh.h = double.Parse(OrgCoor[i][2]);
                                        if (mlon == 123456)
                                        {
                                            CoorSysPars54_2000.CMeridian = double.Parse(OrgCoor[i][1].Substring(0, 2)) * 3;
                                        }
                                        double e2 = CoorSysPars54_2000.YSDAlpha * (2 - CoorSysPars54_2000.YSDAlpha);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        double b = 0;
                                        double l = 0;

                                        cs.PostCoorTrans.xy2BL(CoorSysPars54_2000.YSMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars54_2000.CMeridian), xyh.x, xyh.y, ref b, ref l);

                                        BLH.lat = b * 180 / Math.PI;
                                        BLH.lon = l * 180 / Math.PI;
                                        BLH.height = xyh.h;



                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                        cs.PLANECOOR xyh_temp = new cs.PLANECOOR();
                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PostCoorTrans.Geo2Car(CoorSysPars54_2000.YSMajorAxis, CoorSysPars54_2000.YSDAlpha, BLH, ref XYZ);
                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars54_2000, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars54_2000.MDMajorAxis, CoorSysPars54_2000.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        e2 = CoorSysPars54_2000.MDDAlpha * (2 - CoorSysPars54_2000.MDDAlpha);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars54_2000.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars54_2000.CMeridian), CoorSysPars54_2000.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh_temp.x, ref xyh_temp.y);
                                        xyh_temp.h = BLH_temp.height;


                                        // PostCoorTrans.BLHtoxyh(BLH, CoorSysPars2000_54, ref xyh);
                                        xyh_temp.x = xyh_temp.x + CoorSysPars54_2000.OriginNorth; xyh_temp.y = xyh_temp.y + CoorSysPars54_2000.OriginEast;

                                        double H = 0;
                                        double dh = CoorSysPars54_2000.CMeridian / 3;//  getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh_temp.h = BLH.height - H;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + CoorSysPars54_2000.CMeridian.ToString("F4").PadRight(20));

                                        }
                                        else
                                        {
                                            xyh_temp.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + CoorSysPars54_2000.CMeridian.ToString("F4").PadRight(20));

                                        }
                                    }
                                }
                            }
                            sw.Close();
                            //转换完成
                            Model.CoorTransRec coorTransRec = new Model.CoorTransRec();
                            try
                            {
                                coorTransRec.ProjectName = Request.Form["ProjectName"].ToString();
                            }
                            catch (Exception)
                            {


                            }
                            coorTransRec.Time = DateTime.Now;
                            coorTransRec.Remark = "多点转换";
                            coorTransRec.Type = TargetS;
                            coorTransRec.UserName = username;

                            //Model.RTKUserInfo rtkUsetInfo = DAL.RTKUserInfo.GetModel(cr.UserName);
                            //rtkUsetInfo.Amount = OrgCoor.Count;
                            //rtkUsetInfo.Cost = pay;
                            //rtkUsetInfo.Result = "转换成功";
                            //if (rt == null)
                            //{
                            //    DAL.UserInfoWeb us = new DAL.UserInfoWeb();

                            //    mus = us.GetModelu(username);
                            //    cr.Company = mus.Unit;
                            //}
                            //else
                            //{
                            //    cr.Company = rt.Company;
                            //}

                            path = resultfile;
                            if (Request.Form["Encryption"].ToString().Trim() == "不压缩")
                            {
                            }
                            else
                            {
                                if (Request.Form["Encryption"].ToString().Trim() == "采用用户名进行加密压缩")
                                {
                                    cs.clsWinRar.CompressRar(path, "", rtkUserName);
                                }
                                //else
                                //{
                                //    clsWinRar.CompressRar(path, "", AES_Key.AESDecrypt(duinfo.GetModelu(UserName).PassWord, UserName.PadLeft(16, '0')));
                                //}
                                path += ".rar";
                            }
                            coorTransRec.ResultPath = Path.GetFileName(path);
                            DAL.CoorTransRec.Add(coorTransRec);
                            //Model.CompanyPurview mcp = DAL.CompanyPurview.GetModel(Company);
                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;
                            //DAL.CompanyPurview.Update(mcp);
                            //Model.CompanyInfo mcp = DAL.CompanyInfo.GetModel(Company);
                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;
                            //mcp.Balance -= pay;
                            //DAL.CompanyInfo.Update(mcp);
                            Response.Clear();
                            Response.Write(resultfile);
                            Response.End();
                            break;
                        }
                    #endregion
                    #region XIAN1980_TO_CGCS2000
                    case "XIAN1980_TO_CGCS2000":
                        {
                            string GeoidFilename = Server.MapPath("~/cs/") + "geoid.mskE";
                            cs.Geoid geoid = new cs.Geoid();
                            geoid.ReadGrid(GeoidFilename);
                            Model.OFormerCoorSysPars CoorSysPars80_2000 = new Model.OFormerCoorSysPars();
                            CoorSysPars80_2000.X = -65.7195;
                            CoorSysPars80_2000.Y = -135.0313;
                            CoorSysPars80_2000.Z = 79.7629;
                            CoorSysPars80_2000.aa = 3.6766065466;
                            CoorSysPars80_2000.bb = 0.8652358566;
                            CoorSysPars80_2000.cc = -0.6213678779;
                            CoorSysPars80_2000.m = 3.2387800164;
                            CoorSysPars80_2000.CMeridian = mlon;
                            CoorSysPars80_2000.MDDAlpha = 1.0 / 298.257223563;
                            CoorSysPars80_2000.MDe2 = 0.00669438002290;
                            CoorSysPars80_2000.MDMajorAxis = 6378137.0;
                            CoorSysPars80_2000.YSDAlpha = 1.0 / 298.257;
                            CoorSysPars80_2000.YSe2 = 0.00669438498631463;
                            CoorSysPars80_2000.YSMajorAxis = 6378140.0;
                            CoorSysPars80_2000.OriginEast = oe;
                            CoorSysPars80_2000.OriginNorth = on;
                            CoorSysPars80_2000.ProjElevation = projele;
                            string resultfile = Server.MapPath("~/TransResult/") + rtkUserName + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".result";
                            File.Create(resultfile).Close();
                            StreamWriter sw = new StreamWriter(resultfile);
                            sw.WriteLine("#单位：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#操作人：".PadRight(10, ' ') + rtkUserName);
                            sw.WriteLine("#项目名称：".PadRight(10, ' ') + Projectname);
                            sw.WriteLine("#转点时间：".PadRight(10, ' ') + DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日");
                            sw.WriteLine("#转换类型：".PadRight(10, ' ') + coortype + "->xyh");
                            sw.WriteLine("#转换坐标系：".PadRight(10, ' ') + TargetS);
                            sw.WriteLine("#转点个数：".PadRight(10, ' ') + OrgCoor.Count);
                            sw.WriteLine("#起始北坐标：".PadRight(10, ' ') + on);
                            sw.WriteLine("#起始东坐标：".PadRight(10, ' ') + oe);
                            sw.WriteLine("#投影抬高：".PadRight(10, ' ') + projele);
                            //sw.WriteLine("#中央子午线经度：".PadRight(10, ' ') + mlon);

                            sw.WriteLine("#原始数据".PadRight(10, ' '));
                            sw.WriteLine("--".PadRight(120, '-'));
                            if (coortype == "BLH")
                            {
                                sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(18) + "经度".PadRight(18) + "大地高".PadRight(17));

                            }
                            if (coortype == "XYZ")
                            {
                                sw.WriteLine("点名".PadRight(8) + "X".PadRight(18) + "Y".PadRight(18) + "Z".PadRight(17));
                            }
                            if (coortype == "xyh")
                            {
                                sw.WriteLine("点名".PadRight(8) + "北坐标".PadRight(18) + "东坐标".PadRight(18) + "大地高".PadRight(17));
                            }
                            foreach (var d in OrgCoor)
                            {
                                sw.WriteLine(d[3].ToString().PadRight(10) + d[0].PadRight(20) + d[1].PadRight(20) + d[2].PadRight(20));

                            }
                            sw.WriteLine("   ");
                            sw.WriteLine("#成果数据".PadRight(10, ' '));

                            sw.WriteLine("--".PadRight(100, '-'));
                            sw.WriteLine("点名".PadRight(8) + "纬度".PadRight(18) + "经度".PadRight(18) + "北坐标".PadRight(17) + "东坐标".PadRight(17) + "中央子午线".PadRight(15));


                            if (coortype == "BLH")
                            {
                                for (int i = 0; i < OrgCoor.Count; i++)
                                {
                                    cs.GEODETIC BLH = new cs.GEODETIC();
                                    cs.PLANECOOR xyh = new cs.PLANECOOR();
                                    BLH.latdms = double.Parse(OrgCoor[i][0]);
                                    BLH.londms = double.Parse(OrgCoor[i][1]);
                                    BLH.height = double.Parse(OrgCoor[i][2]);




                                    if (mlon == 123456)
                                    {
                                        CoorSysPars80_2000.CMeridian = getcm(BLH.londms);
                                    }


                                    double e2 = CoorSysPars80_2000.MDDAlpha * (2 - CoorSysPars80_2000.MDDAlpha);
                                    cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                    cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                    cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                    cs.PostCoorTrans.Geo2Car(CoorSysPars80_2000.YSMajorAxis, CoorSysPars80_2000.YSDAlpha, BLH, ref XYZ);
                                    cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars80_2000, ref XYZ_temp);
                                    cs.PostCoorTrans.Car2Geo(CoorSysPars80_2000.MDMajorAxis, CoorSysPars80_2000.MDDAlpha, XYZ_temp, ref BLH_temp);
                                    cs.PostCoorTrans.BL2xy(CoorSysPars80_2000.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars80_2000.CMeridian), CoorSysPars80_2000.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);

                                    xyh.h = BLH_temp.height;

                                    // PostCoorTrans.BLHtoxyh(BLH, CoorSysPars80_2000, ref xyh);
                                    xyh.x = xyh.x + CoorSysPars80_2000.OriginNorth; xyh.y = xyh.y + CoorSysPars80_2000.OriginEast;
                                    double H = 0;
                                    double dh = CoorSysPars80_2000.CMeridian / 3;//  getcm(BLH.londms) / 3;
                                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                    {
                                        xyh.h = BLH.height - H;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars80_2000.CMeridian.ToString("F4").PadRight(20));

                                    }
                                    else
                                    {
                                        xyh.h = BLH.height;
                                        sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars80_2000.CMeridian.ToString("F4").PadRight(20));

                                    }


                                }
                            }
                            else
                            {
                                if (coortype == "XYZ")
                                {
                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        XYZ.X = double.Parse(OrgCoor[i][0]);
                                        XYZ.Y = double.Parse(OrgCoor[i][1]);
                                        XYZ.Z = double.Parse(OrgCoor[i][2]);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars80_2000.YSMajorAxis, CoorSysPars80_2000.YSDAlpha, XYZ, ref BLH); double H = 0;



                                        if (mlon == 123456)
                                        {
                                            CoorSysPars80_2000.CMeridian = getcm(BLH.londms);
                                        }
                                        double e2 = CoorSysPars80_2000.MDDAlpha * (2 - CoorSysPars80_2000.MDDAlpha);
                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();


                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars80_2000, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars80_2000.MDMajorAxis, CoorSysPars80_2000.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars80_2000.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars80_2000.CMeridian), CoorSysPars80_2000.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
                                        xyh.h = BLH_temp.height;

                                        //PostCoorTrans.XYZtoxyh(XYZ, CoorSysPars2000_80, ref xyh);
                                        xyh.x = xyh.x + CoorSysPars80_2000.OriginNorth; xyh.y = xyh.y + CoorSysPars80_2000.OriginEast;
                                        double dh = CoorSysPars80_2000.CMeridian / 3;//getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh.h = BLH.height - H;

                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars80_2000.CMeridian.ToString("F4").PadRight(20));
                                        }
                                        else
                                        {
                                            xyh.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh.y.ToString("F4").PadRight(18) + CoorSysPars80_2000.CMeridian.ToString("F4").PadRight(20));
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < OrgCoor.Count; i++)
                                    {

                                        //xyh

                                        //前面有带号，提取出来算中央子午线
                                        cs.PLANECOOR xyh = new cs.PLANECOOR();
                                        xyh.x = double.Parse(OrgCoor[i][0]);
                                        xyh.y = double.Parse(OrgCoor[i][1].Substring(2, OrgCoor[i][1].Length - 2)) - 500000;
                                        xyh.h = double.Parse(OrgCoor[i][2]);
                                        if (mlon == 123456)
                                        {
                                            CoorSysPars80_2000.CMeridian = double.Parse(OrgCoor[i][1].Substring(0, 2)) * 3;
                                        }
                                        double e2 = CoorSysPars80_2000.YSDAlpha * (2 - CoorSysPars80_2000.YSDAlpha);
                                        cs.GEODETIC BLH = new cs.GEODETIC();
                                        double b = 0;
                                        double l = 0;

                                        cs.PostCoorTrans.xy2BL(CoorSysPars80_2000.YSMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars80_2000.CMeridian), xyh.x, xyh.y, ref b, ref l);

                                        BLH.lat = b * 180 / Math.PI;
                                        BLH.lon = l * 180 / Math.PI;
                                        BLH.height = xyh.h;



                                        cs.CARTESIAN XYZ_temp = new cs.CARTESIAN();
                                        cs.GEODETIC BLH_temp = new cs.GEODETIC();
                                        cs.PLANECOOR xyh_temp = new cs.PLANECOOR();
                                        cs.CARTESIAN XYZ = new cs.CARTESIAN();
                                        cs.PostCoorTrans.Geo2Car(CoorSysPars80_2000.YSMajorAxis, CoorSysPars80_2000.YSDAlpha, BLH, ref XYZ);
                                        cs.PostCoorTrans.ParameterTrans7(XYZ, CoorSysPars80_2000, ref XYZ_temp);
                                        cs.PostCoorTrans.Car2Geo(CoorSysPars80_2000.MDMajorAxis, CoorSysPars80_2000.MDDAlpha, XYZ_temp, ref BLH_temp);
                                        e2 = CoorSysPars80_2000.MDDAlpha * (2 - CoorSysPars80_2000.MDDAlpha);
                                        cs.PostCoorTrans.BL2xy(CoorSysPars80_2000.MDMajorAxis, e2, cs.PostCoorTrans.Angle2Ration(CoorSysPars80_2000.CMeridian), CoorSysPars80_2000.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh_temp.x, ref xyh_temp.y);
                                        xyh_temp.h = BLH_temp.height;


                                        // PostCoorTrans.BLHtoxyh(BLH, CoorSysPars2000_54, ref xyh);
                                        xyh_temp.x = xyh_temp.x + CoorSysPars80_2000.OriginNorth; xyh_temp.y = xyh_temp.y + CoorSysPars80_2000.OriginEast;

                                        double H = 0;
                                        double dh = CoorSysPars80_2000.CMeridian / 3;// getcm(BLH.londms) / 3;
                                        if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                                        {
                                            xyh_temp.h = BLH.height - H;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + CoorSysPars80_2000.CMeridian.ToString("F4").PadRight(20));

                                        }
                                        else
                                        {
                                            xyh_temp.h = BLH.height;
                                            sw.WriteLine(OrgCoor[i][3].ToString().PadRight(10) + BLH_temp.latdms.ToString("F8").PadRight(20) + BLH_temp.londms.ToString("F8").PadRight(20) + xyh_temp.x.ToString("F4").PadRight(20) + dh.ToString("00") + xyh_temp.y.ToString("F4").PadRight(18) + CoorSysPars80_2000.CMeridian.ToString("F4").PadRight(20));

                                        }
                                    }
                                }
                            }
                            sw.Close();
                            //转换完成
                            Model.CoorTransRec cr = new Model.CoorTransRec();
                            try
                            {
                                cr.ProjectName = Request.Form["ProjectName"].ToString();
                            }
                            catch (Exception)
                            {


                            }
                            cr.Time = DateTime.Now;
                            cr.Remark = "多点转换";
                            cr.Type = TargetS;
                            cr.UserName = username;
                            cr.ResultPath = Path.GetFileName(resultfile);
                            cr.Amount = OrgCoor.Count;
                            cr.Cost = pay;
                            cr.Result = "转换成功";
                            //if (rt == null)
                            //{
                            //    DAL.UserInfoWeb us = new DAL.UserInfoWeb();

                            //    mus = us.GetModelu(username);
                            //    cr.Company = mus.Unit;
                            //}
                            //else
                            //{
                            //    cr.Company = rt.Company;
                            //}

                            path = resultfile;
                            if (Request.Form["Encryption"].ToString().Trim() == "不压缩")
                            {
                            }
                            else
                            {
                                if (Request.Form["Encryption"].ToString().Trim() == "采用用户名进行加密压缩")
                                {
                                    cs.clsWinRar.CompressRar(path, "",rtkUserName);
                                }
                                //else
                                //{
                                //    clsWinRar.CompressRar(path, "", AES_Key.AESDecrypt(duinfo.GetModelu(UserName).PassWord, UserName.PadLeft(16, '0')));
                                //}
                                path += ".rar";
                            }
                            cr.ResultPath = Path.GetFileName(path);
                            DAL.CoorTransRec.Add(cr);
                            //Model.CompanyPurview mcp = DAL.CompanyPurview.GetModel(Company);
                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;
                            //DAL.CompanyPurview.Update(mcp);
                            //Model.CompanyInfo mcp = DAL.CompanyInfo.GetModel(Company);
                            //mcp.PostCoorTransUsed += OrgCoor.Count;
                            //mcp.PostCoorTransCount -= OrgCoor.Count;
                            //DAL.CompanyInfo.Update(mcp);
                            Response.Clear();
                            Response.Write(resultfile);
                            Response.End();
                            break;
                        }
                    #endregion
                    default:
                        {
                            //转换类型错误
                            Response.Clear();
                            Response.Write("3");
                            Response.End();
                            break;
                        }
                }
            }


        }

        double getcm(double L)
        {
            //河南经纬度范围：东经110°21′ ～116°39′，北纬31°23′～36°22′
            if(L<112.3)
            {
                return 111;
            }
            else
            {
                return 114;
            }
            ////青海
            //if (L <= 91.3)
            //{
            //    return 90;
            //}
            //else
            //{
            //    if (L > 91.3 && L <= 94.3)
            //    {
            //        return 93;
            //    }
            //    else
            //    {
            //        if (L > 94.3 && L <= 97.3)
            //        {
            //            return 96;
            //        }
            //        else
            //        {
            //            if (L > 97.3 && L <= 100.3)
            //            {
            //                return 99;
            //            }
            //            else
            //            {
            //                return 102;
            //            }
            //        }
            //    }
            //}
        }

        protected void downloadresult_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                Response.AppendHeader("Content-Length", fi.Length.ToString());
                Response.WriteFile(fi.FullName);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {


            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != null)
                {
                    FileInfo fi = new FileInfo(path);
                    path = null;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name));
                    Response.AppendHeader("Content-Length", fi.Length.ToString());
                    Response.WriteFile(fi.FullName);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception)
            {


            }
        }


        public void download(string filename)
        {
            string FileName = Server.MapPath("~/TransResult/") + filename;
            if (File.Exists(FileName))
            {
                FileInfo fileinfoo = new FileInfo(FileName);
                //以字符流的形式下载文件
                FileStream fs = new FileStream(FileName, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开
                Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileinfoo.Name, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
}