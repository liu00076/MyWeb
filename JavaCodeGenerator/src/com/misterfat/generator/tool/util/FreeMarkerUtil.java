package com.misterfat.generator.tool.util;

import java.io.BufferedWriter;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.StringWriter;
import java.io.Writer;
import java.util.Map;

import freemarker.cache.FileTemplateLoader;
import freemarker.cache.TemplateLoader;
import freemarker.template.Configuration;
import freemarker.template.Template;
import freemarker.template.TemplateException;
import freemarker.template.Version;

/**
 * FreeMarker操作类
 * 
 * @author sunjun
 * 
 */
public class FreeMarkerUtil {

	/**
	 * 编码
	 */
	private static String encoding = "utf-8";

	private static String version = "2.3.0";

	/**
	 * 构造方法
	 * 
	 * @throws IOException
	 */
	private FreeMarkerUtil() {
	}

	/**
	 * 生成静态页面
	 * 
	 * @param ftlFile
	 *            模板文件(相对根目录的绝对路径，以/开头)
	 * @param data
	 *            数据Map
	 * @param file
	 *            生成的文件
	 * @throws IOException
	 * @throws TemplateException
	 */
	public static void generateFile(File ftlFile, Map<String, Object> data, File file)
			throws IOException, TemplateException {
		FileOutputStream fileOutputStream = null;
		OutputStreamWriter outputStream = null;
		Writer out = null;

		try {

			if (!file.exists()) {
				FileUtil.createFile(file.getAbsolutePath());
			}

			Configuration configuration = new Configuration(new Version(version));
			configuration.setDefaultEncoding(encoding);
			TemplateLoader loader = new FileTemplateLoader(new File(ftlFile.getParent() + File.separator));
			configuration.setTemplateLoader(loader);

			Template template = configuration.getTemplate(ftlFile.getName());
			fileOutputStream = new FileOutputStream(file);
			outputStream = new OutputStreamWriter(fileOutputStream, "UTF-8");
			out = new BufferedWriter(outputStream);

			template.process(data, out);

		} catch (FileNotFoundException e) {
			throw e;
		} catch (IOException e) {
			throw e;
		} catch (TemplateException e) {
			throw e;
		} finally {
			try {
				if (fileOutputStream != null) {
					fileOutputStream.close();
					fileOutputStream = null;
				}
			} catch (Exception e) {
				fileOutputStream = null;
			}
			try {
				if (outputStream != null) {
					outputStream.close();
					outputStream = null;
				}
			} catch (Exception e) {
				outputStream = null;
			}
			try {
				if (out != null) {
					out.close();
					out = null;
				}
			} catch (Exception e) {
				out = null;
			}
		}
	}

	/**
	 * 输出到字符串
	 * 
	 * @param ftlFile
	 *            模板文件(相对根目录的绝对路径，以/开头)
	 * @param data
	 *            数据Map
	 * @return 结果字符串
	 */
	public static String getString(String ftlFile, Map<String, Object> data) {
		StringWriter writer = null;
		String result = "";
		try {
			Configuration config = new Configuration(new Version(version));
			Template template = config.getTemplate(ftlFile);
			writer = new StringWriter();
			template.process(data, writer);
			result = writer.toString();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 关闭write
			try {
				if (writer != null) {
					writer.flush();
					writer.close();
				}
			} catch (Exception ex) {
				ex.printStackTrace();
			}
		}
		return result;
	}

	/**
	 * 输出到内存
	 * 
	 * @param ftlFile
	 *            模板文件(相对模板文件目录的相对路径)
	 * @param data
	 *            数据Map
	 * @return ByteArrayOutputStream
	 * @throws IOException
	 */
	public static ByteArrayOutputStream createByteArray(String ftlFile, Map<String, Object> data) throws IOException {
		ByteArrayOutputStream os = null;
		BufferedWriter writer = null;
		try {

			Configuration config = new Configuration(new Version(version));
			Template template = config.getTemplate(ftlFile);
			os = new ByteArrayOutputStream();
			writer = new BufferedWriter(new OutputStreamWriter(os));
			template.process(data, writer);
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 关闭os write
			if (writer != null) {
				writer.flush();
				writer.close();
			}
			if (os != null) {
				os.flush();
				os.close();
			}
		}
		return os;
	}
}