using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CORSV2.forms.administrator.users
{
    public partial class rtkUserDetailInfoView : System.Web.UI.Page
    {
        public static int rtkUserInfoId ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 1 || Convert.ToInt32(Session["UserType"]) > 3)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                rtkUserInfoId = Convert.ToInt32(Request["id"]);

                if (rtkUserInfoId == null)
                {
                    Response.Redirect("/forms/administrator/users/RtkUserManage.aspx");
                    Response.End();
                }

                #region 加载初始数据
                //作业区域
                DataSet dswork = DAL.WorkingArea.GetList("1=1");
                foreach (DataRow dr in dswork.Tables[0].Rows)
                {
                    sszyqu.Items.Add(dr["AreaName"].ToString());
                }
                //源列表
                DataSet dssource = DAL.SourceTable.GetList("1=1");
                foreach (DataRow dr in dssource.Tables[0].Rows)
                {
                    ssylbpz.Items.Add(dr["Source"].ToString());
                }
                // 坐标系
                DataSet dsCoor = DAL.CoorSysPars.GetList("YSZBXM ='WGS84'");
                foreach (DataRow dr in dsCoor.Tables[0].Rows)
                {
                    ssdfzbx.Items.Add(dr["MDZBXM"].ToString());
                    shzbzhlb.Items.Add(dr["YSZBXM"].ToString() + "_" + dr["MDZBXM"].ToString());
                }
                #endregion
                #region 用户信息
                Model.RTKUserInfo mrtk = DAL.RTKUserInfo.GetModel(rtkUserInfoId);
                if (mrtk.UserType == 1)
                {
                    cominfo1.Visible = false;
                    cominfo12.Visible = false;
                    cominfo3.Visible = false;
                    cominfo4.Visible = false;
                }
                else
                {
                    user1.Visible = false;
                    user2.Visible = false;
                }
                UserName.Value = mrtk.UserName;
                PassWord.Value = AES_Key.AESDecrypt(mrtk.PassWord, mrtk.UserName.PadLeft(16, '0'));
                if (mrtk.UserType == -1)
                {
                    corszhky.SelectedIndex = 1;
                }
                else
                {
                    corszhky.SelectedIndex = 0;
                }
                Contacts.Value = mrtk.Contact;
                Phone.Value = mrtk.ContactPhone;
                contactEmail.Value = mrtk.ContactEmail;
                regtime.Value = mrtk.RegTime.ToString();
                #endregion

                if (mrtk.UserType == 1)
                {
                    //IDCardNumber.Value = mrtk.IDCardNumber;
                    //IDCard.Value = mrtk.IDCard;
                }
                else
                {
                    try
                    {
                        Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(mrtk.Company);
                        company.Value = companyInfo.Company;
                        BelongArea.Value = companyInfo.BelongArea;
                        dwType.Value = companyInfo.Industry;
                        Industry.Value = companyInfo.Industry;
                    }
                    catch
                    {

                    }

                }

                corsbelongarea.Value = mrtk.BelongArea;



                #region 用户权限
                Model.RTKUserPurview rTKUserPurview = DAL.RTKUserPurview.GetModel(mrtk.UserName);
                Model.RTKPostPurview rTKPostPurview=DAL.RTKPostPurview.GetModel(mrtk.UserName);
                if (rTKUserPurview.ServerType == "cm")
                {
                    corstype.Value = "厘米级";
                }
                else
                {
                    corstype.Value = "亚米级";
                }
                if (rTKUserPurview.VRSEnable == 1)
                {
                    ssfwky.SelectedIndex = 1;
                }
                else
                {
                    ssfwky.SelectedIndex = 0;
                }
                ssbsks.Value = rTKUserPurview.StartTime.ToString();
                ssbsjs.Value = rTKUserPurview.EndTime.ToString();


                if (rTKPostPurview.CoorTransEnable == 1)
                {
                    ssdfzbxhq.SelectedIndex = 0;
                }
                else
                {
                    ssdfzbxhq.SelectedIndex = 1;
                }
                sskyzbx.Value = rTKUserPurview.CoorSystem;
                if (rTKUserPurview.CoorSystem == "")
                {
                    ssdfzbxky.SelectedIndex = 0;
                }
                else
                {
                    ssdfzbxky.SelectedIndex = 1;
                    ssdfzbx.Value = rTKUserPurview.CoorSystem.Split(';')[0];
                }
                if (rTKUserPurview.SourceTable == "")
                {
                    ssylbky.SelectedIndex = 0;
                }
                else
                {
                    ssylbky.SelectedIndex = 1;
                    ssylbpz.Value = rTKUserPurview.SourceTable.Split(';')[0];
                }
                sskyylb.Value = rTKUserPurview.SourceTable;
                if (rTKUserPurview.AreaID == "")
                {
                    sskyqu.Value = "全部区域";
                    sszyqu.SelectedIndex = 0;
                    sszyqyky.SelectedIndex = 1;
                }
                else
                {
                    string[] workareas = rTKUserPurview.AreaID.Split(';');
                    string workarea = "";
                    foreach (var wo in workareas)
                    {
                        try
                        {
                            workarea += (DAL.WorkingArea.GetModel(int.Parse(wo)).AreaName + ";");
                        }
                            
                        catch (Exception)
                        {

                        }

                    }
                    sskyqu.Value = workarea;//mrtkpur.AreaID;//
                    sszyqyky.SelectedIndex = 1;
                    sszyqu.Value = DAL.WorkingArea.GetModel(int.Parse(workareas[0])).AreaName;//workareas[0];//
                }
                if (rTKUserPurview.ElevationEnable == 1)
                {
                    sszcghq.SelectedIndex = 1;
                }
                else
                {
                    sszcghq.SelectedIndex = 0;
                }
                if (rTKUserPurview.ElevationMode.Contains("85"))
                {
                    ssgcjz.SelectedIndex = 0;
                }
                else
                {
                    ssgcjz.SelectedIndex = 1;
                }
                if (rTKUserPurview.ServerType == "cm")
                {
                    WorkType.Value = "厘米级";
                }
                else
                {
                    if (rTKUserPurview.ServerType == "dm")
                    {
                        WorkType.Value = "亚米级";

                    }
                    else
                    {
                        if (rTKUserPurview.ServerType == "m")
                        {
                            WorkType.Value = "米级";
                        }
                        else
                        {

                            WorkType.Value = "厘米级";

                        }
                    }
                }
                #endregion
            }
            if (Request["action"] == "save")
            {
                #region 用户个人信息
                Model.RTKUserInfo rTKUserInfo = DAL.RTKUserInfo.GetModel(rtkUserInfoId);
                rTKUserInfo.UserName = Request.Form["UserName"].ToString();
                try
                {
                    rTKUserInfo.Company = Request.Form["Company"].ToString();
                }
                catch
                {
                    rTKUserInfo.Company = "个人";

                }
                rTKUserInfo.PassWord = AES_Key.AESEncrypt(Request.Form["PassWord"].ToString().Trim(), Request.Form["UserName"].ToString().Trim().PadLeft(16, '0'));
                rTKUserInfo.ContactPhone = Request.Form["Phone"].ToString();
                rTKUserInfo.ContactEmail = Request.Form["contactEmail"].ToString();
                rTKUserInfo.RegTime = DateTime.Parse(Request.Form["regtime"].ToString());

                if (Request.Form["corszhky"].ToString().Trim() == "可用")
                {
                    rTKUserInfo.UserType = -1;
                }
                try
                {

                    if (Request.Form["BelongArea"].ToString() == "")
                    {
                        rTKUserInfo.BelongArea = "全部";
                    }
                    else
                    {
                        rTKUserInfo.BelongArea = Request.Form["BelongArea"].ToString();
                    }
                }
                catch
                {
                    rTKUserInfo.BelongArea = "全部";
                }


                if (rTKUserInfo.UserType == 1)
                {
                    //rTKUserInfo.IDCard = Request.Form["IDCard"].ToString();
                    //rTKUserInfo.IDCardNumber = Request.Form["IDCardNumber"].ToString();
                }
                else
                {
                    rTKUserInfo.UserType=0;
                    Model.CompanyInfo mci = DAL.CompanyInfo.GetModel(rTKUserInfo.Company);
                }
                rTKUserInfo.BelongArea = Request.Form["corsbelongarea"].ToString();
                DAL.RTKUserInfo.Update(rTKUserInfo);

                #endregion
                #region 权限
                Model.RTKUserPurview rTKUserPurview = DAL.RTKUserPurview.GetModel(rTKUserInfo.UserName);
                Model.RTKPostPurview rTKPostPurview = DAL.RTKPostPurview.GetModel(rTKUserInfo.UserName);
                rTKUserPurview.AreaID = Request.Form["sskyqu"].ToString();

                if (Request.Form["ssbsjs"] == null || Request.Form["ssbsjs"] == "")
                {
                    rTKUserPurview.EndTime = DateTime.Now;
                    rTKPostPurview.EndTime= DateTime.Now;
                }
                else
                {
                    rTKUserPurview.EndTime = DateTime.Parse(Request.Form["ssbsjs"].ToString());
                    rTKPostPurview.EndTime = DateTime.Parse(Request.Form["ssbsjs"].ToString());
                }


                if (Request.Form["WorkType"].ToString() == "厘米级")
                {
                    rTKUserPurview.ServerType = "cm";
                }
                if (Request.Form["WorkType"].ToString() == "亚米级")
                {
                    rTKUserPurview.ServerType = "dm";
                }
                if (Request.Form["WorkType"].ToString() == "米级")
                {
                    rTKUserPurview.ServerType = "m";
                }
                if (Request.Form["sskyqu"].ToString().Trim() == "全部区域")
                {
                    rTKUserPurview.AreaID = "";
                }
                else
                {
                    string[] areanames = Request.Form["sskyqu"].ToString().Split(';');
                    rTKUserPurview.AreaID = "";
                    foreach (var aname in areanames)
                    {
                        try
                        {
                            rTKUserPurview.AreaID += (DAL.WorkingArea.GetModel(aname).ID + ";");
                        }
                        catch (Exception)
                        {

                        }

                    }
                }

                if (Request.Form["ssgcjz"].ToString().Trim() == "56国家高程")
                {
                    rTKUserPurview.ElevationMode = "56GC";
                }
                else
                {
                    rTKUserPurview.ElevationMode = "85GC";
                }
                if (Request.Form["sszcghq"] == null)
                {
                    if (sszcghq.SelectedIndex == 1)
                    {
                        rTKUserPurview.ElevationEnable = 1;
                    }
                    else
                    {
                        rTKUserPurview.ElevationEnable = 0;
                    }
                }
                else
                {
                    if (Request.Form["sszcghq"].ToString().Trim() == "可用")
                    {
                        rTKUserPurview.ElevationEnable = 1;
                    }
                    else
                    {
                        rTKUserPurview.ElevationEnable = 0;
                    }

                }


                if (Request.Form["ssdfzbxhq"].ToString().Trim() == "可用")
                {
                    rTKPostPurview.CoorTransEnable = 1;
                }
                else
                {
                    rTKPostPurview.CoorTransEnable = 0;
                }
                rTKUserPurview.CoorSystem = Request.Form["sskyzbx"].ToString();


                rTKUserPurview.SourceTable = Request.Form["sskyylb"].ToString();
                rTKUserPurview.UserName = Request.Form["username"].ToString();
                if (Request.Form["ssfwky"].ToString().Trim() == "否")
                {
                    rTKUserPurview.VRSEnable = 0;
                }
                else
                {
                    rTKUserPurview.VRSEnable = 1;
                }

                //DAL.RTKUserPurview.Update(rTKUserPurview);
                //DAL.RTKPostPurview.Update(rTKPostPurview);
                #endregion


                Model.SysLog msyslog = new Model.SysLog();

                msyslog.UserName = Session["UserName"].ToString();

                msyslog.LogTime = DateTime.Now;

                msyslog.LogType = 0;

                msyslog.Remark = "管理员修改了CORS用户：" + rTKUserInfo.UserName;

                DAL.SysLog.Add(msyslog);
                Response.Clear();
                Response.Write("1");
                Response.End();
            }

        }

    }
}