package com.misterfat.generator.tool.util;

import java.math.BigDecimal;

/**
 * 数字工具类
 * 
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2016年7月12日
 */
public class NumberUtil {

	/**
	 * 
	 * 功能描述：字符串转整型
	 *
	 * @param number
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年7月12日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Integer parseInteger(String number) {
		try {
			return Integer.parseInt(number);
		} catch (Exception e) {
		}
		return null;
	}

	/**
	 * 
	 * 功能描述：保留指定位数小数(四舍五入)
	 *
	 * @param number
	 * @param count
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年7月12日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static double toFixed(double number, int count) {
		return new BigDecimal(number).setScale(count, BigDecimal.ROUND_HALF_UP).doubleValue();
	}
}
