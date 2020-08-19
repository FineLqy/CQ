using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class FormerCoorSysPars
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        ///// <summary>
        ///// 是否存在
        ///// </summary>
        ///// <param name="YSZBXM"></param>
        ///// <param name="MDZBXM"></param>
        ///// <returns></returns>
        //public static bool Exists(string YSZBXM, string MDZBXM)
        //{
        //    string strSql = "select count(*) from FormerCoorSysPars where YSZBXM='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
        //    return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        //}
        public static bool Add(Model.FormerCoorSysPars model)
        {
            string strSql = "insert into FormerCoorSysPars (YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2,YSRemarkName,MDRemarkName,YSDAlpha,MDDAlpha,CMeridian,ProjElevation,IsFormer,StartTime,EndTime,OriginNorth,OriginEast)values(@YSZBXM, @MDZBXM, @X, @Y, @Z, @aa, @bb, @cc, @m, @YSMajorAxis, @YSe2, @MDMajorAxis, @MDe2,@YSRemarkName,@MDRemarkName,@YSDAlpha,@MDDAlpha,@CMeridian,@ProjElevation,@IsFormer,@StartTime,@EndTime,@OriginNorth,@OriginEast)";
            SqlParameter YSZBXM = new SqlParameter("YSZBXM", SqlDbType.NVarChar); YSZBXM.Value = model.YSZBXM;
            SqlParameter MDZBXM = new SqlParameter("MDZBXM", SqlDbType.NVarChar); MDZBXM.Value = model.MDZBXM;
            SqlParameter X = new SqlParameter("X", SqlDbType.NVarChar); X.Value = AES.AESEncrypt(model.X.ToString());
            SqlParameter Y = new SqlParameter("Y", SqlDbType.NVarChar); Y.Value = AES.AESEncrypt(model.Y.ToString());
            SqlParameter Z = new SqlParameter("Z", SqlDbType.NVarChar); Z.Value = AES.AESEncrypt(model.Z.ToString());
            SqlParameter aa = new SqlParameter("aa", SqlDbType.NVarChar); aa.Value = AES.AESEncrypt(model.aa.ToString());
            SqlParameter bb = new SqlParameter("bb", SqlDbType.NVarChar); bb.Value = AES.AESEncrypt(model.bb.ToString());
            SqlParameter cc = new SqlParameter("cc", SqlDbType.NVarChar); cc.Value = AES.AESEncrypt(model.cc.ToString());
            SqlParameter m = new SqlParameter("m", SqlDbType.NVarChar); m.Value = AES.AESEncrypt(model.m.ToString());
            SqlParameter YSMajorAxis = new SqlParameter("YSMajorAxis", SqlDbType.Float); YSMajorAxis.Value = model.YSMajorAxis;
            SqlParameter YSe2 = new SqlParameter("YSe2", SqlDbType.Float); YSe2.Value = model.YSe2;
            SqlParameter MDMajorAxis = new SqlParameter("MDMajorAxis", SqlDbType.Float); MDMajorAxis.Value = model.MDMajorAxis;
            SqlParameter MDe2 = new SqlParameter("MDe2", SqlDbType.Float); MDe2.Value = model.MDe2;
            SqlParameter YSRemarkName = new SqlParameter("YSRemarkName", SqlDbType.NVarChar); YSRemarkName.Value = model.YSRemarkName;
            SqlParameter MDRemarkName = new SqlParameter("MDRemarkName", SqlDbType.NVarChar); MDRemarkName.Value = model.MDRemarkName;
            SqlParameter YSDAlpha = new SqlParameter("YSDAlpha", SqlDbType.Float); YSDAlpha.Value = model.YSDAlpha;
            SqlParameter MDDAlpha = new SqlParameter("MDDAlpha", SqlDbType.Float); MDDAlpha.Value = model.MDDAlpha;
            SqlParameter CMeridian = new SqlParameter("CMeridian", SqlDbType.NVarChar); CMeridian.Value = AES.AESEncrypt(model.CMeridian.ToString());
            SqlParameter ProjElevation = new SqlParameter("ProjElevation", SqlDbType.NVarChar); ProjElevation.Value = AES.AESEncrypt(model.ProjElevation.ToString());
            SqlParameter IsFormer = new SqlParameter("IsFormer", SqlDbType.Int); IsFormer.Value = model.IsFormer;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            SqlParameter OriginNorth = new SqlParameter("OriginNorth", SqlDbType.NVarChar); OriginNorth.Value = AES.AESEncrypt(model.OriginNorth.ToString());
            SqlParameter OriginEast = new SqlParameter("OriginEast", SqlDbType.NVarChar); OriginEast.Value = AES.AESEncrypt(model.OriginEast.ToString());
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2, YSRemarkName, MDRemarkName, YSDAlpha, MDDAlpha, CMeridian, ProjElevation, IsFormer, StartTime, EndTime, OriginNorth, OriginEast }, connectionString) == 1 ? true : false;
        }

        public static bool Add(Model.OFormerCoorSysPars model)
        {
            string strSql = "insert into FormerCoorSysPars (YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2,YSRemarkName,MDRemarkName,YSDAlpha,MDDAlpha,CMeridian,ProjElevation,IsFormer,StartTime,EndTime,OriginNorth,OriginEast)values(@YSZBXM, @MDZBXM, @X, @Y, @Z, @aa, @bb, @cc, @m, @YSMajorAxis, @YSe2, @MDMajorAxis, @MDe2,@YSRemarkName,@MDRemarkName,@YSDAlpha,@MDDAlpha,@CMeridian,@ProjElevation,@IsFormer,@StartTime,@EndTime,@OriginNorth,@OriginEast)";
            SqlParameter YSZBXM = new SqlParameter("YSZBXM", SqlDbType.NVarChar); YSZBXM.Value = model.YSZBXM;
            SqlParameter MDZBXM = new SqlParameter("MDZBXM", SqlDbType.NVarChar); MDZBXM.Value = model.MDZBXM;
            SqlParameter X = new SqlParameter("X", SqlDbType.NVarChar); X.Value = AES.AESEncrypt(model.X.ToString());
            SqlParameter Y = new SqlParameter("Y", SqlDbType.NVarChar); Y.Value = AES.AESEncrypt(model.Y.ToString());
            SqlParameter Z = new SqlParameter("Z", SqlDbType.NVarChar); Z.Value = AES.AESEncrypt(model.Z.ToString());
            SqlParameter aa = new SqlParameter("aa", SqlDbType.NVarChar); aa.Value = AES.AESEncrypt(model.aa.ToString());
            SqlParameter bb = new SqlParameter("bb", SqlDbType.NVarChar); bb.Value = AES.AESEncrypt(model.bb.ToString());
            SqlParameter cc = new SqlParameter("cc", SqlDbType.NVarChar); cc.Value = AES.AESEncrypt(model.cc.ToString());
            SqlParameter m = new SqlParameter("m", SqlDbType.NVarChar); m.Value = AES.AESEncrypt(model.m.ToString());
            SqlParameter YSMajorAxis = new SqlParameter("YSMajorAxis", SqlDbType.Float); YSMajorAxis.Value = model.YSMajorAxis;
            SqlParameter YSe2 = new SqlParameter("YSe2", SqlDbType.Float); YSe2.Value = model.YSe2;
            SqlParameter MDMajorAxis = new SqlParameter("MDMajorAxis", SqlDbType.Float); MDMajorAxis.Value = model.MDMajorAxis;
            SqlParameter MDe2 = new SqlParameter("MDe2", SqlDbType.Float); MDe2.Value = model.MDe2;
            SqlParameter YSRemarkName = new SqlParameter("YSRemarkName", SqlDbType.NVarChar); YSRemarkName.Value = model.YSRemarkName;
            SqlParameter MDRemarkName = new SqlParameter("MDRemarkName", SqlDbType.NVarChar); MDRemarkName.Value = model.MDRemarkName;
            SqlParameter YSDAlpha = new SqlParameter("YSDAlpha", SqlDbType.Float); YSDAlpha.Value = model.YSDAlpha;
            SqlParameter MDDAlpha = new SqlParameter("MDDAlpha", SqlDbType.Float); MDDAlpha.Value = model.MDDAlpha;
            SqlParameter CMeridian = new SqlParameter("CMeridian", SqlDbType.NVarChar); CMeridian.Value = AES.AESEncrypt(model.CMeridian.ToString());
            SqlParameter ProjElevation = new SqlParameter("ProjElevation", SqlDbType.NVarChar); ProjElevation.Value = AES.AESEncrypt(model.ProjElevation.ToString());
            SqlParameter IsFormer = new SqlParameter("IsFormer", SqlDbType.Int); IsFormer.Value = model.IsFormer;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            SqlParameter OriginNorth = new SqlParameter("OriginNorth", SqlDbType.NVarChar); OriginNorth.Value = AES.AESEncrypt(model.OriginNorth.ToString());
            SqlParameter OriginEast = new SqlParameter("OriginEast", SqlDbType.NVarChar); OriginEast.Value = AES.AESEncrypt(model.OriginEast.ToString());
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2, YSRemarkName, MDRemarkName, YSDAlpha, MDDAlpha, CMeridian, ProjElevation, IsFormer, StartTime, EndTime, OriginNorth, OriginEast }, connectionString) == 1 ? true : false;
        }

        public static bool Update(Model.FormerCoorSysPars model)
        {
            string strSql = "update FormerCoorSysPars set YSZBXM=@YSZBXM, MDZBXM=@MDZBXM, X=@X,Y=@Y,Z=@Z,aa=@aa,bb=@bb,cc=@cc,m=@m,YSMajorAxis=@YSMajorAxis,YSe2=@YSe2,MDMajorAxis=@MDMajorAxis,MDe2=@MDe2, YSRemarkName=@YSRemarkName, MDRemarkName=@MDRemarkName, YSDAlpha=@YSDAlpha, MDDAlpha=@MDDAlpha, CMeridian=@CMeridian, ProjElevation=@ProjElevation, IsFormer=@IsFormer, StartTime=@StartTime, EndTime=@EndTime,OriginNorth=@OriginNorth,OriginEast=@OriginEast where ID = " + model.ID.ToString();
            SqlParameter YSZBXM = new SqlParameter("YSZBXM", SqlDbType.NVarChar); YSZBXM.Value = model.YSZBXM;
            SqlParameter MDZBXM = new SqlParameter("MDZBXM", SqlDbType.NVarChar); MDZBXM.Value = model.MDZBXM;
            SqlParameter X = new SqlParameter("X", SqlDbType.NVarChar); X.Value = AES.AESEncrypt(model.X.ToString());
            SqlParameter Y = new SqlParameter("Y", SqlDbType.NVarChar); Y.Value = AES.AESEncrypt(model.Y.ToString());
            SqlParameter Z = new SqlParameter("Z", SqlDbType.NVarChar); Z.Value = AES.AESEncrypt(model.Z.ToString());
            SqlParameter aa = new SqlParameter("aa", SqlDbType.NVarChar); aa.Value = AES.AESEncrypt(model.aa.ToString());
            SqlParameter bb = new SqlParameter("bb", SqlDbType.NVarChar); bb.Value = AES.AESEncrypt(model.bb.ToString());
            SqlParameter cc = new SqlParameter("cc", SqlDbType.NVarChar); cc.Value = AES.AESEncrypt(model.cc.ToString());
            SqlParameter m = new SqlParameter("m", SqlDbType.NVarChar); m.Value = AES.AESEncrypt(model.m.ToString());
            SqlParameter YSMajorAxis = new SqlParameter("YSMajorAxis", SqlDbType.Float); YSMajorAxis.Value = model.YSMajorAxis;
            SqlParameter YSe2 = new SqlParameter("YSe2", SqlDbType.Float); YSe2.Value = model.YSe2;
            SqlParameter MDMajorAxis = new SqlParameter("MDMajorAxis", SqlDbType.Float); MDMajorAxis.Value = model.MDMajorAxis;
            SqlParameter MDe2 = new SqlParameter("MDe2", SqlDbType.Float); MDe2.Value = model.MDe2;
            SqlParameter YSRemarkName = new SqlParameter("YSRemarkName", SqlDbType.NVarChar); YSRemarkName.Value = model.YSRemarkName;
            SqlParameter MDRemarkName = new SqlParameter("MDRemarkName", SqlDbType.NVarChar); MDRemarkName.Value = model.MDRemarkName;
            SqlParameter YSDAlpha = new SqlParameter("YSDAlpha", SqlDbType.Float); YSDAlpha.Value = model.YSDAlpha;
            SqlParameter MDDAlpha = new SqlParameter("MDDAlpha", SqlDbType.Float); MDDAlpha.Value = model.MDDAlpha;
            SqlParameter CMeridian = new SqlParameter("CMeridian", SqlDbType.NVarChar); CMeridian.Value = AES.AESEncrypt(model.CMeridian.ToString());
            SqlParameter ProjElevation = new SqlParameter("ProjElevation", SqlDbType.NVarChar); ProjElevation.Value = AES.AESEncrypt(model.ProjElevation.ToString());
            SqlParameter IsFormer = new SqlParameter("IsFormer", SqlDbType.Int); IsFormer.Value = model.IsFormer;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            SqlParameter OriginNorth = new SqlParameter("OriginNorth", SqlDbType.NVarChar); OriginNorth.Value = AES.AESEncrypt(model.OriginNorth.ToString());
            SqlParameter OriginEast = new SqlParameter("OriginEast", SqlDbType.NVarChar); OriginEast.Value = AES.AESEncrypt(model.OriginEast.ToString());
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2, YSRemarkName, MDRemarkName, YSDAlpha, MDDAlpha, CMeridian, ProjElevation, IsFormer, StartTime, EndTime, OriginNorth, OriginEast }, connectionString) == 1 ? true : false;
        }

        public static bool Update(Model.OFormerCoorSysPars model)
        {
            string strSql = "update FormerCoorSysPars set YSZBXM=@YSZBXM, MDZBXM=@MDZBXM, X=@X,Y=@Y,Z=@Z,aa=@aa,bb=@bb,cc=@cc,m=@m,YSMajorAxis=@YSMajorAxis,YSe2=@YSe2,MDMajorAxis=@MDMajorAxis,MDe2=@MDe2, YSRemarkName=@YSRemarkName, MDRemarkName=@MDRemarkName, YSDAlpha=@YSDAlpha, MDDAlpha=@MDDAlpha, CMeridian=@CMeridian, ProjElevation=@ProjElevation, IsFormer=@IsFormer, StartTime=@StartTime, EndTime=@EndTime,OriginNorth=@OriginNorth,OriginEast=@OriginEast where ID = " + model.ID.ToString();
            SqlParameter YSZBXM = new SqlParameter("YSZBXM", SqlDbType.NVarChar); YSZBXM.Value = model.YSZBXM;
            SqlParameter MDZBXM = new SqlParameter("MDZBXM", SqlDbType.NVarChar); MDZBXM.Value = model.MDZBXM;
            SqlParameter X = new SqlParameter("X", SqlDbType.NVarChar); X.Value = AES.AESEncrypt(model.X.ToString());
            SqlParameter Y = new SqlParameter("Y", SqlDbType.NVarChar); Y.Value = AES.AESEncrypt(model.Y.ToString());
            SqlParameter Z = new SqlParameter("Z", SqlDbType.NVarChar); Z.Value = AES.AESEncrypt(model.Z.ToString());
            SqlParameter aa = new SqlParameter("aa", SqlDbType.NVarChar); aa.Value = AES.AESEncrypt(model.aa.ToString());
            SqlParameter bb = new SqlParameter("bb", SqlDbType.NVarChar); bb.Value = AES.AESEncrypt(model.bb.ToString());
            SqlParameter cc = new SqlParameter("cc", SqlDbType.NVarChar); cc.Value = AES.AESEncrypt(model.cc.ToString());
            SqlParameter m = new SqlParameter("m", SqlDbType.NVarChar); m.Value = AES.AESEncrypt(model.m.ToString());
            SqlParameter YSMajorAxis = new SqlParameter("YSMajorAxis", SqlDbType.Float); YSMajorAxis.Value = model.YSMajorAxis;
            SqlParameter YSe2 = new SqlParameter("YSe2", SqlDbType.Float); YSe2.Value = model.YSe2;
            SqlParameter MDMajorAxis = new SqlParameter("MDMajorAxis", SqlDbType.Float); MDMajorAxis.Value = model.MDMajorAxis;
            SqlParameter MDe2 = new SqlParameter("MDe2", SqlDbType.Float); MDe2.Value = model.MDe2;
            SqlParameter YSRemarkName = new SqlParameter("YSRemarkName", SqlDbType.NVarChar); YSRemarkName.Value = model.YSRemarkName;
            SqlParameter MDRemarkName = new SqlParameter("MDRemarkName", SqlDbType.NVarChar); MDRemarkName.Value = model.MDRemarkName;
            SqlParameter YSDAlpha = new SqlParameter("YSDAlpha", SqlDbType.Float); YSDAlpha.Value = model.YSDAlpha;
            SqlParameter MDDAlpha = new SqlParameter("MDDAlpha", SqlDbType.Float); MDDAlpha.Value = model.MDDAlpha;
            SqlParameter CMeridian = new SqlParameter("CMeridian", SqlDbType.NVarChar); CMeridian.Value = AES.AESEncrypt(model.CMeridian.ToString());
            SqlParameter ProjElevation = new SqlParameter("ProjElevation", SqlDbType.NVarChar); ProjElevation.Value = AES.AESEncrypt(model.ProjElevation.ToString());
            SqlParameter IsFormer = new SqlParameter("IsFormer", SqlDbType.Int); IsFormer.Value = model.IsFormer;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            SqlParameter OriginNorth = new SqlParameter("OriginNorth", SqlDbType.NVarChar); OriginNorth.Value = AES.AESEncrypt(model.OriginNorth.ToString());
            SqlParameter OriginEast = new SqlParameter("OriginEast", SqlDbType.NVarChar); OriginEast.Value = AES.AESEncrypt(model.OriginEast.ToString());
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2, YSRemarkName, MDRemarkName, YSDAlpha, MDDAlpha, CMeridian, ProjElevation, IsFormer, StartTime, EndTime, OriginNorth, OriginEast }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 根据所处的时间提供参数
        /// </summary>
        /// <param name="YSZBXM"></param>
        /// <param name="MDZBXM"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static Model.OFormerCoorSysPars GetModel(string YSZBXM, string MDZBXM,DateTime Time)
        {
            string strSql = "select * from FormerCoorSysPars where YSZBXM ='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.OFormerCoorSysPars model = new Model.OFormerCoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            int Rindex = 0;
            //增加判断内容
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["IsFormer"].ToString() == "0")//当前正在使用的参数
                {
                    DateTime StartTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]);
                    if (Time > StartTime)
                    {
                        Rindex = i;
                        break;
                    }
                }
                else//曾用参数
                {
                    DateTime StartTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]);
                    DateTime EndTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]);
                    if (Time > StartTime && Time < EndTime)
                    {
                        Rindex = i;
                        break;
                    }
                }
            }
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[Rindex]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[Rindex]["YSZBXM"]);
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[Rindex]["MDZBXM"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["m"].ToString()));
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[Rindex]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[Rindex]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSDAlpha"]);
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDDAlpha"]);
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["ProjElevation"].ToString()));
                model.IsFormer = Convert.ToInt32(ds.Tables[0].Rows[Rindex]["IsFormer"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[Rindex]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[Rindex]["EndTime"]);
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["OriginEast"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["OriginNorth"].ToString()));
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据所处的时间提供真参数
        /// </summary>
        /// <param name="YSZBXM"></param>
        /// <param name="MDZBXM"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static Model.OFormerCoorSysPars GetOModel(string YSZBXM, string MDZBXM, DateTime Time)
        {
            string strSql = "select * from FormerCoorSysPars where YSZBXM ='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.OFormerCoorSysPars model = new Model.OFormerCoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            int Rindex = 0;
            //增加判断内容
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["IsFormer"].ToString() == "0")//当前正在使用的参数
                {
                    DateTime StartTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]);
                    if (Time > StartTime)
                    {
                        Rindex = i;
                        break;
                    }
                }
                else//曾用参数
                {
                    DateTime StartTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]);
                    DateTime EndTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]);
                    if (Time > StartTime && Time < EndTime)
                    {
                        Rindex = i;
                        break;
                    }
                }
            }
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[Rindex]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[Rindex]["YSZBXM"]);
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[Rindex]["MDZBXM"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["m"].ToString()));
                model.X = Math.Round(model.X - 243243.24, 4);
                model.Y = Math.Round(model.Y - 1983435.23, 4);
                model.Z = Math.Round(model.Z + 1233234.12, 4);
                model.aa = Math.Round(model.aa - 76755.99, 10);
                model.bb = Math.Round(model.bb + 4564543.78, 10);
                model.cc = Math.Round(model.cc + 321907.65, 10);
                model.m = Math.Round(model.m - 432487.123, 11);
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[Rindex]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[Rindex]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSDAlpha"]);
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDDAlpha"]);
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["ProjElevation"].ToString()));
                model.IsFormer = Convert.ToInt32(ds.Tables[0].Rows[Rindex]["IsFormer"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[Rindex]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[Rindex]["EndTime"]);
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["OriginEast"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["OriginNorth"].ToString()));
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据所处的时间提供真参数，适用于何冰写的坐标转换程序
        /// </summary>
        /// <param name="YSZBXM"></param>
        /// <param name="MDZBXM"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static Model.OFormerCoorSysPars GetHBModel(string YSZBXM, string MDZBXM, DateTime Time)
        {
            string strSql = "select * from FormerCoorSysPars where YSZBXM ='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.OFormerCoorSysPars model = new Model.OFormerCoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            int Rindex = -1;
            //增加判断内容
            if (YSZBXM == "WGS84")
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["IsFormer"].ToString() == "0")//当前正在使用的参数
                    {
                            Rindex = i;
                            break;
                        
                    }
                }
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["IsFormer"].ToString() == "0")//当前正在使用的参数
                    {
                        DateTime StartTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]);
                        if (Time > StartTime)
                        {
                            Rindex = i;
                            break;
                        }
                    }
                    else//曾用参数
                    {
                        DateTime StartTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]);
                        DateTime EndTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]);
                        if (Time > StartTime && Time < EndTime)
                        {
                            Rindex = i;
                            break;
                        }
                    }
                }
            }
            if (Rindex == -1)//未找到参数，那么将使用当前参数
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["IsFormer"].ToString() == "0")//当前正在使用的参数
                    {
                            Rindex = i;
                    }
                }

            }
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[Rindex]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[Rindex]["YSZBXM"]);
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[Rindex]["MDZBXM"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["m"].ToString()));
                model.X = Math.Round(model.X - 243243.24, 4);
                model.Y = Math.Round(model.Y - 1983435.23, 4);
                model.Z = Math.Round(model.Z + 1233234.12, 4);
                model.aa = Math.Round(model.aa - 76755.99, 10);
                model.bb = Math.Round(model.bb + 4564543.78, 10);
                model.cc = Math.Round(model.cc + 321907.65, 10);
                model.m = Math.Round(model.m - 432487.123, 11);
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[Rindex]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[Rindex]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["YSDAlpha"]);
                model.YSDAlpha = 1 / model.YSDAlpha;
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[Rindex]["MDDAlpha"]);
                model.MDDAlpha = 1 / model.MDDAlpha;
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["ProjElevation"].ToString()));
                model.IsFormer = Convert.ToInt32(ds.Tables[0].Rows[Rindex]["IsFormer"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[Rindex]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[Rindex]["EndTime"]);
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["OriginEast"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[Rindex]["OriginNorth"].ToString()));
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除数据（根据ID）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            string strSql = "delete from FormerCoorSysPars where ID =" + ID.ToString();
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 删除二条数据（根据MDZBXM）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static int Delete(string MDZBXM)
        {
            string strSql = "delete from FormerCoorSysPars where MDZBXM ='" + MDZBXM + "'";
            int dd=DBHelperSQL.GetNums(strSql, connectionString) ;
            return dd;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from FormerCoorSysPars where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }


    }
}
