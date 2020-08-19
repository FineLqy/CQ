using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CORSV2
{
    public struct TIME
    {
        public int wYear;
        public int byMonth;
        public int byDay;
        public int byHour;
        public int byMinute;
        public double dSecond;
        public char byDayOfWeek;
    }

    public struct JULIANDAY
    {
        public long lDay;
        public long lSecond;
        public double dFraction;
    }

    public struct GPSTIME
    {
        public long lWeek;
        public long lSecond;
        public double dFraction;
    }

    public class time
    {
        /// <summary>
        /// 日历时转儒略日
        /// </summary>
        public static void tmTimeToJulianDay(ref TIME pTime, ref JULIANDAY pJulianDay)
        {
            int m;
            int y;
            double ut;

            tmTimeToJulianDay2(ref pTime, ref pJulianDay);

            ut = pTime.byHour + pTime.byMinute / 60.0 + pTime.dSecond / 3600.0;

            if (pTime.byMonth <= 2)
            {
                y = pTime.wYear - 1;
                m = pTime.byMonth + 12;
            }
            else
            {
                y = pTime.wYear;
                m = pTime.byMonth;
            }

            pJulianDay.lDay = (long)(365.25 * y) + (long)(30.6001 * (m + 1)) + pTime.byDay
                + (long)(ut / 24 + 1720981.5);
            pJulianDay.lSecond = ((pTime.byHour + 12) % 24) * 3600L + pTime.byMinute * 60L
                + (long)pTime.dSecond;
            pJulianDay.dFraction = pTime.dSecond - (long)pTime.dSecond;
        }

        private static void tmTimeToJulianDay2(ref TIME pTime, ref JULIANDAY pJulianDay)
        {
            double UT;

            long Y;
            long M;
            long D;

            Y = pTime.wYear;
            M = pTime.byMonth;
            D = pTime.byDay;
            UT = pTime.byHour + pTime.byMinute / 60.0 + pTime.dSecond / 3600.0;

            pJulianDay.lDay =
                (long)(367 * Y)
                - (long)(7 * (Y + (long)((M + 9) / 12)) / 4)
                - (long)(3 * ((long)((Y + (M - 9) / 7) / 100) + 1) / 4)
                + (long)(275 * M / 9) + D + (long)(1721028.5 + UT / 24);

            pJulianDay.lSecond = ((pTime.byHour + 12) % 24) * 3600L + pTime.byMinute * 60L
                + (long)pTime.dSecond;
            pJulianDay.dFraction = pTime.dSecond - (long)pTime.dSecond;
        }

        /// <summary>
        /// 儒略日转日历时
        /// </summary>
        public static void tmJulianDayToTime(ref JULIANDAY pJulianDay, ref TIME pTime)
        {
            long a;
            long b;
            long c;
            long d;
            long e;
            double dTemp;
            long lTemp;

            dTemp = pJulianDay.lDay + (double)(pJulianDay.lSecond + pJulianDay.dFraction) / 86400.0;
            lTemp = (pJulianDay.lSecond + 43200L) % 86400L;

            a = (long)(dTemp + 0.5);
            b = a + 1537;
            c = (long)((b - 122.1) / 365.25);
            d = (long)(365.25 * c);
            e = (long)((b - d) / 30.60001);

            pTime.byHour = (char)(lTemp / 3600L);
            pTime.byMinute = (char)(lTemp % 3600L / 60L);
            pTime.dSecond = lTemp % 3600L % 60L + pJulianDay.dFraction;
            pTime.byDay = (char)(b - d - (long)(30.6001 * e));
            pTime.byMonth = (char)(e - 1 - 12 * (long)(e / 14));
            pTime.wYear = Convert.ToInt32(c - 4715 - (long)((7 + pTime.byMonth) / 10));
            pTime.byDayOfWeek = Convert.ToChar(((long)(dTemp + 0.5) % 7 + 1) % 7);
        }

        /// <summary>
        /// 日历时转GPS时间
        /// </summary>
        public static void tmTimeToGPSTime(ref TIME pTime, ref GPSTIME pGPSTime)
        {
            JULIANDAY jd;
            double dTemp;
            long lTemp;

            jd.dFraction = 0.0;
            jd.lDay = 0;
            jd.lSecond = 0;

            tmTimeToJulianDay(ref pTime, ref jd);
            dTemp = jd.lDay + (double)(jd.lSecond + jd.dFraction) / 86400.0;
            lTemp = (long)(dTemp - 2444244.5);

            pGPSTime.lWeek = (long)((lTemp) / 7);
            pGPSTime.lSecond = (long)(lTemp % 7 * 86400L) + pTime.byHour * 3600L
                + pTime.byMinute * 60L + (long)pTime.dSecond;
            pGPSTime.dFraction = pTime.dSecond - (long)pTime.dSecond;

        }

        /// <summary>
        /// GPS时间转日历时
        /// </summary>
        public static void tmGPSTimeToTime(ref GPSTIME pGPSTime, ref TIME pTime)
        {
            JULIANDAY jd;
            double dTemp;

            dTemp = pGPSTime.lWeek * 7L + (double)pGPSTime.lSecond / 86400.0
                + pGPSTime.dFraction / 86400.0;

            jd.lDay = (long)(dTemp + 2444244.5);
            jd.lSecond = (pGPSTime.lSecond % 86400 + 43200L) % 86400L;
            jd.dFraction = pGPSTime.dFraction;

            tmJulianDayToTime(ref jd, ref  pTime);
        }

        /// <summary>
        /// 儒略日转GPS时间
        /// </summary>
        public static void tmJulianDayToGPSTime(JULIANDAY pJulianDay, GPSTIME pGPSTime)
        {
            double dTemp;
            long lTemp;

            dTemp = pJulianDay.lDay +
                (double)(pJulianDay.lSecond + pJulianDay.dFraction) / 86400.0;
            lTemp = (long)(dTemp - 2444244.5);

            pGPSTime.lWeek = (long)((lTemp) / 7);
            pGPSTime.lSecond = (long)(lTemp % 7 * 86400L)
                + (pJulianDay.lSecond + 43200L) % 86400L;
            pGPSTime.dFraction = pJulianDay.dFraction;
        }

        /// <summary>
        /// GPS时间转儒略日
        /// </summary>
        public static void tmGPSTimeToJulianDay(GPSTIME pGPSTime, JULIANDAY pJulianDay)
        {
            double dTemp;

            dTemp = pGPSTime.lWeek * 7L + (double)pGPSTime.lSecond / 86400.0
                + pGPSTime.dFraction;

            pJulianDay.lDay = (long)(dTemp + 2444244.5);
            pJulianDay.lSecond = (pGPSTime.lSecond % 86400 + 43200L) % 86400L;
            pJulianDay.dFraction = pGPSTime.dFraction;
        }
    }
}
