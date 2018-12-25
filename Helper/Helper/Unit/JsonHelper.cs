using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helper
{
    /// <summary>
    /// 2013年10月16日，将对象转换成Json或将Json字符串转化成对象
    /// </summary>
    public class JsonHelper
    {
        #region 使用第三方类库Newtonsoft转换。

        /// <summary>
        /// 使用第三方类库Newtonsoft将对象转换成JSON字符串。
        /// </summary>
        /// <param name="objectT">要转换的对象。</param>
        /// <returns></returns>
        public static String ToJson(object objectT)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";

            StringBuilder sbJSON;
            string rawJSON = JsonConvert.SerializeObject(objectT, Newtonsoft.Json.Formatting.Indented, timeConverter);

            StringWriter sw = new StringWriter();
            JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            writer.WriteRaw(rawJSON);
            writer.Flush();

            sbJSON = sw.GetStringBuilder();

            return sbJSON.ToString();
        }

        /// <summary>
        /// 泛型对象转换到JSON表示字符串
        /// </summary>
        /// <param name="objectT">目标对象</param>
        /// <param name="totalResults">总记录数</param>
        /// <returns>返回JSON表示字符串</returns>
        public static string ToJSON(object objectT, int totalResults)
        {
            StringBuilder sbJSON;
            string rawJSON = JsonConvert.SerializeObject(objectT);

            StringWriter sw = new StringWriter();
            JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            writer.WriteStartObject();

            writer.WritePropertyName("TotalRecord"); //总记录数
            writer.WriteValue(totalResults);

            writer.WritePropertyName("Data"); //数据集合
            writer.WriteRaw(rawJSON);
            writer.WriteEndObject();
            writer.Flush();

            sbJSON = sw.GetStringBuilder();
            return sbJSON.ToString();
        }

        /// <summary>
        /// 从json格式字符串转成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T FromJson<T>(string jsonString) where T : class
        {
            object target = JsonConvert.DeserializeObject(jsonString, typeof(T));

            if (target != null)
            {
                return target as T;
            }

            return default(T);
        }

        #endregion

        #region 微软解决方案，JavaScriptSerializer实现转换。

        //这个类位于System.Web.Script.Serialization名字空间中
        //（非Web项目需要添加System.Web.Extensions.dll引用）
        //如果不希望序列化某个属性，可以给该属性标记为[ScriptIgnore]
        public static string seJson(object obj)
        {
            return JsonHelper.seJson<object>(obj);
        }

        public static string seJson<T>(T Tobj) where T:class
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(Tobj);
        }

        public static object covObj(string json)
        {
            return JsonHelper.covObj<object>(json);
        }

        public static T covObj<T>(string Tjson) where T:class
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(Tjson);
        }

        //JavaScriptSerializer 会将日期和时间格式转换成/Date(700000+0500)/格式
        //提供将数据转换成自定义的时间格式的c#代码实现。
        public string CovJsonTimeToLocal(string json)
        {
            json = Regex.Replace(json, @"\\/Date\((\d+)\)\\/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime();
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            });
            return json;
        }
        #endregion

    }
}
