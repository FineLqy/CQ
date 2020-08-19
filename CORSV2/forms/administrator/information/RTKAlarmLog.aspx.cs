using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class RTKAlarmLog : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {

                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {

            }
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetEquips())
                {
                    Response.Write("0");

                }
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
            {
                search = Request["search"].ToString();
            }

         

            int totalCount = DAL.ErrorRTKRecord.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            string strwhere = "1=1";
            if ((Request["dataType1"] != null))
            {
                if (Request["dataType1"].ToString().Contains("报警类型"))
                { }
                else
                {
                    strwhere += (" and ErrorType like '%" + Request["dataType1"].ToString() + "%'");
                }
            }
            DataSet ds = DAL.ErrorRTKRecord.GetBriefList(offset, limit, search, strwhere);

            ds.Tables[0].Columns.Add("ErrorTime1", typeof(string));

            ds.Tables[0].Columns.Add("deErrorType", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["ErrorTime1"] = dr["ErrorTime"].ToString();
                if (dr["ErrorType"].ToString()=="0")
                {
                    dr["deErrorType"] = "超出范围";
                }
                if (dr["ErrorType"].ToString() == "1")
                {
                    dr["deErrorType"] = "密码错误";
                }
                if (dr["ErrorType"].ToString() == "2")
                {
                    dr["deErrorType"] = "其他错误";
                }
            }
            string jsonComs = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
            result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonComs + "}";
            Response.ContentType = "application/Json";
            Response.Write(result);
            Response.End();
            if (ds.Tables[0].Rows.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}