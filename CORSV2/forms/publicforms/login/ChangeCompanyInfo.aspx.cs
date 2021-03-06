﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.login
{
    public partial class ChangeCompanyInfo : System.Web.UI.Page
    {
        public static string userName = "";
        public static string oldCompany = "";

        public static Model.RegisterUser registerUser = new Model.RegisterUser();
        public static Model.CompanyInfo companyInfo = new Model.CompanyInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "hencors";
            //Session["UserType"] = "1";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            //加载前端数据
            userName = Session["UserName"].ToString();
            companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(DAL.RegisterUser.GetModel(userName).CertifiationIndex));
            oldCompany = companyInfo.Company;

            //
            if (Request["action"] != null && Request["action"].ToString() == "changeCompanyInfo")
            {
                registerUser = DAL.RegisterUser.GetModel(userName);
                companyInfo.Company = Request["new_company"].ToString();
                DAL.CompanyInfo.Update(companyInfo);

                //string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                //string message = "尊敬的用户您好：平台绑定单位已经成功修改为：" + companyInfo.Company + "，请及时登录系统查看!";
                //SMS = SMS.Replace("@message", message);
                //SMS = SMS.Replace("@phone", registerUser.Phone);

                //try
                //{
                //    cs.HttpHelper.SendSMS(SMS);
                //}
                //catch (Exception ex)
                //{
                //    cs.WebLogger.WriteErroLog("修改单位短信发送错误" + ex.ToString());    //输出到文件中
                //}

                Response.Write("{\"code\":200}");
                Response.End();
            }
        }
    }
}