using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderList
    {
        public OrderList() {
            UserName = "";
            OrderNumber = "";
            SubmitTime = DateTime.Now;
            OrderStatus = 0;
            WorkArea = "";
            ServerType = "cm";
            CoorTransEnable = 0;
            HeightTransEnable = 0;
            SHPTransEnable = 0;
            DXFTransEnable = 0;
            PPPserverEnable = 0;
            ObsQualityEnable = 0;
            BaseLineEnable = 0;
            MultiBaseLineEnable = 0;
            CoorSystemEnable = 0;
            RoamingServiceArea = "";
            RoamingServiceEnable = 0;
            AccountNum = 0;
            ServiceDuration = "0";
            Price = "0";
            Dealer = "";
            DealTime = DateTime.Now;
            PayMethod = 0;
            TransferCertificate = "";
            PayTime = DateTime.Now;
            RoamID = "";
            company = "";
            OrderContent = "";
            OrdeType = 0;
            ElevationEnable = 0;
            IsRenew = "";



        }
        public int ID { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { set; get; }
        /// <summary>
        /// 提交订单时间
        /// </summary>
        public DateTime SubmitTime
        {
            set;
            get;
        }
        /// <summary>
        /// 订单状态 0-提交未支付  1-提交已支付 2-支付审核通过处理完成  3-支付审核失败
        /// </summary>
        public int OrderStatus { set; get; }
        /// <summary>
        /// 申请作业区域  保存ID  ""为全部区域
        /// </summary>
        public string WorkArea { set; get; }
        /// <summary>
        /// 申请服务等级 cm /dm /mm
        /// </summary>
        public string ServerType { set; get; }
        /// <summary>
        /// 坐标转换可用性 0-不可用 1-可用
        /// </summary>
        public int CoorTransEnable { set; get; }
        /// <summary>
        ///  高程转换可用性 0-不可用 1-可用
        /// </summary>
        public int HeightTransEnable { set; get; }
        /// <summary>
        /// SHP文件转换可用性 0-不可用 1-可用
        /// </summary>
        public int SHPTransEnable { set; get; }
        /// <summary>
        /// DXF转换可用性 0-不可用   1-可用
        /// </summary>
        public int DXFTransEnable { set; get; }
        /// <summary>
        /// PPP服务可用性 0- 不可用1-可用
        /// </summary>
        public int PPPserverEnable { set; get; }
        /// <summary>
        /// 观测文件质量检核 0-不可用1-可用
        /// </summary>
        public int ObsQualityEnable { set; get; }
        /// <summary>
        ///  单站平差解算 0-可用 1-不可用
        /// </summary>
        public int BaseLineEnable { set; get; }
        /// <summary>
        ///  多站平差解算 0-可用 1-不可用
        /// </summary>
        public int MultiBaseLineEnable { set; get; }
        /// <summary>
        /// 正常高可用
        /// </summary>
        public int ElevationEnable { set; get; }
        /// <summary>
        /// 实时在线坐标转换可用性 0- 不可用 1-可用
        /// </summary>
        public int CoorSystemEnable { set; get; }
        /// <summary>
        /// 数据漫游服务可用性 0-不可用 1-可用
        /// </summary>
        public int RoamingServiceEnable { set; get; }
        /// <summary>
        /// 漫游可用区域
        /// </summary>
        public string RoamingServiceArea { set; get; }
        /// <summary>
        /// 申请账号个数
        /// </summary>
        public int AccountNum { set; get; }
        /// <summary>
        /// 服务时长1个月还是一年 用月的个数来计数
        /// </summary>
        public string ServiceDuration { set; get; }
        /// <summary>
        /// 价格
        /// </summary>
        public string Price { set; get; }
        /// <summary>
        /// 订单审核处理人
        /// </summary>
        public string Dealer { set; get; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime DealTime { set; get; }
        /// <summary>
        /// 支付方式 0-对公转账上传缴费凭证 1-微信 2-支付宝
        /// </summary>
        public int PayMethod { set; get; }
        /// <summary>
        /// 转账凭证路径
        /// </summary>
        public string TransferCertificate { set; get; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { set; get; }
        /// <summary>
        /// 漫游ID
        /// </summary>
        public string RoamID { get; set; }
        /// <summary>
        /// 单位名
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 订单内容
        /// </summary>
        public string OrderContent { get; set; }
        /// <summary>
        /// 订单类型  0:订单申请 1：账号续费 2：账号充值 3:订单申请（自定义账号）
        /// </summary>
        public int OrdeType { get; set; }
        /// <summary>
        /// 是否自动续费 0:不续费 1：自动续费 
        /// </summary>
        public string IsRenew { get; set; }

    }
}
