package com.misterfat.generator.tool.util;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Map;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFCellStyle;
import org.apache.poi.hssf.usermodel.HSSFRichTextString;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.openxml4j.exceptions.InvalidFormatException;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.ss.usermodel.WorkbookFactory;

/**
 * poi 导出excel 工具类
 */
public class POIExcelUtil {

	private static Log logger = LogFactory.getLog(POIExcelUtil.class);

	private static final String DEFAULT_SHEET_NAME = "sheet0";

	private static final String DEFAULT_DATETIME_PARTTEN = "yyyy-MM-dd HH:mm:ss";

	public static final String WORDS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public static final String READ_TYPE_ROW = "ROW_BY_ROW";
	public static final String READ_TYPE_COLUMN = "COLUMN_BY_COLUMN";

	/**
	 * 得到工作簿
	 * 
	 * @return
	 */
	public static HSSFWorkbook getHSSFWorkbook() {
		return new HSSFWorkbook();
	}

	/**
	 * 
	 * 功能描述：字符串按指定格式转成时间
	 *
	 * @param datestr
	 * @param pattern
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月20日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Date parseDate(String datestr, String pattern) {

		Date date = null;
		if (null == pattern || "".equals(pattern)) {
			pattern = DEFAULT_DATETIME_PARTTEN;
		}

		try {
			SimpleDateFormat formater = new SimpleDateFormat(pattern);
			date = formater.parse(datestr);
		} catch (ParseException e) {
			e.printStackTrace();
			throw new RuntimeException("日期" + datestr + "不能通过" + pattern + "格式解析");
		}

		return date;
	}

	/**
	 * 字符串首字母大写
	 * 
	 * capitalize(null) = null capitalize("") = "" capitalize("cat") = "Cat"
	 * capitalize("cAt") = "CAt"
	 * 
	 * @param str
	 * @return
	 */
	private static String capitalize(final String str) {
		int strLen;
		if (str == null || (strLen = str.length()) == 0) {
			return str;
		}

		final char firstChar = str.charAt(0);
		if (Character.isTitleCase(firstChar)) {
			// already capitalized
			return str;
		}

		return new StringBuilder(strLen).append(Character.toTitleCase(firstChar)).append(str.substring(1)).toString();
	}

	/**
	 * 执行get方法
	 * 
	 * @param target
	 * @param propertyName
	 * @return
	 */
	private static Object invokeGetterMethod(Object target, String propertyName) {
		String getterMethodName = "get" + capitalize(propertyName);
		return invokeMethod(target, getterMethodName, new Class[] {}, new Object[] {});
	}

