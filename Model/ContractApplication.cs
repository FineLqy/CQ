using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContractApplication
    {
        public ContractApplication()
         {
             ID = "";
            UserName = "";
            Contacts = "";
            Phone = "";
            Address = "";
            Price = "";
            ContractFile = "";
            Type = "";
            ApplicationTime = DateTime.Now;
            Remark = "";
    }
        /// <summary>
        /// 合同号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 合同路径
        /// </summary>
        public string ContractFile { get; set; }
        /// <summary>
        /// 合同类型：0：草稿；1：正式
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplicationTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
