using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebGNSS
{
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           DataSet ds= DAL.News.GetList();
            this.Repeater1.DataSource = ds.Tables[0];
            this.Repeater1.DataBind();
        }
    }
}