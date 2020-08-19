using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
  
    public class InvoiceInfo
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from InvoiceInfo where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string Invoice)
        {
            string strSql = "select count(*) from InvoiceInfo where Invoice='" + Invoice + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.InvoiceInfo model)
        {
            string strSql = "insert into InvoiceInfo(Invoice, TaxNum, UnitAddress, Tel, Bank, AccountNum, UserName) values(@Invoice, @TaxNum, @UnitAddress, @Tel, @Bank, @AccountNum, @UserName)";
            SqlParameter Invoice = new SqlParameter("Invoice", SqlDbType.NVarChar); Invoice.Value = model.Invoice;
            SqlParameter TaxNum = new SqlParameter("TaxNum", SqlDbType.NVarChar); TaxNum.Value = model.TaxNum;
            SqlParameter UnitAddress = new SqlParameter("UnitAddress", SqlDbType.NVarChar); UnitAddress.Value = model.UnitAddress;
            SqlParameter Tel = new SqlParameter("Tel", SqlDbType.NVarChar); Tel.Value = model.Tel;
            SqlParameter Bank = new SqlParameter("Bank", SqlDbType.NVarChar); Bank.Value = model.Bank;
            SqlParameter AccountNum = new SqlParameter("AccountNum", SqlDbType.NVarChar); AccountNum.Value = model.AccountNum;
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Invoice, TaxNum, UnitAddress, Tel, Bank, AccountNum, UserName }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.InvoiceInfo model)
        {
            string strSql = "update InvoiceInfo set Invoice=@Invoice, TaxNum=@TaxNum, UnitAddress=@UnitAddress, Tel=@Tel, Bank=@Bank, AccountNum=@AccountNum, UserName=@UserName where ID = " + model.ID.ToString();
            SqlParameter Invoice = new SqlParameter("Invoice", SqlDbType.NVarChar); Invoice.Value = model.Invoice;
            SqlParameter TaxNum = new SqlParameter("TaxNum", SqlDbType.NVarChar); TaxNum.Value = model.TaxNum;
            SqlParameter UnitAddress = new SqlParameter("UnitAddress", SqlDbType.NVarChar); UnitAddress.Value = model.UnitAddress;
            SqlParameter Tel = new SqlParameter("Tel", SqlDbType.NVarChar); Tel.Value = model.Tel;
            SqlParameter Bank = new SqlParameter("Bank", SqlDbType.NVarChar); Bank.Value = model.Bank;
            SqlParameter AccountNum = new SqlParameter("AccountNum", SqlDbType.NVarChar); AccountNum.Value = model.AccountNum;
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Invoice, TaxNum, UnitAddress, Tel, Bank, AccountNum, UserName }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.InvoiceInfo GetModel(string Invoice)
        {
            string strSql = "select * from InvoiceInfo where Invoice = '" + Invoice + "'";
            Model.InvoiceInfo model = new Model.InvoiceInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.Invoice = Invoice;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.TaxNum = Convert.ToString(ds.Tables[0].Rows[0]["TaxNum"]);
                model.UnitAddress = Convert.ToString(ds.Tables[0].Rows[0]["UnitAddress"]);
                model.Tel = Convert.ToString(ds.Tables[0].Rows[0]["Tel"]);
                model.Bank = Convert.ToString(ds.Tables[0].Rows[0]["Bank"]);
                model.AccountNum = Convert.ToString(ds.Tables[0].Rows[0]["AccountNum"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.InvoiceInfo GetModel(int ID)
        {
            string strSql = "select * from InvoiceInfo where ID = '" + ID + "'";
            Model.InvoiceInfo model = new Model.InvoiceInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Invoice = Convert.ToString(ds.Tables[0].Rows[0]["Invoice"]);
                model.TaxNum = Convert.ToString(ds.Tables[0].Rows[0]["TaxNum"]);
                model.UnitAddress = Convert.ToString(ds.Tables[0].Rows[0]["UnitAddress"]);
                model.Tel = Convert.ToString(ds.Tables[0].Rows[0]["Tel"]);
                model.Bank = Convert.ToString(ds.Tables[0].Rows[0]["Bank"]);
                model.AccountNum = Convert.ToString(ds.Tables[0].Rows[0]["AccountNum"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
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
        public static bool Delete(string Invoice)
        {
            string strSql = "delete from InvoiceInfo where Invoice ='" + Invoice + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from InvoiceInfo where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from InvoiceInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from InvoiceInfo where Invoice like '%" + search + "%'";
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
            string sql = "SELECT * FROM InvoiceInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InvoiceInfo where Invoice like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "TaxNum", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM InvoiceInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InvoiceInfo where Invoice like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
