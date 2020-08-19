using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace CORSV2.forms.administrator.information
{
    public partial class StationNetManage : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {

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
            if (Request["action"] != null && Request["action"] == "add")
            {
                Add();
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


            int totalCount = DAL.StationNetInfo.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.StationNetInfo.GetBriefList(offset, limit, search);
            ds.Tables[0].Columns.Add("button", typeof(string));

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";

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
            int[] ids;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            ids = new int[temp.Length];
            try
            {
                for (int m = 0; m < temp.Length; m++)
                {
                    ids[m] = Convert.ToInt32(temp[m]);
                    Model.StationNetInfo ms = DAL.StationNetInfo.GetModel(ids[m]);



                    string name = ms.NetName;
                    DAL.StationNetInfo.Delete(ids[m]);




                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = Session["UserName"].ToString();
                    mSysLog.Remark = "管理员删除了站网：" + name;
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
        private void Add()
        {
            var cont = Request["net"].ToString();
            Content content = CORSV2.cs.JSONHelper.JSONToObject<Content>(cont);
            Model.StationNetInfo MS = new Model.StationNetInfo();
            MS.IP = content.IP;
            MS.Port = content.Port;
            MS.NetName = content.NetName;
            MS.NetworkProtocol = content.NetworkProtocol;
            MS.SourceNode = content.SourceNode;
            MS.Number = content.Number;
            string[] sys = content.SatelliteSystem.Split(' ');
            string SateSys = "";
            foreach (string s in sys)
            {
                if (s != "")
                {
                    SateSys += (s + ';');
                }
            }
            MS.SatelliteSystem = SateSys;
            MS.ServiceContent = content.ServiceContent;
            if (DAL.StationNetInfo.Exists(MS.NetName))
            {
                Response.Clear();
                Response.Write("2");
                Response.End();
                return;
            }
            else
            {
                bool result = DAL.StationNetInfo.Add(MS);
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
        public class Content
        {
            public Content()
            { }
            public Content(string NetName, string Number, string NetworkProtocol, string SourceNode, string IP, string Port, string ServiceContent, string SatelliteSystem)
            {
                this.NetName = NetName;
                this.NetworkProtocol = NetworkProtocol;
                this.SourceNode = SourceNode;
                this.IP = IP;
                this.Port = Port;
                this.ServiceContent = ServiceContent;
                this.SatelliteSystem = SatelliteSystem;
                this.Number = Number;
            }
            public string Number { get; set; }
            public string NetName { get; set; }
            public string NetworkProtocol { get; set; }
            public string SourceNode { get; set; }
            public string IP { get; set; }
            public string Port { get; set; }
            public string ServiceContent { get; set; }
            public string SatelliteSystem { get; set; }


        }
    }
}