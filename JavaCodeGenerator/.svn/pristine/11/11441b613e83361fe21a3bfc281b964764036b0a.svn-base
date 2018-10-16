package com.misterfat.lottery;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.misterfat.generator.tool.db.product.MysqlDatabase;

public class Statistics {

	private static MysqlDatabase mysqlDatabase = new MysqlDatabase(
			"jdbc:mysql://123.56.92.138:3306/lottery?characterEncoding=utf-8", "root", "new.1234");

	public static List<Map<String, Object>> zhiXuanNoAppear(String lotteryType) {
		String sql = "select lottery_number,lottery_type from all_numbers an where not exists(select * from lottery_numbers where lottery_number = an.lottery_number and lottery_type = \""
				+ lotteryType + "\" );";
		try {
			List<Map<String, Object>> result = mysqlDatabase.executeQuery(sql);

			return result;
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public static List<Map<String, Object>> zhiXuanAppear(String number) {
		String sql = "select * from lottery_numbers where lottery_number = \"" + number + "\"";
		try {
			List<Map<String, Object>> result = mysqlDatabase.executeQuery(sql);

			return result;
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public static List<Map<String, Object>> zuXuanAppear(String number) {

		List<Map<String, Object>> resultList = new ArrayList<Map<String, Object>>();
		String[] split = number.split(",");
		String number1 = split[0] + "," + split[1] + "," + split[2];
		String number2 = split[0] + "," + split[2] + "," + split[1];
		String number3 = split[1] + "," + split[0] + "," + split[2];
		String number4 = split[1] + "," + split[2] + "," + split[0];
		String number5 = split[2] + "," + split[0] + "," + split[1];
		String number6 = split[2] + "," + split[1] + "," + split[0];

		Set<String> set = new HashSet<String>();
		set.add(number1);
		set.add(number2);
		set.add(number3);
		set.add(number4);
		set.add(number5);
		set.add(number6);

		Iterator<String> iterator = set.iterator();
		while (iterator.hasNext()) {
			String num = iterator.next();
			String sql = "select * from lottery_numbers where lottery_number = \"" + num + "\"";
			try {
				List<Map<String, Object>> result = mysqlDatabase.executeQuery(sql);
				if (result != null) {
					resultList.addAll(result);
				}
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		return resultList;
	}

	public static void printResult(List<Map<String, Object>> result, String... columns) {
		System.out.println();
		if (result != null && !result.isEmpty()) {
			boolean isPrintHeader = false;
			for (Map<String, Object> row : result) {
				if (!isPrintHeader) {
					for (String col : columns) {
						System.out.print(col);
						System.out.print("    ");
					}
					isPrintHeader = true;
					System.out.println();
				}

				for (String col : columns) {
					System.out.print(getFormatString(row.get(col).toString(), col));
					System.out.print("    ");
				}
				System.out.println();
			}
		}
	}

	public static String getFormatString(String text, String col) {
		int col_len = col.length();
		int text_len = text.length();

		int len = col_len - text_len;
		for (int i = 0; i < len / 2; i++) {
			text = " " + text + " ";
		}

		return text;
	}

	public static void main(String[] args) {
		printResult(zuXuanAppear("5,6,7"), new String[] { "lottery_number", "lottery_issue" });
	}
}
