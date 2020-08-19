using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.administrator.information
{
    public partial class StationEquipAdd : System.Web.UI.Page
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

                    Model.StationEquip se = new Model.StationEquip();
                    string time = Request.Form["InstallationDate"].ToString();
                    string dtime = DateTime.Now.ToString();
                    se.InstallationDate = DateTime.Parse(dtime);
                    se.MachineName = Request.Form["MachineName"].ToString();
                    se.Models = Request.Form["Models"].ToString();
                    se.SerialNumber = Request.Form["SerialNumber"].ToString();


                    bool result = DAL.StationEquip.Add(se);
                    if (result)
                    {
                        Model.EquipmentInfo MII = DAL.EquipmentInfo.GetModel(IDD);
                        DataSet ds = DAL.StationEquip.GetList("InstallationDate='" + dtime + "'");

                        MII.EquipID += ds.Tables[0].Rows[0]["ID"].ToString() + ";";
                        se.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                        DAL.EquipmentInfo.Update(MII);
                        try
                        {
                            se.InstallationDate = DateTime.Parse(time);
                        }
                        catch (Exception)
                        {


                        }
                        DAL.StationEquip.Update(se);
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