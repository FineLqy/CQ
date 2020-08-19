using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class News
    {
        public News()
        {
            Pageview = 0;
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime Time { set; get; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { set; get; }
        /// <summary>
        /// 缩略
        /// </summary>
        public int Pageview { set; get; }
        /// <summary>
        /// 文章具体内容
        /// </summary>
        public string Details { set; get; }

    }
}
