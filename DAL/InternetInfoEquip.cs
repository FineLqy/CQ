using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DAL
{
    public class InternetInfoEquip
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from InternetInfoEquip where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 设备名
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string MachineName)
        {
            string strSql = "select count(*) from InternetInfoEquip where MachineName='" + MachineName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.InternetInfoEquip model)
        {
            string strSql = "insert into InternetInfoEquip(IP,Port,MachineName,Logo,EUse,Remark) values(@IP,@Port,@MachineName,@Logo,@EUse,@Remark)";
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter MachineName = new SqlParameter("MachineName", SqlDbType.NVarChar); MachineName.Value = model.MachineName;
            SqlParameter Logo = new SqlParameter("Logo", SqlDbType.NVarChar); Logo.Value = model.Logo;
            SqlParameter EUse = new SqlParameter("EUse", SqlDbType.NVarChar); EUse.Value = model.EUse;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { IP, Port, MachineName, Logo, EUse, Remark }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.InternetInfoEquip model)
        {
            string strSql = "update InternetInfoEquip set IP=@IP,Port=@Port,MachineName=@MachineName,Logo=@Logo,EUse=@EUse,Remark=@Remark where ID = " + model.ID.ToString();
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter MachineName = new SqlParameter("MachineName", SqlDbType.NVarChar); MachineName.Value = model.MachineName;
            SqlParameter Logo = new SqlParameter("Logo", SqlDbType.NVarChar); Logo.Value = model.Logo;
            SqlParameter EUse = new SqlParameter("EUse", SqlDbType.NVarChar); EUse.Value = model.EUse;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { IP, Port, MachineName, Logo, EUse, Remark }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象根据设备名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.InternetInfoEquip GetModel(string MachineName)
        {
            string strSql = "select * from InternetInfoEquip where MachineName = '" + MachineName + "'";
            Model.InternetInfoEquip model = new Model.InternetInfoEquip();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.MachineName = MachineName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.Logo = Convert.ToString(ds.Tables[0].Rows[0]["Logo"]);
                model.EUse = Convert.ToString(ds.Tables[0].Rows[0]["EUse"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                
              
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.InternetInfoEquip GetModel(int ID)
        {
            string strSql = "select * from InternetInfoEquip where ID = '" + ID + "'";
            Model.InternetInfoEquip model = new Model.InternetInfoEquip();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MachineName = Convert.ToString(ds.Tables[0].Rows[0]["MachineName"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.Logo = Convert.ToString(ds.Tables[0].Rows[0]["Logo"]);
                model.EUse = Convert.ToString(ds.Tables[0].Rows[0]["EUse"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);


                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据（根据MachineName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string MachineName)
        {
            string strSql = "delete from InternetInfoEquip where MachineName ='" + MachineName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int id)
        {
            string strSql = "delete from InternetInfoEquip where ID ='" + id + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from InternetInfoEquip where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        //public static DataSet GetBriefList(int offset, int limit, string MachineName = "")
        //{
        //    int endRecord = offset + limit;
        //    string sql = "SELECT * FROM InternetInfoEquip w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InternetInfoEquip where MachineName like '%" + MachineName + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
        //    return DBHelperSQL.GetDataSet(sql, connectionString);
        //}
        //public static int GetRecordCount(string MachineName = "")
        //{
        //    string strSql = "select count(*) from InternetInfoEquip where MachineName like '%" + MachineName + "%'";
        //    return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        //}



        public static DataSet GetBriefList(int offset, int limit, string where = "1=1")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM InternetInfoEquip w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InternetInfoEquip where "+where+" ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string where = "1=1")
        {
            string strSql = "select count(*) from InternetInfoEquip where "+where;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
