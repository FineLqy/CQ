using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class ServerConfigSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["action"] != "" && Request["action"] == "save")
            {
                save();
            }
            if (!IsPostBack)
            {
                if (Request["ServerName"] != null)
                {

                    Session["ServerName"] = Request["ServerName"].ToString();
                    Model.ServiceConfiguration serviceConfiguration = DAL.ServiceConfiguration.GetModel(Session["ServerName"].ToString());

                  ServerName.Value=serviceConfiguration.ServerName;
                    Price.Value = serviceConfiguration.Price.ToString();
                   paymentMethod.Value=  serviceConfiguration.paymentMethod.ToString();
                    ProductDescription.Value= serviceConfiguration.ProductDescription;

                }
              
            }


        }
        public void save()
        {


            Model.ServiceConfiguration service = DAL.ServiceConfiguration.GetModel(Session["ServerName"].ToString());
            service.ServerName=ServerName.Value;
            service.paymentMethod = paymentMethod.Value;
            service.Price =Convert.ToSingle( Price.Value);
            service.ProductDescription = ProductDescription.Value;
           




            DAL.ServiceConfiguration.Update(service);

          



            Response.Clear();
            Response.Write("1");
            Response.End();
        }
    }
}