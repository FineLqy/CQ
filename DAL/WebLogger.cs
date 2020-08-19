using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DAL

{
    public static class WebLogger
    {
         /// <summary>
        /// 日志文件路径
        /// </summary>
        private static string logFilePath = string.Empty;
 
        static WebLogger()
        {
            Init();
        }
 
        private static void Init()
        {
            logFilePath = "C:\\Web错误日志" + "\\" + string.Format("{0:yyyyMMdd}", DateTime.Now) + ".log";//设置文件路径及文件名称
            if (!File.Exists(logFilePath))
            {
                FileStream fs = File.Create(logFilePath);
                fs.Close();
            }
 
        }
        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="erro">错误信息</param>
        public static void WriteErroLog(string erro)
        {
            try
            {
                FileStream fileStream = File.Open(logFilePath, FileMode.Append);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream, System.Text.Encoding.Default);
                sw.WriteLine("【 " + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "】:  " + erro);
                sw.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("添加日志异常" + ex.ToString());
            }
        }

    }
}