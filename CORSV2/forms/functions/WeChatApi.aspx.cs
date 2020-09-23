using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.functions
{
    public partial class WeChatApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request["action"] != null && Request["key"] != null)
            {
                //给微信小程序传数据
                if (Request["action"] == "GetData" && Request["key"] == "kZJdqQGFq1SntAI/SE9IMQ==")
                {
                    #region 基站信息
                    DataSet DSStationInfo = DAL.CORSStationInfo.GetList("1=1");
                    string StationInfo = cs.JSONHelper.DataTableToJSON(DSStationInfo.Tables[0]);
                    #endregion

                    #region 服务平台信息
                    //基站状态
                    int StationCount = DSStationInfo.Tables[0].Rows.Count;
                    int StationFineCount = DAL.CORSStationInfo.GetList("IsOK=1").Tables[0].Rows.Count;

                    //获取用户数和固定率

                    double Rtk = 0;
                    string strGD = "";
                    double rtkNum = DAL.RTKUserStatus.GetList("IsOnline =1").Tables[0].Rows.Count;
                    double rtkGd = DAL.RTKUserStatus.GetList("IsOnline=1 and  Remark like '%RTK固定%'").Tables[0].Rows.Count;

                    if (rtkNum != 0 && rtkGd != 0)
                    {
                        double GD = Math.Round(rtkGd / rtkNum * 100, 2);
                        strGD = GD + "%";
                    }




                    //对流层实时值
                    string pwvValue = "";
                    string pwvfilepath = Server.MapPath("~\\Product\\PWV_AVERAGE_REALTIME.rtpwv");
                    if (System.IO.File.Exists(pwvfilepath))
                    {
                        StreamReader readrtpwv = new StreamReader(pwvfilepath);
                        string pwvline = readrtpwv.ReadLine();
                        string[] pwv = getnewstr(pwvline).Split(' ');
                        pwvValue = pwv[pwv.Length - 1];
                        readrtpwv.Close();
                        readrtpwv.Dispose();
                    }

                    //电离层实时值
                    string tecValue = "";
                    string ionopath = Server.MapPath("~\\Product\\SLM_AVERAGE_REALTIME.rttec");
                    if (System.IO.File.Exists(ionopath))
                    {
                        StreamReader readrttec = new StreamReader(ionopath);
                        string tecline = readrttec.ReadLine();
                        string[] tec = getnewstr(tecline).Split(' ');
                        tecValue = tec[tec.Length - 2] + ' ' + tec[tec.Length - 1];
                        readrttec.Close();
                    }

                    //电离层预报值
                    string retecValue = "";
                    string strpath = Server.MapPath("~/Product/SLM_THREEDY.forecast");
                    if (File.Exists(strpath))
                    {
                        try
                        {
                            StreamReader readeriono = new StreamReader(strpath);
                            List<List<string>> Dataiono = new List<List<string>>();
                            for (string line = readeriono.ReadLine(); line != null; line = readeriono.ReadLine())
                            {
                                string[] ll = getnewstr(line).Split(' ');
                                List<string> l = new List<string>();
                                l.Add(ll[0]);
                                l.Add(ll[1]);
                                Dataiono.Add(l);
                            }
                            readeriono.Close();
                            for (int i = 0; i < Dataiono.Count; i++)
                            {
                                if (int.Parse(Dataiono[i][0]) == DateTime.Now.AddHours(2).Hour)
                                {
                                    retecValue = Dataiono[i][1] + "TECU";
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }

                    }

                    DataSet DSPlatInfo = new DataSet();
                    DataTable DTPlatInfo = new DataTable();
                    DTPlatInfo.Columns.Add("Item", typeof(string));
                    DTPlatInfo.Columns.Add("Value", typeof(string));
                    DataRow DRPlatInfo1 = DTPlatInfo.NewRow();
                    DRPlatInfo1["Item"] = "CORS当前服务状态";
                    DRPlatInfo1["Value"] = "正常";
                    DTPlatInfo.Rows.Add(DRPlatInfo1);
                    DataRow DRPlatInfo2 = DTPlatInfo.NewRow();
                    DRPlatInfo2["Item"] = "CORS基准站运行状态(正常站点/总站点)";
                    DRPlatInfo2["Value"] = StationFineCount.ToString() + "/" + StationCount.ToString();
                    DTPlatInfo.Rows.Add(DRPlatInfo2);
                    DataRow DRPlatInfo3 = DTPlatInfo.NewRow();
                    DRPlatInfo3["Item"] = "作业用户数";
                    DRPlatInfo3["Value"] = rtkNum;
                    DTPlatInfo.Rows.Add(DRPlatInfo3);
                    DataRow DRPlatInfo4 = DTPlatInfo.NewRow();
                    DRPlatInfo4["Item"] = "固定率";
                    DRPlatInfo4["Value"] = strGD;
                    DTPlatInfo.Rows.Add(DRPlatInfo4);
                    DataRow DRPlatInfo5 = DTPlatInfo.NewRow();
                    DRPlatInfo5["Item"] = "对流层实时数值";
                    DRPlatInfo5["Value"] = pwvValue;
                    DTPlatInfo.Rows.Add(DRPlatInfo5);
                    DataRow DRPlatInfo6 = DTPlatInfo.NewRow();
                    DRPlatInfo6["Item"] = "电离层实时数值";
                    DRPlatInfo6["Value"] = tecValue;
                    DTPlatInfo.Rows.Add(DRPlatInfo6);

                    DataRow DRPlatInfo7 = DTPlatInfo.NewRow();
                    DRPlatInfo7["Item"] = "电离层预报数值(未来两个小时)";
                    DRPlatInfo7["Value"] = retecValue;
                    DTPlatInfo.Rows.Add(DRPlatInfo7);
                    string PlatInfo = cs.JSONHelper.DataTableToJSON(DTPlatInfo);

                    #endregion

                    #region 空间环境产品

                    #endregion
                    string result = "{\"StationInfo\":" + StationInfo + ",\"PlatInfo\":" + PlatInfo + "}";
                    Response.Clear();
                    Response.Write(result);
                    Response.End();
                }
                //给微信小程序登录
                if (Request["action"] == "Login" && Request["key"] == "kZJdqQGFq1SntAI/SE9IMQ==")
                {
                    #region 验证用户名和密码
                    if (Request["UserName"] != null && Request["PassWord"] != null)
                    {
                        string UserName = Request["UserName"].ToString();
                        string PassWord = Request["PassWord"].ToString();
                        //userinfo-->RTKuser
                        // DAL.UserInfoWeb duserinfo = new DAL.UserInfoWeb();
                        Model.RegisterUser muinfo = DAL.RegisterUser.GetModel(UserName);
                        if (muinfo != null)
                        {
                            if (PassWord == AES_Key.AESDecrypt(muinfo.PassWord, muinfo.UserName.PadLeft(16, '0')))
                            {
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
                            Model.RTKUserInfo mrtk = DAL.RTKUserInfo.GetModel2(UserName);
                            if (mrtk != null)
                            {
                                if (PassWord == AES_Key.AESDecrypt(mrtk.PassWord, mrtk.UserName.PadLeft(16, '0')))
                                {
                                    Response.Clear();
                                    Response.Write("2");
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
                                Response.Clear();
                                Response.Write("0");
                                Response.End();
                            }
                        }
                    }

                    #endregion

                }

                //微信小程序修改密码
                if (Request["action"] == "ChangePass" && Request["key"] == "kZJdqQGFq1SntAI/SE9IMQ==")
                {
                    if (Request["UserName"] != null && Request["PassWord"] != null && Request["NewPassWord"] != null)
                    {
                        string UserName = Request["UserName"].ToString();
                        string PassWord = Request["PassWord"].ToString();
                        string NewPassWord = Request["NewPassWord"].ToString();
                        //userinfo-->RTKuser

                        Model.RegisterUser muinfo = DAL.RegisterUser.GetModel(UserName);
                        if (muinfo != null)
                        {
                            if (PassWord == AES_Key.AESDecrypt(muinfo.PassWord, muinfo.UserName.PadLeft(16, '0')))
                            {

                                muinfo.PassWord = AES_Key.AESEncrypt(NewPassWord, UserName.PadLeft(16, '0'));
                                if (DAL.RegisterUser.Update(muinfo))
                                {
                                    Response.Clear();
                                    Response.Write("1");
                                    Response.End();
                                }
                                else
                                {
                                    Response.Clear();
                                    Response.Write("-1");
                                    Response.End();
                                }
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
                            Model.RTKUserInfo mrtk = DAL.RTKUserInfo.GetModel2(UserName);
                            if (mrtk != null)
                            {
                                if (PassWord == AES_Key.AESDecrypt(mrtk.PassWord, mrtk.UserName.PadLeft(16, '0')))
                                {
                                    mrtk.PassWord = AES_Key.AESEncrypt(NewPassWord, UserName.PadLeft(16, '0'));
                                    if (DAL.RTKUserInfo.Update(mrtk))
                                    {
                                        Response.Clear();
                                        Response.Write("1");
                                        Response.End();
                                    }
                                    else
                                    {
                                        Response.Clear();
                                        Response.Write("-1");
                                        Response.End();
                                    }
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
                                Response.Clear();
                                Response.Write("-1");
                                Response.End();
                            }
                        }
                    }
                }

            }

        }

        public string getnewstr(string str)
        {
            return Regex.Replace(str.Trim(), "\\s+", " ");
        }
    }
}