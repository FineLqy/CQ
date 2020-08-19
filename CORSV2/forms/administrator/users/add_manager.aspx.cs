using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.users
{
    public partial class add_manager : System.Web.UI.Page
    {

        public static string userName = "";
        public static Model.RegisterUser registerUser = new Model.RegisterUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            userName = Session["UserName"].ToString();
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

            if (Request["actionAdd"] != null)
            {
               
                string inf = Request["actionAdd"].ToString().Trim();
                string[] a = inf.Split('}');
                if (a.Length == 3 && a[0] != "" && a[1] != "")
                {
                    string usr = a[0];
                    //string tempPassWord = AES_Key.AESEncrypt(a[1], a[0].PadLeft(16, '0'));
                    //string aa = AES_Key.AESDecrypt(tempPassWord, a[0].PadLeft(16, '0'));
                    if (DAL.RegisterUser.Exists(a[0]))
                    {
                        Response.Write("2");
                        Response.End();
                    }
                    Model.RegisterUser registerUser = new Model.RegisterUser();                  
                    registerUser.UserName = a[0];
                    registerUser.PassWord = AES_Key.AESEncrypt(a[1], a[0].PadLeft(16, '0'));
                    registerUser.UserType = 2;
                    registerUser.BelongArea = a[2];
                    registerUser.CertifiationStatus = 2;
                    DAL.RegisterUser.Add(registerUser);
                    Response.Write("1");
                    Response.End();
                }
            }
            //if (Request["action"] != null && Request["action"].ToString() == "checkPassword")
            //{
            //    registerUser = DAL.RegisterUser.GetModel(userName);
            //    if (registerUser.PassWord != Request["old_password"].ToString())
            //    {
            //        Response.Write("旧密码输入错误");
            //        Response.End();
            //    }
            //    else
            //    {
            //        Response.Write("true");
            //        Response.End();
            //    }
            //}
            //if (Request["action"] != null && Request["action"].ToString() == "changePassword")
            //{
            //    registerUser.PassWord = Request["new_password"].ToString();
            //    DAL.RegisterUser.Update(registerUser);

            //    Response.Write("{\"code\":200}");
            //    Response.End();
            //}
        }
    }
}