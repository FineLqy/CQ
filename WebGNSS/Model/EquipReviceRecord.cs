using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class EquipReviceRecord
    {
        public EquipReviceRecord()
        {
            ReviceTime = DateTime.Now;
            RevicePerson = "";
            Contents = "";
            Information = "";
            ReviceID = "";
        }

        public int ID { set; get; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ReviceTime { set; get; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string RevicePerson { set; get; }
        /// <summary>
        /// 修改内容
        /// </summary>
        public string Contents { set; get; }
        /// <summary>
        /// 修改设备所述（模块）页面
        /// </summary>
        public string Information { set; get; }
        /// <summary>
        /// 修改对象ID
        /// </summary>
        public string ReviceID { set; get; }

    }
}
