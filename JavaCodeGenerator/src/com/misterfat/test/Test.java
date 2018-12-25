package com.misterfat.test;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.misterfat.generator.tool.db.product.MysqlDatabase;
import com.misterfat.generator.tool.util.HttpRequestUtil;
import com.misterfat.generator.tool.util.StringUtil;

public class Test {

	public static void main(String[] args) {
		try {
			MysqlDatabase mysql = new MysqlDatabase("jdbc:mysql://123.56.92.138:3306/lottery?characterEncoding=utf-8",
					"root", "new.1234");
			// http://blog.csdn.net/memray/article/details/11990585
			List<String> sqls = new ArrayList<String>();
			for (int i = 0; i >= 0; i--) {
				String url = "";
				if (i == 0) {
					url = "http://www.cwl.gov.cn/kjxx/fc3d/hmhz/index.shtml";
				} else {
					url = "http://www.cwl.gov.cn/kjxx/fc3d/hmhz/index_" + i + ".shtml";
				}

				String responseText = HttpRequestUtil.sendGet(url, "");

				// System.out.println(responseText);

				List<String> findMatch = StringUtil.findMatch(responseText, "<table.*?/table>");

				if (findMatch != null && !findMatch.isEmpty()) {
					List<String> trs = StringUtil.findMatch(findMatch.get(0), "<tr.*?/tr>");
					Collections.reverse(trs);
					for (String tr : trs) {
						List<String> numbers = StringUtil.findMatch(tr, "\\d+");
						int len = 13;
						if (numbers != null && numbers.size() == len) {

							String qihao = numbers.get(1);
							String bw = numbers.get(2);
							String sw = numbers.get(3);
							String gw = numbers.get(4);

							String findSql = "select * from lottery_numbers where lottery_issue = \"" + qihao + "\"";
							List<Map<String, Object>> find = mysql.executeQuery(findSql);
							if (find == null || find.isEmpty()) {

								String sql = "INSERT INTO lottery_numbers (lottery_type,lottery_issue,lottery_number,publish_date) values(\"3D\",\""
										+ qihao + "\",\"" + bw + "," + sw + "," + gw + "\",null);";
								System.out.println(sql);
								// sqls.add(sql);
							}

						}
					}
				}
			}

			mysql.executeUpdate(sqls.toArray(new String[sqls.size()]));
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
}
