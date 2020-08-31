using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.order
{
    public partial class PaymentRecord : System.Web.UI.Page
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
            Model.RegisterUser RegisterUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
            Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(RegisterUser.CertifiationIndex));
            string Company = companyInfo.Company;


            int totalCount = DAL.PaymentRecord.GetRecordCount(Company);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            string strwhere = "1=1";
            if ((Request["dataType1"] != null))
            {
                if (Request["dataType1"].ToString().Contains("类型"))
                { }
                else
                {
                    strwhere += (" and Type like '%" + Request["dataType1"].ToString() + "%'");
                }
            }
            
            
            DataSet ds = DAL.PaymentRecord.GetBriefList(offset, limit, search, strwhere, Company, Session["UserName"].ToString());

            ds.Tables[0].Columns.Add("deRechargeTime", typeof(string));

            ds.Tables[0].Columns.Add("deType", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
               
                if (dr["Type"].ToString().Trim() == "0"|| dr["Type"].ToString().Trim() == "3")
                {
                    dr["deType"] = "申请";
                 
                }
                if (dr["Type"].ToString().Trim() == "1")
                {
                    dr["deType"] = "续费";
                }
                if (dr["Type"].ToString().Trim() == "2")
                {
                    dr["deType"] = "充值";
                }
                dr["deRechargeTime"] = dr["RechargeTime"].ToString();
               
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