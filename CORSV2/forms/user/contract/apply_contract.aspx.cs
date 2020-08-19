using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.contract
{
    public partial class apply_contract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 0 || Convert.ToInt32(Session["UserType"]) > 5)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!Get_invoice())
                {
                    Response.Write("0");

                }
            }

            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                DeleteCors();
            }
            if (Request["invoiceListId"]!=null)
            {
                string invoiceListID = Request["invoiceListID"].ToString();
                Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(Convert.ToInt32(Request["invoiceListID"]));
                invoiceList.ContractStatus = 2;
                DAL.InvoiceList.Update(invoiceList);
                Response.Write("success");
                Response.End();
            }
            if (Request["action"] != null && Request["action"] == "downloadfile")
            {
                string ID = Request["id"].ToString();
                Model.ContractApplication contract = DAL.ContractApplication.GetModel(ID);
                if (contract.UserName != Session["UserName"].ToString())
                {
                    Response.End();
                }
                else
                {
                    //string fileName = invoiceList.InvoiceFile;//客户端保存的文件名
                    //string filePath = Server.MapPath("DownLoad/aaa.txt");//路径
                    string filePath = this.Server.MapPath(contract.ContractFile);//文件路径，可用相对路径
                    FileInfo fileInfo = new FileInfo(filePath);
                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(fileInfo.Name.ToString()));
                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.ContentType = "application/octet-stream";
                    Response.ContentEncoding = System.Text.Encoding.Default;
                    Response.WriteFile(fileInfo.FullName);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        private bool Get_invoice()
        {
            string sort = "SubmitTime";
            string order = "DESC";
            string search = "";
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            if (Request["search"] != null)
                search = Request["search"].ToString();
         
            string strwhere = "1=1";
            int totalCount = DAL.ContractApplication.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            strwhere = "UserName='" + Session["UserName"].ToString() + "'";
            DataSet ds = DAL.ContractApplication.GetBriefList(offset, limit, search);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("invoice", typeof(string));
            ds.Tables[0].Columns.Add("reSubmitTime", typeof(string));
            ds.Tables[0].Columns.Add("deOrderNumber", typeof(string));
            ds.Tables[0].Columns.Add("recontractStatus",typeof(string));
            ds.Tables[0].Columns.Add("Remarks", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dr["deOrderNumber"] = dr["ID"].ToString();
                if (dr["Type"].ToString()=="0")
                {
                    dr["recontractStatus"] = "草稿";
                }
                if (dr["Type"].ToString() == "1")
                {
                    dr["recontractStatus"] = "正式";
                }
                // string temp_time=((DateTime)dr["SubmitTime"]).ToString("yyyy-MM-dd");
                dr["reSubmitTime"] = dr["ApplicationTime"].ToString();
                dr["Remarks"] = dr["Remark"].ToString();
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
                dr["button"] = "<a id='" + dr["ID"] + "'  >查看</a>";


             

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
            
            string ordernumber = Request["id"];
            try
            {
              
                   
                   
                    //删除该订单
                    bool result = DAL.ContractApplication.Delete(ordernumber);
                
               
            }
            catch (Exception)
            {
            }
        }
    }
}