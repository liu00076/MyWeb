package com.misterfat.test;

import java.io.IOException;
import java.util.HashSet;
import java.util.Set;

import org.apache.poi.openxml4j.exceptions.InvalidFormatException;

public class ImportNumbers {
	public static void main(String[] args) throws InvalidFormatException, IOException {

		// MysqlDatabase mysql = new
		// MysqlDatabase("jdbc:mysql://123.56.92.138:3306/lottery?characterEncoding=utf-8",
		// "root", "new.1234");
		//
		// List<String> sqls = new ArrayList<String>();
		// for (int i = 0; i < 10; i++) {
		// for (int j = 0; j < 10; j++) {
		// for (int k = 0; k < 10; k++) {
		// String sql = "insert into all_numbers(lottery_type,lottery_number)
		// values(\"3D\",\"" + i + "," + j
		// + "," + k + "\");";
		// System.out.println(sql);
		// sqls.add(sql);
		// }
		// }
		// }
		// try {
		// mysql.executeUpdate(sqls.toArray(new String[sqls.size()]));
		// } catch (SQLException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		// }

		String[] array = new String[] { "A", "B", "C" };

		Set<String> set = new HashSet<String>();

		for (int i = 0; i < array.length; i++) {
			for (int j = 0; j < array.length; j++) {
				for (int k = 0; k < array.length; k++) {
					String text = array[i] + array[j] + array[k];
					set.add(text);
				}
			}
		}
		System.out.println(set);

		for (int i = 0; i < 8; i++) {
			System.out.println(Integer.toBinaryString(i));
		}
	}

	// 偶偶偶、偶偶奇、偶奇偶、偶奇奇、奇偶偶、奇偶奇、奇奇偶、奇奇奇
	// 小小小、小小大、小大小、小大大、大小小、大小大、大大小、大大大
	// AAA AAB ABA BAA ABC

}
