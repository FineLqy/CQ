using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
namespace CORSV2.cs
{
    public class Geoid
    {
        public Geoid()
        {
            GeoidEle = new Hashtable();
        }
        public struct BLH
        {
            public double B;
            public double L;
            public double H;
        }
        public Hashtable GeoidEle;
        /// <summary>
        /// 读入格网数据
        /// </summary>
        /// <returns></returns>
        public bool ReadGrid(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                BLH blh = new BLH();
                double StratB = 0, StartL = 0;
                string linedata = "";
                int HS = 0;
                while (sr.Peek() != -1)
                {
                    linedata = sr.ReadLine(); HS = HS + 1;
                    if (linedata == null)
                    {
                        break;
                    }
                    else if (linedata.Trim() == "")
                    {
                        break;
                    }
                    string[] line = AES_Key.AESDecrypt(linedata, ("xcq" + HS.ToString()).PadLeft(16, '0')).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    StratB = Convert.ToDouble(line[0]) * 60 - 1;
                    StartL = Convert.ToDouble(line[1]) * 60 + 1;
                    if (!GeoidEle.ContainsKey(StratB))
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            double B = 0;
                            linedata = sr.ReadLine(); HS = HS + 1;
                            line = AES_Key.AESDecrypt(linedata, ("xcq" + HS.ToString()).PadLeft(16, '0')).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            B = StratB - i * 2.0;
                            Hashtable ht = new Hashtable();
                            for (int j = 0; j < 30; j++)
                            {
                                double L = 0;
                                L = StartL + j * 2.0;
                                blh.B = B;
                                blh.L = L;
                                blh.H = Convert.ToDouble(line[j]);
                                ht.Add(blh.L, blh.H);
                            }
                            GeoidEle.Add(B, ht);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            double B = 0;
                            linedata = sr.ReadLine(); HS = HS + 1;
                            line = AES_Key.AESDecrypt(linedata, ("xcq" + HS.ToString()).PadLeft(16, '0')).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            B = StratB - i * 2.0;
                            Hashtable htt = new Hashtable();
                            htt = (Hashtable)GeoidEle[B];
                            GeoidEle.Remove(B);
                            for (int j = 0; j < 30; j++)
                            {
                                double L = 0;
                                L = StartL + j * 2.0;
                                blh.B = B;
                                blh.L = L;
                                blh.H = Convert.ToDouble(line[j]);
                                if (!htt.Contains(L))
                                {
                                    htt.Add(L, blh.H);
                                }
                                else
                                {
                                    if (Convert.ToDouble(htt[L]) == 9999.0 && blh.H != 9999.0)
                                    {
                                        htt[L] = blh.H;
                                    }
                                }
                            }
                            GeoidEle.Add(B, htt);
                        }
                    }
                }
                sr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取格网数据
        /// </summary>
        /// <param name="B">单位为分</param>
        /// <param name="L">单位为分</param>
        /// <param name="f11"></param>
        /// <param name="f12"></param>
        /// <param name="f21"></param>
        /// <param name="f22"></param>
        /// <returns></returns>
        public bool GetGridPoints(double B, double L, ref BLH f11, ref BLH f12, ref BLH f21, ref BLH f22)
        {
            try
            {
                double L1, B1, L2, B2;
                if (Math.Floor(L) % 2 == 1)
                {
                    L1 = Math.Floor(L);
                    L2 = L1 + 2;
                }
                else
                {
                    L1 = Math.Floor(L) - 1;
                    L2 = L1 + 2;
                }
                if (Math.Floor(B) % 2 == 1)
                {
                    B1 = Math.Floor(B);
                    B2 = Math.Floor(B) + 2;
                }
                else
                {
                    B1 = Math.Floor(B) - 1;
                    B2 = B1 + 2;
                }
                f11.B = B1; f11.L = L1;
                Hashtable hstb = new Hashtable();
                hstb = (Hashtable)GeoidEle[f11.B];
                f11.H = (double)hstb[f11.L];

                f12.B = B2; f12.L = L1;
                hstb = new Hashtable();
                hstb = (Hashtable)GeoidEle[f12.B];
                f12.H = (double)hstb[f12.L];

                f22.B = B2; f22.L = L2;
                hstb = new Hashtable();
                hstb = (Hashtable)GeoidEle[f22.B];
                f22.H = (double)hstb[f22.L];

                f21.B = B1; f21.L = L2;
                hstb = new Hashtable();
                hstb = (Hashtable)GeoidEle[f21.B];
                f21.H = (double)hstb[f21.L];
                //if (f11.H == 9999 || f12.H == 9999 || f21.H == 9999 || f22.H == 9999)
                //{
                //    return false;
                //}
                return true;
            }
            catch
            {
                return false;
            }
        }
        public double BilinearInterpolation(BLH f11, BLH f12, BLH f21, BLH f22, double B, double L)
        {
            if (f11.L == f12.L && f12.B == f22.B && f11.B == f21.B)
            {
                if (f11.H == 9999 || f12.H == 9999 || f21.H == 9999 || f22.H == 9999)
                {
                    return 999999999;
                }
                double L1 = f11.L;
                double L2 = f21.L;
                double B1 = f11.B;
                double B2 = f22.B;
                BLH fR1 = new BLH();
                BLH fR2 = new BLH();
                fR1.L = L; fR1.B = B1;
                fR1.H = ((L2 - L) / (L2 - L1)) * f11.H + ((L - L1) / (L2 - L1)) * f21.H;//f21
                fR2.L = L; fR2.B = B2;
                fR2.H = ((L2 - L) / (L2 - L1)) * f12.H + ((L - L1) / (L2 - L1)) * f22.H;
                double fp = 0;
                fp = ((B2 - B) / (B2 - B1)) * fR1.H + ((B - B1) / (B2 - B1)) * fR2.H;
                return fp;
            }
            else
            {
                return 999999999;
            }
        }

