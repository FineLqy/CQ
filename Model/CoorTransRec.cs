using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CoorTransRec
    {
        public CoorTransRec()
        {
            ProjectName = "";
            ResultPath = "";
           
        }

        public int ID { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 所属单位
        /// </summary>
        public string Company { set; get; }
        /// <summary>
        /// 数据处理类型（例如BLH-h）
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 数据处理时间
        /// </summary>
        public DateTime Time { set; get; }
        /// <summary>
        /// 数据处理结果
        /// </summary>
        public string Result { set; get; }
        /// <summary>
        /// 备注 转换类型 如 DXF文件转换
        /// </summary>
        public string Remark { set; get; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { set; get; }
        /// <summary>
        /// 数据处理任务量（比如坐标转换的点数目）
        /// </summary>
        public double Amount { set; get; }
        /// <summary>
        /// 所花费用
        /// </summary>
        public double Cost { set; get; }
        /// <summary>
        /// 结果文件路径
        /// </summary>
        public string ResultPath { set; get; }
    }
}
