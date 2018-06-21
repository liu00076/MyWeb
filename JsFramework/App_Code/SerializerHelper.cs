using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// SerializerHelper 的摘要说明
/// </summary>
public class SerializerHelper
{
	public SerializerHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    #region json序列化和反序列化
    /// <summary>
    /// JSON序列化
    /// </summary>
    /// <typeparam name="T">要序列化成json的对象</typeparam>
    /// <param name="t"></param>
    /// <returns>T序列化后的json对象</returns>
    public static string JsonSerializer<T>(T t)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            return jsonString;
        }
    }
    /// <summary>
    /// JSON反序列化
    /// </summary>
    /// <typeparam name="T">json字符串要反序列化成的对象</typeparam>
    /// <param name="jsonString">json字符串</param>
    /// <returns>T</returns>
    public static T JsonDeserialize<T>(string jsonString)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
        {
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
    #endregion

    #region xml序列化和反序列化
    /// <summary>
    /// 将对象序列化为xml文件流保存在指点路径
    /// </summary>
    /// <typeparam name="Tobj">要序列化的对象类型</typeparam>
    /// <param name="obj">要序列化的对象</param>
    /// <param name="path">序列化的xml文件保存的路径</param>
    public void Serialize<Tobj>(Tobj obj, string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            //设置 不输出xml声明，指定换行符，指定缩进字符
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.OmitXmlDeclaration = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(fs, settings);

            XmlSerializer formatter = new XmlSerializer(typeof(Tobj));
            formatter.Serialize(writer, obj);
        }
    }
    /// <summary>
    /// 将指定路径的文件流反序列化问对象
    /// </summary>
    /// <typeparam name="Tobj">反序列化文件流成的对象类型</typeparam>
    /// <param name="obj">反序列化后的对象类型</param>
    /// <param name="path">反序列化的文件流的路径</param>
    /// <returns>反序列化后的对象</returns>
    public Tobj DeSerialize<Tobj>(Tobj obj, string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Tobj));
            obj = (Tobj)formatter.Deserialize(fs);
        }
        return obj;
    }

    /// <summary>
    /// 将对象序列化成xml文档
    /// </summary>
    /// <typeparam name="Tobj">要序列化的对象类型</typeparam>
    /// <param name="objectToXML">要序列化的对象</param>
    /// <returns>序列化的xml文档</returns>
    public string ConverToXML<Tobj>(Tobj objectToXML)
    {
        string xml = null;
        Type t = objectToXML.GetType();
        XmlSerializer ser = new XmlSerializer(t);
        using (StringWriter writer = new StringWriter())
        {
            ser.Serialize(writer, objectToXML);
            xml = writer.ToString();
            writer.Close();
        }
        return xml;
    }

    /// <summary>
    /// xml字符串转化对象（反序列化）
    /// </summary>
    /// <typeparam name="T">要反序列化成的对象</typeparam>
    /// <param name="xml">xml字符串</param>
    /// <param name="objectType">对象类型</param>
    /// <returns>反序列化后的对象</returns>
    public T ConvertToObject<T>(string xml, Type objectType)
    {
        T convertedObject = default(T);
        if (!string.IsNullOrEmpty(xml))
        {
            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer ser = new XmlSerializer(objectType);
                convertedObject = (T)ser.Deserialize(reader);
                reader.Close();
            }
        }
        return convertedObject;
    }

    public T ConvertToObject<T>(XmlNode node, Type objectType)
    {
        return ConvertToObject<T>(node.OuterXml, objectType);
    }
    #endregion

    #region binarySerialize序列化和反序列化
    /// <summary>
    /// 将对象转化成二进制保存在文件流对象中
    /// </summary>
    /// <typeparam name="Tobj">要转化的对象类型</typeparam>
    /// <param name="path">文件流的保存路径</param>
    /// <param name="obj">对象类型</param>
    public static void SerializeBytes<Tobj>(string path, Tobj obj)
    {
        //构造一个流来容纳序列化的对象
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            //构造一个序列格式化器，他负责将对象序列化
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
        }
    }
    /// <summary>
    /// 将文件转换成特定的对象
    /// </summary>
    /// <typeparam name="Tobj">转换的对象类型</typeparam>
    /// <param name="path">文件所在的路径</param>
    /// <param name="obj">转换成的对象实例</param>
    /// <returns>转换成的对象实例</returns>
    public static Tobj DeSerializeBytes<Tobj>(string path)
    {
        Tobj result = default(Tobj);
        if (!File.Exists(path)) return result;
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            //构造一个序列格式化器，他负责将对象序列化
            BinaryFormatter formatter = new BinaryFormatter();
            result = (Tobj)formatter.Deserialize(fs);
        }
        return result;
    }
    /// <summary>
    /// 通过BinaryReader将文件流转化成字节数组，在将字节数组转化成内存流，
    /// 在通过内存流的BinaryFormatter将字节数组转化成object对象
    /// </summary>
    /// <param name="path">文件流的路径</param>
    /// <returns>返回的对象</returns>
    public static T LoadBinaryFile<T>(string path)
    {
        T convertedObject;
        if (!File.Exists(path))
            return default(T);
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            BinaryReader br = new BinaryReader(fs);
            byte[] ba = new byte[fs.Length];
            br.Read(ba, 0, (int)fs.Length);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(ba, 0, ba.Length);
                //设置内存流的起始位置
                ms.Position = 0;
                //构造序列化器进行序列化
                BinaryFormatter binaryFormater = new BinaryFormatter();
                convertedObject = (T)binaryFormater.Deserialize(ms);
            }
        }
        return convertedObject;
    }
    /// <summary>
    /// 把对象序列化成Byte[]数组，用于把对象在不同的流之间转换
    /// </summary>
    /// <typeparam name="Tobj">要序列化的对象的类型</typeparam>
    /// <param name="objectToConvert">要序列化的对象实例</param>
    /// <returns>转化对象转化成的字节数组</returns>
    public static byte[] ConverToBytes<Tobj>(Tobj objectToConvert)
    {
        byte[] byteArray = null;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            binaryFormatter.Serialize(ms, objectToConvert);
            ms.Position = 0;
            byteArray = new Byte[ms.Length];
            ms.Read(byteArray, 0, byteArray.Length);
        }
        return byteArray;
    }

    /// <summary>
    /// byte[]反序列化成对象
    /// </summary>
    /// <typeparam name="T">要反序列化后生成的对象</typeparam>
    /// <param name="byteArray">字节数组</param>
    /// <returns>反序列化的对象</returns>
    public static T ConvertToObject<T>(byte[] byteArray)
    {
        T convertedObject = default(T);
        if (byteArray != null && byteArray.Length > 0)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(byteArray, 0, byteArray.Length);
                ms.Position = 0;
                if (byteArray.Length > 4)
                {
                    convertedObject = (T)binaryFormatter.Deserialize(ms);
                }
                ms.Close();
            }
        }
        return convertedObject;
    }
    #endregion

    #region nameValueCollection <==>string之间的相互转换
    /// <summary>
    /// Creates a NameValueCollection from two string. The first contains the key pattern and the second contains the values
    /// spaced according to the kys
    /// </summary>
    /// <param name="keys">Keys for the namevalue collection</param>
    /// <param name="values">Values for the namevalue collection</param>
    /// <returns>A NVC populated based on the keys and vaules</returns>
    /// <example>
    /// string keys = "Name:S:0:3:Age:S:3:2:Sex:S:5:3:";
    /// string values = "Luu20Men";
    /// This would result in a NameValueCollection with two keys (Key1 and Key2) with the values 123 and 45
    /// </example>
    public static NameValueCollection ConvertToNameValueCollection(string keys, string values)
    {
        NameValueCollection nvc = new NameValueCollection();

        if (keys != null && values != null && keys.Length > 0 && values.Length > 0)
        {
            char[] splitter = new char[1] { ':' };
            string[] keyNames = keys.Split(splitter);

            for (int i = 0; i < (keyNames.Length / 4); i++)
            {
                int start = int.Parse(keyNames[(i * 4) + 2], CultureInfo.InvariantCulture);
                int len = int.Parse(keyNames[(i * 4) + 3], CultureInfo.InvariantCulture);
                string key = keyNames[i * 4];

                //Future version will support more complex types	
                if (((keyNames[(i * 4) + 1] == "S") && (start >= 0)) && (len > 0) && (values.Length >= (start + len)))
                {
                    nvc[key] = values.Substring(start, len);
                }
            }
        }

        return nvc;
    }

    /// <summary>
    /// Creates a the keys and values strings for the simple serialization based on a NameValueCollection
    /// </summary>
    /// <param name="nvc">NameValueCollection to convert</param>
    /// <param name="keys">the ref string will contain the keys based on the key format</param>
    /// <param name="values">the ref string will contain all the values of the namevaluecollection</param>
    public static void ConvertFromNameValueCollection(NameValueCollection nvc, out string keys, out string values)
    {
        if (nvc == null || nvc.Count == 0)
        {
            keys = null;
            values = null;
            return;
        }
        StringBuilder sbKey = new StringBuilder();
        StringBuilder sbValue = new StringBuilder();

        int index = 0;
        foreach (string key in nvc.AllKeys)
        {
            if (key.IndexOf(':') != -1)
                throw new ArgumentException("ExtendedAttributes Key can not contain the character \":\"");

            string v = nvc[key];
            if (!string.IsNullOrEmpty(v))
            {
                sbKey.AppendFormat("{0}:S:{1}:{2}:", key, index, v.Length);
                sbValue.Append(v);
                index += v.Length;
            }
        }
        keys = sbKey.ToString();
        values = sbValue.ToString();
    }
    #endregion
}