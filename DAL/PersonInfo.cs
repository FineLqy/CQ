using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    
    public class PersonInfo
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from PersonInfo where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string Contact)
        {
            string strSql = "select count(*) from PersonInfo where Contact='" + Contact + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.PersonInfo model)
        {
            string strSql = "insert into PersonInfo(Contact, ContactIDCardNumber, ContactIDCardFile, CertificationTime, BelongArea) values(@Contact, @ContactIDCardNumber, @ContactIDCardFile, @CertificationTime, @BelongArea)";
            SqlParameter Contact = new SqlParameter("Contact", SqlDbType.NVarChar); Contact.Value = model.Contact;
            SqlParameter ContactIDCardNumber = new SqlParameter("ContactIDCardNumber", SqlDbType.NVarChar); ContactIDCardNumber.Value = model.ContactIDCardNumber;
            SqlParameter ContactIDCardFile = new SqlParameter("ContactIDCardFile", SqlDbType.NVarChar); ContactIDCardFile.Value = model.ContactIDCardFile;
            SqlParameter CertificationTime = new SqlParameter("CertificationTime", SqlDbType.DateTime); CertificationTime.Value = model.CertificationTime;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Contact, ContactIDCardNumber, ContactIDCardFile, CertificationTime, BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.PersonInfo model)
        {
            string strSql = "update PersonInfo set Contact=@Contact, ContactIDCardNumber=@ContactIDCardNumber, ContactIDCardFile=@ContactIDCardFile, CertificationTime=@CertificationTime, BelongArea=@BelongArea  where ID = " + model.ID.ToString();
            SqlParameter Contact = new SqlParameter("Contact", SqlDbType.NVarChar); Contact.Value = model.Contact;
            SqlParameter ContactIDCardNumber = new SqlParameter("ContactIDCardNumber", SqlDbType.NVarChar); ContactIDCardNumber.Value = model.ContactIDCardNumber;
            SqlParameter ContactIDCardFile = new SqlParameter("ContactIDCardFile", SqlDbType.NVarChar); ContactIDCardFile.Value = model.ContactIDCardFile;
            SqlParameter CertificationTime = new SqlParameter("CertificationTime", SqlDbType.DateTime); CertificationTime.Value = model.CertificationTime;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Contact, ContactIDCardNumber, ContactIDCardFile, CertificationTime, BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.PersonInfo GetModel(string Contact)
        {
            string strSql = "select * from PersonInfo where Contact = '" + Contact + "'";
            Model.PersonInfo model = new Model.PersonInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.Contact = Contact;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.ContactIDCardNumber = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardNumber"]);
                model.ContactIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardFile"]);
                model.CertificationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CertificationTime"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.PersonInfo GetModel(int ID)
        {
            string strSql = "select * from PersonInfo where ID = '" + ID + "'";
            Model.PersonInfo model = new Model.PersonInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactIDCardNumber = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardNumber"]);
                model.ContactIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardFile"]);
                model.CertificationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CertificationTime"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.PersonInfo GetModel()
        {
            string strSql = "select top 1 * from PersonInfo order by ID desc";
            Model.PersonInfo model = new Model.PersonInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactIDCardNumber = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardNumber"]);
                model.ContactIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardFile"]);
                model.CertificationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CertificationTime"]);
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
        public static bool Delete(string Contact)
        {
            string strSql = "delete from PersonInfo where Contact ='" + Contact + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from PersonInfo where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from PersonInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from PersonInfo where Contact like '%" + search + "%'";
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
            string sql = "SELECT * FROM PersonInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM PersonInfo where Contact like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "CertificationTime", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM PersonInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM PersonInfo where Contact like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
