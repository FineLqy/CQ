using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.company
{

    public partial class qualification_Update : System.Web.UI.Page
    {
        public static string map_qualification_path = "";
        public static string business_licence_path = "";
        public static string corporate_id_card_front = "";
        public static string corporate_id_card_reverse = "";
        public static string operator_id_card_front = "";
        public static string operator_id_card_reverse = "";
        public static string secrecy_agreement_path = "";
        public static string client_authorization_path = "";
        public static string Service_agreement_path = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "hencors";
            //Session["UserType"] = "1";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }

            if (Request["action"] != "" && Request["action"] == "AddData")
            {
                AddData();
            }
            if (Request["action"] != "" && Request["action"] == "save")
            {
                save();
            }
            if (!IsPostBack)
            {

                int companyCertifiationIndex = Convert.ToInt32(DAL.RegisterUser.GetModel(Session["UserName"].ToString()).CertifiationIndex);

                //根据注册用户的认证id索引加载页面信息
                Model.CompanyInfo companyinfo = DAL.CompanyInfo.GetModel(companyCertifiationIndex);
                company_name.Value = companyinfo.Company;
                map_qualification_path_file_.Src = companyinfo.SurveyingFile;
                switch (companyinfo.Industry)
                {
                    case "1":
                        type_id.Value = "测绘资质单位";
                        break;
                    case "2":
                        type_id.Value = "政府机构";
                        break;
                    case "3":
                        type_id.Value = "仪器公司";
                        break;
                    case "4":
                        type_id.Value = "高校/科研院所";
                        break;
                    default:
                        type_id.Value = "其他非测绘资质执证单位";
                        break;
                }
                maplevel.Value = companyinfo.SurveyingQualification;
                map_qualification_sn.Value = companyinfo.SurveyingNumber;
                corporate.Value = companyinfo.LegalPerson;
                corporate_tel.Value = companyinfo.CompanyTel;
                business_licence.Value = companyinfo.OrganizationCode;
                address.Value = companyinfo.Address;
                business_licence_path_file_.Src = companyinfo.BusinessLicense;
                corporate_id_card_front_file_.Src = companyinfo.LegalIDCardFile;
                secrecy_agreement_path_file_.Src = companyinfo.ServiceAgreementFile;
                client_authorization_path_file_.Src = companyinfo.PowerOfAttorney;


                contact_name.Value = companyinfo.Contact;
                //contact_phone.Value = companyinfo.CompanyTel;
                phone.Value = companyinfo.CompanyTel;
                //string res = cs.JSONHelper.ObjectToJSON(companyinfo);


            }


        }


        public int AddData()
        {
            string fileid = Request["field"];
            string filename = Request.Files[0].FileName;
            string[] extname = filename.Split('.');
            string temptime = DateTime.Now.ToString("yyyMMddhhmmssfff");
            string savepath = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + temptime + "." + extname[extname.Length - 1];
            Request.Files[0].SaveAs(savepath);
            switch (Request["field"])
            {
                case "map_qualification_path":
                    map_qualification_path = "/upload/Qualification/" + Session["UserName"].ToString() + "_map" + temptime + "." + extname[extname.Length - 1];
                    break;
                case "business_licence_path":
                    business_licence_path = "/upload/Qualification/" + Session["UserName"].ToString() + "_business" + temptime + "." + extname[extname.Length - 1];
                    break;
                case "corporate_id_card_front":
                    corporate_id_card_front = "/upload/Qualification/" + Session["UserName"].ToString() + "_corporate" + temptime + "." + extname[extname.Length - 1];
                    break;
                case "corporate_id_card_reverse":
                    corporate_id_card_reverse = "/upload/Qualification/" + Session["UserName"].ToString() + "_corporate_id" + temptime + "." + extname[extname.Length - 1];
                    break;
                case "operator_id_card_front":
                    operator_id_card_front = "/upload/Qualification/" + Session["UserName"].ToString() + "_card_front" + temptime + "." + extname[extname.Length - 1];
                    break;
                case "operator_id_card_reverse":
                    operator_id_card_reverse = "/upload/Qualification/" + Session["UserName"].ToString() + "_card_reverse" + temptime + "." + extname[extname.Length - 1];
                    break;
                case "secrecy_agreement_path":
                    secrecy_agreement_path = "/upload/Qualification/" + Session["UserName"].ToString() + "_secrecy" + temptime + "." + extname[extname.Length - 1];
                    break;

                case "client_authorization_path":
                    client_authorization_path = "/upload/Qualification/" + Session["UserName"].ToString() + "client" + temptime + "." + extname[extname.Length - 1];
                    break;
                default:
                    break;
            }
            return 1;
        }

        public void save()
        {
            int companyCertifiationIndex = Convert.ToInt32(DAL.RegisterUser.GetModel(Session["UserName"].ToString()).CertifiationIndex);

            Model.CompanyInfo updateinfo = DAL.CompanyInfo.GetModel(companyCertifiationIndex);
            updateinfo.Company = company_name.Value;
            type_id.SelectedIndex = Convert.ToInt32(updateinfo.Industry) - 1;

            switch (type_id.Value)
            {
                case "测绘资质单位":
                    updateinfo.Industry = "1";
                    break;
                case "政府机构":
                    updateinfo.Industry = "2";
                    break;
                case "仪器公司":
                    updateinfo.Industry = "3";
                    break;
                case "科研院所":
                    updateinfo.Industry = "4";
                    break;
                case "其他非测绘资质执证单位":

                    updateinfo.Industry = "5";
                    break;
            }
            updateinfo.SurveyingQualification = maplevel.Value;
            updateinfo.SurveyingNumber = map_qualification_sn.Value;
            updateinfo.LegalPerson = corporate.Value;
            updateinfo.CompanyTel = corporate_tel.Value;
            updateinfo.OrganizationCode = business_licence.Value;
            updateinfo.Address = address.Value;
            updateinfo.Industry = type_id.Value;
            updateinfo.Contact = contact_name.Value;
            //contact_phone.Value = companyinfo.CompanyTel;
            updateinfo.CompanyTel = phone.Value;
            updateinfo.ID = companyCertifiationIndex;

            if (business_licence_path == "")
            {
                updateinfo.BusinessLicense = business_licence_path_file_.Src;
               
            }
            else
            {
                updateinfo.BusinessLicense = business_licence_path;
               
            }

            if (corporate_id_card_front == "")
            {
                updateinfo.LegalIDCardFile = corporate_id_card_front_file_.Src;
              
            }
            else
            {
                updateinfo.LegalIDCardFile = corporate_id_card_front;
              


            }
            if (map_qualification_path == "")
            {
                updateinfo.SurveyingFile = map_qualification_path_file_.Src;
            }
            else
            {
                updateinfo.SurveyingFile = map_qualification_path;
            }
            if (secrecy_agreement_path=="")
            {
                updateinfo.ServiceAgreementFile = secrecy_agreement_path_file_.Src;
            }
            else
            {
                updateinfo.ServiceAgreementFile = secrecy_agreement_path;
            }
            if (client_authorization_path=="")
            {
                updateinfo.PowerOfAttorney = client_authorization_path_file_.Src;
            }
            else
            {
                updateinfo.PowerOfAttorney = client_authorization_path;
            }

                  
                    DAL.CompanyInfo.Update(updateinfo);

                    Model.RegisterUser registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                    registeruser.CertifiationStatus = 1;
                    DAL.RegisterUser.Update(registeruser);
         
       

            Response.Clear();
                    Response.Write("1");
                    Response.End();
                }

    }
        

    }
