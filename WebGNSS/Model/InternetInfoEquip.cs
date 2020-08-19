using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class InternetInfoEquip
    {
        public InternetInfoEquip()
        {
            IP = "";
            Port = "";
            MachineName = "";
            Logo = "";
            EUse = "";
            Remark = "";
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { set; get; }        
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        /// 设备名
        /// </summary>
        public string MachineName { set; get; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Logo { set; get; }
        /// <summary>
        /// 用途
        /// </summary>
        public string EUse { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
    }
}