	/**
	 * 执行方法
	 * 
	 * @param object
	 * @param methodName
	 * @param parameterTypes
	 * @param parameters
	 * @return
	 */
	private static Object invokeMethod(final Object object, final String methodName, final Class<?>[] parameterTypes,
			final Object[] parameters) {
		Method method = getDeclaredMethod(object, methodName, parameterTypes);
		if (method == null) {
			throw new IllegalArgumentException("Could not find method [" + methodName + "] parameterType "
					+ parameterTypes + " on target [" + object + "]");
		}

		method.setAccessible(true);

		try {
			return method.invoke(object, parameters);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	/**
	 * 得到声明的方法
	 * 
	 * @param object
	 * @param methodName
	 * @param parameterTypes
	 * @return
	 */
	private static Method getDeclaredMethod(Object object, String methodName, Class<?>[] parameterTypes) {

		if (object == null) {
			throw new RuntimeException("object不能为 null");
		}

		for (Class<?> superClass = object.getClass(); superClass != Object.class; superClass = superClass
				.getSuperclass()) {
			try {
				return superClass.getDeclaredMethod(methodName, parameterTypes);
			} catch (NoSuchMethodException e) {

			}
		}
		return null;
	}

	/************************************************ 写方法 ******************************************************************/

	/**
	 * 
	 * 导出Excel到文件路径
	 * 
	 * @param hssfworkbook
	 *            工作簿
	 * @param headList
	 *            标题的列表 list中存放map 如: map.put("field", 字段名); 必要 map.put("title",
	 *            显示的标题); 必要 map.put("titleStyle", HSSFCellStyle 标题单元格的样式);
	 *            map.put("dataStyle", HSSFCellStyle 内容单元格的样式);
	 *            map.put("autoColumnWidth", Boolean 是否自动调整列宽);
	 *            map.put("partten", String 内容格式);
	 * @param dataList
	 *            数据列表
	 * @param filePath
	 *            导出文件的完整路径,包话XLS、XLSX后缀名
	 */
	public static <T> void writeExcel(HSSFWorkbook hssfworkbook, List<Map<String, Object>> headList, List<T> dataList,
			String filePath) {
		writeExcel(hssfworkbook, DEFAULT_SHEET_NAME, headList, dataList, filePath);
	}

	/**
	 * 
	 * 导出Excel到输出流
	 * 
	 * @param hssfworkbook
	 *            工作簿
	 * @param headList
	 *            标题的列表 list中存放map 如: map.put("field", 字段名); 必要 map.put("title",
	 *            显示的标题); 必要 map.put("titleStyle", HSSFCellStyle 标题单元格的样式);
	 *            map.put("dataStyle", HSSFCellStyle 内容单元格的样式);
	 *            map.put("autoColumnWidth", Boolean 是否自动调整列宽);
	 *            map.put("partten", String 内容格式);
	 * @param dataList
	 *            数据列表
	 * @param out
	 *            输出流
	 * @throws IOException
	 */
	public static <T> void writeExcel(HSSFWorkbook hssfworkbook, List<Map<String, Object>> headList, List<T> dataList,
			OutputStream out) throws IOException {
		writeExcel(hssfworkbook, DEFAULT_SHEET_NAME, headList, dataList, out);
	}

	/**
	 * 
	 * 导出Excel到文件路径
	 * 
	 * @param hssfworkbook
	 *            工作簿
	 * @param sheet
	 *            工作表名
	 * @param headList
	 *            标题的列表 list中存放map 如: map.put("field", 字段名); 必要 map.put("title",
	 *            显示的标题); 必要 map.put("titleStyle", HSSFCellStyle 标题单元格的样式);
	 *            map.put("dataStyle", HSSFCellStyle 内容单元格的样式);
	 *            map.put("autoColumnWidth", Boolean 是否自动调整列宽);
	 *            map.put("partten", String 内容格式);
	 * @param dataList
	 *            数据列表
	 * @param filePath
	 *            导出文件的完整路径,包话XLS、XLSX后缀名
	 */
	public static <T> void writeExcel(HSSFWorkbook hssfworkbook, String sheet, List<Map<String, Object>> headList,
			List<T> dataList, String filePath) {
		FileOutputStream fos = null;
		try {
			fos = new FileOutputStream(new File(filePath));
			writeExcel(hssfworkbook, sheet, headList, dataList, fos);
		} catch (FileNotFoundException e) {
			throw new RuntimeException("找不到" + filePath + "对应的文件", e);
		} catch (IOException e) {
			throw new RuntimeException("写入文件" + filePath + "出错", e);
		} finally {
			if (fos != null) {
				try {
					fos.flush();
				} catch (IOException e) {
					throw new RuntimeException("刷新输出流失败", e);
				}
				try {
					fos.close();
				} catch (IOException e) {
					throw new RuntimeException("关闭输出流失败", e);
				}
				fos = null;
			}
		}
	}

	/**
	 * 
	 * 导出Excel到输出流
	 * 
	 * @param hssfworkbook
	 *            工作簿
	 * @param sheet
	 *            工作表名
	 * @param headList
	 *            标题的列表 list中存放map 如: map.put("field", 字段名); 必要 map.put("title",
	 *            显示的标题); 必要 map.put("titleStyle", HSSFCellStyle 标题单元格的样式);
	 *            map.put("dataStyle", HSSFCellStyle 内容单元格的样式);
	 *            map.put("autoColumnWidth", Boolean 是否自动调整列宽);
	 *            map.put("partten", String 内容格式);
	 * @param dataList
	 *            数据列表
	 * @param out
	 *            输出流
	 * @throws IOException
	 */
	public static <T> void writeExcel(HSSFWorkbook hssfworkbook, String sheet, List<Map<String, Object>> headList,
			List<T> dataList, OutputStream out) throws IOException {

		HSSFSheet hssfsheet = hssfworkbook.createSheet(sheet);
		HSSFRow headRow = hssfsheet.createRow(0);
		// 标题
		for (int i = 0; i < headList.size(); i++) {
			HSSFCell hssfcell = headRow.createCell(i);
			Map<String, Object> head = headList.get(i);
			if (head != null) {
				// 加样式
				Object titleStyle = head.get("titleStyle");
				if (titleStyle instanceof HSSFCellStyle) {
					hssfcell.setCellStyle((HSSFCellStyle) titleStyle);
				}

				hssfcell.setCellValue(head.get("title").toString());
			}

		}
		// 创建样式放到循环外，否则数据量大时会报错
		HSSFCellStyle hssfcellstyle = hssfworkbook.createCellStyle();
		// 内容
		for (int i = 0; i < dataList.size(); i++) {
			T t = dataList.get(i);
			HSSFRow dataRow = hssfsheet.createRow(i + 1);
			for (int j = 0; j < headList.size(); j++) {

				Map<String, Object> head = headList.get(j);

				if (head != null) {
					HSSFCell hssfcell = dataRow.createCell(j);
					Object object = head.get("field");
					String field = object.toString();
					// 加样式
					Object dataStyle = head.get("dataStyle");
					Object partten = head.get("partten");
					if (dataStyle != null && dataStyle instanceof HSSFCellStyle) {
						hssfcellstyle = (HSSFCellStyle) dataStyle;
						hssfcell.setCellStyle((HSSFCellStyle) dataStyle);
					}
					// 加格式
					if (partten != null && partten instanceof String) {
						short df = hssfworkbook.createDataFormat().getFormat((String) partten);
						hssfcellstyle.setDataFormat(df);
						hssfcell.setCellStyle(hssfcellstyle);
					}

					// 设置内容
					Object value = invokeGetterMethod(t, field);
					setCellValue(hssfworkbook, hssfcellstyle, hssfcell, partten, value);
				}
			}
		}

		// 自动列宽
		for (int i = 0; i < headList.size(); i++) {
			Map<String, Object> head = headList.get(i);
			if (head != null) {
				Object autoColumnWidth = head.get("autoColumnWidth");
				if (autoColumnWidth == null) {
					hssfsheet.autoSizeColumn((short) i);
				} else if (autoColumnWidth instanceof Boolean && (Boolean) autoColumnWidth) {
					hssfsheet.autoSizeColumn((short) i);
				}
			}

		}

		hssfworkbook.write(out);
	}

	/**
	 * 
	 * 功能描述：设置单元格内容
	 *
	 * @param hssfworkbook
	 * @param hssfcellstyle
	 * @param hssfcell
	 * @param partten
	 * @param value
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月20日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	private static void setCellValue(HSSFWorkbook hssfworkbook, HSSFCellStyle hssfcellstyle, HSSFCell hssfcell,
			Object partten, Object value) {
		if (value == null) {
			value = "";
		}
		if (value instanceof String) {
			hssfcell.setCellValue((String) value);
		} else if (value instanceof Boolean) {
			hssfcell.setCellValue((Boolean) value);
		} else if (value instanceof Calendar) {
			hssfcell.setCellValue((Calendar) value);
		} else if (value instanceof Double) {
			hssfcell.setCellType(Cell.CELL_TYPE_NUMERIC);
			hssfcell.setCellValue((Double) value);
		} else
			if (value instanceof Integer || value instanceof Long || value instanceof Short || value instanceof Float) {
			hssfcell.setCellType(Cell.CELL_TYPE_NUMERIC);
			hssfcell.setCellValue(Double.parseDouble(value.toString()));
		} else if (value instanceof HSSFRichTextString) {
			hssfcell.setCellValue((HSSFRichTextString) value);
		} else if (value instanceof Date) {
			if (partten == null) {
				// 日期默认格式
				short df = hssfworkbook.createDataFormat().getFormat(DEFAULT_DATETIME_PARTTEN);
				hssfcellstyle.setDataFormat(df);
				hssfcell.setCellStyle(hssfcellstyle);
			}
			hssfcell.setCellValue((Date) value);
		} else {
			hssfcell.setCellValue(value.toString());
		}
	}

	/*********************************************** 读方法 ********************************************************************/

	/**
	 * 
	 * 功能描述：从输入流解析出工作簿
	 *
	 * @param in
	 * @return
	 * 
	 * @author 耿沫然
	 * @throws IOException
	 * @throws InvalidFormatException
	 *
	 * @since 2015年11月21日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static Workbook createWorkbook(InputStream in) throws IOException, InvalidFormatException {
		return WorkbookFactory.create(in);
	}

	/**
	 * 
	 * 功能描述：从Excel读取数据封装成指定对象列表
	 *
	 * @param is
	 * @param sheetIndex
	 *            工作表索引位置 0开始
	 * @param contentRowIndex
	 *            正文开始行索引位置 0开始
	 * @param contentColumnIndex
	 *            正文开始列索引位置 0开始
	 * @param fieldNames
	 * @param clazz
	 * @return
	 * 
	 * @throws IOException
	 * @throws InvalidFormatException
	 * @author 耿沫然
	 *
	 * @since 2015年11月20日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static <T> List<T> read(InputStream is, int sheetIndex, int contentRowIndex, int contentColumnIndex,
			String[] fieldNames, Class<T> clazz) throws IOException, InvalidFormatException {
		Workbook workbook = createWorkbook(is);
		return read(workbook, sheetIndex, contentRowIndex, contentColumnIndex, fieldNames, clazz);
	}

	/**
	 * 
	 * 功能描述：读取EXCEL数据到二维数组
	 *
	 * @param file
	 * @param sheetIndex
	 * @param rowStart
	 * @param rowEnd
	 * @param columnStart
	 * @param columnEnd
	 * @param readType
	 * @return
	 * 
	 * @author 耿沫然
	 * @throws InvalidFormatException
	 * @throws IOException
	 *
	 * @since 2016年6月1日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String[][] read(File file, int sheetIndex, int rowStart, int rowEnd, int columnStart, int columnEnd,
			String readType) throws InvalidFormatException, IOException {
		FileInputStream in = null;
		String[][] table = null;
		try {
			in = new FileInputStream(file);
			// 得到工作簿
			Workbook workbook = createWorkbook(in);
			// 得到工作表
			Sheet sheet = workbook.getSheetAt(sheetIndex);

			// 结果数组
			if (READ_TYPE_ROW.equals(readType)) {
				table = new String[rowEnd - rowStart + 1][columnEnd - columnStart + 1];
			} else if (READ_TYPE_COLUMN.equals(readType)) {
				table = new String[columnEnd - columnStart + 1][rowEnd - rowStart + 1];
			} else {
				table = new String[rowEnd - rowStart + 1][columnEnd - columnStart + 1];
			}

			for (int i = 0; i < (rowEnd - rowStart + 1); i++) {
				Row row = sheet.getRow(rowStart + i);
				if (row != null) {
					for (int j = 0; j < (columnEnd - columnStart + 1); j++) {
						String content = getCellFormatValue(row.getCell((short) (columnStart + j)));
						if (READ_TYPE_ROW.equals(readType)) {
							table[i][j] = content;
						} else if (READ_TYPE_COLUMN.equals(readType)) {
							table[j][i] = content;
						} else {
							table[i][j] = content;
						}
					}
				}
			}

		} catch (FileNotFoundException e) {
			throw e;
		} catch (InvalidFormatException e) {
			throw e;
		} catch (IOException e) {
			throw e;
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
		return table;
	}

	/**
	 * 
	 * 功能描述：根据行号列号读数据
	 *
	 * @param file
	 * @param sheetIndex
	 *            0 1
	 * @param rowNumStart
	 *            1 2
	 * @param rowNumEnd
	 *            1 2
	 * @param columnNumStart
	 *            A AA
	 * @param columnNumEnd
	 *            A AA
	 * @return
	 * 
	 * @author 耿沫然
	 * @throws IOException
	 * @throws InvalidFormatException
	 *
	 * @since 2016年6月1日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String[][] read(File file, int sheetIndex, String rowNumStart, String rowNumEnd,
			String columnNumStart, String columnNumEnd) throws InvalidFormatException, IOException {
		return read(file, sheetIndex, rowNumStart, rowNumEnd, columnNumStart, columnNumEnd, READ_TYPE_ROW);
	}

	/**
	 * 
	 * 功能描述：根据行号列号 按行或按列 读数据
	 *
	 * @param file
	 * @param sheetIndex
	 *            0 1
	 * @param rowNumStart
	 *            1 2
	 * @param rowNumEnd
	 *            1 2
	 * @param columnNumStart
	 *            A AA
	 * @param columnNumEnd
	 *            A AA
	 * @param readType
	 *            READ_TYPE_ROW READ_TYPE_COLUMN
	 * @return
	 * 
	 * @author 耿沫然
	 * @throws IOException
	 * @throws InvalidFormatException
	 *
	 * @since 2016年6月1日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String[][] read(File file, int sheetIndex, String rowNumStart, String rowNumEnd,
			String columnNumStart, String columnNumEnd, String readType) throws InvalidFormatException, IOException {

		int rowStart = convertRowNumber(rowNumStart);
		int rowEnd = convertRowNumber(rowNumEnd);
		int columnStart = convertColumnNumber(columnNumStart);
		int columnEnd = convertColumnNumber(columnNumEnd);
		return read(file, sheetIndex, rowStart, rowEnd, columnStart, columnEnd, readType);
	}

	/**
	 * 
	 * 功能描述：转换列号
	 *
	 * @param columnNum
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年6月1日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static int convertColumnNumber(String columnNum) {
		columnNum = columnNum.toUpperCase();
		int length = columnNum.length();
		int value = 0;
		for (int i = 0; i < length; i++) {
			char ch = columnNum.charAt(i);
			int index = WORDS.indexOf(ch);
			value += (index + 1) * Math.pow(WORDS.length(), length - i - 1);
		}
		return value - 1;
	}

	/**
	 * 
	 * 功能描述：转换行号
	 *
	 * @param rowNum
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年6月1日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static int convertRowNumber(String rowNum) {
		return Integer.parseInt(rowNum) - 1;
	}

	/**
	 * 
	 * 功能描述：从Excel读取数据封装成指定对象列表
	 *
	 * @param workbook
	 * @param sheetIndex
	 *            工作表索引位置 0开始
	 * @param contentRowIndex
	 *            正文开始行索引位置 0开始
	 * @param contentColumnIndex
	 *            正文开始列索引位置 0开始
	 * @param fieldNames
	 * @param clazz
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月20日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static <T> List<T> read(Workbook workbook, int sheetIndex, int contentRowIndex, int contentColumnIndex,
			String[] fieldNames, Class<T> clazz) {

		int len = fieldNames.length;
		Field[] fields = new Field[len];
		for (int i = 0; i < len; i++) {
			Field field;
			try {
				field = clazz.getDeclaredField(fieldNames[i]);
			} catch (Exception e) {
				e.printStackTrace();
				throw new RuntimeException("读取Excel时，获得类字段" + fieldNames[i] + "时出错", e);
			}
			field.setAccessible(true);
			fields[i] = field;
		}

		List<T> list = new ArrayList<T>();
		Sheet sheet = workbook.getSheetAt(sheetIndex);
		// 得到最后行号
		int rowNum = sheet.getLastRowNum();
		// 得到总列数
		// int colNum = row.getPhysicalNumberOfCells();

		// 正文内容应该从第contentRowIndex行开始
		for (int i = contentRowIndex; i <= rowNum; i++) {
			Row row = sheet.getRow(i);
			if (row != null) {
				T t = null;
				try {
					t = clazz.newInstance();
				} catch (Exception e) {
					e.printStackTrace();
					throw new RuntimeException("读取Excel时，创建实体出错", e);
				}

				boolean isHasContent = false;

				for (int j = 0; j < len; j++) {

					Field field = fields[j];
					String content = getCellFormatValue(row.getCell((short) (contentColumnIndex + j)));
					if (content != null && (content = content.trim()) != "") {
						isHasContent = true;

						try {
							setFieldValue(t, field, content);
							logger.debug("set" + capitalize(fieldNames[j]) + "(" + content + ")");
						} catch (Exception e) {
							e.printStackTrace();
							throw new RuntimeException("读取Excel时，执行set" + capitalize(fieldNames[j]) + "(" + content
									+ ")出错:原因:" + e.getMessage(), e);
						}
					}
				}
				if (isHasContent) {
					list.add(t);
				}
			}
		}

		return list;

	}

	/**
	 * 
	 * 功能描述：为字段赋值
	 *
	 * @param t
	 * @param field
	 * @param content
	 * @throws IllegalAccessException
	 * @throws IllegalArgumentException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月20日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	private static <T> void setFieldValue(T t, Field field, String content)
			throws IllegalArgumentException, IllegalAccessException {

		Class<?> fieldType = field.getType();
		if (content != null && content.trim() != "") {
			Object value = content;
			if (fieldType == Date.class) {
				value = parseDate(content, DEFAULT_DATETIME_PARTTEN);
			}
			try {
				if (fieldType == Integer.class || fieldType == Integer.TYPE) {
					value = (int) Double.parseDouble(content);
				} else if (fieldType == Double.class || fieldType == Double.TYPE) {
					value = Double.parseDouble(content);
				} else if (fieldType == BigDecimal.class) {
					value = new BigDecimal(content);
				}
			} catch (Exception e) {
				e.printStackTrace();
				value = 0;
			}
			field.set(t, value);
		}
	}

	/**
	 * 全部以字符串的形式取单元格数据
	 * 
	 * @param cell
	 * @return
	 */
	private static String getCellFormatValue(Cell cell) {
		String cellvalue = "";
		if (cell != null) {
			cell.setCellType(Cell.CELL_TYPE_STRING);
			cellvalue = cell.toString();
		}
		return cellvalue;

	}

}