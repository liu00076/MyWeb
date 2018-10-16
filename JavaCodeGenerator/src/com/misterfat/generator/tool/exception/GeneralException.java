package com.misterfat.generator.tool.exception;

/**
 * 
 * 自定义异常类
 *
 * @author 耿沫然
 *
 * @version
 *
 * @since 2015年11月19日
 */
public class GeneralException extends Exception {

	/**
	 * serialVersionUID
	 */
	private static final long serialVersionUID = -8338305421389829481L;

	/**
	 * 缺省构造函数
	 */
	public GeneralException() {
		super();
	}

	/**
	 * 带异常消息的构造函数
	 */
	public GeneralException(String message) {
		super(message);
	}
}