using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class RoamingAreaManagement : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {

            }
            if (Request["action"] != null && Request["action"] == "add")
            {
                AddStas();
            }

            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetStas())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteStas")
            {
                DeleteStas();
            }
        }
        private bool GetStas()
        {
            string search = "";
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();


            int totalCount = DAL.RoamingAreaManagement.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.RoamingAreaManagement.GetBriefList(offset, limit, search);
            ds.Tables[0].Columns.Add("deInsertTime", typeof(string));
            ds.Tables[0].Columns.Add("Update", typeof(string));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["deInsertTime"] = dr["InsertTime"].ToString(); ;
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
                //dr["Update"] = "<button style='background-color:#35AA47;border-color:#35AA47;color:#FFFFFF;'  id='" + dr["GroupName"] + "' onclick= viewDevice(this.id) >编辑</button>";
              
   
    
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }
        private void DeleteStas()
        {
           
            string name = Request["id"];
          
            try
            {
                
                   
                  



                 

                    bool result = DAL.RoamingAreaManagement.Delete(name);
                    try
                    {


                    }
                    catch (Exception)
                    {

                    }

                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = Session["UserName"].ToString();
                    mSysLog.Remark = "管理员删除了分组：" + name;
                    DAL.SysLog.Add(mSysLog);

               
            }
            catch (Exception)
            {


            }

        }

        private void AddStas()
        {

            Model.RoamingAreaManagement roamingArea  = new Model.RoamingAreaManagement();
            roamingArea.GroupName = Request.Form["GroupName"].ToString();
            roamingArea.Remark =Request.Form["Remark"].ToString();
            roamingArea.GroupRange = Request.Form["GroupRange"].ToString();
            roamingArea.InsertTime = DateTime.Now;
         

            if (DAL.RoamingAreaManagement.Exists(roamingArea.GroupName))
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }
            else
            {

                try
                {
                    DAL.RoamingAreaManagement.Add(roamingArea);

                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                catch (Exception)
                {

                }

                Model.SysLog mSysLog = new Model.SysLog();
                mSysLog.LogTime = DateTime.Now;
                mSysLog.LogType = 0;
                mSysLog.UserName = Session["UserName"].ToString();
                mSysLog.Remark = "管理员添加分组信息：" + roamingArea.GroupName + "的信息";
                DAL.SysLog.Add(mSysLog);
            }

        }
    }
}