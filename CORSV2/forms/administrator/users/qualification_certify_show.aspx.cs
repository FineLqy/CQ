using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.users
{
    public partial class qualification_certify_show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "hencors";
            //Session["UserType"] = "1";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            int registerId = Convert.ToInt32(Request["id"]);
            int companyCertifiationIndex = Convert.ToInt32(DAL.RegisterUser.GetModel(registerId).CertifiationIndex);
            int companyCertifiationStatus = Convert.ToInt32(DAL.RegisterUser.GetModel(registerId).CertifiationStatus);
            //根据注册用户的认证id索引加载页面信息
            Model.CompanyInfo companyinfo = DAL.CompanyInfo.GetModel(companyCertifiationIndex);
            if (companyinfo == null)
            {
                Response.Write("<script>alert('未绑定单位名')</script>");
            }
            else
            {
                company_name.Value = companyinfo.Company;
                map_qualification_path.Src = companyinfo.SurveyingFile;
                switch (companyinfo.Industry)
                {
                    case "1":
                        company_type_id.Value = "测绘资质单位";
                        break;
                    case "2":
                        company_type_id.Value = "政府机构";
                        break;
                    case "3":
                        company_type_id.Value = "仪器公司";
                        break;
                    case "4":
                        company_type_id.Value = "高校/科研院所";
                        break;
                    default:
                        company_type_id.Value = "其他非测绘资质执证单位";
                        break;
                }
                map_level.Value = companyinfo.SurveyingQualification;
                map_qualification_sn.Value = companyinfo.SurveyingNumber;
                corporate.Value = companyinfo.LegalPerson;
                corporate_tel.Value = companyinfo.CompanyTel;
                business_licence.Value = companyinfo.OrganizationCode;
                address.Value = companyinfo.Address;
                business_licence_path.Src = companyinfo.BusinessLicense;
                corporate_id_card.Src = companyinfo.LegalIDCardFile;
                operator_id_card_front.Src = companyinfo.ContactIDCardFile;
              

                secrecy_agreement_path.Src = companyinfo.ServiceAgreementFile;
                client_authorization_path.Src = companyinfo.PowerOfAttorney;
                contact_name.Value = companyinfo.Contact;
                //contact_phone.Value = companyinfo.CompanyTel;
                contactPhone.Value = companyinfo.CompanyTel;
                //string res = cs.JSONHelper.ObjectToJSON(companyinfo);
            }


        }
    }
}