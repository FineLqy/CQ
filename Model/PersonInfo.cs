using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 个人认证信息表
    /// </summary>
    public class PersonInfo
    {
        public PersonInfo() {
            Contact = "";
            ContactIDCardNumber = "";
            ContactIDCardFile = "";
            CertificationTime = DateTime.Now;
            BelongArea = "";
        }
        public int ID { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Contact { set; get; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string ContactIDCardNumber { set; get; }
        /// <summary>
        /// 身份证复印件
        /// </summary>
        public string ContactIDCardFile { set; get; }
        /// <summary>
        /// 认证时间
        /// </summary>
        public DateTime CertificationTime { set; get; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string BelongArea { set; get; }
    }
}
