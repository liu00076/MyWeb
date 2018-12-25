package com.misterfat.generator.tool.util;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * 
 * 字段串处理工具类
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月19日
 */
public class StringUtil {

	/**
	 * 
	 * 功能描述：获取正则匹配的字符串
	 *
	 * @param text
	 * @param pattern
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年6月1日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static List<String> findMatch(String text, String pattern) {
		List<String> list = new ArrayList<String>();
		Pattern valiPattern = Pattern.compile(pattern);
		Matcher matcher = valiPattern.matcher(text);
		while (matcher.find()) {
			list.add(matcher.group(0));
		}
		return list;

	}
}