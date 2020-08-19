using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORSV2.cs
{
    public class HideCharShow
    {
        /// <summary>
        /// 通过长度生成遮盖字段如****
        /// </summary>
        /// <param name="program_StarLen">长度如4</param>
        /// <param name="program_StarChar">遮盖符号如*</param>
        /// <returns></returns>
        public static string StarCharShow(int program_StarLen, string program_StarChar)
        {
            string program_StarCharShow = "";
            for (int i = 0; i < program_StarLen; i++)
            {
                program_StarCharShow = program_StarCharShow + program_StarChar;
            }
            return program_StarCharShow;
        }
        /// <summary>
        /// 特殊符号遮盖
        /// </summary>
        /// <param name="str">拟遮盖字符全字段</param>
        /// <param name="program_starBegin">开始位</param>
        /// <param name="program_starEnd">结束位</param>
        /// <param name="program_StarCharShow">遮盖组合符号</param>
        /// <returns></returns>
        public static string StrReplaceByStar(string str, int program_starBegin, int program_starEnd, string program_StarChar)
        {
            string NewStr = "";
            string a = "";
            string b = "";
            int starLen = program_starEnd - program_starBegin + 1;
            if (starLen <= 0)
            {
                return str;
            }
            string program_StarCharShow = StarCharShow(starLen, program_StarChar);
            if (str.Length <= program_starEnd)
            {
                if (str.Length < program_starBegin)
                {
                    a = str;
                }
                else
                {
                    a = str.Substring(0, program_starBegin - 1);
                }
            }
            else
            {
                a = str.Substring(0, program_starBegin - 1);
                b = str.Substring(program_starEnd, str.Length - program_starEnd);
            }
            NewStr = a + program_StarCharShow + b;
            return NewStr;
        }
        /// <summary>
        /// 特殊符号遮盖
        /// </summary>
        /// <param name="str">拟遮盖字符全字段</param>
        /// <param name="program_starBegin">开始位</param>
        /// <param name="program_starEnd">结束位</param>
        /// <param name="program_StarChar">遮盖符号单个</param>
        /// <returns></returns>
        public static string StrReplaceByStars(string str, int program_starBegin, int program_starEnd, string program_StarCharShow)
        {
            string NewStr = "";
            string a = "";
            string b = "";
            if (str.Length <= program_starEnd)
            {
                if (str.Length < program_starBegin)
                {
                    a = str;
                }
                else
                {
                    a = str.Substring(0, program_starBegin - 1);
                }
            }
            else
            {
                a = str.Substring(0, program_starBegin - 1);
                b = str.Substring(program_starEnd, str.Length - program_starEnd);
            }
            NewStr = a + program_StarCharShow + b;
            return NewStr;
        }
    }

}