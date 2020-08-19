using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RTKUserStatus
    {
        public RTKUserStatus()
        {
            //StartTime = new DateTime();
        }
        public int ID { set; get; }
        public string UserName { set; get; }
        /// <summary>
        /// 所属单位
        /// </summary>
        public string Company { set; get; }

        /// <summary>
        /// 用户是否在线，0为不在线，1为在线
        /// </summary>
        public int IsOnline { set; get; }

        public DateTime StartTime { set; get; }

        public double Lon { set; get; }

        public double Lat { set; get; }

        public string Remark { set; get; }
    }
}
