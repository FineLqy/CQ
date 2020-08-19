using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class InternetEquipAdd : System.Web.UI.Page
    {
        public static int IDD;
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
                    IDD = int.Parse(Request["ID"].ToString());
                }
            }
            else
            {
                if (Request["action"] == "save")
                {

                    Model.InternetInfoEquip MI = new Model.InternetInfoEquip();
                    MI.IP = Request.Form["IP"].ToString();
                    MI.Port = Request.Form["Port"].ToString();
                    MI.MachineName = Request.Form["MachineName"].ToString();
                    MI.Logo = Request.Form["Logo"].ToString();
                    MI.Remark = Request.Form["Remark"].ToString();
                    MI.EUse = Request.Form["EUse"].ToString();
                    if (DAL.InternetInfoEquip.Exists(MI.MachineName))
                    {
                        Response.Clear();
                        Response.Write("2");
                        Response.End();
                        return;
                    }
                    else
                    {
                        bool result = DAL.InternetInfoEquip.Add(MI);
                        if (result)
                        {
                            Model.InternetInformation MII = DAL.InternetInformation.GetModel(IDD);
                            MII.EquipmentID += DAL.InternetInfoEquip.GetModel(MI.MachineName).ID + ";";
                            DAL.InternetInformation.Update(MII);

                            Response.Clear();
                            Response.Write("1");
                            Response.End();
                            return;
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