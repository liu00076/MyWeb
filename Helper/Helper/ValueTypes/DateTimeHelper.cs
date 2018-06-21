using System;

namespace Helper
{
    /// <summary>
    /// 时间操作类
    /// </summary>
    public class DateTimeHelper
    {

        #region 关于时间的格式化方式

        DateTime dt = DateTime.Now;
        //dt.CompareTo(dt).ToString();//0 
        //dt.Add(?).ToString();//问号为一个时间段 
        //dt.Equals("2005-11-6 16:11:04").ToString();//False 
        //dt.Equals(dt).ToString();//True 
        //dt.GetType().ToString();//System.DateTime 
        //dt.GetTypeCode().ToString();//DateTime 
        //dt.ToString();//2005-11-5 13:21:25 
        //dt.ToFileTime().ToString();//127756416859912816 
        //dt.ToFileTimeUtc().ToString();//127756704859912816 
        //dt.ToLocalTime().ToString();//2005-11-5 21:21:25 
        //dt.ToLongDateString().ToString();//2005年11月5日 
        //dt.ToLongTimeString().ToString();//13:21:25 
        //dt.ToOADate().ToString();//38661.5565508218 
        //dt.ToShortDateString().ToString();//2005-11-5 
        //dt.ToShortTimeString().ToString();//13:21 
        // dt.ToUniversalTime().ToString();//2005-11-5 5:21:25
        //dt.Year.ToString();//2005 
        //dt.Date.ToString();//2005-11-5 0:00:00 
        //dt.DayOfWeek.ToString();//Saturday 
        //dt.DayOfYear.ToString();//309 
        //dt.Hour.ToString();//13 
        //dt.Millisecond.ToString();//441 
        //dt.Minute.ToString();//30 
        //dt.Month.ToString();//11 
        //dt.Second.ToString();//28 
        // dt.Ticks.ToString();//632667942284412864 
        // dt.TimeOfDay.ToString();//13:30:28.4412864 
        //dt.ToString();//2005-11-5 13:47:04 
        //dt.AddYears(1).ToString();//2006-11-5 13:47:04 
        //dt.AddDays(1.1).ToString();//2005-11-6 16:11:04 
        //dt.AddHours(1.1).ToString();//2005-11-5 14:53:04 
        //dt.AddMilliseconds(1.1).ToString();//2005-11-5 13:47:04 
        //dt.AddMonths(1).ToString();//2005-12-5 13:47:04 
        //dt.AddSeconds(1.1).ToString();//2005-11-5 13:47:05 
        //dt.AddMinutes(1.1).ToString();//2005-11-5 13:48:10 
        //dt.AddTicks(1000).ToString();//2005-11-5 13:47:04 
        //dt.GetDateTimeFormats('s')[0].ToString();//2005-11-05T14:06:25 
        //dt.GetDateTimeFormats('t')[0].ToString();//14:06 
        //dt.GetDateTimeFormats('y')[0].ToString();//2005年11月 
        //dt.GetDateTimeFormats('D')[0].ToString();//2005年11月5日 
        //dt.GetDateTimeFormats('D')[1].ToString();//2005 11 05 
        //dt.GetDateTimeFormats('D')[2].ToString();//星期六 2005 11 05 
        //dt.GetDateTimeFormats('D')[3].ToString();//星期六 2005年11月5日 
        //dt.GetDateTimeFormats('M')[0].ToString();//11月5日 
        //dt.GetDateTimeFormats('f')[0].ToString();//2005年11月5日 14:06 
        //dt.GetDateTimeFormats('g')[0].ToString();//2005-11-5 14:06 
        //dt.GetDateTimeFormats('r')[0].ToString();//Sat, 05 Nov 2005 14:06:25 GMT
        //dt.GetDateTimeFormats()[0].ToString();//2012/3/28
        //string.Format("{0:d}", dt);//2005-11-5 
        //string.Format("{0:D}", dt);//2005年11月5日 
        //string.Format("{0:f}", dt);//2005年11月5日 14:23 
        //string.Format("{0:F}", dt);//2005年11月5日 14:23:23 
        //string.Format("{0:g}", dt);//2005-11-5 14:23 
        //string.Format("{0:G}", dt);//2005-11-5 14:23:23 
        //string.Format("{0:M}", dt);//11月5日 
        //string.Format("{0:R}", dt);//Sat, 05 Nov 2005 14:23:23 GMT 
        //string.Format("{0:s}", dt);//2005-11-05T14:23:23 
        //string.Format("{0:t}", dt);//14:23 
        //string.Format("{0:T}", dt);//14:23:23 
        //string.Format("{0:u}", dt);//2005-11-05 14:23:23Z 
        //string.Format("{0:U}", dt);//2005年11月5日 6:23:23 
        //string.Format("{0:Y}", dt);//2005年11月 
        //string.Format("{0}", dt);//2005-11-5 14:23:23 
        //string.Format("{0:yyyy-MM-dd HH:mm:ss:ffff}", dt);//2012-03-28 18:07:19:0174 

