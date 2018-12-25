using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Base64CovertHelper 的摘要说明
/// </summary>
public class Base64CovertHelper
{
	public Base64CovertHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 将对象转换成base64位的字符串
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="t">对象</param>
    /// <returns></returns>
    public static string EncryptBase64<T>(T t) where T : class
    {
        string result = string.Empty;
        if (t == null) return result;
        byte[] bytes = SerializerHelper.ConverToBytes(t);
        result = Convert.ToBase64String(bytes, Base64FormattingOptions.None);
        return result;
    }

    /// <summary>
    /// 将通过Base64加密的字符串转换成对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str"></param>
    /// <returns></returns>
    public static T DecryptBase64<T>(string str) where T : class
    {
        if (string.IsNullOrEmpty(str)) return default(T);
        byte[] bytes = Convert.FromBase64String(str);
        T t = SerializerHelper.ConvertToObject<T>(bytes);
        return t;
    }
}