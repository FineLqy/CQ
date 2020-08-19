using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class InternetInformation
    {
        public InternetInformation() 
        {
            DataLineStartP = "";
            DataLineEndP = "";
            Type = "";
            EncryptionTechnology = "";
            BandWidth = "";
            GreenOperator = "";
            TechnicalSupportStaff = "";
            FDataLineType = "";
            FEncryptionTechnology = "";
            FBandWidth = "";
            FGreenOperator = "";
            FTechnicalSupportStaff = "";
            ServerIP = "";
            ServerPort = "";
            ServerMachineName = "";
            ServerLogo = "";
            ServerUse = "";
            ServerRemark = "";
            StorageIP = "";
            StoragePort = "";
            StorageMachineName = "";
            StorageLogo = "";
            StorageUse = "";
            StorageRemark = "";
            EquipmentID = "";
            EquipConfig = "";
            Topological = "";
            RouterConfig = "";
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 数据专线起点
        /// </summary>
        public string DataLineStartP { set; get; }
        /// <summary>
        /// 数据专线止点
        /// </summary>
        public string DataLineEndP { set; get; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 加密技术
        /// </summary>
        public string EncryptionTechnology { set; get; }
        /// <summary>
        /// 带宽
        /// </summary>
        public string BandWidth { set; get; }
        /// <summary>
        /// 专线运营商
        /// </summary>
        public string GreenOperator { set; get; }
        /// <summary>
        /// 技术支持人员
        /// </summary>
        public string TechnicalSupportStaff { set; get; }
        /// <summary>
        /// 数据分发专线类型
        /// </summary>
        public string FDataLineType { set; get; }
        /// <summary>
        /// 数据分发加密技术
        /// </summary>
        public string FEncryptionTechnology { set; get; }
        /// <summary>
        /// 数据分发宽带
        /// </summary>
        public string FBandWidth { set; get; }
        /// <summary>
        /// 数据分发运营商
        /// </summary>
        public string FGreenOperator { set; get; }
        /// <summary>
        /// 数据分发技术支持
        /// </summary>
        public string FTechnicalSupportStaff { set; get; }
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP { set; get; }
        /// <summary>
        /// 服务器端口
        /// </summary>
        public string ServerPort { set; get; }
        /// <summary>
        /// 服务器机器名
        /// </summary>
        public string ServerMachineName { set; get; }
        /// <summary>
        /// 服务器标识
        /// </summary>
        public string ServerLogo { set; get; }
        /// <summary>
        /// 服务器用途
        /// </summary>
        public string ServerUse { set; get; }
        /// <summary>
        /// 服务器备注
        /// </summary>
        public string ServerRemark { set; get; }
        /// <summary>
        /// 存储IP
        /// </summary>
        public string StorageIP { set; get; }
        /// <summary>
        /// 存储端口
        /// </summary>
        public string StoragePort { set; get; }
        /// <summary>
        /// 存储机器名
        /// </summary>
        public string StorageMachineName { set; get; }
        /// <summary>
        /// 存储标识
        /// </summary>
        public string StorageLogo { set; get; }
        /// <summary>
        /// 存储用途
        /// </summary>
        public string StorageUse { set; get; }
        /// <summary>
        /// 存储备注
        /// </summary>
        public string StorageRemark { set; get; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string EquipmentID { set; get; }
        /// <summary>
        /// 设备基本配置--配置文件地址
        /// </summary>
        public string EquipConfig { set; get; }
        /// <summary>
        /// 拓扑关系--文件地址
        /// </summary>
        public string Topological { set; get; }
        /// <summary>
        /// 路由器配置
        /// </summary>
        public string RouterConfig { set; get; }
       
    }
}
