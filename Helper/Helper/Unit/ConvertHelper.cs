using System;

namespace Helper {
    /// <summary>
    /// 数字和时间转化相关类。
    /// </summary>
    public class ConvertHelper {

        /// <summary>
        /// 将数据转化成简写形式。
        /// </summary>
        /// <param name="number">要转换成简写的数字。</param>
        /// <param name="ratio">转换的比率。</param>
        /// <returns>简写后的数字形式。</returns>
        public static string GetBriefNumber(int number, int ratio) {
            if(number < 1000000) return number.ToString();
            return String.Format("{0:F}", Convert.ToDouble(number / ratio + "." + number % ratio));
        }

        /// <summary>
        /// 将string类型的Number按照格式转换成Double。
        /// </summary>
        /// <param name="strNumber">string类型的数据。</param>
        /// <param name="Format">转换的格式。eg:0.00保留小数点后两位。f1:保留小数点后一位。</param>
        /// <returns>转换成double类型的数据。</returns>
        public static string ConverToDouble(string strNumber, string Format) {
            if(string.IsNullOrEmpty(strNumber)) return null;
            return Convert.ToDouble(strNumber).ToString(Format);
        }

        /// <summary>
        /// 将字符串转换成另一种编码的字符串。
        /// </summary>
        /// <param name="str">源字符串。</param>
        /// <param name="From">源字符串的编码类型。</param>
        /// <param name="To">目标字符串的编码类型。</param>
        /// <returns></returns>
        public static string ConvertStr(string str, string From, string To) {
            byte[] bs = System.Text.Encoding.GetEncoding(From).GetBytes(str);
            bs = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(From), System.Text.Encoding.GetEncoding(To), bs);
            return System.Text.Encoding.GetEncoding(To).GetString(bs);
        }
    }
}
