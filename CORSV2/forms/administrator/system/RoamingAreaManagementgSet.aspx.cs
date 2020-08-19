using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class RoamingAreaManagementgSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          
            if (!IsPostBack)
            {
                if (Request["GroupName"] != null)
                {

                    Session["GroupName"] = Request["GroupName"].ToString();
                    Model.RoamingAreaManagement RoamingArea  = DAL.RoamingAreaManagement.GetModel(Session["GroupName"].ToString());

                    GroupName.Value = RoamingArea.GroupName;
                    Remark.Value = RoamingArea.Remark.ToString();
                    GroupRange.Value = RoamingArea.GroupRange.ToString();
                    



                }

            }


        }
        public void save()
        {


            Model.RoamingAreaManagement management  = DAL.RoamingAreaManagement.GetModel(Session["GroupName"].ToString());
            management.GroupName = GroupName.Value;
            management.Remark = Remark.Value;
            management.GroupRange = GroupRange.Value;
          





            DAL.RoamingAreaManagement.Update(management);





            Response.Clear();
            Response.Write("1");
            Response.End();
        }
    }
}