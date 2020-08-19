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
    public class DataCenter
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from DataCenter where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
       
        /// <summary>
        /// 设备类型
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string DeviceType)
        {
            string strSql = "select count(*) from DataCenter where DeviceType='" + DeviceType + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        public static bool Exists(string SerialNumber, int i = 1)
        {
            string strSql = "select count(*) from DataCenter where SerialNumber='" + SerialNumber + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.DataCenter model)
        {
            string strSql = "insert into DataCenter(DeviceType, Type, SerialNumber, FirstUseDate, LoginName, Password, Business, IP, SubnetMask, Gateway, Port, MaintenanceTime, MaintenanceContent, MaintenancePerson) values(@DeviceType, @Type, @SerialNumber, @FirstUseDate, @LoginName, @Password, @Business, @IP, @SubnetMask, @Gateway, @Port, @MaintenanceTime, @MaintenanceContent, @MaintenancePerson)";
            SqlParameter DeviceType = new SqlParameter("DeviceType", SqlDbType.NVarChar); DeviceType.Value = model.DeviceType;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter SerialNumber = new SqlParameter("SerialNumber", SqlDbType.NVarChar); SerialNumber.Value = model.SerialNumber;
            SqlParameter FirstUseDate = new SqlParameter("FirstUseDate", SqlDbType.DateTime); FirstUseDate.Value = model.FirstUseDate;
            SqlParameter LoginName = new SqlParameter("LoginName", SqlDbType.NVarChar); LoginName.Value = model.LoginName;
            SqlParameter Password = new SqlParameter("Password", SqlDbType.NVarChar); Password.Value = model.Password;
            SqlParameter Business = new SqlParameter("Business", SqlDbType.NVarChar); Business.Value = model.Business;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter SubnetMask = new SqlParameter("SubnetMask", SqlDbType.NVarChar); SubnetMask.Value = model.SubnetMask;
            SqlParameter Gateway = new SqlParameter("Gateway", SqlDbType.NVarChar); Gateway.Value = model.Gateway;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter MaintenanceTime = new SqlParameter("MaintenanceTime", SqlDbType.DateTime); MaintenanceTime.Value = model.MaintenanceTime;
            SqlParameter MaintenanceContent = new SqlParameter("MaintenanceContent", SqlDbType.NVarChar); MaintenanceContent.Value = model.MaintenanceContent;
            SqlParameter MaintenancePerson = new SqlParameter("MaintenancePerson", SqlDbType.NVarChar); MaintenancePerson.Value = model.MaintenancePerson;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { DeviceType, Type, SerialNumber, FirstUseDate, LoginName, Password, Business, IP, SubnetMask, Gateway, Port, MaintenanceTime, MaintenanceContent, MaintenancePerson }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.DataCenter model)
        {
            string strSql = "update DataCenter set DeviceType=@DeviceType,Type=@Type,SerialNumber=@SerialNumber,FirstUseDate=@FirstUseDate,LoginName=@LoginName,Password=@Password,Business=@Business,IP=@IP,SubnetMask=@SubnetMask,Gateway=@Gateway,Port=@Port,MaintenanceTime=@MaintenanceTime,MaintenanceContent=@MaintenanceContent,MaintenancePerson=@MaintenancePerson where ID = " + model.ID.ToString();
            SqlParameter DeviceType = new SqlParameter("DeviceType", SqlDbType.NVarChar); DeviceType.Value = model.DeviceType;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter SerialNumber = new SqlParameter("SerialNumber", SqlDbType.NVarChar); SerialNumber.Value = model.SerialNumber;
            SqlParameter FirstUseDate = new SqlParameter("FirstUseDate", SqlDbType.DateTime); FirstUseDate.Value = model.FirstUseDate;
            SqlParameter LoginName = new SqlParameter("LoginName", SqlDbType.NVarChar); LoginName.Value = model.LoginName;
            SqlParameter Password = new SqlParameter("Password", SqlDbType.NVarChar); Password.Value = model.Password;
            SqlParameter Business = new SqlParameter("Business", SqlDbType.NVarChar); Business.Value = model.Business;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter SubnetMask = new SqlParameter("SubnetMask", SqlDbType.NVarChar); SubnetMask.Value = model.SubnetMask;
            SqlParameter Gateway = new SqlParameter("Gateway", SqlDbType.NVarChar); Gateway.Value = model.Gateway;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter MaintenanceTime = new SqlParameter("MaintenanceTime", SqlDbType.DateTime); MaintenanceTime.Value = model.MaintenanceTime;
            SqlParameter MaintenanceContent = new SqlParameter("MaintenanceContent", SqlDbType.NVarChar); MaintenanceContent.Value = model.MaintenanceContent;
            SqlParameter MaintenancePerson = new SqlParameter("MaintenancePerson", SqlDbType.NVarChar); MaintenancePerson.Value = model.MaintenancePerson;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { DeviceType, Type, SerialNumber, FirstUseDate, LoginName, Password, Business, IP, SubnetMask, Gateway, Port, MaintenanceTime, MaintenanceContent, MaintenancePerson }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象根据序列号
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.DataCenter GetModel(string SerialNumber)
        {
            string strSql = "select * from DataCenter where SerialNumber = '" + SerialNumber + "'";
            Model.DataCenter model = new Model.DataCenter();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.SerialNumber = SerialNumber;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
    
                model.Business = Convert.ToString(ds.Tables[0].Rows[0]["Business"]);
                model.DeviceType = Convert.ToString(ds.Tables[0].Rows[0]["DeviceType"]);
                model.Gateway = Convert.ToString(ds.Tables[0].Rows[0]["Gateway"]);
                model.FirstUseDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FirstUseDate"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.LoginName = Convert.ToString(ds.Tables[0].Rows[0]["LoginName"]);
                model.MaintenanceContent = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceContent"]);
                model.MaintenancePerson = Convert.ToString(ds.Tables[0].Rows[0]["MaintenancePerson"]);
                model.MaintenanceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaintenanceTime"]);
                model.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);               
              
                model.SubnetMask = Convert.ToString(ds.Tables[0].Rows[0]["SubnetMask"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.DataCenter GetModel(int ID)
        {
            string strSql = "select * from DataCenter where ID = '" + ID + "'";
            Model.DataCenter model = new Model.DataCenter();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["SerialNumber"]);
                model.Business = Convert.ToString(ds.Tables[0].Rows[0]["Business"]);
                model.DeviceType = Convert.ToString(ds.Tables[0].Rows[0]["DeviceType"]);
                model.Gateway = Convert.ToString(ds.Tables[0].Rows[0]["Gateway"]);
                model.FirstUseDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FirstUseDate"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.LoginName = Convert.ToString(ds.Tables[0].Rows[0]["LoginName"]);
                model.MaintenanceContent = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceContent"]);
                model.MaintenancePerson = Convert.ToString(ds.Tables[0].Rows[0]["MaintenancePerson"]);
                model.MaintenanceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaintenanceTime"]);
                model.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.SubnetMask = Convert.ToString(ds.Tables[0].Rows[0]["SubnetMask"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                return model;
            }
            else
            {
                return null;
            }
        }
       

        /// <summary>
        /// 删除一条数据（根据SerialNumber）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string SerialNumber)
        {
            string strSql = "delete from DataCenter where SerialNumber ='" + SerialNumber + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from DataCenter where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetBriefList(int offset, int limit, string DeviceType = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM DataCenter w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM DataCenter where DeviceType like '%" + DeviceType + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string DeviceType = "")
        {
            string strSql = "select count(*) from DataCenter where DeviceType like '%" + DeviceType + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
