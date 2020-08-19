using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RTKPostPurview
    {
        public RTKPostPurview() {
            UserName = "";
            CoorTransEnable = 0;
            HeightTransEnable = 0;
            SHPTransEnable = 0;
            DXFTransEnable = 0;
            PPPserverEnable = 0;
            ObsQualityEnable = 0;
            BaseLineEnable = 0;
            MultiBaseLineEnable = 0;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
        public int ID { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 坐标转换可用性 0-不可用 1-可用
        /// </summary>
        public int CoorTransEnable { set; get; }
        /// <summary>
        /// 高程转换可用性 0-不可用 1-可用
        /// </summary>
        public int HeightTransEnable { set; get; }
        /// <summary>
        /// SHP文件转换可用性 0-不可用 1-可用
        /// </summary>
        public int SHPTransEnable { set; get; }
        /// <summary>
        /// DXF文件转换可用性 0-不可用 1-可用
        /// </summary>
        public int DXFTransEnable { set; get; }
        /// <summary>
        /// PPP在线定位可用性 0-不可用 1-可用
        /// </summary>
        public int PPPserverEnable { set; get; }
        /// <summary>
        /// 观测文件质量检查可用性 0-不可用 1-可用
        /// </summary>
        public int ObsQualityEnable { set; get; }
        /// <summary>
        /// 单站平差解算可用性 0-不可用 1-可用
        /// </summary>
        public int BaseLineEnable { set; get; }
        /// <summary>
        /// 多站平差解算可用性 0-不可用 1-可用
        /// </summary>
        public int MultiBaseLineEnable { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { set; get; }
    }
}
