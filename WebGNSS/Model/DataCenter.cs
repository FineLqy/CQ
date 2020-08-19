using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DataCenter
    {
        public DataCenter() {
            DeviceType = "";
            Type = "";
            SerialNumber = "";
            FirstUseDate = DateTime.Now;
            LoginName = "";
            Password = "";
            Business = "";
            IP = "";
            SubnetMask = "";
            Gateway = "";
            Port = "";          
            MaintenanceTime = DateTime.Now;
            MaintenanceContent = "";
            MaintenancePerson = "";
        }
        public int ID { set; get; }
        
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
        /// 初次使用时间
        /// </summary>
        public DateTime FirstUseDate { set; get; }
        /// <summary>
        /// 业务及用途
        /// </summary>
        public string Business { set; get; }
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
        /// 登录名
        /// </summary>
        public string LoginName { set; get; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { set; get; }
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
    }
}
