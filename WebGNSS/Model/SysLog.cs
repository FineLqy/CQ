using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SysLog
    {
        public SysLog() { }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime LogTime { set; get; }
        /// <summary>
        /// 操作用户名，管理员或用户
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 日志类型，0为管理员操作日志，1为用户操作日志,2为基站状态变更日志，3为七参数变更日志,4为单位管理员操作日志
        /// </summary>
        public int LogType { set; get; }
    }
}
