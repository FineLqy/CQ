using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class StationInfoSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                string id = null;
                id = Request["id"];
                stationid.Value = id.ToString();
                Model.CORSStationInfo mc = DAL.CORSStationInfo.GetModel(int.Parse(id.ToString()));
                StationName.Value = mc.StationName;
                StationOName.Value = mc.StationOName;
                if (mc.IsOK == 1)
                {
                    IsOK.Value = "正常";
                }
                else
                {
                    IsOK.Value = "异常";
                }
                TransferType.Value = mc.TransferType;
                IP.Value = mc.IP;
                Port.Value = mc.Port;
                Lat.Value = mc.Lat.ToString();
                Lon.Value = mc.Lon.ToString();
                H.Value = mc.H.ToString();
                StationType.Value = mc.StationType;
                CaseNumber.Value = mc.CaseNumber;
                if (mc.BuildTime != null)
                { BuildTime.Value = mc.BuildTime.ToString(); }
                AffiliatedNetwork.Value = mc.AffiliatedNetwork;
                PiersType.Value = mc.PiersType;
                RelyUnits.Value = mc.RelyUnits;
                Address.Value = mc.Address;
                ThicknessOfLayer.Value = mc.ThicknessOfLayer;
                TrafficCondition.Value = mc.TrafficCondition;
                SitePerson.Value = mc.SitePerson;
                Builder.Value = mc.Builder;
                SoilType.Value = mc.SoilType;
                PermafrostDepth.Value = mc.PermafrostDepth;
                ThawDepth.Value = mc.ThawDepth;
                GroundwaterDepth.Value = mc.GroundwaterDepth;
                BelongsMap.Value = mc.BelongsMap;
                GeologicalStructure.Value = mc.GeologicalStructure;
                MaintenanceUnit.Value = mc.MaintenanceUnit;
                ContactPerson.Value = mc.ContactPerson;
                ContactTel.Value = mc.ContactTel;
                StationPlan.Value = mc.StationPlan;
                GravityPier.Value = mc.GravityPier;
                LevelSign.Value = mc.LevelSign;
                LightningReport.Value = mc.LightningReport;
                StationPhoto.Value = mc.StationPhoto;
                if (mc.StationPlan == "" || mc.StationPlan == null)
                {
                    viewPlan.Disabled = true;
                }
                if (mc.RingView == "" || mc.RingView == null)
                {
                    viewRingView.Disabled = true;
                }
                if (mc.GravityPier == "" || mc.GravityPier == null)
                {
                    viewGravityPier.Disabled = true;
                }
                if (mc.LevelSign == "" || mc.LevelSign == null)
                {
                    viewLevelSign.Disabled = true;
                }
                if (mc.LightningReport == "" || mc.LightningReport == null)
                {
                    viewLightningReport.Disabled = true;
                }
                if (mc.StationPhoto == "" || mc.StationPhoto == null)
                {
                    viewStationPhoto.Disabled = true;
                }
                RingView.Value = mc.RingView;
                EnvironmentalDescription.Value = mc.EnvironmentalDescription;
                SiteConditions.Value = mc.SiteConditions;
            }
            else
            {
                if (Request["upload"] == "plan")
                {
                    string filename = Request.Files["FilePlan"].FileName;
                    string stationname = Request.Form["StationName"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FilePlan"].SaveAs(Server.MapPath("~/upload/PLAN/") + stationname + "." + filenames[filenames.Length - 1]);
                    Model.CORSStationInfo ms = DAL.CORSStationInfo.GetModel(stationname);
                    ms.StationPlan = "/upload/PLAN/" + stationname + "." + filenames[filenames.Length - 1];
                    DAL.CORSStationInfo.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["stationid"].ToString().Trim();
                    MERR.Contents = Request.Form["StationName"].ToString().Trim() + "信息发生了修改：平面图;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "基站信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["upload"] == "ringview")
                {
                    string filename = Request.Files["FileRingView"].FileName;
                    string stationname = Request.Form["StationName"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileRingView"].SaveAs(Server.MapPath("~/upload/RINGVIEW/") + stationname + "." + filenames[filenames.Length - 1]);
                    Model.CORSStationInfo ms = DAL.CORSStationInfo.GetModel(stationname);
                    ms.RingView = "/upload/RINGVIEW/" + stationname + "." + filenames[filenames.Length - 1];
                    DAL.CORSStationInfo.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["stationid"].ToString().Trim();
                    MERR.Contents = Request.Form["StationName"].ToString().Trim() + "信息发生了修改：环视图;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "基站信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }

                if (Request["upload"] == "GravityPier")
                {
                    string filename = Request.Files["FileGravityPier"].FileName;
                    string stationname = Request.Form["StationName"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileGravityPier"].SaveAs(Server.MapPath("~/upload/GravityPier/") + stationname + "." + filenames[filenames.Length - 1]);
                    Model.CORSStationInfo ms = DAL.CORSStationInfo.GetModel(stationname);
                    ms.GravityPier = "/upload/GravityPier/" + stationname + "." + filenames[filenames.Length - 1];
                    DAL.CORSStationInfo.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["stationid"].ToString().Trim();
                    MERR.Contents = Request.Form["StationName"].ToString().Trim() + "信息发生了修改：重力墩;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "基站信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["upload"] == "LevelSign")
                {
                    string filename = Request.Files["FileLevelSign"].FileName;
                    string stationname = Request.Form["StationName"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileLevelSign"].SaveAs(Server.MapPath("~/upload/LevelSign/") + stationname + "." + filenames[filenames.Length - 1]);
                    Model.CORSStationInfo ms = DAL.CORSStationInfo.GetModel(stationname);
                    ms.LevelSign = "/upload/LevelSign/" + stationname + "." + filenames[filenames.Length - 1];
                    DAL.CORSStationInfo.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["stationid"].ToString().Trim();
                    MERR.Contents = Request.Form["StationName"].ToString().Trim() + "信息发生了修改：水准标志;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "基站信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["upload"] == "LightningReport")
                {
                    string filename = Request.Files["FileLightningReport"].FileName;
                    string stationname = Request.Form["StationName"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileLightningReport"].SaveAs(Server.MapPath("~/upload/LightningReport/") + stationname + "." + filenames[filenames.Length - 1]);
                    Model.CORSStationInfo ms = DAL.CORSStationInfo.GetModel(stationname);
                    ms.LightningReport = "/upload/LightningReport/" + stationname + "." + filenames[filenames.Length - 1];
                    DAL.CORSStationInfo.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["stationid"].ToString().Trim();
                    MERR.Contents = Request.Form["StationName"].ToString().Trim() + "信息发生了修改：检测报告;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "基站信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["upload"] == "StationPhoto")
                {
                    string filename = Request.Files["FileStationPhoto"].FileName;
                    string stationname = Request.Form["StationName"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileStationPhoto"].SaveAs(Server.MapPath("~/upload/StationPhoto/") + stationname + "." + filenames[filenames.Length - 1]);
                    Model.CORSStationInfo ms = DAL.CORSStationInfo.GetModel(stationname);
                    ms.StationPhoto = "/upload/StationPhoto/" + stationname + "." + filenames[filenames.Length - 1];
                    DAL.CORSStationInfo.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["stationid"].ToString().Trim();
                    MERR.Contents = Request.Form["StationName"].ToString().Trim() + "信息发生了修改：基站照片;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "基站信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["action"] == "save")
                {

                    Model.CORSStationInfo mcors = DAL.CORSStationInfo.GetModel(int.Parse(Request.Form["stationid"].ToString().Trim()));
                    Model.EquipmentInfo me = DAL.EquipmentInfo.GetModel(mcors.StationOName);
                    Model.SiteMonitoring ms = DAL.SiteMonitoring.GetModel(mcors.StationOName);

                    #region 对修改信息进行比对
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    bool IsRevice = false;
                    MERR.Contents = mcors.StationName + "信息发生了修改：";
                    if (mcors.TransferType != Request.Form["TransferType"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "传输类型;";
                    }
                    if (mcors.IP != Request.Form["IP"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "IP地址;";
                    }
                    if (mcors.Port != Request.Form["Port"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "端口;";
                    }
                    if (mcors.Lat != double.Parse(Request.Form["Lat"].ToString().Trim()))
                    {

                        IsRevice = true;
                        MERR.Contents += "纬度;";
                    }
                    if (mcors.Lon != double.Parse(Request.Form["Lon"].ToString().Trim()))
                    {
                        IsRevice = true;
                        MERR.Contents += "经度;";
                    }
                    if (mcors.H != double.Parse(Request.Form["H"].ToString().Trim()))
                    {
                        IsRevice = true;
                        MERR.Contents += "高程;";
                    }
                    if (mcors.StationType != Request.Form["StationType"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "基站型号;";
                    }
                    if (mcors.CaseNumber != Request.Form["CaseNumber"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "备案号;";
                    }
                    if (mcors.BuildTime != DateTime.Parse(Request.Form["BuildTime"].ToString().Trim()))
                    {
                        IsRevice = true;
                        MERR.Contents += "建站时间;";
                    }
                    if (mcors.AffiliatedNetwork != Request.Form["AffiliatedNetwork"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "所属站网;";
                    }
                    if (mcors.PiersType != Request.Form["PiersType"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "墩标类型;";
                    }
                    if (mcors.RelyUnits != Request.Form["RelyUnits"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "依托单位;";
                    }
                    if (mcors.Address != Request.Form["Address"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "所在地区;";
                    }
                    if (mcors.ThicknessOfLayer != Request.Form["ThicknessOfLayer"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "土层厚度;";
                    }
                    if (mcors.TrafficCondition != Request.Form["TrafficCondition"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "交通情况;";
                    }
                    if (mcors.SitePerson != Request.Form["SitePerson"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "选点者信息;";
                    }
                    if (mcors.Builder != Request.Form["Builder"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "建站者信息;";
                    }
                    if (mcors.SoilType != Request.Form["SoilType"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "地类土质;";
                    }
                    if (mcors.PermafrostDepth != Request.Form["PermafrostDepth"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "冻土深度;";
                    }
                    if (mcors.ThawDepth != Request.Form["ThawDepth"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "解冻深度;";
                    }
                    if (mcors.BelongsMap != Request.Form["BelongsMap"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "所在图幅;";
                    }
                    if (mcors.GroundwaterDepth != Request.Form["GroundwaterDepth"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "地下水深度;";
                    }
                    if (mcors.GeologicalStructure != Request.Form["GeologicalStructure"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "基础岩性和地质构造说明;";
                    }
                    if (mcors.MaintenanceUnit != Request.Form["MaintenanceUnit"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "维护单位;";
                    }
                    if (mcors.ContactPerson != Request.Form["ContactPerson"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "维护人;";
                    }
                    if (mcors.ContactTel != Request.Form["ContactTel"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "联系电话;";
                    }
                    if (mcors.EnvironmentalDescription != Request.Form["EnvironmentalDescription"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "环境说明;";
                    }
                    if (mcors.SiteConditions != Request.Form["SiteConditions"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "站点条件信息;";
                    }

                    #endregion

                    mcors.StationName = Request.Form["StationName"].ToString().Trim();
                    mcors.StationOName = Request.Form["StationOName"].ToString().Trim();
                    if (Request.Form["IsOK"].ToString() == "正常")
                    { mcors.IsOK = 1; }
                    else
                    { mcors.IsOK = 0; }
                    mcors.TransferType = Request.Form["TransferType"].ToString().Trim();
                    mcors.IP = Request.Form["IP"].ToString().Trim();
                    mcors.Port = Request.Form["Port"].ToString().Trim();
                    mcors.Lat = double.Parse(Request.Form["Lat"].ToString().Trim());
                    mcors.Lon = double.Parse(Request.Form["Lon"].ToString().Trim());
                    mcors.H = double.Parse(Request.Form["H"].ToString().Trim());
                    mcors.StationType = Request.Form["StationType"].ToString().Trim();
                    mcors.CaseNumber = Request.Form["CaseNumber"].ToString().Trim();
                    mcors.BuildTime = DateTime.Parse(Request.Form["BuildTime"].ToString().Trim());
                    mcors.AffiliatedNetwork = Request.Form["AffiliatedNetwork"].ToString().Trim();
                    mcors.PiersType = Request.Form["PiersType"].ToString().Trim();
                    mcors.RelyUnits = Request.Form["RelyUnits"].ToString().Trim();
                    mcors.Address = Request.Form["Address"].ToString().Trim();
                    mcors.ThicknessOfLayer = Request.Form["ThicknessOfLayer"].ToString().Trim();
                    mcors.TrafficCondition = Request.Form["TrafficCondition"].ToString().Trim();
                    mcors.SitePerson = Request.Form["SitePerson"].ToString().Trim();
                    mcors.Builder = Request.Form["Builder"].ToString().Trim();
                    mcors.SoilType = Request.Form["SoilType"].ToString().Trim();
                    mcors.PermafrostDepth = Request.Form["PermafrostDepth"].ToString().Trim();
                    mcors.ThawDepth = Request.Form["ThawDepth"].ToString().Trim();
                    mcors.GroundwaterDepth = Request.Form["GroundwaterDepth"].ToString().Trim();
                    mcors.BelongsMap = Request.Form["BelongsMap"].ToString().Trim();
                    mcors.GeologicalStructure = Request.Form["GeologicalStructure"].ToString().Trim();
                    mcors.MaintenanceUnit = Request.Form["MaintenanceUnit"].ToString().Trim();
                    mcors.ContactPerson = Request.Form["ContactPerson"].ToString().Trim();
                    mcors.ContactTel = Request.Form["ContactTel"].ToString().Trim();
                    if (Request.Form["StationPlan"].ToString().Trim().Contains("PLAN"))
                    {
                        mcors.StationPlan = Request.Form["StationPlan"].ToString().Trim();
                    }
                    if (Request.Form["RingView"].ToString().Trim().Contains("RINGVIEW"))
                    {
                        mcors.RingView = Request.Form["RingView"].ToString().Trim();
                    }
                    if (Request.Form["GravityPier"].ToString().Trim().Contains("GravityPier"))
                    {
                        mcors.GravityPier = Request.Form["GravityPier"].ToString().Trim();
                    }
                    if (Request.Form["LevelSign"].ToString().Trim().Contains("LevelSign"))
                    {
                        mcors.LevelSign = Request.Form["LevelSign"].ToString().Trim();
                    }
                    if (Request.Form["LightningReport"].ToString().Trim().Contains("LightningReport"))
                    {
                        mcors.LightningReport = Request.Form["LightningReport"].ToString().Trim();
                    }
                    if (Request.Form["StationPhoto"].ToString().Trim().Contains("StationPhoto"))
                    {
                        mcors.StationPhoto = Request.Form["StationPhoto"].ToString().Trim();
                    }
                    mcors.SiteConditions = Request.Form["SiteConditions"].ToString().Trim();
                    mcors.EnvironmentalDescription = Request.Form["EnvironmentalDescription"].ToString().Trim();
                    bool res = DAL.CORSStationInfo.Update(mcors, 1);
                    me.StationName = mcors.StationName;
                    me.StationOName = mcors.StationOName;
                    me.IP = mcors.IP;
                    me.Port = mcors.Port;
                    DAL.EquipmentInfo.Update(me);
                    ms.StationOName = me.StationOName;
                    bool r = DAL.SiteMonitoring.Update(ms);
                    if (res)
                    {
                        if (IsRevice)
                        {
                            MERR.ReviceID = mcors.ID.ToString();
                            MERR.RevicePerson = Session["UserName"].ToString();
                            MERR.ReviceTime = DateTime.Now;
                            MERR.Information = "基站信息";
                            DAL.EquipReviceRecord.Add(MERR);
                        }
                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
            }
        }
    }
}