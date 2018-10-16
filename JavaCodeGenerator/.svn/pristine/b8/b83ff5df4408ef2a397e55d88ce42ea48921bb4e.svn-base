package com.misterfat.generator.exec;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.jdom.JDOMException;

import com.misterfat.generator.tool.gen.ModelTool;
import com.misterfat.generator.tool.gen.XmlTool;
import com.misterfat.generator.tool.model.TableModel;
import com.misterfat.generator.tool.util.CamelCaseUtil;
import com.misterfat.generator.tool.util.DateUtil;
import com.misterfat.generator.tool.util.Dom4jUtil;
import com.misterfat.generator.tool.util.FileUtil;
import com.misterfat.generator.tool.util.LogUtil;
import com.misterfat.generator.tool.util.PathUtil;
import com.misterfat.generator.tool.util.PropertiesUtil;
import com.misterfat.generator.tool.util.VelocityUtil;

import freemarker.template.TemplateException;

public class CodeGenerator {

	public static void main(String[] args) {
		String xmlPath = PathUtil.getProjectBasePath() + "/table.xml";
		String propertiesFilePath = PathUtil.getProjectBasePath() + "/gen.properties";
		try {
			// 生成代码
			generateCode(new File(xmlPath), new File(propertiesFilePath));
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	/**
	 * 
	 * 功能描述：生成代码
	 *
	 * @param tableXmlFile
	 * @param configFile
	 * 
	 * @author 耿沫然
	 * @throws TemplateException
	 * @throws IOException
	 * @throws DocumentException
	 * @throws JDOMException
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void generateCode(File tableXmlFile, File configFile)
			throws IOException, TemplateException, DocumentException {

		LogUtil.log();
		LogUtil.log("Generate Start");

		// 从XML获取元素集合
		List<Element> elements = Dom4jUtil.getElementsByTagName(tableXmlFile, "table");
		// 获取配置信息
		Map<String, String> config = PropertiesUtil.getConfig(configFile);
		// 表模型集合
		List<TableModel> tableList = new ArrayList<TableModel>();
		// 模板目录(从项目根目录开始)
		String oneByOneTmplBaseDir = PathUtil.getProjectBasePath() + "/template/velocity/springboot/one_by_one";
		String allInOneTmplBaseDir = PathUtil.getProjectBasePath() + "/template/velocity/springboot/all_in_one";

		String outputBaseDir = PathUtil.getProjectBasePath() + "/output";

		// 生成配置
		Map<String, String> generateConfig = new HashMap<String, String>();
		generateConfig.put("package", config.get("package").replace(".", "/"));
		generateConfig.put("module", config.get("module"));
		generateConfig.put("role", config.get("role"));
		generateConfig.put("Role", CamelCaseUtil.toCapitalizeCamelCase(config.get("role")));
		generateConfig.put("controllerPackage", config.get("controllerPackage"));
		generateConfig.put("pageBasePath", config.get("controllerPackage").replace(".", "/"));
		generateConfig.put("l", "/");
		generateConfig.put("u", "_");

		LogUtil.log("Clear outDir: " + outputBaseDir);
		FileUtil.clearDir(outputBaseDir);// 清空输出目录

		// 生成 one_by_one
		for (int i = 0; i < elements.size(); i++) {

			// 数据模型
			Map<String, Object> data = new HashMap<String, Object>();
			config.put("date", DateUtil.getDate("yyyy年MM月dd日"));
			data.put("config", config);
			Element element = elements.get(i);
			TableModel tableModel = XmlTool.elementToTableModel(element);
			// 加入表模型集合
			tableList.add(tableModel);

			data.put("tableModel", tableModel);
			Map<String, String> mybatisConfig = ModelTool.generateMybatisConfig(tableModel);
			data.put("mybatisConfig", mybatisConfig);

			generateConfig.put("className", tableModel.getClassName());
			generateConfig.put("objectName", tableModel.getObjectName());
			generateConfig.put("name", tableModel.getName());
			generateConfig.put("url", tableModel.getUrl());

			data.put("generateConfig", generateConfig);

			// 文件模板
			List<File> readFileList = FileUtil.readFileList(oneByOneTmplBaseDir, ".vsl");

			if (readFileList != null && !readFileList.isEmpty()) {

				for (File file : readFileList) {
					// 文件相对路径
					String relativePath = FileUtil.getRelativePath(file, oneByOneTmplBaseDir);
					// 文件相对目录
					String relativeDir = FileUtil.getFilePathFolder(relativePath);
					// 文件名不带后缀
					String filename = FileUtil.getFilename(file);

					// 替换文件名
					String[] filenameParams = filename.split("_");
					String outFileName = "";
					int length = filenameParams.length;
					for (int j = 0; j < length; j++) {
						String param = filenameParams[j];
						String replacement = null;
						if (param.startsWith("{{") && param.endsWith("}}")) {
							replacement = generateConfig.get(param.replace("{{", "").replace("}}", "").trim());
						}
						if (replacement != null) {
							outFileName += replacement;
						} else {
							outFileName += param;
						}

					}

					File outFile = new File(outputBaseDir + "/" + relativeDir + "/" + outFileName);
					VelocityUtil.generateFile(file, data, outFile);

					LogUtil.log("Generate:=>" + outFile.getPath());

				}
			}

		}

		// 生成all_in_one
		Map<String, Object> data = new HashMap<String, Object>();
		data.put("tableList", tableList);
		data.put("config", config);

		List<File> readFileList = FileUtil.readFileList(allInOneTmplBaseDir, ".vsl");// 文件模板

		if (readFileList != null && !readFileList.isEmpty()) {
			for (File file : readFileList) {
				// 文件相对路径
				String relativePath = FileUtil.getRelativePath(file, allInOneTmplBaseDir);
				// 文件相对目录
				String relativeDir = FileUtil.getFilePathFolder(relativePath);
				// 文件名不带后缀
				String filename = FileUtil.getFilename(file);

				// 替换文件名
				String[] filenameParams = filename.split("_");
				String outFileName = "";
				int length = filenameParams.length;
				for (int j = 0; j < length; j++) {
					String param = filenameParams[j];
					String replacement = null;
					if (param.startsWith("{{") && param.endsWith("}}")) {
						replacement = generateConfig.get(param.replace("{{", "").replace("}}", "").trim());
					}
					if (replacement != null) {
						outFileName += replacement;
					} else {
						outFileName += param;
					}

				}

				File outFile = new File(outputBaseDir + "/" + relativeDir + "/" + outFileName);
				VelocityUtil.generateFile(file, data, outFile);

				LogUtil.log("Generate:=>" + outFile.getPath());

			}
		}

		LogUtil.log("Generate Successful!");
	}

}
