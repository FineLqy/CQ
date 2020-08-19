using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    /// <summary>
    /// CORS基站信息 数据库操作类
    /// </summary>
    public class CORSStationInfo
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;


        /// <summary>
        /// 是否存在该基站名
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(string StationName)
        {
            string strSql = "select count(*) from CORSStationInfo where StationName='" + StationName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 是否存在该IP
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool ExistIP(string IP,string Port)
        {
            string strSql = "select count(*) from CORSStationInfo where IP='" + IP + "' and Port='" + Port.ToString() + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 增加一条基站信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.CORSStationInfo model)
        {
            string strSql = "insert into CORSStationInfo(StationName,StationOName, IP, Port, Lat, Lon,H, IsOK,TransferType,ReceiverType,ReceiverSN,AntennaType,AntennaSN,StationFigure,StationType,SpecialTelLine,ContactPerson,ContactTel,FaultLog,TrusteeFeeLog,OperatingState,Condition,MovingStationLog,AntennaRepLog, Remark,BuildTime,CaseNumber,AffiliatedNetwork,PiersType,RelyUnits,Address,ThicknessOfLayer,TrafficCondition,SitePerson,Builder,SoilType,PermafrostDepth,ThawDepth,GroundwaterDepth,BelongsMap,GeologicalStructure,StationPlan,RingView,EnvironmentalDescription,MaintenanceUnit,SiteConditions, GravityPier, LevelSign, LightningReport, StationPhoto ) values(@StationName,@StationOName, @IP, @Port, @Lat, @Lon,@H, @IsOK,@TransferType, @ReceiverType, @ReceiverSN, @AntennaType, @AntennaSN, @StationFigure, @StationType, @SpecialTelLine, @ContactPerson, @ContactTel, @FaultLog, @TrusteeFeeLog, @OperatingState, @Condition, @MovingStationLog, @AntennaRepLog, @Remark,@BuildTime,@CaseNumber,@AffiliatedNetwork,@PiersType,@RelyUnits,@Address,@ThicknessOfLayer,@TrafficCondition,@SitePerson,@Builder,@SoilType,@PermafrostDepth,@ThawDepth,@GroundwaterDepth,@BelongsMap,@GeologicalStructure,@StationPlan,@RingView,@EnvironmentalDescription,@MaintenanceUnit,@SiteConditions,@GravityPier, @LevelSign, @LightningReport, @StationPhoto )";

            SqlParameter StationName = new SqlParameter("StationName", SqlDbType.NVarChar); StationName.Value = model.StationName;
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter Lat = new SqlParameter("Lat", SqlDbType.Float); Lat.Value = model.Lat;
            SqlParameter Lon = new SqlParameter("Lon", SqlDbType.Float); Lon.Value = model.Lon;
            SqlParameter H = new SqlParameter("H", SqlDbType.Float); H.Value = model.H;
            SqlParameter IsOK = new SqlParameter("IsOK", SqlDbType.Int); IsOK.Value = model.IsOK;
            SqlParameter TransferType = new SqlParameter("TransferType", SqlDbType.NVarChar); TransferType.Value = model.TransferType;
            SqlParameter ReceiverType = new SqlParameter("ReceiverType", SqlDbType.NVarChar); ReceiverType.Value = model.ReceiverType.ToString();
            SqlParameter ReceiverSN = new SqlParameter("ReceiverSN", SqlDbType.NVarChar); ReceiverSN.Value = model.ReceiverSN.ToString();
            SqlParameter AntennaType = new SqlParameter("AntennaType", SqlDbType.NVarChar); AntennaType.Value = model.AntennaType.ToString();
            SqlParameter AntennaSN = new SqlParameter("AntennaSN", SqlDbType.NVarChar); AntennaSN.Value = model.AntennaSN.ToString();
            SqlParameter StationFigure = new SqlParameter("StationFigure", SqlDbType.NVarChar); StationFigure.Value = model.StationFigure.ToString();
            SqlParameter StationType = new SqlParameter("StationType", SqlDbType.NVarChar); StationType.Value = model.StationType.ToString();
            SqlParameter SpecialTelLine = new SqlParameter("SpecialTelLine", SqlDbType.NVarChar); SpecialTelLine.Value = model.SpecialTelLine.ToString();
            SqlParameter ContactPerson = new SqlParameter("ContactPerson", SqlDbType.NVarChar); ContactPerson.Value = model.ContactPerson.ToString();
            SqlParameter ContactTel = new SqlParameter("ContactTel", SqlDbType.NVarChar); ContactTel.Value = model.ContactTel.ToString();
            SqlParameter FaultLog = new SqlParameter("FaultLog", SqlDbType.NVarChar); FaultLog.Value = model.FaultLog.ToString();
            SqlParameter TrusteeFeeLog = new SqlParameter("TrusteeFeeLog", SqlDbType.NVarChar); TrusteeFeeLog.Value = model.TrusteeFeeLog.ToString();
            SqlParameter OperatingState = new SqlParameter("OperatingState", SqlDbType.NVarChar); OperatingState.Value = model.OperatingState.ToString();
            SqlParameter Condition = new SqlParameter("Condition", SqlDbType.NVarChar); Condition.Value = model.Condition.ToString();
            SqlParameter MovingStationLog = new SqlParameter("MovingStationLog", SqlDbType.NVarChar); MovingStationLog.Value = model.MovingStationLog.ToString();
            SqlParameter AntennaRepLog = new SqlParameter("AntennaRepLog", SqlDbType.NVarChar); AntennaRepLog.Value = model.AntennaRepLog.ToString();
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark.ToString();
            SqlParameter BuildTime = new SqlParameter("BuildTime", SqlDbType.DateTime); BuildTime.Value = model.BuildTime.ToString();
            SqlParameter CaseNumber = new SqlParameter("CaseNumber", SqlDbType.NVarChar); CaseNumber.Value = model.CaseNumber.ToString();
            SqlParameter AffiliatedNetwork = new SqlParameter("AffiliatedNetwork", SqlDbType.NVarChar); AffiliatedNetwork.Value = model.AffiliatedNetwork.ToString();
            SqlParameter PiersType = new SqlParameter("PiersType", SqlDbType.NVarChar); PiersType.Value = model.PiersType.ToString();
            SqlParameter RelyUnits = new SqlParameter("RelyUnits", SqlDbType.NVarChar); RelyUnits.Value = model.RelyUnits.ToString();
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address.ToString();
            SqlParameter ThicknessOfLayer = new SqlParameter("ThicknessOfLayer", SqlDbType.NVarChar); ThicknessOfLayer.Value = model.ThicknessOfLayer.ToString();
            SqlParameter TrafficCondition = new SqlParameter("TrafficCondition", SqlDbType.NVarChar); TrafficCondition.Value = model.TrafficCondition.ToString();
            SqlParameter SitePerson = new SqlParameter("SitePerson", SqlDbType.NVarChar); SitePerson.Value = model.SitePerson.ToString();
            SqlParameter Builder = new SqlParameter("Builder", SqlDbType.NVarChar); Builder.Value = model.Builder.ToString();
            SqlParameter SoilType = new SqlParameter("SoilType", SqlDbType.NVarChar); SoilType.Value = model.SoilType.ToString();
            SqlParameter PermafrostDepth = new SqlParameter("PermafrostDepth", SqlDbType.NVarChar); PermafrostDepth.Value = model.PermafrostDepth.ToString();
            SqlParameter ThawDepth = new SqlParameter("ThawDepth", SqlDbType.NVarChar); ThawDepth.Value = model.ThawDepth.ToString();
            SqlParameter GroundwaterDepth = new SqlParameter("GroundwaterDepth", SqlDbType.NVarChar); GroundwaterDepth.Value = model.GroundwaterDepth.ToString();
            SqlParameter BelongsMap = new SqlParameter("BelongsMap", SqlDbType.NVarChar); BelongsMap.Value = model.BelongsMap.ToString();
            SqlParameter GeologicalStructure = new SqlParameter("GeologicalStructure", SqlDbType.NVarChar); GeologicalStructure.Value = model.GeologicalStructure.ToString();
            SqlParameter StationPlan = new SqlParameter("StationPlan", SqlDbType.NVarChar); StationPlan.Value = model.StationPlan.ToString();
            SqlParameter RingView = new SqlParameter("RingView", SqlDbType.NVarChar); RingView.Value = model.RingView.ToString();
            SqlParameter EnvironmentalDescription = new SqlParameter("EnvironmentalDescription", SqlDbType.NVarChar); EnvironmentalDescription.Value = model.EnvironmentalDescription.ToString();
            SqlParameter MaintenanceUnit = new SqlParameter("MaintenanceUnit", SqlDbType.NVarChar); MaintenanceUnit.Value = model.MaintenanceUnit.ToString();
            SqlParameter SiteConditions = new SqlParameter("SiteConditions", SqlDbType.NVarChar); SiteConditions.Value = model.SiteConditions.ToString();
            SqlParameter GravityPier = new SqlParameter("GravityPier", SqlDbType.NVarChar); GravityPier.Value = model.GravityPier.ToString();
            SqlParameter LevelSign = new SqlParameter("LevelSign", SqlDbType.NVarChar); LevelSign.Value = model.LevelSign.ToString();
            SqlParameter LightningReport = new SqlParameter("LightningReport", SqlDbType.NVarChar); LightningReport.Value = model.LightningReport.ToString();
            SqlParameter StationPhoto = new SqlParameter("StationPhoto", SqlDbType.NVarChar); StationPhoto.Value = model.StationPhoto.ToString();

    
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationName, StationOName, IP, Port, Lat, Lon, H, IsOK, TransferType, ReceiverType, ReceiverSN, AntennaType, AntennaSN, StationFigure, StationType, SpecialTelLine, ContactPerson, ContactTel, FaultLog, TrusteeFeeLog, OperatingState, Condition, MovingStationLog, AntennaRepLog, Remark, BuildTime, CaseNumber, AffiliatedNetwork, PiersType, RelyUnits, Address, ThicknessOfLayer, TrafficCondition, SitePerson, Builder, SoilType, PermafrostDepth, ThawDepth, GroundwaterDepth, BelongsMap, GeologicalStructure, StationPlan, RingView, EnvironmentalDescription, MaintenanceUnit, SiteConditions, GravityPier, LevelSign, LightningReport, StationPhoto }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.CORSStationInfo model)
        {
            string strSql = "update CORSStationInfo set StationName=@StationName, StationOName=@StationOName, IP=@IP, Port=@Port, Lat=@Lat, Lon=@Lon, H=@H, IsOK=@IsOK, TransferType=@TransferType, ReceiverType=@ReceiverType, ReceiverSN=@ReceiverSN, AntennaType=@AntennaType, AntennaSN=@AntennaSN, StationFigure=@StationFigure, StationType=@StationType, SpecialTelLine=@SpecialTelLine, ContactPerson=@ContactPerson, ContactTel=@ContactTel, FaultLog=@FaultLog, TrusteeFeeLog=@TrusteeFeeLog, OperatingState=@OperatingState, Condition=@Condition, MovingStationLog=@MovingStationLog, AntennaRepLog=@AntennaRepLog, Remark=@Remark,BuildTime=@BuildTime,CaseNumber=@CaseNumber,AffiliatedNetwork=@AffiliatedNetwork,PiersType=@PiersType,RelyUnits=@RelyUnits,Address=@Address,ThicknessOfLayer=@ThicknessOfLayer,TrafficCondition=@TrafficCondition,SitePerson=@SitePerson,Builder=@Builder,SoilType=@SoilType,PermafrostDepth=@PermafrostDepth,ThawDepth=@ThawDepth,GroundwaterDepth=@GroundwaterDepth,BelongsMap=@BelongsMap,GeologicalStructure=@GeologicalStructure,StationPlan=@StationPlan,RingView=@RingView,EnvironmentalDescription=@EnvironmentalDescription,MaintenanceUnit=@MaintenanceUnit,SiteConditions=@SiteConditions, GravityPier=@GravityPier, LevelSign=@LevelSign, LightningReport=@LightningReport, StationPhoto=@StationPhoto where StationName = '" + model.StationName + "'";
            SqlParameter StationName = new SqlParameter("StationName", SqlDbType.NVarChar); StationName.Value = model.StationName;
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter Lat = new SqlParameter("Lat", SqlDbType.Float); Lat.Value = model.Lat;
            SqlParameter Lon = new SqlParameter("Lon", SqlDbType.Float); Lon.Value = model.Lon;
            SqlParameter H = new SqlParameter("H", SqlDbType.Float); H.Value = model.H;
            SqlParameter IsOK = new SqlParameter("IsOK", SqlDbType.Int); IsOK.Value = model.IsOK;
            SqlParameter TransferType = new SqlParameter("TransferType", SqlDbType.NVarChar); TransferType.Value = model.TransferType;
            SqlParameter ReceiverType = new SqlParameter("ReceiverType", SqlDbType.NVarChar); ReceiverType.Value = model.ReceiverType;
            SqlParameter ReceiverSN = new SqlParameter("ReceiverSN", SqlDbType.NVarChar); ReceiverSN.Value = model.ReceiverSN;
            SqlParameter AntennaType = new SqlParameter("AntennaType", SqlDbType.NVarChar); AntennaType.Value = model.AntennaType;
            SqlParameter AntennaSN = new SqlParameter("AntennaSN", SqlDbType.NVarChar); AntennaSN.Value = model.AntennaSN;
            SqlParameter StationFigure = new SqlParameter("StationFigure", SqlDbType.NVarChar); StationFigure.Value = model.StationFigure;
            SqlParameter StationType = new SqlParameter("StationType", SqlDbType.NVarChar); StationType.Value = model.StationType;
            SqlParameter SpecialTelLine = new SqlParameter("SpecialTelLine", SqlDbType.NVarChar); SpecialTelLine.Value = model.SpecialTelLine;
            SqlParameter ContactPerson = new SqlParameter("ContactPerson", SqlDbType.NVarChar); ContactPerson.Value = model.ContactPerson;
            SqlParameter ContactTel = new SqlParameter("ContactTel", SqlDbType.NVarChar); ContactTel.Value = model.ContactTel;
            SqlParameter FaultLog = new SqlParameter("FaultLog", SqlDbType.NVarChar); FaultLog.Value = model.FaultLog;
            SqlParameter TrusteeFeeLog = new SqlParameter("TrusteeFeeLog", SqlDbType.NVarChar); TrusteeFeeLog.Value = model.TrusteeFeeLog;
            SqlParameter OperatingState = new SqlParameter("OperatingState", SqlDbType.NVarChar); OperatingState.Value = model.OperatingState;
            SqlParameter Condition = new SqlParameter("Condition", SqlDbType.NVarChar); Condition.Value = model.Condition;
            SqlParameter MovingStationLog = new SqlParameter("MovingStationLog", SqlDbType.NVarChar); MovingStationLog.Value = model.MovingStationLog;
            SqlParameter AntennaRepLog = new SqlParameter("AntennaRepLog", SqlDbType.NVarChar); AntennaRepLog.Value = model.AntennaRepLog;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter BuildTime = new SqlParameter("BuildTime", SqlDbType.DateTime); BuildTime.Value = model.BuildTime.ToString();
            SqlParameter CaseNumber = new SqlParameter("CaseNumber", SqlDbType.NVarChar); CaseNumber.Value = model.CaseNumber.ToString();
            SqlParameter AffiliatedNetwork = new SqlParameter("AffiliatedNetwork", SqlDbType.NVarChar); AffiliatedNetwork.Value = model.AffiliatedNetwork.ToString();
            SqlParameter PiersType = new SqlParameter("PiersType", SqlDbType.NVarChar); PiersType.Value = model.PiersType.ToString();
            SqlParameter RelyUnits = new SqlParameter("RelyUnits", SqlDbType.NVarChar); RelyUnits.Value = model.RelyUnits.ToString();
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address.ToString();
            SqlParameter ThicknessOfLayer = new SqlParameter("ThicknessOfLayer", SqlDbType.NVarChar); ThicknessOfLayer.Value = model.ThicknessOfLayer.ToString();
            SqlParameter TrafficCondition = new SqlParameter("TrafficCondition", SqlDbType.NVarChar); TrafficCondition.Value = model.TrafficCondition.ToString();
            SqlParameter SitePerson = new SqlParameter("SitePerson", SqlDbType.NVarChar); SitePerson.Value = model.SitePerson.ToString();
            SqlParameter Builder = new SqlParameter("Builder", SqlDbType.NVarChar); Builder.Value = model.Builder.ToString();
            SqlParameter SoilType = new SqlParameter("SoilType", SqlDbType.NVarChar); SoilType.Value = model.SoilType.ToString();
            SqlParameter PermafrostDepth = new SqlParameter("PermafrostDepth", SqlDbType.NVarChar); PermafrostDepth.Value = model.PermafrostDepth.ToString();
            SqlParameter ThawDepth = new SqlParameter("ThawDepth", SqlDbType.NVarChar); ThawDepth.Value = model.ThawDepth.ToString();
            SqlParameter GroundwaterDepth = new SqlParameter("GroundwaterDepth", SqlDbType.NVarChar); GroundwaterDepth.Value = model.GroundwaterDepth.ToString();
            SqlParameter BelongsMap = new SqlParameter("BelongsMap", SqlDbType.NVarChar); BelongsMap.Value = model.BelongsMap.ToString();
            SqlParameter GeologicalStructure = new SqlParameter("GeologicalStructure", SqlDbType.NVarChar); GeologicalStructure.Value = model.GeologicalStructure.ToString();
            SqlParameter StationPlan = new SqlParameter("StationPlan", SqlDbType.NVarChar); StationPlan.Value = model.StationPlan.ToString();
            SqlParameter RingView = new SqlParameter("RingView", SqlDbType.NVarChar); RingView.Value = model.RingView.ToString();
            SqlParameter EnvironmentalDescription = new SqlParameter("EnvironmentalDescription", SqlDbType.NVarChar); EnvironmentalDescription.Value = model.EnvironmentalDescription.ToString();
            SqlParameter MaintenanceUnit = new SqlParameter("MaintenanceUnit", SqlDbType.NVarChar); MaintenanceUnit.Value = model.MaintenanceUnit.ToString();
            SqlParameter SiteConditions = new SqlParameter("SiteConditions", SqlDbType.NVarChar); SiteConditions.Value = model.SiteConditions.ToString();


            SqlParameter GravityPier = new SqlParameter("GravityPier", SqlDbType.NVarChar); GravityPier.Value = model.GravityPier.ToString();
            SqlParameter LevelSign = new SqlParameter("LevelSign", SqlDbType.NVarChar); LevelSign.Value = model.LevelSign.ToString();
            SqlParameter LightningReport = new SqlParameter("LightningReport", SqlDbType.NVarChar); LightningReport.Value = model.LightningReport.ToString();
            SqlParameter StationPhoto = new SqlParameter("StationPhoto", SqlDbType.NVarChar); StationPhoto.Value = model.StationPhoto.ToString();


            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationName, StationOName, IP, Port, Lat, Lon, H, IsOK, TransferType, ReceiverType, ReceiverSN, AntennaType, AntennaSN, StationFigure, StationType, SpecialTelLine, ContactPerson, ContactTel, FaultLog, TrusteeFeeLog, OperatingState, Condition, MovingStationLog, AntennaRepLog, Remark, BuildTime, CaseNumber, AffiliatedNetwork, PiersType, RelyUnits, Address, ThicknessOfLayer, TrafficCondition, SitePerson, Builder, SoilType, PermafrostDepth, ThawDepth, GroundwaterDepth, BelongsMap, GeologicalStructure, StationPlan, RingView, EnvironmentalDescription, MaintenanceUnit, SiteConditions, GravityPier, LevelSign, LightningReport, StationPhoto }, connectionString) == 1 ? true : false;

        }
        /// <summary>
        /// 根据ID更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool Update(Model.CORSStationInfo model,int i=1)
        {
            string strSql = "update CORSStationInfo set StationName=@StationName, StationOName=@StationOName, IP=@IP, Port=@Port, Lat=@Lat, Lon=@Lon, H=@H, IsOK=@IsOK, TransferType=@TransferType, ReceiverType=@ReceiverType, ReceiverSN=@ReceiverSN, AntennaType=@AntennaType, AntennaSN=@AntennaSN, StationFigure=@StationFigure, StationType=@StationType, SpecialTelLine=@SpecialTelLine, ContactPerson=@ContactPerson, ContactTel=@ContactTel, FaultLog=@FaultLog, TrusteeFeeLog=@TrusteeFeeLog, OperatingState=@OperatingState, Condition=@Condition, MovingStationLog=@MovingStationLog, AntennaRepLog=@AntennaRepLog, Remark=@Remark,BuildTime=@BuildTime,CaseNumber=@CaseNumber,AffiliatedNetwork=@AffiliatedNetwork,PiersType=@PiersType,RelyUnits=@RelyUnits,Address=@Address,ThicknessOfLayer=@ThicknessOfLayer,TrafficCondition=@TrafficCondition,SitePerson=@SitePerson,Builder=@Builder,SoilType=@SoilType,PermafrostDepth=@PermafrostDepth,ThawDepth=@ThawDepth,GroundwaterDepth=@GroundwaterDepth,BelongsMap=@BelongsMap,GeologicalStructure=@GeologicalStructure,StationPlan=@StationPlan,RingView=@RingView,EnvironmentalDescription=@EnvironmentalDescription,MaintenanceUnit=@MaintenanceUnit,SiteConditions=@SiteConditions,GravityPier=@GravityPier, LevelSign=@LevelSign, LightningReport=@LightningReport, StationPhoto=@StationPhoto where ID = '" + model.ID.ToString() + "'";
            SqlParameter StationName = new SqlParameter("StationName", SqlDbType.NVarChar); StationName.Value = model.StationName;
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter Lat = new SqlParameter("Lat", SqlDbType.Float); Lat.Value = model.Lat;
            SqlParameter Lon = new SqlParameter("Lon", SqlDbType.Float); Lon.Value = model.Lon;
            SqlParameter H = new SqlParameter("H", SqlDbType.Float); H.Value = model.H;
            SqlParameter IsOK = new SqlParameter("IsOK", SqlDbType.Int); IsOK.Value = model.IsOK;
            SqlParameter TransferType = new SqlParameter("TransferType", SqlDbType.NVarChar); TransferType.Value = model.TransferType;
            SqlParameter ReceiverType = new SqlParameter("ReceiverType", SqlDbType.NVarChar); ReceiverType.Value = model.ReceiverType;
            SqlParameter ReceiverSN = new SqlParameter("ReceiverSN", SqlDbType.NVarChar); ReceiverSN.Value = model.ReceiverSN;
            SqlParameter AntennaType = new SqlParameter("AntennaType", SqlDbType.NVarChar); AntennaType.Value = model.AntennaType;
            SqlParameter AntennaSN = new SqlParameter("AntennaSN", SqlDbType.NVarChar); AntennaSN.Value = model.AntennaSN;
            SqlParameter StationFigure = new SqlParameter("StationFigure", SqlDbType.NVarChar); StationFigure.Value = model.StationFigure;
            SqlParameter StationType = new SqlParameter("StationType", SqlDbType.NVarChar); StationType.Value = model.StationType;
            SqlParameter SpecialTelLine = new SqlParameter("SpecialTelLine", SqlDbType.NVarChar); SpecialTelLine.Value = model.SpecialTelLine;
            SqlParameter ContactPerson = new SqlParameter("ContactPerson", SqlDbType.NVarChar); ContactPerson.Value = model.ContactPerson;
            SqlParameter ContactTel = new SqlParameter("ContactTel", SqlDbType.NVarChar); ContactTel.Value = model.ContactTel;
            SqlParameter FaultLog = new SqlParameter("FaultLog", SqlDbType.NVarChar); FaultLog.Value = model.FaultLog;
            SqlParameter TrusteeFeeLog = new SqlParameter("TrusteeFeeLog", SqlDbType.NVarChar); TrusteeFeeLog.Value = model.TrusteeFeeLog;
            SqlParameter OperatingState = new SqlParameter("OperatingState", SqlDbType.NVarChar); OperatingState.Value = model.OperatingState;
            SqlParameter Condition = new SqlParameter("Condition", SqlDbType.NVarChar); Condition.Value = model.Condition;
            SqlParameter MovingStationLog = new SqlParameter("MovingStationLog", SqlDbType.NVarChar); MovingStationLog.Value = model.MovingStationLog;
            SqlParameter AntennaRepLog = new SqlParameter("AntennaRepLog", SqlDbType.NVarChar); AntennaRepLog.Value = model.AntennaRepLog;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter BuildTime = new SqlParameter("BuildTime", SqlDbType.DateTime); BuildTime.Value = model.BuildTime.ToString();
            SqlParameter CaseNumber = new SqlParameter("CaseNumber", SqlDbType.NVarChar); CaseNumber.Value = model.CaseNumber.ToString();
            SqlParameter AffiliatedNetwork = new SqlParameter("AffiliatedNetwork", SqlDbType.NVarChar); AffiliatedNetwork.Value = model.AffiliatedNetwork.ToString();
            SqlParameter PiersType = new SqlParameter("PiersType", SqlDbType.NVarChar); PiersType.Value = model.PiersType.ToString();
            SqlParameter RelyUnits = new SqlParameter("RelyUnits", SqlDbType.NVarChar); RelyUnits.Value = model.RelyUnits.ToString();
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address.ToString();
            SqlParameter ThicknessOfLayer = new SqlParameter("ThicknessOfLayer", SqlDbType.NVarChar); ThicknessOfLayer.Value = model.ThicknessOfLayer.ToString();
            SqlParameter TrafficCondition = new SqlParameter("TrafficCondition", SqlDbType.NVarChar); TrafficCondition.Value = model.TrafficCondition.ToString();
            SqlParameter SitePerson = new SqlParameter("SitePerson", SqlDbType.NVarChar); SitePerson.Value = model.SitePerson.ToString();
            SqlParameter Builder = new SqlParameter("Builder", SqlDbType.NVarChar); Builder.Value = model.Builder.ToString();
            SqlParameter SoilType = new SqlParameter("SoilType", SqlDbType.NVarChar); SoilType.Value = model.SoilType.ToString();
            SqlParameter PermafrostDepth = new SqlParameter("PermafrostDepth", SqlDbType.NVarChar); PermafrostDepth.Value = model.PermafrostDepth.ToString();
            SqlParameter ThawDepth = new SqlParameter("ThawDepth", SqlDbType.NVarChar); ThawDepth.Value = model.ThawDepth.ToString();
            SqlParameter GroundwaterDepth = new SqlParameter("GroundwaterDepth", SqlDbType.NVarChar); GroundwaterDepth.Value = model.GroundwaterDepth.ToString();
            SqlParameter BelongsMap = new SqlParameter("BelongsMap", SqlDbType.NVarChar); BelongsMap.Value = model.BelongsMap.ToString();
            SqlParameter GeologicalStructure = new SqlParameter("GeologicalStructure", SqlDbType.NVarChar); GeologicalStructure.Value = model.GeologicalStructure.ToString();
            SqlParameter StationPlan = new SqlParameter("StationPlan", SqlDbType.NVarChar); StationPlan.Value = model.StationPlan.ToString();
            SqlParameter RingView = new SqlParameter("RingView", SqlDbType.NVarChar); RingView.Value = model.RingView.ToString();
            SqlParameter EnvironmentalDescription = new SqlParameter("EnvironmentalDescription", SqlDbType.NVarChar); EnvironmentalDescription.Value = model.EnvironmentalDescription.ToString();
            SqlParameter MaintenanceUnit = new SqlParameter("MaintenanceUnit", SqlDbType.NVarChar); MaintenanceUnit.Value = model.MaintenanceUnit.ToString();
            SqlParameter SiteConditions = new SqlParameter("SiteConditions", SqlDbType.NVarChar); SiteConditions.Value = model.SiteConditions.ToString();


            SqlParameter GravityPier = new SqlParameter("GravityPier", SqlDbType.NVarChar); GravityPier.Value = model.GravityPier.ToString();
            SqlParameter LevelSign = new SqlParameter("LevelSign", SqlDbType.NVarChar); LevelSign.Value = model.LevelSign.ToString();
            SqlParameter LightningReport = new SqlParameter("LightningReport", SqlDbType.NVarChar); LightningReport.Value = model.LightningReport.ToString();
            SqlParameter StationPhoto = new SqlParameter("StationPhoto", SqlDbType.NVarChar); StationPhoto.Value = model.StationPhoto.ToString();


            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationName, StationOName, IP, Port, Lat, Lon, H, IsOK, TransferType, ReceiverType, ReceiverSN, AntennaType, AntennaSN, StationFigure, StationType, SpecialTelLine, ContactPerson, ContactTel, FaultLog, TrusteeFeeLog, OperatingState, Condition, MovingStationLog, AntennaRepLog, Remark, BuildTime, CaseNumber, AffiliatedNetwork, PiersType, RelyUnits, Address, ThicknessOfLayer, TrafficCondition, SitePerson, Builder, SoilType, PermafrostDepth, ThawDepth, GroundwaterDepth, BelongsMap, GeologicalStructure, StationPlan, RingView, EnvironmentalDescription, MaintenanceUnit, SiteConditions, GravityPier, LevelSign, LightningReport, StationPhoto }, connectionString) == 1 ? true : false;

        }
        /// <summary>
        /// 删除一条数据（根据StationName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string StationName)
        {
            string strSql = "delete from CORSStationInfo where StationName ='" + StationName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.CORSStationInfo GetModel(string StationName)
        {
            string strSql = "select * from CORSStationInfo where StationName = '" + StationName+"'";
            Model.CORSStationInfo model = new Model.CORSStationInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.StationName = StationName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.StationOName = Convert.ToString(ds.Tables[0].Rows[0]["StationOName"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                try
                {
                    model.Lon = Convert.ToDouble(ds.Tables[0].Rows[0]["Lon"]);
                }
                catch
                {
                    model.Lon = 0;
                }
                try
                {
                    model.Lat = Convert.ToDouble(ds.Tables[0].Rows[0]["Lat"]);
                }
                catch
                {
                    model.Lat = 0;
                }
                try
                {
                    model.H = Convert.ToDouble(ds.Tables[0].Rows[0]["H"]);
                }
                catch
                {
                    model.H = 0;
                }

                try
                {
                    model.IsOK = Convert.ToInt32(ds.Tables[0].Rows[0]["IsOK"]);
                }
                catch
                {
                    model.IsOK = 0;
                }
                model.TransferType = Convert.ToString(ds.Tables[0].Rows[0]["TransferType"]);
                model.ReceiverType = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverType"]);
                model.ReceiverSN = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverSN"]);
                model.AntennaType = Convert.ToString(ds.Tables[0].Rows[0]["AntennaType"]);
                model.AntennaSN = Convert.ToString(ds.Tables[0].Rows[0]["AntennaSN"]);
                model.StationFigure = Convert.ToString(ds.Tables[0].Rows[0]["StationFigure"]);
                model.StationType = Convert.ToString(ds.Tables[0].Rows[0]["StationType"]);
                model.SpecialTelLine = Convert.ToString(ds.Tables[0].Rows[0]["SpecialTelLine"]);
                model.ContactPerson = Convert.ToString(ds.Tables[0].Rows[0]["ContactPerson"]);
                model.ContactTel = Convert.ToString(ds.Tables[0].Rows[0]["ContactTel"]);
                model.FaultLog = Convert.ToString(ds.Tables[0].Rows[0]["FaultLog"]);
                model.TrusteeFeeLog = Convert.ToString(ds.Tables[0].Rows[0]["TrusteeFeeLog"]);
                model.OperatingState = Convert.ToString(ds.Tables[0].Rows[0]["OperatingState"]);
                model.Condition = Convert.ToString(ds.Tables[0].Rows[0]["Condition"]);
                model.MovingStationLog = Convert.ToString(ds.Tables[0].Rows[0]["MovingStationLog"]);
                model.AntennaRepLog = Convert.ToString(ds.Tables[0].Rows[0]["AntennaRepLog"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.BuildTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BuildTime"]);
                model.CaseNumber = Convert.ToString(ds.Tables[0].Rows[0]["CaseNumber"]);
                model.AffiliatedNetwork = Convert.ToString(ds.Tables[0].Rows[0]["AffiliatedNetwork"]);
                model.PiersType = Convert.ToString(ds.Tables[0].Rows[0]["PiersType"]);
                model.RelyUnits = Convert.ToString(ds.Tables[0].Rows[0]["RelyUnits"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.ThicknessOfLayer = Convert.ToString(ds.Tables[0].Rows[0]["ThicknessOfLayer"]);
                model.TrafficCondition = Convert.ToString(ds.Tables[0].Rows[0]["TrafficCondition"]);
                model.SitePerson = Convert.ToString(ds.Tables[0].Rows[0]["SitePerson"]);
                model.Builder = Convert.ToString(ds.Tables[0].Rows[0]["Builder"]);
                model.SoilType = Convert.ToString(ds.Tables[0].Rows[0]["SoilType"]);
                model.PermafrostDepth = Convert.ToString(ds.Tables[0].Rows[0]["PermafrostDepth"]);
                model.ThawDepth = Convert.ToString(ds.Tables[0].Rows[0]["ThawDepth"]);
                model.GroundwaterDepth = Convert.ToString(ds.Tables[0].Rows[0]["GroundwaterDepth"]);
                model.BelongsMap = Convert.ToString(ds.Tables[0].Rows[0]["BelongsMap"]);
                model.GeologicalStructure = Convert.ToString(ds.Tables[0].Rows[0]["GeologicalStructure"]);
                model.StationPlan = Convert.ToString(ds.Tables[0].Rows[0]["StationPlan"]);
                model.RingView = Convert.ToString(ds.Tables[0].Rows[0]["RingView"]);
                model.EnvironmentalDescription = Convert.ToString(ds.Tables[0].Rows[0]["EnvironmentalDescription"]);
                model.MaintenanceUnit = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceUnit"]);
                model.SiteConditions = Convert.ToString(ds.Tables[0].Rows[0]["SiteConditions"]);
                model.GravityPier = Convert.ToString(ds.Tables[0].Rows[0]["GravityPier"]);
                model.LevelSign = Convert.ToString(ds.Tables[0].Rows[0]["LevelSign"]);
                model.LightningReport = Convert.ToString(ds.Tables[0].Rows[0]["LightningReport"]);
                model.StationPhoto = Convert.ToString(ds.Tables[0].Rows[0]["StationPhoto"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.CORSStationInfo GetModel(int id)
        {
            string strSql = "select * from CORSStationInfo where ID = '" + id + "'";
            Model.CORSStationInfo model = new Model.CORSStationInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.StationName = Convert.ToString(ds.Tables[0].Rows[0]["StationName"]);
                model.StationOName = Convert.ToString(ds.Tables[0].Rows[0]["StationOName"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                try
                {
                    model.Lon = Convert.ToDouble(ds.Tables[0].Rows[0]["Lon"]);
                }
                catch
                {
                    model.Lon = 0;
                }
                try
                {
                    model.Lat = Convert.ToDouble(ds.Tables[0].Rows[0]["Lat"]);
                }
                catch
                {
                    model.Lat = 0;
                }
                try
                {
                    model.H = Convert.ToDouble(ds.Tables[0].Rows[0]["H"]);
                }
                catch
                {
                    model.H = 0;
                }

                try
                {
                    model.IsOK = Convert.ToInt32(ds.Tables[0].Rows[0]["IsOK"]);
                }
                catch
                {
                    model.IsOK = 0;
                }
                model.TransferType = Convert.ToString(ds.Tables[0].Rows[0]["TransferType"]);
                model.ReceiverType = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverType"]);
                model.ReceiverSN = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverSN"]);
                model.AntennaType = Convert.ToString(ds.Tables[0].Rows[0]["AntennaType"]);
                model.AntennaSN = Convert.ToString(ds.Tables[0].Rows[0]["AntennaSN"]);
                model.StationFigure = Convert.ToString(ds.Tables[0].Rows[0]["StationFigure"]);
                model.StationType = Convert.ToString(ds.Tables[0].Rows[0]["StationType"]);
                model.SpecialTelLine = Convert.ToString(ds.Tables[0].Rows[0]["SpecialTelLine"]);
                model.ContactPerson = Convert.ToString(ds.Tables[0].Rows[0]["ContactPerson"]);
                model.ContactTel = Convert.ToString(ds.Tables[0].Rows[0]["ContactTel"]);
                model.FaultLog = Convert.ToString(ds.Tables[0].Rows[0]["FaultLog"]);
                model.TrusteeFeeLog = Convert.ToString(ds.Tables[0].Rows[0]["TrusteeFeeLog"]);
                model.OperatingState = Convert.ToString(ds.Tables[0].Rows[0]["OperatingState"]);
                model.Condition = Convert.ToString(ds.Tables[0].Rows[0]["Condition"]);
                model.MovingStationLog = Convert.ToString(ds.Tables[0].Rows[0]["MovingStationLog"]);
                model.AntennaRepLog = Convert.ToString(ds.Tables[0].Rows[0]["AntennaRepLog"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.BuildTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BuildTime"]);
                model.CaseNumber = Convert.ToString(ds.Tables[0].Rows[0]["CaseNumber"]);
                model.AffiliatedNetwork = Convert.ToString(ds.Tables[0].Rows[0]["AffiliatedNetwork"]);
                model.PiersType = Convert.ToString(ds.Tables[0].Rows[0]["PiersType"]);
                model.RelyUnits = Convert.ToString(ds.Tables[0].Rows[0]["RelyUnits"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.ThicknessOfLayer = Convert.ToString(ds.Tables[0].Rows[0]["ThicknessOfLayer"]);
                model.TrafficCondition = Convert.ToString(ds.Tables[0].Rows[0]["TrafficCondition"]);
                model.SitePerson = Convert.ToString(ds.Tables[0].Rows[0]["SitePerson"]);
                model.Builder = Convert.ToString(ds.Tables[0].Rows[0]["Builder"]);
                model.SoilType = Convert.ToString(ds.Tables[0].Rows[0]["SoilType"]);
                model.PermafrostDepth = Convert.ToString(ds.Tables[0].Rows[0]["PermafrostDepth"]);
                model.ThawDepth = Convert.ToString(ds.Tables[0].Rows[0]["ThawDepth"]);
                model.GroundwaterDepth = Convert.ToString(ds.Tables[0].Rows[0]["GroundwaterDepth"]);
                model.BelongsMap = Convert.ToString(ds.Tables[0].Rows[0]["BelongsMap"]);
                model.GeologicalStructure = Convert.ToString(ds.Tables[0].Rows[0]["GeologicalStructure"]);
                model.StationPlan = Convert.ToString(ds.Tables[0].Rows[0]["StationPlan"]);
                model.RingView = Convert.ToString(ds.Tables[0].Rows[0]["RingView"]);
                model.EnvironmentalDescription = Convert.ToString(ds.Tables[0].Rows[0]["EnvironmentalDescription"]);
                model.MaintenanceUnit = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceUnit"]);
                model.SiteConditions = Convert.ToString(ds.Tables[0].Rows[0]["SiteConditions"]);
                model.GravityPier = Convert.ToString(ds.Tables[0].Rows[0]["GravityPier"]);
                model.LevelSign = Convert.ToString(ds.Tables[0].Rows[0]["LevelSign"]);
                model.LightningReport = Convert.ToString(ds.Tables[0].Rows[0]["LightningReport"]);
                model.StationPhoto = Convert.ToString(ds.Tables[0].Rows[0]["StationPhoto"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.CORSStationInfo GetModelByOName(string StationOName)
        {
            string strSql = "select * from CORSStationInfo where StationOName = '" + StationOName + "'";
            Model.CORSStationInfo model = new Model.CORSStationInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.StationOName = StationOName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.StationName = Convert.ToString(ds.Tables[0].Rows[0]["StationName"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                try
                {
                    model.Lon = Convert.ToDouble(ds.Tables[0].Rows[0]["Lon"]);
                }
                catch
                {
                    model.Lon = 0;
                }
                try
                {
                    model.Lat = Convert.ToDouble(ds.Tables[0].Rows[0]["Lat"]);
                }
                catch
                {
                    model.Lat = 0;
                }
                try
                {
                    model.H = Convert.ToDouble(ds.Tables[0].Rows[0]["H"]);
                }
                catch
                {
                    model.H = 0;
                }

                try
                {
                    model.IsOK = Convert.ToInt32(ds.Tables[0].Rows[0]["IsOK"]);
                }
                catch
                {
                    model.IsOK = 0;
                }
                model.TransferType = Convert.ToString(ds.Tables[0].Rows[0]["TransferType"]);
                model.ReceiverType = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverType"]);
                model.ReceiverSN = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverSN"]);
                model.AntennaType = Convert.ToString(ds.Tables[0].Rows[0]["AntennaType"]);
                model.AntennaSN = Convert.ToString(ds.Tables[0].Rows[0]["AntennaSN"]);
                model.StationFigure = Convert.ToString(ds.Tables[0].Rows[0]["StationFigure"]);
                model.StationType = Convert.ToString(ds.Tables[0].Rows[0]["StationType"]);
                model.SpecialTelLine = Convert.ToString(ds.Tables[0].Rows[0]["SpecialTelLine"]);
                model.ContactPerson = Convert.ToString(ds.Tables[0].Rows[0]["ContactPerson"]);
                model.ContactTel = Convert.ToString(ds.Tables[0].Rows[0]["ContactTel"]);
                model.FaultLog = Convert.ToString(ds.Tables[0].Rows[0]["FaultLog"]);
                model.TrusteeFeeLog = Convert.ToString(ds.Tables[0].Rows[0]["TrusteeFeeLog"]);
                model.OperatingState = Convert.ToString(ds.Tables[0].Rows[0]["OperatingState"]);
                model.Condition = Convert.ToString(ds.Tables[0].Rows[0]["Condition"]);
                model.MovingStationLog = Convert.ToString(ds.Tables[0].Rows[0]["MovingStationLog"]);
                model.AntennaRepLog = Convert.ToString(ds.Tables[0].Rows[0]["AntennaRepLog"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.BuildTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BuildTime"]);
                model.CaseNumber = Convert.ToString(ds.Tables[0].Rows[0]["CaseNumber"]);
                model.AffiliatedNetwork = Convert.ToString(ds.Tables[0].Rows[0]["AffiliatedNetwork"]);
                model.PiersType = Convert.ToString(ds.Tables[0].Rows[0]["PiersType"]);
                model.RelyUnits = Convert.ToString(ds.Tables[0].Rows[0]["RelyUnits"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.ThicknessOfLayer = Convert.ToString(ds.Tables[0].Rows[0]["ThicknessOfLayer"]);
                model.TrafficCondition = Convert.ToString(ds.Tables[0].Rows[0]["TrafficCondition"]);
                model.SitePerson = Convert.ToString(ds.Tables[0].Rows[0]["SitePerson"]);
                model.Builder = Convert.ToString(ds.Tables[0].Rows[0]["Builder"]);
                model.SoilType = Convert.ToString(ds.Tables[0].Rows[0]["SoilType"]);
                model.PermafrostDepth = Convert.ToString(ds.Tables[0].Rows[0]["PermafrostDepth"]);
                model.ThawDepth = Convert.ToString(ds.Tables[0].Rows[0]["ThawDepth"]);
                model.GroundwaterDepth = Convert.ToString(ds.Tables[0].Rows[0]["GroundwaterDepth"]);
                model.BelongsMap = Convert.ToString(ds.Tables[0].Rows[0]["BelongsMap"]);
                model.GeologicalStructure = Convert.ToString(ds.Tables[0].Rows[0]["GeologicalStructure"]);
                model.StationPlan = Convert.ToString(ds.Tables[0].Rows[0]["StationPlan"]);
                model.RingView = Convert.ToString(ds.Tables[0].Rows[0]["RingView"]);
                model.EnvironmentalDescription = Convert.ToString(ds.Tables[0].Rows[0]["EnvironmentalDescription"]);
                model.MaintenanceUnit = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceUnit"]);
                model.SiteConditions = Convert.ToString(ds.Tables[0].Rows[0]["SiteConditions"]);
                model.GravityPier = Convert.ToString(ds.Tables[0].Rows[0]["GravityPier"]);
                model.LevelSign = Convert.ToString(ds.Tables[0].Rows[0]["LevelSign"]);
                model.LightningReport = Convert.ToString(ds.Tables[0].Rows[0]["LightningReport"]);
                model.StationPhoto = Convert.ToString(ds.Tables[0].Rows[0]["StationPhoto"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from CORSStationInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount()
        {
            string strSql = "select count(*) from CORSStationInfo";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        ///获取基站列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.StationName,w1.StationOName,w1.Lat,w1.Lon,w1.OperatingState FROM CORSStationInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,StationName,StationOName,Lat,Lon,OperatingState FROM CORSStationInfo ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from CORSStationInfo where StationOName like '%" + search + "%' or StationName like '%" + search + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 获得用户坐标转换列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string search = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM CORSStationInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM CORSStationInfo where StationName like '%" + search + "%' or StationOName like '%" + search + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage(int offset, int limit, string sort = "ID", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.StationName,w1.StationOName,w1.StationType FROM CORSStationInfo w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM CORSStationInfo where StationName like '%@search%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            sql = sql.Replace("@search", search);
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;
        }


    }
}
