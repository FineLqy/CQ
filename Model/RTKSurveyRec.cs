using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// RTK作业记录
    /// </summary>
    public class RTKSurveyRec
    {
        public RTKSurveyRec() { }

        public int ID { set; get; }
        /// <summary>
        /// RTK用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 所属单位
        /// </summary>
        public string Company { set; get; }

        /// <summary>
        /// 开始作业时间
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 作业时间（分钟）
        /// </summary>
        public double OnlineSpan { set; get; }
        /// <summary>
        /// 固定时长(分钟)
        /// </summary>
        public double FixedSpan { set; get; }
        /// <summary>
        /// 花费
        /// </summary>
        public double Cost { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }

    }
}
