using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    public class ErrorRTKRecord
    {
        public ErrorRTKRecord() { }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
       
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Company { set; get; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime ErrorTime { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        ///错误类型0表示超限、1表示密码错误、2表示其他异常
        /// </summary>
        public int ErrorType { set; get; }
    }
}
