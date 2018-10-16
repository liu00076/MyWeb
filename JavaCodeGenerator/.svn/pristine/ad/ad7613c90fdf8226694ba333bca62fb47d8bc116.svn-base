package com.misterfat.generator.tool.gen;

import java.beans.IntrospectionException;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.Serializable;
import java.lang.reflect.InvocationTargetException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.io.OutputFormat;
import org.dom4j.io.XMLWriter;

import com.misterfat.generator.tool.Constants;
import com.misterfat.generator.tool.db.Database;
import com.misterfat.generator.tool.db.Field;
import com.misterfat.generator.tool.db.Table;
import com.misterfat.generator.tool.model.FieldModel;
import com.misterfat.generator.tool.model.TableModel;
import com.misterfat.generator.tool.util.Dom4jUtil;
import com.misterfat.generator.tool.util.LogUtil;

public class XmlTool implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = 3168544225178976464L;

	/**
	 * 
	 * 功能描述：生成一张表的XML元素
	 *
	 * @param database
	 * @param table
	 * @param root
	 * @throws SQLException
	 * 
	 * @author 耿沫然
	 * @throws IntrospectionException
	 * @throws InvocationTargetException
	 * @throws IllegalArgumentException
	 * @throws IllegalAccessException
	 *
	 * @since 2016年5月23日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void genarateTableElement(Database database, Table table, Element root) throws SQLException,
			IllegalAccessException, IllegalArgumentException, InvocationTargetException, IntrospectionException {

		table.queryFieldList();
		Dom4jUtil.beanToElement(table, root);

	}

	/**
	 * 
	 * 功能描述：生成XML
	 *
	 * @param mysqlDatabase
	 * @param tableNames
	 * @param xmlPath
	 * @throws SQLException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 * @throws IntrospectionException
	 * @throws InvocationTargetException
	 * @throws IllegalArgumentException
	 * @throws IllegalAccessException
	 *
	 * @since 2016年5月23日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void generateTable(Database mysqlDatabase, String[] tableNames, String xmlPath)
			throws SQLException, IOException, IllegalAccessException, IllegalArgumentException,
			InvocationTargetException, IntrospectionException {
		// 获得表
		mysqlDatabase.getTalbes(tableNames);
		List<Table> tableList = mysqlDatabase.getTableList();

		generateTable(mysqlDatabase, tableList, xmlPath);

	}

	/**
	 * 
	 * 功能描述：生成XML
	 *
	 * @param mysqlDatabase
	 * @param tableList
	 * @param xmlPath
	 * @throws SQLException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 * @throws IntrospectionException
	 * @throws InvocationTargetException
	 * @throws IllegalArgumentException
	 * @throws IllegalAccessException
	 *
	 * @since 2016年5月23日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void generateTable(Database mysqlDatabase, List<Table> tableList, String xmlPath)
			throws SQLException, IllegalAccessException, InvocationTargetException, IntrospectionException {
		// 生成xml
		Document doc = DocumentHelper.createDocument();
		Element root = doc.addElement("database");
		doc.setRootElement(root);

		for (Table table : tableList) {
			genarateTableElement(mysqlDatabase, table, doc.getRootElement());
		}

		File file = new File(xmlPath);
		try {
			if (!file.exists()) {
				file.createNewFile();
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		// 实例化输出格式对象
		OutputFormat format = OutputFormat.createPrettyPrint();
		// 设置输出编码
		format.setEncoding("UTF-8");

		XMLWriter writer = null;
		try {
			LogUtil.log(doc.asXML());
			// 生成XMLWriter对象，构造函数中的参数为需要输出的文件流和格式
			writer = new XMLWriter(new FileOutputStream(file), format);
			// 开始写入，write方法中包含上面创建的Document对象
			writer.write(doc);
		} catch (Exception ex) {
			ex.printStackTrace();
		} finally {
			try {
				if (writer != null) {
					writer.close();
				}
				writer = null;
			} catch (IOException localIOException1) {
				writer = null;
			}
		}
	}

	/**
	 * 
	 * 功能描述：根据DOM获到Table对象
	 *
	 * @param element
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@SuppressWarnings("unchecked")
	public static Table elementToTable(Element element) {
		Table table = new Table();
		table.setName(element.attributeValue("name"));
		table.setComment(element.attributeValue("comment"));
		table.setType(element.attributeValue("type"));
		table.setPrimarykeys(element.attributeValue("primarykeys").split(","));
		List<Element> fieldElements = element.elements("field");
		List<Field> fieldList = new ArrayList<Field>();
		for (Element fieldElement : fieldElements) {
			fieldList.add(elementToField(fieldElement));
		}
		table.setFieldList(fieldList);
		return table;
	}

	/**
	 * 
	 * 功能描述：根据DOM获到TableModel对象
	 *
	 * @param element
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@SuppressWarnings("unchecked")
	public static TableModel elementToTableModel(Element element) {
		TableModel table = new TableModel();
		table.setName(element.attributeValue("name"));
		table.setComment(element.attributeValue("comment"));
		table.setType(element.attributeValue("type"));
		table.setPrimarykeys(element.attributeValue("primarykeys").split(","));
		List<Element> fieldElements = element.elements("field");
		List<FieldModel> fieldList = new ArrayList<FieldModel>();
		for (Element fieldElement : fieldElements) {
			FieldModel fieldModel = elementToFieldModel(fieldElement);
			fieldList.add(fieldModel);
			String fieldJavaType = fieldModel.getJavaType();

			if ("BigDecimal".equals(fieldJavaType)) {
				table.setHasBigDecimal(Constants.TRUE);
			} else if ("Date".equals(fieldJavaType)) {
				table.setHasDate(Constants.TRUE);
			}
		}
		table.setFieldList(fieldList);
		return table;
	}

	/**
	 * 
	 * 功能描述：根据DOM获到Field对象
	 *
	 * @param element
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Field elementToField(Element element) {
		Field field = new Field();
		field.setName(element.attributeValue("name"));
		field.setComment(element.attributeValue("comment"));
		field.setFieldLength(element.attributeValue("fieldLength"));
		field.setFieldType(element.attributeValue("fieldType"));
		field.setNullable(element.attributeValue("nullable"));
		field.setPrimaryKey(element.attributeValue("primaryKey"));
		field.setScale(element.attributeValue("scale"));

		return field;
	}

	/**
	 * 
	 * 功能描述：根据DOM获到FieldModel对象
	 *
	 * @param element
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static FieldModel elementToFieldModel(Element element) {
		FieldModel field = new FieldModel();
		field.setName(element.attributeValue("name"));
		field.setComment(element.attributeValue("comment"));
		field.setFieldLength(element.attributeValue("fieldLength"));
		field.setFieldType(element.attributeValue("fieldType"));
		field.setNullable(element.attributeValue("nullable"));
		field.setPrimaryKey(element.attributeValue("primaryKey"));
		field.setScale(element.attributeValue("scale"));

		return field;
	}

}