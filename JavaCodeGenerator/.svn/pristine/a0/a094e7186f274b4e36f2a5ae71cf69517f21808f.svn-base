package com.misterfat.generator.tool.gen;

import java.io.Serializable;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.misterfat.generator.tool.Constants;
import com.misterfat.generator.tool.model.FieldModel;
import com.misterfat.generator.tool.model.TableModel;
import com.misterfat.generator.tool.util.CamelCaseUtil;

/**
 * 
 * 数据模型工具
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2016年5月25日
 */
public class ModelTool implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = 4739325069622404804L;

	/**
	 * 
	 * 功能描述：生成mybatis需要的模板数据
	 *
	 * @param tableModel
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Map<String, String> generateMybatisConfig(TableModel tableModel) {
		Map<String, String> ele = new HashMap<String, String>();

		List<FieldModel> proList = tableModel.getFieldList();

		String json = "";
		String fields = "";
		String fieldsValues = "";
		String insertSelective = "";
		String insertSelectiveValues = "";
		String update = "";
		String updateSelective = "";
		String results = "";
		String where = "";
		String likeWhere = "";
		String toString = "\"{";

		json += tableModel.getObjectName() + ":{";

		if (proList != null && !proList.isEmpty()) {

			for (FieldModel fieldModel : proList) {

				String fieldName = fieldModel.getName();
				String proName = fieldModel.getPropertyName();
				String cnName = fieldModel.getComment();
				String jdbcType = fieldModel.getJdbcType();
				String javaType = fieldModel.getJavaType();

				json += "\"" + proName + "\":" + "\"" + cnName + "\",";
				fields += fieldName + ",";
				fieldsValues += "#{" + proName + ",jdbcType=" + jdbcType + "},";
				insertSelective += "<if test=\\\"" + proName + " != null\\\" > " + fieldName + ", </if> ";
				insertSelective += "\",\"";
				insertSelectiveValues += " <if test=\\\"" + proName + " != null\\\" > #{" + proName + ",jdbcType="
						+ jdbcType + "}, </if>";
				insertSelectiveValues += "\",\"";
				update += fieldName + "= #{" + proName + ",jdbcType=" + jdbcType + "},";
				updateSelective += "<if test=\\\"" + proName + " != null\\\" > " + fieldName + " = #{" + proName
						+ ",jdbcType=" + jdbcType + "}, </if> ";
				updateSelective += "\",\"";
				results += "@Result(column = \"" + fieldName + "\", property = \"" + proName
						+ "\" , jdbcType = JdbcType." + jdbcType.trim();
				where += "<if test=\\\"" + proName + " != null\\\" > and " + fieldName + " = #{" + proName
						+ ",jdbcType=" + jdbcType + "} </if>";
				where += "\",\"";
				where += "<if test=\\\"" + proName + "Or" + " != null\\\" > or " + fieldName + " = #{" + proName + "Or"
						+ ",jdbcType=" + jdbcType + "} </if>";
				where += "\",\"";

				likeWhere += "<if test=\\\"" + proName + " != null\\\" > and " + fieldName + " = #{" + proName
						+ ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "In" + " != null\\\" > and " + fieldName
						+ " in <foreach  item=\\\"item\\\"  collection=\\\"" + proName + "In"
						+ "\\\" open=\\\"(\\\" separator=\\\",\\\" close=\\\")\\\" > #{item} </foreach> </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "NotIn" + " != null\\\" > and " + fieldName
						+ " not in <foreach  item=\\\"item\\\"  collection=\\\"" + proName + "NotIn"
						+ "\\\" open=\\\"(\\\" separator=\\\",\\\" close=\\\")\\\" > #{item} </foreach> </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "Not" + " != null\\\" > and " + fieldName + " != #{" + proName
						+ "Not" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "GreaterThan" + " != null\\\" > and " + fieldName
						+ " <![CDATA[>]]>  #{" + proName + "GreaterThan" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "LessThan" + " != null\\\" > and " + fieldName
						+ " <![CDATA[<]]>  #{" + proName + "LessThan" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "GreaterEqual" + " != null\\\" > and " + fieldName
						+ " <![CDATA[>=]]>  #{" + proName + "GreaterEqual" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "LessEqual" + " != null\\\" > and " + fieldName
						+ " <![CDATA[<=]]>  #{" + proName + "LessEqual" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "IsNull" + " != null\\\" > and " + fieldName
						+ " is null </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "IsNotNull" + " != null\\\" > and " + fieldName
						+ " is not null </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "Like" + " != null\\\" > and " + fieldName
						+ " like CONCAT('%', #{" + proName + "Like" + ",jdbcType=" + jdbcType + "},'%') </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "NotLike" + " != null\\\" > and " + fieldName
						+ " not like CONCAT('%', #{" + proName + "NotLike" + ",jdbcType=" + jdbcType + "},'%') </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "StartWith" + " != null\\\" > and " + fieldName
						+ " like CONCAT( #{" + proName + "StartWith" + ",jdbcType=" + jdbcType + "},'%')  </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "NotStartWith" + " != null\\\" > and " + fieldName
						+ " not like CONCAT( #{" + proName + "NotStartWith" + ",jdbcType=" + jdbcType + "},'%')  </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "EndWith" + " != null\\\" > and " + fieldName
						+ " like CONCAT('%',  #{" + proName + "EndWith" + ",jdbcType=" + jdbcType + "}) </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "NotEndWith" + " != null\\\" > and " + fieldName
						+ " not like CONCAT( '%', #{" + proName + "NotEndWith" + ",jdbcType=" + jdbcType + "}) </if>";

				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "Or != null\\\" > or " + fieldName + " = #{" + proName
						+ "Or,jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrIn" + " != null\\\" > or " + fieldName
						+ " in <foreach  item=\\\"item\\\"  collection=\\\"" + proName + "OrIn"
						+ "\\\" open=\\\"(\\\" separator=\\\",\\\" close=\\\")\\\" > #{item} </foreach> </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrNotIn" + " != null\\\" > or " + fieldName
						+ "  not in <foreach  item=\\\"item\\\"  collection=\\\"" + proName + "OrNotIn"
						+ "\\\" open=\\\"(\\\" separator=\\\",\\\" close=\\\")\\\" > #{item} </foreach> </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrNot" + " != null\\\" > or " + fieldName + " != #{" + proName
						+ "OrNot" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrGreaterThan" + " != null\\\" > or " + fieldName
						+ " <![CDATA[>]]>  #{" + proName + "OrGreaterThan" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrLessThan" + " != null\\\" > or " + fieldName
						+ " <![CDATA[<]]>  #{" + proName + "OrLessThan" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrGreaterEqual" + " != null\\\" > or " + fieldName
						+ " <![CDATA[>=]]>  #{" + proName + "OrGreaterEqual" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrLessEqual" + " != null\\\" > or " + fieldName
						+ " <![CDATA[<=]]>  #{" + proName + "OrLessEqual" + ",jdbcType=" + jdbcType + "} </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrIsNull" + " != null\\\" > or " + fieldName
						+ " is null </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrIsNotNull" + " != null\\\" > or " + fieldName
						+ " is not null </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrLike" + " != null\\\" > or " + fieldName
						+ " like CONCAT('%', #{" + proName + "OrLike" + ",jdbcType=" + jdbcType + "},'%') </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrNotLike" + " != null\\\" > or " + fieldName
						+ " not like CONCAT('%', #{" + proName + "OrNotLike" + ",jdbcType=" + jdbcType + "},'%') </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrStartWith" + " != null\\\" > or " + fieldName
						+ " like CONCAT( #{" + proName + "OrStartWith" + ",jdbcType=" + jdbcType + "},'%')  </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrNotStartWith" + " != null\\\" > or " + fieldName
						+ " not like CONCAT( #{" + proName + "OrNotStartWith" + ",jdbcType=" + jdbcType
						+ "},'%')  </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrEndWith" + " != null\\\" > or " + fieldName
						+ " like CONCAT('%',  #{" + proName + "OrEndWith" + ",jdbcType=" + jdbcType + "}) </if>";
				likeWhere += "\",\"";
				likeWhere += "<if test=\\\"" + proName + "OrNotEndWith" + " != null\\\" > or " + fieldName
						+ " not like CONCAT( '%', #{" + proName + "OrNotEndWith" + ",jdbcType=" + jdbcType + "}) </if>";

				String yinhao = "Integer".equals(javaType) ? "" : "\'";
				toString += "\'" + proName + "\':" + yinhao + "\" + " + proName + " + \"" + yinhao;
				toString += ",";

				if (Constants.TRUE.equals(fieldModel.getPrimaryKey())) {
					ele.put("fieldId", fieldName);
					ele.put("propId", proName);
					ele.put("firstUpperPropId", CamelCaseUtil.toCapitalizeCamelCase(fieldName));
					ele.put("idJdbcType", jdbcType);
					results += " ,id = true ";
				}
				results += " ),";

			}
			json = json.substring(0, json.length() - 1);
			json += "}";
			fields = fields.substring(0, fields.length() - 1);
			fieldsValues = fieldsValues.substring(0, fieldsValues.length() - 1);
			update = update.substring(0, update.length() - 1);
			results = results.substring(0, results.length() - 1);
			toString = toString.substring(0, toString.length() - 1);
			toString += "}\"";

			System.out.println(json);
			ele.put("json", json);
			ele.put("fields", fields);
			ele.put("fieldsValues", fieldsValues);
			ele.put("insertSelective", insertSelective);
			ele.put("insertSelectiveValues", insertSelectiveValues);
			ele.put("update", update);
			ele.put("updateSelective", updateSelective);
			ele.put("results", results);
			ele.put("where", where);
			ele.put("likeWhere", likeWhere);
			ele.put("toString", toString);
		}
		return ele;

	}
}