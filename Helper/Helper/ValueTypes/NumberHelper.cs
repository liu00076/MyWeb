using System;

namespace Helper {
    /// <summary>
    /// 2013年5月14日 刘道阳
    /// 提供数据的一些操作。
    /// 微软的类库Math提供了一些操作。也可以参考下面这个文章。
    /// http://www.crifan.com/csharp_format_double_to_string_with_dicimal_point/
    /// </summary>
    public class NumberHelper {

        #region double类型的数据转换。

        /// <summary>
        /// 将string类型的Number按照格式转换成Double。
        /// </summary>
        /// <param name="strNumber">string类型的数据。</param>
        /// <param name="Format">转换的格式。eg:0.00保留小数点后两位。f1:保留小数点后一位。</param>
        /// <returns>转换成double类型的数据。</returns>
        public static string ConverToDouble(string strNumber, string format) {
            if(string.IsNullOrEmpty(strNumber)) return null;
            return Convert.ToDouble(strNumber).ToString(format);
        }

        /// <summary>
        /// 将数据转化成简写形式。
        /// </summary>
        /// <param name="number">要转换成简写的数字。</param>
        /// <param name="ratio">转换的比率。</param>
        /// <returns>简写后的数字形式。</returns>
        public static string GetBriefNumber(int number, int ratio,string format) {
            if(number < ratio) return number.ToString();
            return String.Format("{0:1}", ConverToDouble(number / ratio + "." + number % ratio, format));
        }

        #endregion


        /// <summary>
        /// 将整数型的数字转换成本地类型。
        /// </summary>
        /// <param name="i">要转换的整数。</param>
        /// <param name="format">本地化数据的Fomrat。eg：n,n1,n2……</param>
        /// <returns></returns>
        public static string ConvertToInt(int i, string format) {
            if(i <= 0 || string.IsNullOrEmpty(format)) return null;
            return i.ToString(format);//将数据转换
        }
    }
}
