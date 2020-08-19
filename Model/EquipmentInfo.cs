using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class EquipmentInfo
    {
        public EquipmentInfo()
        {
            StationOName = "";
            StationName = "";
            DeviceType = "";
            Type = "";
            SerialNumber = "";
            InstallationDate = DateTime.Now;
            LoginName = "";
            Password = "";
            SatelliteSystem = "";
            AntennaH = 0;
            AntennaHM = "";
            AntennaHML = "";
            IP = "";
            SubnetMask = "";
            Gateway = "";
            Port = "";
            BaudRate = "";
            DataConfiguration = "";
            MaintenanceTime = DateTime.Now;
            MaintenanceContent = "";
            MaintenancePerson = "";
            AntennaType = "";
            AntennaDate = DateTime.Now;
            AntennaModels = "";
            AntennaSerialNumber = "";
            MeteorologicalType = "";
            MeteorologicalDate = DateTime.Now;
            MeteorologicalModels = "";
            MeteorologicalSerialNumber = "";
            AtomicclkType = "";
            AtomicclkDate = DateTime.Now;
            AtomicclkModels = "";
            AtomicclkSerialNumber = "";
            switchType = "";
            switchDate = DateTime.Now;
            switchModels = "";
            switchSerialNumber = "";
            routerType = "";
            routerDate = DateTime.Now;
            routerModels = "";
            routerSerialNumber = "";
            FirewallType = "";
            FirewallDate = DateTime.Now;
            FirewallSerialNumber = "";
            FirewallModels = "";
            LightningType = "";
            LightningDate = DateTime.Now;
            LightningModels = "";
            LightningSerialNumber = "";
            ComputerType = "";
            ComputerModels = "";
            ComputerSerialNumber = "";
            ComputerDate = DateTime.Now;
            EquipID = "";
        }
        public int ID { set; get; }
        /// <summary>
        /// 站点Rinex站名
        /// </summary>
        public string StationOName { set; get; }
        /// <summary>
        /// 站点名
        /// </summary>
        public string StationName { set; get; }
        /// <summary>
        /// 设备的类型
        /// </summary>
        public string DeviceType { set; get; }
        /// <summary>
        /// 型号
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { set; get; }
        /// <summary>
        /// 初装时间
        /// </summary>
        public DateTime InstallationDate { set; get; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { set; get; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// 卫星系统
        /// </summary>
        public string SatelliteSystem { set; get; }
        /// <summary>
        /// 天线高
        /// </summary>
        public double AntennaH { set; get; }
        /// <summary>
        /// 天线高量取方式
        /// </summary>
        public string AntennaHM { set; get; }
        /// <summary>
        /// 天线高量取位置
        /// </summary>
        public string AntennaHML { set; get; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { set; get; }
        /// <summary>
        /// 子网掩码
        /// </summary>
        public string SubnetMask { set; get; }
        /// <summary>
        /// 网关
        /// </summary>
        public string Gateway { set; get; }
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        /// 波特率
        /// </summary>
        public string BaudRate { set; get; }
        /// <summary>
        /// 数据流转发配置
        /// </summary>
        public string DataConfiguration { set; get; }
        /// <summary>
        /// 设备维护时间
        /// </summary>
        public DateTime MaintenanceTime { set; get; }
        /// <summary>
        /// 设备维护内容
        /// </summary>
        public string MaintenanceContent { set; get; }
        /// <summary>
        /// 设备维护人员
        /// </summary>
        public string MaintenancePerson { set; get; }
        /// <summary>
        /// 天线类型
        /// </summary>
        public string AntennaType
        {
            set;
            get;
        }
        /// <summary>
        /// 天线型号
        /// </summary>
        public string AntennaModels
        {
            set;
            get;
        }
        /// <summary>
        /// 天线序列号
        /// </summary>
        public string AntennaSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 天线初装日期
        /// </summary>
        public DateTime AntennaDate
        {
            set;
            get;
        }
        /// <summary>
        /// 气象仪类型
        /// </summary>
        public string MeteorologicalType
        {
            set;
            get;
        }
        /// <summary>
        /// 气象仪型号
        /// </summary>
        public string MeteorologicalModels
        {
            set;
            get;
        }
        /// <summary>
        /// 气象仪序列号
        /// </summary>
        public string MeteorologicalSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 气象仪初装日期
        /// </summary>
        public DateTime MeteorologicalDate
        {
            set;
            get;
        }
        /// <summary>
        /// 原子钟类型
        /// </summary>
        public string AtomicclkType
        {
            set;
            get;
        }
        /// <summary>
        /// 原子钟型号
        /// </summary>
        public string AtomicclkModels
        {
            set;
            get;
        }
        /// <summary>
        /// 原子钟序列号
        /// </summary>
        public string AtomicclkSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 原子钟初装日期
        /// </summary>
        public DateTime AtomicclkDate
        {
            set;
            get;
        }
        /// <summary>
        /// 交换机类型
        /// </summary>
        public string switchType
        {
            set;
            get;
        }
        /// <summary>
        /// 交换机型号
        /// </summary>
        public string switchModels
        {
            set;
            get;
        }
        /// <summary>
        /// 交换机序列号
        /// </summary>
        public string switchSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 交换机安装日期
        /// </summary>
        public DateTime switchDate
        {
            set;
            get;
        }
        /// <summary>
        /// 路由器类型
        /// </summary>
        public string routerType
        {
            set;
            get;
        }
        /// <summary>
        /// 路由器型号
        /// </summary>
        public string routerModels
        {
            set;
            get;
        }
        /// <summary>
        /// 路由器序列号
        /// </summary>
        public string routerSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 路由器安装日期
        /// </summary>
        public DateTime routerDate
        {
            set;
            get;
        }
        /// <summary>
        /// 防火墙类型
        /// </summary>
        public string FirewallType
        {
            set;
            get;
        }
        /// <summary>
        /// 防火墙型号
        /// </summary>
        public string FirewallModels
        {
            set;
            get;
        }
        /// <summary>
        /// 防火墙序列号
        /// </summary>
        public string FirewallSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 防火墙安装日期
        /// </summary>
        public DateTime FirewallDate
        {
            set;
            get;
        }
        /// <summary>
        /// 防雷设备类型
        /// </summary>
        public string LightningType
        {
            set;
            get;
        }
        /// <summary>
        /// 防雷设备型号
        /// </summary>
        public string LightningModels
        {
            set;
            get;
        }
        /// <summary>
        /// 防雷设备序列号
        /// </summary>
        public string LightningSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 防雷设备安装日期
        /// </summary>
        public DateTime LightningDate
        {
            set;
            get;
        }
        /// <summary>
        /// 终端计算机类型
        /// </summary>
        public string ComputerType
        {
            set;
            get;
        }
        /// <summary>
        /// 计算机型号
        /// </summary>
        public string ComputerModels
        {
            set;
            get;
        }
        /// <summary>
        /// 计算机序列号
        /// </summary>
        public string ComputerSerialNumber
        {
            set;
            get;
        }
        /// <summary>
        /// 计算机安装日期
        /// </summary>
        public DateTime ComputerDate
        {
            set;
            get;
        }
        /// <summary>
        /// 设备id
        /// 
        /// </summary>
        public string EquipID
        {
            set;
            get;
        }
    }
}
