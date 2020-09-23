using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms
{
    public partial class cors_user : System.Web.UI.Page
    {
        public static string unreadMailNum = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "qjzql";
            //Session["UserType"] = "3";

            //Session["UserName"] = "qjzql";
            //Session["UserType"] = "1";
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");parent.window.location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
             if (Convert.ToInt32(Session["UserType"]) ==0 )
             {
                 businessManage.Style.Add("display","none");
                 userManage.Style.Add("display", "none");
                 qualification.Style.Add("display", "none");
             }
             //如果是普通平台用户登录的时候则不显示数据处理
             else
             {
                 dataProcess.Style.Add("display", "none");
             }

            if (Request["action"] == "username_judge")
            {
                Model.RegisterUser registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                if (registeruser.CertifiationStatus == 2 || registeruser.CertifiationStatus == 4)
                {
                    //location.href = location.origin+\"/forms/cors.aspx\";
                    Response.Write("OK");
                    Response.End();
                }
                else if (registeruser.CertifiationStatus == 1)
                {
                    Response.Write("checking");
                    Response.End();
                }
                else if (registeruser.CertifiationStatus == 6)
                {
                    Response.Write("changeing");
                    Response.End();
                }

                else
                {
                    Response.Write("NO");
                    Response.End();
                }
            }


            if (Request["action"] == "checkQualification")
            {
                Model.RegisterUser registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                if (registeruser.CertifiationStatus == 2 || registeruser.CertifiationStatus == 4)
                {
                    //location.href = location.origin+\"/forms/cors.aspx\";
                    Response.Write("OK");
                    Response.End();
                }
                else if(registeruser.CertifiationStatus==1)
                {
                    Response.Write("checking");
                    Response.End();
                }
                else if (registeruser.CertifiationStatus == 6)
                {
                    Response.Write("changeing");
                    Response.End();
                }

                else
                {
                    Response.Write("NO");
                    Response.End();
                }
            }


            if (!IsPostBack)
            {
                UserName.InnerText = Session["UserName"].ToString();
                if (Session["UserType"].ToString() == "1")
                {
                    UserType.InnerText = "普通用户";
                }
                else
                {
                    UserType.InnerText = "RTK用户";
                }
                string strwhere = "(ToUser = '全部用户' or ToUser ='" + Session["UserName"].ToString() + "') and IsRead=0 ";

                //查询该用户收件箱里里面未读信个数

                unreadMailNum = DAL.UserMessage.GetRecordCountNew("", strwhere).ToString();

                if (unreadMailNum == "0")
                {
                    unreadMailNum = "";
                }
            }
        }
    }
}