package com.misterfat.generator.exec;

import java.io.File;
import java.util.Properties;

import com.misterfat.generator.tool.db.product.MysqlDatabase;
import com.misterfat.generator.tool.gen.XmlTool;
import com.misterfat.generator.tool.util.PathUtil;
import com.misterfat.generator.tool.util.PropertiesUtil;

public class MysqlCodeGenerator {

	public static void main(String[] args) {
		String xmlPath = PathUtil.getProjectBasePath() + "/table.xml";
		String propertiesFilePath = PathUtil.getProjectBasePath() + "/gen.properties";
		// String[] tableNames = new String[] { "account_detailed", "article",
		// "article_comment", "article_comment_praise",
		// "article_share", "artwork_auth_setting", "artwork_content",
		// "artwork_info", "artwork_info_statistics",
		// "artwork_property", "artwork_set", "artwork_set_artworks",
		// "artwork_setting", "auth_info", "category",
		// "common_file", "data_dict", "feature", "link_account", "message",
		// "message_record", "message_template",
		// "oauth_access_token", "oauth_client_details", "oauth_code",
		// "operation_log", "person", "person_account",
		// "person_area", "person_follow", "person_info_data",
		// "person_info_statistics", "person_like",
		// "person_settings", "platform_notification",
		// "platform_notification_queue", "platform_notification_read",
		// "product", "product_comment", "product_comment_praise",
		// "product_file", "product_like", "product_view",
		// "receipt_address", "sale_unit", "sale_unit_feature",
		// "message_notification_setting",
		// "person_blacklist" };
		String[] tableNames = new String[] { "girl" };
		// 1.查询表信息
		MysqlDatabase mysqlDatabase = new MysqlDatabase("jdbc:sqlserver://10.5.234.78;database=dbgirl",	"sa", "Passw0rd");
		
		//MysqlDatabase mysqlDatabase = new MysqlDatabase("jdbc:mysql://localhost:3306/gen-test?characterEncoding=utf-8","root", "new.1234");
		
		try {
			// 生成XML
			// mysqlDatabase.getAllTalbes()
			XmlTool.generateTable(mysqlDatabase, tableNames, xmlPath);

			// 生成配置文件
			Properties properties = new Properties();
			properties.setProperty("package", "com.centa.agency");
			properties.setProperty("module", "core");
			properties.setProperty("version", "1.0");
			properties.setProperty("author", "");
			properties.setProperty("role", "user");
			properties.setProperty("controllerPackage", "user");
			properties.setProperty("tableXmlPath", xmlPath);
			PropertiesUtil.writeProperties(propertiesFilePath, properties);
			// 生成代码
			CodeGenerator.generateCode(new File(xmlPath), new File(propertiesFilePath));

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
