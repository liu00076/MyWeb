package com.misterfat.generator.tool.util;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Iterator;
import java.util.Map;

import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.VelocityEngine;
import org.apache.velocity.runtime.resource.loader.ClasspathResourceLoader;

public class VelocityUtil {

	private static String encoding = "utf-8";

	/**
	 * 
	 * 功能描述：混合模板
	 *
	 * @param template
	 * @param ctx
	 * @param file
	 * @throws FileNotFoundException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void merge(Template template, VelocityContext ctx, File file) throws FileNotFoundException {
		PrintWriter writer = null;
		try {
			writer = new PrintWriter(file);
			template.merge(ctx, writer);
			writer.flush();
		} catch (FileNotFoundException e) {
			throw e;
		} finally {
			writer.close();
		}
	}

	/**
	 * 
	 * 功能描述：根据模板生成文件
	 *
	 * @param vmFile
	 * @param data
	 * @param file
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void generateFile(File vmFile, Map<String, Object> data, File file) throws IOException {

		if (!file.exists()) {
			FileUtil.createFile(file.getAbsolutePath());
		}

		VelocityEngine ve = new VelocityEngine();
		ve.setProperty(VelocityEngine.FILE_RESOURCE_LOADER_PATH, vmFile.getParent() + File.separator);
		ve.setProperty("input.encoding", encoding);
		ve.setProperty("output.encoding", encoding);
		ve.setProperty("classpath.resource.loader.class", ClasspathResourceLoader.class.getName());

		ve.init();
		Template template = ve.getTemplate(vmFile.getName());
		VelocityContext ctx = new VelocityContext();

		Iterator<String> iterator = data.keySet().iterator();
		while (iterator.hasNext()) {
			String key = iterator.next();
			ctx.put(key, data.get(key));

		}
		merge(template, ctx, file);

	}

}