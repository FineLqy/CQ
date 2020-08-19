using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CORSV2
{
    public struct Canshu
    {
        public double dx, dy, dz;///////转换参数
        public double m0;      ///////尺度变化因子
        public double Qx, Qy, Qz;////旋转角
    }
    public struct Coordinates
    {
        public string name;
        public double X, Y, Z;
    }
    public class CoorTrans
    {
        public Coordinates OriginalCoor;
        public Coordinates TransCoor;
        public Canshu cs;                      //////从原始坐标系转换到目标坐标系的参数
        public Canshu cs1;                    /////从原始坐标系转换到过渡坐标系的参数
        public Canshu cs2;                    /////从过渡坐标系到目标坐标系的参数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CoorTrans()
        { }
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="cs1"></param>
        public void SetCanshu(Canshu cs0)
        {
            cs = new Canshu();
            cs = cs0;
        }
        /// <summary>
        /// 由平移量计算过渡参数
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        public void CalCanshu(double dx, double dy, double dz)
        {
            /////1.计算由原始坐标系到过渡坐标系的参数(由于小量平移引起)
            cs1 = new Canshu();
            cs1.dx -= dx;
            cs1.dy -= dy;
            cs1.dz -= dz;
            cs1.m0 = 0;
            cs1.Qx = 0;
            cs1.Qy = 0;
            cs1.Qz = 0;
            /////2.计算过渡坐标系到目标坐标的参数
            cs2 = cs;
            cs2.dx += dx;
            cs2.dy += dy;
            cs2.dz += dz;
        }

        /// <summary>
        /// 由平移量计算过渡参数
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        public void CalCanshu(double dx, double dy, double dz, double da, double db, double dc)
        {
            /////1.计算由原始坐标系到过渡坐标系的参数(由于小量平移引起)
            cs1 = new Canshu();
            cs1.dx -= dx;
            cs1.dy -= dy;
            cs1.dz -= dz;
            cs1.m0 = 0;
            cs1.Qx -= da;
            cs1.Qy -= db;
            cs1.Qz -= dc;
            /////2.计算过渡坐标系到目标坐标的参数
            cs2 = cs;
            cs2.dx += dx;
            cs2.dy += dy;
            cs2.dz += dz;
            cs2.Qx += da;
            cs2.Qy += db;
            cs2.Qz += dc;
        }

        /// <summary>
        /// 单个坐标转换
        /// </summary>
        /// <param name="ocoor"></param>
        /// <param name="css"></param>
        /// <param name="tcoor"></param>
        /// <returns></returns>
        public bool CoorTran(Coordinates ocoor, Canshu css, ref Coordinates tcoor)
        {
            Matrix XYZ_T = new Matrix(3, 1);                 //////转换后的坐标
            Matrix XYZ_S = new Matrix(3, 1);                 //////转换前的坐标
            Matrix Q_xyz = new Matrix(3, 3);                   ///////旋转矩阵
            Matrix d_xyz = new Matrix(3, 1);                    ///////平移矩阵
            try
            {
                ///////////////////平移矩阵赋值
                d_xyz[0, 0] = css.dx;
                d_xyz[1, 0] = css.dy;
                d_xyz[2, 0] = css.dz;
                //////////////////旋转矩阵赋值
                Q_xyz[0, 0] = Q_xyz[1, 1] = Q_xyz[2, 2] = 1;
                Q_xyz[0, 1] = css.Qz;
                Q_xyz[1, 0] = -css.Qz;
                Q_xyz[0, 2] = -css.Qy;
                Q_xyz[2, 0] = css.Qy;
                Q_xyz[1, 2] = css.Qx;
                Q_xyz[2, 1] = -css.Qx;
                ///////////////初始坐标矩阵赋值
                XYZ_S[0, 0] = ocoor.X;
                XYZ_S[1, 0] = ocoor.Y;
                XYZ_S[2, 0] = ocoor.Z;
                /////////////////计算转换后的坐标
                XYZ_T = d_xyz + (1 + css.m0) * (Q_xyz * XYZ_S);
                tcoor.X = XYZ_T[0, 0];
                tcoor.Y = XYZ_T[1, 0];
                tcoor.Z = XYZ_T[2, 0];
                tcoor.name = ocoor.name;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 批量坐标转换
        /// </summary>
        /// <param name="ocoors"></param>
        /// <param name="tcoors"></param>
        /// <returns></returns>
        public bool CoorTran(Coordinates[] ocoors,Canshu css, Coordinates[] tcoors)
        {
            for (int i = 0; i < ocoors.Length; i++)
            {
                Coordinates coor = new Coordinates();
                bool issucceed;
                issucceed = CoorTran(ocoors[i], css,ref coor);
                if (issucceed)
                {
                    tcoors[i] = coor;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class CoorT
    {
        public struct XYZorBLH
        {
            public string name;
            public double XB, YL, ZH;
        }
        /// <summary>
        /// /////////////////变量
        /// </summary>
        public string path;
        public List<XYZorBLH> XB = new List<XYZorBLH>();///////存储待转换的点的坐标
        public XYZorBLH[] Result;
        public XYZorBLH xb = new XYZorBLH();
        public XYZorBLH result = new XYZorBLH();
        public double a = 6378137, e = 0.00669438002290079; ////////限定使用WGS-84坐标转换
        public CoorT()
        {
        }
        public CoorT(string file)
        {
            path = file;
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            XYZorBLH t;
            while (sr.Peek() != -1)
            {
                string[] temp = sr.ReadLine().Trim().Split(',');
                t.name = temp[0];
                t.XB = Convert.ToDouble(temp[1]);
                t.YL = Convert.ToDouble(temp[2]);
                t.ZH = Convert.ToDouble(temp[3]);
                XB.Add(t);
            }
        }
        public double hudu2jiaodu(double hudu)
        {
            double t = 0, t1 = 0, t2;
            t1 = t = hudu * 180 / Math.PI;
            t = Math.Floor(t1);//整度
            t1 = t1 - t;
            t2 = t1 = t1 * 60;
            t1 = Math.Floor(t1);//整分
            t2 = t2 - t1;
            t2 = t2 * 60;/////秒
            t = t + t1 / 100 + t2 / 10000;
            return t;
        }
        public double du2hudu(double du)
        {
            double t = 0, t1 = 0, t2 = 0;
            t = Math.Floor(du);///正度
            t1 = Math.Floor((du - t) * 100);///整分
            t2 = du * 10000 - t * 10000 - t1 * 100;///秒为单位
            return (t + t1 / 60 + t2 / 3600) / 180 * Math.PI;
        }
        public void XYZ2BLH()
        {
            Result = new XYZorBLH[XB.Count];
            for (int i = 0; i < XB.Count; i++)
            {
                Result[i].YL = Math.Acos(XB[i].XB / Math.Sqrt(XB[i].XB * XB[i].XB + XB[i].YL * XB[i].YL));
                double t0 = 0, t1 = 0;
                t0 = XB[i].ZH / Math.Sqrt(XB[i].XB * XB[i].XB + XB[i].YL * XB[i].YL);
                double b = a * Math.Sqrt(1 - e);
                double c = a * a / b;
                double e1 = e / (1 - e);////e1为e'的平方
                t1 = t0 + c * e * t0 * t0 / XB[i].ZH / Math.Sqrt(1 + e1 + t0 * t0);
                while (t1 - t0 > 0.000001)
                {
                    t0 = t1;
                    t1 = XB[i].ZH / Math.Sqrt(XB[i].XB * XB[i].XB + XB[i].YL * XB[i].YL) + c * e * t0 / (Math.Sqrt(XB[i].XB * XB[i].XB + XB[i].YL * XB[i].YL) * Math.Sqrt(1 + e1 + t0 * t0));
                }
                Result[i].XB = Math.Atan(t1);
                double W = Math.Sqrt(1 - e * Math.Sin(Result[i].XB) * Math.Sin(Result[i].XB));
                double N = a / W;
                Result[i].ZH = Math.Sqrt(XB[i].XB * XB[i].XB + XB[i].YL * XB[i].YL) / Math.Cos(Result[i].XB) - N;
                Result[i].XB = hudu2jiaodu(Result[i].XB);
                Result[i].YL = hudu2jiaodu(Result[i].YL);
            }
        }
        public void BLH2XYZ()
        {
            Result = new XYZorBLH[XB.Count];
            for (int i = 0; i < XB.Count; i++)
            {
                double W = Math.Sqrt(1 - e * Math.Pow(Math.Sin(du2hudu(XB[i].XB)), 2));
                double N = a / W;
                Result[i].XB = (N + XB[i].ZH) * Math.Cos(du2hudu(XB[i].XB)) * Math.Cos(du2hudu(XB[i].YL));
                Result[i].YL = (N + XB[i].ZH) * Math.Cos(du2hudu(XB[i].XB)) * Math.Sin(du2hudu(XB[i].YL));
                Result[i].ZH = (N * (1 - e) + XB[i].ZH) * Math.Sin(du2hudu(XB[i].XB));
            }

        }
        /// <summary>
        /// ct在使用前必须设置参数和计算参数先，否则不能用
        /// </summary>
        /// <param name="ocoor"></param>
        /// <param name="ct"></param>
        /// <param name="tcoor"></param>h 为正常高
        /// <returns>计算得到的tcoor为过渡坐标系坐标可以发送出去，用户再进行一次转换</returns>
        public bool ModifyCoor(Coordinates ocoor, CoorTrans ct, double h, ref Coordinates tcoor)
        {
            try
            {
                Coordinates coor = new Coordinates();
                Coordinates coord = new Coordinates();
                if (ct.CoorTran(ocoor, ct.cs, ref coor))
                {
                    xb.name = coor.name;
                    xb.XB = coor.X;
                    xb.YL = coor.Y;
                    xb.ZH = coor.Z;
                    XB.Add(xb);
                    a = 6378245; e = 0.006693421622966;//BJ54的椭球参数
                    XYZ2BLH();
                    double dh = h - Result[0].ZH;  //////计算得到的高程补偿
                    //////////修改vrs的大地高
                    XB.Clear();
                    xb.name = ocoor.name;
                    xb.XB = ocoor.X;
                    xb.YL = ocoor.Y;
                    xb.ZH = ocoor.Z;
                    XB.Add(xb);
                    a = 6378137; e = 0.00669438002290079;
                    XYZ2BLH();          /////把VRS的坐标转化为大地坐标
                    Result[0].ZH += dh; /////把VRS的大地高加上高程补偿
                    XB.Clear();
                    XB.Add(Result[0]);
                    BLH2XYZ();                  //////把修改后的VRS换算到空间直角坐标
                    coor.name = Result[0].name;
                    coor.X = Result[0].XB;
                    coor.Y = Result[0].YL;
                    coor.Z = Result[0].ZH;
                    ct.CoorTran(coor, ct.cs1, ref  tcoor);
                    //ct.CoorTran(tcoor, ct.cs2, ref coord);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
