using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 发票抬头信息
    /// </summary>
    public class InvoiceInfo
    {
        public InvoiceInfo() {
            Invoice = "";
            TaxNum = "";
            UnitAddress = "";
            Tel = "";
            Bank = "";
            AccountNum = "";
            UserName = "";
        }
        public int ID { set; get; }
        /// <summary>
        /// 抬头
        /// </summary>
        public string Invoice { set; get; }
        /// <summary>
        /// 税号
        /// </summary>
        public string TaxNum { set; get; }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string UnitAddress { set; get; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Tel { set; get; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string Bank { set; get; }
        /// <summary>
        /// 银行账户
        /// </summary>
        public string AccountNum { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
    }
}
