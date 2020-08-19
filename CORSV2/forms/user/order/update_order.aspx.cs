using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.order
{

    public partial class update_order : System.Web.UI.Page
    {
        public static string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["name"] != "" && Request["name"] != null)
            {
                Label1.Text = Request["name"];//要续费的用户名
                
                Session["OrderName"] = Label1.Text;
            }
            if (Request["action"] == "order")
            {

                Model.OrderList orderlist = new Model.OrderList();
                orderlist.UserName = Session["OrderName"].ToString();
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                orderlist.WorkArea = registerUser.BelongArea;
                orderlist.OrderNumber = DateTime.Now.ToString("yyyMMddhhmmssfff");
                //将订单号存储在session里面用于整个订单的操作流程。
                Session["OrderNumber"] = orderlist.OrderNumber;
                orderlist.SubmitTime = DateTime.Now;
                orderlist.AccountNum = Convert.ToInt32(Request["applynum"]);
                orderlist.ServiceDuration = Request["time"].ToString();
                orderlist.ServerType = Request["servertype"].ToString();
                orderlist.Price = Request["price"].ToString();
                string[] otherserver = Request["otherserver"].ToString().Split(',');
                if (Array.IndexOf(otherserver, "CoorTransEnable") != -1)
                {
                    orderlist.CoorSystemEnable = 1;
                }
                if (Array.IndexOf(otherserver, "HeightTransEnable") != -1)
                {
                    orderlist.HeightTransEnable = 1;
                }
                if (Array.IndexOf(otherserver, "SHPTransEnable") != -1)
                {
                    orderlist.SHPTransEnable = 1;
                }
                if (Array.IndexOf(otherserver, "ObsQualityEnable") != -1)
                {
                    orderlist.ObsQualityEnable = 1;
                }

                //Model.SysLog syslog = new Model.SysLog();
                //syslog.LogTime = DateTime.Now;
                //syslog.LogType = 5;
                //syslog.Remark = "申请的服务订单待处理";
                //syslog.UserName = orderlist.UserName;
                //DAL.SysLog.Add(syslog);


                if (DAL.OrderList.Add(orderlist))
                {
                    Response.Write(orderlist.OrderNumber);
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
