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
  public  class DeUserInfo
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;


        /// <summary>
        /// 服务名称是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string UserName)
        {
            string strSql = "select count(*) from DeUserInfo where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.DeUserInfo model)
        {
            string strSql = "insert into DeUserInfo( UserName,UserPwd,OrderNumber) values(@UserName,@UserPwd,@OrderNumber)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter UserPwd = new SqlParameter("UserPwd", SqlDbType.NVarChar); UserPwd.Value = model.UserPwd;
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
    

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, UserPwd, OrderNumber }, connectionString) == 1 ? true : false;
        }

       

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.DeUserInfo GetModel(string UserName)
        {
            string strSql = "select * from DeUserInfo where UserName = '" + UserName + "'";
            Model.DeUserInfo model = new Model.DeUserInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.UserPwd = Convert.ToString(ds.Tables[0].Rows[0]["UserPwd"]);
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
                


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
            string strSql = "delete from DeUserInfo where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from DeUserInfo where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string OrderNumber)
        {
            string strSql = "select * from DeUserInfo where OrderNumber='"+ OrderNumber + "' ";
    
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }


    }
}

