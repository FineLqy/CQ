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
    public partial class StationManage : System.Web.UI.Page
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


            int totalCount = DAL.CORSStationInfo.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.CORSStationInfo.GetBriefList(offset, limit, search);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("deIsOK", typeof(string));
            ds.Tables[0].Columns.Add("buttonequip", typeof(string));
            ds.Tables[0].Columns.Add("SiteMonitoring", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
                dr["buttonequip"] = "<a id='" + dr["StationOName"] + "' onclick= viewDevice(this.id) >查看设备</a>";
                dr["SiteMonitoring"] = "<a id='" + dr["StationOName"] + "' onclick= viewSite(this.id) >站点监视</a>";
                if (dr["IsOK"].ToString() == "1")
                {
                    dr["deIsOK"] = "正常";
                }
                else
                {
                    dr["deIsOK"] = "异常";
                }
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
                string jsonComs =  CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
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
                    Model.CORSStationInfo mc = DAL.CORSStationInfo.GetModel(ids[m]);
                    string fileplan = Server.MapPath("~" + mc.StationPlan);
                    string fileRingView = Server.MapPath("~" + mc.RingView);


                    string name = mc.StationName;
                    DAL.EquipmentInfo.Delete(DAL.CORSStationInfo.GetModel(ids[m]).StationOName);

                    DAL.SiteMonitoring.Delete(DAL.CORSStationInfo.GetModel(ids[m]).StationOName);
                    bool result = DAL.CORSStationInfo.Delete(name);
                    try
                    {

                        if (File.Exists(fileplan))
                        {
                            File.Delete(fileplan);
                        }

                        if (File.Exists(fileRingView))
                        {
                            File.Delete(fileRingView);
                        }
                    }
                    catch (Exception)
                    {

                    }

                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = Session["UserName"].ToString();
                    mSysLog.Remark = "管理员删除了基站：" + name;
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

        private void AddStas() {
            
            Model.CORSStationInfo cors = new Model.CORSStationInfo();
            cors.StationName = Request.Form["StationName"].ToString();
            cors.StationOName = Request.Form["StationOName"].ToString();
            cors.TransferType = Request.Form["TransType"].ToString();
            cors.IP = Request.Form["Ip"].ToString();
            cors.Port = Request.Form["Port"].ToString();
            cors.Lat = double.Parse(Request.Form["Lat"].ToString());
            cors.Lon = double.Parse(Request.Form["Lon"].ToString());
            cors.H = double.Parse(Request.Form["H"].ToString());
            cors.Remark = Request.Form["Remark"].ToString();
            cors.IsOK = 0;
            if (DAL.CORSStationInfo.Exists(cors.StationName) || DAL.CORSStationInfo.GetModelByOName(cors.StationOName) != null)
            {
                Response.Clear();
                Response.Write("0");
                Response.End();
            }
            else
            {
                Model.EquipmentInfo eq = new Model.EquipmentInfo();
                eq.StationOName = cors.StationOName;
                eq.StationName = cors.StationName;
                eq.IP = cors.IP;
                eq.Port = cors.Port;
                Model.SiteMonitoring ms = new Model.SiteMonitoring();
                ms.StationOName = cors.StationOName;
                try
                {
                    DAL.CORSStationInfo.Add(cors);
                    Model.CORSStationInfo cos = DAL.CORSStationInfo.GetModel(cors.StationName);
                    DAL.EquipmentInfo.Add(eq);
                    DAL.SiteMonitoring.Add(ms);
                    result = cos.ID.ToString();
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
                mSysLog.Remark = "管理员添加基站：" + cors.StationName + "的信息";
                DAL.SysLog.Add(mSysLog);
            }
            
        }
    }
}