using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RegisterUser
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from RegisterUser where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string UserName)
        {
            string strSql = "select count(*) from RegisterUser where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 手机号是否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool ExistsPhone(string Phone)
        {
            string strSql = "select count(*) from RegisterUser where Phone='" + Phone + "'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim()) >=1 ? true : false;
        }

        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.RegisterUser model)
        {
            string strSql = "insert into RegisterUser(UserName,PassWord,Email,Phone,RegTime,LastLoginTime,TryLoginTimes,CertifiationStatus,CertifiationIndex,UserType,IsEnable,BelongArea) values(@UserName,@PassWord,@Email,@Phone,@RegTime,@LastLoginTime,@TryLoginTimes,@CertifiationStatus,@CertifiationIndex,@UserType,@IsEnable,@BelongArea)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter PassWord = new SqlParameter("PassWord", SqlDbType.NVarChar); PassWord.Value = model.PassWord;
            SqlParameter Email = new SqlParameter("Email", SqlDbType.NVarChar); Email.Value = model.Email;
            SqlParameter Phone = new SqlParameter("Phone", SqlDbType.NVarChar); Phone.Value = model.Phone;
            SqlParameter RegTime = new SqlParameter("RegTime", SqlDbType.DateTime); RegTime.Value = model.RegTime;
            SqlParameter LastLoginTime = new SqlParameter("LastLoginTime", SqlDbType.DateTime); LastLoginTime.Value = model.LastLoginTime;
            SqlParameter TryLoginTimes = new SqlParameter("TryLoginTimes", SqlDbType.Int); TryLoginTimes.Value = model.TryLoginTimes;
            SqlParameter CertifiationStatus = new SqlParameter("CertifiationStatus", SqlDbType.Int); CertifiationStatus.Value = model.CertifiationStatus;
            SqlParameter CertifiationIndex = new SqlParameter("CertifiationIndex", SqlDbType.NVarChar); CertifiationIndex.Value = model.CertifiationIndex;
            SqlParameter UserType = new SqlParameter("UserType", SqlDbType.Int); UserType.Value = model.UserType;
            SqlParameter IsEnable = new SqlParameter("IsEnable", SqlDbType.Int); IsEnable.Value = model.IsEnable;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, PassWord, Email, Phone, RegTime, LastLoginTime, TryLoginTimes, CertifiationStatus, CertifiationIndex, UserType, IsEnable, BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.RegisterUser model)
        {
            string strSql = "update RegisterUser set UserName=@UserName, PassWord=@PassWord, Email=@Email, Phone=@Phone, RegTime=@RegTime, LastLoginTime=@LastLoginTime, TryLoginTimes=@TryLoginTimes, CertifiationStatus=@CertifiationStatus, CertifiationIndex=@CertifiationIndex, UserType=@UserType, IsEnable=@IsEnable,BelongArea=@BelongArea where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter PassWord = new SqlParameter("PassWord", SqlDbType.NVarChar); PassWord.Value = model.PassWord;
            SqlParameter Email = new SqlParameter("Email", SqlDbType.NVarChar); Email.Value = model.Email;
            SqlParameter Phone = new SqlParameter("Phone", SqlDbType.NVarChar); Phone.Value = model.Phone;
            SqlParameter RegTime = new SqlParameter("RegTime", SqlDbType.DateTime); RegTime.Value = model.RegTime;
            SqlParameter LastLoginTime = new SqlParameter("LastLoginTime", SqlDbType.DateTime); LastLoginTime.Value = model.LastLoginTime;
            SqlParameter TryLoginTimes = new SqlParameter("TryLoginTimes", SqlDbType.Int); TryLoginTimes.Value = model.TryLoginTimes;
            SqlParameter CertifiationStatus = new SqlParameter("CertifiationStatus", SqlDbType.Int); CertifiationStatus.Value = model.CertifiationStatus;
            SqlParameter CertifiationIndex = new SqlParameter("CertifiationIndex", SqlDbType.NVarChar); CertifiationIndex.Value = model.CertifiationIndex;
            SqlParameter UserType = new SqlParameter("UserType", SqlDbType.Int); UserType.Value = model.UserType;
            SqlParameter IsEnable = new SqlParameter("IsEnable", SqlDbType.Int); IsEnable.Value = model.IsEnable;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, PassWord, Email, Phone, RegTime, LastLoginTime, TryLoginTimes, CertifiationStatus, CertifiationIndex, UserType, IsEnable,BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RegisterUser GetModel(string UserName)
        {
            string strSql = "select * from RegisterUser where UserName = '" + UserName + "'";
            Model.RegisterUser model = new Model.RegisterUser();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                model.Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.LastLoginTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastLoginTime"]);
                model.TryLoginTimes = Convert.ToInt32(ds.Tables[0].Rows[0]["TryLoginTimes"]);
                model.CertifiationStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["CertifiationStatus"]);
                model.CertifiationIndex = Convert.ToString(ds.Tables[0].Rows[0]["CertifiationIndex"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.IsEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["IsEnable"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RegisterUser GetModelByPhone(string Phone)
        {
            string strSql = "select * from RegisterUser where Phone = '" + Phone + "'";
            Model.RegisterUser model = new Model.RegisterUser();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.Phone = Phone;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.LastLoginTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastLoginTime"]);
                model.TryLoginTimes = Convert.ToInt32(ds.Tables[0].Rows[0]["TryLoginTimes"]);
                model.CertifiationStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["CertifiationStatus"]);
                model.CertifiationIndex = Convert.ToString(ds.Tables[0].Rows[0]["CertifiationIndex"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.IsEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["IsEnable"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);

                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.RegisterUser GetModel(int ID)
        {
            string strSql = "select * from RegisterUser where ID = '" + ID + "'";
            Model.RegisterUser model = new Model.RegisterUser();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.PassWord = Convert.ToString(ds.Tables[0].Rows[0]["PassWord"]);
                model.Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                model.Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                model.RegTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegTime"]);
                model.LastLoginTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastLoginTime"]);
                model.TryLoginTimes = Convert.ToInt32(ds.Tables[0].Rows[0]["TryLoginTimes"]);
                model.CertifiationStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["CertifiationStatus"]);
                model.CertifiationIndex = Convert.ToString(ds.Tables[0].Rows[0]["CertifiationIndex"]);
                model.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);
                model.IsEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["IsEnable"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
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
            string strSql = "delete from RegisterUser where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from RegisterUser where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from RegisterUser where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static int Getcount()
        {
            string strSql = "select count(*) from RegisterUser where CertifiationStatus=1 and UserType=1 ";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        public static DataSet GetUserNameList(string strWhere)
        {
            string strSql = "select UserName from RegisterUser where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static DataSet GetUserNameList1(string username)
        {
            string strSql = "select UserName from RegisterUser where UserName='"+username+"'";
            
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "", string strwhere = "1=1")
        {
            string strSql = "select count(*) from RegisterUser where UserName like '%" + search + "%' and "+strwhere;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string search = "", string strwhere = "1=1")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM RegisterUser w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RegisterUser where UserName like '%" + search + "%' and "+strwhere+" ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
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
            string sql = "SELECT * FROM RegisterUser w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RegisterUser where UserName like '%" + search + "%' and "+strwhere+" ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static DataSet GetUserName(string UserName)
        {
            string strSql = "select UserName from RegisterUser where UserName='"+UserName+"'  ";
            
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

    }
}
