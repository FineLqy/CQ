using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 源列表
    /// </summary>
    public class SourceTable
    {
        public SourceTable()
        {

        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 源
        /// </summary>
        public string Source { set; get; }

        /// <summary>
        /// 源节点电文格式（RTCM2，RTCM3，CMR+）
        /// </summary>
        public string SourceType { set; get; }


    }
}
