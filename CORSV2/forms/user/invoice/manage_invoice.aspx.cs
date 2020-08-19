using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.user.invoice
{
    public partial class manage_invoice : System.Web.UI.Page
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
            if (Request["action"] != null && Request["action"] == "downloadfile")
            {
                string invoiceListID = Request["invoiceListID"].ToString();
                Model.InvoiceList invoiceList = DAL.InvoiceList.GetModel(Convert.ToInt32(Request["invoiceListID"]));
                if(invoiceList.UserName!=Session["UserName"].ToString())
                {
                    Response.End();
                }
                else
                {
                    //string fileName = invoiceList.InvoiceFile;//客户端保存的文件名
                    //string filePath = Server.MapPath("DownLoad/aaa.txt");//路径
                    string filePath = this.Server.MapPath(invoiceList.InvoiceFile);//文件路径，可用相对路径
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
            if (Request["sort"] != null)
            {

                sort = Request["sort"].ToString() == "reSubmitTime" ? "SubmitTime" : Request["sort"].ToString();
                order = Request["order"].ToString();

            }
            string strwhere = "1=1";
            int totalCount = DAL.InvoiceList.GetRecordCount(search);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            strwhere = "UserName='" + Session["UserName"].ToString() + "'";
            DataSet ds = DAL.InvoiceList.GetBriefList1(offset, limit, sort, order, search,strwhere);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("invoice", typeof(string));
            ds.Tables[0].Columns.Add("reSubmitTime", typeof(string));
            ds.Tables[0].Columns.Add("rePayTime", typeof(string));
            //ds.Tables[0].Columns.Add("deType", typeof(string));
            
             foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //if (dr["Type"].ToString()=="0")
                //{
                //    dr["deType"] = "账号申请";
                //}
                //if (dr["Type"].ToString() == "1")
                //{
                //    dr["deType"] = "账号续费";
                //}
                //if (dr["Type"].ToString() == "2")
                //{
                //    dr["deType"] = "账号充值";
                //}
                // string temp_time=((DateTime)dr["SubmitTime"]).ToString("yyyy-MM-dd");
                dr["reSubmitTime"] = dr["SubmitTime"].ToString();
                dr["rePayTime"] = dr["PayTime"].ToString();
                //dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
              


                if (dr["Status"].ToString() == "1")
                {
                    dr["invoice"] = "<a id='" + dr["ID"] + "' onclick= invoice(this.id)  >待申请</a>";
                }
                else if (dr["Status"].ToString() == "2")
                {
                    dr["invoice"] = "<a id='" + dr["ID"] + "'>待审核</a>";
                }
                else if (dr["Status"].ToString() == "3")
                {
                    dr["invoice"] = "<a id='" + dr["ID"] + "'>待开具</a>";
                }
                else if (dr["Status"].ToString() == "4")
                {
                    dr["invoice"] = "<a id='" + dr["ID"] + "' href='/forms/user/invoice/manage_invoice.aspx?action=downloadfile&invoiceListID="+dr["ID"]+"' >已开具,点击下载</a>";
                    dr["button"] = "<a id='" + dr["ID"] + "' href='/forms/user/invoice/ContractApplication.aspx?id=" + dr["ID"] + "' >索要合同</a>";
                  
                }
                else
                {
                    dr["invoice"] = "<a id='" + dr["ID"] + "'>已驳回</a>";
                }
                if (dr["ContractStatus"].ToString()=="4")
                {
                    dr["button"] = "<a  >合同索要成功</a>";
                }

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
                    string ordernumber = DAL.InvoiceList.GetModel(ids[m]).OrderNumber;
                    //删除该订单
                    bool result = DAL.InvoiceList.Delete(ordernumber);
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