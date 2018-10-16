package com.misterfat.generator.tool.util;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.URL;
import java.net.URLConnection;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

public class HttpRequestUtil {
	/**
	 * 向指定URL发送GET方法的请求
	 * 
	 * @param url
	 *            发送请求的URL
	 * @param param
	 *            请求参数，请求参数应该是 name1=value1&name2=value2 的形式。
	 * @return URL 所代表远程资源的响应结果
	 */
	public static String sendGet(String url, String param) {
		String result = "";
		BufferedReader in = null;
		try {
			String urlNameString = url + "?" + param;
			URL realUrl = new URL(urlNameString);
			// 打开和URL之间的连接
			URLConnection connection = realUrl.openConnection();
			// 设置通用的请求属性
			connection.setRequestProperty("accept", "*/*");
			connection.setRequestProperty("connection", "Keep-Alive");
			connection.setRequestProperty("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)");
			// 建立实际的连接
			connection.connect();
			// 获取所有响应头字段
			Map<String, List<String>> map = connection.getHeaderFields();
			// 遍历所有的响应头字段
			for (String key : map.keySet()) {
				// System.out.println(key + "--->: " + map.get(key));
			}
			// 定义 BufferedReader输入流来读取URL的响应
			in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
			String line;
			while ((line = in.readLine()) != null) {
				result += line;
			}
		} catch (Exception e) {
			System.out.println("发送GET请求出现异常！: " + e);
			e.printStackTrace();
		}
		// 使用finally块来关闭输入流
		finally {
			try {
				if (in != null) {
					in.close();
				}
			} catch (Exception e2) {
				e2.printStackTrace();
			}
		}
		return result;
	}

	/**
	 * 向指定 URL 发送POST方法的请求
	 * 
	 * @param url
	 *            发送请求的 URL
	 * @param param
	 *            请求参数，请求参数应该是 name1=value1&name2=value2 的形式。
	 * @return 所代表远程资源的响应结果
	 */
	public static String sendPost(String url, String param) {
		PrintWriter out = null;
		BufferedReader in = null;
		String result = "";
		try {
			URL realUrl = new URL(url);
			// 打开和URL之间的连接
			URLConnection conn = realUrl.openConnection();
			// 设置通用的请求属性
			conn.setRequestProperty("accept", "*/*");
			conn.setRequestProperty("connection", "Keep-Alive");
			conn.setRequestProperty("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)");
			// 发送POST请求必须设置如下两行
			conn.setDoOutput(true);
			conn.setDoInput(true);
			// 获取URLConnection对象对应的输出流
			out = new PrintWriter(conn.getOutputStream());
			// 发送请求参数
			out.print(param);
			// flush输出流的缓冲
			out.flush();
			// 定义BufferedReader输入流来读取URL的响应
			in = new BufferedReader(new InputStreamReader(conn.getInputStream()));
			String line;
			while ((line = in.readLine()) != null) {
				result += line;
			}
		} catch (Exception e) {
			System.out.println("发送 POST 请求出现异常！: " + e);
			e.printStackTrace();
		}
		// 使用finally块来关闭输出流、输入流
		finally {
			try {
				if (out != null) {
					out.close();
				}
				if (in != null) {
					in.close();
				}
			} catch (IOException ex) {
				ex.printStackTrace();
			}
		}
		return result;
	}

	/**
	 * 
	 * 功能描述：打印请求相关信息
	 *
	 * @param req
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月28日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void printInfo(HttpServletRequest req) {
		System.out.println("AuthType: " + req.getAuthType());
		System.out.println("CharacterEncoding: " + req.getCharacterEncoding());
		System.out.println("ContentLength: " + req.getContentLength());
		System.out.println("ContentType: " + req.getContentType());
		System.out.println("ContextPath: " + req.getContextPath());
		System.out.println("LocalAddr: " + req.getLocalAddr());
		System.out.println("LocalName: " + req.getLocalName());
		System.out.println("LocalPort: " + req.getLocalPort());
		System.out.println("Method: " + req.getMethod());
		System.out.println("PathInfo: " + req.getPathInfo());
		System.out.println("PathTranslated: " + req.getPathTranslated());
		System.out.println("Protocol: " + req.getProtocol());
		System.out.println("QueryString: " + req.getQueryString());
		System.out.println("RemoteAddr: " + req.getRemoteAddr());
		System.out.println("RemoteHost: " + req.getRemoteHost());
		System.out.println("RemotePort: " + req.getRemotePort());
		System.out.println("RemoteUser: " + req.getRemoteUser());
		System.out.println("RequestedSessionId: " + req.getRequestedSessionId());
		System.out.println("RequestURI: " + req.getRequestURI());
		System.out.println("Scheme: " + req.getScheme());
		System.out.println("ServerName: " + req.getServerName());
		System.out.println("ServerPort: " + req.getServerPort());
		System.out.println("ServletPath: " + req.getServletPath());
		System.out.println("isRequestedSessionIdFromCookie: " + req.isRequestedSessionIdFromCookie());
		System.out.println("isRequestedSessionIdFromURL: " + req.isRequestedSessionIdFromURL());
		System.out.println("isRequestedSessionIdFromURL: " + req.isRequestedSessionIdFromURL());
		System.out.println("isRequestedSessionIdValid: " + req.isRequestedSessionIdValid());
		System.out.println("isSecure: " + req.isSecure());
	}
}
