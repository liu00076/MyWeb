package com.misterfat.generator.tool.db;

import java.io.Serializable;

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
public class Field implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = -5296890070697589853L;

	// 是否为主键
	private String primaryKey;

	// 属性名称
	private String name;

	// 属性注释
	private String comment;

	// 属性类型
	private String fieldType;

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

}