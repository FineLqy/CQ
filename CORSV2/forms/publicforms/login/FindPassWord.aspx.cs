using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.login
{
    public partial class FindPassWord : System.Web.UI.Page
    {
        public static string code = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] != null&& Request["action"].ToString()== "getCode")
            {
                string name = Request["name"].ToString();
                string ff = Request["action"].ToString();
                string phone = Request["phone1"].ToString();
          
                code = Number(6, false);
                string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                string message = "尊敬的用户您好，您的账号"+ name + "正在重置平台密码，验证码为：" + code;

                SMS = SMS.Replace("@message", message);
                SMS = SMS.Replace("@phone", phone);

                if (cs.HttpHelper.SendSMS(SMS))
                {
                    Response.Write("1");
                    Response.End();
                }
                else
                {
                    cs.WebLogger.WriteErroLog("验证码短信发送错误");    //输出到文件中
                }
            
            }
            if(Request["action"] != null&&Request["action"].ToString()== "checkCode"&& Request["code"]!=null)
            {
                string tempcode = Request["code"].ToString();
                if(tempcode==code&&code.Length==6)
                {
                    Response.Write("true");
                    Response.End();
                }
                else
                {
                    Response.Write("输入验证码错误");
                    Response.End();
                }

            }

            if (Request["action"]!=null&&Request["action"].ToString()=="resetPassword")
            {
                string name = Request["UserName"].ToString();
                string tempPassWord = Request["password"].ToString();
                string phone = Request["phone1"].ToString();
                if (phone != null)
                {
                    Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(name);
                    registerUser.PassWord = AES_Key.AESEncrypt(tempPassWord, registerUser.UserName.PadLeft(16, '0'));
                    string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                    string message = "尊敬的用户您好：您的平台账号" + name + "密码已经成功修改为：" + tempPassWord + "，请及时登录系统查看!";
                    SMS = SMS.Replace("@message", message);
                    SMS = SMS.Replace("@phone", phone);

                    if (cs.HttpHelper.SendSMS(SMS))
                    {
                        DAL.RegisterUser.Update(registerUser);
                    }
                    else
                    {
                        cs.WebLogger.WriteErroLog("短信发送错误");    //输出到文件中
                    }


                    Response.Write("{\"code\":200}");
                    Response.End();
                }
                else
                {
                    Response.Write("{\"code\":100}");
                    Response.End();
                }
          
            }
        }
        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        public static string Number(int Length, bool Sleep)
        {
            if (Sleep) System.Threading.Thread.Sleep(3);
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }
    }
}