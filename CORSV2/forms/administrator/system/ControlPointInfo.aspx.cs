using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class ControlPointInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                string id = null;
                id = Request["id"];
                pointid.Value = id.ToString();
                Model.ControlPoint mcp = DAL.ControlPoint.GetModel(int.Parse(id.ToString()));
                MarkName.Value = mcp.MarkName;
                MarkID.Value = mcp.MarkID;
                BZ.Value = mcp.BZ;
                AccuracyClass.Value = mcp.AccuracyClass;
                GCgrade.Value = mcp.GCgrade;
                if (mcp.PointRemark == "" || mcp.PointRemark == null)
                {
                    viewPointRemark.Disabled = true;
                }
                B.Value = mcp.B.ToString();
                L.Value = mcp.L.ToString();
                try
                {
                    H.Value = mcp.H.ToString();
                }
                catch (Exception)
                {


                }
                PointRemark.Value = mcp.PointRemark;

            }
            else
            {
                if (Request["upload"] == "PointRemark")
                {
                    string filename = Request.Files["FilePointRemark"].FileName;
                    string MarkName = Request.Form["MarkName"].ToString().Trim();
                    int ids = int.Parse(Request.Form["pointid"].ToString());
                    string[] filenames = filename.Split('.');
                    Request.Files["FilePointRemark"].SaveAs(Server.MapPath("~/upload/PointRemark/") + MarkName + "." + filenames[filenames.Length - 1]);
                    Model.ControlPoint mcp = DAL.ControlPoint.GetModel(ids);
                    mcp.PointRemark = "/upload/PointRemark/" + MarkName + "." + filenames[filenames.Length - 1];
                    DAL.ControlPoint.Update(mcp);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["action"] == "save")
                {
                    int ids = int.Parse(Request.Form["pointid"].ToString());
                    Model.ControlPoint mcp = DAL.ControlPoint.GetModel(ids);
                    mcp.MarkID = Request.Form["MarkID"].ToString().Trim();
                    mcp.MarkName = Request.Form["MarkName"].ToString().Trim();
                    mcp.AccuracyClass = Request.Form["AccuracyClass"].ToString().Trim();
                    mcp.BZ = Request.Form["BZ"].ToString().Trim();
                    mcp.GCgrade = Request.Form["GCgrade"].ToString().Trim();
                    mcp.B = double.Parse(Request.Form["B"].ToString().Trim());
                    mcp.L = double.Parse(Request.Form["L"].ToString().Trim());
                    mcp.H = double.Parse(Request.Form["H"].ToString().Trim());
                    DAL.ControlPoint.Update(mcp);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
            }
        }
    }
}