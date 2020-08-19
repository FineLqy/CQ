using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.administrator.information
{
    public partial class DataCenterManage : System.Web.UI.Page
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
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetEquips())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteEquips")
            {
                DeleteEquips();
            }
            if (Request["action"] != null && Request["action"] == "AddEquip")
            {
                AddEquip();
            }
        }
        private void AddEquip()
        {
            var cont = Request["equip"].ToString();
            Content content = CORSV2.cs.JSONHelper.JSONToObject<Content>(cont);
            if (DAL.DataCenter.Exists(content.SerialNumber, 1))
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }
            else
            {
                Model.DataCenter md = new Model.DataCenter();
                md.DeviceType = content.DeviceType;
                md.Type = content.dType;
                md.SerialNumber = content.SerialNumber;
                md.IP = content.IP;
                md.Port = content.Port;
                md.Business = content.Business;
                bool r = DAL.DataCenter.Add(md);
                if (r)
                {
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Write("2");
                    Response.End();
                }
            }


        }
        public class Content
        {
            public Content()
            { }
            public Content(string Business, string IP, string Port, string SerialNumber, string dType, string DeviceType)
            {
                this.DeviceType = DeviceType;
                this.dType = dType;
                this.SerialNumber = SerialNumber;
                this.IP = IP;
                this.Port = Port;
                this.Business = Business;
            }

            public string DeviceType { get; set; }
            public string dType { get; set; }
            public string SerialNumber { get; set; }
            public string IP { get; set; }
            public string Port { get; set; }
            public string Business { get; set; }

        }
        private bool GetEquips()
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

            int totalCount = DAL.DataCenter.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.DataCenter.GetBriefList(offset, limit, search);

            ds.Tables[0].Columns.Add("button", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["button"] = "<a id='" + dr["SerialNumber"] + "' onclick= viewDevice(this.id) >查看</a>";
            }
            string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
            result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
            Response.ContentType = "application/Json";
            Response.Write(result);
            Response.End();
            if (ds.Tables[0].Rows.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        private void DeleteEquips()
        {
            int[] ids;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            ids = new int[temp.Length];
            try
            {
                for (int m = 0; m < temp.Length; m++)
                {
                    ids[m] = Convert.ToInt32(temp[m]);
                    Model.DataCenter md = DAL.DataCenter.GetModel(ids[m]);
                    bool resultd = DAL.DataCenter.Delete(md.SerialNumber);


                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = Session["UserName"].ToString();
                    mSysLog.Remark = "管理员删除了设备:" + md.DeviceType + "序列号为:" + md.SerialNumber;
                    DAL.SysLog.Add(mSysLog);

                }
                Response.Clear();
                Response.Write("1");
                Response.End();
            }
            catch (Exception)
            {


            }

        }
    }
}