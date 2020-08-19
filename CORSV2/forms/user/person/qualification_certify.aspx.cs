using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.person
{
    public partial class qualification_certify : System.Web.UI.Page
    {

        public static string corporate_id_card_front = "";
        public static string corporate_id_card_reverse = "";
        public static string secrecy_agreement_path = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "qjzql";
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
            }
        }
        private void company_judge(string company_name)
        {
            string json = "{\"code\":200}";
            Response.Write(json);
            Response.End();
        }
        private int AddData()
        {
            string fileid = Request["field"];
            string filename = Request.Files[0].FileName;
            string[] extname = filename.Split('.');
            string savepath = Server.MapPath("~/upload/Qualification/") + DateTime.Now.ToString("yyyMMddhhmmssfff") + "." + extname[extname.Length - 1];
            Request.Files[0].SaveAs(savepath + filename);
            switch (Request["field"])
            {

                case "corporate_id_card_front":
                    corporate_id_card_front = "/upload/Qualification/" + DateTime.Now.ToString("yyyMMddhhmmssfff") + "." + extname[extname.Length - 1];
                    break;
                case "corporate_id_card_reverse":
                    corporate_id_card_reverse = "/upload/Qualification/" + DateTime.Now.ToString("yyyMMddhhmmssfff") + "." + extname[extname.Length - 1];
                    break;

                case "secrecy_agreement_path":
                    secrecy_agreement_path = "/upload/Qualification/" + DateTime.Now.ToString("yyyMMddhhmmssfff") + "." + extname[extname.Length - 1];
                    break;

                default:
                    break;
            }
            return 1;
        }

        private int Verifycompanyform()
        {
            Model.PersonInfo personinfo = new Model.PersonInfo();
            personinfo.BelongArea = Request.Form["city"];
            personinfo.Contact = Request.Form["contact_name"];
            personinfo.ContactIDCardFile = corporate_id_card_front;
            personinfo.ContactIDCardNumber = corporate_id_card_reverse;
            DAL.PersonInfo.Add(personinfo);
            Model.PersonInfo temp_personinfo = DAL.PersonInfo.GetModel();
            Model.RegisterUser registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
            registeruser.CertifiationIndex = temp_personinfo.ID.ToString();
            registeruser.CertifiationStatus = 3;
            DAL.RegisterUser.Update(registeruser);
            string json = "{\"code\":200}";
            Response.Write(json);
            Response.End();
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
            return 1;
        }
    }
}