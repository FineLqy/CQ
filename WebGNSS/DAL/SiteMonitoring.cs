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
    public class SiteMonitoring
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from SiteMonitoring where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 站点监视是否存在
        /// </summary>
        /// <param name="StationOName"></param>
        /// <returns></returns>
        public static bool Exists(string StationOName)
        {
            string strSql = "select count(*) from SiteMonitoring where StationOName='" + StationOName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个站点监视
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.SiteMonitoring model)
        {

            string strSql = "insert into SiteMonitoring(StationOName,SatelliteType,Numbering,Track,Quantity,Angle,Time,Ratio,StorageEable,DesignCapacity,UsedstorageSpace,AvailablestorageSpace,ReceiverTemperature,ReceiverVoltage,ReceiverElectricity,ReceiverCPU,WeatherTemperature,WeatherVoltage,WeatherElectricity,WeatherCPU,UPSTemperature,UPSVoltage,UPSElectricity,UPSCPU) values(@StationOName,@SatelliteType,@Numbering,@Track,@Quantity,@Angle,@Time,@Ratio,@StorageEable,@DesignCapacity,@UsedstorageSpace,@AvailablestorageSpace,@ReceiverTemperature,@ReceiverVoltage,@ReceiverElectricity,@ReceiverCPU,@WeatherTemperature,@WeatherVoltage,@WeatherElectricity,@WeatherCPU,@UPSTemperature,@UPSVoltage,@UPSElectricity,@UPSCPU)";
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter SatelliteType = new SqlParameter("SatelliteType", SqlDbType.NVarChar); SatelliteType.Value = model.SatelliteType;
            SqlParameter Numbering = new SqlParameter("Numbering", SqlDbType.NVarChar); Numbering.Value = model.Numbering;
            SqlParameter Track = new SqlParameter("Track", SqlDbType.NVarChar); Track.Value = model.Track;
            SqlParameter Quantity = new SqlParameter("Quantity", SqlDbType.NVarChar); Quantity.Value = model.Quantity;
            SqlParameter Angle = new SqlParameter("Angle", SqlDbType.NVarChar); Angle.Value = model.Angle;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
            SqlParameter Ratio = new SqlParameter("Ratio", SqlDbType.NVarChar); Ratio.Value = model.Ratio;
            SqlParameter StorageEable = new SqlParameter("StorageEable", SqlDbType.Int); StorageEable.Value = model.StorageEable;
            SqlParameter DesignCapacity = new SqlParameter("DesignCapacity", SqlDbType.NVarChar); DesignCapacity.Value = model.DesignCapacity;
            SqlParameter UsedstorageSpace = new SqlParameter("UsedstorageSpace", SqlDbType.NVarChar); UsedstorageSpace.Value = model.UsedstorageSpace;
            SqlParameter AvailablestorageSpace = new SqlParameter("AvailablestorageSpace", SqlDbType.NVarChar); AvailablestorageSpace.Value = model.AvailablestorageSpace;
            SqlParameter ReceiverTemperature = new SqlParameter("ReceiverTemperature", SqlDbType.NVarChar); ReceiverTemperature.Value = model.ReceiverTemperature;
            SqlParameter ReceiverVoltage = new SqlParameter("ReceiverVoltage", SqlDbType.NVarChar); ReceiverVoltage.Value = model.ReceiverVoltage;
            SqlParameter ReceiverElectricity = new SqlParameter("ReceiverElectricity", SqlDbType.NVarChar); ReceiverElectricity.Value = model.ReceiverElectricity;
            SqlParameter ReceiverCPU = new SqlParameter("ReceiverCPU", SqlDbType.NVarChar); ReceiverCPU.Value = model.ReceiverCPU;
            SqlParameter WeatherTemperature = new SqlParameter("WeatherTemperature", SqlDbType.NVarChar); WeatherTemperature.Value = model.WeatherTemperature;
            SqlParameter WeatherVoltage = new SqlParameter("WeatherVoltage", SqlDbType.NVarChar); WeatherVoltage.Value = model.WeatherVoltage;
            SqlParameter WeatherElectricity = new SqlParameter("WeatherElectricity", SqlDbType.NVarChar); WeatherElectricity.Value = model.WeatherElectricity;
            SqlParameter WeatherCPU = new SqlParameter("WeatherCPU", SqlDbType.NVarChar); WeatherCPU.Value = model.WeatherCPU;
            SqlParameter UPSTemperature = new SqlParameter("UPSTemperature", SqlDbType.NVarChar); UPSTemperature.Value = model.UPSTemperature;
            SqlParameter UPSVoltage = new SqlParameter("UPSVoltage", SqlDbType.NVarChar); UPSVoltage.Value = model.UPSVoltage;
            SqlParameter UPSElectricity = new SqlParameter("UPSElectricity", SqlDbType.NVarChar); UPSElectricity.Value = model.UPSElectricity;
            SqlParameter UPSCPU = new SqlParameter("UPSCPU", SqlDbType.NVarChar); UPSCPU.Value = model.UPSCPU;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationOName, SatelliteType, Numbering, Track, Quantity, Angle, Time, Ratio, StorageEable, DesignCapacity, UsedstorageSpace, AvailablestorageSpace, ReceiverTemperature, ReceiverVoltage, ReceiverElectricity, ReceiverCPU, WeatherTemperature, WeatherVoltage, WeatherElectricity, WeatherCPU, UPSTemperature, UPSVoltage, UPSElectricity, UPSCPU }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.SiteMonitoring model)
        {
            string strSql = "update SiteMonitoring set StationOName=@StationOName, SatelliteType=@SatelliteType, Numbering=@Numbering, Track=@Track, Quantity=@Quantity, Angle=@Angle, Time=@Time, Ratio=@Ratio, StorageEable=@StorageEable, DesignCapacity=@DesignCapacity, UsedstorageSpace=@UsedstorageSpace, AvailablestorageSpace=@AvailablestorageSpace, ReceiverTemperature=@ReceiverTemperature, ReceiverVoltage=@ReceiverVoltage, ReceiverElectricity=@ReceiverElectricity, ReceiverCPU=@ReceiverCPU, WeatherTemperature=@WeatherTemperature, WeatherVoltage=@WeatherVoltage, WeatherElectricity=@WeatherElectricity, WeatherCPU=@WeatherCPU, UPSTemperature=@UPSTemperature, UPSVoltage=@UPSVoltage, UPSElectricity=@UPSElectricity, UPSCPU=@UPSCPU  where ID = " + model.ID.ToString();
            SqlParameter StationOName = new SqlParameter("StationOName", SqlDbType.NVarChar); StationOName.Value = model.StationOName;
            SqlParameter SatelliteType = new SqlParameter("SatelliteType", SqlDbType.NVarChar); SatelliteType.Value = model.SatelliteType;
            SqlParameter Numbering = new SqlParameter("Numbering", SqlDbType.NVarChar); Numbering.Value = model.Numbering;
            SqlParameter Track = new SqlParameter("Track", SqlDbType.NVarChar); Track.Value = model.Track;
            SqlParameter Quantity = new SqlParameter("Quantity", SqlDbType.NVarChar); Quantity.Value = model.Quantity;
            SqlParameter Angle = new SqlParameter("Angle", SqlDbType.NVarChar); Angle.Value = model.Angle;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
            SqlParameter Ratio = new SqlParameter("Ratio", SqlDbType.NVarChar); Ratio.Value = model.Ratio;
            SqlParameter StorageEable = new SqlParameter("StorageEable", SqlDbType.Int); StorageEable.Value = model.StorageEable;
            SqlParameter DesignCapacity = new SqlParameter("DesignCapacity", SqlDbType.NVarChar); DesignCapacity.Value = model.DesignCapacity;
            SqlParameter UsedstorageSpace = new SqlParameter("UsedstorageSpace", SqlDbType.NVarChar); UsedstorageSpace.Value = model.UsedstorageSpace;
            SqlParameter AvailablestorageSpace = new SqlParameter("AvailablestorageSpace", SqlDbType.NVarChar); AvailablestorageSpace.Value = model.AvailablestorageSpace;
            SqlParameter ReceiverTemperature = new SqlParameter("ReceiverTemperature", SqlDbType.NVarChar); ReceiverTemperature.Value = model.ReceiverTemperature;
            SqlParameter ReceiverVoltage = new SqlParameter("ReceiverVoltage", SqlDbType.NVarChar); ReceiverVoltage.Value = model.ReceiverVoltage;
            SqlParameter ReceiverElectricity = new SqlParameter("ReceiverElectricity", SqlDbType.NVarChar); ReceiverElectricity.Value = model.ReceiverElectricity;
            SqlParameter ReceiverCPU = new SqlParameter("ReceiverCPU", SqlDbType.NVarChar); ReceiverCPU.Value = model.ReceiverCPU;
            SqlParameter WeatherTemperature = new SqlParameter("WeatherTemperature", SqlDbType.NVarChar); WeatherTemperature.Value = model.WeatherTemperature;
            SqlParameter WeatherVoltage = new SqlParameter("WeatherVoltage", SqlDbType.NVarChar); WeatherVoltage.Value = model.WeatherVoltage;
            SqlParameter WeatherElectricity = new SqlParameter("WeatherElectricity", SqlDbType.NVarChar); WeatherElectricity.Value = model.WeatherElectricity;
            SqlParameter WeatherCPU = new SqlParameter("WeatherCPU", SqlDbType.NVarChar); WeatherCPU.Value = model.WeatherCPU;
            SqlParameter UPSTemperature = new SqlParameter("UPSTemperature", SqlDbType.NVarChar); UPSTemperature.Value = model.UPSTemperature;
            SqlParameter UPSVoltage = new SqlParameter("UPSVoltage", SqlDbType.NVarChar); UPSVoltage.Value = model.UPSVoltage;
            SqlParameter UPSElectricity = new SqlParameter("UPSElectricity", SqlDbType.NVarChar); UPSElectricity.Value = model.UPSElectricity;
            SqlParameter UPSCPU = new SqlParameter("UPSCPU", SqlDbType.NVarChar); UPSCPU.Value = model.UPSCPU;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { StationOName, SatelliteType, Numbering, Track, Quantity, Angle, Time, Ratio, StorageEable, DesignCapacity, UsedstorageSpace, AvailablestorageSpace, ReceiverTemperature, ReceiverVoltage, ReceiverElectricity, ReceiverCPU, WeatherTemperature, WeatherVoltage, WeatherElectricity, WeatherCPU, UPSTemperature, UPSVoltage, UPSElectricity, UPSCPU }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.SiteMonitoring GetModel(string StationOName)
        {
            string strSql = "select * from SiteMonitoring where StationOName = '" + StationOName + "'";
            Model.SiteMonitoring model = new Model.SiteMonitoring();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.StationOName = StationOName;
            if (ds.Tables[0].Rows.Count > 0)
            { 
                model.SatelliteType = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteType"]);
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Numbering = Convert.ToString(ds.Tables[0].Rows[0]["Numbering"]);
                model.Track = Convert.ToString(ds.Tables[0].Rows[0]["Track"]);
                model.Quantity = Convert.ToString(ds.Tables[0].Rows[0]["Quantity"]);
                model.Angle = Convert.ToString(ds.Tables[0].Rows[0]["Angle"]);
                model.Time = Convert.ToDateTime(ds.Tables[0].Rows[0]["Time"]);
                model.Ratio = Convert.ToString(ds.Tables[0].Rows[0]["Ratio"]);
                model.StorageEable = Convert.ToInt32(ds.Tables[0].Rows[0]["StorageEable"]);
                model.DesignCapacity = Convert.ToString(ds.Tables[0].Rows[0]["DesignCapacity"]);
                model.UsedstorageSpace = Convert.ToString(ds.Tables[0].Rows[0]["UsedstorageSpace"]);
                model.AvailablestorageSpace = Convert.ToString(ds.Tables[0].Rows[0]["AvailablestorageSpace"]);
                model.ReceiverTemperature = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverTemperature"]);
                model.ReceiverVoltage = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverVoltage"]);
                model.ReceiverElectricity = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverElectricity"]);
                model.ReceiverCPU = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverCPU"]);
                model.WeatherTemperature = Convert.ToString(ds.Tables[0].Rows[0]["WeatherTemperature"]);
                model.WeatherVoltage = Convert.ToString(ds.Tables[0].Rows[0]["WeatherVoltage"]);
                model.WeatherElectricity = Convert.ToString(ds.Tables[0].Rows[0]["WeatherElectricity"]);
                model.WeatherCPU = Convert.ToString(ds.Tables[0].Rows[0]["WeatherCPU"]);
                model.UPSTemperature = Convert.ToString(ds.Tables[0].Rows[0]["UPSTemperature"]);
                model.UPSVoltage = Convert.ToString(ds.Tables[0].Rows[0]["UPSVoltage"]);
                model.UPSElectricity = Convert.ToString(ds.Tables[0].Rows[0]["UPSElectricity"]);
                model.UPSCPU = Convert.ToString(ds.Tables[0].Rows[0]["UPSCPU"]);
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
        public static Model.SiteMonitoring GetModel(int ID)
        {
            string strSql = "select * from SiteMonitoring where ID = " + ID.ToString();
            Model.SiteMonitoring model = new Model.SiteMonitoring();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.StationOName = Convert.ToString(ds.Tables[0].Rows[0]["StationOName"]);   
                model.SatelliteType = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteType"]);            
                model.Numbering = Convert.ToString(ds.Tables[0].Rows[0]["Numbering"]);
                model.Track = Convert.ToString(ds.Tables[0].Rows[0]["Track"]);
                model.Quantity = Convert.ToString(ds.Tables[0].Rows[0]["Quantity"]);
                model.Angle = Convert.ToString(ds.Tables[0].Rows[0]["Angle"]);
                model.Time = Convert.ToDateTime(ds.Tables[0].Rows[0]["Time"]);
                model.Ratio = Convert.ToString(ds.Tables[0].Rows[0]["Ratio"]);
                model.StorageEable = Convert.ToInt32(ds.Tables[0].Rows[0]["StorageEable"]);
                model.DesignCapacity = Convert.ToString(ds.Tables[0].Rows[0]["DesignCapacity"]);
                model.UsedstorageSpace = Convert.ToString(ds.Tables[0].Rows[0]["UsedstorageSpace"]);
                model.AvailablestorageSpace = Convert.ToString(ds.Tables[0].Rows[0]["AvailablestorageSpace"]);
                model.ReceiverTemperature = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverTemperature"]);
                model.ReceiverVoltage = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverVoltage"]);
                model.ReceiverElectricity = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverElectricity"]);
                model.ReceiverCPU = Convert.ToString(ds.Tables[0].Rows[0]["ReceiverCPU"]);
                model.WeatherTemperature = Convert.ToString(ds.Tables[0].Rows[0]["WeatherTemperature"]);
                model.WeatherVoltage = Convert.ToString(ds.Tables[0].Rows[0]["WeatherVoltage"]);
                model.WeatherElectricity = Convert.ToString(ds.Tables[0].Rows[0]["WeatherElectricity"]);
                model.WeatherCPU = Convert.ToString(ds.Tables[0].Rows[0]["WeatherCPU"]);
                model.UPSTemperature = Convert.ToString(ds.Tables[0].Rows[0]["UPSTemperature"]);
                model.UPSVoltage = Convert.ToString(ds.Tables[0].Rows[0]["UPSVoltage"]);
                model.UPSElectricity = Convert.ToString(ds.Tables[0].Rows[0]["UPSElectricity"]);
                model.UPSCPU = Convert.ToString(ds.Tables[0].Rows[0]["UPSCPU"]);
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
            string strSql = "delete from SiteMonitoring where StationOName ='" + StationOName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from SiteMonitoring where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
    }
}
