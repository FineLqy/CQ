using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 坐标系统参数
    /// </summary>
    public class OCoorSysPars
    {
        public OCoorSysPars() { }

        private int ID_;
        private string YSZBXM_;
        private string MDZBXM_;
        private double X_;
        private double Y_;
        private double Z_;
        private double aa_;
        private double bb_;
        private double cc_;
        private double m_;
        private double YSMajorAxis_;
        private double YSe2_;
        private double MDMajorAxis_;
        private double MDe2_;
        /// <summary>
        /// 原始坐标系备注名
        /// </summary>
        public string YSRemarkName { set; get; }
        /// <summary>
        /// 目的坐标系备注名
        /// </summary>
        public string MDRemarkName { set; get; }
        /// <summary>
        /// 原始坐标系椭球扁率倒数
        /// </summary>
        public double YSDAlpha { set; get; }
        /// <summary>
        /// 原始坐标系椭球扁率倒数
        /// </summary>
        public double MDDAlpha { set; get; }
        /// <summary>
        /// 中央子午线，度分秒
        /// </summary>
        public double CMeridian { set; get; }
        /// <summary>
        /// 投影抬高（单位m）
        /// </summary>
        public double ProjElevation { set; get; }
        /// <summary>
        /// 原点北（m）
        /// </summary>
        public double OriginNorth { set; get; }
        /// <summary>
        /// 原点东（m）
        /// </summary>
        public double OriginEast { set; get; }

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
        /// 作业区域限定
        /// </summary>
        public int AreaID { set; get; }
        /// <summary>
        /// x方向上的平移参数（单位：米）
        /// </summary>
        public double X
        {
            set
            {
                X_ = value ;
            }
            get
            {
                return X_;
            }
        }
        /// <summary>
        /// y方向上的平移参数(单位：米)
        /// </summary>
        public double Y
        {
            set
            {
                Y_ = value ;
            }
            get
            {
                return Y_;
            }
        }
        /// <summary>
        /// z方向上的平移参数（单位：米）
        /// </summary>
        public double Z
        {
            set
            {
                Z_ = value ;
            }
            get
            {
                return Z_;
            }

        }
        /// <summary>
        /// x轴旋转参数（单位：秒）
        /// </summary>
        public double aa
        {
            set
            {
                aa_ = value ;
            }
            get
            {
                return aa_;
            }
        }
        /// <summary>
        /// y轴旋转参数（单位：秒）
        /// </summary>
        public double bb
        {
            set
            {
                bb_ = value ;
            }
            get
            {
                return bb_;
            }
        }
        /// <summary>
        /// y轴旋转参数（单位：秒）
        /// </summary>
        public double cc
        {
            set
            {
                cc_ = value ;
            }
            get
            {
                return cc_;
            }
        }
        /// <summary>
        /// 尺度参数（单位：ppm)
        /// </summary>
        public double m
        {
            set
            {
                m_ = value ;
            }
            get
            {
                return m_;
            }
        }
        /// <summary>
        /// 原始坐标系椭球参数，长轴（单位：米）
        /// </summary>
        public double YSMajorAxis
        {
            set
            {
                YSMajorAxis_ = value ;
            }
            get
            {
                return YSMajorAxis_;
            }
        }
        /// <summary>
        /// 原始坐标系椭球参数，偏心率的平方
        /// </summary>
        public double YSe2
        {
            set
            {
                YSe2_ = value ;
            }
            get
            {
                return YSe2_;
            }
        }
        /// <summary>
        /// 目的坐标系椭球参数，长轴（单位：米）
        /// </summary>
        public double MDMajorAxis
        {
            set
            {
                MDMajorAxis_ = value ;
            }
            get
            {
                return MDMajorAxis_;
            }
        }
        /// <summary>
        /// 目的坐标系椭球参数，偏心率的平方
        /// </summary>
        public double MDe2
        {
            set
            {
                MDe2_ = value ;
            }
            get
            {
                return MDe2_;
            }
        }
    }
}
