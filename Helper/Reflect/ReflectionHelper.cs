using System;
using System.Reflection;
namespace Helper
{
    public delegate void ReflectionHelperExceptionHandler(string functionName, string msg);
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public class ReflectionHelper
    {
        public static ReflectionHelperExceptionHandler ReflectionHelperException;
        #region 获取反射对象的值
        /// <summary>
        /// 获取反射对象的字段值
        /// </summary>
        /// <param name="fieldName">要返回的字段名称</param>
        /// <param name="reflectionObj">待反射的对象</param>
        /// <returns>返回对象的字段值</returns>
        public static string GetReflectionField(ref object reflectionObj, string fieldName)
        {
            string fieldValue = string.Empty;
            try
            {
                fieldValue = reflectionObj.GetType().GetField(fieldName).GetValue(reflectionObj).ToString();
            }
            catch (ReflectionTypeLoadException ex)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetReflectionField(ref object reflectionObj, string fieldName)", ex.Message);
                }
                //new ReflectionHelperExceptionHandler(ex.Message);
                fieldValue = string.Empty;
            }
            return fieldValue;
        }
        /// <summary>
        /// 获取反射对象的属性值
        /// </summary>
        /// <param name="propertyName">要返回的属性名称</param>
        /// <param name="reflectionObj">待反射的对象</param>
        /// <returns></returns>
        public static object GetReflectionProperty(ref object reflectionObj, string propertyName)
        {
            object propertValue = null;
            try
            {
                propertValue = reflectionObj.GetType().GetProperty(propertyName).GetValue(reflectionObj, null);
            }
            catch (ReflectionTypeLoadException ex)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetReflectionProperty(ref object reflectionObj,string propertyName)", ex.Message);
                }
                propertValue = null;
            }
            return propertValue;
        }
        /// <summary>
        /// 获取反射对象的属性值
        /// </summary>
        /// <param name="propertyName">要返回的属性名称</param>
        /// <param name="reflectionObj">待反射的对象</param>
        /// <returns></returns>
        public static string GetReflectionPropertyValue(ref object reflectionObj, string propertyName)
        {
            string propertValue = string.Empty;
            try
            {
                propertValue = reflectionObj.GetType().GetProperty(propertyName).GetValue(reflectionObj, null).ToString();
            }
            catch (ReflectionTypeLoadException ex)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetReflectionPropertyValue(ref object reflectionObj, string propertyName)", ex.Message);
                }
                propertValue = string.Empty;
            }
            return propertValue;
        }
        #endregion

        #region 设置反射对象的值
        /// <summary>
        /// 设置反射对象的属性值
        /// </summary>
        /// <param name="reflectionObj">反射的对象(引用)</param>
        /// <param name="pi">属性</param>
        /// <param name="propertyValue">属性值</param>
        public static void SetPropertyValue(ref object reflectionObj, ref PropertyInfo pi, object propertyValue)
        {
            if (pi != null)
            {
                pi.SetValue(reflectionObj, Convert.ChangeType(propertyValue, pi.PropertyType), null);
            }
        }
        /// <summary>
        /// 设置反射对象的字段值
        /// </summary>
        /// <param name="reflectionObj">反射的对象(引用)</param>
        /// <param name="field">字段[变量/域]</param>
        /// <param name="fieldValue">字段值</param>
        public static void SetFieldValue(ref object reflectionObj, ref FieldInfo field, object fieldValue)
        {
            if (field != null)
            {
                field.SetValue(reflectionObj, Convert.ChangeType(fieldValue, field.FieldType));
            }
        }

        /// <summary>
        /// 设置反射对象的属性值
        /// </summary>
        /// <param name="reflectionObj">反射的对象(引用)</param>
        /// <param name="pi">属性名</param>
        /// <param name="propertyValue">属性值</param>
        public static void SetPropertyValue(ref object reflectionObj, string propertyName, object propertyValue)
        {
            PropertyInfo pi = GetObjectPropertyInfo(ref reflectionObj, propertyName);
            if (pi != null)
            {
                pi.SetValue(reflectionObj, Convert.ChangeType(propertyValue, pi.PropertyType), null);
            }
        }
        /// <summary>
        /// 设置反射对象的字段值
        /// </summary>
        /// <param name="reflectionObj">反射的对象(引用)</param>
        /// <param name="field">字段名[变量/域]</param>
        /// <param name="fieldValue">字段值</param>
        public static void SetFieldValue(ref object reflectionObj, string fieldName, object fieldValue)
        {
            FieldInfo field = GetObjectFieldInfo(ref reflectionObj, fieldName);
            if (field != null)
            {
                field.SetValue(reflectionObj, Convert.ChangeType(fieldValue, field.FieldType));
            }
        }
        #endregion

        #region 获取反射对象的成员
        /// <summary>
        /// 获取反射对象的域[变量]
        /// </summary>
        /// <param name="reflectionObj">反射的对象(引用)</param>
        /// <param name="filedName">域名[变量名]</param>
        /// <returns></returns>
        public static FieldInfo GetObjectFieldInfo(ref object reflectionObj, string fieldName)
        {
            FieldInfo field = null;
            try
            {
                field = reflectionObj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            }
            catch (ReflectionTypeLoadException ex)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetObjectFieldInfo(ref object reflectionObj, string fieldName)", ex.Message);
                }
                field = null;
            }
            return field;
        }
        /// <summary>
        /// 获取反射对象的域[变量]
        /// </summary>
        /// <param name="reflectionObj">反射的对象(引用)</param>
        /// <param name="propertyName">域名[变量名]</param>
        /// <returns></returns>
        public static PropertyInfo GetObjectPropertyInfo(ref object reflectionObj, string propertyName)
        {
            PropertyInfo pi = null;
            try
            {
                pi = reflectionObj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
            }
            catch (ReflectionTypeLoadException ex)
            {
                if (ReflectionHelperException != null)
                {
                    ReflectionHelperException("GetObjectPropertyInfo(ref object reflectionObj, string propertyName)", ex.Message);
                }
                pi = null;
            }
            return pi;
        }
        #endregion

        #region 获取反射对象的所有属性
        /// <summary>
        /// 获取反射对象的所有属性
        /// </summary>
        /// <param name="reflectionObj">待反射的对象(引用)</param>
        /// <returns>返回为public 声明的所有属性</returns>
        public static PropertyInfo[] GetObjectPropertyInfoList(ref object reflectionObj)
        {
            return reflectionObj.GetType().GetProperties();
        }
        /// <summary>
        /// 获取反射对象的所有属性
        /// </summary>
        /// <param name="reflectionObj">待反射的对象(引用)</param>
        /// <returns>返回根据flagArgs指定范围的所有属性，默认为所有public声明的所有属性</returns>
        public static PropertyInfo[] GetObjectPropertyInfoList(ref object reflectionObj, BindingFlags flagArgs)
        {
            return reflectionObj.GetType().GetProperties(flagArgs);
        }
        #endregion

        #region 获取反射对象的所有字段
        /// <summary>
        /// 获取反射对象的所有字段
        /// </summary>
        /// <param name="reflectionObj">待反射的对象(引用)</param>
        /// <returns>返回为public 声明的所有字段</returns>
        public static FieldInfo[] GetObjectFieldInfoList(ref object reflectionObj)
        {
            return reflectionObj.GetType().GetFields();
        }
        /// <summary>
        /// 获取反射对象的所有字段
        /// </summary>
        /// <param name="reflectionObj">待反射的对象(引用)</param>
        /// <returns>返回根据flagArgs指定范围的所有字段，默认为所有public声明的所有字段</returns>
        public static FieldInfo[] GetObjectFieldInfoList(ref object reflectionObj, BindingFlags flagArgs)
        {
            return reflectionObj.GetType().GetFields(flagArgs);
        }
        #endregion

        #region 动态创建对象
        /// <summary>
        /// 动态创建对象
        /// </summary>
        /// <param name="assemblyName">创建对象的程序集名称</param>
        /// <param name="ojbFullName">对象的全名[包括命名空间]</param>
        /// <returns></returns>
        public static object GetReflectionObject(string assemblyName, string ojbFullName)
        {
            object returnObj = null;
            returnObj = System.Reflection.Assembly.Load(assemblyName).CreateInstance(ojbFullName);
            return returnObj;
        }
        #endregion
    }
}
