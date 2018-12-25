package com.misterfat.generator.tool.util;

/*   
 调用org.apache.tools.zip实现压缩。   
 夜可以使用java.util.zip不过如果是中文的话，   
 解压缩的时候文件名字会是乱码。原因是解压缩软件的编码格式跟   
 java.util.zip.ZipInputStream的编码字符集不同   
 java.util.zip.ZipInputStream的字符集固定是UTF-8   
 */
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;

import org.apache.tools.zip.ZipEntry;
import org.apache.tools.zip.ZipFile;
import org.apache.tools.zip.ZipOutputStream;

public class ZipCompressUtil {

	/** 参数一：需要压缩的文件或文件夹路径,参数二：压缩后的文件名 */
	public void zip(String inputFile, String zipFileName) {
		zip(new File(inputFile), zipFileName, null);
	}

	/** 参数一：需要压缩的File对象,参数二：压缩后的文件名 */
	public void zip(File inputFile, String zipFileName, String ingore) {
		try {
			ZipOutputStream zOut = new ZipOutputStream(
					new FileOutputStream(new String(zipFileName.getBytes("gb2312"))));
			System.out.println("压缩-->开始");
			zip(zOut, inputFile, "", ingore);
			System.out.println("压缩-->结束");
			zOut.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/** 参数一：压缩输出流对象(此流用于写入数据并生成文件),参数二：需要压缩的File对象,参数三：根目录,即压缩包中的文件夹目录 */
	public void zip(ZipOutputStream zOut, File file, String base, String ingore) {
		try {
			System.out.println("正在压缩-->" + file.getName());
			if (file.isDirectory()) {
				if (file.getName().equals(ingore)) {
					return;
				}
				File[] listFiles = file.listFiles();

				// 此处解决压缩未端数据不正确,这是判断当前是什么系统,普遍是Windows所以在这里就不注释不做此判断.
				if (System.getProperty("os.name").startsWith("Windows")) {
					base = base.length() == 0 ? "" : base + "\\";
					zOut.putNextEntry(new ZipEntry(base));
				} else {
					base = base.length() == 0 ? "" : base + "/";
					zOut.putNextEntry(new ZipEntry(base));
				}
				// 一般来说用"/"符号来分割出文件与文件夹是没有问题的

				zOut.putNextEntry(new ZipEntry(base + "/"));
				base = base.length() == 0 ? "" : base + "/";
				for (int i = 0; i < listFiles.length; i++) {
					zip(zOut, listFiles[i], base + listFiles[i].getName(), ingore);
					// System.out.println(new
					// String(fl[i].getName().getBytes("gb2312")));
				}
			} else {
				if (base == "") {
					base = file.getName();
				}
				zOut.putNextEntry(new ZipEntry(base));
				System.out.println(file.getPath() + "," + base);
				FileInputStream in = new FileInputStream(file);
				int len;
				while ((len = in.read()) != -1)
					zOut.write(len);
				in.close();
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	private void createDirectory(String directory, String subDirectory) {
		String dir[];
		File fl = new File(directory);
		try {
			if (subDirectory == "" && fl.exists() != true)
				fl.mkdir();
			else if (subDirectory != "") {
				dir = subDirectory.replace('\\', '/').split("/");
				for (int i = 0; i < dir.length; i++) {
					File subFile = new File(directory + File.separator + dir[i]);
					if (subFile.exists() == false)
						subFile.mkdir();
					directory += File.separator + dir[i];
				}
			}
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
		}
	}

	@SuppressWarnings("rawtypes")
	public void unZip(String zipFileName, String outputDirectory) {
		try {
			ZipFile zipFile = new ZipFile(zipFileName, "GBK");
			java.util.Enumeration e = zipFile.getEntries();
			ZipEntry zipEntry = null;
			createDirectory(outputDirectory, "");
			while (e.hasMoreElements()) {
				zipEntry = (ZipEntry) e.nextElement();
				System.out.println("正在解压: " + zipEntry.getName());
				String name = null;
				if (zipEntry.isDirectory()) {
					name = zipEntry.getName();
					name = name.substring(0, name.length() - 1);
					File f = new File(outputDirectory + File.separator + name);
					f.mkdir();
					System.out.println("创建目录：" + outputDirectory + File.separator + name);
				} else {
					String fileName = zipEntry.getName();
					fileName = fileName.replace('\\', '/');
					// System.out.println("测试文件1：" +fileName);
					if (fileName.indexOf("/") != -1) {
						createDirectory(outputDirectory, fileName.substring(0, fileName.lastIndexOf("/")));
						fileName = fileName.substring(fileName.lastIndexOf("/") + 1, fileName.length());
					}

					File f = new File(outputDirectory + File.separator + zipEntry.getName());

					f.createNewFile();
					InputStream in = zipFile.getInputStream(zipEntry);
					FileOutputStream out = new FileOutputStream(f);

					byte[] by = new byte[1024];
					int c;
					while ((c = in.read(by)) != -1) {
						out.write(by, 0, c);
					}
					out.close();
					in.close();

				}

			}
			zipFile.close();
			// 删除文件不能在这里删，因为文件正在使用，应在上传那处删
			// 解压后，删除压缩文件
			// File zipFileToDel = new File(zipFileName);
			// zipFileToDel.delete();
			// System.out.println("正在删除文件："+ zipFileToDel.getCanonicalPath());

			// //删除解压后的那一层目录
			// delALayerDir(zipFileName, outputDirectory);

		} catch (Exception ex) {
			System.out.println(ex.getMessage());
		}

	}

	/**
	 * 删掉一层目录
	 * 
	 * @param zipFileName
	 * @param outputDirectory
	 */
	public void delALayerDir(String zipFileName, String outputDirectory) {

		String[] dir = zipFileName.replace('\\', '/').split("/");
		String fileFullName = dir[dir.length - 1]; // 得到aa.zip
		int pos = -1;
		pos = fileFullName.indexOf(".");
		String fileName = fileFullName.substring(0, pos); // 得到aa
		String sourceDir = outputDirectory + File.separator + fileName;
		try {
			copyFile(new File(outputDirectory), new File(sourceDir), new File(sourceDir));

			deleteSourceBaseDir(new File(sourceDir));

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * 将sourceDir目录的文件全部copy到destDir中去
	 */
	public void copyFile(File destDir, File sourceBaseDir, File sourceDir) throws Exception {

		File[] lists = sourceDir.listFiles();
		if (lists == null)
			return;
		for (int i = 0; i < lists.length; i++) {
			File f = lists[i];
			if (f.isFile()) {
				FileInputStream fis = new FileInputStream(f);
				String content = "";
				String sourceBasePath = sourceBaseDir.getCanonicalPath();
				String fPath = f.getCanonicalPath();
				String drPath = destDir + fPath.substring(fPath.indexOf(sourceBasePath) + sourceBasePath.length());
				FileOutputStream fos = new FileOutputStream(drPath);

				byte[] b = new byte[2048];
				while (fis.read(b) != -1) {
					if (content != null)
						content += new String(b);
					else
						content = new String(b);
					b = new byte[2048];
				}

				content = content.trim();
				fis.close();

				fos.write(content.getBytes());
				fos.flush();
				fos.close();

			} else {
				// 先新建目录
				new File(destDir + File.separator + f.getName()).mkdir();

				copyFile(destDir, sourceBaseDir, f); // 递归调用
			}
		}
	}

	/**
	 * 将sourceDir目录的文件全部copy到destDir中去
	 */
	public void deleteSourceBaseDir(File curFile) throws Exception {
		File[] lists = curFile.listFiles();
		File parentFile = null;
		for (int i = 0; i < lists.length; i++) {
			File f = lists[i];
			if (f.isFile()) {
				f.delete();
				// 若它的父目录没有文件了，说明已经删完，应该删除父目录
				parentFile = f.getParentFile();
				if (parentFile.list().length == 0)
					parentFile.delete();
			} else {
				deleteSourceBaseDir(f); // 递归调用
			}
		}
	}

	public static void main(String[] args) {
		ZipCompressUtil t = new ZipCompressUtil();
		// 这里是调用压缩的代码
		// t.zip("d:\\me.7z", "d:\\test.jar");
		// 这里是调用解压缩的代码
		t.unZip("d:\\me.zip", "d:\\my");
	}

}