using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SourceMap
    {
        public SourceMap() { }

        public int ID { set; get; }

        /// <summary>
        /// 源名称
        /// </summary>
        public string Source { set; get; }
        /// <summary>
        /// 源类型
        /// </summary>
        public string SourceType { set; get; }
        /// <summary>
        /// 服务端名称
        /// </summary>
        public string ServiceName { set; get; }
        /// <summary>
        /// 服务端IP
        /// </summary>
        public string ServiceIP { set; get; }
        /// <summary>
        /// 服务端端口
        /// </summary>
        public string ServicePort { set; get; }
        /// <summary>
        /// 映射后源名称
        /// </summary>
        public string MapSource { set; get; }

        /// <summary>
        /// 优先等级(1,2,3,4)
        /// </summary>
        public int PrecedenceLevel { set; get; }

        /// <summary>
        /// 最大用户数量，若超过，则直接切换到下一级连接
        /// </summary>
        public int AllowMaxNum { set; get; }

    }
}
