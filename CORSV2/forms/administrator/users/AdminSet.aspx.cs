using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.users
{
    public partial class AdminSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] == null)
            {
                string id = Request["id"];
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(int.Parse(id));
                userName.Value = registerUser.UserName;
                belongArea.Value = registerUser.BelongArea;
                oldPassword.Value = registerUser.PassWord;
            }
            if(Request["action"]!=null)
            {
                string inf = Request["action"].ToString().Trim();
                string[] a = inf.Split('}');
                if (a.Length == 2 && a[1] != "")
                {
                    //string usr = a[1];
                    //string pas = a[2];
                    string tempPassWord = AES_Key.AESEncrypt(a[1], a[0].PadLeft(16, '0'));
                   // string aa = AES_Key.AESDecrypt(tempPassWord, a[0].PadLeft(16, '0'));
                    Model.RegisterUser registerUser= DAL.RegisterUser.GetModel(a[0]);

                    registerUser.PassWord = tempPassWord;


                    DAL.RegisterUser.Update(registerUser);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Write("0");
                    Response.End();
                }
            }
        }
    }
}