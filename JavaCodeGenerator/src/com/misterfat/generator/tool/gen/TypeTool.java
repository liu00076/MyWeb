package com.misterfat.generator.tool.gen;

/**
 * 
 * 类型工具类
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月28日
 */
public class TypeTool {

	/**
	 * 
	 * 功能描述：fieldType 转 jdbcType
	 *
	 * @param fieldType
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String fieldToJdbc(String fieldType) {
		if (fieldType == null) {
			return null;
		}
		String upperFieldType = fieldType.toUpperCase();
		if ("DATETIME".equals(upperFieldType)) {
			return "TIMESTAMP";
		} else if ("INT".equals(upperFieldType)) {
			return "INTEGER";
		} else if ("TEXT".equals(upperFieldType)) {
			return "VARCHAR";
		} else if ("LONGTEXT".equals(upperFieldType)) {
			return "LONGVARCHAR";
		}
		return upperFieldType;
	}

	/**
	 * 
	 * 功能描述：fieldType 转 javaType
	 *
	 * @param fieldType
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String fieldToJava(String fieldType) {
		if (fieldType == null) {
			return null;
		}
		String upperFieldType = fieldType.toUpperCase();

		if (upperFieldType.indexOf("CHAR") > -1) {
			return "String";

		} else if (upperFieldType.indexOf("BIGINT") > -1) {
			return "Long";
		} else if (upperFieldType.indexOf("INT") > -1) {
			return "Integer";
		} else if ((upperFieldType.indexOf("NUMBER") > -1) || (upperFieldType.indexOf("DOUBLE") > -1)) {
			return "Double";
		} else if ((upperFieldType.indexOf("DECIMAL") > -1)) {
			return "BigDecimal";
		} else if ((upperFieldType.indexOf("FLOAT") > -1)) {
			return "Float";
		} else if ((upperFieldType.indexOf("DATE") > -1) || (upperFieldType.indexOf("TIME") > -1)
				|| (upperFieldType.indexOf("DATETIME") > -1) || (upperFieldType.indexOf("TIMESTAMP") > -1)) {
			return "Date";
		} else if (upperFieldType.matches("BOOLEAN") || upperFieldType.matches("BIT")) {
			return "Boolean";
		} else if (upperFieldType.matches("BLOB")) {
			return "byte[]";
		} else {
			return "String";
		}
	}

}
