using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RTKUserPosiRec
    {
         
        public int ID { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 费用
        /// </summary>
        public DateTime Time { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public double Lat { set; get; }
        public double Lon { set; get; }
    }
}
