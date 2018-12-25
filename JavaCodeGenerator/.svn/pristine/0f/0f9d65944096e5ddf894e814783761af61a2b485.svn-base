package com.misterfat.test;

import com.misterfat.generator.tool.util.HttpRequestUtil;
import com.misterfat.generator.tool.util.PathUtil;

public class RhinoScaperTest {

	public static void main(String[] args) {
		RhinoScaper rs = new RhinoScaper();

		rs.init();
		rs.putObject("out", System.out);
		String html = HttpRequestUtil.sendGet("https://www.baidu.com/s", "wd=aa");
		rs.putObject("html", html);
		rs.setJsFile(PathUtil.getClassBasePath() + "com/misterfat/test/test2.js");

		rs.run();
	}

}