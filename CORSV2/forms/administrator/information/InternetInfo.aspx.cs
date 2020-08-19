using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace CORSV2.forms.administrator.information
{
    public partial class InternetInfo : System.Web.UI.Page
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
                if (!GetInternet())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteInternet")
            {
                DeleteInternet();
            }
            if (Request["action"] != null && Request["action"] == "AddInternet")
            {
                AddInternet();
            }
        }
        private void AddInternet()
        {
            var cont = Request["internet"].ToString();
            Content content = CORSV2.cs.JSONHelper.JSONToObject<Content>(cont);
            if (DAL.InternetInformation.Exists(content.nType))
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }
            else
            {
                Model.InternetInformation mi = new Model.InternetInformation();
                mi.DataLineStartP = content.DataLineStartP;
                mi.Type = content.nType;
                mi.DataLineEndP = content.DataLineEndP;
                mi.EncryptionTechnology = content.EncryptionTechnology;
                mi.BandWidth = content.BandWidth;
                mi.GreenOperator = content.GreenOperator;
                mi.TechnicalSupportStaff = content.TechnicalSupportStaff;
                bool r = DAL.InternetInformation.Add(mi);
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
            public Content(string nType, string DataLineStartP, string DataLineEndP, string EncryptionTechnology, string BandWidth, string GreenOperator, string TechnicalSupportStaff)
            {
                this.nType = nType;
                this.DataLineStartP = DataLineStartP;
                this.DataLineEndP = DataLineEndP;
                this.EncryptionTechnology = EncryptionTechnology;
                this.BandWidth = BandWidth;
                this.GreenOperator = GreenOperator;
                this.TechnicalSupportStaff = TechnicalSupportStaff;
            }

            public string nType { get; set; }
            public string DataLineStartP { get; set; }
            public string DataLineEndP { get; set; }
            public string EncryptionTechnology { get; set; }
            public string BandWidth { get; set; }
            public string GreenOperator { get; set; }
            public string TechnicalSupportStaff { set; get; }

        }
        private bool GetInternet()
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

            int totalCount = DAL.InternetInformation.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.InternetInformation.GetBriefList(offset, limit, search);

            ds.Tables[0].Columns.Add("button", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= viewInternet(this.id) >查看</a>";
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
        private void DeleteInternet()
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
                    Model.InternetInformation mi = DAL.InternetInformation.GetModel(ids[m]);
                    bool resultd = DAL.InternetInformation.Delete(ids[m]);


                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = Session["UserName"].ToString();
                    mSysLog.Remark = "管理员删除了网络:" + mi.Type;
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