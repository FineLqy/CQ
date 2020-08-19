using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 系统消息
    /// </summary>
    public class UserMessage
    {
        public UserMessage()
        {
            Remark = "";
        }
        /// <summary>
        /// ID
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 消息等级
        /// </summary>
        public int level { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        /// 发件人
        /// </summary>
        public string FromUser { set; get; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string ToUser { set; get; }
        /// <summary>
        /// 发件时间
        /// </summary>
        public DateTime SentTime { set; get; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public int IsRead { set; get; }
        /// <summary>
        /// 查阅时间
        /// </summary>
        public DateTime ReadTime { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }

    }
}
