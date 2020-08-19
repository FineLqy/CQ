using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.users
{
    public partial class AdminManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = "xcq";
            //Session["UserType"] = "3";
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetData())
                {
                    Response.Write("0");

                }
            }
            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                DeleteCors();
            }
        }
        private bool GetData()
        {
            string sort = "RegTime";
            string order = "DESC";
            string search = "";
            int offset = 0;
            int limit = 10;
            string strwhere = "1=1";
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();

            //平台协管员管理只包括 UserType = 1 的用户
            strwhere = strwhere + " and UserType = 2 ";

            if (Request["sort"] != null)
            {

                if (Request["sort"].ToString() == "reRegTime")
                {
                    sort = "RegTime";
                }
                else if (Request["sort"].ToString() == "reLastLoginTime")
                {
                    sort = "LastLoginTime";

                }
                else
                {
                    sort = Request["sort"].ToString();

                }
                order = Request["order"].ToString();

            }
            int totalCount = DAL.RegisterUser.GetRecordCount(search, strwhere);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            //strwhere = "UserName='" + Session["UserName"].ToString() + "'";
            DataSet ds = DAL.RegisterUser.GetBriefList1(offset, limit, sort, order, search, strwhere);
            //ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("reRegTime", typeof(string));
            ds.Tables[0].Columns.Add("reLastLoginTime", typeof(string));
            ds.Tables[0].Columns.Add("changePasswword", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["PassWord"] = AES_Key.AESDecrypt(dr["PassWord"].ToString(), dr["UserName"].ToString().PadLeft(16, '0'));
                dr["reRegTime"] = dr["RegTime"].ToString();
                dr["reLastLoginTime"] = dr["LastLoginTime"].ToString();
                dr["changePasswword"] = "<a id='" + dr["ID"] + "' onclick=changePasswword(this.id) >设置</a>";
          
            }
            string result = "";
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
                string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }
        private void DeleteCors()
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
                    //删除该用户
                    bool result = DAL.RegisterUser.Delete(ids[m]);
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