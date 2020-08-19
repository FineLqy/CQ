using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.administrator.information
{
    public partial class EquipSetInfo : System.Web.UI.Page
    {
        string result = "";
        public static int IDD;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                #region load
                if (Request["StationOName"] != null)
                {

                    string stoname = Request["StationOName"].ToString();
                    Model.EquipmentInfo meq = DAL.EquipmentInfo.GetModel(stoname);
                    StationName.Value = meq.StationName;
                    IDD = meq.ID;
                    IDS.Value = meq.ID.ToString();
                    LoginName.Value = meq.LoginName;
                    if (meq.Password != "" && meq.Password != null)
                    {
                        Password.Value = AES_Key.AESDecrypt(meq.Password, meq.LoginName.PadLeft(16, '0'));
                    }
                    AntennaH.Value = meq.AntennaH.ToString();
                    AntennaHM.Value = meq.AntennaHM;
                    AntennaHML.Value = meq.AntennaHML;
                    SatelliteSystem.Value = meq.SatelliteSystem;
                    IP.Value = meq.IP;
                    Port.Value = meq.Port;
                    SubnetMask.Value = meq.SubnetMask;
                    Gateway.Value = meq.Gateway;
                    BaudRate.Value = meq.BaudRate;
                    DataConfiguration.Value = meq.DataConfiguration;
                    MaintenancePerson.Value = meq.MaintenancePerson;
                    MaintenanceTime.Value = meq.MaintenanceTime.ToString();
                    MaintenanceContent.Value = meq.MaintenanceContent;
                }
                #endregion

            }
            else
            {
                if (Request["action"] == "save")
                {


                    #region save
                    Model.EquipmentInfo MEQ = DAL.EquipmentInfo.GetModel(Request.Form["StationName"].ToString().Trim(), 1);
                    #region 对修改信息进行对比


                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    bool IsRevice = false;
                    MERR.Contents = MEQ.StationName + "设备信息发生了修改：";
                    if (MEQ.AntennaH != double.Parse(Request.Form["AntennaH"].ToString().Trim()))
                    {
                        IsRevice = true;
                        MERR.Contents += "天线高;";
                    }
                    if (MEQ.AntennaHM != Request.Form["AntennaHM"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "天线高量取方式;";
                    }
                    if (MEQ.AntennaHML != Request.Form["AntennaHML"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "天线高量取位置;";
                    }
                    if (MEQ.LoginName != Request.Form["LoginName"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "设备登录名;";
                    }
                    if (MEQ.Password != AES_Key.AESEncrypt(Request.Form["Password"].ToString().Trim(), MEQ.LoginName.PadLeft(16, '0')))
                    {
                        IsRevice = true;
                        MERR.Contents += "登录密码;";
                    }
                    if (MEQ.SatelliteSystem != Request.Form["SatelliteSystem"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "卫星系统;";
                    }
                    if (MEQ.IP != Request.Form["IP"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "IP地址;";
                    }
                    if (MEQ.Port != Request.Form["Port"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "端口;";
                    }
                    if (MEQ.SubnetMask != Request.Form["SubnetMask"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "子网掩码;";
                    }
                    if (MEQ.Gateway != Request.Form["Gateway"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "网关;";
                    }
                    if (MEQ.BaudRate != Request.Form["BaudRate"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "波特率;";
                    }
                    if (MEQ.DataConfiguration != Request.Form["DataConfiguration"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据流转发配置;";
                    }
                    if (MEQ.MaintenancePerson != Request.Form["MaintenancePerson"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "设备维护人员;";
                    }
                    if (MEQ.MaintenanceTime != DateTime.Parse(Request.Form["MaintenanceTime"].ToString().Trim()))
                    {
                        IsRevice = true;
                        MERR.Contents += "设备维护时间;";
                    }
                    if (MEQ.MaintenanceContent != Request.Form["MaintenanceContent"].ToString().Trim())
                    {
                        IsRevice = true;
                        MERR.Contents += "设备维护内容;";
                    }
                    
                    #endregion

                    MEQ.AntennaH = double.Parse(Request.Form["AntennaH"].ToString().Trim());
                    MEQ.AntennaHM = Request.Form["AntennaHM"].ToString().Trim();
                    MEQ.AntennaHML = Request.Form["AntennaHML"].ToString().Trim();
                    MEQ.BaudRate = Request.Form["BaudRate"].ToString().Trim();
                    MEQ.DataConfiguration = Request.Form["DataConfiguration"].ToString().Trim();
                    
                    MEQ.Gateway = Request.Form["Gateway"].ToString().Trim();
                    MEQ.IP = Request.Form["IP"].ToString().Trim();
                    MEQ.LoginName = Request.Form["LoginName"].ToString().Trim();
                    MEQ.MaintenanceContent = Request.Form["MaintenanceContent"].ToString().Trim();
                    MEQ.MaintenancePerson = Request.Form["MaintenancePerson"].ToString().Trim();
                    MEQ.MaintenanceTime = DateTime.Parse(Request.Form["MaintenanceTime"].ToString());
                    MEQ.Password = AES_Key.AESEncrypt(Request.Form["Password"].ToString().Trim(), MEQ.LoginName.PadLeft(16, '0'));
                    MEQ.Port = Request.Form["Port"].ToString().Trim();
                    MEQ.SatelliteSystem = Request.Form["SatelliteSystem"].ToString().Trim();
                  
                    bool result = DAL.EquipmentInfo.Update(MEQ);
                    Model.CORSStationInfo mc = DAL.CORSStationInfo.GetModel(MEQ.StationName);
                    mc.IP = MEQ.IP;
                    mc.Port = MEQ.Port;
                    DAL.CORSStationInfo.Update(mc);
                    if (result)
                    {
                        if (IsRevice)
                        {
                            MERR.ReviceID = MEQ.ID.ToString();
                            MERR.RevicePerson = Session["UserName"].ToString();
                            MERR.ReviceTime = DateTime.Now;
                            MERR.Information = "基站设备";
                            DAL.EquipReviceRecord.Add(MERR);
                        }
                        Response.Clear();
                        Response.Write("1");
                        Response.End();
                    }
                    else
                    {
                        Response.Clear();
                        Response.Write("0");
                        Response.End();
                    }
                    #endregion
                }
            }
            if (Request["action"] != null && Request["action"] == "GetData")
            {

                if (!GetEquips())
                {
                    Response.Write("0");

                }

            }
            if (Request["action"] != null && Request["action"] == "DeleteEquip")
            {
                DeleteEquip();
            }
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
            string[] ids = DAL.EquipmentInfo.GetModel(IDD).EquipID.Split(';');
            string where = "(";
            for (int i = 0; i < ids.Length - 2; i++)
            {
                where += ("ID ='" + ids[i] + "' or ");

            }
            where += ("ID ='" + ids[ids.Length - 2] + "')");
            where += " and MachineName like '%" + search + "%'";

            int totalCount = DAL.StationEquip.GetRecordCount(where);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet DS = DAL.StationEquip.GetBriefList(offset, limit, where);

            DS.Tables[0].Columns.Add("dInstallationDate", typeof(string));
            foreach (DataRow dr in DS.Tables[0].Rows)
            {
                dr["dInstallationDate"] = dr["InstallationDate"].ToString();
            }
            string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(DS.Tables[0]);
            result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
            Response.ContentType = "application/Json";
            Response.Write(result);
            Response.End();

            if (DS.Tables[0].Rows.Count > 0)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        private void DeleteEquip()
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
                    Model.StationEquip mi = DAL.StationEquip.GetModel(ids[m]);

                    DataSet ds = DAL.EquipmentInfo.GetList("EquipID like '%" + ids[m] + ";%'");

                    string name = mi.MachineName;
                    bool result = DAL.StationEquip.Delete(ids[m]);

                    if (result)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Model.EquipmentInfo MII = DAL.EquipmentInfo.GetModel(int.Parse(dr["ID"].ToString()));
                            if (MII != null)
                            {
                                string eid = MII.EquipID.Replace(ids[m] + ";", "").Trim();
                                MII.EquipID = eid;
                                DAL.EquipmentInfo.Update(MII);
                            }
                        }
                        Model.SysLog mSysLog = new Model.SysLog();
                        mSysLog.LogTime = DateTime.Now;
                        mSysLog.LogType = 0;
                        mSysLog.UserName = Session["UserName"].ToString();
                        mSysLog.Remark = "管理员删除了基站设备：" + name;
                        DAL.SysLog.Add(mSysLog);
                    }

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