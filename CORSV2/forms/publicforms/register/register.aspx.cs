using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.register
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] == "register")
            {

                string user = Request.Form["userPhone"].ToString();
                string userNum = Session["num"].ToString();

                if ( Request.Form["userPhone"]== Session["num"].ToString())
                {

               

                Model.RegisterUser registeruser = new Model.RegisterUser();
                registeruser.UserName = Request.Form["username"];
                string tempPassWord = Request.Form["password"];
                registeruser.PassWord = AES_Key.AESEncrypt(tempPassWord, registeruser.UserName.PadLeft(16,'0'));
                registeruser.Email = Request.Form["email"];
                registeruser.Phone = Request.Form["phone"];
                registeruser.RegTime = DateTime.Now;
                registeruser.LastLoginTime = DateTime.Now;
                registeruser.TryLoginTimes = 0;
                registeruser.CertifiationStatus = 0;
                registeruser.CertifiationIndex = "";
                registeruser.UserType = 1;
                registeruser.IsEnable = 1;

              

                    DAL.RegisterUser.Add(registeruser);
                    Response.Write("1");
                    Response.End();
                }
            }

            if (Request["action"] == "aaa")
            {

                string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                Session["num"] = cs.VerifyCodeHelper.Number(4, true);
                string message = "您的短信验证码为：" + Session["num"] + "，用于注册验证，为保证账号安全，请勿将验证码告知他人";

                SMS = SMS.Replace("@message", message);
                SMS = SMS.Replace("@phone", Request["phone"]);

                if (cs.HttpHelper.SendSMS(SMS))
                {
                    
                }
                else
                {
                    cs.WebLogger.WriteErroLog("注册短信发送错误");    //输出到文件中
                }

            }



            if (Request["action"] == "check_username")
            {
                if (DAL.RegisterUser.Exists(Request["username"]))
                {
                    Response.Write("用户名已存在");
                    Response.End();
                }
                else
                {
                    Response.Write("true");
                    Response.End();
                }
            }
            if (Request["action"] == "check_phone")
            {
                if (DAL.RegisterUser.ExistsPhone(Request["phone"]))
                {
                    Response.Write("手机号已注册");
                    
                    Response.End();
                }
                else
                {
                    Response.Write("true");
                    Response.End();
                }
            }





        }
   


    }

}