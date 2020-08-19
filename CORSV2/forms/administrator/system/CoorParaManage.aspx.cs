using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class CoorParaManage : System.Web.UI.Page
    {
        public string result = "";
        public string selectArea = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) < 2 || Convert.ToInt32(Session["UserType"]) > 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] != null)
            {
                switch (Request["action"].ToString())
                {
                    case "GetData":
                        GetData();
                        break;
                    //case "GetGD":
                    //    GetGDByID();
                    //    break;
                    case "GetWorkingArea":
                        GetWorkingArea();
                        break;
                    case "Delete":
                        DeleteData();
                        break;
                    case "UpdateData":
                        try
                        {
                            if (!UpdateData())
                            {
                                Response.Clear();
                                Response.ContentType = "text/plain";
                                Response.Write("1");
                                Response.End();
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message != "")
                            {
                                Response.Clear();
                                Response.ContentType = "text/plain";
                                Response.Write("0");
                                Response.End();
                            }
                        }

                        break;
                    case "AddPara":
                        AddData();
                        Response.Write(result);
                        Response.ContentType = "text/plain";
                        Response.End();
                        break;
                    default:
                        break;
                }

            }
        }

        /// <summary>
        /// 获得WorkingArea的json字符串 
        /// </summary>
        /// <returns>是否成功获得数据</returns>
        private bool GetWorkingArea()
        {
            DataSet ds = DAL.WorkingArea.GetList("1=1");
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = "0";
            dr["AreaName"] = "全部区域";
            ds.Tables[0].Rows.Add(dr);
            string jsonArea = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
            Response.ContentType = "application/Json";
            Response.Write(jsonArea);
            Response.End();
            return true;
        }
        private bool GetData()
        {
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            DataSet ds = DAL.CoorSysPars.GetListByPage(offset, limit);
            int totalCount = DAL.CoorSysPars.GetRecordCount();
            //ds.Tables[0].Columns.Add("deTime", typeof(string));
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //    dr["deTime"] = dr["Time"].ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonNews = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
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

        private void DeleteData()
        {
            //int[] ids;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            //ids = new int[temp.Length];
            Model.SysLog mSysLog = new Model.SysLog();
            for (int j = 0; j < temp.Length; j++)
            {
                int id = Convert.ToInt32(temp[j]);

                Model.CoorSysPars cp = DAL.CoorSysPars.GetModelFormId(id);
                string YSZBXM = cp.YSZBXM;
                string MDZBXM = cp.MDZBXM;
                DAL.CoorSysPars.Delete(MDZBXM);
                int Fcsp = DAL.FormerCoorSysPars.Delete(MDZBXM);
                mSysLog.UserName = Convert.ToString(Session["UserName"]);
                mSysLog.LogType = 0;
                mSysLog.LogTime = DateTime.Now;
                mSysLog.Remark = "管理员删除了目的坐标系为" + MDZBXM + "的坐标系,其中包括" + (2 + Fcsp).ToString() + "套";
                DAL.SysLog.Add(mSysLog);
                //删除GDCoorXYZ
                DAL.GDCoorSysXYZ.Delete(MDZBXM);

                //删除用户权限坐标系中的信息
                DataSet ds = DAL.RTKUserPurview.GetList("1=1");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Model.RTKUserPurview modelRTKUserPurview = DAL.RTKUserPurview.GetModel(ds.Tables[0].Rows[i]["UserName"].ToString());
                    string[] Sources = modelRTKUserPurview.CoorSystem.Split(';');
                    string NewSources = "";
                    bool IsHas = false;
                    foreach (string SourceIn in Sources)
                    {
                        if (SourceIn.Trim() != "")
                        {
                            if (SourceIn == MDZBXM)
                            {
                                IsHas = true;
                            }
                            else
                            {
                                NewSources = NewSources + SourceIn + ";";
                            }
                        }
                    }
                    if (IsHas)
                    {
                        modelRTKUserPurview.CoorSystem = NewSources;
                        DAL.RTKUserPurview.Update(modelRTKUserPurview);
                    }

                }
                //删除事后坐标转换中的用户权限相关信息，实时服务的在用户管理页面会有相关信息
                ds = new DataSet();
                ds = DAL.RTKUserPurview.GetList("1=1");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Model.RTKUserPurview modelRTKUserPurview = DAL.RTKUserPurview.GetModel(ds.Tables[0].Rows[i]["UserName"].ToString());
                    string[] Sources = modelRTKUserPurview.CoorSystem.Split(';');
                    string NewSources = "";
                    bool IsHas = false;
                    foreach (string SourceIn in Sources)
                    {
                        if (SourceIn.Trim() != "")
                        {
                            if (SourceIn == (YSZBXM + "-" + MDZBXM) || SourceIn == ("GD-" + MDZBXM))
                            {
                                IsHas = true;
                            }
                            else
                            {
                                NewSources = NewSources + SourceIn + ";";
                            }
                        }
                    }
                    if (IsHas)
                    {
                        modelRTKUserPurview.CoorSystem = NewSources;
                        DAL.RTKUserPurview.Update(modelRTKUserPurview);
                    }
                }

                //}
                ////删除单位管理权限中的坐标系
                //ds = new DataSet();
                //ds = DAL.CompanyPurview.GetList("1=1");
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    Model.CompanyPurview mcp = DAL.CompanyPurview.GetModel(ds.Tables[0].Rows[i]["Company"].ToString());
                //    string[] Sources = mcp.MDZBXM.Split(';');
                //    string NewSources = "";
                //    bool IsHas = false;
                //    foreach (string SourceIn in Sources)
                //    {
                //        if (SourceIn.Trim() != "")
                //        {
                //            if (SourceIn == MDZBXM)
                //            {
                //                IsHas = true;
                //            }
                //            else
                //            {
                //                NewSources = NewSources + SourceIn + ";";
                //            }
                //        }
                //    }
                //    mcp.MDZBXM = NewSources;
                //    Sources = mcp.PostCoorTrans.Split(';');
                //    NewSources = "";
                //    foreach (string SourceIn in Sources)
                //    {
                //        if (SourceIn.Trim() != "")
                //        {
                //            if (SourceIn == (YSZBXM + "-" + MDZBXM) || SourceIn == ("GD-" + MDZBXM))
                //            {
                //                IsHas = true;
                //            }
                //            else
                //            {
                //                NewSources = NewSources + SourceIn + ";";
                //            }
                //        }
                //    }
                //    mcp.PostCoorTrans = NewSources;

                //    if (IsHas)
                //    {
                //        DAL.CompanyPurview.Update(mcp);
                //    }
                //}
            }
        }

        private bool AddData()
        {
            try
            {
                Model.CoorSysPars mcs = GetModelFromRequest();
                if (!ValidateCoorPara(mcs))
                    return false;

                mcs.YSMajorAxis = 6378137;
                mcs.YSDAlpha = 298.257223563;
                mcs.YSe2 = 0.00669438000426083;
                if (Request["DesEllip"] == "84")
                {
                    mcs.MDMajorAxis = 6378137;
                    mcs.MDDAlpha = 298.257223563;
                    mcs.MDe2 = 0.00669438000426083;
                }
                else if (Request["DesEllip"] == "54")
                {
                    mcs.MDMajorAxis = 6378245;
                    mcs.MDDAlpha = 298.3;
                    mcs.MDe2 = 0.00669342161454287;
                }
                else if (Request["DesEllip"] == "80")
                {
                    mcs.MDMajorAxis = 6378140;
                    mcs.MDDAlpha = 298.257;
                    mcs.MDe2 = 0.00669438498631463;
                }
                else if (Request["DesEllip"] == "0")
                {
                    mcs.MDMajorAxis = Convert.ToDouble(Request["MDMajorAxis"].Trim());
                    double a = mcs.MDMajorAxis;
                    double f = Convert.ToDouble(Request["MDDAlpha"].Trim());
                    mcs.MDDAlpha = f;
                    double b = a - a / f;
                    double e12 = (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(a, 2);
                    mcs.MDe2 = e12;
                }

                //if (Regex.IsMatch(TextBox_AddMDMajorAxis.Text.Trim(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
                //{
                //    mcs.MDMajorAxis = Convert.ToDouble(TextBox_AddMDMajorAxis.Text.Trim());
                //}
                //else
                //{
                //    ExtAspNet.Alert.Show("输入有误，请慎重修改", "提示", ExtAspNet.MessageBoxIcon.Information);
                //    return;
                //}
                //if (Regex.IsMatch(TextBox_AddMDe2.Text.Trim(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
                //{
                //    mcs.MDe2 = Convert.ToDouble(TextBox_AddMDe2.Text.Trim());
                //}
                //else
                //{
                //    ExtAspNet.Alert.Show("输入有误，请慎重修改", "提示", ExtAspNet.MessageBoxIcon.Information);
                //    return;
                //}
                mcs.AreaID = Convert.ToInt32(Request["WorkArea"]);
                DAL.CoorSysPars.Add(mcs);
                //加入OFormerCoorSysPars
                Model.OFormerCoorSysPars mofcsp = new Model.OFormerCoorSysPars();
                mofcsp.aa = mcs.aa; mofcsp.bb = mcs.bb; mofcsp.cc = mcs.cc; mofcsp.CMeridian = mcs.CMeridian; mofcsp.EndTime = DateTime.Now;
                mofcsp.IsFormer = 0; mofcsp.m = mcs.m; mofcsp.MDDAlpha = mcs.MDDAlpha; mofcsp.MDe2 = mcs.MDe2; mofcsp.MDMajorAxis = mcs.MDMajorAxis;
                mofcsp.MDRemarkName = mcs.MDRemarkName; mofcsp.MDZBXM = mcs.MDZBXM; mofcsp.ProjElevation = mcs.ProjElevation; mofcsp.StartTime = DateTime.Now;
                mofcsp.X = mcs.X; mofcsp.Y = mcs.Y; mofcsp.YSDAlpha = mcs.YSDAlpha; mofcsp.YSe2 = mcs.YSe2; mofcsp.YSMajorAxis = mcs.YSMajorAxis;
                mofcsp.YSRemarkName = mcs.YSRemarkName; mofcsp.YSZBXM = mcs.YSZBXM; mofcsp.Z = mcs.Z; mofcsp.OriginEast = mcs.OriginEast; mofcsp.OriginNorth = mcs.OriginNorth;
                DAL.FormerCoorSysPars.Add(mofcsp);
                Model.OCoorSysPars mocsp = DAL.CoorSysPars.GetOModel(mcs.YSZBXM, mcs.MDZBXM);
                //加入GDCoorSysXYZ
                Model.GDCoorSysXYZ mgdcs = new Model.GDCoorSysXYZ();
                mgdcs.YSZBXM = mocsp.YSZBXM; mgdcs.MDZBXM = mocsp.MDZBXM;
                Random r = new Random();
                mgdcs.X = r.Next(-4, 3) + r.NextDouble();
                double xs = (mocsp.X + mgdcs.X) * 10 - Math.Floor(mocsp.X * 10 + mgdcs.X * 10);
                xs = 1 - xs;
                mgdcs.X = mgdcs.X + xs / 10;
                mgdcs.Y = r.Next(2, 5) + r.NextDouble();
                xs = (mocsp.Y + mgdcs.Y) * 10 - Math.Floor(mocsp.Y * 10 + mgdcs.Y * 10);
                xs = 1 - xs;
                mgdcs.Y += xs / 10;
                mgdcs.Z = r.Next(1, 4) + r.NextDouble();
                xs = (mocsp.Z + mgdcs.Z) * 10 - Math.Floor(mocsp.Z * 10 + mgdcs.Z * 10);
                xs = 1 - xs;
                mgdcs.Z += xs / 10;

                mgdcs.aa = (double)r.Next(1, 9) / 100.0 + (double)r.Next(1, 9) / 1000.0;
                xs = (mocsp.aa + mgdcs.aa) * 1000 - Math.Floor(mocsp.aa * 1000 + mgdcs.aa * 1000);
                xs = 1 - xs;
                mgdcs.aa += xs / 1000;

                mgdcs.bb = (double)r.Next(1, 9) / 100.0 + (double)r.Next(1, 9) / 1000.0;
                xs = (mocsp.bb + mgdcs.bb) * 1000 - Math.Floor(mocsp.bb * 1000 + mgdcs.bb * 1000);
                xs = 1 - xs;
                mgdcs.bb += xs / 1000;

                mgdcs.cc = (double)r.Next(1, 9) / 100.0 + (double)r.Next(1, 9) / 1000.0;
                xs = (mocsp.cc + mgdcs.cc) * 1000 - Math.Floor(mocsp.cc * 1000 + mgdcs.cc * 1000);
                xs = 1 - xs;
                mgdcs.cc += xs / 1000;
                // mgdcs.aa = 0; mgdcs.bb = 0; mgdcs.cc = 0;

                ///////////////////////////Not sure///////////////////////////
                if (Request["md"] == "0")
                {
                    mgdcs.aa = 0; mgdcs.bb = 0; mgdcs.cc = 0;
                    mgdcs.X = 0; mgdcs.Y = 0; mgdcs.Z = 0;
                }


                DAL.GDCoorSysXYZ.Add(mgdcs);
                double hudumiao = (180.0 / Math.PI) * 3600;
                Canshu csk = new Canshu();
                csk.dx = mocsp.X;
                csk.dy = mocsp.Y;
                csk.dz = mocsp.Z;
                csk.m0 = mocsp.m / 1000000.0;
                csk.Qx = mocsp.aa / hudumiao;
                csk.Qy = mocsp.bb / hudumiao;
                csk.Qz = mocsp.cc / hudumiao;
                CoorTrans coortrana = new CoorTrans();
                coortrana.SetCanshu(csk);
                Model.GDCoorSysXYZ mgdc = DAL.GDCoorSysXYZ.GetModel(mcs.YSZBXM, mcs.MDZBXM);
                coortrana.CalCanshu(mgdc.X, mgdc.Y, mgdc.Z, mgdc.aa / hudumiao, mgdc.bb / hudumiao, mgdc.cc / hudumiao);
                Model.CoorSysPars gd = new Model.CoorSysPars();
                gd.YSZBXM = "GD";
                gd.YSRemarkName = "发布坐标系";
                gd.MDZBXM = mcs.MDZBXM;
                gd.MDRemarkName = mcs.MDRemarkName;
                gd.X = coortrana.cs2.dx;
                gd.Y = coortrana.cs2.dy;
                gd.Z = coortrana.cs2.dz;
                gd.m = coortrana.cs2.m0 * 1000000.0;
                gd.aa = coortrana.cs2.Qx * hudumiao;
                gd.bb = coortrana.cs2.Qy * hudumiao;
                gd.cc = coortrana.cs2.Qz * hudumiao;
                gd.YSMajorAxis = mcs.YSMajorAxis;
                gd.YSDAlpha = mcs.YSDAlpha;
                gd.YSe2 = mcs.YSe2;
                gd.MDMajorAxis = mcs.MDMajorAxis;
                gd.MDDAlpha = mcs.MDDAlpha;
                gd.MDe2 = mcs.MDe2;
                gd.CMeridian = mcs.CMeridian;
                gd.ProjElevation = mcs.ProjElevation;
                gd.OriginNorth = mcs.OriginNorth;
                gd.OriginEast = mcs.OriginEast;
                gd.AreaID = mcs.AreaID;
                DAL.CoorSysPars.Add(gd);
                Model.SysLog msl = new Model.SysLog();
                msl.LogType = 0;
                msl.LogTime = DateTime.Now;
                msl.UserName = Convert.ToString(Session["UserName"]);
                msl.Remark = "添加了" + mcs.YSZBXM + "到" + mcs.MDZBXM + "的转换参数";
                DAL.SysLog.Add(msl);
                result += "添加参数成功";
                return true;
            }
            catch (Exception e) { result += e.Message; return false; }
        }


        private bool UpdateData()
        {
            Model.CoorSysPars mcs = GetModelFromRequest();

            if (mcs.YSZBXM == "GD")
            {
                result += "过渡坐标系不能修改";
            }
            mcs.ID = Convert.ToInt32(Request["ID"]);
            if (!ValidateCoorPara(mcs, 1))
                return false;

            DAL.CoorSysPars.Update(mcs);
            //更改过度坐标系坐标
            Model.OCoorSysPars mocsp = DAL.CoorSysPars.GetOModel(mcs.YSZBXM, mcs.MDZBXM);
            //加入GDCoorSysXYZ
            Model.GDCoorSysXYZ mgdcs = new Model.GDCoorSysXYZ();
            mgdcs.YSZBXM = mocsp.YSZBXM; mgdcs.MDZBXM = mocsp.MDZBXM;
            Random r = new Random();
            mgdcs.X = r.Next(-4, 3) + r.NextDouble();
            double xs = (mocsp.X + mgdcs.X) * 10 - Math.Floor(mocsp.X * 10 + mgdcs.X * 10);
            xs = 1 - xs;
            mgdcs.X = mgdcs.X + xs / 10;
            mgdcs.Y = r.Next(2, 5) + r.NextDouble();
            xs = (mocsp.Y + mgdcs.Y) * 10 - Math.Floor(mocsp.Y * 10 + mgdcs.Y * 10);
            xs = 1 - xs;
            mgdcs.Y += xs / 10;
            mgdcs.Z = r.Next(1, 4) + r.NextDouble();
            xs = (mocsp.Z + mgdcs.Z) * 10 - Math.Floor(mocsp.Z * 10 + mgdcs.Z * 10);
            xs = 1 - xs;
            mgdcs.Z += xs / 10;

            mgdcs.aa = (double)r.Next(1, 9) / 100.0 + (double)r.Next(1, 9) / 1000.0;
            xs = (mocsp.aa + mgdcs.aa) * 1000 - Math.Floor(mocsp.aa * 1000 + mgdcs.aa * 1000);
            xs = 1 - xs;
            mgdcs.aa += xs / 1000;

            mgdcs.bb = (double)r.Next(1, 9) / 100.0 + (double)r.Next(1, 9) / 1000.0;
            xs = (mocsp.bb + mgdcs.bb) * 1000 - Math.Floor(mocsp.bb * 1000 + mgdcs.bb * 1000);
            xs = 1 - xs;
            mgdcs.bb += xs / 1000;

            mgdcs.cc = (double)r.Next(1, 9) / 100.0 + (double)r.Next(1, 9) / 1000.0;
            xs = (mocsp.cc + mgdcs.cc) * 1000 - Math.Floor(mocsp.cc * 1000 + mgdcs.cc * 1000);
            xs = 1 - xs;
            mgdcs.cc += xs / 1000;
            //mgdcs.aa = 0; mgdcs.bb = 0; mgdcs.cc = 0;
            if (DAL.GDCoorSysXYZ.Exists(mcs.MDZBXM))
            {
                Model.GDCoorSysXYZ oldmgdcs = DAL.GDCoorSysXYZ.GetModel(mgdcs.YSZBXM, mgdcs.MDZBXM);
                mgdcs.ID = oldmgdcs.ID;
                bool IsSu = DAL.GDCoorSysXYZ.Update(mgdcs);
            }
            else
            {
                DAL.GDCoorSysXYZ.Add(mgdcs);
            }
            double hudumiao = (180.0 / Math.PI) * 3600;
            Canshu csk = new Canshu();
            csk.dx = mocsp.X;
            csk.dy = mocsp.Y;
            csk.dz = mocsp.Z;
            csk.m0 = mocsp.m / 1000000.0;
            csk.Qx = mocsp.aa / hudumiao;
            csk.Qy = mocsp.bb / hudumiao;
            csk.Qz = mocsp.cc / hudumiao;
            CoorTrans coortrana = new CoorTrans();
            coortrana.SetCanshu(csk);
            Model.GDCoorSysXYZ mgdc = DAL.GDCoorSysXYZ.GetModel(mcs.YSZBXM, mcs.MDZBXM);
            coortrana.CalCanshu(mgdc.X, mgdc.Y, mgdc.Z, mgdc.aa / hudumiao, mgdc.bb / hudumiao, mgdc.cc / hudumiao);
            Model.CoorSysPars gd = new Model.CoorSysPars();
            Model.CoorSysPars gdls = DAL.CoorSysPars.GetModel("GD", mcs.MDZBXM);
            gd.ID = gdls.ID;
            gd.YSZBXM = "GD";
            gd.YSRemarkName = mcs.YSRemarkName;
            gd.MDZBXM = mcs.MDZBXM;
            gd.MDRemarkName = mcs.MDRemarkName;
            gd.X = coortrana.cs2.dx;
            gd.Y = coortrana.cs2.dy;
            gd.Z = coortrana.cs2.dz;
            gd.m = coortrana.cs2.m0 * 1000000.0;
            gd.aa = coortrana.cs2.Qx * hudumiao;
            gd.bb = coortrana.cs2.Qy * hudumiao;
            gd.cc = coortrana.cs2.Qz * hudumiao;
            gd.YSMajorAxis = mcs.YSMajorAxis;
            gd.YSDAlpha = mcs.YSDAlpha;
            gd.YSe2 = mcs.YSe2;
            gd.MDMajorAxis = mcs.MDMajorAxis;
            gd.MDDAlpha = mcs.MDDAlpha;
            gd.MDe2 = mcs.MDe2;
            gd.CMeridian = mcs.CMeridian;
            gd.ProjElevation = mcs.ProjElevation;
            gd.OriginEast = mcs.OriginEast;
            gd.OriginNorth = mcs.OriginNorth;
            gd.AreaID = mcs.AreaID;
            DAL.CoorSysPars.Update(gd);
            Model.SysLog msl = new Model.SysLog();
            msl.LogType = 0;
            msl.LogTime = DateTime.Now;
            msl.UserName = Convert.ToString(Session["UserName"]);
            msl.Remark = "修改了" + mcs.YSZBXM + "到" + mcs.MDZBXM + "的转换参数";
            DAL.SysLog.Add(msl);
            result += "保存成功,请稍后退出系统，系统正在发送邮件通知用户";
            Thread Noticethread = new Thread(NoticeRTKUser);
            Noticethread.Start(gd.MDZBXM);
            return true;
        }
        /// <summary>
        /// 将获得的输入数据转换为MODEL对象
        /// </summary>
        /// <returns></returns>
        private Model.CoorSysPars GetModelFromRequest()
        {
            try
            {
                Model.CoorSysPars model = new Model.CoorSysPars();
                model.YSZBXM = "WGS84";
                model.MDZBXM = Request["MDZBXM"].ToString().Trim();
                model.X = Convert.ToDouble(Request["X"].ToString().Trim());
                model.Y = Convert.ToDouble(Request["Y"].ToString().Trim());
                model.Z = Convert.ToDouble(Request["Z"].ToString().Trim());
                model.aa = Convert.ToDouble(Request["aa"].ToString().Trim());
                model.bb = Convert.ToDouble(Request["bb"].ToString().Trim());
                model.cc = Convert.ToDouble(Request["cc"].ToString().Trim());
                model.m = Convert.ToDouble(Request["m"].ToString().Trim());
                model.YSMajorAxis = Request["YSMajorAxis"] == null ? -1 : Convert.ToDouble(Request["YSMajorAxis"].ToString().Trim());
                //model.YSe2 = Convert.ToDouble(Request["YSe2"].ToString().Trim());
                model.MDMajorAxis = Request["MDMajorAxis"] == null ? -1 : Convert.ToDouble(Request["MDMajorAxis"].ToString().Trim());
                //model.MDe2 = Convert.ToDouble(Request["MDe2"].ToString().Trim());
                model.YSRemarkName = Request["YSRemarkName"] == null ? "" : Request["YSRemarkName"].ToString().Trim();
                model.MDRemarkName = Request["MDRemarkName"] == null ? "" : Request["MDRemarkName"].ToString().Trim();
                //model.YSDAlpha = Convert.ToDouble(Request["YSDAlpha"].ToString().Trim());
                model.MDDAlpha = Convert.ToDouble(Request["MDDAlpha"].ToString().Trim());
                model.CMeridian = Convert.ToDouble(Request["CMeridian"].ToString().Trim());
                model.ProjElevation = Convert.ToDouble(Request["ProjElevation"].ToString().Trim());
                model.OriginNorth = Convert.ToDouble(Request["OriginNorth"].ToString().Trim());
                model.OriginEast = Convert.ToDouble(Request["OriginEast"].ToString().Trim());
                double a = 0, b = 0;
                a = model.YSMajorAxis;
                b = a - a / model.YSDAlpha;
                model.YSe2 = (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(a, 2);
                a = model.MDMajorAxis;
                b = a - a / model.MDDAlpha;
                model.MDe2 = (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(a, 2);
                return model;
            }
            catch
            {
                throw new Exception("参数填写错误");
            }
        }

        /// <summary>
        /// 判断是否有汉字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool HaveHZ(string text)
        {
            bool IsHas = false;
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] > 127)
                {
                    IsHas = true;
                    return IsHas;
                }
                else
                { }
            }
            return IsHas;
        }

        /// <summary>
        /// 判断是否为度分秒格式
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        private bool IsDMS(double L)
        {

            //double Ldu = Math.Floor(L); double Lfen = (L - Ldu) * 100; double Lm = (Lfen - Math.Floor(Lfen)) * 100;
            int Ldu = (int)Math.Floor(L); double Lfen = L * 100 - Ldu * 100; double Lm = Lfen * 100 - Math.Floor(Lfen) * 100;
            if (Ldu <= 60 || Ldu >= 130)
            {
                return false;
            }
            if (Lfen > 60 || Lm > 60)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="flag">为0时表示添加时的验证，为1时表示时修改时的验证</param>
        /// <returns></returns>
        private bool ValidateCoorPara(Model.CoorSysPars model, int flag = 0)
        {
            Model.CoorSysPars mcs = new Model.CoorSysPars();
            mcs = model;

            if (HaveHZ(mcs.MDZBXM))
            {
                result += "目的坐标系名不允许有汉字";
                return false;
            }
            if (mcs.MDZBXM == "无" || mcs.MDZBXM == "请选择" || mcs.MDZBXM == "WGS84")
            {
                result += "此目的坐标系名有误";
                return false;
            }
            if (flag == 0 && DAL.CoorSysPars.Exists(mcs.YSZBXM, mcs.MDZBXM))
            {
                result += "此目的坐标系已经存在";
                return false;
            }
            if (!Regex.IsMatch(mcs.X.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,9})$"))
            {
                result += "平移参数X输入有误";
                return false;
            }
            if (!Regex.IsMatch(mcs.Y.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,9})$"))
            {
                result += "平移参数Y输入有误";
                return false;
            }

            if (!Regex.IsMatch(mcs.Z.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,9})$"))
            {
                result += "平移参数Z输入有误";
                return false;
            }

            if (!Regex.IsMatch(mcs.aa.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
            {
                result += "旋转参数输入有误 ，请慎重修改";
                return false;
            }
            if (!Regex.IsMatch(mcs.bb.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
            {
                result += "旋转参数输入有误 ，请慎重修改";
                return false;
            }

            if (!Regex.IsMatch(mcs.cc.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
            {
                result += "旋转参数输入有误 ，请慎重修改";
                return false;
            }
            if (!Regex.IsMatch(mcs.m.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
            {
                result += "比例尺因子输入有误 ，请慎重修改";
                return false;
            }

            if (!IsDMS(mcs.CMeridian))
            {
                result += "中央子午线格式输入错误";
                return false;
            }
            if (!Regex.IsMatch(mcs.ProjElevation.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
            {
                result += "投影抬高输入有误";
                return false;
            }
            if (!Regex.IsMatch(mcs.OriginNorth.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$") || !Regex.IsMatch(mcs.OriginEast.ToString(), @"^(-?[0-9]*[.]*[0-9]{0,20})$"))
            {
                result += "原点坐标输入有误";
                return false;
            }
            return true;
        }

        public void NoticeRTKUser(object MDM)
        {
            string MDZBXM = MDM.ToString();
            //DataSet ds = DAL.RTKUserPurview.GetList("MDZBXM='" + MDZBXM + "'");
            //Model.OCoorSysPars mCoorSysPars = DAL.CoorSysPars.GetOModel("GD", MDZBXM);
            //string SendEmail = MDZBXM + "坐标系七参数已于" + DateTime.Now.ToString() + "变更。X轴平移参数=" + mCoorSysPars.X + "（米），Y轴平移参数=" + mCoorSysPars.Y + "（米），Z轴平移参数=" + mCoorSysPars.Z + "（米），X轴旋转角=" + mCoorSysPars.aa + "（秒），Y轴旋转角=" + mCoorSysPars.bb + "（秒），Z轴旋转角=" + mCoorSysPars.cc + "(秒)，尺度参数=" + mCoorSysPars.m + "（ppm），原始坐标系椭球长轴=" + mCoorSysPars.YSMajorAxis + "（米），原始坐标系椭球偏心率的平方=" + mCoorSysPars.YSe2 + "，目的坐标系椭球长轴=" + mCoorSysPars.MDMajorAxis + "（米），目的坐标系椭球偏心率的平方=" + mCoorSysPars.MDe2 + "。请及时更换，以免影响作业！";
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    string UserName = ds.Tables[0].Rows[i]["UserName"].ToString();
            //    Model.RTK_User mRTK_User = DAL.RTK_User.GetModel(UserName);

            //    if (mRTK_User.Email.Trim() != "")
            //    {
            //        JSCORS.SendEmail.Send(mRTK_User.Email, "七参数变更，请及时更换！", SendEmail);
            //        //if (mRTK_User.Phone.Contains("-"))
            //        //{
            //        //    string newphone = "";
            //        //    string[] phones = mRTK_User.Phone.Split('-');
            //        //    for (int ii = 0; ii < phones.Length; ii++)
            //        //    {
            //        //        newphone += phones[ii];
            //        //    }
            //        //    mRTK_User.Phone = newphone.Trim();
            //        //}
            //        //if (mRTK_User.Phone != "" && mRTK_User.Phone != null && mRTK_User.Phone.Trim().Length == 11)
            //        //{
            //        //    JSCORS.SendEmail.SendMessage(mRTK_User.Phone, SendEmail);
            //        //}
            //    }
            //}

        }
    }
}