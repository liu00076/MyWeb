package com.misterfat.generator.tool.util;

/**
 * 
 * 各种路径获取工具类
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月28日
 */
public class PathUtil {

	/**
	 * 
	 * 功能描述： 获得项目根目录的绝对路径
	 *
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月28日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getProjectBasePath() {
		return System.getProperty("user.dir").replace('\\', '/');
	}

	/**
	 * 
	 * 功能描述：获得类(.class)的根目录的绝对路径
	 *
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月28日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getClassBasePath() {
		return Thread.currentThread().getContextClassLoader().getResource("").toString().substring(6);
	}

}
