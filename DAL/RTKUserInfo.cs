using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
    public class RTKUserInfo
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from RTKUserInfo where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string UserName)
        {
            string strSql = "select count(*) from RTKUserInfo where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.RTKUserInfo model)
        {
            string strSql = "insert into RTKUserInfo( UserName, PassWord, Contact, ContactPhone, ContactEmail, ContactQQ, CORSCardNum, ReceiverNum, Company, RegTime, UserType,OrderNumber,BelongArea,RegisterUserName ) values( @UserName, @PassWord, @Contact, @ContactPhone, @ContactEmail, @ContactQQ, @CORSCardNum, @ReceiverNum, @Company, @RegTime, @UserType,@OrderNumber,@BelongArea,@RegisterUserName )";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter PassWord = new SqlParameter("PassWord", SqlDbType.NVarChar); PassWord.Value = model.PassWord;
            SqlParameter Contact = new SqlParameter("Contact", SqlDbType.NVarChar); Contact.Value = model.Contact;
            SqlParameter ContactPhone = new SqlParameter("ContactPhone", SqlDbType.NVarChar); ContactPhone.Value = model.ContactPhone;
            SqlParameter ContactEmail = new SqlParameter("ContactEmail", SqlDbType.NVarChar); ContactEmail.Value = model.ContactEmail;
            SqlParameter ContactQQ = new SqlParameter("ContactQQ", SqlDbType.NVarChar); ContactQQ.Value = model.ContactQQ;
            SqlParameter CORSCardNum = new SqlParameter("CORSCardNum", SqlDbType.NVarChar); CORSCardNum.Value = model.CORSCardNum;
            SqlParameter ReceiverNum = new SqlParameter("ReceiverNum", SqlDbType.NVarChar); ReceiverNum.Value = model.ReceiverNum;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter RegTime = new SqlParameter("RegTime", SqlDbType.DateTime); RegTime.Value = model.RegTime;
            SqlParameter UserType = new SqlParameter("UserType", SqlDbType.Int); UserType.Value = model.UserType;
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            SqlParameter RegisterUserName = new SqlParameter("RegisterUserName", SqlDbType.NVarChar); RegisterUserName.Value = model.RegisterUserName;

            WebLogger.WriteErroLog(CORSCardNum.ToString());
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, PassWord, Contact, ContactPhone, ContactEmail, ContactQQ, CORSCardNum, ReceiverNum, Company, RegTime, UserType, OrderNumber, BelongArea, RegisterUserName }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.RTKUserInfo model)
        {
            string strSql = "update RTKUserInfo set UserName=@UserName, PassWord=@PassWord, Contact=@Contact, ContactPhone=@ContactPhone, ContactEmail=@ContactEmail, ContactQQ=@ContactQQ, CORSCardNum=@CORSCardNum, ReceiverNum=@ReceiverNum, Company=@Company, RegTime=@RegTime, UserType=@UserType,OrderNumber=@OrderNumber,BelongArea=@BelongArea,RegisterUserName=@RegisterUserName where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter PassWord = new SqlParameter("PassWord", SqlDbType.NVarChar); PassWord.Value = model.PassWord;
            SqlParameter Contact = new SqlParameter("Contact", SqlDbType.NVarChar); Contact.Value = model.Contact;
            SqlParameter ContactPhone = new SqlParameter("ContactPhone", SqlDbType.NVarChar); ContactPhone.Value = model.ContactPhone;
            SqlParameter ContactEmail = new SqlParameter("ContactEmail", SqlDbType.NVarChar); ContactEmail.Value = model.ContactEmail;
            SqlParameter ContactQQ = new SqlParameter("ContactQQ", SqlDbType.NVarChar); ContactQQ.Value = model.ContactQQ;
            SqlParameter CORSCardNum = new SqlParameter("CORSCardNum", SqlDbType.NVarChar); CORSCardNum.Value = model.CORSCardNum;
            SqlParameter ReceiverNum = new SqlParameter("ReceiverNum", SqlDbType.NVarChar); ReceiverNum.Value = model.ReceiverNum;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter RegTime = new SqlParameter("RegTime", SqlDbType.DateTime); RegTime.Value = model.RegTime;
            SqlParameter UserType = new SqlParameter("UserType", SqlDbType.Int); UserType.Value = model.UserType;
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            SqlParameter RegisterUserName = new SqlParameter("RegisterUserName", SqlDbType.NVarChar); RegisterUserName.Value = model.RegisterUserName;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, PassWord, Contact, ContactPhone, ContactEmail, ContactQQ, CORSCardNum, ReceiverNum, Company, RegTime, UserType ,OrderNumber,BelongArea,RegisterUserName}, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RTKUserInfo GetModel(string UserName)
        {
            string strSql = "select * from RTKUserInfo where UserName = '" + UserName + "'";
            Model.RTKUserInfo model = new Model.RTKUserInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactPhone = Convert.ToString(ds.Tables[0].Rows[0]["ContactPhone"]);
                model.ContactEmail = Convert.ToString(ds.Tables[0].Rows[0]["ContactEmail"]);
                model.ContactQQ = Convert.ToString(ds.Tables[0].Rows[0]["ContactQQ"]);
                model.CORSCardNum = Convert.ToString(ds.Tables[0].Rows[0]["CORSCardNum"]);
                model.ReceiverNum = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverNum"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.RegisterUserName = Convert.ToString(ds.Tables[0].Rows[0]["RegisterUserName"]);

                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.RTKUserInfo GetMode2(string UserName)
        {
            string strSql = "select * from RTKUserInfo where RegisterUserName = '" + UserName + "'";
            Model.RTKUserInfo model = new Model.RTKUserInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactPhone = Convert.ToString(ds.Tables[0].Rows[0]["ContactPhone"]);
                model.ContactEmail = Convert.ToString(ds.Tables[0].Rows[0]["ContactEmail"]);
                model.ContactQQ = Convert.ToString(ds.Tables[0].Rows[0]["ContactQQ"]);
                model.CORSCardNum = Convert.ToString(ds.Tables[0].Rows[0]["CORSCardNum"]);
                model.ReceiverNum = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverNum"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.RegisterUserName = Convert.ToString(ds.Tables[0].Rows[0]["RegisterUserName"]);

                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.RTKUserInfo GetModel(int ID)
        {
            string strSql = "select * from RTKUserInfo where ID = '" + ID + "'";
            Model.RTKUserInfo model = new Model.RTKUserInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactPhone = Convert.ToString(ds.Tables[0].Rows[0]["ContactPhone"]);
                model.ContactEmail = Convert.ToString(ds.Tables[0].Rows[0]["ContactEmail"]);
                model.ContactQQ = Convert.ToString(ds.Tables[0].Rows[0]["ContactQQ"]);
                model.CORSCardNum = Convert.ToString(ds.Tables[0].Rows[0]["CORSCardNum"]);
                model.ReceiverNum = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverNum"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.RegisterUserName = Convert.ToString(ds.Tables[0].Rows[0]["RegisterUserName"]);

                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.RTKUserInfo GetModel2(string UserName)
        {
            string strSql = "select * from RTKUserInfo where RegisterUserName = '" + UserName + "'";
            Model.RTKUserInfo model = new Model.RTKUserInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactPhone = Convert.ToString(ds.Tables[0].Rows[0]["ContactPhone"]);
                model.ContactEmail = Convert.ToString(ds.Tables[0].Rows[0]["ContactEmail"]);
                model.ContactQQ = Convert.ToString(ds.Tables[0].Rows[0]["ContactQQ"]);
                model.CORSCardNum = Convert.ToString(ds.Tables[0].Rows[0]["CORSCardNum"]);
                model.ReceiverNum = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverNum"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.RegisterUserName = Convert.ToString(ds.Tables[0].Rows[0]["RegisterUserName"]);

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 删除一条数据（根据UserName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string UserName)
        {
            string strSql = "delete from RTKUserInfo where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from RTKUserInfo where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from RTKUserInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetList1(string UserName)
        {
            string strSql = "select * from RTKUserInfo where RegisterUserName ='"+ UserName + "'";
           
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static DataSet GetUserNameList(string strWhere)
        {
            string strSql = "select UserName from RTKUserInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "",string strwhere="1=1")
        {
            string strSql = "select count(*) from RTKUserInfo where UserName like '%" + search + "%' and " + strwhere;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string search = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM RTKUserInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RTKUserInfo where UserName like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "RegTime", string order = "desc", string search = "", string strwhere = "1=1")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM RTKUserInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RTKUserInfo where UserName like '%" + search + "%' and "+strwhere+" ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
