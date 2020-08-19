using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.login
{
    public partial class Recharge : System.Web.UI.Page
    {
        public static string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Session["UserName"].ToString();
            int companyCertifiationIndex = Convert.ToInt32(DAL.RegisterUser.GetModel(Session["UserName"].ToString()).CertifiationIndex);

            //根据注册用户的认证id索引加载页面信息
            Model.CompanyInfo companyinfo = DAL.CompanyInfo.GetModel(companyCertifiationIndex);
            company.InnerText= companyinfo.Company;
           Balance.InnerText= companyinfo.Balance.ToString();
            if (Request["action"] == "order")
            {


                Model.OrderList orderlist = new Model.OrderList();
                orderlist.UserName = Session["UserName"].ToString();
                orderlist.company = company.InnerText;
                orderlist.Price = Price.Value;
                orderlist.OrderStatus = 0;
                orderlist.OrderContent = orderlist.company + "充值" + orderlist.Price + "元";
                orderlist.OrdeType = 2;
                orderlist.ServerType = "";


                orderlist.OrderNumber = DateTime.Now.ToString("yyyMMddhhmmssfff");
                //将订单号存储在session里面用于整个订单的操作流程。
                Session["OrderNumber"] = orderlist.OrderNumber;
                orderlist.SubmitTime = DateTime.Now;
              

                if (DAL.OrderList.Add(orderlist))
                {
                    Response.Write(orderlist.OrderNumber);

                    //Model.SysLog syslog = new Model.SysLog();
                    //syslog.LogTime = DateTime.Now;
                    //syslog.LogType = 5;
                    //syslog.Remark = "申请的服务订单待处理";
                    //syslog.UserName = orderlist.UserName;
                    //DAL.SysLog.Add(syslog);
                    Response.End();
                }
                else
                {
                    Response.Write("200");
                    Response.End();
                }
            }
        }
    }
}