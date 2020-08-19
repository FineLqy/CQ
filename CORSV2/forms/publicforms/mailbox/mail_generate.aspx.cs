using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.publicforms.mailbox
{
    public partial class mail_generate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["PostBack"] != null && Request["PostBack"].ToString() == "true")
            {
                if (Request["Title"] != null && Request["Title"] != "")
                {
                    string Rec = Request["Rec"];

                        if (DAL.RegisterUser.Exists(Rec) || Rec.Contains("全部用户"))
                        {
                        }
                        else
                        {
                            Response.Clear();
                            Response.Write("2");
                            Response.End();
                            return;
                        }

                    if (NewMessages())
                    {
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
            if (!IsPostBack)
            {
                try
                {
                    DataSet ds = DAL.RegisterUser.GetList("1=1");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        username.Items.Add(dr["UserName"].ToString());
                    }
                    //if (Request["action"] != null)
                    //{
                    //    string result = "";
                    //    string para = Request["action"].ToString();
                    //    string companys = para.Split('_')[1];
                    //    DAL.UserInfoWeb usi1 = new DAL.UserInfoWeb();
                    //    DataSet ddddw1 = usi1.GetList("Unit='" + companys + "'");
                    //    foreach (DataRow dr in ddddw1.Tables[0].Rows)
                    //    {
                    //        result += (dr["UserName"].ToString() + ";");
                    //    }

                    //    DataSet dddcors1 = DAL.RTK_User.GetList("Company='" + companys + "'");
                    //    foreach (DataRow dr in dddcors1.Tables[0].Rows)
                    //    {
                    //        result += (dr["UserName"].ToString() + ";");
                    //    }
                    //    Response.Clear();
                    //    Response.Write(result);
                    //    Response.End();

                    //}
                }
                catch (Exception)
                {


                }

            }
            else
            {

            }
        }
        private bool NewMessages()
        {
            try
            {
                string Title = Request["Title"];
                string Content = Request["Details"];
                string Level = Request["level"];
                string Rec = Request["Rec"];

                //如果是全部用户 则记录下来的ToUser字段就为全部用户
                Model.UserMessage mess = new Model.UserMessage();
                mess.Title = Title;
                mess.Content = Content;
                mess.level = int.Parse(Level);
                mess.IsRead = 0;
                mess.Remark = "";
                mess.FromUser = Session["UserName"].ToString();
                mess.ToUser = Rec;
                mess.SentTime = DateTime.Now;
                if (!DAL.UserMessage.Add(mess))
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Response.Write("发送失败");
                return false;
            }
        }
    }
}