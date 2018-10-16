package com.misterfat.generator.tool.util;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.Serializable;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;

public class PropertiesUtil implements Serializable {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = -3531561941531107834L;

	/**
	 * 
	 * 功能描述：获取配置文件信息
	 *
	 * @param file
	 * @return
	 * @throws FileNotFoundException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Map<String, String> getConfig(File file) throws FileNotFoundException, IOException {
		Properties pps = new Properties();
		pps.load(new FileInputStream(file));
		Enumeration<?> enum1 = pps.propertyNames();// 得到配置文件的名字
		Map<String, String> map = new HashMap<String, String>();
		while (enum1.hasMoreElements()) {
			String strKey = (String) enum1.nextElement();
			String strValue = pps.getProperty(strKey);
			map.put(strKey, strValue);
		}
		return map;
	}

	/**
	 * 
	 * 功能描述：根据key读取value
	 *
	 * @param filePath
	 * @param key
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String readValue(String filePath, String key) {
		Properties props = new Properties();
		try {
			InputStream in = new BufferedInputStream(new FileInputStream(filePath));
			props.load(in);
			String value = props.getProperty(key);
			System.out.println(key + value);
			return value;
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}

	/**
	 * 
	 * 功能描述：读取properties的全部信息
	 *
	 * @param filePath
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Properties readProperties(String filePath) {
		Properties props = new Properties();
		InputStream in = null;
		try {
			in = new BufferedInputStream(new FileInputStream(filePath));
			props.load(in);
		} catch (Exception e) {
		} finally {
			if (in != null) {
				try {
					in.close();
					in = null;
				} catch (IOException e) {
					in = null;
				}
			}
		}
		return props;
	}

	/**
	 * 
	 * 功能描述：写入properties信息
	 *
	 * @param filePath
	 * @param parameterName
	 * @param parameterValue
	 * 
	 * @author 耿沫然
	 * @throws IOException
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void writeProperties(String filePath, String parameterName, String parameterValue)
			throws IOException {
		Properties prop = new Properties();
		InputStream fis = null;
		OutputStream fos = null;
		try {
			fis = new FileInputStream(filePath);
			// 从输入流中读取属性列表（键和元素对）
			prop.load(fis);
			// 调用 Hashtable 的方法 put。使用 getProperty 方法提供并行性。
			// 强制要求为属性的键和值使用字符串。返回值是 Hashtable 调用 put 的结果。
			fos = new FileOutputStream(filePath);
			prop.setProperty(parameterName, parameterValue);
			// 以适合使用 load 方法加载到 Properties 表中的格式，
			// 将此 Properties 表中的属性列表（键和元素对）写入输出流
			prop.store(fos, "Update '" + parameterName + "' value");
		} catch (IOException e) {
			throw e;
		} finally {
			if (fis != null) {
				try {
					fis.close();
					fis = null;
				} catch (IOException e) {
					fis = null;
				}
			}
			if (fos != null) {
				try {
					fos.close();
					fos = null;
				} catch (IOException e) {
					fos = null;
				}
			}
		}
	}

	/**
	 * 
	 * 功能描述：覆盖写文件
	 *
	 * @param filePath
	 * @param prop
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void writeProperties(String filePath, Properties prop) throws IOException {
		OutputStream fos = null;
		try {
			fos = new FileOutputStream(filePath);
			prop.store(fos, "write => " + filePath);
		} catch (IOException e) {
			throw e;
		} finally {
			if (fos != null) {
				try {
					fos.close();
					fos = null;
				} catch (IOException e) {
					fos = null;
				}
			}
		}
	}

}