        #endregion

        // 判断是否在指定日期以前，还是以后。
        public static string ComputingTime(DateTime time)
        {
            string timeHtml = null;
            DateTime newTime = DateTime.Now;
            if (time.Year == newTime.Year && time.Month == newTime.Month && time.Day == newTime.Day)
                timeHtml = "今天";
            else
                timeHtml = "以前";
            return timeHtml;
        }

        // 计算某个月有多少天
        private void GetLastDateForMonth(DateTime DtStart, out DateTime DtEnd)
        {
            int Dtyear, DtMonth;
            Dtyear = DtStart.Year;
            DtMonth = DtStart.Month;
            int MonthCount = DateTime.DaysInMonth(Dtyear, DtMonth);//計算該月有多少天
            DtEnd = Convert.ToDateTime(Dtyear.ToString() + "-" + DtMonth.ToString() + "-" + MonthCount);
        }

        // 将字符串类型的时间转换成自定义的时间类型。
        private string ConvertDateTimeTostring(string dateString, string pattern)
        {
            System.Globalization.DateTimeFormatInfo dateFormat = new System.Globalization.DateTimeFormatInfo();
            if (!string.Empty.Equals(dateString))
            {
                dateFormat.ShortDatePattern = pattern;
                dateFormat.DateSeparator = "-";
                DateTime DateTimes = Convert.ToDateTime(dateString);
                return DateTimes.ToString(dateFormat);
            }
            else
            {
                return string.Empty;
            }
        }

        // 时间格式化, 超过24小时显示详细日期
        public static string DateFormat0(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalHours > 24)
            {
                return dt.ToString("yyyy-MM-dd HH:mm");
            }
            else if (span.TotalHours > 1 && span.TotalHours <= 24)
            {
                return
                string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
            }
            else if (span.TotalMinutes > 1)
            {
                return
                string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
            }
            else
            {
                return "1分钟前";
            }
        }

        //距dateTime 还有:*天
        public static string DateFormat1(DateTime dateTime)
        {
            string _dateFormat = string.Empty;
            TimeSpan ts = dateTime - DateTime.Now;
            if (ts.Days > 0)
                _dateFormat = Convert.ToInt32(Math.Round(ts.TotalDays, 0)) + "";
            return _dateFormat;
        }

        //距dateTime 还有:*天*时*分*秒
        public static string DateFormat2(DateTime dateTime)
        {
            string _dateFormat = string.Empty;

            TimeSpan ts = dateTime - DateTime.Now;

            if (ts.Days > 0)
                _dateFormat = ts.Days.ToString() + "天";
            if (ts.Hours > 0)
                _dateFormat += ts.Hours.ToString() + "时";
            if (ts.Minutes > 0)
                _dateFormat += ts.Minutes.ToString() + "分";
            if (ts.Seconds > 0)
                _dateFormat += ts.Seconds.ToString() + "秒";

            return _dateFormat;
        }
    }
}
