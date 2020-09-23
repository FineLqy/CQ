using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 注册登录用户信息表
    /// </summary>
    public class RegisterUser
    {
        public RegisterUser() {
            UserName = "";
            PassWord = "";
            Email = "";
            Phone = "";
            RegTime = DateTime.Now;
            LastLoginTime = DateTime.Now;
            TryLoginTimes = 0;
            CertifiationStatus = 0;
            CertifiationIndex = "";
            UserType = 1;
            IsEnable = 1;
            BelongArea = "全部";
        }
        /// <summary>
        /// ID
        /// </summary>
        public int ID {set;get;}
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { set; get; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { set; get; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { set; get; }
        /// <summary>
        /// 尝试登录次数
        /// </summary>
        public int TryLoginTimes { set; get; }
        /// <summary>
        /// 认证状态 0-未认证 1-单位认证中 2-单位认证通过 3-个人认证中 4-个人认证通过 5-认证失败 6-资质变更中
        /// </summary>
        public int CertifiationStatus { set; get; }
        /// <summary>
        /// 认证信息索引
        /// </summary>
        public string CertifiationIndex { set; get; }
        /// <summary>
        /// 用户类型 1-普通用户 2-协管员用户 3-超级管理员用户 
        /// </summary>
        public int UserType { set; get; }
        /// <summary>
        /// 是否可登陆系统
        /// </summary>
        public int IsEnable { set; get; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public string BelongArea { set; get; }
    }
}
