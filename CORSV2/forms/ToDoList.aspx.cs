using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms
{
    public partial class ToDoList : System.Web.UI.Page
    {
        public static string qualificationNum = "";
        public static string OrderNum = "";
        public static string InvoiceNum = "";
        public static string InvoiceNum1 = "";
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                qualificationNum = DAL.RegisterUser.Getcount().ToString();//资质待审核个数
                OrderNum= DAL.OrderList.Getcount().ToString();//订单待审核个数
                InvoiceNum= DAL.InvoiceList.Getcount().ToString();//发票待审核个数
                InvoiceNum1= DAL.InvoiceList.Getcount1().ToString();//发票待开个数

            }
           
        }
    }
}