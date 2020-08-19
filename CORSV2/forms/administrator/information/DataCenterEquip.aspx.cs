using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class DataCenterEquip : System.Web.UI.Page
    {
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
                string SerialNum = Request["Serial"].ToString();
                Model.DataCenter md = DAL.DataCenter.GetModel(SerialNum);
                IDS.Value = md.ID.ToString(); ;
                DeviceType.Value = md.DeviceType;
                dType.Value = md.Type;
                SerialNumber.Value = md.SerialNumber;
                FirstUseDate.Value = md.FirstUseDate.ToString();
                LoginName.Value = md.LoginName;
                if (md.Password != "" && md.Password != null)
                {
                    Password.Value = AES_Key.AESDecrypt(md.Password, md.LoginName.PadLeft(16, '0'));
                }
                IP.Value = md.IP;
                Port.Value = md.Port;
                SubnetMask.Value = md.SubnetMask;
                Gateway.Value = md.Gateway;
                Business.Value = md.Business;
                MaintenancePerson.Value = md.MaintenancePerson;
                MaintenanceTime.Value = md.MaintenanceTime.ToString();
                MaintenanceContent.Value = md.MaintenanceContent;
            }
            else
            {
                if (Request["action"] == "save")
                {
                    Model.DataCenter MD = DAL.DataCenter.GetModel(int.Parse(Request.Form["IDS"].ToString().Trim()));
                    #region 对修改信息进行对比
                    Model.EquipReviceRecord MERR = new Model.EquipReviceRecord();
                    bool IsRevice = false;
                    MERR.Contents = "设备类型为" + MD.DeviceType + "的设备信息发生了修改：";
                    #endregion
                    if (Request.Form["SerialNumber"].ToString().Trim() == MD.SerialNumber)
                    {
                        if (MD.DeviceType != Request.Form["DeviceType"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "设备类型;";
                        }
                        if (MD.Type != Request.Form["dType"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "型号;";
                        }
                        if (MD.FirstUseDate != DateTime.Parse(Request.Form["FirstUseDate"].ToString()))
                        {
                            IsRevice = true;
                            MERR.Contents += "初次使用日期;";
                        }
                        if (MD.Business != Request.Form["Business"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "业务用途;";
                        }
                        if (MD.IP != Request.Form["IP"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "IP地址;";
                        }
                        if (MD.Port != Request.Form["Port"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "端口;";
                        }
                        if (MD.SubnetMask != Request.Form["SubnetMask"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "子网掩码;";
                        }
                        if (MD.Gateway != Request.Form["Gateway"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "网关;";
                        }
                        if (MD.LoginName != Request.Form["LoginName"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "登陆名;";
                        }
                        if (MD.Password != AES_Key.AESEncrypt(Request.Form["Password"].ToString().Trim(), MD.LoginName.PadLeft(16, '0')))
                        {
                            IsRevice = true;
                            MERR.Contents += "登陆密码;";
                        }
                        if (MD.MaintenancePerson != Request.Form["MaintenancePerson"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "设备维护人员;";
                        }
                        if (MD.MaintenanceTime != DateTime.Parse(Request.Form["MaintenanceTime"].ToString()))
                        {
                            IsRevice = true;
                            MERR.Contents += "设备维护时间;";
                        }
                        if (MD.MaintenanceContent != Request.Form["MaintenanceContent"].ToString().Trim())
                        {
                            IsRevice = true;
                            MERR.Contents += "设备维护内容;";
                        }
                        MD.DeviceType = Request.Form["DeviceType"].ToString().Trim();
                        MD.Gateway = Request.Form["Gateway"].ToString().Trim();
                        MD.FirstUseDate = DateTime.Parse(Request.Form["FirstUseDate"].ToString());
                        MD.IP = Request.Form["IP"].ToString().Trim();
                        MD.LoginName = Request.Form["LoginName"].ToString().Trim();
                        MD.MaintenanceContent = Request.Form["MaintenanceContent"].ToString().Trim();
                        MD.MaintenancePerson = Request.Form["MaintenancePerson"].ToString().Trim();
                        MD.MaintenanceTime = DateTime.Parse(Request.Form["MaintenanceTime"].ToString());
                        MD.Password = AES_Key.AESEncrypt(Request.Form["Password"].ToString().Trim(), MD.LoginName.PadLeft(16, '0'));
                        MD.Port = Request.Form["Port"].ToString().Trim();
                        MD.Business = Request.Form["Business"].ToString().Trim();
                        MD.SerialNumber = Request.Form["SerialNumber"].ToString().Trim();
                        MD.SubnetMask = Request.Form["SubnetMask"].ToString().Trim();
                        bool result = DAL.DataCenter.Update(MD);
                        if (result)
                        {
                            if (IsRevice)
                            {
                                MERR.ReviceID = MD.ID.ToString();
                                MERR.RevicePerson = Session["UserName"].ToString();
                                MERR.ReviceTime = DateTime.Now;
                                MERR.Information = "数据中心设备";
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
                    else
                    {
                        if (DAL.DataCenter.Exists(Request.Form["SerialNumber"].ToString().Trim(), 1))
                        {
                            Response.Clear();
                            Response.Write("2");
                            Response.End();

                        }
                        else
                        {
                            if (MD.DeviceType != Request.Form["DeviceType"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "设备类型;";
                            }
                            if (MD.Type != Request.Form["dType"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "型号;";
                            }
                            if (MD.FirstUseDate != DateTime.Parse(Request.Form["FirstUseDate"].ToString()))
                            {
                                IsRevice = true;
                                MERR.Contents += "初次使用日期;";
                            }
                            if (MD.Business != Request.Form["Business"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "业务用途;";
                            }
                            if (MD.IP != Request.Form["IP"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "IP地址;";
                            }
                            if (MD.Port != Request.Form["Port"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "端口;";
                            }
                            if (MD.SubnetMask != Request.Form["SubnetMask"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "子网掩码;";
                            }
                            if (MD.Gateway != Request.Form["Gateway"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "网关;";
                            }
                            if (MD.LoginName != Request.Form["LoginName"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "登陆名;";
                            }
                            if (MD.Password != AES_Key.AESEncrypt(Request.Form["Password"].ToString().Trim(), MD.LoginName.PadLeft(16, '0')))
                            {
                                IsRevice = true;
                                MERR.Contents += "登陆密码;";
                            }
                            if (MD.MaintenancePerson != Request.Form["MaintenancePerson"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "设备维护人员;";
                            }
                            if (MD.MaintenanceTime != DateTime.Parse(Request.Form["MaintenanceTime"].ToString()))
                            {
                                IsRevice = true;
                                MERR.Contents += "设备维护时间;";
                            }
                            if (MD.MaintenanceContent != Request.Form["MaintenanceContent"].ToString().Trim())
                            {
                                IsRevice = true;
                                MERR.Contents += "设备维护内容;";
                            }
                            MD.DeviceType = Request.Form["DeviceType"].ToString().Trim();
                            MD.Gateway = Request.Form["Gateway"].ToString().Trim();
                            MD.FirstUseDate = DateTime.Parse(Request.Form["FirstUseDate"].ToString());
                            MD.IP = Request.Form["IP"].ToString().Trim();
                            MD.LoginName = Request.Form["LoginName"].ToString().Trim();
                            MD.MaintenanceContent = Request.Form["MaintenanceContent"].ToString().Trim();
                            MD.MaintenancePerson = Request.Form["MaintenancePerson"].ToString().Trim();
                            MD.MaintenanceTime = DateTime.Parse(Request.Form["MaintenanceTime"].ToString());
                            MD.Password = AES_Key.AESEncrypt(Request.Form["Password"].ToString().Trim(), MD.LoginName.PadLeft(16, '0'));
                            MD.Port = Request.Form["Port"].ToString().Trim();
                            MD.Business = Request.Form["Business"].ToString().Trim();
                            MD.SerialNumber = Request.Form["SerialNumber"].ToString().Trim();
                            MD.SubnetMask = Request.Form["SubnetMask"].ToString().Trim();
                            bool result = DAL.DataCenter.Update(MD);
                            if (result)
                            {
                                if (IsRevice)
                                {
                                    MERR.ReviceID = MD.ID.ToString();
                                    MERR.RevicePerson = Session["UserName"].ToString();
                                    MERR.ReviceTime = DateTime.Now;
                                    MERR.Information = "数据中心设备";
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
                }
            }

        }
    }
}