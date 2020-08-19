using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.publicforms.download
{
    public partial class ResourceDownload : System.Web.UI.Page
    {
        public string linkstr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.Host;
            string port = HttpContext.Current.Request.Url.Port.ToString();
            DataSet ds = DAL.ResourcesDownload.GetFullList("1=1");
            string template = " <li><a href=\"@href\"download=\"@download\" style=\"font-size: x-large\">@content</a></li>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string rsPath = ds.Tables[0].Rows[i]["ResourcePath"].ToString();
                string rsFullName = rsPath.Substring(rsPath.LastIndexOf('\\') + 1);
                string rsDisplayName = ds.Tables[0].Rows[i]["ResourceName"].ToString();
                string temp = template;
                //temp = temp.Replace("@href",url+port+@"\ResourceDownload\"+rsFullName);
                temp = temp.Replace("@href", @"../../..\upload\ResourceDownload\" + rsFullName);
                temp = temp.Replace("@download", rsFullName);
                temp = temp.Replace("@content", rsDisplayName);
                linkstr += temp;
            }
        }
    }
}