using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.system
{
    public partial class ServiceConfig : System.Web.UI.Page
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


            int totalCount = DAL.ServiceConfiguration.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.ServiceConfiguration.GetBriefList(offset, limit, search);
             ds.Tables[0].Columns.Add("InsertDate1", typeof(string));
            ds.Tables[0].Columns.Add("Update", typeof(string));
          
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["InsertDate1"] = dr["InsertDate"].ToString(); ;
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
                dr["Update"] = "<button  id='" + dr["ServerName"] + "' onclick= viewDevice(this.id) >编辑</button>";
               
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

                bool result = DAL.ServiceConfiguration.Delete(name);
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
                mSysLog.Remark = "管理员删除了产品配置：" + name;
                DAL.SysLog.Add(mSysLog);



            }
            catch (Exception)
            {


            }

        }

        private void AddStas()
        {

            Model.ServiceConfiguration ServiceConfig = new Model.ServiceConfiguration();
            ServiceConfig.ServerName = Request.Form["ServerName"].ToString();
            ServiceConfig.Price =Convert.ToSingle( Request.Form["Price"].ToString());
            ServiceConfig.ProductDescription = Request.Form["ProductDescription"].ToString();
            ServiceConfig.InsertDate = DateTime.Now; 
            ServiceConfig.paymentMethod = Request.Form["paymentMethod"].ToString();
        
            if (DAL.ServiceConfiguration.Exists(ServiceConfig.ServerName) )
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }
            else
            {
               
                try
                {
                    DAL.ServiceConfiguration.Add(ServiceConfig);
                  
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
                mSysLog.Remark = "管理员添加产品配置：" + ServiceConfig.ServerName + "的信息";
                DAL.SysLog.Add(mSysLog);
            }

        }
    }
}