using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class PaymentRecord
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.PaymentRecord model)
        {
            string strSql = "insert into PaymentRecord( UserName,ProductName, Company, Type, Money, RechargeTime) values(@UserName,  @ProductName, @Company, @Type, @Money, @RechargeTime) ";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter ProductName = new SqlParameter("ProductName", SqlDbType.NVarChar); ProductName.Value = model.ProductName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter Money = new SqlParameter("Money", SqlDbType.NVarChar); Money.Value = model.Money;
            SqlParameter RechargeTime = new SqlParameter("RechargeTime", SqlDbType.DateTime); RechargeTime.Value = model.RechargeTime;
          
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, ProductName, Company, Type, Money, RechargeTime }, connectionString) == 1 ? true : false;
        }

        public static int GetRecordCount(string Company = "")
        {
            string strSql = "select count(*) from PaymentRecord where Company like '%" + Company + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        public static DataSet GetBriefList(int offset, int limit, string search = "", string strwhere = "",string Company="",string username="")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM PaymentRecord w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM PaymentRecord where Company like '%" + search + "%'and UserName like'%"+username+"%'  and " + strwhere + " and Company='"+ Company + "'   ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
