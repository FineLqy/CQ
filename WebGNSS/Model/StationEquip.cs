using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StationEquip
    {
        public StationEquip()
        {
 
        }
        public int ID { set; get; }
        /// <summary>
        /// 设备名
        /// </summary>
        public string MachineName { set; get; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string Models
        {
            set;
            get;
        }
        /// <summary>
        /// 初装时间
        /// </summary>
        public DateTime InstallationDate
        {
            set;
            get;
        }
        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber
        {
            set;
            get;
        }
    }
}
