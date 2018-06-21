using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Helper
{
    /// <summary>
    /// 将对象和byte数组转换
    /// </summary>
    public class ObjectHelper
    {
        /// <summary>
        /// 将一个对象转化成byte[]数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static byte[] ConvertToByte<T>(T t) where T : class ,new()
        {
            byte[] result = new byte[] { };
            if (t == default(T)) return result;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms,t);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 将一个二进制数组转化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static T ConvertToObject<T>(byte[] byteArray)where T:class ,new()
        {
            if (byteArray == null || byteArray.Length == 0) return default(T);
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                object obj = formatter.Deserialize(ms);
                if (obj is T)
                {
                    return (T)obj;
                }
                return default(T);
            }
        }


    }
}
