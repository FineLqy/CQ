using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class CoorSysPars
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="YSZBXM"></param>
        /// <param name="MDZBXM"></param>
        /// <returns></returns>
        public static bool Exists(string YSZBXM, string MDZBXM)
        {
            string strSql = "select count(*) from CoorSysPars where YSZBXM='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static bool Add(Model.CoorSysPars model)
        {
            string strSql = "insert into CoorSysPars (YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2,YSRemarkName,MDRemarkName,YSDAlpha,MDDAlpha,CMeridian,ProjElevation,OriginNorth,OriginEast,AreaID)values(@YSZBXM, @MDZBXM, @X, @Y, @Z, @aa, @bb, @cc, @m, @YSMajorAxis, @YSe2, @MDMajorAxis, @MDe2,@YSRemarkName,@MDRemarkName,@YSDAlpha,@MDDAlpha,@CMeridian,@ProjElevation,@OriginNorth,@OriginEast,@AreaID)";
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
            SqlParameter OriginNorth = new SqlParameter("OriginNorth", SqlDbType.NVarChar); OriginNorth.Value = AES.AESEncrypt(model.OriginNorth.ToString());
            SqlParameter OriginEast = new SqlParameter("OriginEast", SqlDbType.NVarChar); OriginEast.Value = AES.AESEncrypt(model.OriginEast.ToString());
            SqlParameter AreaID = new SqlParameter("AreaID", SqlDbType.Int); AreaID.Value = model.AreaID;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2, YSRemarkName, MDRemarkName, YSDAlpha, MDDAlpha, CMeridian, ProjElevation, OriginNorth, OriginEast, AreaID }, connectionString) == 1 ? true : false;
        }

        public static bool Update(Model.CoorSysPars model)
        {
            string strSql = "update CoorSysPars set YSZBXM=@YSZBXM, MDZBXM=@MDZBXM, X=@X,Y=@Y,Z=@Z,aa=@aa,bb=@bb,cc=@cc,m=@m,YSMajorAxis=@YSMajorAxis,YSe2=@YSe2,MDMajorAxis=@MDMajorAxis,MDe2=@MDe2, YSRemarkName=@YSRemarkName, MDRemarkName=@MDRemarkName, YSDAlpha=@YSDAlpha, MDDAlpha=@MDDAlpha, CMeridian=@CMeridian, ProjElevation=@ProjElevation,OriginNorth=@OriginNorth,OriginEast=@OriginEast,AreaID=@AreaID where ID = " + model.ID.ToString();
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
            SqlParameter OriginNorth = new SqlParameter("OriginNorth", SqlDbType.NVarChar); OriginNorth.Value = AES.AESEncrypt(model.OriginNorth.ToString());
            SqlParameter OriginEast = new SqlParameter("OriginEast", SqlDbType.NVarChar); OriginEast.Value = AES.AESEncrypt(model.OriginEast.ToString());
            SqlParameter AreaID = new SqlParameter("AreaID", SqlDbType.Int); AreaID.Value = model.AreaID;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { YSZBXM, MDZBXM, X, Y, Z, aa, bb, cc, m, YSMajorAxis, YSe2, MDMajorAxis, MDe2, YSRemarkName, MDRemarkName, YSDAlpha, MDDAlpha, CMeridian, ProjElevation, OriginNorth, OriginEast, AreaID }, connectionString) == 1 ? true : false;
        }
        public static Model.CoorSysPars GetModelFormId(int id)
        {
            string strSql = "select * from CoorSysPars where ID ='" + id + "'";
            Model.CoorSysPars model = new Model.CoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[0]["YSZBXM"]);
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[0]["MDZBXM"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["m"].ToString()));
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["YSDAlpha"]);
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["MDDAlpha"]);
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["ProjElevation"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginNorth"].ToString()));
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginEast"].ToString()));
                model.AreaID = Convert.ToInt32(ds.Tables[0].Rows[0]["AreaID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.CoorSysPars GetModel(string YSZBXM, string MDZBXM)
        {
            string strSql = "select * from CoorSysPars where YSZBXM ='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.CoorSysPars model = new Model.CoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = ds.Tables[0].Rows[0]["YSZBXM"].ToString();
                model.MDZBXM = ds.Tables[0].Rows[0]["MDZBXM"].ToString();
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["m"].ToString()));
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["YSDAlpha"]);
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["MDDAlpha"]);
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["ProjElevation"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginNorth"].ToString()));
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginEast"].ToString()));
                model.AreaID = Convert.ToInt32(ds.Tables[0].Rows[0]["AreaID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 从数据库中提取出真参数
        /// </summary>
        /// <param name="YSZBXM"></param>
        /// <param name="MDZBXM"></param>
        /// <returns></returns>
        public static Model.OCoorSysPars GetOModel(string YSZBXM, string MDZBXM)
        {
            string strSql = "select * from CoorSysPars where YSZBXM ='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.OCoorSysPars model = new Model.OCoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[0]["YSZBXM"]);
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[0]["MDZBXM"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["m"].ToString()));
                model.X = Math.Round(model.X - 243243.24, 4);
                model.Y = Math.Round(model.Y - 1983435.23, 4);
                model.Z = Math.Round(model.Z + 1233234.12, 4);
                model.aa = Math.Round(model.aa - 76755.99, 8);
                model.bb = Math.Round(model.bb + 4564543.78, 8);
                model.cc = Math.Round(model.cc + 321907.65, 8);
                model.m = Math.Round(model.m - 432487.123, 11);
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["YSDAlpha"]);
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["MDDAlpha"]);
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["ProjElevation"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginNorth"].ToString()));
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginEast"].ToString()));
                model.AreaID = Convert.ToInt32(ds.Tables[0].Rows[0]["AreaID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 从数据库中提取出真参数,用于何冰写的坐标转换程序
        /// </summary>
        /// <param name="YSZBXM"></param>
        /// <param name="MDZBXM"></param>
        /// <returns></returns>
        public static Model.OCoorSysPars GetHBModel(string YSZBXM, string MDZBXM)
        {
            string strSql = "select * from CoorSysPars where YSZBXM ='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.OCoorSysPars model = new Model.OCoorSysPars();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[0]["YSZBXM"]);
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[0]["MDZBXM"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["cc"].ToString()));
                model.m = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["m"].ToString()));
                model.X = Math.Round(model.X - 243243.24, 4);
                model.Y = Math.Round(model.Y - 1983435.23, 4);
                model.Z = Math.Round(model.Z + 1233234.12, 4);
                model.aa = Math.Round(model.aa - 76755.99, 8);
                model.bb = Math.Round(model.bb + 4564543.78, 8);
                model.cc = Math.Round(model.cc + 321907.65, 8);
                model.m = Math.Round(model.m - 432487.123, 11);
                model.YSMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["YSMajorAxis"]);
                model.YSe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["YSe2"]);
                model.MDMajorAxis = Convert.ToDouble(ds.Tables[0].Rows[0]["MDMajorAxis"]);
                model.MDe2 = Convert.ToDouble(ds.Tables[0].Rows[0]["MDe2"]);
                model.YSRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["YSRemarkName"]);
                model.MDRemarkName = Convert.ToString(ds.Tables[0].Rows[0]["MDRemarkName"]);
                model.YSDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["YSDAlpha"]);
                model.YSDAlpha = 1 / model.YSDAlpha;
                model.MDDAlpha = Convert.ToDouble(ds.Tables[0].Rows[0]["MDDAlpha"]);
                model.MDDAlpha = 1 / model.MDDAlpha;
                model.CMeridian = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["CMeridian"].ToString()));
                model.ProjElevation = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["ProjElevation"].ToString()));
                model.OriginNorth = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginNorth"].ToString()));
                model.OriginEast = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["OriginEast"].ToString()));
                model.AreaID = Convert.ToInt32(ds.Tables[0].Rows[0]["AreaID"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除二条数据（根据MDZBXM）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string MDZBXM)
        {
            string strSql = "delete from CoorSysPars where MDZBXM ='" + MDZBXM + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 2 ? true : false;
        }
        /// <summary>
        /// 删除多条数据（根据ID）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static bool DeleteByIDs(int[] ids)
        {
            string delstr = "";
            for (int i = 0; i < ids.Length - 1; i++)
            {
                delstr += "(ID='" + ids[i] + "')or";
            }
            delstr += "(ID='" + ids[ids.Length - 1] + "')";
            string strSql = "delete from CoorSysPars where " + delstr;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from CoorSysPars where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM CoorSysPars w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " * FROM CoorSysPars ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            //SqlParameter Limit = new SqlParameter("@limit", SqlDbType.NVarChar, 500); Limit.Value = limit;
            //SqlParameter EndRecord = new SqlParameter("@endRecord", SqlDbType.DateTime);
            //EndRecord.Value = endRecord;
            //return DBHelperSQL.GetDataSet(sql, new SqlParameter[] { Limit, EndRecord });
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[0]["YSZBXM"]);
                //model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[0]["MDZBXM"]);
                if (ds.Tables[0].Rows[i]["YSZBXM"].ToString() != "GD") continue;
                ds.Tables[0].Rows[i]["X"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["X"].ToString());
                ds.Tables[0].Rows[i]["Y"] = ds.Tables[0].Rows[i]["Y"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["Y"].ToString());
                ds.Tables[0].Rows[i]["Z"] = ds.Tables[0].Rows[i]["Z"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["Z"].ToString());
                ds.Tables[0].Rows[i]["aa"] = ds.Tables[0].Rows[i]["aa"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["aa"].ToString());
                ds.Tables[0].Rows[i]["bb"] = ds.Tables[0].Rows[i]["bb"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["bb"].ToString());
                ds.Tables[0].Rows[i]["cc"] = ds.Tables[0].Rows[i]["cc"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["cc"].ToString());
                ds.Tables[0].Rows[i]["m"] = ds.Tables[0].Rows[i]["m"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["m"].ToString());
                ds.Tables[0].Rows[i]["X"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["X"]) - 243243.24, 4).ToString();
                ds.Tables[0].Rows[i]["Y"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["Y"]) - 1983435.23, 4).ToString();
                ds.Tables[0].Rows[i]["Z"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["Z"]) + 1233234.12, 4).ToString();
                ds.Tables[0].Rows[i]["aa"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["aa"]) - 76755.99, 8).ToString();
                ds.Tables[0].Rows[i]["bb"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["bb"]) + 4564543.78, 8).ToString();
                ds.Tables[0].Rows[i]["cc"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["cc"]) + 321907.65, 8).ToString();
                ds.Tables[0].Rows[i]["m"] = ds.Tables[0].Rows[i]["X"].ToString() == "" ? "" : Math.Round(Convert.ToDouble(ds.Tables[0].Rows[i]["m"]) - 432487.123, 11).ToString();

                ds.Tables[0].Rows[i]["CMeridian"] = ds.Tables[0].Rows[i]["CMeridian"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["CMeridian"].ToString());
                ds.Tables[0].Rows[i]["ProjElevation"] = ds.Tables[0].Rows[i]["ProjElevation"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["ProjElevation"].ToString());
                ds.Tables[0].Rows[i]["OriginNorth"] = ds.Tables[0].Rows[i]["OriginNorth"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["OriginNorth"].ToString());
                ds.Tables[0].Rows[i]["OriginEast"] = ds.Tables[0].Rows[i]["OriginEast"].ToString() == "" ? "" : AES.AESDecrypt(ds.Tables[0].Rows[i]["OriginEast"].ToString());
                ds.Tables[0].Rows[i]["AreaID"] = ds.Tables[0].Rows[i]["AreaID"].ToString() == "" ? 99999 : ds.Tables[0].Rows[i]["AreaID"];
            }
            return ds;


        }


        public static int GetRecordCount()
        {
            string strSql = "select count(*) from CoorSysPars";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }


    }
}
