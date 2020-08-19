using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class Internetequipset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    int id = int.Parse(Request["ID"].ToString());
                    Model.InternetInfoEquip MIE = DAL.InternetInfoEquip.GetModel(id);
                    MachineName.Value = MIE.MachineName;
                    IP.Value = MIE.IP;
                    Port.Value = MIE.Port;
                    EUse.Value = MIE.EUse;
                    Logo.Value = MIE.Logo;
                    Remark.Value = MIE.Remark;
                    IDs.Value = MIE.ID.ToString();
                }
            }
            else
            {
                if (Request["action"] == "save")
                {
                    int id = int.Parse(Request.Form["IDs"].ToString());
                    Model.InternetInfoEquip MI = DAL.InternetInfoEquip.GetModel(id);
                    MI.IP = Request.Form["IP"].ToString();
                    MI.Port = Request.Form["Port"].ToString();
                    MI.MachineName = Request.Form["MachineName"].ToString();
                    MI.Logo = Request.Form["Logo"].ToString();
                    MI.Remark = Request.Form["Remark"].ToString();
                    MI.EUse = Request.Form["EUse"].ToString();
                    Model.InternetInfoEquip MI2 = DAL.InternetInfoEquip.GetModel(MI.MachineName);
                    if (MI2 != null)
                    {
                        if (MI2.ID != MI.ID)
                        {
                            Response.Clear();
                            Response.Write("2");
                            Response.End();
                            return;
                        }
                        else
                        {
                            bool result = DAL.InternetInfoEquip.Update(MI);
                            if (result)
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
                    else
                    {
                        bool result = DAL.InternetInfoEquip.Update(MI);
                        if (result)
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
}