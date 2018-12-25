using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Helper
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 将枚举的字符串类型转换成枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="val">枚举值，也可以是枚举int类型的值</param>
        /// <param name="t">转换成功的枚举值</param>
        /// <returns></returns>
        public static bool IsCanConvert<T>(object val, out T t) where T : struct
        {
            bool result = false;
            t = default(T);
            if (!t.GetType().IsEnum) return false;
            if (Enum.IsDefined(typeof(T), val))
            {
                t = (T)Enum.Parse(typeof(T), val.ToString());
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 将枚举转换为ArrayList
        /// 说明：
        /// 若不是枚举类型，则返回NULL
        /// 单元测试-->通过
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns>ArrayList</returns>
        public static ArrayList ToArrayList(this Type type)
        {
            if (type.IsEnum)
            {
                ArrayList array = new ArrayList();
                Array enumValues = System.Enum.GetValues(type);
                foreach (System.Enum value in enumValues)
                {
                    array.Add(new KeyValuePair<System.Enum, string>(value, GetDescription(value)));
                }
                return array;
            }
            return null;
        }

        /// <summary>
        /// 获取枚举类型值对应的描述名称
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <typeparam name="TAttr"></typeparam>
        /// <param name="t"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TAttr GetAttribute<TEnum, TAttr>(TEnum t, object value)
            where TEnum : struct
            where TAttr : Attribute
        {
            if(!t.GetType().IsEnum) return default(TAttr);
            string name = Enum.GetName(typeof(TEnum), value);
            FieldInfo[] fields = t.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum && field.Name == name)
                {
                    object[] arr = field.GetCustomAttributes(typeof(TAttr), true);
                    if (arr.Length > 0)
                    {
                        return arr[0] as TAttr;
                    }
                }
            }
            return default(TAttr);
        }

        #region 获取枚举的DescriptionAttribute 描述

        /// <summary>
        /// 从枚举中获取Description
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <param name="enumName">需要获取枚举描述的枚举</param>
        /// <returns>描述内容</returns>
        public static string GetDescription(this System.Enum enumName)
        {
            string description;
            FieldInfo fieldInfo = enumName.GetType().GetField(enumName.ToString());
            DescriptionAttribute[] attributes = fieldInfo.GetDescriptAttr();
            if (attributes != null && attributes.Length > 0)
                description = attributes[0].Description;
            else
                description = enumName.ToString();
            return description;
        }
        /// <summary>
        /// 获取字段Description
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        /// <returns>DescriptionAttribute[] </returns>
        public static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo)
        {
            if (fieldInfo != null)
            {
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return null;
        }
        /// <summary>
        /// 根据Description获取枚举
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>枚举</returns>
        public static T GetEnumName<T>(string description)
        {
            Type _type = typeof(T);
            foreach (FieldInfo field in _type.GetFields())
            {
                DescriptionAttribute[] _curDesc = field.GetDescriptAttr();
                if (_curDesc != null && _curDesc.Length > 0)
                {
                    if (_curDesc[0].Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "description");
        }

        #endregion 
    }
}
