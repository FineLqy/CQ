using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;

namespace CORSV2.forms.administrator.order
{
    public partial class manage_order : System.Web.UI.Page
    {
        /// <summary>
        /// 设置全局静态变量belongArea
        /// </summary>
        public static string belongArea = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 2 || Convert.ToInt32(Session["UserType"]) > 3)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/Login/Login.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] != null && Session["UserType"].ToString() == "2")
            {
                Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(Session["UserName"].ToString());
                cityType.Items.Clear();
                cityType.Items.Add(registerUser.BelongArea);
                cityType.Value = registerUser.BelongArea;
                belongArea = registerUser.BelongArea;
            }

            if (Request["action"] != null && Request["action"] == "GetData")
            {
                GetCors();
            }
            if (Request["action"] != null && Request["action"] == "DeleteCors")
            {
                DeleteCors();
            }
            if (Request["id"] != null)
            {
                Model.OrderList orderlist = DAL.OrderList.GetModel(Convert.ToInt32(Request["id"]));
                string img_path = orderlist.TransferCertificate;
                Response.Write("<img src='" + img_path + "' />");
                Response.End();
            }
            if (Request["verify"] != null)
            {
                AddData();
            }

            if (Request["action"] != null && Request["action"] == "DownloadAll")
            {
                DownloadAll();
            }
        }


        private void DownloadAll()
        {
            if (Session["UserName"] == null)
            { }
            else
            {
                DataTable dt = DAL.OrderList.GetList("1=1 order by id asc").Tables[0];
                //  PassWord.Value = AES_Key.AESDecrypt(mrtk.PassWord, mrtk.UserName.PadLeft(16, '0'));
                WriteExcelWithNPOI(dt, "xls");
                // WriteExcelWithNPOI(dt1, "xls");
            }
        }

        public void WriteExcelWithNPOI(DataTable dt, String extension)
        {

            IWorkbook workbook;

            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "用户订单列表.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "用户订单列表.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
        private bool AddData()
        {
            try
            {
                Model.OrderList orderlist = DAL.OrderList.GetModel(Convert.ToInt32(Request["verify"]));
                if (Request["status"] == "OK")
                {
                    orderlist.OrderStatus = 2;

                    if (orderlist.OrdeType==0)//账号申请
                    {
                        //订单审核通过后添加发票信息
                        Model.InvoiceList invoicelist = new Model.InvoiceList();
                        invoicelist.OrderDetail = orderlist.ID.ToString();
                        invoicelist.OrderNumber = orderlist.OrderNumber;
                        invoicelist.BelongArea = orderlist.WorkArea;
                        invoicelist.PayTime = orderlist.PayTime;
                        invoicelist.Price = orderlist.Price;
                        invoicelist.Status = 1;
                        invoicelist.ContractStatus = 1;
                        invoicelist.UserName = orderlist.UserName;
                        invoicelist.Type = 0;
                        DAL.InvoiceList.Add(invoicelist);
                        Model.RTKUserInfo rtkUserInfo = new Model.RTKUserInfo();
                        for (int i = 0; i < orderlist.AccountNum; i++)
                        {

                            Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(orderlist.UserName);
                          
                            System.Random a = new Random(DateTime.Now.Millisecond);
                            // use System.DateTime.Now.Millisecond as seed
                            int RandKey = a.Next(100, 999);
                            Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(registerUser.CertifiationIndex));
                            rtkUserInfo.RegisterUserName = orderlist.UserName;
                            rtkUserInfo.UserName = orderlist.UserName + RandKey.ToString();
                            rtkUserInfo.Company = companyInfo.Company;
                            rtkUserInfo.PassWord = AES_Key.AESEncrypt(rtkUserInfo.UserName, rtkUserInfo.UserName.PadLeft(16, '0'));
                            rtkUserInfo.UserType = 0;
                            rtkUserInfo.OrderNumber = orderlist.OrderNumber;
                            rtkUserInfo.CORSCardNum = "";
                            rtkUserInfo.BelongArea = registerUser.BelongArea;
                            rtkUserInfo.Contact = companyInfo.Contact;
                            rtkUserInfo.ContactPhone = registerUser.Phone;
                            rtkUserInfo.ContactEmail = registerUser.Email;
                        
                            rtkUserInfo.RegTime = DateTime.Now;

                            if (!DAL.RTKUserInfo.Exists(rtkUserInfo.UserName))
                            {
                                DAL.RTKUserInfo.Add(rtkUserInfo);
                            }
                            else
                            {
                                //如何已经存在则重新循环一次
                                i = i - 1;
                                continue;
                            }


                            #region 权限信息部分

                            Model.RTKUserPurview rtkUserPurview = new Model.RTKUserPurview();
                            Model.RTKPostPurview rTKPostPurview = new Model.RTKPostPurview();
                            string startTime = DateTime.Now.ToString();

                            rtkUserPurview.UserName = rtkUserInfo.UserName;
                            rtkUserPurview.StartTime = DateTime.Now;
                            rtkUserPurview.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(orderlist.ServiceDuration));
                            rtkUserPurview.ServerType = orderlist.ServerType;

                            string CoorSystem = "";
                            string SourceTable = "";
                            rtkUserPurview.VRSEnable = 1;
                            rtkUserPurview.SourceTable = SourceTable;
                            rtkUserPurview.CoorSystem = CoorSystem;
                            if (orderlist.RoamID == "" || orderlist.RoamID == null)
                            {
                                rtkUserPurview.RoamID = "";
                            }
                            else
                            {
                                rtkUserPurview.RoamID = orderlist.RoamID;
                            }

                            if (orderlist.ElevationEnable == 1)
                            {
                                rtkUserPurview.ElevationEnable = 1;
                            }
                            else
                            {
                                rtkUserPurview.ElevationEnable = 0;
                            }


                            rTKPostPurview.UserName = rtkUserInfo.UserName;
                            rTKPostPurview.StartTime = DateTime.Now;
                            rTKPostPurview.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(orderlist.ServiceDuration));
                            DAL.RTKPostPurview.Add(rTKPostPurview);
                            DAL.RTKUserPurview.Add(rtkUserPurview);
                   
                            companyInfo.Balance = companyInfo.Balance - Convert.ToSingle(orderlist.Price);
                            DAL.CompanyInfo.Update(companyInfo);
                            #endregion
                        }



                    }
                    if (orderlist.OrdeType == 3)//账号申请（自定义账号）
                    {
                        //订单审核通过后添加发票信息
                        Model.InvoiceList invoicelist = new Model.InvoiceList();
                        invoicelist.OrderDetail = orderlist.ID.ToString();
                        invoicelist.OrderNumber = orderlist.OrderNumber;
                        invoicelist.BelongArea = orderlist.WorkArea;
                        invoicelist.PayTime = orderlist.PayTime;
                        invoicelist.Price = orderlist.Price;
                        invoicelist.Status = 1;
                        invoicelist.ContractStatus = 1;
                        invoicelist.UserName = orderlist.UserName;
                        invoicelist.Type = 0;
                        DAL.InvoiceList.Add(invoicelist);
                        Model.RTKUserInfo rtkUserInfo = new Model.RTKUserInfo();
                        

                            Model.RegisterUser registerUser = DAL.RegisterUser.GetModel(orderlist.UserName);
                        Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(Convert.ToInt32(registerUser.CertifiationIndex));

                        DataSet ds= DAL.DeUserInfo.GetList(orderlist.OrderNumber);
                            for (int i = 0; i <ds.Tables[0].Rows.Count; i++)
                            {
                                
                                rtkUserInfo.RegisterUserName = orderlist.UserName;
                            rtkUserInfo.UserName = ds.Tables[0].Rows[i]["UserName"].ToString();
                                rtkUserInfo.Company = companyInfo.Company;
                                rtkUserInfo.PassWord = AES_Key.AESEncrypt(rtkUserInfo.UserName, rtkUserInfo.UserName.PadLeft(16, '0'));
                                rtkUserInfo.UserType = 0;
                                rtkUserInfo.OrderNumber = orderlist.OrderNumber;
                                rtkUserInfo.BelongArea = registerUser.BelongArea;
                                rtkUserInfo.Contact = companyInfo.Contact;
                                rtkUserInfo.ContactPhone = registerUser.Phone;
                                rtkUserInfo.ContactEmail = registerUser.Email;
                            rtkUserInfo.CORSCardNum = "";
                            rtkUserInfo.RegTime = DateTime.Now;

                                if (!DAL.RTKUserInfo.Exists(rtkUserInfo.UserName))
                                {
                                    DAL.RTKUserInfo.Add(rtkUserInfo);
                                }
                                else
                                {
                                    //如何已经存在则重新循环一次
                                    i = i - 1;
                                    continue;
                                }


                                #region 权限信息部分

                                Model.RTKUserPurview rtkUserPurview = new Model.RTKUserPurview();
                                Model.RTKPostPurview rTKPostPurview = new Model.RTKPostPurview();
                                string startTime = DateTime.Now.ToString();

                                rtkUserPurview.UserName = rtkUserInfo.UserName;
                                rtkUserPurview.StartTime = DateTime.Now;
                                rtkUserPurview.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(orderlist.ServiceDuration));
                                rtkUserPurview.ServerType = orderlist.ServerType;

                                string CoorSystem = "";
                                string SourceTable = "";
                                rtkUserPurview.VRSEnable = 1;
                                rtkUserPurview.SourceTable = SourceTable;
                                rtkUserPurview.CoorSystem = CoorSystem;
                                if (orderlist.RoamID == "" || orderlist.RoamID == null)
                                {
                                    rtkUserPurview.RoamID = "";
                                }
                                else
                                {
                                    rtkUserPurview.RoamID = orderlist.RoamID;
                                }

                                if (orderlist.ElevationEnable == 1)
                                {
                                    rtkUserPurview.ElevationEnable = 1;
                                }
                                else
                                {
                                    rtkUserPurview.ElevationEnable = 0;
                                }


                                rTKPostPurview.UserName = rtkUserInfo.UserName;
                                rTKPostPurview.StartTime = DateTime.Now;
                                rTKPostPurview.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(orderlist.ServiceDuration));
                                DAL.RTKPostPurview.Add(rTKPostPurview);
                                DAL.RTKUserPurview.Add(rtkUserPurview);

                               
                                #endregion
                            }
                        companyInfo.Balance = companyInfo.Balance - Convert.ToSingle(orderlist.Price);
                        DAL.CompanyInfo.Update(companyInfo);
                        Model.PaymentRecord paymentRecord = new Model.PaymentRecord();
                        paymentRecord.ProductName = "账号申请";
                        paymentRecord.Company = orderlist.company;
                        paymentRecord.Type = orderlist.OrdeType;
                        paymentRecord.Money = "-" + orderlist.Price;
                        paymentRecord.RechargeTime = DateTime.Now;
                        paymentRecord.UserName = orderlist.UserName;
                        DAL.PaymentRecord.Add(paymentRecord);





                    }
                    if (orderlist.OrdeType == 1)//账号续费
                    {
                        Model.InvoiceList invoicelist = new Model.InvoiceList();
                        invoicelist.OrderDetail = orderlist.ID.ToString();
                        invoicelist.OrderNumber = orderlist.OrderNumber;
                        invoicelist.BelongArea = orderlist.WorkArea;
                        invoicelist.PayTime = orderlist.PayTime;
                        invoicelist.Price = orderlist.Price;
                        invoicelist.Status = 1;
                        invoicelist.ContractStatus = 1;
                        invoicelist.UserName = orderlist.UserName;
                        invoicelist.Type = 1;
                        DAL.InvoiceList.Add(invoicelist);
                        string a = orderlist.OrderContent;
                        string name= orderlist.OrderContent.Substring(4);
                        Regex regex = new Regex(";");//以  [##]  分割 
                        string[] result = regex.Split(name);
                        for (int i = 0; i < result.Length; i++)
                        {
                            if (result[i]!="")
                            {
                                
                                Model.RTKUserPurview rtkUserPurview = DAL.RTKUserPurview.GetModel(result[i]);
                                Model.RTKPostPurview rTKPostPurview = DAL.RTKPostPurview.GetModel(result[i]);

                                rtkUserPurview.UserName = result[i];


                                rtkUserPurview.EndTime = rtkUserPurview.EndTime.AddMonths(Convert.ToInt32(orderlist.ServiceDuration));


                                rTKPostPurview.UserName = result[i];
                                rTKPostPurview.EndTime = rTKPostPurview.EndTime.AddMonths(Convert.ToInt32(orderlist.ServiceDuration));
                                DAL.RTKPostPurview.Update1(rTKPostPurview);
                                DAL.RTKUserPurview.Update1(rtkUserPurview);


                            }
                           

                        }
                        Model.CompanyInfo companyInfo = DAL.CompanyInfo.GetModel(orderlist.company);
                        companyInfo.Balance = companyInfo.Balance- Convert.ToSingle(orderlist.Price);
                        DAL.CompanyInfo.Update(companyInfo);
                        Model.PaymentRecord paymentRecord = new Model.PaymentRecord();
                        paymentRecord.ProductName = "账号续费";
                        paymentRecord.Company = orderlist.company;
                        paymentRecord.Type = orderlist.OrdeType;
                        paymentRecord.Money = "-" + orderlist.Price;
                        paymentRecord.RechargeTime = DateTime.Now;
                        paymentRecord.UserName = orderlist.UserName;
                        DAL.PaymentRecord.Add(paymentRecord);




                    }
                    if (orderlist.OrdeType == 2)//账号充值
                    {
                        Model.InvoiceList invoicelist = new Model.InvoiceList();
                        invoicelist.OrderDetail = orderlist.ID.ToString();
                        invoicelist.OrderNumber = orderlist.OrderNumber;
                        invoicelist.BelongArea = orderlist.WorkArea;
                        invoicelist.PayTime = orderlist.PayTime;
                        invoicelist.Price = orderlist.Price;
                        invoicelist.Status = 1;
                        invoicelist.ContractStatus = 1;
                        invoicelist.UserName = orderlist.UserName;
                        invoicelist.Type = 2;
                        DAL.InvoiceList.Add(invoicelist);

                       Model.CompanyInfo companyInfo=  DAL.CompanyInfo.GetModel(orderlist.company);
                        companyInfo.Balance += Convert.ToSingle( orderlist.Price);
                        DAL.CompanyInfo.Update(companyInfo);
                        Model.PaymentRecord paymentRecord = new Model.PaymentRecord();
                        paymentRecord.ProductName = "账号充值";
                        paymentRecord.Company = orderlist.company;
                        paymentRecord.Type = orderlist.OrdeType;
                        paymentRecord.Money = orderlist.Price;
                        paymentRecord.RechargeTime = DateTime.Now;
                        paymentRecord.UserName = orderlist.UserName;
                        DAL.PaymentRecord.Add(paymentRecord);

                    }
                   

         

                    
                }
                else
                {
                    orderlist.OrderStatus = 3;
                }
                DAL.OrderList.Update(orderlist);
                return true;
            }
            catch (System.Threading.ThreadAbortException)
            {
                return true;
            }
            catch (Exception ex)
            {
                cs.WebLogger.WriteErroLog(ex.ToString());    //输出到文件中
                //Response.Write("<script>alert(\"1\")</script>");
                return true;
            }
        }
        private bool GetCors()
        {
            string sort = "SubmitTime";
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
        
                //int dataTypenum = int.Parse(Request["dataType"].ToString());
                if ((Request["cityType"] != null))
                {
                    if (Request["cityType"].ToString().Contains("全部订单"))
                    { }
                    else
                    {
                        strwhere += (" and OrdeType like '%" + Request["cityType"].ToString() + "%'");
                    }
                }
            
       
            if (Request["sort"] != null)
            {
                if (Request["sort"].ToString() == "dealStatus")
                {
                    sort = "OrderStatus";
                }
                else if (Request["sort"].ToString() == "reSubmitTime")
                {
                    sort = "SubmitTime";

                }
                else if (Request["sort"].ToString() == "verify")
                {
                    sort = "OrderStatus";
                }

                else
                {
                    sort = Request["sort"].ToString();
                }

                order = Request["order"].ToString();

            }
            int totalCount = DAL.OrderList.GetRecordCount(search, strwhere);
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.OrderList.GetBriefList1(offset, limit, sort, order, search, strwhere);
            ds.Tables[0].Columns.Add("button", typeof(string));
            ds.Tables[0].Columns.Add("verify", typeof(string));
            ds.Tables[0].Columns.Add("dealStatus", typeof(string));
            ds.Tables[0].Columns.Add("reSubmitTime", typeof(string));
            ds.Tables[0].Columns.Add("deOrderType", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                if (dr["OrdeType"].ToString() == "0"|| dr["OrdeType"].ToString() == "3")
                {
                    dr["deOrderType"] = "订单申请";
                }
                if (dr["OrdeType"].ToString() == "1")
                {
                    dr["deOrderType"] = "账号续费";
                }
                if (dr["OrdeType"].ToString() == "2")
                {
                    dr["deOrderType"] = "账号充值";
                }
            
                // string temp_time=((DateTime)dr["SubmitTime"]).ToString("yyyy-MM-dd");
                dr["reSubmitTime"] = dr["SubmitTime"].ToString();
                dr["button"] = "<a id='" + dr["ID"] + "' onclick= view(this.id) >查看</a>";
                dr["verify"] = "<a id='" + dr["ID"] + "' style='color:red;' onclick= verify(this.id)>待审核</a>";
                if (dr["OrderStatus"].ToString() == "1")
                {
                    dr["dealStatus"] = "提交已支付";

                }
                else if (dr["OrderStatus"].ToString() == "2")
                {
                    dr["dealStatus"] = "已审核通过";
                    dr["verify"] = "<a id='" + dr["ID"] + "'>已审核</a>";
                }
                else if (dr["OrderStatus"].ToString() == "3")
                {
                    dr["dealStatus"] = "已审核拒绝";
                    dr["verify"] = "<a id='" + dr["ID"] + "'>已审核</a>";
                }
                else
                {
                    dr["dealStatus"] = "提交未支付";
                    dr["button"] = "<a id='" + dr["ID"] + "'  style='color:red;' >未支付</a>";
                }
                //if (dr["IsChecked"].ToString() == "0")
                //{
                //    dr["Status"] = "<a style=" + "color:red" + ">注册申请</a>";
                //}
                //else if (dr["IsChecked"].ToString() == "1")
                //{
                //    dr["Status"] = "<a style=" + "color:blue" + ">受理通过</a>";
                //}
                //else if (dr["IsChecked"].ToString() == "-1")
                //{
                //    dr["Status"] = "<a style=" + "color:brown" + ">受理失败</a>";
                //}
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
                    string ordernumber = DAL.OrderList.GetModel(ids[m]).OrderNumber;
                    //删除该订单
                    bool result = DAL.OrderList.Delete(ordernumber);
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