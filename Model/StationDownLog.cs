using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StationDownLog
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 站名
        /// </summary>
        public string StationOName { set; get; }
        /// <summary>
        /// 故障时间
        /// </summary>
        public DateTime DownTime { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        ///故障类型
        /// </summary>
        public int FaultType { set; get; }
    }
}
