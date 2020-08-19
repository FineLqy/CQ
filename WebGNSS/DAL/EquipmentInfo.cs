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
    public class EquipmentInfo
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from EquipmentInfo where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 基站设备
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string StationOName)
        {
            string strSql = "select count(*) from EquipmentInfo where StationOName='" + StationOName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.EquipmentInfo model)
        {
            string strSql = "insert into EquipmentInfo(StationOName,StationName,DeviceType,Type,SerialNumber,InstallationDate,LoginName,Password,SatelliteSystem,AntennaH,AntennaHM,AntennaHML,IP,SubnetMask,Gateway,Port,BaudRate,DataConfiguration,MaintenanceTime,MaintenanceContent,MaintenancePerson, AntennaType, AntennaDate, AntennaModels, AntennaSerialNumber, MeteorologicalType, MeteorologicalDate, MeteorologicalModels, MeteorologicalSerialNumber, AtomicclkType, AtomicclkDate, AtomicclkModels, AtomicclkSerialNumber, switchType, switchDate, switchModels, switchSerialNumber, routerType, routerDate, routerModels, routerSerialNumber, FirewallType, FirewallDate, FirewallSerialNumber, FirewallModels, LightningType, LightningDate, LightningModels, LightningSerialNumber, ComputerType, ComputerModels, ComputerSerialNumber, ComputerDate,EquipID) values(@StationOName,@StationName,@DeviceType,@Type,@SerialNumber,@InstallationDate,@LoginName,@Password,@SatelliteSystem,@AntennaH,@AntennaHM,@AntennaHML,@IP,@SubnetMask,@Gateway,@Port,@BaudRate,@DataConfiguration,@MaintenanceTime,@MaintenanceContent,@MaintenancePerson, @AntennaType, @AntennaDate, @AntennaModels, @AntennaSerialNumber,@MeteorologicalType, @MeteorologicalDate, @MeteorologicalModels, @MeteorologicalSerialNumber, @AtomicclkType, @AtomicclkDate, @AtomicclkModels, @AtomicclkSerialNumber, @switchType, @switchDate, @switchModels, @switchSerialNumber, @routerType, @routerDate, @routerModels, @routerSerialNumber, @FirewallType, @FirewallDate, @FirewallSerialNumber, @FirewallModels, @LightningType, @LightningDate, @LightningModels, @LightningSerialNumber, @ComputerType, @ComputerModels, @ComputerSerialNumber, @ComputerDate,@EquipID)";
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter StationName = new SqlParameter("StationName", SqlDbType.NVarChar); StationName.Value = model.StationName;
            SqlParameter DeviceType = new SqlParameter("DeviceType", SqlDbType.NVarChar); DeviceType.Value = model.DeviceType;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter SerialNumber = new SqlParameter("SerialNumber", SqlDbType.NVarChar); SerialNumber.Value = model.SerialNumber;
            SqlParameter InstallationDate = new SqlParameter("InstallationDate", SqlDbType.DateTime); InstallationDate.Value = model.InstallationDate;
            SqlParameter LoginName = new SqlParameter("LoginName", SqlDbType.NVarChar); LoginName.Value = model.LoginName;
            SqlParameter Password = new SqlParameter("Password", SqlDbType.NVarChar); Password.Value = model.Password;
            SqlParameter SatelliteSystem = new SqlParameter("SatelliteSystem", SqlDbType.NVarChar); SatelliteSystem.Value = model.SatelliteSystem;
            SqlParameter AntennaH = new SqlParameter("AntennaH", SqlDbType.Float); AntennaH.Value = model.AntennaH;
            SqlParameter AntennaHM = new SqlParameter("AntennaHM", SqlDbType.NVarChar); AntennaHM.Value = model.AntennaHM;
            SqlParameter AntennaHML = new SqlParameter("AntennaHML", SqlDbType.NVarChar); AntennaHML.Value = model.AntennaHML;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter SubnetMask = new SqlParameter("SubnetMask", SqlDbType.NVarChar); SubnetMask.Value = model.SubnetMask;
            SqlParameter Gateway = new SqlParameter("Gateway", SqlDbType.NVarChar); Gateway.Value = model.Gateway;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter BaudRate = new SqlParameter("BaudRate", SqlDbType.NVarChar); BaudRate.Value = model.BaudRate;
            SqlParameter DataConfiguration = new SqlParameter("DataConfiguration", SqlDbType.NVarChar); DataConfiguration.Value = model.DataConfiguration;
            SqlParameter MaintenanceTime = new SqlParameter("MaintenanceTime", SqlDbType.DateTime); MaintenanceTime.Value = model.MaintenanceTime;
            SqlParameter MaintenanceContent = new SqlParameter("MaintenanceContent", SqlDbType.NVarChar); MaintenanceContent.Value = model.MaintenanceContent;
            SqlParameter MaintenancePerson = new SqlParameter("MaintenancePerson", SqlDbType.NVarChar); MaintenancePerson.Value = model.MaintenancePerson;
            SqlParameter AntennaType = new SqlParameter("AntennaType", SqlDbType.NVarChar); AntennaType.Value = model.AntennaType;
            SqlParameter AntennaDate = new SqlParameter("AntennaDate", SqlDbType.DateTime); AntennaDate.Value = model.AntennaDate;
            SqlParameter AntennaModels = new SqlParameter("AntennaModels", SqlDbType.NVarChar); AntennaModels.Value = model.AntennaModels;
            SqlParameter AntennaSerialNumber = new SqlParameter("AntennaSerialNumber", SqlDbType.NVarChar); AntennaSerialNumber.Value = model.AntennaSerialNumber;
            SqlParameter MeteorologicalType = new SqlParameter("MeteorologicalType", SqlDbType.NVarChar); MeteorologicalType.Value = model.MeteorologicalType;
            SqlParameter MeteorologicalDate = new SqlParameter("MeteorologicalDate", SqlDbType.DateTime); MeteorologicalDate.Value = model.MeteorologicalDate;
            SqlParameter MeteorologicalModels = new SqlParameter("MeteorologicalModels", SqlDbType.NVarChar); MeteorologicalModels.Value = model.MeteorologicalModels;
            SqlParameter MeteorologicalSerialNumber = new SqlParameter("MeteorologicalSerialNumber", SqlDbType.NVarChar); MeteorologicalSerialNumber.Value = model.MeteorologicalSerialNumber;
            SqlParameter AtomicclkType = new SqlParameter("AtomicclkType", SqlDbType.NVarChar); AtomicclkType.Value = model.AtomicclkType;
            SqlParameter AtomicclkDate = new SqlParameter("AtomicclkDate", SqlDbType.DateTime); AtomicclkDate.Value = model.AtomicclkDate;
            SqlParameter AtomicclkModels = new SqlParameter("AtomicclkModels", SqlDbType.NVarChar); AtomicclkModels.Value = model.AtomicclkModels;
            SqlParameter AtomicclkSerialNumber = new SqlParameter("AtomicclkSerialNumber", SqlDbType.NVarChar); AtomicclkSerialNumber.Value = model.AtomicclkSerialNumber;
            SqlParameter switchType = new SqlParameter("switchType", SqlDbType.NVarChar); switchType.Value = model.switchType;
            SqlParameter switchDate = new SqlParameter("switchDate", SqlDbType.DateTime); switchDate.Value = model.switchDate;
            SqlParameter switchModels = new SqlParameter("switchModels", SqlDbType.NVarChar); switchModels.Value = model.switchModels;
            SqlParameter switchSerialNumber = new SqlParameter("switchSerialNumber", SqlDbType.NVarChar); switchSerialNumber.Value = model.switchSerialNumber;
            SqlParameter routerType = new SqlParameter("routerType", SqlDbType.NVarChar); routerType.Value = model.routerType;
            SqlParameter routerDate = new SqlParameter("routerDate", SqlDbType.DateTime); routerDate.Value = model.routerDate;
            SqlParameter routerModels = new SqlParameter("routerModels", SqlDbType.NVarChar); routerModels.Value = model.routerModels;
            SqlParameter routerSerialNumber = new SqlParameter("routerSerialNumber", SqlDbType.NVarChar); routerSerialNumber.Value = model.routerSerialNumber;
            SqlParameter FirewallType = new SqlParameter("FirewallType", SqlDbType.NVarChar); FirewallType.Value = model.FirewallType;
            SqlParameter FirewallDate = new SqlParameter("FirewallDate", SqlDbType.DateTime); FirewallDate.Value = model.FirewallDate;
            SqlParameter FirewallSerialNumber = new SqlParameter("FirewallSerialNumber", SqlDbType.NVarChar); FirewallSerialNumber.Value = model.FirewallSerialNumber;
            SqlParameter FirewallModels = new SqlParameter("FirewallModels", SqlDbType.NVarChar); FirewallModels.Value = model.FirewallModels;
            SqlParameter LightningType = new SqlParameter("LightningType", SqlDbType.NVarChar); LightningType.Value = model.LightningType;
            SqlParameter LightningDate = new SqlParameter("LightningDate", SqlDbType.DateTime); LightningDate.Value = model.LightningDate;
            SqlParameter LightningModels = new SqlParameter("LightningModels", SqlDbType.NVarChar); LightningModels.Value = model.LightningModels;
            SqlParameter LightningSerialNumber = new SqlParameter("LightningSerialNumber", SqlDbType.NVarChar); LightningSerialNumber.Value = model.LightningSerialNumber;
            SqlParameter ComputerType = new SqlParameter("ComputerType", SqlDbType.NVarChar); ComputerType.Value = model.ComputerType;
            SqlParameter ComputerModels = new SqlParameter("ComputerModels", SqlDbType.NVarChar); ComputerModels.Value = model.ComputerModels;
            SqlParameter ComputerSerialNumber = new SqlParameter("ComputerSerialNumber", SqlDbType.NVarChar); ComputerSerialNumber.Value = model.ComputerSerialNumber;
            SqlParameter ComputerDate = new SqlParameter("ComputerDate", SqlDbType.DateTime); ComputerDate.Value = model.ComputerDate;
            SqlParameter EquipID = new SqlParameter("EquipID", SqlDbType.NVarChar); EquipID.Value = model.EquipID;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationOName, StationName, DeviceType, Type, SerialNumber, InstallationDate, LoginName, Password, SatelliteSystem, AntennaH, AntennaHM, AntennaHML, IP, SubnetMask, Gateway, Port, BaudRate, DataConfiguration, MaintenanceTime, MaintenanceContent, MaintenancePerson, AntennaType, AntennaDate, AntennaModels, AntennaSerialNumber, MeteorologicalType, MeteorologicalDate, MeteorologicalModels, MeteorologicalSerialNumber, AtomicclkType, AtomicclkDate, AtomicclkModels, AtomicclkSerialNumber, switchType, switchDate, switchModels, switchSerialNumber, routerType, routerDate, routerModels, routerSerialNumber, FirewallType, FirewallDate, FirewallSerialNumber, FirewallModels, LightningType, LightningDate, LightningModels, LightningSerialNumber, ComputerType, ComputerModels, ComputerSerialNumber, ComputerDate, EquipID }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.EquipmentInfo model)
        {
            string strSql = "update EquipmentInfo set EquipID=@EquipID,StationOName=@StationOName, StationName=@StationName,DeviceType=@DeviceType,Type=@Type,SerialNumber=@SerialNumber,InstallationDate=@InstallationDate,LoginName=@LoginName,Password=@Password,SatelliteSystem=@SatelliteSystem,AntennaH=@AntennaH,AntennaHM=@AntennaHM,AntennaHML=@AntennaHML,IP=@IP,SubnetMask=@SubnetMask,Gateway=@Gateway,Port=@Port,BaudRate=@BaudRate,DataConfiguration=@DataConfiguration,MaintenanceTime=@MaintenanceTime,MaintenanceContent=@MaintenanceContent,MaintenancePerson=@MaintenancePerson, AntennaType=@AntennaType, AntennaDate=@AntennaDate, AntennaModels=@AntennaModels, AntennaSerialNumber=@AntennaSerialNumber, MeteorologicalType=@MeteorologicalType, MeteorologicalDate=@MeteorologicalDate, MeteorologicalModels=@MeteorologicalModels, MeteorologicalSerialNumber=@MeteorologicalSerialNumber, AtomicclkType=@AtomicclkType, AtomicclkDate=@AtomicclkDate, AtomicclkModels=@AtomicclkModels, AtomicclkSerialNumber=@AtomicclkSerialNumber, switchType=@switchType, switchDate=@switchDate, switchModels=@switchModels, switchSerialNumber=@switchSerialNumber, routerType=@routerType, routerDate=@routerDate, routerModels=@routerModels, routerSerialNumber=@routerSerialNumber, FirewallType=@FirewallType, FirewallDate=@FirewallDate, FirewallSerialNumber=@FirewallSerialNumber, FirewallModels=@FirewallModels, LightningType=@LightningType, LightningDate=@LightningDate, LightningModels=@LightningModels, LightningSerialNumber=@LightningSerialNumber, ComputerType=@ComputerType, ComputerModels=@ComputerModels, ComputerSerialNumber=@ComputerSerialNumber, ComputerDate=@ComputerDate where ID = " + model.ID.ToString();
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter StationName = new SqlParameter("StationName", SqlDbType.NVarChar); StationName.Value = model.StationName;
            SqlParameter DeviceType = new SqlParameter("DeviceType", SqlDbType.NVarChar); DeviceType.Value = model.DeviceType;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter SerialNumber = new SqlParameter("SerialNumber", SqlDbType.NVarChar); SerialNumber.Value = model.SerialNumber;
            SqlParameter InstallationDate = new SqlParameter("InstallationDate", SqlDbType.DateTime); InstallationDate.Value = model.InstallationDate;
            SqlParameter LoginName = new SqlParameter("LoginName", SqlDbType.NVarChar); LoginName.Value = model.LoginName;
            SqlParameter Password = new SqlParameter("Password", SqlDbType.NVarChar); Password.Value = model.Password;
            SqlParameter SatelliteSystem = new SqlParameter("SatelliteSystem", SqlDbType.NVarChar); SatelliteSystem.Value = model.SatelliteSystem;
            SqlParameter AntennaH = new SqlParameter("AntennaH", SqlDbType.Float); AntennaH.Value = model.AntennaH;
            SqlParameter AntennaHM = new SqlParameter("AntennaHM", SqlDbType.NVarChar); AntennaHM.Value = model.AntennaHM;
            SqlParameter AntennaHML = new SqlParameter("AntennaHML", SqlDbType.NVarChar); AntennaHML.Value = model.AntennaHML;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter SubnetMask = new SqlParameter("SubnetMask", SqlDbType.NVarChar); SubnetMask.Value = model.SubnetMask;
            SqlParameter Gateway = new SqlParameter("Gateway", SqlDbType.NVarChar); Gateway.Value = model.Gateway;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter BaudRate = new SqlParameter("BaudRate", SqlDbType.NVarChar); BaudRate.Value = model.BaudRate;
            SqlParameter DataConfiguration = new SqlParameter("DataConfiguration", SqlDbType.NVarChar); DataConfiguration.Value = model.DataConfiguration;
            SqlParameter MaintenanceTime = new SqlParameter("MaintenanceTime", SqlDbType.DateTime); MaintenanceTime.Value = model.MaintenanceTime;
            SqlParameter MaintenanceContent = new SqlParameter("MaintenanceContent", SqlDbType.NVarChar); MaintenanceContent.Value = model.MaintenanceContent;
            SqlParameter MaintenancePerson = new SqlParameter("MaintenancePerson", SqlDbType.NVarChar); MaintenancePerson.Value = model.MaintenancePerson;

            SqlParameter AntennaType = new SqlParameter("AntennaType", SqlDbType.NVarChar); AntennaType.Value = model.AntennaType;
            SqlParameter AntennaDate = new SqlParameter("AntennaDate", SqlDbType.DateTime); AntennaDate.Value = model.AntennaDate;
            SqlParameter AntennaModels = new SqlParameter("AntennaModels", SqlDbType.NVarChar); AntennaModels.Value = model.AntennaModels;
            SqlParameter AntennaSerialNumber = new SqlParameter("AntennaSerialNumber", SqlDbType.NVarChar); AntennaSerialNumber.Value = model.AntennaSerialNumber;
            SqlParameter MeteorologicalType = new SqlParameter("MeteorologicalType", SqlDbType.NVarChar); MeteorologicalType.Value = model.MeteorologicalType;
            SqlParameter MeteorologicalDate = new SqlParameter("MeteorologicalDate", SqlDbType.DateTime); MeteorologicalDate.Value = model.MeteorologicalDate;
            SqlParameter MeteorologicalModels = new SqlParameter("MeteorologicalModels", SqlDbType.NVarChar); MeteorologicalModels.Value = model.MeteorologicalModels;
            SqlParameter MeteorologicalSerialNumber = new SqlParameter("MeteorologicalSerialNumber", SqlDbType.NVarChar); MeteorologicalSerialNumber.Value = model.MeteorologicalSerialNumber;
            SqlParameter AtomicclkType = new SqlParameter("AtomicclkType", SqlDbType.NVarChar); AtomicclkType.Value = model.AtomicclkType;
            SqlParameter AtomicclkDate = new SqlParameter("AtomicclkDate", SqlDbType.DateTime); AtomicclkDate.Value = model.AtomicclkDate;
            SqlParameter AtomicclkModels = new SqlParameter("AtomicclkModels", SqlDbType.NVarChar); AtomicclkModels.Value = model.AtomicclkModels;
            SqlParameter AtomicclkSerialNumber = new SqlParameter("AtomicclkSerialNumber", SqlDbType.NVarChar); AtomicclkSerialNumber.Value = model.AtomicclkSerialNumber;
            SqlParameter switchType = new SqlParameter("switchType", SqlDbType.NVarChar); switchType.Value = model.switchType;
            SqlParameter switchDate = new SqlParameter("switchDate", SqlDbType.DateTime); switchDate.Value = model.switchDate;
            SqlParameter switchModels = new SqlParameter("switchModels", SqlDbType.NVarChar); switchModels.Value = model.switchModels;
            SqlParameter switchSerialNumber = new SqlParameter("switchSerialNumber", SqlDbType.NVarChar); switchSerialNumber.Value = model.switchSerialNumber;
            SqlParameter routerType = new SqlParameter("routerType", SqlDbType.NVarChar); routerType.Value = model.routerType;
            SqlParameter routerDate = new SqlParameter("routerDate", SqlDbType.DateTime); routerDate.Value = model.routerDate;
            SqlParameter routerModels = new SqlParameter("routerModels", SqlDbType.NVarChar); routerModels.Value = model.routerModels;
            SqlParameter routerSerialNumber = new SqlParameter("routerSerialNumber", SqlDbType.NVarChar); routerSerialNumber.Value = model.routerSerialNumber;
            SqlParameter FirewallType = new SqlParameter("FirewallType", SqlDbType.NVarChar); FirewallType.Value = model.FirewallType;
            SqlParameter FirewallDate = new SqlParameter("FirewallDate", SqlDbType.DateTime); FirewallDate.Value = model.FirewallDate;
            SqlParameter FirewallSerialNumber = new SqlParameter("FirewallSerialNumber", SqlDbType.NVarChar); FirewallSerialNumber.Value = model.FirewallSerialNumber;
            SqlParameter FirewallModels = new SqlParameter("FirewallModels", SqlDbType.NVarChar); FirewallModels.Value = model.FirewallModels;
            SqlParameter LightningType = new SqlParameter("LightningType", SqlDbType.NVarChar); LightningType.Value = model.LightningType;
            SqlParameter LightningDate = new SqlParameter("LightningDate", SqlDbType.DateTime); LightningDate.Value = model.LightningDate;
            SqlParameter LightningModels = new SqlParameter("LightningModels", SqlDbType.NVarChar); LightningModels.Value = model.LightningModels;
            SqlParameter LightningSerialNumber = new SqlParameter("LightningSerialNumber", SqlDbType.NVarChar); LightningSerialNumber.Value = model.LightningSerialNumber;
            SqlParameter ComputerType = new SqlParameter("ComputerType", SqlDbType.NVarChar); ComputerType.Value = model.ComputerType;
            SqlParameter ComputerModels = new SqlParameter("ComputerModels", SqlDbType.NVarChar); ComputerModels.Value = model.ComputerModels;
            SqlParameter ComputerSerialNumber = new SqlParameter("ComputerSerialNumber", SqlDbType.NVarChar); ComputerSerialNumber.Value = model.ComputerSerialNumber;
            SqlParameter ComputerDate = new SqlParameter("ComputerDate", SqlDbType.DateTime); ComputerDate.Value = model.ComputerDate;
            SqlParameter EquipID = new SqlParameter("EquipID", SqlDbType.NVarChar); EquipID.Value = model.EquipID;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationOName, StationName, DeviceType, Type, SerialNumber, InstallationDate, LoginName, Password, SatelliteSystem, AntennaH, AntennaHM, AntennaHML, IP, SubnetMask, Gateway, Port, BaudRate, DataConfiguration, MaintenanceTime, MaintenanceContent, MaintenancePerson, AntennaType, AntennaDate, AntennaModels, AntennaSerialNumber, MeteorologicalType, MeteorologicalDate, MeteorologicalModels, MeteorologicalSerialNumber, AtomicclkType, AtomicclkDate, AtomicclkModels, AtomicclkSerialNumber, switchType, switchDate, switchModels, switchSerialNumber, routerType, routerDate, routerModels, routerSerialNumber, FirewallType, FirewallDate, FirewallSerialNumber, FirewallModels, LightningType, LightningDate, LightningModels, LightningSerialNumber, ComputerType, ComputerModels, ComputerSerialNumber, ComputerDate, EquipID }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.EquipmentInfo GetModel(string StationOName)
        {
            string strSql = "select * from EquipmentInfo where StationOName = '" + StationOName + "'";
            Model.EquipmentInfo model = new Model.EquipmentInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.StationOName = StationOName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AntennaH = Convert.ToDouble(ds.Tables[0].Rows[0]["AntennaH"]);
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.AntennaHM = Convert.ToString(ds.Tables[0].Rows[0]["AntennaHM"]);
                model.AntennaHML = Convert.ToString(ds.Tables[0].Rows[0]["AntennaHML"]);
                model.BaudRate = Convert.ToString(ds.Tables[0].Rows[0]["BaudRate"]);
                model.DataConfiguration = Convert.ToString(ds.Tables[0].Rows[0]["DataConfiguration"]);
                model.DeviceType = Convert.ToString(ds.Tables[0].Rows[0]["DeviceType"]);
                model.Gateway = Convert.ToString(ds.Tables[0].Rows[0]["Gateway"]);
                model.InstallationDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InstallationDate"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.LoginName = Convert.ToString(ds.Tables[0].Rows[0]["LoginName"]);
                model.MaintenanceContent = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceContent"]);
                model.MaintenancePerson = Convert.ToString(ds.Tables[0].Rows[0]["MaintenancePerson"]);
                model.MaintenanceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaintenanceTime"]);
                model.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.SatelliteSystem = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteSystem"]);
                model.SerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["SerialNumber"]);
                model.StationName = Convert.ToString(ds.Tables[0].Rows[0]["StationName"]);
                model.SubnetMask = Convert.ToString(ds.Tables[0].Rows[0]["SubnetMask"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                model.AntennaType = Convert.ToString(ds.Tables[0].Rows[0]["AntennaType"]);
                model.AntennaDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AntennaDate"]);
                model.AntennaModels = Convert.ToString(ds.Tables[0].Rows[0]["AntennaModels"]);
                model.AntennaSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["AntennaSerialNumber"]);
                model.MeteorologicalType = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalType"]);
                model.MeteorologicalDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MeteorologicalDate"]);
                model.MeteorologicalModels = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalModels"]);
                model.MeteorologicalSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalSerialNumber"]);
                model.AtomicclkType = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkType"]);
                model.AtomicclkDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AtomicclkDate"]);
                model.AtomicclkModels = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkModels"]);
                model.AtomicclkSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkSerialNumber"]);
                model.switchType = Convert.ToString(ds.Tables[0].Rows[0]["switchType"]);
                model.switchDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["switchDate"]);
                model.switchModels = Convert.ToString(ds.Tables[0].Rows[0]["switchModels"]);
                model.switchSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["switchSerialNumber"]);
                model.routerType = Convert.ToString(ds.Tables[0].Rows[0]["routerType"]);
                model.routerDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["routerDate"]);
                model.routerModels = Convert.ToString(ds.Tables[0].Rows[0]["routerModels"]);
                model.routerSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["routerSerialNumber"]);
                model.FirewallType = Convert.ToString(ds.Tables[0].Rows[0]["FirewallType"]);
                model.FirewallDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FirewallDate"]);
                model.FirewallSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["FirewallSerialNumber"]);
                model.FirewallModels = Convert.ToString(ds.Tables[0].Rows[0]["FirewallModels"]);
                model.LightningType = Convert.ToString(ds.Tables[0].Rows[0]["LightningType"]);
                model.LightningDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["LightningDate"]);
                model.LightningModels = Convert.ToString(ds.Tables[0].Rows[0]["LightningModels"]);
                model.LightningSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["LightningSerialNumber"]);
                model.ComputerType = Convert.ToString(ds.Tables[0].Rows[0]["ComputerType"]);
                model.ComputerModels = Convert.ToString(ds.Tables[0].Rows[0]["ComputerModels"]);
                model.ComputerSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["ComputerSerialNumber"]);
                model.ComputerDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ComputerDate"]);
                model.EquipID = Convert.ToString(ds.Tables[0].Rows[0]["EquipID"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.EquipmentInfo GetModel(string StationName,int i=1)
        {
            string strSql = "select * from EquipmentInfo where StationName = '" + StationName + "'";
            Model.EquipmentInfo model = new Model.EquipmentInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.StationName = StationName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AntennaH = Convert.ToDouble(ds.Tables[0].Rows[0]["AntennaH"]);
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.AntennaHM = Convert.ToString(ds.Tables[0].Rows[0]["AntennaHM"]);
                model.AntennaHML = Convert.ToString(ds.Tables[0].Rows[0]["AntennaHML"]);
                model.BaudRate = Convert.ToString(ds.Tables[0].Rows[0]["BaudRate"]);
                model.DataConfiguration = Convert.ToString(ds.Tables[0].Rows[0]["DataConfiguration"]);
                model.DeviceType = Convert.ToString(ds.Tables[0].Rows[0]["DeviceType"]);
                model.Gateway = Convert.ToString(ds.Tables[0].Rows[0]["Gateway"]);
                model.InstallationDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InstallationDate"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.LoginName = Convert.ToString(ds.Tables[0].Rows[0]["LoginName"]);
                model.MaintenanceContent = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceContent"]);
                model.MaintenancePerson = Convert.ToString(ds.Tables[0].Rows[0]["MaintenancePerson"]);
                model.MaintenanceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaintenanceTime"]);
                model.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.SatelliteSystem = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteSystem"]);
                model.SerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["SerialNumber"]);
                model.StationOName = Convert.ToString(ds.Tables[0].Rows[0]["StationOName"]);
                model.SubnetMask = Convert.ToString(ds.Tables[0].Rows[0]["SubnetMask"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                model.AntennaType = Convert.ToString(ds.Tables[0].Rows[0]["AntennaType"]);
                model.AntennaDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AntennaDate"]);
                model.AntennaModels = Convert.ToString(ds.Tables[0].Rows[0]["AntennaModels"]);
                model.AntennaSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["AntennaSerialNumber"]);
                model.MeteorologicalType = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalType"]);
                model.MeteorologicalDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MeteorologicalDate"]);
                model.MeteorologicalModels = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalModels"]);
                model.MeteorologicalSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalSerialNumber"]);
                model.AtomicclkType = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkType"]);
                model.AtomicclkDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AtomicclkDate"]);
                model.AtomicclkModels = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkModels"]);
                model.AtomicclkSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkSerialNumber"]);
                model.switchType = Convert.ToString(ds.Tables[0].Rows[0]["switchType"]);
                model.switchDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["switchDate"]);
                model.switchModels = Convert.ToString(ds.Tables[0].Rows[0]["switchModels"]);
                model.switchSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["switchSerialNumber"]);
                model.routerType = Convert.ToString(ds.Tables[0].Rows[0]["routerType"]);
                model.routerDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["routerDate"]);
                model.routerModels = Convert.ToString(ds.Tables[0].Rows[0]["routerModels"]);
                model.routerSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["routerSerialNumber"]);
                model.FirewallType = Convert.ToString(ds.Tables[0].Rows[0]["FirewallType"]);
                model.FirewallDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FirewallDate"]);
                model.FirewallSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["FirewallSerialNumber"]);
                model.FirewallModels = Convert.ToString(ds.Tables[0].Rows[0]["FirewallModels"]);
                model.LightningType = Convert.ToString(ds.Tables[0].Rows[0]["LightningType"]);
                model.LightningDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["LightningDate"]);
                model.LightningModels = Convert.ToString(ds.Tables[0].Rows[0]["LightningModels"]);
                model.LightningSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["LightningSerialNumber"]);
                model.ComputerType = Convert.ToString(ds.Tables[0].Rows[0]["ComputerType"]);
                model.ComputerModels = Convert.ToString(ds.Tables[0].Rows[0]["ComputerModels"]);
                model.ComputerSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["ComputerSerialNumber"]);
                model.ComputerDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ComputerDate"]);
                model.EquipID = Convert.ToString(ds.Tables[0].Rows[0]["EquipID"]);
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
        public static Model.EquipmentInfo GetModel(int ID)
        {
            string strSql = "select * from EquipmentInfo where ID = " + ID.ToString();
            Model.EquipmentInfo model = new Model.EquipmentInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AntennaH = Convert.ToDouble(ds.Tables[0].Rows[0]["AntennaH"]);
                model.StationOName = Convert.ToString(ds.Tables[0].Rows[0]["StationOName"]); ;
                model.AntennaHM = Convert.ToString(ds.Tables[0].Rows[0]["AntennaHM"]);
                model.AntennaHML = Convert.ToString(ds.Tables[0].Rows[0]["AntennaHML"]);
                model.BaudRate = Convert.ToString(ds.Tables[0].Rows[0]["BaudRate"]);
                model.DataConfiguration = Convert.ToString(ds.Tables[0].Rows[0]["DataConfiguration"]);
                model.DeviceType = Convert.ToString(ds.Tables[0].Rows[0]["DeviceType"]);
                model.Gateway = Convert.ToString(ds.Tables[0].Rows[0]["Gateway"]);
                model.InstallationDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InstallationDate"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.LoginName = Convert.ToString(ds.Tables[0].Rows[0]["LoginName"]);
                model.MaintenanceContent = Convert.ToString(ds.Tables[0].Rows[0]["MaintenanceContent"]);
                model.MaintenancePerson = Convert.ToString(ds.Tables[0].Rows[0]["MaintenancePerson"]);
                model.MaintenanceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaintenanceTime"]);
                model.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.SatelliteSystem = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteSystem"]);
                model.SerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["SerialNumber"]);
                model.StationName = Convert.ToString(ds.Tables[0].Rows[0]["StationName"]);
                model.SubnetMask = Convert.ToString(ds.Tables[0].Rows[0]["SubnetMask"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                model.AntennaType = Convert.ToString(ds.Tables[0].Rows[0]["AntennaType"]);
                model.AntennaDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AntennaDate"]);
                model.AntennaModels = Convert.ToString(ds.Tables[0].Rows[0]["AntennaModels"]);
                model.AntennaSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["AntennaSerialNumber"]);
                model.MeteorologicalType = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalType"]);
                model.MeteorologicalDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MeteorologicalDate"]);
                model.MeteorologicalModels = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalModels"]);
                model.MeteorologicalSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["MeteorologicalSerialNumber"]);
                model.AtomicclkType = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkType"]);
                model.AtomicclkDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AtomicclkDate"]);
                model.AtomicclkModels = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkModels"]);
                model.AtomicclkSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["AtomicclkSerialNumber"]);
                model.switchType = Convert.ToString(ds.Tables[0].Rows[0]["switchType"]);
                model.switchDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["switchDate"]);
                model.switchModels = Convert.ToString(ds.Tables[0].Rows[0]["switchModels"]);
                model.switchSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["switchSerialNumber"]);
                model.routerType = Convert.ToString(ds.Tables[0].Rows[0]["routerType"]);
                model.routerDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["routerDate"]);
                model.routerModels = Convert.ToString(ds.Tables[0].Rows[0]["routerModels"]);
                model.routerSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["routerSerialNumber"]);
                model.FirewallType = Convert.ToString(ds.Tables[0].Rows[0]["FirewallType"]);
                model.FirewallDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FirewallDate"]);
                model.FirewallSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["FirewallSerialNumber"]);
                model.FirewallModels = Convert.ToString(ds.Tables[0].Rows[0]["FirewallModels"]);
                model.LightningType = Convert.ToString(ds.Tables[0].Rows[0]["LightningType"]);
                model.LightningDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["LightningDate"]);
                model.LightningModels = Convert.ToString(ds.Tables[0].Rows[0]["LightningModels"]);
                model.LightningSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["LightningSerialNumber"]);
                model.ComputerType = Convert.ToString(ds.Tables[0].Rows[0]["ComputerType"]);
                model.ComputerModels = Convert.ToString(ds.Tables[0].Rows[0]["ComputerModels"]);
                model.ComputerSerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["ComputerSerialNumber"]);
                model.ComputerDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ComputerDate"]);
                model.EquipID = Convert.ToString(ds.Tables[0].Rows[0]["EquipID"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据（根据StationOName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string StationOName)
        {
            string strSql = "delete from EquipmentInfo where StationOName ='" + StationOName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from EquipmentInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

    }
}
