using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 基站信息类
    /// </summary>
    public class CORSStationInfo
    {
        public CORSStationInfo()
        {
            ReceiverType = "";
            ReceiverSN = "";
            AntennaType = "";
            AntennaSN = "";
            StationFigure = "";
            StationType = "";
            SpecialTelLine = "";
            ContactPerson = "";
            ContactTel = "";
            FaultLog = "";
            TrusteeFeeLog = "";
            OperatingState = "";
            Condition = "";
            MovingStationLog = "";
            AntennaRepLog = "";
            Remark = "";
            BuildTime = DateTime.Now;
            CaseNumber = "";
            AffiliatedNetwork = "";
            PiersType = "";
            RelyUnits = "";
            Address = "";
            ThicknessOfLayer = "";
            TrafficCondition = "";
            SitePerson = "";
            Builder = "";
            SoilType = "";
            PermafrostDepth = "";
            ThawDepth = "";
            GroundwaterDepth = "";
            BelongsMap = "";
            GeologicalStructure = "";
            StationPlan = "";
            RingView = "";
            EnvironmentalDescription = "";
            MaintenanceUnit = "";
            SiteConditions = "";
            GravityPier = "";
            LevelSign = "";
            LightningReport = "";
            StationPhoto = "";
            SatNum = 0;

        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 基站名
        /// </summary>
        public string StationName { set; get; }
        /// <summary>
        /// 基站O文件名
        /// </summary>
        public string StationOName { set; get; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { set; get; }
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        /// 纬度（度）
        /// </summary>
        public double Lat { set; get; }
        /// <summary>
        /// 经度（度）
        /// </summary>
        public double Lon { set; get; }
        /// <summary>
        /// 大地高（米）
        /// </summary>
        public double H { set; get; }

        /// <summary>
        /// 是否正常运行，0为不正常，1为正常
        /// </summary>
        public int IsOK { set; get; }
        /// <summary>
        /// 传输类型（Ntrip，TCP/IP）
        /// </summary>
        public string TransferType { set; get; }
        /// <summary>
        /// 接收机型号
        /// </summary>
        public string ReceiverType { set; get; }
        /// <summary>
        /// 接收机序列号
        /// </summary>
        public string ReceiverSN { set; get; }
        /// <summary>
        /// 天线类型
        /// </summary>
        public string AntennaType { set; get; }
        /// <summary>
        /// 天线序列号
        /// </summary>
        public string AntennaSN { set; get; }
        /// <summary>
        /// 站点图片
        /// </summary>
        public string StationFigure { set; get; }
        /// <summary>
        /// 基站型号
        /// </summary>
        public string StationType { set; get; }
        /// <summary>
        /// 专线号
        /// </summary>
        public string SpecialTelLine { set; get; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactPerson { set; get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { set; get; }
        /// <summary>
        /// 故障记录及维修
        /// </summary>
        public string FaultLog { set; get; }
        /// <summary>
        /// 托管费缴纳情况
        /// </summary>
        public string TrusteeFeeLog { set; get; }
        /// <summary>
        /// 基准站运行情况
        /// </summary>
        public string OperatingState { set; get; }
        /// <summary>
        /// 设备环境
        /// </summary>
        public string Condition { set; get; }
        /// <summary>
        /// 搬站情况
        /// </summary>
        public string MovingStationLog { set; get; }
        /// <summary>
        /// 天线更换情况
        /// </summary>
        public string AntennaRepLog { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }

        /// <summary>
        /// 建站时间
        /// </summary>
        public DateTime BuildTime { set; get; }
        /// <summary>
        /// 备案号
        /// </summary>
        public string CaseNumber { set; get; }
        /// <summary>
        /// 所属站网
        /// </summary>
        public string AffiliatedNetwork { set; get; }
        /// <summary>
        /// 墩标类型
        /// </summary>
        public string PiersType { set; get; }
        /// <summary>
        /// 依托单位
        /// </summary>
        public string RelyUnits { set; get; }
        /// <summary>
        /// 所在地区
        /// </summary>
        public string Address { set; get; }
        /// <summary>
        /// 土层厚度
        /// </summary>
        public string ThicknessOfLayer { set; get; }
        /// <summary>
        /// 交通情况
        /// </summary>
        public string TrafficCondition { set; get; }
        /// <summary>
        /// 选点者信息
        /// </summary>
        public string SitePerson { set; get; }
        /// <summary>
        /// 建站者信息
        /// </summary>
        public string Builder { set; get; }
        /// <summary>
        /// 地类土质
        /// </summary>
        public string SoilType { set; get; }
        /// <summary>
        /// 冻土深度
        /// </summary>
        public string PermafrostDepth { set; get; }
        /// <summary>
        /// 解冻深度
        /// </summary>
        public string ThawDepth { set; get; }
        /// <summary>
        /// 地下水深度
        /// </summary>
        public string GroundwaterDepth { set; get; }
        /// <summary>
        /// 所在图幅
        /// </summary>
        public string BelongsMap { set; get; }
        /// <summary>
        /// 基础岩性和地质构造说明
        /// </summary>
        public string GeologicalStructure { set; get; }
        /// <summary>
        /// 站点的平面图
        /// </summary>
        public string StationPlan { set; get; }
        /// <summary>
        /// 环视图
        /// </summary>
        public string RingView { set; get; }
        /// <summary>
        /// 环境说明
        /// </summary>
        public string EnvironmentalDescription { set; get; }
        /// <summary>
        /// 维护单位
        /// </summary>
        public string MaintenanceUnit { set; get; }
        /// <summary>
        /// 站点条件信息
        /// </summary>
        public string SiteConditions { set; get; }

        /// <summary>
        /// 重力墩
        /// </summary>
        public string GravityPier
        {
            set;
            get;
        }
        /// <summary>
        /// 水准标志
        /// </summary>
        public string LevelSign
        {
            set;
            get;
        }
        /// <summary>
        ///检测报告
        /// </summary>
        public string LightningReport
        {
            set;
            get;
        }
        /// <summary>
        /// 基站照片
        /// </summary>
        public string StationPhoto
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int SatNum
        {
            set;
            get;
        }
    }
}
