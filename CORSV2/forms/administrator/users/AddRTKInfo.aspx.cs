using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.users
{
    public partial class AddRTKInfo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
              
                if (Request["name"] != null)
                {
               Session["RegisterUserName"]  = Request["name"].ToString();


                }

                DataSet ds = DAL.CoorSysPars.GetList("YSZBXM ='WGS84'");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ssdfzbx.Items.Add(dr["MDZBXM"].ToString());
                    ssdfzbx1.Items.Add(dr["MDZBXM"].ToString());
            }

                DataSet ds1 = DAL.SourceTable.GetList("1=1");
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    ssylbpz.Items.Add(dr["Source"].ToString());
                     ssylbpz1.Items.Add(dr["Source"].ToString());
            }
               
            int companyCertifiationIndex = Convert.ToInt32(DAL.RegisterUser.GetModel(Session["RegisterUserName"].ToString()).CertifiationIndex);
            Model.CompanyInfo companyInfo=  DAL.CompanyInfo.GetModel(companyCertifiationIndex);
            Model.RegisterUser registerUser= DAL.RegisterUser.GetModel(Session["RegisterUserName"].ToString());


                Company.Value = companyInfo.Company;
            Contacts.Value = companyInfo.Contact;
            phone.Value = registerUser.Phone;
            email.Value = registerUser.Email;


            Company1.Value = companyInfo.Company;
            Contacts1.Value = companyInfo.Contact;
            phone1.Value = registerUser.Phone;
            email1.Value = registerUser.Email;





            if (Request["action"] != null)
            {
                if (Request["action"].ToString() == "check")
                {
                    string username = Request["data"].ToString();
                    DAL.RegisterUser du = new DAL.RegisterUser();
                    if (DAL.RTKUserInfo.GetModel(username) == null && DAL.RegisterUser.GetModel(username) == null)
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

                if (Request["action"].ToString() == "AddUser")
                {
                    bool dele = true;

                    string UserName = Request.Form["username"].ToString();
                   
                    try
                    {


                        // 个人信息部分
                        DAL.RegisterUser du1 = new DAL.RegisterUser();
                        if (DAL.RTKUserInfo.GetModel(UserName) == null && DAL.RegisterUser.GetModel(UserName) == null)
                        {

                        }
                        else
                        {
                            dele = false;
                            Response.Clear();
                            Response.Write("-1");
                            Response.End();
                            return;
                        }

                        string PassWord = Request.Form["password"].ToString();
                        string WorkType = Request.Form["WorkType"].ToString();
                        string Contacts = Request.Form["Contacts"].ToString();
                        string Phone = Request.Form["phone"].ToString();
                        string Email = Request.Form["email"].ToString();
                        string Company = Request.Form["Company"].ToString();

                        int Enable = int.Parse(Request.Form["status"].ToString());
                        Model.RTKUserInfo rtkUserInfo = new Model.RTKUserInfo();

                        rtkUserInfo.RegisterUserName = Session["RegisterUserName"].ToString();
                        rtkUserInfo.UserName = UserName;
                        rtkUserInfo.Company = Company;
                        rtkUserInfo.PassWord = AES_Key.AESEncrypt(PassWord, UserName.PadLeft(16, '0'));
                        rtkUserInfo.UserType = 0;
                        //rtkUserInfo.OrderNumber = ;
                       // rtkUserInfo.BelongArea = registerUser.BelongArea;
                        rtkUserInfo.Contact = Contacts;
                        rtkUserInfo.ContactPhone = Phone;
                        rtkUserInfo.ContactEmail = Email;
                        rtkUserInfo.RegTime = DateTime.Now;
                        rtkUserInfo.CORSCardNum = "";
                        if (DAL.RTKUserInfo.Add(rtkUserInfo))
                        {

                        }
                        else
                        {
                            Response.Clear();
                            Response.Write("0");
                            Response.End();
                            return;
                        }


                        // 权限信息部分

                        Model.RTKUserPurview mrtkp = new Model.RTKUserPurview();
                        int PostEnable = int.Parse(Request.Form["ssfwky"].ToString());
                        string StartTime = Request.Form["ssbsks"].ToString();
                        string EndTime = Request.Form["ssbsjs"].ToString();
                        string CoorSystem = Request.Form["sskyzbx"].ToString();
                        string SourceTable = Request.Form["sskyylb"].ToString();
                        int ElevationEnable = int.Parse(Request.Form["sszcghq"].ToString());
                        string ElevationMode = Request.Form["ssgcjz"].ToString();
                        mrtkp.AreaID = "";
                        mrtkp.ElevationEnable = ElevationEnable;
                        mrtkp.ElevationMode = ElevationMode;
                        mrtkp.SourceTable = SourceTable;
                        mrtkp.UserName = UserName;
                        mrtkp.VRSEnable = PostEnable;
                        mrtkp.ServerType = WorkType;
                        mrtkp.CoorSystem = CoorSystem;
                        mrtkp.RoamID = "";
                        mrtkp.StartTime =Convert.ToDateTime( StartTime);
                        mrtkp.EndTime =Convert.ToDateTime( EndTime);

                        if (!DAL.RTKUserPurview.Exists(mrtkp.UserName))
                        {
                            if (!DAL.RTKUserPurview.Add(mrtkp))
                            {
                                DAL.RTKUserInfo.Delete(UserName);
                                Response.Clear();
                                Response.Write("0");
                                Response.End();
                                return;
                            }
                        }
                        Model.RTKPostPurview rTKPostPurview = new Model.RTKPostPurview();
                        rTKPostPurview.UserName = UserName;
                        rTKPostPurview.CoorTransEnable = 0;
                        rTKPostPurview.HeightTransEnable = 0;
                        rTKPostPurview.SHPTransEnable = 0;
                        rTKPostPurview.DXFTransEnable = 0;
                        rTKPostPurview.PPPserverEnable = 0;
                        rTKPostPurview.ObsQualityEnable = 0;
                        rTKPostPurview.BaseLineEnable = 0;
                        
                        
                        rTKPostPurview.StartTime = Convert.ToDateTime(StartTime);
                        rTKPostPurview.EndTime= Convert.ToDateTime(EndTime);
                        DAL.RTKPostPurview.Add(rTKPostPurview);

                        //添加用户状态信息
                        Model.RTKUserStatus mrtks = new Model.RTKUserStatus();
                        mrtks.UserName = UserName;
                        mrtks.Company = Company;
                        mrtks.IsOnline = 0;
                        mrtks.Lat = 0;
                        mrtks.Lon = 0;
                        mrtks.StartTime = Convert.ToDateTime(StartTime);
                        mrtks.Remark = "";
                        DAL.RTKUserStatus bllrtkus = new DAL.RTKUserStatus();

                        if (!bllrtkus.Exists(UserName))
                        {
                            if (DAL.RTKUserStatus.Add(mrtks))
                            {
                                
                            }
                        }

                        Model.OrderList orderList = new Model.OrderList();
                        orderList.UserName = Session["RegisterUserName"].ToString();
                        orderList.OrderNumber = DateTime.Now.ToString("yyyMMddhhmmssfff");
                        orderList.company = Company;
                        orderList.Price = "1000";
                        orderList.DealTime = DateTime.Now;
                        orderList.OrderContent = "账号申请";
                        orderList.OrderStatus = 2;
                        orderList.OrdeType = 0;
                        orderList.RoamID = "";
                        DAL.OrderList.Add(orderList);
                        //修改单位余额
                        Model.CompanyInfo UpdatecompanyInfo = DAL.CompanyInfo.GetModel(Company);
                        UpdatecompanyInfo.Balance = UpdatecompanyInfo.Balance - 1000;
                        DAL.CompanyInfo.Update(UpdatecompanyInfo);

                        //添加发票信息
                        Model.InvoiceList invoicelist = new Model.InvoiceList();
                        invoicelist.OrderDetail = orderList.ID.ToString();
                        invoicelist.OrderNumber = orderList.OrderNumber;
                        invoicelist.BelongArea = orderList.WorkArea;
                        invoicelist.PayTime = orderList.PayTime;
                        invoicelist.Price = orderList.Price;
                        invoicelist.Status = 1;
                        invoicelist.ContractStatus = 1;
                        invoicelist.UserName = orderList.UserName;
                        DAL.InvoiceList.Add(invoicelist);
                        //添加缴费记录
                        Model.PaymentRecord paymentRecord = new Model.PaymentRecord();
                        paymentRecord.ProductName = "账号申请";
                        paymentRecord.Company = Company;
                        paymentRecord.Type =orderList.OrdeType ;
                        paymentRecord.Money = Convert.ToSingle( orderList.Price);
                        paymentRecord.RechargeTime = DateTime.Now;
                        DAL.PaymentRecord.Add(paymentRecord);




                    }


                    catch {

                       
                      
                        DAL.RTKUserInfo.Delete(UserName);
                        DAL.RTKUserPurview.Delete(UserName);
                        DAL.RTKUserStatus.Delete(UserName);
                        DAL.RTKPostPurview.Delete(UserName);
                        DAL.InvoiceList.Delete(UserName);
                        Response.Clear();
                        Response.Write("0");
                        Response.End();
                        return;

                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }

                if (Request["action"].ToString() == "AddUser1")
                {
                    bool dele = true;

                 
                    for (int i = 0; i <Convert.ToInt32( AccountNumber.Value); i++)
                    {
                        
                        int[] RandKey=  cs.RandomNumber.UseHashTableToNonRepeatedRandom(4, 0, 9);
                        string UserName = Session["RegisterUserName"].ToString()+ string.Join("", RandKey);
                        try
                        {


                            // 个人信息部分
                            DAL.RegisterUser du1 = new DAL.RegisterUser();
                            if (DAL.RTKUserInfo.GetModel(UserName) == null && DAL.RegisterUser.GetModel(UserName) == null)
                            {

                            }
                            else
                            {
                                dele = false;
                                Response.Clear();
                                Response.Write("-1");
                                Response.End();
                                return;
                            }

                            string PassWord = UserName;
                            string WorkType = Request.Form["WorkType1"].ToString();
                            string Contacts = Request.Form["Contacts1"].ToString();
                            string Phone = Request.Form["phone1"].ToString();
                            string Email = Request.Form["email1"].ToString();
                            string Company = Request.Form["Company1"].ToString();

                            int Enable = int.Parse(Request.Form["status1"].ToString());
                            Model.RTKUserInfo rtkUserInfo = new Model.RTKUserInfo();

                            rtkUserInfo.RegisterUserName = Session["RegisterUserName"].ToString();
                            rtkUserInfo.UserName = UserName;
                            rtkUserInfo.Company = Company;
                            rtkUserInfo.PassWord = AES_Key.AESEncrypt(PassWord, UserName.PadLeft(16, '0'));
                            rtkUserInfo.UserType = 0;
                            //rtkUserInfo.OrderNumber = ;
                            // rtkUserInfo.BelongArea = registerUser.BelongArea;
                            rtkUserInfo.Contact = Contacts;
                            rtkUserInfo.ContactPhone = Phone;
                            rtkUserInfo.ContactEmail = Email;
                            rtkUserInfo.RegTime = DateTime.Now;
                            rtkUserInfo.CORSCardNum = "";
                            if (DAL.RTKUserInfo.Add(rtkUserInfo))
                            {

                            }
                            else
                            {
                                Response.Clear();
                                Response.Write("0");
                                Response.End();
                                return;
                            }


                            // 权限信息部分

                            Model.RTKUserPurview mrtkp = new Model.RTKUserPurview();
                            int PostEnable = int.Parse(Request.Form["ssfwky1"].ToString());
                            string StartTime = Request.Form["ssbsks1"].ToString();
                            string EndTime = Request.Form["ssbsjs1"].ToString();
                            string CoorSystem = Request.Form["sskyzbx1"].ToString();
                            string SourceTable = Request.Form["sskyylb1"].ToString();
                            int ElevationEnable = int.Parse(Request.Form["sszcghq1"].ToString());
                            string ElevationMode = Request.Form["ssgcjz1"].ToString();
                            mrtkp.AreaID = "";
                            mrtkp.ElevationEnable = ElevationEnable;
                            mrtkp.ElevationMode = ElevationMode;
                            mrtkp.SourceTable = SourceTable;
                            mrtkp.UserName = UserName;
                            mrtkp.VRSEnable = PostEnable;
                            mrtkp.ServerType = WorkType;
                            mrtkp.CoorSystem = CoorSystem;
                            mrtkp.RoamID = "";
                            mrtkp.StartTime = Convert.ToDateTime(StartTime);
                            mrtkp.EndTime = Convert.ToDateTime(EndTime);
                            mrtkp.RoamID = "";

                            if (!DAL.RTKUserPurview.Exists(mrtkp.UserName))
                            {
                                if (!DAL.RTKUserPurview.Add(mrtkp))
                                {
                                    DAL.RTKUserInfo.Delete(UserName);
                                    Response.Clear();
                                    Response.Write("0");
                                    Response.End();
                                    return;
                                }
                            }
                            Model.RTKPostPurview rTKPostPurview = new Model.RTKPostPurview();
                            rTKPostPurview.UserName = UserName;
                            rTKPostPurview.CoorTransEnable = 0;
                            rTKPostPurview.HeightTransEnable = 0;
                            rTKPostPurview.SHPTransEnable = 0;
                            rTKPostPurview.DXFTransEnable = 0;
                            rTKPostPurview.PPPserverEnable = 0;
                            rTKPostPurview.ObsQualityEnable = 0;
                            rTKPostPurview.BaseLineEnable = 0;

                            rTKPostPurview.StartTime = Convert.ToDateTime(StartTime);
                            rTKPostPurview.EndTime = Convert.ToDateTime(EndTime);
                            DAL.RTKPostPurview.Add(rTKPostPurview);

                            //添加用户状态信息
                            Model.RTKUserStatus mrtks = new Model.RTKUserStatus();
                            mrtks.UserName = UserName;
                            mrtks.Company = Company;
                            mrtks.IsOnline = 0;
                            mrtks.Lat = 0;
                            mrtks.Lon = 0;
                            mrtks.StartTime = Convert.ToDateTime(StartTime);
                            mrtks.Remark = "";
                            DAL.RTKUserStatus bllrtkus = new DAL.RTKUserStatus();

                            if (!bllrtkus.Exists(UserName))
                            {
                                if (DAL.RTKUserStatus.Add(mrtks))
                                {

                                }
                            }

                            Model.OrderList orderList = new Model.OrderList();
                            orderList.UserName = Session["RegisterUserName"].ToString();
                            orderList.OrderNumber = DateTime.Now.ToString("yyyMMddhhmmssfff");
                            orderList.company = Company;
                            orderList.Price = "1000";
                            orderList.DealTime = DateTime.Now;
                            orderList.OrderContent = "账号申请";
                            orderList.OrderStatus = 2;
                            orderList.OrdeType = 0;
                            orderList.RoamID = "";
                            DAL.OrderList.Add(orderList);
                            //修改单位余额
                            Model.CompanyInfo UpdatecompanyInfo = DAL.CompanyInfo.GetModel(Company);
                            UpdatecompanyInfo.Balance = UpdatecompanyInfo.Balance - 1000;
                            DAL.CompanyInfo.Update(UpdatecompanyInfo);

                            //添加发票信息
                            Model.InvoiceList invoicelist = new Model.InvoiceList();
                            invoicelist.OrderDetail = orderList.ID.ToString();
                            invoicelist.OrderNumber = orderList.OrderNumber;
                            invoicelist.BelongArea = orderList.WorkArea;
                            invoicelist.PayTime = orderList.PayTime;
                            invoicelist.Price = orderList.Price;
                            invoicelist.Status = 1;
                            invoicelist.ContractStatus = 1;
                            invoicelist.UserName = orderList.UserName;
                            DAL.InvoiceList.Add(invoicelist);
                            //添加缴费记录
                            Model.PaymentRecord paymentRecord = new Model.PaymentRecord();
                            paymentRecord.ProductName = "账号申请";
                            paymentRecord.Company = Company;
                            paymentRecord.Type = orderList.OrdeType;
                            paymentRecord.Money = Convert.ToSingle(orderList.Price);
                            paymentRecord.RechargeTime = DateTime.Now;
                            DAL.PaymentRecord.Add(paymentRecord);




                        }


                        catch
                        {



                            DAL.RTKUserInfo.Delete(UserName);
                            DAL.RTKUserPurview.Delete(UserName);
                            DAL.RTKUserStatus.Delete(UserName);
                            DAL.RTKPostPurview.Delete(UserName);
                            DAL.InvoiceList.Delete(UserName);
                            Response.Clear();
                            Response.Write("0");
                            Response.End();
                            return;

                        }
                       
                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }

            }
        }
    }
}
                    
                   


                 
            
            
        


    

