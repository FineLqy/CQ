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
   public class ServiceConfiguration
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;


        /// <summary>
        /// 服务名称是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string ServerName)
        {
            string strSql = "select count(*) from ServiceConfiguration where ServerName='" + ServerName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个服务配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.ServiceConfiguration model)
        {
            string strSql = "insert into ServiceConfiguration(ServerName,paymentMethod,Price,InsertDate,ProductDescription) values(@ServerName,@paymentMethod,@Price,@InsertDate,@ProductDescription)";
            SqlParameter ServerName = new SqlParameter("ServerName", SqlDbType.NVarChar); ServerName.Value = model.ServerName;
            SqlParameter paymentMethod = new SqlParameter("paymentMethod", SqlDbType.NVarChar); paymentMethod.Value = model.paymentMethod;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter InsertDate = new SqlParameter("InsertDate", SqlDbType.NVarChar); InsertDate.Value = model.InsertDate;
            SqlParameter ProductDescription = new SqlParameter("ProductDescription", SqlDbType.NVarChar); ProductDescription.Value = model.ProductDescription;
           
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ServerName,paymentMethod,Price,InsertDate,ProductDescription }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.ServiceConfiguration model)
        {

            string strSql = "update ServiceConfiguration set ServerName=@ServerName, paymentMethod=@paymentMethod, Price=@Price, InsertDate=@InsertDate, ProductDescription=@ProductDescription  where ID = " + model.ID.ToString();
            SqlParameter ServerName = new SqlParameter("ServerName", SqlDbType.NVarChar); ServerName.Value = model.ServerName;
            SqlParameter paymentMethod = new SqlParameter("paymentMethod", SqlDbType.NVarChar); paymentMethod.Value = model.paymentMethod;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter InsertDate = new SqlParameter("InsertDate", SqlDbType.NVarChar); InsertDate.Value = model.InsertDate;
            SqlParameter ProductDescription = new SqlParameter("ProductDescription", SqlDbType.NVarChar); ProductDescription.Value = model.ProductDescription;

            //WebLogger.WriteErroLog(strSql);
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ServerName, paymentMethod, Price, InsertDate, ProductDescription }, connectionString) == 1 ? true : false;

        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.ServiceConfiguration GetModel(string ServerName)
        {
            string strSql = "select * from ServiceConfiguration where ServerName = '" + ServerName + "'";
            Model.ServiceConfiguration model = new Model.ServiceConfiguration();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ServerName = ServerName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.ServerName = Convert.ToString(ds.Tables[0].Rows[0]["ServerName"]);
                model.paymentMethod = Convert.ToString(ds.Tables[0].Rows[0]["paymentMethod"]);
                model.Price = Convert.ToSingle(ds.Tables[0].Rows[0]["Price"]);
                model.InsertDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsertDate"]);
                model.ProductDescription = Convert.ToString(ds.Tables[0].Rows[0]["ProductDescription"]);
               

                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.ServiceConfiguration GetModel(int ID)
        {
            string strSql = "select * from ServiceConfiguration where ID = '" + ID + "'";
            Model.ServiceConfiguration model = new Model.ServiceConfiguration();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ServerName = Convert.ToString(ds.Tables[0].Rows[0]["ServerName"]);
                model.paymentMethod = Convert.ToString(ds.Tables[0].Rows[0]["paymentMethod"]);
                model.Price = Convert.ToSingle(ds.Tables[0].Rows[0]["Price"]);
                model.InsertDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsertDate"]);
                model.ProductDescription = Convert.ToString(ds.Tables[0].Rows[0]["ProductDescription"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.ServiceConfiguration GetModel()
        {
            string strSql = "select top 1 * from ServiceConfiguration order by ID desc";
            Model.ServiceConfiguration model = new Model.ServiceConfiguration();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.ServerName = Convert.ToString(ds.Tables[0].Rows[0]["ServerName"]);
                model.paymentMethod = Convert.ToString(ds.Tables[0].Rows[0]["paymentMethod"]);
                model.Price = Convert.ToSingle(ds.Tables[0].Rows[0]["Price"]);
                model.InsertDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsertDate"]);
                model.ProductDescription = Convert.ToString(ds.Tables[0].Rows[0]["ProductDescription"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据（根据ServerName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string ServerName)
        {
            string strSql = "delete from ServiceConfiguration where ServerName ='" + ServerName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from ServiceConfiguration where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from ServiceConfiguration where ServerName like '%" + search + "%' ";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

               /// <summary>
        /// 获得用户坐标转换列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string search = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM ServiceConfiguration w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM ServiceConfiguration where ServerName like '%" + search + "%'  ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
    }
}
