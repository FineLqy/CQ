using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace CORSV2.forms.publicforms.login
{
    public partial class login : System.Web.UI.Page
    {
        public static string code = "";
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Request["action"] == "getcode")
            {
                //string code;
                Bitmap bmp = cs.VerifyCodeHelper.CreateVerifyCodeBmp(out code);
                Bitmap newbmp = new Bitmap(bmp, 108, 36);
                //GetMD5Hash32(code);
                // Session["VerifyCode"] = code;

                Response.Clear();
                Response.ContentType = "image/bmp";
                newbmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            if (Request["action"] == "login")
            {
                string VerifyCode = Request["VerifyCode"];
                string username = Request["UserName"];
                string password = Request["PassWord"];
                //string code = Session["VerifyCode"].ToString();
                //验证输入的验证码是否正确
                if (VerifyCode.ToLower() != code.ToLower())
                {
                    Response.Write("-1");
                    Response.End();
                }

                //Response.Write("<script>alert(\"1\")</script>");
                //return;   
                Model.RegisterUser registeruser = new Model.RegisterUser();
                Model.RTKUserInfo rtkUserInfo = new Model.RTKUserInfo();
                string sessionUserName = "";
                string tempUserName = "";
                string tempPassWord = "";
                int tempUserType = 0;
                string symbol = "";
                try
                {
                    if (DAL.RegisterUser.Exists(username))
                    {
                        tempUserName = username;
                        registeruser = DAL.RegisterUser.GetModel(username);
                        sessionUserName = registeruser.UserName;


                        // 求时间差
                        TimeSpan ts = DateTime.Now - registeruser.LastLoginTime;

                        //如果登录时间在300分钟外并且为超级管理员 则检索数据库 向过期RTK用户发短信
                        if (Math.Abs(ts.TotalMinutes) > 300 && registeruser.UserType == 3)
                        {
                            DataSet ds = DAL.RTKUserPurview.GetList("1=1");
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {

                                DateTime dt1 = Convert.ToDateTime(dr["EndTime"].ToString());

                                DateTime dt2 = DateTime.Now;

                                TimeSpan deta = DateTime.Now - dt1;

                                if (Math.Abs(deta.TotalDays) < 30)
                                {

                                    string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                                    string message = "用户您好：RTK账号即将到期，请及时登录CORS管理系统查看!";

                                    SMS = SMS.Replace("@message", message);
                                    SMS = SMS.Replace("@phone", DAL.RTKUserInfo.GetModel(dr["UserName"].ToString()).ContactPhone);

                                    if (cs.HttpHelper.SendSMS(SMS))
                                    {

                                    }
                                    else
                                    {
                                        cs.WebLogger.WriteErroLog("续费提醒短信发送错误");    //输出到文件中
                                    }

                                }
                            }
                        }

                        //如果登录在半小时内超过三次则无效
                        if (Math.Abs(ts.TotalMinutes) < 30 && registeruser.TryLoginTimes > 3)
                        {
                            //登录频繁则返回
                            symbol = "-3";
                        }

                        else
                        {
                            registeruser.TryLoginTimes += 1;
                            registeruser.LastLoginTime = DateTime.Now;
                            tempPassWord = AES_Key.AESDecrypt(registeruser.PassWord, registeruser.UserName.PadLeft(16, '0'));
                            tempUserType = registeruser.UserType;
                            DAL.RegisterUser.Update(registeruser);
                        }
                    }
                    else if (DAL.RegisterUser.ExistsPhone(username))
                    {

                        registeruser = DAL.RegisterUser.GetModelByPhone(username);
                        tempUserName = registeruser.Phone;
                        sessionUserName = registeruser.UserName;
                        // 求时间差
                        TimeSpan ts = DateTime.Now - registeruser.LastLoginTime;

                        //如果登录时间在300分钟外并且为超级管理员 则检索数据库 向过期RTK用户发短信
                        if (Math.Abs(ts.TotalMinutes) > 300 && registeruser.UserType == 3)
                        {
                            DataSet ds = DAL.RTKUserPurview.GetList("1=1");
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {

                                DateTime dt1 = Convert.ToDateTime(dr["EndTime"].ToString());

                                DateTime dt2 = DateTime.Now;

                                TimeSpan deta = DateTime.Now - dt1;

                                if (Math.Abs(deta.TotalDays) < 30)
                                {

                                    string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
                                    string message = "用户您好：RTK账号" + dr["UserName"].ToString() + "即将到期，请及时登录CORS管理系统查看!";

                                    SMS = SMS.Replace("@message", message);
                                    SMS = SMS.Replace("@phone", DAL.RTKUserInfo.GetModel(dr["UserName"].ToString()).ContactPhone);

                                    if (cs.HttpHelper.SendSMS(SMS))
                                    {

                                    }
                                    else
                                    {
                                        cs.WebLogger.WriteErroLog("续费提醒短信发送错误");    //输出到文件中
                                    }

                                }
                            }
                        }
                        //如果登录在半小时内超过三次则无效
                        if (Math.Abs(ts.TotalMinutes) < 30 && registeruser.TryLoginTimes > 3)
                        {
                            //登录频繁则返回
                            symbol = "-3";
                            Session["UserType"] = tempUserType;
                            Session["UserName"] = sessionUserName;
                            Model.SysLog mSysLog = new Model.SysLog();
                            mSysLog.LogTime = DateTime.Now;
                            mSysLog.LogType = 0;
                            mSysLog.UserName = sessionUserName;
                            mSysLog.Remark = "登录次数超出限制:";
                            DAL.SysLog.Add(mSysLog);
                            Response.End();
                        }

                        else
                        {
                            registeruser.TryLoginTimes += 1;
                            registeruser.LastLoginTime = DateTime.Now;
                            tempPassWord = AES_Key.AESDecrypt(registeruser.PassWord, registeruser.UserName.PadLeft(16, '0'));
                            tempUserType = registeruser.UserType;
                            DAL.RegisterUser.Update(registeruser);
                        }
                    }

                    else if (DAL.RTKUserInfo.Exists(username))
                    {
                        tempUserName = username;
                        sessionUserName = username;
                        rtkUserInfo = DAL.RTKUserInfo.GetModel(username);
                        tempPassWord = AES_Key.AESDecrypt(rtkUserInfo.PassWord, rtkUserInfo.UserName.PadLeft(16, '0'));
                        tempUserType = 0;
                    }
                    else
                    {
                        //用户名不存在则返回
                        symbol = "-2";

                    }

                }

                catch (System.Threading.ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    cs.WebLogger.WriteErroLog(ex.ToString());    //输出到文件中
                    //Response.Write("<script>alert(\"1\")</script>");
                    return;
                }
                if (symbol == "-2")
                {
                    Response.Write("-2");
                    Response.End();
                    return;
                }
                if (symbol == "-3")
                {//111
                    Response.Write("-3");
                    Response.End();
                    return;
                }


                if (getEncryption(tempPassWord, tempUserName, code, true) == password)
                {
                    //StreamReader sr = new StreamReader("D:\\jizhan.txt");
                    //sr.ReadLine();
                    //while (!sr.EndOfStream)
                    //{
                    //    string line = sr.ReadLine();
                    //    string[] mm = Regex.Split(line.Trim(), "\\s+", RegexOptions.IgnoreCase);
                    //    Model.CORSStationInfo cORSStationInfo = new Model.CORSStationInfo();
                    //    cORSStationInfo.StationName = mm[1];
                    //    cORSStationInfo.StationOName = mm[0];
                    //    cORSStationInfo.Lat = Convert.ToDouble(mm[2]);
                    //    cORSStationInfo.Lon = Convert.ToDouble(mm[3]);
                    //    cORSStationInfo.H = Convert.ToDouble(mm[4]);
                    //    cORSStationInfo.Remark = "";
                    //    cORSStationInfo.IP = mm[5];
                    //    cORSStationInfo.Port = "9902";
                    //    cORSStationInfo.TransferType = "TCP/IP";
                    //    cORSStationInfo.IsOK = 1;
                    //    DAL.CORSStationInfo.Add(cORSStationInfo);

                    //    Model.EquipmentInfo eq = new Model.EquipmentInfo();
                    //    eq.StationOName = cORSStationInfo.StationOName;
                    //    eq.StationName = cORSStationInfo.StationName;
                    //    eq.IP = cORSStationInfo.IP;
                    //    eq.Port = cORSStationInfo.Port;

                    //    DAL.EquipmentInfo.Add(eq);

                    //    Model.SiteMonitoring ms = new Model.SiteMonitoring();
                    //    ms.StationOName = cORSStationInfo.StationOName;
                    //    DAL.SiteMonitoring.Add(ms);

                    //}
                    //sr.Close();

                    Session["UserType"] = tempUserType;
                    Session["UserName"] = sessionUserName;
                    Model.SysLog mSysLog = new Model.SysLog();

                    switch (tempUserType)
                    {

                        case 0:
                            Response.Write("<script>location.href = \"/forms/cors_user.aspx\";</script>");


                            mSysLog.LogTime = DateTime.Now;
                            mSysLog.LogType = 0;
                            mSysLog.UserName = sessionUserName;
                            mSysLog.Remark = "登录成功:";
                            DAL.SysLog.Add(mSysLog);
                            Response.End();
                            break;
                        case 1:
                            //registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                            registeruser.TryLoginTimes = 0;
                            DAL.RegisterUser.Update(registeruser);
                            Response.Write("<script>location.href = \"/forms/cors_user.aspx\";</script>");


                            mSysLog.LogTime = DateTime.Now;
                            mSysLog.LogType = 0;
                            mSysLog.UserName = sessionUserName;
                            mSysLog.Remark = "登录成功:";
                            DAL.SysLog.Add(mSysLog);
                            Response.End();
                            break;
                        case 2:
                            //registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                            registeruser.TryLoginTimes = 0;
                            DAL.RegisterUser.Update(registeruser);
                            Response.Write("<script>location.href = \"/forms/cors_admin.aspx\";</script>");

                            mSysLog.LogTime = DateTime.Now;
                            mSysLog.LogType = 0;
                            mSysLog.UserName = sessionUserName;
                            mSysLog.Remark = "登录成功:";
                            DAL.SysLog.Add(mSysLog);
                            Response.End();
                            break;
                        case 3:
                            //registeruser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                            registeruser.TryLoginTimes = 0;
                            DAL.RegisterUser.Update(registeruser);
                            Response.Write("<script>location.href = \"/forms/cors_admin.aspx\";</script>");


                            mSysLog.LogTime = DateTime.Now;
                            mSysLog.LogType = 0;
                            mSysLog.UserName = sessionUserName;
                            mSysLog.Remark = "管理员登录成功:";
                            DAL.SysLog.Add(mSysLog);
                            Response.End();
                            break;
                        default:
                            break;
                    }

                    if (Session["UserType"].ToString() == "1")
                    {


                        Response.Write("1");
                        Response.End();
                    }
                    if (Session["UserType"].ToString() == "3")
                    {


                        Response.Write("3");
                        Response.End();
                    }
                }
                else
                {
                    Model.SysLog mSysLog = new Model.SysLog();
                    mSysLog.LogTime = DateTime.Now;
                    mSysLog.LogType = 0;
                    mSysLog.UserName = sessionUserName;
                    mSysLog.Remark = "登录密码错误";
                    DAL.SysLog.Add(mSysLog);

                    //密码错误则返回
                    Response.Write("0");
                    Response.End();
                    return;
                }
                //Model.RegisterUser registeruser = new Model.RegisterUser();

                //    if (DAL.RegisterUser.Exists(username))
                //    {
                //        registeruser = DAL.RegisterUser.GetModel(username);
                //    }
                //    else
                //    {
                //        Response.Write("-2");
                //        Response.End();
                //    }
                //    Response.Write("<script>alert(\"1\")</script>");
                //    return;  
                //string ff=GetMD5Hash32(registeruser.PassWord);
                //string rff=GetMD5Hash16(registeruser.PassWord);
                //string frf = getEncryption(registeruser.PassWord, username, code, true);

            }

        }

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <returns>返回32位的字符串</returns>
        public static string getEncryption(string password, string uin, string vcode, bool isMd5)
        {
            var str1 = isMd5 ? password : GetMD5Hash32(password);
            var str2 = GetMD5Hash32(str1 + uin);
            var str3 = GetMD5Hash32(str2 + vcode.ToUpper());
            return str3;
        }



        /// <summary>
        /// 加密字符串，返回32位字符串
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <returns>返回32位的字符串</returns>
        public static string GetMD5Hash32(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            string str = BitConverter.ToString(res).Replace("-", "");
            return str.ToLower();
        }


        /// <summary>
        /// 加密字符串，返回16位字符串
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <returns>返回16位的字符串</returns>
        public static string GetMD5Hash16(String input)
        {
            return GetMD5Hash32(input).Substring(8, 16);
        }
    }
}