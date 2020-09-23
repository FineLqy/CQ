using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.company
{
    public partial class qualification_certify : System.Web.UI.Page
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

            string UserName = Session["UserName"].ToString();
            if (Request["action"] != null)
            {
                switch (Request["action"])
                {
                    case "AddData":
                        //Response.ContentType = "text/plain";
                        AddData();
                        //Response.End();
                        break;
                    case "verifycompanyform":
                        Verifycompanyform();
                        break;
                    case "company_judge":
                        company_judge(Request["company_name"]);
                        break;

                    default:
                        break;
                }
                if (Request["action"].ToString() == "check")
                {
                    string username = Request["data"].ToString();
                    DAL.CompanyInfo du = new DAL.CompanyInfo();
                    if (DAL.CompanyInfo.Exists(username))
                    {
                        Response.Clear();
                        Response.Write("0");
                        Response.End();
                    }
                    else
                    {
                        Response.Clear();
                        Response.Write("1");
                        Response.End();

                    }
                }

            }

            if (DAL.RegisterUser.Exists(Session["UserName"].ToString()))
            {
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                if (registerUser.CertifiationStatus==5)
                {
                    try
                    {
                        Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(registerUser.CertifiationIndex));
                        company_name.Value = companyInfo.Company;
                        map_level.Value = companyInfo.SurveyingQualification;
                        map_qualification_sn.Value = companyInfo.SurveyingNumber;
                        business_licence.Value = companyInfo.OrganizationCode;
                        corporate.Value = companyInfo.LegalPerson;
                        corporate_tel.Value = companyInfo.CompanyTel;
                        province.SelectedIndex = 1;
                        city.SelectedIndex = 1;
                        town.SelectedIndex = 1;

                        address.Value = companyInfo.Address;
                        post_code.Value = "";
                        map_qualification_path_file_.Src = companyInfo.SurveyingFile;
                        map_qualification_path = companyInfo.SurveyingFile;

                        business_licence_path_file_.Src = companyInfo.BusinessLicense;
                        business_licence_path = companyInfo.BusinessLicense;

                       // corporate_id_card_front_file_.Src = companyInfo.LegalIDCardFile;
                        //corporate_id_card_front = companyInfo.LegalIDCardFile; 

                       // operator_id_card_front_file_.Src = companyInfo.ContactIDCardFile;
                      //  operator_id_card_front = companyInfo.ContactIDCardFile;


                       // client_authorization_path_file_.Src = companyInfo.PowerOfAttorney;
                       // client_authorization_path = companyInfo.PowerOfAttorney;
                        contact_name.Value = companyInfo.Contact;
                        qcphone.Value = companyInfo.CompanyTel;
                        //secrecy_agreement_path_file_.Src = companyInfo.ServiceAgreementFile;
                    }

                    catch
                    {

                    }

                }
            }




        }
        private void company_judge(string company_name)
        {
            //string username = Request["company_name"].ToString();
            //DAL.CompanyInfo du = new DAL.CompanyInfo();
            //if (DAL.CompanyInfo.Exists(username))
            //{
            //    string json = "{\"code\":100}";
            //    Response.Write(json);
            //    Response.End();
            //}
            //else
            //{
            //    string json = "{\"code\":200}";
            //    Response.Write(json);
            //    Response.End();

            //}
           
        }
        private int AddData()
        {
            string fileid = Request["field"];
            string filename = Request.Files[0].FileName;
            string[] extname = filename.Split('.');
            string temptime = DateTime.Now.ToString("yyyMMddhhmmssfff");
            
            switch (Request["field"])
            {
                case "map_qualification_path":
                    map_qualification_path = "/upload/Qualification/" + Session["UserName"].ToString() + "_map" + temptime + "." + extname[extname.Length - 1];
                    string savepath = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_map" + temptime + "." + extname[extname.Length - 1];
                    Request.Files[0].SaveAs(savepath);
                    break;
                case "business_licence_path":
                    business_licence_path = "/upload/Qualification/" + Session["UserName"].ToString() + "_business" + temptime + "." + extname[extname.Length - 1];
                    string savepath1 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_business" + temptime + "." + extname[extname.Length - 1];
                    Request.Files[0].SaveAs(savepath1);
                    break;
                //case "corporate_id_card_front":
                //    corporate_id_card_front = "/upload/Qualification/" + Session["UserName"].ToString() + "_corporate" + temptime + "." + extname[extname.Length - 1];
                //    string savepath2 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_corporate" + temptime + "." + extname[extname.Length - 1];
                //    Request.Files[0].SaveAs(savepath2);
                //    break;
                //case "corporate_id_card_reverse":
                //    corporate_id_card_reverse = "/upload/Qualification/" + Session["UserName"].ToString() + "_corporate_id" + temptime + "." + extname[extname.Length - 1];
                //    string savepath3 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_corporate_id" + temptime + "." + extname[extname.Length - 1];
                //    Request.Files[0].SaveAs(savepath3);
                //    break;
                case "operator_id_card_front":
                    operator_id_card_front = "/upload/Qualification/" + Session["UserName"].ToString() + "_card_front" + temptime + "." + extname[extname.Length - 1];
                    string savepath4 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_card_front" + temptime + "." + extname[extname.Length - 1];
                    Request.Files[0].SaveAs(savepath4);
                    break;
                case "operator_id_card_reverse":
                    operator_id_card_reverse = "/upload/Qualification/" + Session["UserName"].ToString() + "_card_reverse" + temptime + "." + extname[extname.Length - 1];
                    string savepath5 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_card_reverse" + temptime + "." + extname[extname.Length - 1];
                    Request.Files[0].SaveAs(savepath5);
                    break;
                case "secrecy_agreement_path":
                    secrecy_agreement_path = "/upload/Qualification/" + Session["UserName"].ToString() + "_secrecy" + temptime + "." + extname[extname.Length - 1];
                    string savepath6 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "_secrecy" + temptime + "." + extname[extname.Length - 1];
                    Request.Files[0].SaveAs(savepath6);
                    break;

                case "client_authorization_path":
                    client_authorization_path = "/upload/Qualification/" + Session["UserName"].ToString() + "client" + temptime + "." + extname[extname.Length - 1];
                    string savepath7 = Server.MapPath("~/upload/Qualification/") + Session["UserName"].ToString() + "client" + temptime + "." + extname[extname.Length - 1];
                    Request.Files[0].SaveAs(savepath7);
                    break;
                default:
                    break;
            }
            return 1;
        }

        private int Verifycompanyform()
        {
            Model.CompanyInfo companyinfo = new Model.CompanyInfo();
            companyinfo.Address = Request.Form["address"];
            try
            {
                companyinfo.BelongArea = Request.Form["city"];
            }
            catch
            {
                companyinfo.BelongArea = "重庆";
            }
            companyinfo.BusinessLicense = business_licence_path;
            companyinfo.Company = Request.Form["company_name"];
            companyinfo.CompanyTel = Request.Form["corporate_tel"];
            companyinfo.Contact = Request.Form["contact_name"];
            companyinfo.ContactIDCardFile = operator_id_card_front;
            companyinfo.ContactIDCardNumer = "";
            try
            {
                companyinfo.Industry = Request.Form["company_type_id"];
            }
            catch
            {
                companyinfo.Industry = "1";
            }
           // companyinfo.LegalIDCardFile = corporate_id_card_front;
            companyinfo.LegalIDCardNumber = "";
            companyinfo.LegalPerson = Request.Form["corporate"];
            companyinfo.OrganizationCode = Request.Form["business_licence"];
            //companyinfo.PowerOfAttorney = client_authorization_path;
            companyinfo.SurveyingFile = map_qualification_path;
            companyinfo.SurveyingNumber = Request.Form["map_qualification_sn"];
            //companyinfo.ServiceAgreementFile = secrecy_agreement_path;
            
            
            try
            {
                companyinfo.SurveyingQualification = Request.Form["map_level"];

            }
            catch
            {
                companyinfo.SurveyingQualification = "1";
            }
            if (DAL.CompanyInfo.Exists(companyinfo.Company))
            {
                //Response.Write(" <script>function window.onload() {alert( '该机构已认证,不能重复认证！' ); } </script> ");
               // string json = "{\"code\":200}";
                Response.Write("{\"code\":100}");
                Response.End();
                //Model.CompanyInfo companyInfo1= DAL.CompanyInfo.GetModel(companyinfo.Company);
                //companyinfo.ID = companyInfo1.ID;
                //DAL.CompanyInfo.Update1(companyinfo);

                //Model.CompanyInfo temp_companyinfo = DAL.CompanyInfo.GetModel(companyinfo.Company);
                //Model.RegisterUser registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                //registeruser.CertifiationIndex = temp_companyinfo.ID.ToString();
                //registeruser.CertifiationStatus = 1;
                //registeruser.BelongArea = companyinfo.BelongArea;
                //DAL.RegisterUser.Update(registeruser);

            }
            else
            {
                companyinfo.Balance = 0;
                DAL.CompanyInfo.Add(companyinfo);
                Model.CompanyInfo temp_companyinfo = DAL.CompanyInfo.GetModel();
                Model.RegisterUser registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                registeruser.CertifiationIndex = temp_companyinfo.ID.ToString();
                //registeruser.CertifiationIndex = temp_companyinfo.ID.ToString();
                registeruser.CertifiationStatus = 1;
                registeruser.BelongArea = companyinfo.BelongArea;
                DAL.RegisterUser.Update(registeruser);
           
            }
            string json = "{\"code\":200}";
            Response.Write(json);
            Response.End();
            return 1;


            //选择最新添加的一条数据

            //select top 1 * from tra.dbo.订单 order by 下单时间 desc   --时间倒序排列取第一条
            // companyinfo.
            //string map_level = Request.Form["map_level"];
            //string corporate = Request.Form["corporate"];
            //string province = Request.Form["province"];
            //string city = Request.Form["city"];
            //string town = Request.Form["town"];
            //string address = Request.Form["address"];
            //string post_code = Request.Form["post_code"];
            //string contact_phone = Request.Form["contact_phone"];
            //string contact_email = Request.Form["contact_email"];
            //string contact_qq = Request.Form["contact_qq"];
            //string contact_wechat = Request.Form["contact_wechat"];

        }
    }
}