using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace CORSV2.forms.administrator.information
{
    public partial class SoftwareManage : System.Web.UI.Page
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
            if (Request["action"] != null && Request["action"] == "AddSoftWare")
            {
                AddEquip();
            }
        }
        private void AddEquip()
        {
            var cont = Request["equip"].ToString();
            Content content = CORSV2.cs.JSONHelper.JSONToObject<Content>(cont);

            Model.SoftWare md = new Model.SoftWare();
            md.SoftWareType = content.SoftWareType;
            md.Type = content.dType;
            md.Config = content.Config;
            md.Maintenance = content.Maintenance;
            md.SoftWareName = content.SoftWareName;
            md.Num = content.Num;
            md.IP = content.IP;
            md.Time = DateTime.Now;
            md.IsShow = "1";
            bool r = DAL.SoftWare.Add(md);
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
        public class Content
        {
            public Content()
            { }
            public Content(string SoftWareType, string dType, string Config, string Maintenance, string SoftWareName, string IP, string Num)
            {
                this.SoftWareType = SoftWareType;
                this.dType = dType;
                this.Config = Config;
                this.Maintenance = Maintenance;
                this.SoftWareName = SoftWareName;
                this.IP = IP;
                this.Num = Num;

            }

            public string SoftWareType { get; set; }
            public string dType { get; set; }
            public string Config { get; set; }
            public string Maintenance { get; set; }
            public string SoftWareName { get; set; }
            public string IP { get; set; }
            public string Num { get; set; }

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

            int totalCount = DAL.SoftWare.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.SoftWare.GetBriefList(offset, limit, search);

            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("dTime", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["dTime"] = dr["Time"].ToString();
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= viewDevice(this.id) >查看</a>";
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
                    Model.SoftWare md = DAL.SoftWare.GetModel(ids[m]);
                    bool resultd = DAL.SoftWare.Delete(md.ID);


                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = Session["UserName"].ToString();
                    mSysLog.Remark = "管理员删除了软件:" + md.SoftWareType;
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