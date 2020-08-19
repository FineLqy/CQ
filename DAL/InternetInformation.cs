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
    public class InternetInformation
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from InternetInformation where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 类型
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string Type)
        {
            string strSql = "select count(*) from InternetInformation where Type='" + Type + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个网络信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.InternetInformation model)
        {

            string strSql = "insert into InternetInformation(DataLineStartP,DataLineEndP,Type,EncryptionTechnology,BandWidth,GreenOperator,TechnicalSupportStaff,FDataLineType,FEncryptionTechnology,FBandWidth,FGreenOperator,FTechnicalSupportStaff,ServerIP,ServerPort,ServerMachineName,ServerLogo,ServerUse,ServerRemark,StorageIP,StoragePort,StorageMachineName,StorageLogo,StorageUse,StorageRemark,EquipmentID,EquipConfig,Topological,RouterConfig) values(@DataLineStartP,@DataLineEndP,@Type,@EncryptionTechnology,@BandWidth,@GreenOperator,@TechnicalSupportStaff,@FDataLineType,@FEncryptionTechnology,@FBandWidth,@FGreenOperator,@FTechnicalSupportStaff,@ServerIP,@ServerPort,@ServerMachineName,@ServerLogo,@ServerUse,@ServerRemark,@StorageIP,@StoragePort,@StorageMachineName,@StorageLogo,@StorageUse,@StorageRemark,@EquipmentID,@EquipConfig,@Topological,@RouterConfig)";
            SqlParameter DataLineStartP = new SqlParameter("DataLineStartP", SqlDbType.NVarChar); DataLineStartP.Value = model.DataLineStartP;
            SqlParameter DataLineEndP = new SqlParameter("DataLineEndP", SqlDbType.NVarChar); DataLineEndP.Value = model.DataLineEndP;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter EncryptionTechnology = new SqlParameter("EncryptionTechnology", SqlDbType.NVarChar); EncryptionTechnology.Value = model.EncryptionTechnology;
            SqlParameter BandWidth = new SqlParameter("BandWidth", SqlDbType.NVarChar); BandWidth.Value = model.BandWidth;
            SqlParameter GreenOperator = new SqlParameter("GreenOperator", SqlDbType.NVarChar); GreenOperator.Value = model.GreenOperator;
            SqlParameter TechnicalSupportStaff = new SqlParameter("TechnicalSupportStaff", SqlDbType.NVarChar); TechnicalSupportStaff.Value = model.TechnicalSupportStaff;
            SqlParameter FDataLineType = new SqlParameter("FDataLineType", SqlDbType.NVarChar); FDataLineType.Value = model.FDataLineType;
            SqlParameter FEncryptionTechnology = new SqlParameter("FEncryptionTechnology", SqlDbType.NVarChar); FEncryptionTechnology.Value = model.FEncryptionTechnology;
            SqlParameter FBandWidth = new SqlParameter("FBandWidth", SqlDbType.NVarChar); FBandWidth.Value = model.FBandWidth;
            SqlParameter FGreenOperator = new SqlParameter("FGreenOperator", SqlDbType.NVarChar); FGreenOperator.Value = model.FGreenOperator;
            SqlParameter FTechnicalSupportStaff = new SqlParameter("FTechnicalSupportStaff", SqlDbType.NVarChar); FTechnicalSupportStaff.Value = model.FTechnicalSupportStaff;
            SqlParameter ServerIP = new SqlParameter("ServerIP", SqlDbType.NVarChar); ServerIP.Value = model.ServerIP;
            SqlParameter ServerPort = new SqlParameter("ServerPort", SqlDbType.NVarChar); ServerPort.Value = model.ServerPort;
            SqlParameter ServerMachineName = new SqlParameter("ServerMachineName", SqlDbType.NVarChar); ServerMachineName.Value = model.ServerMachineName;
            SqlParameter ServerLogo = new SqlParameter("ServerLogo", SqlDbType.NVarChar); ServerLogo.Value = model.ServerLogo;
            SqlParameter ServerUse = new SqlParameter("ServerUse", SqlDbType.NVarChar); ServerUse.Value = model.ServerUse;
            SqlParameter ServerRemark = new SqlParameter("ServerRemark", SqlDbType.NVarChar); ServerRemark.Value = model.ServerRemark;
            SqlParameter StorageIP = new SqlParameter("StorageIP", SqlDbType.NVarChar); StorageIP.Value = model.StorageIP;
            SqlParameter StoragePort = new SqlParameter("StoragePort", SqlDbType.NVarChar); StoragePort.Value = model.StoragePort;
            SqlParameter StorageMachineName = new SqlParameter("StorageMachineName", SqlDbType.NVarChar); StorageMachineName.Value = model.StorageMachineName;
            SqlParameter StorageLogo = new SqlParameter("StorageLogo", SqlDbType.NVarChar); StorageLogo.Value = model.StorageLogo;
            SqlParameter StorageUse = new SqlParameter("StorageUse", SqlDbType.NVarChar); StorageUse.Value = model.StorageUse;
            SqlParameter StorageRemark = new SqlParameter("StorageRemark", SqlDbType.NVarChar); StorageRemark.Value = model.StorageRemark;
            SqlParameter EquipmentID = new SqlParameter("EquipmentID", SqlDbType.NVarChar); EquipmentID.Value = model.EquipmentID;
            SqlParameter EquipConfig = new SqlParameter("EquipConfig", SqlDbType.NVarChar); EquipConfig.Value = model.EquipConfig;
            SqlParameter Topological = new SqlParameter("Topological", SqlDbType.NVarChar); Topological.Value = model.Topological;
            SqlParameter RouterConfig = new SqlParameter("RouterConfig", SqlDbType.NVarChar); RouterConfig.Value = model.RouterConfig;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { DataLineStartP, DataLineEndP, Type, EncryptionTechnology, BandWidth, GreenOperator, TechnicalSupportStaff, FDataLineType, FEncryptionTechnology, FBandWidth, FGreenOperator, FTechnicalSupportStaff, ServerIP, ServerPort, ServerMachineName, ServerLogo, ServerUse, ServerRemark, StorageIP, StoragePort, StorageMachineName, StorageLogo, StorageUse, StorageRemark, EquipmentID, EquipConfig, Topological, RouterConfig }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.InternetInformation model)
        {
            string strSql = "update InternetInformation set DataLineStartP=@DataLineStartP, DataLineEndP=@DataLineEndP, Type=@Type, EncryptionTechnology=@EncryptionTechnology, BandWidth=@BandWidth, GreenOperator=@GreenOperator, TechnicalSupportStaff=@TechnicalSupportStaff, FDataLineType=@FDataLineType, FEncryptionTechnology=@FEncryptionTechnology, FBandWidth=@FBandWidth, FGreenOperator=@FGreenOperator, FTechnicalSupportStaff=@FTechnicalSupportStaff, ServerIP=@ServerIP, ServerPort=@ServerPort, ServerMachineName=@ServerMachineName, ServerLogo=@ServerLogo, ServerUse=@ServerUse, ServerRemark=@ServerRemark, StorageIP=@StorageIP, StoragePort=@StoragePort, StorageMachineName=@StorageMachineName, StorageLogo=@StorageLogo, StorageUse=@StorageUse, StorageRemark=@StorageRemark, EquipmentID=@EquipmentID, EquipConfig=@EquipConfig, Topological=@Topological, RouterConfig=@RouterConfig  where ID = " + model.ID.ToString();
            SqlParameter DataLineStartP = new SqlParameter("DataLineStartP", SqlDbType.NVarChar); DataLineStartP.Value = model.DataLineStartP;
            SqlParameter DataLineEndP = new SqlParameter("DataLineEndP", SqlDbType.NVarChar); DataLineEndP.Value = model.DataLineEndP;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter EncryptionTechnology = new SqlParameter("EncryptionTechnology", SqlDbType.NVarChar); EncryptionTechnology.Value = model.EncryptionTechnology;
            SqlParameter BandWidth = new SqlParameter("BandWidth", SqlDbType.NVarChar); BandWidth.Value = model.BandWidth;
            SqlParameter GreenOperator = new SqlParameter("GreenOperator", SqlDbType.NVarChar); GreenOperator.Value = model.GreenOperator;
            SqlParameter TechnicalSupportStaff = new SqlParameter("TechnicalSupportStaff", SqlDbType.NVarChar); TechnicalSupportStaff.Value = model.TechnicalSupportStaff;
            SqlParameter FDataLineType = new SqlParameter("FDataLineType", SqlDbType.NVarChar); FDataLineType.Value = model.FDataLineType;
            SqlParameter FEncryptionTechnology = new SqlParameter("FEncryptionTechnology", SqlDbType.NVarChar); FEncryptionTechnology.Value = model.FEncryptionTechnology;
            SqlParameter FBandWidth = new SqlParameter("FBandWidth", SqlDbType.NVarChar); FBandWidth.Value = model.FBandWidth;
            SqlParameter FGreenOperator = new SqlParameter("FGreenOperator", SqlDbType.NVarChar); FGreenOperator.Value = model.FGreenOperator;
            SqlParameter FTechnicalSupportStaff = new SqlParameter("FTechnicalSupportStaff", SqlDbType.NVarChar); FTechnicalSupportStaff.Value = model.FTechnicalSupportStaff;
            SqlParameter ServerIP = new SqlParameter("ServerIP", SqlDbType.NVarChar); ServerIP.Value = model.ServerIP;
            SqlParameter ServerPort = new SqlParameter("ServerPort", SqlDbType.NVarChar); ServerPort.Value = model.ServerPort;
            SqlParameter ServerMachineName = new SqlParameter("ServerMachineName", SqlDbType.NVarChar); ServerMachineName.Value = model.ServerMachineName;
            SqlParameter ServerLogo = new SqlParameter("ServerLogo", SqlDbType.NVarChar); ServerLogo.Value = model.ServerLogo;
            SqlParameter ServerUse = new SqlParameter("ServerUse", SqlDbType.NVarChar); ServerUse.Value = model.ServerUse;
            SqlParameter ServerRemark = new SqlParameter("ServerRemark", SqlDbType.NVarChar); ServerRemark.Value = model.ServerRemark;
            SqlParameter StorageIP = new SqlParameter("StorageIP", SqlDbType.NVarChar); StorageIP.Value = model.StorageIP;
            SqlParameter StoragePort = new SqlParameter("StoragePort", SqlDbType.NVarChar); StoragePort.Value = model.StoragePort;
            SqlParameter StorageMachineName = new SqlParameter("StorageMachineName", SqlDbType.NVarChar); StorageMachineName.Value = model.StorageMachineName;
            SqlParameter StorageLogo = new SqlParameter("StorageLogo", SqlDbType.NVarChar); StorageLogo.Value = model.StorageLogo;
            SqlParameter StorageUse = new SqlParameter("StorageUse", SqlDbType.NVarChar); StorageUse.Value = model.StorageUse;
            SqlParameter StorageRemark = new SqlParameter("StorageRemark", SqlDbType.NVarChar); StorageRemark.Value = model.StorageRemark;
            SqlParameter EquipmentID = new SqlParameter("EquipmentID", SqlDbType.NVarChar); EquipmentID.Value = model.EquipmentID;
            SqlParameter EquipConfig = new SqlParameter("EquipConfig", SqlDbType.NVarChar); EquipConfig.Value = model.EquipConfig;
            SqlParameter Topological = new SqlParameter("Topological", SqlDbType.NVarChar); Topological.Value = model.Topological;
            SqlParameter RouterConfig = new SqlParameter("RouterConfig", SqlDbType.NVarChar); RouterConfig.Value = model.RouterConfig;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { DataLineStartP, DataLineEndP, Type, EncryptionTechnology, BandWidth, GreenOperator, TechnicalSupportStaff, FDataLineType, FEncryptionTechnology, FBandWidth, FGreenOperator, FTechnicalSupportStaff, ServerIP, ServerPort, ServerMachineName, ServerLogo, ServerUse, ServerRemark, StorageIP, StoragePort, StorageMachineName, StorageLogo, StorageUse, StorageRemark, EquipmentID, EquipConfig, Topological, RouterConfig }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象根据设备名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.InternetInformation GetModel(string Type)
        {
            string strSql = "select * from InternetInformation where Type = '" + Type + "'";
            Model.InternetInformation model = new Model.InternetInformation();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.Type = Type;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.DataLineStartP = Convert.ToString(ds.Tables[0].Rows[0]["DataLineStartP"]);
                model.DataLineEndP = Convert.ToString(ds.Tables[0].Rows[0]["DataLineEndP"]);
                model.EncryptionTechnology = Convert.ToString(ds.Tables[0].Rows[0]["EncryptionTechnology"]);
                model.BandWidth = Convert.ToString(ds.Tables[0].Rows[0]["BandWidth"]);
                model.GreenOperator = Convert.ToString(ds.Tables[0].Rows[0]["GreenOperator"]);
                model.TechnicalSupportStaff = Convert.ToString(ds.Tables[0].Rows[0]["TechnicalSupportStaff"]);
                model.FDataLineType = Convert.ToString(ds.Tables[0].Rows[0]["FDataLineType"]);
                model.FEncryptionTechnology = Convert.ToString(ds.Tables[0].Rows[0]["FEncryptionTechnology"]);
                model.FBandWidth = Convert.ToString(ds.Tables[0].Rows[0]["FBandWidth"]);
                model.FGreenOperator = Convert.ToString(ds.Tables[0].Rows[0]["FGreenOperator"]);
                model.FTechnicalSupportStaff = Convert.ToString(ds.Tables[0].Rows[0]["FTechnicalSupportStaff"]);
                model.ServerIP = Convert.ToString(ds.Tables[0].Rows[0]["ServerIP"]);
                model.ServerPort = Convert.ToString(ds.Tables[0].Rows[0]["ServerPort"]);
                model.ServerMachineName = Convert.ToString(ds.Tables[0].Rows[0]["ServerMachineName"]);
                model.ServerLogo = Convert.ToString(ds.Tables[0].Rows[0]["ServerLogo"]);
                model.ServerUse = Convert.ToString(ds.Tables[0].Rows[0]["ServerUse"]);
                model.ServerRemark = Convert.ToString(ds.Tables[0].Rows[0]["ServerRemark"]);
                model.StorageIP = Convert.ToString(ds.Tables[0].Rows[0]["StorageIP"]);
                model.StoragePort = Convert.ToString(ds.Tables[0].Rows[0]["StoragePort"]);
                model.StorageMachineName = Convert.ToString(ds.Tables[0].Rows[0]["StorageMachineName"]);
                model.StorageLogo = Convert.ToString(ds.Tables[0].Rows[0]["StorageLogo"]);
                model.StorageUse = Convert.ToString(ds.Tables[0].Rows[0]["StorageUse"]);
                model.StorageRemark = Convert.ToString(ds.Tables[0].Rows[0]["StorageRemark"]);
                model.EquipmentID = Convert.ToString(ds.Tables[0].Rows[0]["EquipmentID"]);
                model.EquipConfig = Convert.ToString(ds.Tables[0].Rows[0]["EquipConfig"]);
                model.Topological = Convert.ToString(ds.Tables[0].Rows[0]["Topological"]);
                model.RouterConfig = Convert.ToString(ds.Tables[0].Rows[0]["RouterConfig"]);
              
               


                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.InternetInformation GetModel(int ID)
        {
            string strSql = "select * from InternetInformation where ID = '" + ID + "'";
            Model.InternetInformation model = new Model.InternetInformation();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                model.DataLineStartP = Convert.ToString(ds.Tables[0].Rows[0]["DataLineStartP"]);
                model.DataLineEndP = Convert.ToString(ds.Tables[0].Rows[0]["DataLineEndP"]);
                model.EncryptionTechnology = Convert.ToString(ds.Tables[0].Rows[0]["EncryptionTechnology"]);
                model.BandWidth = Convert.ToString(ds.Tables[0].Rows[0]["BandWidth"]);
                model.GreenOperator = Convert.ToString(ds.Tables[0].Rows[0]["GreenOperator"]);
                model.TechnicalSupportStaff = Convert.ToString(ds.Tables[0].Rows[0]["TechnicalSupportStaff"]);
                model.FDataLineType = Convert.ToString(ds.Tables[0].Rows[0]["FDataLineType"]);
                model.FEncryptionTechnology = Convert.ToString(ds.Tables[0].Rows[0]["FEncryptionTechnology"]);
                model.FBandWidth = Convert.ToString(ds.Tables[0].Rows[0]["FBandWidth"]);
                model.FGreenOperator = Convert.ToString(ds.Tables[0].Rows[0]["FGreenOperator"]);
                model.FTechnicalSupportStaff = Convert.ToString(ds.Tables[0].Rows[0]["FTechnicalSupportStaff"]);
                model.ServerIP = Convert.ToString(ds.Tables[0].Rows[0]["ServerIP"]);
                model.ServerPort = Convert.ToString(ds.Tables[0].Rows[0]["ServerPort"]);
                model.ServerMachineName = Convert.ToString(ds.Tables[0].Rows[0]["ServerMachineName"]);
                model.ServerLogo = Convert.ToString(ds.Tables[0].Rows[0]["ServerLogo"]);
                model.ServerUse = Convert.ToString(ds.Tables[0].Rows[0]["ServerUse"]);
                model.ServerRemark = Convert.ToString(ds.Tables[0].Rows[0]["ServerRemark"]);
                model.StorageIP = Convert.ToString(ds.Tables[0].Rows[0]["StorageIP"]);
                model.StoragePort = Convert.ToString(ds.Tables[0].Rows[0]["StoragePort"]);
                model.StorageMachineName = Convert.ToString(ds.Tables[0].Rows[0]["StorageMachineName"]);
                model.StorageLogo = Convert.ToString(ds.Tables[0].Rows[0]["StorageLogo"]);
                model.StorageUse = Convert.ToString(ds.Tables[0].Rows[0]["StorageUse"]);
                model.StorageRemark = Convert.ToString(ds.Tables[0].Rows[0]["StorageRemark"]);
                model.EquipmentID = Convert.ToString(ds.Tables[0].Rows[0]["EquipmentID"]);
                model.EquipConfig = Convert.ToString(ds.Tables[0].Rows[0]["EquipConfig"]);
                model.Topological = Convert.ToString(ds.Tables[0].Rows[0]["Topological"]);
                model.RouterConfig = Convert.ToString(ds.Tables[0].Rows[0]["RouterConfig"]);




                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据（根据Type）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string Type)
        {
            string strSql = "delete from InternetInformation where Type ='" + Type + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int id)
        {
            string strSql = "delete from InternetInformation where ID ='" + id + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from InternetInformation where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetBriefList(int offset, int limit, string Type = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM InternetInformation w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InternetInformation where Type like '%" + Type + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string Type = "")
        {
            string strSql = "select count(*) from InternetInformation where Type like '%" + Type + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
