package com.misterfat.generator.tool.db;

import java.io.Serializable;
import java.math.BigInteger;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.apache.commons.beanutils.converters.BigIntegerConverter;

import com.misterfat.generator.tool.Constants;
import com.misterfat.generator.tool.util.ArrayUtil;

/**
 * 
 * 数据表对象
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月19日
 */
public class Table implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = -7436120709766913744L;

	// 数据库
	private Database database;

	// 表名
	private String name;

	// 注释
	private String comment;

	// 类型
	private String type;

	// ID字段
	private String[] primarykeys;

	// 字段列表
	private List<Field> fieldList;

	/**
	 * 
	 * 功能描述：查询表字段
	 *
	 * @throws SQLException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public List<Field> queryFieldList() throws SQLException {
		List<Map<String, Object>> fields = database.queryAllColumns(this.name);
		List<Map<String, Object>> primarykeyList = database.queryPrimarykeys(this.name);

		List<String> tempList = new ArrayList<String>();

		if (fields != null && !fields.isEmpty()) {
			this.fieldList = new ArrayList<Field>();
			for (Map<String, Object> map : fields) {
				Field field = new Field();
				field.setName((String) map.get("column_name"));
				boolean isPrimarykey = isPrimarykey(primarykeyList, field.getName());
				field.setPrimaryKey(isPrimarykey ? Constants.TRUE : null);
				if (isPrimarykey) {
					tempList.add(field.getName());
				}
				field.setComment((String) map.get("column_comment"));
				Short dataLength = ((Short)map.get("data_length"));
				field.setFieldLength(dataLength == null ? null : dataLength.toString());
				field.setFieldType((String) map.get("data_type"));
				Integer nullable = (Integer) map.get("nullable");
				field.setNullable(nullable > 0 ? Constants.TRUE : null);
				Short scale = ((Short) map.get("scale"));
				field.setScale(scale == null ? null : scale.toString());
				this.fieldList.add(field);
			}
			this.primarykeys = ArrayUtil.listToArray(tempList);
		}
		return this.fieldList;
	}

	/**
	 * 
	 * 功能描述：判断是否是主键
	 *
	 * @param primarykeys
	 * @param field
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	private boolean isPrimarykey(List<Map<String, Object>> primarykeys, String field) {
		if (Constants.DEFAULT_ID_FIELD_NAME.equalsIgnoreCase(field)) {
			return true;
		}
		if (primarykeys == null || primarykeys.isEmpty()) {
			return false;
		}
		for (Map<String, Object> map : primarykeys) {
			if (map.containsValue(field)) {
				return true;
			}
		}
		return false;
	}

	public Database getDatabase() {
		return database;
	}

	public void setDatabase(Database database) {
		this.database = database;
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

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public List<Field> getFieldList() {
		return fieldList;
	}

	public void setFieldList(List<Field> fieldList) {
		this.fieldList = fieldList;
	}

	public String[] getPrimarykeys() {
		return primarykeys;
	}

	public void setPrimarykeys(String[] primarykeys) {
		this.primarykeys = primarykeys;
	}

}