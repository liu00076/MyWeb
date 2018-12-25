package com.misterfat.generator.tool.model;

import java.io.Serializable;

import com.misterfat.generator.tool.gen.TypeTool;
import com.misterfat.generator.tool.util.CamelCaseUtil;

/**
 * 
 * 表字段对象
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月19日
 */
public class FieldModel implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = 8345180647731207742L;

	// 是否为主键
	private String primaryKey;

	// 字段名称
	private String name;

	// 属性名
	private String propertyName;

	// 首字母大写属性名
	private String firstUpperPropertyName;

	// 字段注释
	private String comment;

	// 字段类型
	private String fieldType;

	// SQL字段类型
	private String jdbcType;

	// JAVA属性类型
	private String javaType;

	// 是否可以为空
	private String nullable;

	// 字段长度
	private String fieldLength;

	// 数值范围
	private String scale;

	public String getPrimaryKey() {
		return primaryKey;
	}

	public void setPrimaryKey(String primaryKey) {
		this.primaryKey = primaryKey;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
		this.propertyName = CamelCaseUtil.toCamelCase(name);
		this.firstUpperPropertyName = CamelCaseUtil.toCapitalizeCamelCase(name);
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public String getFieldType() {
		return fieldType;
	}

	public void setFieldType(String fieldType) {
		this.fieldType = fieldType;
		this.jdbcType = TypeTool.fieldToJdbc(fieldType);
		this.javaType = TypeTool.fieldToJava(fieldType);
	}

	public String getNullable() {
		return nullable;
	}

	public void setNullable(String nullable) {
		this.nullable = nullable;
	}

	public String getFieldLength() {
		return fieldLength;
	}

	public void setFieldLength(String fieldLength) {
		this.fieldLength = fieldLength;
	}

	public String getScale() {
		return scale;
	}

	public void setScale(String scale) {
		this.scale = scale;
	}

	public String getPropertyName() {
		return propertyName;
	}

	public void setPropertyName(String propertyName) {
		this.propertyName = propertyName;
	}

	public String getJdbcType() {
		return jdbcType;
	}

	public void setJdbcType(String jdbcType) {
		this.jdbcType = jdbcType;
	}

	public String getJavaType() {
		return javaType;
	}

	public void setJavaType(String javaType) {
		this.javaType = javaType;
	}

	public String getFirstUpperPropertyName() {
		return firstUpperPropertyName;
	}

	public void setFirstUpperPropertyName(String firstUpperPropertyName) {
		this.firstUpperPropertyName = firstUpperPropertyName;
	}

}