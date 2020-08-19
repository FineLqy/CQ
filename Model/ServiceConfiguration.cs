using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 产品服务价格配置
    /// </summary>
    public class ServiceConfiguration
    {
            public ServiceConfiguration()
                {
                ServerName = "";
                paymentMethod = "";
                Price =0;
                InsertDate =DateTime.Now;
                ProductDescription = "";
                }
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string  ServerName { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string paymentMethod { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime InsertDate { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string ProductDescription { get; set; }

    }

   
}
