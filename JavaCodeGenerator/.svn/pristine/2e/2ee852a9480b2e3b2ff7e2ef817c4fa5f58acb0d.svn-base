package com.misterfat.generator.tool.util;

import java.beans.BeanInfo;
import java.beans.IntrospectionException;
import java.beans.Introspector;
import java.beans.PropertyDescriptor;
import java.io.File;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.List;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;
import org.jdom.JDOMException;

public class Dom4jUtil {

	/**
	 * 
	 * 功能描述：获取xml文档对象
	 *
	 * @param file
	 * @return
	 * @throws JDOMException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 * @throws DocumentException
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Document getDocument(File file) throws DocumentException {
		SAXReader reader = new SAXReader();
		Document document = reader.read(file);
		return document;
	}

	/**
	 * 
	 * 功能描述：获取文档根元素
	 *
	 * @param file
	 * @return
	 * @throws JDOMException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 * @throws DocumentException
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Element getRootElement(File file) throws DocumentException {
		return getDocument(file).getRootElement();
	}

	/**
	 * 
	 * 功能描述：获取文档元素
	 *
	 * @param file
	 * @param tagName
	 * @return
	 * @throws JDOMException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 * @throws DocumentException
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@SuppressWarnings("unchecked")
	public static List<Element> getElementsByTagName(File file, String tagName) throws DocumentException {
		return getDocument(file).getRootElement().elements(tagName);
	}

	/**
	 * 
	 * 功能描述：对象转为DOM节点
	 *
	 * @param bean
	 * @param parentElement
	 * @param elementName
	 * @param ignore
	 * @return
	 * @throws IntrospectionException
	 * @throws IllegalAccessException
	 * @throws IllegalArgumentException
	 * @throws InvocationTargetException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Element beanToElement(Object bean, Element parentElement, String elementName, String[] ignore)
			throws IntrospectionException, IllegalAccessException, IllegalArgumentException, InvocationTargetException {

		Class<? extends Object> beanClass = bean.getClass();
		Element tableElement = parentElement.addElement(elementName);
		BeanInfo beanInfo = Introspector.getBeanInfo(beanClass);

		PropertyDescriptor[] propertyDescriptors = beanInfo.getPropertyDescriptors();
		for (int i = 0; i < propertyDescriptors.length; i++) {
			PropertyDescriptor descriptor = propertyDescriptors[i];
			String propertyName = descriptor.getName();
			boolean isIgnore = false;
			for (int j = 0; j < ignore.length; j++) {
				if (propertyName.equals(ignore[j])) {
					isIgnore = true;
				}
			}
			if (!propertyName.equals("class") && !isIgnore) {
				Method readMethod = descriptor.getReadMethod();
				Object result = readMethod.invoke(bean, new Object[0]);
				generateDom(tableElement, propertyName, result);

			}
		}
		return tableElement;
	}

	/**
	 * 
	 * 功能描述：生成DOM结构
	 *
	 * @param bean
	 * @param parentElement
	 * @param elementName
	 * @return
	 * @throws IntrospectionException
	 * @throws IllegalAccessException
	 * @throws IllegalArgumentException
	 * @throws InvocationTargetException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Element beanToElement(Object bean, Element parentElement, String elementName)
			throws IntrospectionException, IllegalAccessException, IllegalArgumentException, InvocationTargetException {
		return beanToElement(bean, parentElement, elementName, new String[0]);
	}

	/**
	 * 
	 * 功能描述：生成DOM结构
	 *
	 * @param bean
	 * @param parentElement
	 * @return
	 * @throws IntrospectionException
	 * @throws IllegalAccessException
	 * @throws IllegalArgumentException
	 * @throws InvocationTargetException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Element beanToElement(Object bean, Element parentElement)
			throws IntrospectionException, IllegalAccessException, IllegalArgumentException, InvocationTargetException {
		String className = bean.getClass().getName().toLowerCase();
		String elementName = className.substring(className.lastIndexOf(".") + 1);
		return beanToElement(bean, parentElement, elementName);
	}

	/**
	 * 
	 * 功能描述：生成DOM结构
	 *
	 * @param parentElement
	 * @param propertyName
	 * @param object
	 * 
	 * @author 耿沫然
	 * @throws IntrospectionException
	 * @throws InvocationTargetException
	 * @throws IllegalArgumentException
	 * @throws IllegalAccessException
	 *
	 * @since 2016年5月24日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	@SuppressWarnings("unchecked")
	public static void generateDom(Element parentElement, String propertyName, Object object)
			throws IllegalAccessException, IllegalArgumentException, InvocationTargetException, IntrospectionException {
		if (object != null) {
			if (object instanceof String) {
				parentElement.addAttribute(propertyName, (String) object);
			} else if (object instanceof Integer) {
				parentElement.addAttribute(propertyName, String.valueOf(object));
			} else if (object instanceof String[]) {
				String[] array = (String[]) object;
				parentElement.addAttribute(propertyName, ArrayUtil.join(array, ","));
			} else if (object instanceof List) {
				List<Object> list = (List<Object>) object;
				if (!list.isEmpty()) {
					for (Object obj : list) {
						beanToElement(obj, parentElement);
					}
				}
			}
		}
	}

}
