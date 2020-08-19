using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.administrator.information
{
    public partial class InternetSet : System.Web.UI.Page
    {
        string result = "";
        public static string equipids = "";
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
                if (Request["ID"] != null)
                {
                    int id = int.Parse(Request["ID"].ToString());
                    Model.InternetInformation mi = DAL.InternetInformation.GetModel(id);
                    if (mi == null)
                    {
                        Response.Write("<script>alert(\"网络信息错误\")");
                    }
                    else //对页面赋初值
                    {
                        IDS.Value = mi.ID.ToString();
                        IDD = mi.ID;
                        Type.Value = mi.Type;
                        DataLineStartP.Value = mi.DataLineStartP;
                        DataLineEndP.Value = mi.DataLineEndP;
                        EncryptionTechnology.Value = mi.EncryptionTechnology;
                        BandWidth.Value = mi.BandWidth;
                        GreenOperator.Value = mi.GreenOperator;
                        TechnicalSupportStaff.Value = mi.TechnicalSupportStaff;
                        FDataLineType.Value = mi.FDataLineType;
                        FEncryptionTechnology.Value = mi.FEncryptionTechnology;
                        FBandWidth.Value = mi.FBandWidth;
                        FGreenOperator.Value = mi.FGreenOperator;
                        FTechnicalSupportStaff.Value = mi.FTechnicalSupportStaff;
                        EquipConfig.Value = mi.EquipConfig;
                        Topological.Value = mi.Topological;
                        RouterConfig.Value = mi.RouterConfig;
                        ServerIP.Value = mi.ServerIP;
                        ServerPort.Value = mi.ServerPort;
                        ServerMachineName.Value = mi.ServerMachineName;
                        ServerLogo.Value = mi.ServerLogo;
                        ServerUse.Value = mi.ServerUse;
                        ServerRemark.Value = mi.ServerRemark;
                        StorageIP.Value = mi.StorageIP;
                        StoragePort.Value = mi.StoragePort;
                        StorageMachineName.Value = mi.StorageMachineName;
                        StorageLogo.Value = mi.StorageLogo;
                        StorageUse.Value = mi.StorageUse;
                        StorageRemark.Value = mi.StorageRemark;
                        EquipmentID.Value = mi.EquipmentID;
                        equipids = mi.EquipmentID;
                    }
                }
            }
            else
            {

                if (Request["upload"] == "EquipConfig")
                {
                    string filename = Request.Files["FileEquipConfig"].FileName;
                    string type = Request.Form["Type"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileEquipConfig"].SaveAs(Server.MapPath("~/upload/EquipConfig/") + type + "." + filenames[filenames.Length - 1]);
                    Model.InternetInformation ms = DAL.InternetInformation.GetModel(type);
                    ms.EquipConfig = "/upload/EquipConfig/" + type + "." + filenames[filenames.Length - 1];
                    DAL.InternetInformation.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["IDS"].ToString().Trim();
                    MERR.Contents = "网络类型" + type + "信息发生了修改：基本配置;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "网络信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["upload"] == "RouterConfig")
                {
                    string filename = Request.Files["FileRouterConfig"].FileName;
                    string type = Request.Form["Type"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileRouterConfig"].SaveAs(Server.MapPath("~/upload/RouterConfig/") + type + "." + filenames[filenames.Length - 1]);
                    Model.InternetInformation ms = DAL.InternetInformation.GetModel(type);
                    ms.RouterConfig = "/upload/RouterConfig/" + type + "." + filenames[filenames.Length - 1];
                    DAL.InternetInformation.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["IDS"].ToString().Trim();
                    MERR.Contents = "网络类型" + type + "信息发生了修改：路由器配置;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "网络信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["upload"] == "Topological")
                {
                    string filename = Request.Files["FileTopological"].FileName;
                    string type = Request.Form["Type"].ToString().Trim();
                    string[] filenames = filename.Split('.');
                    Request.Files["FileTopological"].SaveAs(Server.MapPath("~/upload/Topological/") + type + "." + filenames[filenames.Length - 1]);
                    Model.InternetInformation ms = DAL.InternetInformation.GetModel(type);
                    ms.Topological = "/upload/Topological/" + type + "." + filenames[filenames.Length - 1];
                    DAL.InternetInformation.Update(ms);
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    MERR.ReviceID = Request.Form["IDS"].ToString().Trim();
                    MERR.Contents = "网络类型" + type + "信息发生了修改：拓扑关系;";
                    MERR.RevicePerson = Session["UserName"].ToString();
                    MERR.ReviceTime = DateTime.Now;
                    MERR.Information = "网络信息";
                    DAL.EquipReviceRecord.Add(MERR);
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                if (Request["action"] == "save")
                {
                    int interid = int.Parse(Request.Form["IDS"].ToString());
                    Model.InternetInformation MI = DAL.InternetInformation.GetModel(interid);

                    #region 对修改信息进行比对
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    bool IsRevice = false;
                    MERR.Contents = "网络类型" + MI.Type + "信息发生了修改：";
                    if (MI.Type != Request.Form["Type"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "网络类型;";
                    }
                    if (MI.DataLineStartP != Request.Form["DataLineStartP"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据专线的起端点;";
                    }
                    if (MI.DataLineEndP != Request.Form["DataLineEndP"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据专线的止端点;";
                    }
                    if (MI.EncryptionTechnology != Request.Form["EncryptionTechnology"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "加密技术;";
                    }
                    if (MI.BandWidth != Request.Form["BandWidth"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "带宽;";
                    }
                    if (MI.GreenOperator != Request.Form["GreenOperator"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "专线运营商;";
                    }
                    if (MI.TechnicalSupportStaff != Request.Form["TechnicalSupportStaff"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "技术支持人员;";
                    }
                    if (MI.FDataLineType != Request.Form["FDataLineType"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据分发网络数据专线的类型;";
                    }
                    if (MI.FEncryptionTechnology != Request.Form["FEncryptionTechnology"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据分发网络加密技术;";
                    }
                    if (MI.FBandWidth != Request.Form["FBandWidth"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据分发网络带宽;";
                    }
                    if (MI.FGreenOperator != Request.Form["FGreenOperator"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据分发网络运营商;";
                    }
                    if (MI.FTechnicalSupportStaff != Request.Form["FTechnicalSupportStaff"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "数据分发网络技术支持信息;";
                    }
                    if (MI.ServerIP != Request.Form["ServerIP"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "服务器IP;";
                    }
                    if (MI.ServerPort != Request.Form["ServerPort"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "服务器端口;";
                    }
                    if (MI.ServerMachineName != Request.Form["ServerMachineName"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "服务器机器名;";
                    }
                    if (MI.ServerLogo != Request.Form["ServerLogo"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "服务器标识;";
                    }
                    if (MI.ServerUse != Request.Form["ServerUse"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "服务器用途;";
                    }
                    if (MI.ServerRemark != Request.Form["ServerRemark"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "服务器备注;";
                    }
                    if (MI.StorageIP != Request.Form["StorageIP"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "存储IP;";
                    }
                    if (MI.StoragePort != Request.Form["StoragePort"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "存储端口;";
                    }
                    if (MI.StorageMachineName != Request.Form["StorageMachineName"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "存储机器名;";
                    }
                    if (MI.StorageLogo != Request.Form["StorageLogo"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "存储标识;";
                    }
                    if (MI.StorageUse != Request.Form["StorageUse"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "存储用途;";
                    }
                    if (MI.StorageRemark != Request.Form["StorageRemark"].ToString())
                    {
                        IsRevice = true;
                        MERR.Contents += "存储备注;";
                    }
                    #endregion

                    MI.Type = Request.Form["Type"].ToString();
                    MI.DataLineStartP = Request.Form["DataLineStartP"].ToString();
                    MI.DataLineEndP = Request.Form["DataLineEndP"].ToString();
                    MI.EncryptionTechnology = Request.Form["EncryptionTechnology"].ToString();
                    MI.BandWidth = Request.Form["BandWidth"].ToString();
                    MI.GreenOperator = Request.Form["GreenOperator"].ToString();
                    MI.TechnicalSupportStaff = Request.Form["TechnicalSupportStaff"].ToString();
                    MI.FDataLineType = Request.Form["FDataLineType"].ToString();
                    MI.FEncryptionTechnology = Request.Form["FEncryptionTechnology"].ToString();
                    MI.FBandWidth = Request.Form["FBandWidth"].ToString();
                    MI.FGreenOperator = Request.Form["FGreenOperator"].ToString();
                    MI.FTechnicalSupportStaff = Request.Form["FTechnicalSupportStaff"].ToString();
                    if (Request.Form["EquipConfig"].ToString().Trim().Contains("EquipConfig"))
                    {
                        MI.EquipConfig = Request.Form["EquipConfig"].ToString();
                    }
                    if (Request.Form["Topological"].ToString().Trim().Contains("Topological"))
                    {
                        MI.Topological = Request.Form["Topological"].ToString();
                    }
                    if (Request.Form["RouterConfig"].ToString().Trim().Contains("RouterConfig"))
                    {
                        MI.RouterConfig = Request.Form["RouterConfig"].ToString();
                    }
                    MI.ServerIP = Request.Form["ServerIP"].ToString();
                    MI.ServerPort = Request.Form["ServerPort"].ToString();
                    MI.ServerMachineName = Request.Form["ServerMachineName"].ToString();
                    MI.ServerLogo = Request.Form["ServerLogo"].ToString();
                    MI.ServerUse = Request.Form["ServerUse"].ToString();
                    MI.ServerRemark = Request.Form["ServerRemark"].ToString();
                    MI.StorageIP = Request.Form["StorageIP"].ToString();
                    MI.StoragePort = Request.Form["StoragePort"].ToString();
                    MI.StorageMachineName = Request.Form["StorageMachineName"].ToString();
                    MI.StorageLogo = Request.Form["StorageLogo"].ToString();
                    MI.StorageUse = Request.Form["StorageUse"].ToString();
                    MI.StorageRemark = Request.Form["StorageRemark"].ToString();
                    // MI.EquipmentID = Request.Form["EquipmentID"].ToString();

                    Model.InternetInformation MI2 = DAL.InternetInformation.GetModel(MI.Type);
                    if (MI2 != null)
                    {
                        if (MI2.ID != MI.ID)
                        {
                            Response.Clear();
                            Response.Write("2");
                            Response.End();
                            return;
                        }
                        else
                        {
                            bool result = DAL.InternetInformation.Update(MI);
                            if (result)
                            {

                                if (IsRevice)
                                {
                                    MERR.ReviceID = MI.ID.ToString();
                                    MERR.RevicePerson = Session["UserName"].ToString();
                                    MERR.ReviceTime = DateTime.Now;
                                    MERR.Information = "网络信息";
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
                        }
                    }
                    else
                    {
                        bool result = DAL.InternetInformation.Update(MI);
                        if (result)
                        {
                            MERR.ReviceID = MI.ID.ToString();
                            MERR.RevicePerson = Session["UserName"].ToString();
                            MERR.ReviceTime = DateTime.Now;
                            MERR.Information = "网络信息";
                            DAL.EquipReviceRecord.Add(MERR);
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
                    }
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
            string[] ids = DAL.InternetInformation.GetModel(IDD).EquipmentID.Split(';');
            string where = "(";
            for (int i = 0; i < ids.Length - 2; i++)
            {
                where += ("ID ='" + ids[i] + "' or ");

            }
            where += ("ID ='" + ids[ids.Length - 2] + "')");
            where += " and MachineName like '%" + search + "%'";

            int totalCount = DAL.InternetInfoEquip.GetRecordCount(where);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet DS = DAL.InternetInfoEquip.GetBriefList(offset, limit, where);

            DS.Tables[0].Columns.Add("button", typeof(string));
            foreach (DataRow dr in DS.Tables[0].Rows)
            {
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
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
                    Model.InternetInfoEquip mi = DAL.InternetInfoEquip.GetModel(ids[m]);

                    DataSet ds = DAL.InternetInformation.GetList("EquipmentID like '%" + ids[m] + ";%'");

                    string name = mi.MachineName;
                    bool result = DAL.InternetInfoEquip.Delete(ids[m]);

                    if (result)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Model.InternetInformation MII = DAL.InternetInformation.GetModel(int.Parse(dr["ID"].ToString()));
                            if (MII != null)
                            {
                                string eid = MII.EquipmentID.Replace(ids[m] + ";", "").Trim();
                                MII.EquipmentID = eid;
                                DAL.InternetInformation.Update(MII);
                            }
                        }
                        Model.SysLog mSysLog = new Model.SysLog();
                        mSysLog.LogTime = DateTime.Now;
                        mSysLog.LogType = 0;
                        mSysLog.UserName = Session["UserName"].ToString();
                        mSysLog.Remark = "管理员删除了网络信息管理设备：" + name;
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