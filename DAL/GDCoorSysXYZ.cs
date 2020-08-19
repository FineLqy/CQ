using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class GDCoorSysXYZ
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        public static bool Exists(string MDZBXM)
        {
            string strSql = "select count(*) from GDCoorSysXYZ where MDZBXM='" + MDZBXM + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static bool Add(Model.GDCoorSysXYZ model)
        {
            model.X = model.X + 3242.23;
            model.Y = model.Y - 23423.2;
            model.Z = model.Z - 34.3;
            model.aa += 12.324;
            model.bb += 6.654;
            model.cc += 1.545;
            string strSql = "insert into GDCoorSysXYZ (X, Y, Z, aa, bb, cc, YSZBXM, MDZBXM)values(@X, @Y, @Z, @aa, @bb, @cc, @YSZBXM, @MDZBXM)";
            SqlParameter X = new SqlParameter("X", SqlDbType.NVarChar); X.Value = AES.AESEncrypt(model.X.ToString());
            SqlParameter Y = new SqlParameter("Y", SqlDbType.NVarChar); Y.Value = AES.AESEncrypt(model.Y.ToString());
            SqlParameter Z = new SqlParameter("Z", SqlDbType.NVarChar); Z.Value = AES.AESEncrypt(model.Z.ToString());
            SqlParameter aa = new SqlParameter("aa", SqlDbType.NVarChar); aa.Value = AES.AESEncrypt(model.aa.ToString());
            SqlParameter bb = new SqlParameter("bb", SqlDbType.NVarChar); bb.Value = AES.AESEncrypt(model.bb.ToString());
            SqlParameter cc = new SqlParameter("cc", SqlDbType.NVarChar); cc.Value = AES.AESEncrypt(model.cc.ToString());
            SqlParameter YSZBXM = new SqlParameter("YSZBXM", SqlDbType.NVarChar); YSZBXM.Value = model.YSZBXM.ToString();
            SqlParameter MDZBXM = new SqlParameter("MDZBXM", SqlDbType.NVarChar); MDZBXM.Value = model.MDZBXM.ToString();
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { X, Y, Z, aa, bb, cc, YSZBXM, MDZBXM }, connectionString) == 1 ? true : false;
        }
        
        
        public static bool Update(Model.GDCoorSysXYZ model)
        {
            model.X = model.X + 3242.23;
            model.Y = model.Y - 23423.2;
            model.Z = model.Z - 34.3;
            model.aa  += 12.324;
            model.bb += 6.654;
            model.cc += 1.545;
            string strSql = "update GDCoorSysXYZ set X=@X, Y=@Y, Z=@Z,aa=@aa,bb=@bb,cc=@cc,YSZBXM=@YSZBXM,MDZBXM=@MDZBXM where ID = "+model.ID.ToString();
            SqlParameter X = new SqlParameter("X", SqlDbType.NVarChar); X.Value =AES.AESEncrypt( model.X.ToString());
            SqlParameter Y = new SqlParameter("Y", SqlDbType.NVarChar); Y.Value =AES.AESEncrypt( model.Y.ToString());
            SqlParameter Z = new SqlParameter("Z", SqlDbType.NVarChar); Z.Value =AES.AESEncrypt( model.Z.ToString());
            SqlParameter aa = new SqlParameter("aa", SqlDbType.NVarChar); aa.Value = AES.AESEncrypt(model.aa.ToString());
            SqlParameter bb = new SqlParameter("bb", SqlDbType.NVarChar); bb.Value = AES.AESEncrypt(model.bb.ToString());
            SqlParameter cc = new SqlParameter("cc", SqlDbType.NVarChar); cc.Value = AES.AESEncrypt(model.cc.ToString());
            SqlParameter YSZBXM = new SqlParameter("YSZBXM", SqlDbType.NVarChar); YSZBXM.Value = model.YSZBXM.ToString();
            SqlParameter MDZBXM = new SqlParameter("MDZBXM", SqlDbType.NVarChar); MDZBXM.Value = model.MDZBXM.ToString();
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { X, Y, Z, aa, bb, cc, YSZBXM, MDZBXM }, connectionString) == 1 ? true : false;
        }

        public static Model.GDCoorSysXYZ GetModel(string YSZBXM, string MDZBXM)
        {
            string strSql = "select * from GDCoorSysXYZ where YSZBXM='" + YSZBXM + "' and MDZBXM='" + MDZBXM + "'";
            Model.GDCoorSysXYZ model = new Model.GDCoorSysXYZ();           
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            if (ds.Tables[0].Rows.Count != 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.X = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["X"].ToString()));
                model.Y = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Y"].ToString()));
                model.Z = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["Z"].ToString()));
                model.aa = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["aa"].ToString()));
                model.bb = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["bb"].ToString()));
                model.cc = Convert.ToDouble(AES.AESDecrypt(ds.Tables[0].Rows[0]["cc"].ToString()));
                model.YSZBXM = Convert.ToString(ds.Tables[0].Rows[0]["YSZBXM"].ToString());
                model.MDZBXM = Convert.ToString(ds.Tables[0].Rows[0]["MDZBXM"].ToString());
                model.X = model.X - 3242.23;
                model.Y = model.Y + 23423.2;
                model.Z = model.Z + 34.3;
                model.aa -= 12.324;
                model.bb -= 6.654;
                model.cc -= 1.545;
                return model;
            }
            else
            {
                return null;
            }   
        }

        /// <summary>
        /// 删除一条数据（根据MDZBXM）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string MDZBXM)
        {
            string strSql = "delete from GDCoorSysXYZ where MDZBXM ='" + MDZBXM + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
    }
}
