using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.order
{
    public partial class End_Recharge : System.Web.UI.Page
    {
        public string price = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            string SMS = "http://39.108.107.73:8090/sysmonitor/services/monitor/sendmessage.json?key=is8ji3&phone=@phone&message=@message";
            string message = "管理员您好：有新订单待处理，请及时登录CORS管理系统查看!";
            string strwhere = "UserType = 3";
            DataSet dsRegisterUser = DAL.RegisterUser.GetList(strwhere);
            foreach (DataRow dr in dsRegisterUser.Tables[0].Rows)
            {
                SMS = SMS.Replace("@message", message);
                SMS = SMS.Replace("@phone", dr["Phone"].ToString());

                if (cs.HttpHelper.SendSMS(SMS))
                {

                }
                else
                {
                    cs.WebLogger.WriteErroLog("申请订单提醒短信发送错误");    //输出到文件中
                }
            }
        }
    }
}