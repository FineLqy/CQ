using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RTKUserPurview
    {
        public RTKUserPurview()
        {
            UserName="";
            VRSEnable = 0;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            ServerType = "cm";
            SourceTable = "";
            AreaID = "";
            CoorSystem = "";
            ElevationEnable = 0;
            ElevationMode = "85GC";
            RoamingServiceEnable = 0;
            RoamingServiceArea = "";
        }
        public int ID { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 服务是否可用
        /// </summary>
        public int VRSEnable { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime{set;get;}
        /// <summary>
        /// 服务类型 cm dm mm
        /// </summary>
        public string ServerType { set; get; }
        /// <summary>
        /// 可用源列表
        /// </summary>
        public string SourceTable { set; get; }
        /// <summary>
        /// 可用区域 保存区域ID
        /// </summary>
        public string AreaID { set; get; }
        /// <summary>
        /// 作业可用坐标系
        /// </summary>
        public string CoorSystem { set; get; }
        /// <summary>
        /// 正常高是否可用
        /// </summary>
        public int ElevationEnable { set; get; }
        /// <summary>
        /// 正常高系统
        /// </summary>
        public string ElevationMode { set; get; }
        /// <summary>
        /// 漫游服务可用性
        /// </summary>
        public int RoamingServiceEnable { set; get; }
        /// <summary>
        /// 漫游可用区域
        /// </summary>
        public string RoamingServiceArea { set; get; }
    }
}
