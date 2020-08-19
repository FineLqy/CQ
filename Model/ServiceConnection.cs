using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ServiceConnection
    {
        public ServiceConnection() { }
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 服务端名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务端IP
        /// </summary>
        public string ServiceIP { set; get; }
        /// <summary>
        /// 服务端端口
        /// </summary>
        public string ServicePort { set; get; }
        /// <summary>
        /// 源列表（；分隔），需要自动更新
        /// </summary>
        public string SourceTable { set; get; }

    }
}
