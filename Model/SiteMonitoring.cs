using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SiteMonitoring
    {
        public SiteMonitoring()
        {
            StationOName = "";
            SatelliteType = "";
            Numbering = "";
            Track = "";
            Quantity = "";
            Angle = "";
            Time = DateTime.Now;
            Ratio = "";
            StorageEable = 1;
            DesignCapacity = "";
            UsedstorageSpace = "";
            AvailablestorageSpace = "";
            ReceiverTemperature = "";
            ReceiverVoltage = "";
            ReceiverElectricity = "";
            ReceiverCPU = "";
            WeatherTemperature = "";
            WeatherVoltage = "";
            WeatherElectricity = "";
            WeatherCPU = "";
            UPSTemperature = "";
            UPSVoltage = "";
            UPSElectricity = "";
            UPSCPU = "";
        }
        public int ID { set; get; }
        /// <summary>
        /// 基站Rinex站名
        /// </summary>
        public string StationOName { set; get; }
        /// <summary>
        /// 卫星的类型
        /// </summary>
        public string SatelliteType { set; get; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Numbering { set; get; }
        /// <summary>
        /// 轨迹
        /// </summary>
        public string Track { set; get; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { set; get; }
        /// <summary>
        /// 高度角
        /// </summary>
        public string Angle { set; get; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { set; get; }
        /// <summary>
        /// 信噪比
        /// </summary>
        public string Ratio { set; get; }
        /// <summary>
        /// 存储功能可用性
        /// </summary>
        public int StorageEable { set; get; }
        /// <summary>
        /// 设计容量
        /// </summary>
        public string DesignCapacity { set; get; }
        /// <summary>
        /// 已用存储空间
        /// </summary>
        public string UsedstorageSpace { set; get; }
        /// <summary>
        /// 可用存储空间
        /// </summary>
        public string AvailablestorageSpace { set; get; }
        /// <summary>
        /// 接收机温度
        /// </summary>
        public string ReceiverTemperature { set; get; }
        /// <summary>
        /// 接收机电压
        /// </summary>
        public string ReceiverVoltage { set; get; }
        /// <summary>
        /// 接收机电量
        /// </summary>
        public string ReceiverElectricity { set; get; }
        /// <summary>
        /// 接收机CPU
        /// </summary>
        public string ReceiverCPU { set; get; }
        /// <summary>
        /// 气象仪温度
        /// </summary>
        public string WeatherTemperature { set; get; }
        /// <summary>
        /// 气象仪电压
        /// </summary>
        public string WeatherVoltage { set; get; }
        /// <summary>
        /// 气象仪电量
        /// </summary>
        public string WeatherElectricity { set; get; }
        /// <summary>
        /// 气象仪CPU
        /// </summary>
        public string WeatherCPU { set; get; }
        /// <summary>
        /// UPS温度
        /// </summary>
        public string UPSTemperature { set; get; }
        /// <summary>
        /// UPS电压
        /// </summary>
        public string UPSVoltage { set; get; }
        /// <summary>
        /// UPS电量
        /// </summary>
        public string UPSElectricity { set; get; }
        /// <summary>
        /// UPSCPU
        /// </summary>
        public string UPSCPU { set; get; }
    }
}
