using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class RoamingAreaManagement
    {
        public RoamingAreaManagement()
        {
            GroupName = "";
            Remark = "";
            GroupRange = "";
            InsertTime = DateTime.Now;

        }
        public int ID { set; get; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { set; get; }
        /// <summary>
        /// 分组描述
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 有效范围
        /// </summary>
        public string GroupRange { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime InsertTime { set; get; }
       
    }
}

