using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class StationNetSet : System.Web.UI.Page
    {
        public static string sysselect="";
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
                int id = int.Parse(Request["id"].ToString());
                Model.StationNetInfo MSN = DAL.StationNetInfo.GetModel(id);
                netid.Value = MSN.ID.ToString();
                NetName.Value = MSN.NetName;
                Number.Value = MSN.Number;

                DistributionDiagram.Value = MSN.DistributionDiagram;
                if (MSN.DistributionDiagram == "")
                {
                    viewDistributionDiagram.Disabled = true;
                }
                IP.Value = MSN.IP;
                Port.Value = MSN.Port;
                SourceNode.Value = MSN.SourceNode;
                NetworkProtocol.Value = MSN.NetworkProtocol;
                DataFormat.Value = MSN.DataFormat;
                ServiceContent.Value = MSN.ServiceContent;
                sysselect = MSN.SatelliteSystem;
                BuildTime.Value = MSN.BuildTime.ToString();

            }
            if (Request["action"] != null && Request["action"] == "save")
            {
                string sysdata = Request["sysdata"].ToString();
                string[] sys = sysdata.Split(' ');
                string SateSys = "";
                foreach (string s in sys)
                {
                    if (s != "")
                    {
                        SateSys += (s + ';');
                    }
                }
                int id = int.Parse(Request.Form["netid"].ToString().Trim());
                Model.StationNetInfo ms = DAL.StationNetInfo.GetModel(id);

                #region 对修改信息进行对比
                Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                bool IsRevice = false;
                MERR.Contents = "战网" + ms.NetName + "的信息发生了修改：";
                if (ms.BuildTime != Convert.ToDateTime(Request.Form["BuildTime"].ToString().Trim()))
                {
                    IsRevice = true;
                    MERR.Contents += "建设完成时间;";
                }
                if (ms.Number != Request.Form["Number"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "站点数量;";
                }
                if (ms.IP != Request.Form["IP"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "IP地址;";
                }
                if (ms.Port != Request.Form["Port"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "端口;";
                }
                if (ms.SourceNode != Request.Form["SourceNode"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "源节点;";
                }
                if (ms.NetworkProtocol != Request.Form["NetworkProtocol"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "网络协议;";
                }
                if (ms.DataFormat != Request.Form["DataFormat"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "数据格式;";
                }
                if (ms.SatelliteSystem != SateSys)
                {
                    IsRevice = true;
                    MERR.Contents += "卫星系统;";
                }
                if (ms.ServiceContent != Request.Form["ServiceContent"].ToString().Trim())
                {
                    IsRevice = true;
                    MERR.Contents += "应用服务内容;";
                }

                #endregion


                ms.BuildTime = Convert.ToDateTime(Request.Form["BuildTime"].ToString().Trim());
                ms.DataFormat = Request.Form["DataFormat"].ToString().Trim();
                if (Request.Form["DistributionDiagram"].ToString().Trim().Contains("DistributionDiagram"))
                {
                    ms.DistributionDiagram = Request.Form["DistributionDiagram"].ToString().Trim();
                }
                ms.IP = Request.Form["IP"].ToString().Trim();
                ms.Number = Request.Form["Number"].ToString().Trim();
                ms.Port = Request.Form["Port"].ToString().Trim();
                ms.SatelliteSystem = SateSys;
                ms.NetName = Request.Form["NetName"].ToString().Trim();
                ms.NetworkProtocol = Request.Form["NetworkProtocol"].ToString().Trim();
                ms.ServiceContent = Request.Form["ServiceContent"].ToString().Trim();
                ms.SourceNode = Request.Form["SourceNode"].ToString().Trim();
                if (DAL.StationNetInfo.GetModel(ms.NetName).ID != ms.ID)
                {
                    Response.Clear();
                    Response.Write("2");
                    Response.End();
                }
                else
                {
                    DAL.StationNetInfo.Update(ms);
                    if (IsRevice)
                    {
                        MERR.ReviceID = ms.ID.ToString();
                        MERR.RevicePerson = Session["UserName"].ToString();
                        MERR.ReviceTime = DateTime.Now;
                        MERR.Information = "站网信息";
                        DAL.EquipReviceRecord.Add(MERR);
                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
            }
            if (Request["upload"] == "DistributionDiagram")
            {
                string filename = Request.Files["FileDistributionDiagram"].FileName;
                int ids = int.Parse(Request.Form["netid"].ToString().Trim());
                string[] filenames = filename.Split('.');
                Model.StationNetInfo ms = DAL.StationNetInfo.GetModel(ids);
                Request.Files["FileDistributionDiagram"].SaveAs(Server.MapPath("~/upload/DistributionDiagram/") + ms.NetName + "." + filenames[filenames.Length - 1]);

                ms.DistributionDiagram = "/upload/DistributionDiagram/" + ms.NetName + "." + filenames[filenames.Length - 1];
                DAL.StationNetInfo.Update(ms);
                Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                MERR.ReviceID = Request.Form["netid"].ToString().Trim();
                MERR.Contents = "战网" + ms.NetName + "的信息发生了修改：站点分布示意图;";
                MERR.RevicePerson = Session["UserName"].ToString();
                MERR.ReviceTime = DateTime.Now;
                MERR.Information = "站网信息";
                DAL.EquipReviceRecord.Add(MERR);
                Response.Clear();
                Response.Write("1");
                Response.End();
            }
        }
    }
}