using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 缴费记录
    /// </summary>
  public  class PaymentRecord
    {
        public PaymentRecord()
        {
            UserName= "";
            ProductName = "";
            Company = "";
            Type =0;
            Money = "";
            RechargeTime = DateTime.Now;
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 操作用户
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Money { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime RechargeTime { get; set; }
    }
}
