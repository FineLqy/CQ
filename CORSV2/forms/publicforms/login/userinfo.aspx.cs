using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.login
{
    public partial class userinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            #region 加载页面数据
            if(Session["UserType"].ToString() !="0")
            {
                string tempUserName = Session["UserName"].ToString();
                Model.RegisterUser registerUser = new Model.RegisterUser();
                registerUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                userName.InnerText = registerUser.UserName;
                try
                {
                    Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(registerUser.CertifiationIndex));
                    company.InnerText = companyInfo.Company;
                    Balance.InnerText = companyInfo.Balance.ToString();
                }
                catch
                {
                    company.InnerText = "未绑定";
                }
                switch (registerUser.UserType)
                {
                    case 1:
                        userType.InnerText = "普通用户";
                        break;
                    case 2:
                        userType.InnerText = "协管员用户";
                        break;
                    case 3:
                        userType.InnerText = "超级管理员用户";
                        break;
                    default:
                        break;
                }
                registerTime.InnerText = registerUser.RegTime.ToString("yyyy-MM-dd HH:mm:ss");
                email.InnerText = cs.HideCharShow.StrReplaceByStar(registerUser.Email, 3, 5, "*");
                phone.InnerText = cs.HideCharShow.StrReplaceByStar(registerUser.Phone, 4, 7, "*");
                switch (registerUser.CertifiationStatus)
                {
                    case 0:
                        qualificationStatus.InnerText = "尚未认证资质";
                        qualificationStatus.Style.Add("color", "red");
                        RechargeBtn.Visible = false;
                        break;
                    case 1:
                    case 3:
                        qualificationStatus.InnerText = "资质认证中";
                        qualificationStatus.Style.Add("color", "blue");
                        RechargeBtn.Visible = false;
                        break;
                    case 2:
                    case 4:
                        qualificationStatus.InnerText = "资质认证通过";
                        qualificationStatus.Style.Add("color", "green");
                        RechargeBtn.Visible = true;
                        break;
                    case 5:
                        qualificationStatus.InnerText = "资质认证失败";
                        qualificationStatus.Style.Add("color", "red");
                        RechargeBtn.Visible = false;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                string rr = Session["UserName"].ToString();
                Model.RTKUserInfo rtkUserInfo = new Model.RTKUserInfo();
                rtkUserInfo = DAL.RTKUserInfo.GetModel(Session["UserName"].ToString());
                userType.InnerText = "RTK作业用户";
                registerTime.InnerText = rtkUserInfo.RegTime.ToString("yyyy-MM-dd HH:mm:ss");
                email.InnerText = cs.HideCharShow.StrReplaceByStar(rtkUserInfo.ContactEmail, 3, 5, "*");
                phone.InnerText = cs.HideCharShow.StrReplaceByStar(rtkUserInfo.ContactPhone, 4, 7, "*");
                qualificationStatus.InnerText = "资质认证通过";
                company_update.Visible = false;
             

                Model.RegisterUser registerUser = new Model.RegisterUser();
                registerUser = DAL.RegisterUser.GetModel(rtkUserInfo.RegisterUserName);
                try
                {
                    Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(registerUser.CertifiationIndex));
                    company.InnerText = companyInfo.Company;
                    
                }
                catch
                {
                    company.InnerText = "未绑定";
                }
            }

            #endregion


        }
    }
}