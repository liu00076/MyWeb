using System;
using System.Linq;
using System.Reflection;

namespace Helper
{
    /// <summary>
    /// 创建自定义特性的读取
    /// </summary>
    public class AttributeHelper
    {
        /// <summary>
        /// 4.0 写法 使用泛型获取 成员特性实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static V GetEnumRemark<T, V>(T t)
            where T : struct
            where V : Attribute
        {
            Type type = t.GetType();
            FieldInfo fd = type.GetField(t.ToString());
            if (fd == null) return null;
            var attrs = fd.GetCustomAttributes(typeof(V), false);
            if (attrs == null) return null;
            return attrs.ToList().ConvertAll(m => m as V)[0];
        }

        /// <summary>
        /// 使用泛型获取 4.5 写法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        //public static V GetEnumRemark<T,V>(T t) where T : struct where V:Attribute
        //{
        //    Type type = t.GetType();
        //    FieldInfo fd = type.GetField(t.ToString());
        //    if (fd == null)
        //        return null;
        //    var attrs = fd.GetCustomAttribute(typeof(V), false) as V;
        //    return attrs;
        //}
    }
}
