using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class SoftWare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                Model.SoftWare md = DAL.SoftWare.GetModel(int.Parse(id));
                IDS.Value = md.ID.ToString(); ;
                SoftWareName.Value = md.SoftWareName;
                dType.Value = md.Type;
                SoftWareType.Value = md.SoftWareType;

                IP.Value = md.IP;
                Num.Value = md.Num;
                Maintenance.Value = md.Maintenance;
                Config.Value = md.Config;
            }
            else
            {
                if (Request["action"] == "save")
                {
                    Model.SoftWare ms = new Model.SoftWare();
                    ms.Config = Request.Form["Config"].ToString();
                    ms.IP = Request.Form["IP"].ToString();
                    ms.Maintenance = Request.Form["Maintenance"].ToString();
                    ms.Num = Request.Form["Num"].ToString();
                    ms.SoftWareName = Request.Form["SoftWareName"].ToString();
                    ms.SoftWareType = Request.Form["SoftWareType"].ToString();
                    ms.Time = DateTime.Now;
                    ms.Type = Request.Form["dType"].ToString();
                    ms.IsShow = "1";

                    Model.SoftWare msold = DAL.SoftWare.GetModel(int.Parse(Request.Form["IDS"].ToString()));
                    msold.IsShow = "0";
                    if (DAL.SoftWare.Add(ms) && DAL.SoftWare.Update(msold))
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

        }
    }
}