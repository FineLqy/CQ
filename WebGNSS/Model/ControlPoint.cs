using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ControlPoint
    {
        public ControlPoint()
        {
            PointRemark = "";
        }
        public int ID { set; get; }
        /// <summary>
        /// 点名
        /// </summary>
        public string MarkName { set; get; }
        /// <summary>
        /// 点号
        /// </summary>
        public string MarkID { set; get; }
        /// <summary>
        /// 平面坐标精度等级
        /// </summary>
        public string AccuracyClass { set; get; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double B { set; get; }
        /// <summary>
        /// 经度
        /// </summary>
        public double L { set; get; }
        /// <summary>
        /// 高程
        /// </summary>
        public double H { set; get; }
        /// <summary>
        /// 高程坐标精度等级
        /// </summary>
        public string GCgrade { get; set; }
        /// <summary>
        /// 标志是否完好
        /// </summary>
        public string BZ { set; get; }
        /// <summary>
        /// 点之记
        /// </summary>
        public string PointRemark { set; get; }
    }
}
