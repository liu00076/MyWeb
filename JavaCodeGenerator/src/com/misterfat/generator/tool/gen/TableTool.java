package com.misterfat.generator.tool.gen;

/**
 * 
 * 对表名的处理工具类
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月19日
 */
public class TableTool {

	/**
	 * 
	 * 功能描述：判断是否是视图
	 *
	 * @param tableName
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月19日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static boolean isView(String tableName) {
		return tableName.startsWith("view_") || tableName.endsWith("_view");
	}

}