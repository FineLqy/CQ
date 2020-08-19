using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class AddPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] == "save")
            {

                Model.ControlPoint mcp = new Model.ControlPoint();
                mcp.MarkID = Request.Form["MarkID"].ToString().Trim();
                mcp.MarkName = Request.Form["MarkName"].ToString().Trim();
                mcp.AccuracyClass = Request.Form["AccuracyClass"].ToString().Trim();
                mcp.BZ = Request.Form["BZ"].ToString().Trim();
                mcp.GCgrade = Request.Form["GCgrade"].ToString().Trim();
                mcp.B = double.Parse(Request.Form["B"].ToString().Trim());
                mcp.L = double.Parse(Request.Form["L"].ToString().Trim());
                mcp.H = double.Parse(Request.Form["H"].ToString().Trim());
                if (DAL.ControlPoint.Exists(mcp.MarkName))
                {
                    Response.Clear();
                    Response.Write("2");
                    Response.End();
                    return;
                }
                else
                {
                    bool result = DAL.ControlPoint.Add(mcp);
                    if (result)
                    {


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