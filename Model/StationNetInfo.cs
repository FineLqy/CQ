using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StationNetInfo
    {
        public StationNetInfo() 
        {
            NetName = "";
            BuildTime = DateTime.Now;
            Number = "";
            DistributionDiagram = "";
            IP = "";
            Port = "";
            SourceNode = "";
            NetworkProtocol = "";
            ServiceContent = "";
            DataFormat = "";
            SatelliteSystem = "";
        }
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 站网名称
        /// </summary>
        public string NetName { set; get; }
        /// <summary>
        /// 建设完成时间
        /// </summary>
        public DateTime BuildTime { set; get; }
        /// <summary>
        /// 站点数量
        /// </summary>
        public string Number { set; get; }
        /// <summary>
        /// 站点分布示意图
        /// </summary>
        public string DistributionDiagram { set; get; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { set; get; }
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        /// 源节点
        /// </summary>
        public string SourceNode { set; get; }
        /// <summary>
        /// 网络协议
        /// </summary>
        public string NetworkProtocol { set; get; }
        /// <summary>
        /// 应用服务内容
        /// </summary>
        public string ServiceContent { set; get; }
        /// <summary>
        /// 数据格式
        /// </summary>
        public string DataFormat { set; get; }
        /// <summary>
        /// 卫星系统
        /// </summary>
        public string SatelliteSystem { set; get; }
    }
}
