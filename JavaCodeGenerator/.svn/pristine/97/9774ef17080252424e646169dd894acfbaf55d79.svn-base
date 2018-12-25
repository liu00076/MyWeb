package com.misterfat.generator.tool.model;

import java.io.Serializable;
import java.util.List;

import com.misterfat.generator.tool.Constants;
import com.misterfat.generator.tool.gen.TableTool;
import com.misterfat.generator.tool.util.CamelCaseUtil;

public class TableModel implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = 7410434061778019589L;

	// 是否是视图
	private String isView;

	// 是否有日期类型的字段
	private String hasDate;

	// 是否有BigDecimal类型的字段
	private String hasBigDecimal;

	// 表名
	private String name;

	// 类名
	private String className;

	// 对象名
	private String objectName;

	// 路径名
	private String url;

	// 注释
	private String comment;

	// 类型
	private String type;

	// ID字段
	private String[] primarykeys;

	// ID属性
	private String[] propertyPrimarykeys;

	// 字段列表
	private List<FieldModel> fieldList;

	public String getIsView() {
		return isView;
	}

	public void setIsView(String isView) {
		this.isView = isView;
	}

	public String getHasDate() {
		return hasDate;
	}

	public void setHasDate(String hasDate) {
		this.hasDate = hasDate;
	}

	public String getHasBigDecimal() {
		return hasBigDecimal;
	}

	public void setHasBigDecimal(String hasBigDecimal) {
		this.hasBigDecimal = hasBigDecimal;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name;
			this.url = name.replace("_", "/");
			this.className = CamelCaseUtil.toCapitalizeCamelCase(name);
			this.objectName = CamelCaseUtil.toCamelCase(name);
			this.isView = TableTool.isView(name) ? Constants.TRUE : Constants.FALSE;
		} else {
			this.name = null;
			this.url = null;
			this.className = null;
			this.objectName = null;
			this.isView = null;
		}
	}

	public String getClassName() {
		return className;
	}

	public void setClassName(String className) {
		this.className = className;
	}

	public String getObjectName() {
		return objectName;
	}

	public void setObjectName(String objectName) {
		this.objectName = objectName;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String[] getPrimarykeys() {
		return primarykeys;
	}

	public void setPrimarykeys(String[] primarykeys) {
		if (primarykeys != null) {
			int length = primarykeys.length;
			this.propertyPrimarykeys = new String[length];
			for (int i = 0; i < length; i++) {
				this.propertyPrimarykeys[i] = CamelCaseUtil.toCamelCase(primarykeys[i]);
			}
		}
		this.primarykeys = primarykeys;
	}

	public String[] getPropertyPrimarykeys() {
		return propertyPrimarykeys;
	}

	public void setPropertyPrimarykeys(String[] propertyPrimarykeys) {
		this.propertyPrimarykeys = propertyPrimarykeys;
	}

	public List<FieldModel> getFieldList() {
		return fieldList;
	}

	public void setFieldList(List<FieldModel> fieldList) {
		this.fieldList = fieldList;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

}
