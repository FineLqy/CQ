using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.functions
{
    public partial class UserInfoAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["KEY"] == "Ld3Fx17etlofT3fT7D")
            {
                #region 查询
                if ( Request["UserName"] != null&& Request["PassWord"] !=null)
                {
                    string result = "{\"result\":\"@result\",\"message\": @message,\"code\": \"@code\"}";
                    try
                    {
                        string username = Request["UserName"].ToString();
                     
                        string PassWord = AES_Key.AESEncrypt(Request["PassWord"].ToString(), username.PadLeft(16, '0'));
                       DataSet data= DAL.RegisterUser.GetUserNameList(" UserName='"+username+"' and PassWord='"+PassWord+"'");


                        if (data.Tables[0].Rows.Count>0)
                        {
                            Model.RegisterUser RegisterUser = DAL.RegisterUser.GetModel(username);


                            if (RegisterUser.UserType == 1)
                            {
                                DataSet ds = DAL.RTKUserInfo.GetList("RegisterUserName ='" + username + "'");
                                if (ds.Tables[0].Rows.Count>0)
                                {
                                    //result = result.Replace("@result", "success");
                                    //result = result.Replace("@message", JsonConvert.SerializeObject(ds.Tables[0]));
                                    //result = result.Replace("@code", "1");
                                    result = "{\"result\":\"@failed\",\"message\": "+ JsonConvert.SerializeObject(ds.Tables[0]) + ",\"code\": \"1\"}";
                                    Response.Clear();
                                    Response.Write(result);
                                    Response.End();
                                }
                                else
                                {
                                    //result = result.Replace("@result", "failed");
                                    //result = result.Replace("@message", "没有数据！");
                                    //result = result.Replace("@code", "-3");
                                    result = "{\"result\":\"@failed\",\"message\": \"没有数据\",\"code\": \"-3\"}";
                                    Response.Clear();
                                    Response.Write(result);
                                    Response.End();
                                }
                              
                                
                            }
                            if (RegisterUser.UserType == 3)
                            {

                                DataSet ds = DAL.RTKUserInfo.GetList("1=1");
                                if (ds.Tables[0].Rows.Count>0)
                                {
                                    result = result.Replace("@result", "success");
                                    result = result.Replace("@message", JsonConvert.SerializeObject(ds.Tables[0]));
                                    result = result.Replace("@code", "1");

                                    Response.Clear();
                                    Response.Write(result);
                                    Response.End();
                                }
                                else
                                {
                                    //result = result.Replace("@result", "failed");
                                    //result = result.Replace("@message", "没有数据！");
                                    //result = result.Replace("@code", "-3");
                                    result = "{\"result\":\"@failed\",\"message\": \"没有数据\",\"code\": \"-3\"}";
                                    Response.Clear();
                                    Response.Write(result);
                                    Response.End();
                                }

                               
                            }


                        }
                        else
                        {
                            //result = result.Replace("@result", "failed");
                            //result = result.Replace("@message", "用户名或密码错误！");
                            //result = result.Replace("@code", "-2");
                            result = "{\"result\":\"@failed\",\"message\": \"用户名或密码错误\",\"code\": \"-2\"}";
                            Response.Clear();
                            Response.Write(result);
                            Response.End();
                        }

                    }
                    catch (Exception)
                    {
                        if (result.Contains("@message"))
                        {
                            //result = result.Replace("@result", "failed");
                            //result = result.Replace("@message", "数据错误！");
                            //result = result.Replace("@code", "-1");
                            result = "{\"result\":\"@failed\",\"message\": \"数据错误\",\"code\": \"-1\"}";
                            Response.Clear();
                            Response.Write(result);
                            Response.End();
                        }
                    }
                }
            }
        }



        //public void GetRtkInfo()
        //{
          
        //}
    }
}
#endregion