﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.publicforms.login
{
    public partial class changepassword : System.Web.UI.Page
    {
        public static string code = "";
        public static string userName = "";
        public static string phone = "";

       
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "hencors";
            //Session["UserType"] = "1";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            userName = Session["UserName"].ToString();



            if (Request["action"] != null && Request["action"].ToString() == "getCode")
            {
                string ff = Request["action"].ToString();
             
                string phone = DAL.RegisterUser.GetModel(userName).Phone;
                code = Number(6, false);
                string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                string message = "用户您好，您正在修改平台密码，验证码为：" + code;

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
            if (Request["action"] != null && Request["action"].ToString() == "checkCode" && Request["code"] != null)
            {
                string tempcode = Request["code"].ToString();
                if (tempcode == code && code.Length == 6)
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

            if (Request["action"] != null && Request["action"].ToString() == "resetPassword")
            {
                string tempPassWord = Request["password"].ToString();
                string phone = DAL.RegisterUser.GetModel(userName).Phone;
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModelByPhone(phone);
                registerUser.PassWord = AES_Key.AESEncrypt(tempPassWord, registerUser.UserName.PadLeft(16, '0'));
                
                DAL.RegisterUser.Update(registerUser);

                string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                string message = "尊敬的用户您好：平台密码已经成功修改为：" + tempPassWord + "，请及时登录系统查看!";
                SMS = SMS.Replace("@message", message);
                SMS = SMS.Replace("@phone", phone);

                if (cs.HttpHelper.SendSMS(SMS))
                {

                }
                else
                {
                    cs.WebLogger.WriteErroLog("短信发送错误");    //输出到文件中
                }


                Response.Write("{\"code\":200}");
                Response.End();
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