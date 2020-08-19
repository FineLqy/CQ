using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SoftWare
    {
        public int ID { set; get; }
        /// <summary>
        ///软件名
        /// </summary>
        public string SoftWareName { set; get; }
        /// <summary>
        ///软件类型
        /// </summary>
        public string SoftWareType { set; get; }
        /// <summary>
        /// 型号 版本号
        /// </summary>
        public string Type
        {
            set;
            get;
        }
        /// <summary>
        /// 配置
        /// </summary>
        public string Config
        {
            set;
            get;
        }
        /// <summary>
        /// 维护信息
        /// </summary>
        public string Maintenance
        {
            set;
            get;
        }
        /// <summary>
        /// 软件编号
        /// </summary>
        public string Num
        {
            set;
            get;
        }
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string IP
        {
            set;
            get;
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime Time
        {
            set;
            get;
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public string IsShow
        {
            set;
            get;
        }
    }
}
