using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.order
{
    public partial class RechargeCheck : System.Web.UI.Page
    {
        public string company = "";
        public string servertime = "";
        public string order_number = "";
        public string price = "";
        public string num = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request["action"] == "confirm")
            //{

            //    string ff = Request["ordernumber"];
            //    Response.Write(order_number);
            //    Response.End();
            //    return;
            //}
            if (Request["action"] != null && Request["action"] == "back")
            {
                try
                {
                    string orderNumber = Session["OrderNumber"].ToString();
                    DAL.OrderList.Delete(orderNumber);
                    Response.End();
                }
                catch (Exception ex)
                {
                    cs.WebLogger.WriteErroLog(ex.ToString() + "用户撤回订单出错");    //输出到文件中
                    //Response.Write("<script>alert(\"1\")</script>");
                    return;
                }
            }
            else
            {

                if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
                {
                    Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                    Response.End();
                }
                string UserName = Session["UserName"].ToString();
                Model.OrderList orderlist = new Model.OrderList();
                order_number = Request["order_number"];
                orderlist = DAL.OrderList.GetModel(order_number);
                price = orderlist.Price;
                company= orderlist.company;
            

            }




        }
    }
}