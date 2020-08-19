using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace CORSV2.cs
{
    /// <summary>
    /// 事后坐标转换类
    /// </summary>
    class PostCoorTrans
    {
        /// <summary>
        /// 获取转换点数量
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int CoorNum(string filename)
        {
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            int num = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    num = num + 1;
                }
            }
            sr.Close();
            return num;
        }

        /// <summary>
        /// 判断数据格式是否正确
        /// </summary>
        /// <param name="linedata"></param>
        /// <returns></returns>
        public static bool IsDMSData(string linedata)
        {
            string[] strs = System.Text.RegularExpressions.Regex.Split(linedata.Trim(), @"\s+");
            if (strs.Length != 4)
            {
                return false;
            }
            double B = 0; double L = 0;
            try
            {
                B = Convert.ToDouble(strs[1]);
                L = Convert.ToDouble(strs[2]);
            }
            catch
            {
                return false;
            }
            double Bdu = Math.Floor(B); double Ldu = Math.Floor(L);
            if (Bdu >= 70 || Bdu <= 10 || Ldu <= 60 || Ldu >= 130)
            {
                return false;
            }
            double Bfen = (B - Bdu) * 100; double Lfen = (L - Ldu) * 100; double Bm = (Bfen - Math.Floor(Bfen)) * 100; double Lm = (Lfen - Math.Floor(Lfen)) * 100;
            if (Bfen > 60 || Lfen > 60 || Bm > 60 || Lm > 60)
            {
                return false;
            }
            if (strs.Length == 4)
            {
                double H = 0;
                try
                {
                    H = Convert.ToDouble(strs[3]);
                }
                catch
                {
                    return false;
                }
                if (H > 100000 || H < -1000)
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 检查BLH文件格式是否正确
        /// </summary>
        /// <param name="BLHfilename"></param>
        /// <returns></returns>
        public static bool IsBLHfile(string BLHfilename)
        {
            if (!File.Exists(BLHfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(BLHfilename, Encoding.Default);
            while (!sr.EndOfStream)
            {
                double B, L, H;
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    if (ss.Length != 4)
                    {
                        sr.Close();
                        return false;
                    }
                    if (ss[0].Length > 8)
                    {
                        sr.Close();
                        return false;
                    }
                    if (!double.TryParse(ss[1], out B))
                    {
                        sr.Close();
                        return false;
                    }
                    if (!double.TryParse(ss[2], out L))
                    {
                        sr.Close();
                        return false;
                    }
                    if (!double.TryParse(ss[3], out H))
                    {
                        sr.Close();
                        return false;
                    }
                    if (Math.Abs(B) > 90.0)
                    {
                        sr.Close();
                        return false;
                    }
                    if (Math.Abs(L) > 180.0)
                    {
                        sr.Close();
                        return false;
                    }
                    if (!IsDMSData(line))
                    {
                        sr.Close();
                        return false;
                    }
                }
            }
            sr.Close();
            return true;
        }

        /// <summary>
        /// 检查XYZ文件格式是否正确
        /// </summary>
        /// <param name="BLHfilename"></param>
        /// <returns></returns>
        public static bool IsXYZfile(string XYZfilename)
        {
            if (!File.Exists(XYZfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(XYZfilename, Encoding.Default);
            while (!sr.EndOfStream)
            {
                double X, Y, Z;
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    if (ss.Length != 4)
                    {
                        sr.Close();
                        return false;
                    }
                    if (ss[0].Length > 8)
                    {
                        sr.Close();
                        return false;
                    }
                    if (!double.TryParse(ss[1], out X))
                    {
                        sr.Close();
                        return false;
                    }
                    if (!double.TryParse(ss[2], out Y))
                    {
                        sr.Close();
                        return false;
                    }
                    if (!double.TryParse(ss[3], out Z))
                    {
                        sr.Close();
                        return false;
                    }
                    if (Math.Abs(X) < 361.0)
                    {
                        sr.Close();
                        return false;
                    }
                    if (Math.Abs(Y) < 361.0)
                    {
                        sr.Close();
                        return false;
                    }
                    if (Math.Abs(Z) < 361.0)
                    {
                        sr.Close();
                        return false;
                    }
                }
            }
            sr.Close();
            return true;
        }

        /// <summary>
        /// CGCS2000下的BLH到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高，并根据用户需要确定是否加密压缩存储  只转平面坐标
        /// </summary>
        /// <param name="BLHfilename">BLH文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool BLHtoxyhFile(string BLHfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password)
        {
            if (!IsBLHfile(BLHfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(BLHfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "北坐标".PadLeft(17) + "东坐标".PadLeft(17) + "大地高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                GEODETIC BLH = new GEODETIC();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    BLH.latdms = double.Parse(ss[1]);
                    BLH.londms = double.Parse(ss[2]);
                    BLH.height = double.Parse(ss[3]);
                    BLHtoxyh(BLH, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + xyh.h.ToString("F4").PadLeft(20));
                }
            }
            sr.Close();
            sw.Close();

            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            //else
            //{
            //    clsWinRar.CompressRar(xyhfilename);
            //    File.Delete(xyhfilename);
            //}
            return true;
        }
        /// <summary>
        /// CGCS2000下的BLH到目的坐标系下的坐标 xyh，其中h为正常高，并根据用户需要确定是否加密压缩存储    转平面坐标和正常高
        /// </summary>
        /// <param name="BLHfilename">BLH文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool BLHtoxyhFile(string BLHfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid)
        {
            if (!IsBLHfile(BLHfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(BLHfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + (coorPar.MDZBXM + "北坐标").PadLeft(17) + (coorPar.MDZBXM + "东坐标").PadLeft(17) + "正常高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                GEODETIC BLH = new GEODETIC();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    BLH.latdms = double.Parse(ss[1]);
                    BLH.londms = double.Parse(ss[2]);
                    BLH.height = double.Parse(ss[3]);
                    BLHtoxyh(BLH, coorPar, ref xyh);
                    double H = 0;
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                    {
                        xyh.h = BLH.height - H;

                        sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + xyh.h.ToString("F4").PadLeft(20));
                    }
                    else
                    {
                        xyh.h = BLH.height;
                        sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + (xyh.h.ToString("F4") + "-大地高").PadLeft(20));
                    }

                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            //else
            //{
            //    clsWinRar.CompressRar(xyhfilename);
            //    File.Delete(xyhfilename);
            //}
            return true;
        }
        /// <summary>
        /// CGCS2000下的BLH到目的坐标系下的坐标 xyh，其中h为正常高，并根据用户需要确定是否加密压缩存储    转平面坐标和正常高   适用于GD+正常高测量
        /// </summary>
        /// <param name="BLHfilename">BLH文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool BLHtoxyhFile_GD(string BLHfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid)
        {
            if (!IsBLHfile(BLHfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(BLHfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "北坐标".PadLeft(17) + "东坐标".PadLeft(17) + "正常高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                GEODETIC BLH = new GEODETIC();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    BLH.latdms = double.Parse(ss[1]);
                    BLH.londms = double.Parse(ss[2]);
                    BLH.height = double.Parse(ss[3]);
                    BLHtoxyh(BLH, coorPar, ref xyh);
                    double H = 0; geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H);
                    //xyh.h = BLH.height - H;
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + xyh.h.ToString("F4").PadLeft(20));
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            //else
            //{
            //    clsWinRar.CompressRar(xyhfilename);
            //    File.Delete(xyhfilename);
            //}
            return true;
        }

        /// <summary>
        /// CGCS2000下的BLH到目的坐标系下的坐标 xyh，其中h为正常高，并根据用户需要确定是否加密压缩存储    转正常高
        /// </summary>
        /// <param name="BLHfilename">BLH文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool BLHtoxyhFile(string BLHfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid, bool OnlyHeight)
        {
            if (!IsBLHfile(BLHfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(BLHfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "正常高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                GEODETIC BLH = new GEODETIC();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    BLH.latdms = double.Parse(ss[1]);
                    BLH.londms = double.Parse(ss[2]);
                    BLH.height = double.Parse(ss[3]);
                    BLHtoxyh(BLH, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    double H = 0;
                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                    {
                        xyh.h = BLH.height - H;

                        sw.WriteLine(index.PadLeft(10) + xyh.h.ToString("F4").PadLeft(20));
                    }
                    else
                    {
                        xyh.h = BLH.height;
                        sw.WriteLine(index.PadLeft(10) + (xyh.h.ToString("F4") + "-大地高").PadLeft(20));
                    }

                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            //else
            //{
            //    clsWinRar.CompressRar(xyhfilename);
            //    File.Delete(xyhfilename);
            //}
            return true;
        }

        /// <summary>
        /// CGCS2000下的BLH到目的坐标系下的坐标 xyh，其中h为正常高，并根据用户需要确定是否加密压缩存储    转正常高  适用于GD+正常高测量
        /// </summary>
        /// <param name="BLHfilename">BLH文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool BLHtoxyhFile_GD(string BLHfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid, bool OnlyHeight)
        {
            if (!IsBLHfile(BLHfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(BLHfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "正常高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                GEODETIC BLH = new GEODETIC();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    BLH.latdms = double.Parse(ss[1]);
                    BLH.londms = double.Parse(ss[2]);
                    BLH.height = double.Parse(ss[3]);
                    BLHtoxyh(BLH, coorPar, ref xyh);
                    double H = 0; geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H);
                    //xyh.h = BLH.height - H;
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    sw.WriteLine(index.PadLeft(10) + xyh.h.ToString("F4").PadLeft(20));
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            //else
            //{
            //    clsWinRar.CompressRar(xyhfilename);
            //    File.Delete(xyhfilename);
            //}
            return true;
        }

        /// <summary>
        /// CGCS2000下的XYZ到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高，并根据用户需要确定是否加密压缩存储  只转平面
        /// </summary>
        /// <param name="XYZfilename">XYZ文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool XYZtoxyhFile(string XYZfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password)
        {
            if (!IsXYZfile(XYZfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(XYZfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "北坐标".PadLeft(20) + "东坐标".PadLeft(20) + "大地高".PadLeft(20));
            while (!sr.EndOfStream)
            {
                string index;
                CARTESIAN XYZ = new CARTESIAN();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    XYZ.X = double.Parse(ss[1]);
                    XYZ.Y = double.Parse(ss[2]);
                    XYZ.Z = double.Parse(ss[3]);
                    XYZtoxyh(XYZ, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").ToString().PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + xyh.h.ToString("F4").PadLeft(20));
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            //else
            //{
            //    clsWinRar.CompressRar(xyhfilename);
            //    File.Delete(xyhfilename);
            //}
            return true;
        }

        /// <summary>
        /// CGCS2000下的XYZ到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高，并根据用户需要确定是否加密压缩存储  转平面和正常高
        /// </summary>
        /// <param name="XYZfilename">XYZ文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool XYZtoxyhFile(string XYZfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid)
        {
            if (!IsXYZfile(XYZfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(XYZfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "北坐标".PadLeft(17) + "东坐标".PadLeft(17) + "正常高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                CARTESIAN XYZ = new CARTESIAN();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    XYZ.X = double.Parse(ss[1]);
                    XYZ.Y = double.Parse(ss[2]);
                    XYZ.Z = double.Parse(ss[3]);
                    GEODETIC BLH = new GEODETIC();
                    Car2Geo(coorPar.YSMajorAxis, coorPar.YSDAlpha, XYZ, ref BLH); double H = 0;

                    XYZtoxyh(XYZ, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                    {
                        xyh.h = BLH.height - H;

                        sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + xyh.h.ToString("F4").PadLeft(20));
                    }
                    else
                    {
                        xyh.h = BLH.height;
                        sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + (xyh.h.ToString("F4") + "-大地高").PadLeft(20));
                    }
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            return true;
        }

        /// <summary>
        /// CGCS2000下的XYZ到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高，并根据用户需要确定是否加密压缩存储  转平面和正常高  适用于GD+正常高测量
        /// </summary>
        /// <param name="XYZfilename">XYZ文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool XYZtoxyhFile_GD(string XYZfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid)
        {
            if (!IsXYZfile(XYZfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(XYZfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "北坐标".PadLeft(17) + "东坐标".PadLeft(17) + "正常高".PadLeft(17));
            while (!sr.EndOfStream)
            {
                string index;
                CARTESIAN XYZ = new CARTESIAN();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    XYZ.X = double.Parse(ss[1]);
                    XYZ.Y = double.Parse(ss[2]);
                    XYZ.Z = double.Parse(ss[3]);
                    GEODETIC BLH = new GEODETIC();
                    Car2Geo(coorPar.YSMajorAxis, coorPar.YSDAlpha, XYZ, ref BLH); double H = 0; geoid.GetGeoidH(BLH.latitude * 180 / Math.PI * 60, BLH.longitude * 180 / Math.PI * 60, ref H);
                    XYZtoxyh(XYZ, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast; //xyh.h = BLH.height - H;
                    sw.WriteLine(index.PadLeft(10) + xyh.x.ToString("F4").ToString().PadLeft(20) + xyh.y.ToString("F4").PadLeft(20) + xyh.h.ToString("F4").PadLeft(20));
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            return true;
        }
        /// <summary>
        /// CGCS2000下的XYZ到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高，并根据用户需要确定是否加密压缩存储  转正常高
        /// </summary>
        /// <param name="XYZfilename">XYZ文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool XYZtoxyhFile(string XYZfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid, bool Onlyheiht)
        {
            if (!IsXYZfile(XYZfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(XYZfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "正常高".PadLeft(20));
            while (!sr.EndOfStream)
            {
                string index;
                CARTESIAN XYZ = new CARTESIAN();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    XYZ.X = double.Parse(ss[1]);
                    XYZ.Y = double.Parse(ss[2]);
                    XYZ.Z = double.Parse(ss[3]);
                    GEODETIC BLH = new GEODETIC();
                    Car2Geo(coorPar.YSMajorAxis, coorPar.YSDAlpha, XYZ, ref BLH); double H = 0; geoid.GetGeoidH(BLH.latitude * 180 / Math.PI * 60, BLH.longitude * 180 / Math.PI * 60, ref H);
                    XYZtoxyh(XYZ, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast;
                    if (geoid.GetGeoidH_dms(BLH.latdms, BLH.londms, ref H))
                    {
                        xyh.h = BLH.height - H;

                        sw.WriteLine(index.PadLeft(10) + xyh.h.ToString("F4").PadLeft(20));
                    }
                    else
                    {
                        xyh.h = BLH.height;
                        sw.WriteLine(index.PadLeft(10) + (xyh.h.ToString("F4") + "-大地高").PadLeft(20));
                    }
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            return true;
        }

        /// <summary>
        /// CGCS2000下的XYZ到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高，并根据用户需要确定是否加密压缩存储  转正常高  适用于GD+正常高测量
        /// </summary>
        /// <param name="XYZfilename">XYZ文件名</param>
        /// <param name="xyhfilename">xyh文件名</param>
        /// <param name="coorPar">坐标参数</param>
        /// <param name="NeedCompress">是否需要压缩</param>
        /// <param name="password">解压密码</param>
        public static bool XYZtoxyhFile_GD(string XYZfilename, string xyhfilename, Model.OFormerCoorSysPars coorPar, bool NeedCompress, string password, Geoid geoid, bool Onlyheiht)
        {
            if (!IsXYZfile(XYZfilename))
            {
                return false;
            }
            StreamReader sr = new StreamReader(XYZfilename, Encoding.Default);
            StreamWriter sw = new StreamWriter(xyhfilename, false, Encoding.Default);
            sw.WriteLine("点名".PadLeft(8) + "正常高".PadLeft(20));
            while (!sr.EndOfStream)
            {
                string index;
                CARTESIAN XYZ = new CARTESIAN();
                PLANECOOR xyh = new PLANECOOR();
                string line = sr.ReadLine();
                if (line.Trim() != "")
                {
                    string[] ss = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");
                    index = ss[0];
                    XYZ.X = double.Parse(ss[1]);
                    XYZ.Y = double.Parse(ss[2]);
                    XYZ.Z = double.Parse(ss[3]);
                    GEODETIC BLH = new GEODETIC();
                    Car2Geo(coorPar.YSMajorAxis, coorPar.YSDAlpha, XYZ, ref BLH); double H = 0; geoid.GetGeoidH(BLH.latitude * 180 / Math.PI * 60, BLH.longitude * 180 / Math.PI * 60, ref H);
                    XYZtoxyh(XYZ, coorPar, ref xyh);
                    xyh.x = xyh.x + coorPar.OriginNorth; xyh.y = xyh.y + coorPar.OriginEast; //xyh.h = BLH.height - H;
                    sw.WriteLine(index.PadLeft(10) + xyh.h.ToString("F4").PadLeft(20));
                }
            }
            sr.Close();
            sw.Close();
            if (NeedCompress)
            {
                clsWinRar.CompressRar(xyhfilename, "", password);
                File.Delete(xyhfilename);
            }
            return true;
        }

        /// <summary>
        /// CGCS2000下的BLH到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高
        /// </summary>
        /// <param name="blh"></param>
        /// <param name="coorPar"></param>
        /// <param name="xyh"></param>
        public static void BLHtoxyh(GEODETIC BLH, Model.OFormerCoorSysPars coorPar, ref PLANECOOR xyh)
        {
            CARTESIAN XYZ = new CARTESIAN();
            Geo2Car(coorPar.YSMajorAxis, coorPar.YSDAlpha, BLH, ref XYZ);
            XYZtoxyh(XYZ, coorPar, ref xyh);
        }

        /// <summary>
        /// CGCS2000下的XYZ到目的坐标系下的坐标 xyh，其中h为目的坐标系下的大地高
        /// </summary>
        /// <param name="XYZ"></param>
        /// <param name="coorPar"></param>
        /// <param name="xyh"></param>
        public static void XYZtoxyh(CARTESIAN XYZ, Model.OFormerCoorSysPars coorPar, ref PLANECOOR xyh)
        {
            CARTESIAN XYZ_temp = new CARTESIAN();
            GEODETIC BLH_temp = new GEODETIC();
            double e2 = coorPar.MDDAlpha * (2 - coorPar.MDDAlpha);
            ParameterTrans7(XYZ, coorPar, ref XYZ_temp);
            Car2Geo(coorPar.MDMajorAxis, coorPar.MDDAlpha, XYZ_temp, ref BLH_temp);
            BL2xy(coorPar.MDMajorAxis, e2, Angle2Ration(coorPar.CMeridian), coorPar.ProjElevation, BLH_temp.latitude, BLH_temp.longitude, ref xyh.x, ref xyh.y);
            xyh.h = BLH_temp.height;
        }

        /// <summary>
        /// 空间直角坐标转换为空间大地坐标
        /// </summary>
        /// <param name="a">椭球长半轴</param>
        /// <param name="e2">椭球离心率的平方</param>
        /// <param name="XYZ">空间直角坐标</param>
        /// <param name="BLH">空间大地坐标</param>
        public static void Car2Geo(double a, double f, CARTESIAN XYZ, ref GEODETIC BLH)
        {
            double e2 = 2 * f - f * f;
            double S, B0;

            S = Math.Sqrt(Math.Pow(XYZ.X, 2) + Math.Pow(XYZ.Y, 2));
            B0 = Math.Atan(XYZ.Z / S);

            double Ni = 0.0, Bi = 0.0;
            for (int i = 0; i < 10; i++)
            {
                Ni = a / Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(B0), 2));
                Bi = Math.Atan((XYZ.Z + Ni * e2 * Math.Sin(B0)) / S);

                if (Math.Abs(B0 - Bi) < 1e-20)
                {
                    break;
                }
                B0 = Bi;
            }

            BLH.latitude = Bi;
            BLH.longitude = Math.Atan(XYZ.Y / XYZ.X);
            BLH.height = S / Math.Cos(Bi) - Ni;

            if (XYZ.X < 0)
            {
                BLH.longitude += Math.PI;
            }
            if (BLH.longitude > Math.PI)
            {
                BLH.longitude -= 2 * Math.PI;
            }
        }

        /// <summary>
        /// 空间大地坐标转换为空间直角坐标
        /// </summary>
        /// <param name="a">椭球长半轴</param>
        /// <param name="f">椭球扁率的倒数</param>
        /// <param name="BLH">空间大地坐标</param>
        /// <param name="XYZ">空间直角坐标</param>
        public static void Geo2Car(double a, double f, GEODETIC BLH, ref CARTESIAN XYZ)
        {
            double B = BLH.latitude;
            double L = BLH.longitude;
            double H = BLH.height;

            double e2 = 2 * f - f * f;
            double N = a / Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(B), 2));

            XYZ.X = (N + H) * Math.Cos(B) * Math.Cos(L);
            XYZ.Y = (N + H) * Math.Cos(B) * Math.Sin(L);
            XYZ.Z = (N - N * e2 + H) * Math.Sin(B);
        }

        /// <summary>
        /// 通过七参数完成不同空间坐标系之间的转换
        /// </summary>
        /// <param name="car1">原始坐标系</param>
        /// <param name="coorPar">转换参数</param>
        /// <param name="car2">目标坐标系</param>
        public static void ParameterTrans7(CARTESIAN car1, Model.OFormerCoorSysPars coorPar, ref CARTESIAN car2)
        {
            Matrix M1 = car2Matrix(car1);
            Matrix M = CoorSysPars2Vector(coorPar);
            Matrix M2 = M1 * M;
            car2.X = M2[0, 0];
            car2.Y = M2[1, 0];
            car2.Z = M2[2, 0];
        }

        /// <summary>
        /// 根据空间直角坐标得到七参数转换的转换矩阵
        /// </summary>
        /// <param name="car">空间直角坐标</param>
        /// <returns>转换矩阵</returns>
        public static Matrix car2Matrix(CARTESIAN car)
        {
            Matrix M = new Matrix(3, 7);
            M[0, 0] = 1;
            M[1, 1] = 1;
            M[2, 2] = 1;
            M[0, 3] = car.X / 1e6;
            M[1, 3] = car.Y / 1e6;
            M[2, 3] = car.Z / 1e6;
            M[1, 4] = M[2, 3];
            M[2, 4] = -M[1, 3];
            M[0, 5] = -M[2, 3];
            M[2, 5] = M[0, 3];
            M[0, 6] = M[1, 3];
            M[1, 6] = -M[0, 3];
            return M;
        }

        /// <summary>
        /// 将空间直角坐标XYZ转为向量形式
        /// </summary>
        /// <param name="car">空间直角坐标</param>
        /// <returns>空间直角坐标的向量形式</returns>
        public static Matrix car2Vector(CARTESIAN car)
        {
            Matrix M = new Matrix(3, 1);
            M[0, 0] = car.X;
            M[1, 0] = car.Y;
            M[2, 0] = car.Z;
            return M;
        }

        /// <summary>
        /// 将七参数转换为向量形式
        /// </summary>
        /// <param name="coorPar">七参数</param>
        /// <returns>七参数向量形式</returns>
        public static Matrix CoorSysPars2Vector(Model.OFormerCoorSysPars coorPar)
        {
            Matrix M = new Matrix(7, 1);
            M[0, 0] = coorPar.X;
            M[1, 0] = coorPar.Y;
            M[2, 0] = coorPar.Z;
            M[3, 0] = coorPar.m + 1000000;
            M[4, 0] = M[3, 0] * coorPar.aa / 648000.0 * Math.PI;
            M[5, 0] = M[3, 0] * coorPar.bb / 648000.0 * Math.PI;
            M[6, 0] = M[3, 0] * coorPar.cc / 648000.0 * Math.PI;
            return M;
        }

        /// <summary>
        /// 将角度转换为弧度，角度度分秒格式：aaa.bbcccc。例如，101.301234表示101度30分12.34秒
        /// </summary>
        /// <param name="A">角度</param>
        /// <returns>弧度</returns>
        public static double Angle2Ration(double A)
        {
            double R;
            int Hr, Min;
            double Sec;
            Hr = (int)A;
            Min = (int)((A * 100 - Hr * 100));
            Sec = (A * 10000 - Hr * 10000) - Min * 100;
            R = (Hr + Min / 60.0 + Sec / 3600.0);
            R = R * Math.PI / 180.0;
            return R;
        }

        /// <summary>
        /// 将弧度转换为角度，角度度分秒格式：aaa.bbcccc。例如，101.301234表示101度30分12.34秒
        /// </summary>
        /// <param name="R">弧度</param>
        /// <returns>角度</returns>
        public static double RationToAngle(double R)
        {
            double A;
            int Hr, Min;
            double Sec;
            A = R * 180 / Math.PI;
            Hr = (int)A;
            Min = (int)((A - Hr) * 60);
            Sec = A * 3600 - Hr * 3600 - Min * 60;
            A = Hr + Min / 100.0 + Sec / 10000.0;
            return A;
        }

        /// <summary>
        /// 椭球投影到平面
        /// </summary>
        /// <param name="a"></param>
        /// <param name="e2"></param>
        /// <param name="L0"></param>
        /// <param name="DH"></param>
        /// <param name="B"></param>
        /// <param name="L"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void BL2xy(double a, double e2, double L0, double DH, double B, double L, ref double x, ref double y)
        {
            //double e2=2*f-f*f;
            double e1 = e2 / (1 - e2);
            double W = Math.Sqrt(1 - e2 * Math.Sin(B) * Math.Sin(B));
            double V = Math.Sqrt(1 + e1 * Math.Cos(B) * Math.Cos(B));
            /////////////////////////投影高程面引起的变化
            a = W * DH + a;///////以某点卯酉圈曲率半径变化推算长半轴变化，偏心率不变
            double M = a * (1 - e2) / Math.Pow(W, 3);
            //B = e * Math.Sin(B) * Math.Cos(B) * (1 - e * Math.Sin(B) * Math.Sin(B))/(M*W*Math.Sqrt(1-e))*DH+B;///以平均曲率半径变化推算长半轴变化
            B = e2 * Math.Sin(B) * Math.Cos(B) / M * DH + B;
            W = Math.Sqrt(1 - e2 * Math.Sin(B) * Math.Sin(B));
            V = Math.Sqrt(1 + e1 * Math.Cos(B) * Math.Cos(B));
            //////////////////////////////////////////////////////////////

            double N = a / W;
            double it2 = e1 * Math.Cos(B) * Math.Cos(B);
            double t = Math.Tan(B);
            double X = CalMeridian(a, e2, B);
            double dl = L - L0;
            x = X + N / 2.0 * Math.Sin(B) * Math.Cos(B) * dl * dl + N / 24.0 * Math.Sin(B) * Math.Pow(Math.Cos(B), 3) * (5 - t * t + 9 * it2 + 4 * it2 * it2) * Math.Pow(dl, 4) + N / 720.0 * Math.Sin(B) * Math.Pow(Math.Cos(B), 5) * (61 - 58 * t * t + Math.Pow(t, 4)) * Math.Pow(dl, 6);
            y = N * Math.Cos(B) * dl + N / 6.0 * Math.Pow(Math.Cos(B), 3) * (1 - t * t + it2) * dl * dl * dl + N / 120.0 * Math.Pow(Math.Cos(B), 5) * (5 - 18 * t * t + Math.Pow(t, 4) + 14 * it2 - 58 * it2 * t * t) * Math.Pow(dl, 5);
            //y = y + 500000;
        }

        public static double CalMeridian(double a, double e2, double B)
        {
            double m0 = a * (1 - e2);
            double m2 = 3.0 / 2.0 * e2 * m0;
            double m4 = 5.0 / 4.0 * e2 * m2;
            double m6 = 7.0 / 6.0 * e2 * m4;
            double m8 = 9.0 / 8.0 * e2 * m6;
            double m10 = 11.0 / 10.0 * e2 * m8;

            double a0 = m0 + m2 / 2.0 + 3.0 / 8.0 * m4 + 5.0 / 16.0 * m6 + 35.0 / 128.0 * m8;  //  +63.0 / 256.0 * m10;
            double a2 = m2 / 2.0 + m4 / 2.0 + 15.0 / 32.0 * m6 + 7.0 / 16.0 * m8;  // +21 / 128 * m10;
            double a4 = m4 / 8.0 + 3.0 / 16.0 * m6 + 7.0 / 32.0 * m8;
            double a6 = m6 / 32.0 + m8 / 16.0;
            double a8 = m8 / 128.0;

            double X = a0 * B - a2 / 2.0 * Math.Sin(2 * B) + a4 / 4.0 * Math.Sin(4 * B) - a6 / 6.0 * Math.Sin(6 * B) + a8 / 8.0 * Math.Sin(8 * B);
            return X;
        }

        public static void xy2BL(double a, double e2, double L0, double x, double y, ref double b, ref double l)
        {
            //y -= 500000;
            double e1 = e2 / (1 - e2);
            double A = a * (1 - e2) * (1 + 3.0 / 4.0 * e2 + 45.0 / 64.0 * Math.Pow(e2, 2) + 175.0 / 256.0 * Math.Pow(e2, 3) + 11025.0 / 16384.0 * Math.Pow(e2, 4));
            double B = a * (1 - e2) * (3.0 / 4.0 * e2 + 45.0 / 64.0 * Math.Pow(e2, 2) + 175.0 / 256.0 * Math.Pow(e2, 3) + 11025.0 / 16384.0 * Math.Pow(e2, 4));
            double C = a * (1 - e2) * (15.0 / 32.0 * Math.Pow(e2, 2) + 175.0 / 384.0 * Math.Pow(e2, 3) + 3675.0 / 8192.0 * Math.Pow(e2, 4));
            double D = a * (1 - e2) * (35.0 / 96.0 * Math.Pow(e2, 3) + 735.0 / 2048.0 * Math.Pow(e2, 4));
            double E = a * (1 - e2) * (315.0 / 1024.0 * Math.Pow(e2, 4));
            double dBf = 10000;
            double Bf = 0;
            double Bf0 = x / A;
            while (Math.Abs(dBf) > 1e-20)
            {
                double FBf = -B * Math.Cos(Bf0) * Math.Sin(Bf0)
                    - C * Math.Cos(Bf0) * Math.Pow(Math.Sin(Bf0), 3)
                    - D * Math.Cos(Bf0) * Math.Pow(Math.Sin(Bf0), 5)
                    - E * Math.Cos(Bf0) * Math.Pow(Math.Sin(Bf0), 7);
                Bf = (x - FBf) / A;
                dBf = Bf - Bf0;
                Bf0 = Bf;
            }

            double Mf = a * (1 - e2) * Math.Pow(1 - e2 * Math.Pow(Math.Sin(Bf), 2), -1.5);
            double Nf = a * Math.Pow(1 - e2 * Math.Pow(Math.Sin(Bf), 2), -0.5);
            double tf = Math.Tan(Bf);
            double it2f = e1 * Math.Pow(Math.Cos(Bf), 2);
            b = Bf - tf / (2 * Mf * Nf) * y * y + tf / (24 * Mf * Math.Pow(Nf, 3)) * (5 + 3 * tf * tf + it2f - 9 * it2f * tf * tf) * Math.Pow(y, 4)
                - tf / (720.0 * Mf * Math.Pow(Nf, 5)) * (61 + 90 * tf * tf + 45 * Math.Pow(tf, 4)) * Math.Pow(y, 6);
            l = L0 + 1.00 / (Nf * Math.Cos(Bf)) * y - 1.0 / (6 * Math.Pow(Nf, 3) * Math.Cos(Bf)) * (1 + 2 * tf * tf + it2f) * Math.Pow(y, 3) +
                1.0 / (120.0 * Math.Pow(Nf, 5) * Math.Cos(Bf)) * (5 + 28 * tf * tf + 24 * tf * tf * tf * tf + 6 * it2f + 8 * it2f * tf * tf) * Math.Pow(y, 5);
        }

        public static void xy2BL(double a, double e2, double L0, double DH, double x, double y, ref double b, ref double l)
        {
            xy2BL(a, e2, L0, x, y, ref b, ref l);
            ///////////////////////////投影高程面引起的变化
            double e1 = e2 / (1 - e2);
            double W = Math.Sqrt(1 - e2 * Math.Sin(b) * Math.Sin(b));
            double V = Math.Sqrt(1 + e1 * Math.Cos(b) * Math.Cos(b));
            double M = a * (1 - e2) / Math.Pow(W, 3);
            //B = e * Math.Sin(B) * Math.Cos(B) * (1 - e * Math.Sin(B) * Math.Sin(B))/(M*W*Math.Sqrt(1-e))*DH+B;///以平均曲率半径变化推算长半轴变化
            double dB = e2 * Math.Sin(b) * Math.Cos(b) / (M) * DH;
            W = Math.Sqrt(1 - e2 * Math.Sin(b) * Math.Sin(b));
            V = Math.Sqrt(1 + e1 * Math.Cos(b) * Math.Cos(b));
            a = W * DH + a;///////以某点卯酉圈曲率半径变化推算长半轴变化，偏心率不变

            xy2BL(a, e2, L0, x, y, ref b, ref l);
            b = b - dB;
        }
    }

    public class CoorSysPars
    {
        public CoorSysPars() { }
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 原始坐标系名
        /// </summary>
        public string YSZBXM { set; get; }
        /// <summary>
        /// 目的坐标系名
        /// </summary>
        public string MDZBXM { set; get; }
        /// <summary>
        /// x方向上的平移参数（单位：米）
        /// </summary>
        public double X { set; get; }
        /// <summary>
        /// y方向上的平移参数(单位：米)
        /// </summary>
        public double Y { set; get; }
        /// <summary>
        /// z方向上的平移参数（单位：米）
        /// </summary>
        public double Z { set; get; }
        /// <summary>
        /// x轴旋转参数（单位：秒）
        /// </summary>
        public double aa { set; get; }
        /// <summary>
        /// y轴旋转参数（单位：秒）
        /// </summary>
        public double bb { set; get; }
        /// <summary>
        /// y轴旋转参数（单位：秒）
        /// </summary>
        public double cc { set; get; }
        /// <summary>
        /// 尺度参数（单位：ppm)
        /// </summary>
        public double m { set; get; }
        /// <summary>
        /// 原始坐标系椭球参数，长轴（单位：米）
        /// </summary>
        public double YSMajorAxis { set; get; }
        /// <summary>
        /// 原始坐标系椭球参数，扁率倒数
        /// </summary>
        public double YSf { set; get; }
        /// <summary>
        /// 目的坐标系椭球参数，长轴（单位：米）
        /// </summary>
        public double MDMajorAxis { set; get; }
        /// <summary>
        /// 目的坐标系椭球参数，扁率倒数
        /// </summary>
        public double MDf { set; get; }
        /// <summary>
        /// 投影参数，中央子午线（度分秒格式，例如 :  101.3000,101度30分）
        /// </summary>
        public double CMeridian { set; get; }
        /// <summary>
        /// 投影面抬高（单位，米）
        /// </summary>
        public double ProjElevation { set; get; }

    }
    /// <summary>
    /// 笛卡尔空间直角坐标结构体
    /// </summary>
    public class CARTESIAN
    {
        public CARTESIAN()
        {
            X = 0; Y = 0; Z = 0;
        }
        /// <summary>
        /// 地球空间直角坐标系的X
        /// </summary>
        public double X;
        /// <summary>
        /// 地球空间直角坐标系的Y
        /// </summary>
        public double Y;
        /// <summary>
        /// 地球空间直角坐标系的Z
        /// </summary>
        public double Z;
    }
    /// <summary>
    /// 大地坐标结构体，有一个写到ddd.mmssssssss格式字符串的方法
    /// </summary>
    public class GEODETIC
    {
        public GEODETIC()
        {
            latitude = 0;
            longitude = 0;
            height = 0; lat = 0; lon = 0;
        }
        private double latitude_;
        private double longitude_;
        /// <summary>
        /// 纬度B数值，以弧度表示
        /// </summary>
        public double latitude
        {
            set { this.latitude_ = value; }
            get { return this.latitude_; }
        }
        /// <summary>
        /// 经度L数值，以弧度表示
        /// </summary>
        public double longitude
        {
            set { this.longitude_ = value; }
            get { return this.longitude_; }
        }
        /// <summary>
        /// 纬度，度
        /// </summary>
        public double lat
        {
            set { this.latitude_ = value * Math.PI / 180; }
            get { return this.latitude_ * 180.0 / Math.PI; }
        }
        /// <summary>
        /// 经度，度
        /// </summary>
        public double lon
        {
            set { this.longitude_ = value * Math.PI / 180; }
            get { return this.longitude_ * 180.0 / Math.PI; }
        }
        /// <summary>
        /// 经度，度分秒
        /// </summary>
        public double londms
        {
            set { this.longitude_ = PostCoorTrans.Angle2Ration(value); }
            get { return PostCoorTrans.RationToAngle(longitude_); }
        }
        /// <summary>
        /// 纬度，度分秒
        /// </summary>
        public double latdms
        {
            set { this.latitude_ = PostCoorTrans.Angle2Ration(value); }
            get { return PostCoorTrans.RationToAngle(latitude_); }
        }

        /// <summary>
        /// 高度数值，以米表示
        /// </summary>
        public double height;
        /// <summary>
        /// 输出到ddd.mmsssssss格式的字符串
        /// </summary>
        /// <returns></returns>
        //        public string ToDMSFormatString()
        //        {
        //            int Bd, Bm, Ld, Lm;
        //            double Bs, Ls;
        //            double B, L;
        //            string Bstr, Lstr;
        //            char Bc, Lc;
        //
        //            // *******************************************************************************************
        //            B = this.latitude * Const.D2R;
        //            if (B < 0)
        //            {
        //                B = -B;
        //                Bc = 'S';
        //            }
        //            else
        //                Bc = 'N';
        //            Bd = (int)B;
        //            Bm = (int)((B - Bd) * 60.0);
        //            Bs = B * 3600.0 - Bm * 60.0;
        //            Bstr = Bd.ToString("D2") + " " + Bm.ToString("D2") + " " + Bs.ToString("F10.8") + " " + Bc.ToString();
        //
        //
        //            // *******************************************************************************************
        //            L = this.longitude * Const.D2R;
        //            if (L < 0)
        //            {
        //                L = -L;
        //                Lc = 'W';
        //            }
        //            else
        //                Lc = 'E';
        //            Ld = (int)L;
        //            Lm = (int)((L - Ld) * 60.0);
        //            Ls = L * 3600.0 - Lm * 60.0;
        //            Lstr = Ld.ToString("D2") + " " + Lm.ToString("D2") + " " + Ls.ToString("F10.8") + " " + Lc.ToString();
        //
        //            // *******************************************************************************************
        //            return Bstr + " " + Lstr + " " + this.height.ToString("F10.4");
        //
        //
        //        }
    }
    /// <summary>
    /// 平面坐标结构体
    /// </summary>
    public struct PLANECOOR
    {
        public double x;
        public double y;
        public double h;
    }

    class clsWinRar
    {
        /// <summary>
        /// 验证WinRar是否安装。
        /// </summary>
        /// <returns>true：已安装，false：未安装</returns>
        private static bool ExistsRar(out String winRarPath)
        {
            winRarPath = String.Empty;

            //通过Regedit（注册表）找到WinRar文件
            var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");

            if (registryKey == null) return false;//未安装

            //registryKey = theReg;可以直接返回Registry对象供会面操作
            winRarPath = registryKey.GetValue("").ToString();//这里为节约资源，直接返回路径，反正下面也没用到

            registryKey.Close();//关闭注册表

            return !String.IsNullOrEmpty(winRarPath);
        }

        /// <summary>
        /// 生成Zip
        /// </summary>
        /// <param name="fileDirectory">文件夹路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="rarDirectory">压缩文件的存放文件夹路径</param>
        /// <param name="rarName">生成压缩文件的文件名</param>
        public static bool CompressRar(string FilePath, string RarPath = "", string password = "")
        {
            try
            {
                int n = FilePath.Trim().Length;
                string SaveFileName = FilePath;//.Substring(0, n - 2);
                SaveFileName = SaveFileName + ".rar";
                string[] ObsPath = new string[1];
                ObsPath[0] = FilePath;
                string error = "";
                if (
                MyPackage.Pack11(ObsPath, SaveFileName, 5, password, out error))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception er)
            {
                return false;
                throw er;
            }
            //调用rar打压缩
            //if(RarPath=="")
            //{
            //    RarPath=Path.ChangeExtension(FilePath,"zip");
            //}
            //string fileDirectory=Path.GetDirectoryName(FilePath);
            //string fileName=Path.GetFileName(FilePath);			
            //string rarDirectory=Path.GetDirectoryName(RarPath);
            //string rarName=Path.GetFileName(RarPath);
            //try
            //{
            //    String winRarPath = null;
            //    if (!ExistsRar(out winRarPath)) return;//验证WinRar是否安装。

            //    var pathInfo="";
            //    if(String.IsNullOrWhiteSpace(password)&&String.IsNullOrEmpty(password))
            //    {
            //        pathInfo ="a -afzip -ep1 -ibck -m3 -as -r "+rarName+" "+FilePath;
            //    }
            //    else
            //    {
            //        pathInfo ="a -afzip -ep1 -ibck -m3 -as -r -p"+password+" "+rarName+" "+FilePath;
            //    }

            //    #region WinRar 用到的命令注释

            //    //[a] 添加到压缩文件
            //    //afzip 执行zip压缩方式，方便用户在不同环境下使用。（取消该参数则执行rar压缩）
            //    //-m0 存储 添加到压缩文件时不压缩文件。共6个级别【0-5】，值越大效果越好，也越慢
            //    //ep1 依名称排除主目录（生成的压缩文件不会出现不必要的层级）
            //    //r   修复压缩档案
            //    //t   测试压缩档案内的文件
            //    //as  同步压缩档案内容
            //    //-p  给压缩文件加密码方式为：-p123456

            //    #endregion

            //    if(Directory.Exists(rarDirectory)==false)
            //    {
            //        Directory.CreateDirectory(rarDirectory);
            //    }

            //    //打包文件存放目录
            //    var process = new Process
            //    {
            //        StartInfo = new ProcessStartInfo
            //        {
            //            FileName = winRarPath,//执行的文件名
            //            Arguments = pathInfo,//需要执行的命令
            //            UseShellExecute = false,//使用Shell执行
            //            WindowStyle = ProcessWindowStyle.Hidden,//隐藏窗体
            //            WorkingDirectory = rarDirectory,//rar 存放位置
            //            CreateNoWindow = false,//不显示窗体
            //        },
            //    };
            //    process.Start();//开始执行
            //    process.WaitForExit();//等待完成并退出
            //    process.Close();//关闭调用 cmd 的什么什么
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


    }
}