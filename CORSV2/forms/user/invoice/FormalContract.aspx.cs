using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.invoice
{
    public partial class FormalContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Num.Value = Request.QueryString["id"].ToString();

                Session["ContractID"] = Request.QueryString["id"].ToString();
            
                Model.ContractApplication contractApplication = DAL.ContractApplication.GetModel(Session["ContractID"].ToString());
                phone.Value = contractApplication.Phone;
                string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                Session["num"] = cs.VerifyCodeHelper.Number(4, true);
                string message = "您的短信验证码为：" + Session["num"] + "，用于正式合同转换，为保证信息安全，请勿将验证码告知他人";

                SMS = SMS.Replace("@message", message);
                SMS = SMS.Replace("@phone", contractApplication.Phone);

                if (cs.HttpHelper.SendSMS(SMS))
                {

                }
                else
                {
                    cs.WebLogger.WriteErroLog("注册短信发送错误");    //输出到文件中
                }
            }
        
          
      
            if (Request["action"] == "register")
            {
                Model.ContractApplication contractApplication = DAL.ContractApplication.GetModel(Session["ContractID"].ToString());
                string user = Request.Form["userPhone"].ToString();
                string userNum = Session["num"].ToString();

                if (Request.Form["userPhone"] == Session["num"].ToString())
                {



                
                    contractApplication.Type = "1";



                    DAL.ContractApplication.Update1(contractApplication);
                    Response.Write("1");
                    Response.End();
                }
            }

        

        }
    }
}