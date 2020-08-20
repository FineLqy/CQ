using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.user.order
{
    public partial class add_order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                  
                DataSet dsRoamArea = DAL.RoamArea.GetList("1=1");
                foreach (DataRow dr in dsRoamArea.Tables[0].Rows)
                {
                    Select2.Items.Add(dr["AreaName"].ToString());
                    Select4.Items.Add(dr["AreaName"].ToString());
                }
                              
               

            }
            if (Request["action"] == "check")
            {
                string username = Request["data"].ToString();
                DAL.RegisterUser du = new DAL.RegisterUser();
                if (DAL.RTKUserInfo.GetModel(username) == null && DAL.RegisterUser.GetModel(username) == null)
                {
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Write("0");
                    Response.End();

                }
            }
            //Session["UserName"] = "guoqijia";
            if (Request["action"] == "order")
            {
             

                Model.OrderList orderlist = new Model.OrderList();
                orderlist.UserName = Session["UserName"].ToString();
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(orderlist.UserName);
                orderlist.WorkArea = registerUser.BelongArea;
                orderlist.OrderNumber = DateTime.Now.ToString("yyyMMddhhmmssfff");
                //将订单号存储在session里面用于整个订单的操作流程。
                Session["OrderNumber"] = orderlist.OrderNumber;
                orderlist.SubmitTime = DateTime.Now;
                orderlist.AccountNum = Convert.ToInt32(Request["applynum"]);
                orderlist.ServiceDuration = Request["time"].ToString();
                orderlist.ServerType = Request["servertype"].ToString();

                Model.RegisterUser RegisterUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(RegisterUser.CertifiationIndex));
                orderlist.company = companyInfo.Company;
                orderlist.OrdeType = 0;
               
                orderlist.Price= Request["price"].ToString();
                if (Select1.Value == "是")
                {
                    orderlist.RoamID = this.Select2.Value;//保存的漫游ID
                }
                else
                {
                    orderlist.RoamID = "";
                }
                if (Checkbox1.Checked==true)
                {
                    orderlist.ElevationEnable = 1;
                }
                else
                {
                    orderlist.ElevationEnable = 0;
                }


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
            if (Request["action"] == "order1")
            {


                Model.OrderList orderlist = new Model.OrderList();
                orderlist.UserName = Session["UserName"].ToString();
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(orderlist.UserName);
                orderlist.WorkArea = registerUser.BelongArea;
                orderlist.OrderNumber = DateTime.Now.ToString("yyyMMddhhmmssfff");
                //将订单号存储在session里面用于整个订单的操作流程。
                Session["OrderNumber"] = orderlist.OrderNumber;
                orderlist.SubmitTime = DateTime.Now;
                orderlist.AccountNum = Convert.ToInt32(Request["applynum1"]);
                orderlist.ServiceDuration = Request["time1"].ToString();
                orderlist.ServerType = Request["servertype1"].ToString();

                Model.RegisterUser RegisterUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(RegisterUser.CertifiationIndex));
                orderlist.company = companyInfo.Company;
                orderlist.OrdeType = 0;

                orderlist.Price = Request["price1"].ToString();
                if (Select3.Value == "是")
                {
                    orderlist.RoamID = this.Select4.Value;//保存的漫游ID
                }
                else
                {
                    orderlist.RoamID = "";
                }
                if (Checkbox2.Checked == true)
                {
                    orderlist.ElevationEnable = 1;
                }
                else
                {
                    orderlist.ElevationEnable = 0;
                }
                if (Checkbox3.Checked == true)
                {
                    orderlist.ElevationEnable = 1;
                }
                else
                {
                    orderlist.ElevationEnable = 0;
                }



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

                string[] sys = Request["username"].ToString().Split(',');
               
                foreach (string s in sys)
                {
                    string ss = s;
                }


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