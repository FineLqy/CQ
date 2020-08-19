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
   public class RoamingAreaManagement
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;


        /// <summary>
        /// 分组名称是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string GroupName)
        {
            string strSql = "select count(*) from RoamingAreaManagement where GroupName='" + GroupName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个分组信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.RoamingAreaManagement model)
        {
            string strSql = "insert into RoamingAreaManagement(GroupName, Remark, GroupRange, InsertTime) values(@GroupName, @Remark, @GroupRange, @InsertTime)";
            SqlParameter GroupName = new SqlParameter("GroupName", SqlDbType.NVarChar); GroupName.Value = model.GroupName;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter GroupRange = new SqlParameter("GroupRange", SqlDbType.NVarChar); GroupRange.Value = model.GroupRange;
            SqlParameter InsertTime = new SqlParameter("InsertTime", SqlDbType.NVarChar); InsertTime.Value = model.InsertTime;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { GroupName, Remark, GroupRange, InsertTime }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.RoamingAreaManagement model)
        {

            string strSql = "update RoamingAreaManagement set  GroupName=@GroupName, Remark=@Remark, GroupRange=@GroupRange, InsertTime=@InsertTime  where ID = " + model.ID.ToString();
            SqlParameter GroupName = new SqlParameter("GroupName", SqlDbType.NVarChar); GroupName.Value = model.GroupName;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter GroupRange = new SqlParameter("GroupRange", SqlDbType.NVarChar); GroupRange.Value = model.GroupRange;
            SqlParameter InsertTime = new SqlParameter("InsertTime", SqlDbType.NVarChar); InsertTime.Value = model.InsertTime;
          

            //WebLogger.WriteErroLog(strSql);
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { GroupName, Remark, GroupRange, InsertTime }, connectionString) == 1 ? true : false;

        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RoamingAreaManagement GetModel(string GroupName)
        {
            string strSql = "select * from RoamingAreaManagement where GroupName = '" + GroupName + "'";
            Model.RoamingAreaManagement model = new Model.RoamingAreaManagement();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.GroupName = GroupName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.GroupName = Convert.ToString(ds.Tables[0].Rows[0]["GroupName"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.GroupRange = Convert.ToString(ds.Tables[0].Rows[0]["GroupRange"]);
                model.InsertTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsertTime"]);
               


                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.RoamingAreaManagement GetModel(int ID)
        {
            string strSql = "select * from RoamingAreaManagement where ID = '" + ID + "'";
            Model.RoamingAreaManagement model = new Model.RoamingAreaManagement();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.GroupName = Convert.ToString(ds.Tables[0].Rows[0]["GroupName"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.GroupRange = Convert.ToString(ds.Tables[0].Rows[0]["GroupRange"]);
                model.InsertTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsertTime"]);

                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.RoamingAreaManagement GetModel()
        {
            string strSql = "select top 1 * from RoamingAreaManagement order by ID desc";
            Model.RoamingAreaManagement model = new Model.RoamingAreaManagement();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.GroupName = Convert.ToString(ds.Tables[0].Rows[0]["GroupName"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.GroupRange = Convert.ToString(ds.Tables[0].Rows[0]["GroupRange"]);
                model.InsertTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsertTime"]);

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
        public static bool Delete(string GroupName)
        {
            string strSql = "delete from RoamingAreaManagement where GroupName ='" + GroupName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from RoamingAreaManagement where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from RoamingAreaManagement where GroupName like '%" + search + "%' ";
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
            string sql = "SELECT * FROM RoamingAreaManagement w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RoamingAreaManagement where GroupName like '%" + search + "%'  ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
    }
}