        public double IDWInterpolation(List<BLH> fl, double B, double L)
        {
            double res = 0;
            if (fl.Count > 1)
            {
                double zw = 0;
                foreach (BLH f in fl)
                {
                    zw += 1.0 / Math.Sqrt((f.B - B) * (f.B - B) + (f.L - L) * (f.L - L));
                }

                foreach (BLH f in fl)
                {
                    res += 1.0 / Math.Sqrt((f.B - B) * (f.B - B) + (f.L - L) * (f.L - L)) / zw * f.H;
                }
            }
            return res;

        }

        /// <summary>
        ///给出大地经纬度内插正常高
        /// </summary>
        /// <param name="B">分为单位</param>
        /// <param name="L">分为单位</param>
        /// <returns></returns>
        public bool GetGeoidH(double B, double L, ref double H)
        {
            try
            {
                BLH f11 = new BLH();
                BLH f12 = new BLH();
                BLH f21 = new BLH();
                BLH f22 = new BLH();
                if (GetGridPoints(B, L, ref f11, ref f12, ref f21, ref f22))
                {
                    int num = 0;
                    List<BLH> fl = new List<BLH>();
                    if (f11.H == 9999.0)
                    {
                        num += 1;
                    }
                    else
                    {
                        fl.Add(f11);
                    }
                    if (f12.H == 9999.0)
                    {
                        num += 1;
                    }
                    else
                    {
                        fl.Add(f12);
                    }
                    if (f21.H == 9999.0)
                    {
                        num += 1;
                    }
                    else
                    {
                        fl.Add(f21);
                    }
                    if (f22.H == 9999.0) { num += 1; }
                    else
                    {
                        fl.Add(f22);
                    }
                    if (num == 4)
                    {
                        H = BilinearInterpolation(f11, f12, f21, f22, B, L);
                    }
                    else if (num <= 1)
                    {
                        return false;
                    }
                    else
                    {
                        H = IDWInterpolation(fl, B, L);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///给出大地经纬度内插正常高
        /// </summary>
        /// <param name="B">度分秒为单位</param>
        /// <param name="L">度分秒为单位</param>
        /// <returns></returns>
        public bool GetGeoidH_dms(double B, double L, ref double H)
        {
            double BDu = Math.Floor(B);
            double BFen = Math.Floor((B - BDu) * 100);
            double BMiao = ((B - BDu) * 100 - BFen) * 100;
            B = BDu * 60 + BFen + BMiao / 60.0;
            double LDu = Math.Floor(L);
            double LFen = Math.Floor((L - LDu) * 100);
            double LMiao = ((L - LDu) * 100 - LFen) * 100;
            L = LDu * 60 + LFen + LMiao / 60.0;
            try
            {
                BLH f11 = new BLH();
                BLH f12 = new BLH();
                BLH f21 = new BLH();
                BLH f22 = new BLH();
                if (GetGridPoints(B, L, ref f11, ref f12, ref f21, ref f22))
                {
                    int num = 0;
                    List<BLH> fl = new List<BLH>();
                    if (f11.H == 9999.0)
                    {
                        num += 1;
                    }
                    else
                    {
                        fl.Add(f11);
                    }
                    if (f12.H == 9999.0)
                    {
                        num += 1;
                    }
                    else
                    {
                        fl.Add(f12);
                    }
                    if (f21.H == 9999.0)
                    {
                        num += 1;
                    }
                    else
                    {
                        fl.Add(f21);
                    }
                    if (f22.H == 9999.0) { num += 1; }
                    else
                    {
                        fl.Add(f22);
                    }
                    if (num == 0)
                    {
                        H = BilinearInterpolation(f11, f12, f21, f22, B, L);
                    }
                    else if (num >= 3)
                    {
                        return false;
                    }
                    else
                    {
                        H = IDWInterpolation(fl, B, L);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}