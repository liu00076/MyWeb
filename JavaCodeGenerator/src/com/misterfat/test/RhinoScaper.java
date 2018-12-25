package com.misterfat.test;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

import org.mozilla.javascript.Context;
import org.mozilla.javascript.ContextFactory;
import org.mozilla.javascript.Scriptable;

import com.misterfat.generator.tool.util.PathUtil;

/**
 * @author MyBeautiful
 * @Emal: zhangyu0182@sina.com
 * @date Mar 7, 2012
 */
public class RhinoScaper {
	private String url;
	private String jsFile;

	private Context cx;
	private Scriptable scope;

	public String getUrl() {
		return url;
	}

	public String getJsFile() {
		return jsFile;
	}

	public void setUrl(String url) {
		this.url = url;
		putObject("url", url);
	}

	public void setJsFile(String jsFile) {
		this.jsFile = jsFile;
	}

	public void init() {
		cx = ContextFactory.getGlobal().enterContext();
		scope = cx.initStandardObjects(null);
		cx.setOptimizationLevel(-1);
		cx.setLanguageVersion(Context.VERSION_1_5);

		String[] file = { PathUtil.getClassBasePath() + "com/misterfat/test/env.rhino.js",
				PathUtil.getClassBasePath() + "com/misterfat/test/jquery.js" };
		for (String f : file) {
			evaluateJs(f);
		}

	}

	protected void evaluateJs(String f) {
		try {
			FileReader in = null;
			in = new FileReader(f);
			cx.evaluateReader(scope, in, f, 1, null);
		} catch (FileNotFoundException e1) {
			e1.printStackTrace();
		} catch (IOException e1) {
			e1.printStackTrace();
		}
	}

	public void putObject(String name, Object o) {
		scope.put(name, scope, o);
	}

	public void run() {
		evaluateJs(this.jsFile);
	}
}