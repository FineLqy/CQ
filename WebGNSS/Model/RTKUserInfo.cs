using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RTKUserInfo
    {
        public RTKUserInfo()
        {
            UserName = "";
            PassWord = "";
            Contact = "";
            ContactPhone = "";
            ContactEmail = "";
            ContactQQ = "";
            CORSCardNum = "";
            ReceiverNum = "";
            Company = "";
            RegTime = DateTime.Now;
            UserType = 0;
            OrderNumber = "";
            BelongArea = "全部";
            RegisterUserName = "";
            
        }
        public int ID { set; get; }
        /// <summary>
        ///  用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { set; get; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { set; get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { set; get; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string ContactEmail { set; get; }
        /// <summary>
        /// QQ
        /// </summary>
        public string ContactQQ { set; get; }
        /// <summary>
        /// 专卡号
        /// </summary>
        public string CORSCardNum { set; get; }
        /// <summary>
        /// 接收机序列号
        /// </summary>
        public string ReceiverNum { set; get; }
        /// <summary>
        /// 单位名
        /// </summary>
        public string Company { set; get; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { set; get; }
        /// <summary>
        /// 用户类型 0- 单位申请账号  1-个人申请账号
        /// </summary>
        public int UserType { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { set; get; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public string BelongArea { set; get; }

        /// <summary>
        /// 注册的用户名
        /// </summary>
        public string RegisterUserName { set; get; }
    }
}
