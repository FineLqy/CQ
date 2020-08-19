using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORSV2.cs
{
    public class RandomNumber
    {
        /// <summary>
        /// 利用Hashtable,生成不重复的随机数
        /// </summary>
     public   static int[] UseHashTableToNonRepeatedRandom(int length, int minValue, int maxValue)
        {
            Hashtable hashtable = new Hashtable();
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            for (int i = 0; hashtable.Count < length; i++)
            {
                int nValue = random.Next(minValue, maxValue);
                if (!hashtable.ContainsValue(nValue) && nValue != 0)
                {
                    hashtable.Add(i, nValue);
                    //hashtable.Add(nValue, nValue);        // 将 key 和 value设置成一样的值，导致hashtable无法按添加顺序输出数组
                    //Console.WriteLine(nValue.ToString());
                }
            }
            int[] array = new int[hashtable.Count];
            hashtable.Values.CopyTo(array, 0);
            return array;
        }
    }
}