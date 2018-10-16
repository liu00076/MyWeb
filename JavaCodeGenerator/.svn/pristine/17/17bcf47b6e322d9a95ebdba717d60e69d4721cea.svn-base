package com.misterfat.generator.tool.util;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.math.BigInteger;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;

public class FileUtil {

	/**
	 * 
	 * 功能描述：计算文件的MD5值
	 * 
	 * @param file
	 * @return
	 * 
	 * @author 耿沫然
	 * 
	 * @since 2015年9月23日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getFileMD5(File file) {
		if (!file.isFile()) {
			return null;
		}
		MessageDigest digest = null;
		FileInputStream in = null;
		byte buffer[] = new byte[8192];
		int len;
		try {
			digest = MessageDigest.getInstance("MD5");
			in = new FileInputStream(file);
			while ((len = in.read(buffer)) != -1) {
				digest.update(buffer, 0, len);
			}
			BigInteger bigInt = new BigInteger(1, digest.digest());
			return bigInt.toString(16);
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		} finally {
			try {
				in.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

	}

	/**
	 * 
	 * 功能描述：计算文件的 SHA-1 值
	 * 
	 * @param file
	 * @return
	 * 
	 * @author 耿沫然
	 * 
	 * @since 2015年9月23日
	 * 
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getFileSha1(File file) {
		if (!file.isFile()) {
			return null;
		}
		MessageDigest digest = null;
		FileInputStream in = null;
		byte buffer[] = new byte[8192];
		int len;
		try {
			digest = MessageDigest.getInstance("SHA-1");
			in = new FileInputStream(file);
			while ((len = in.read(buffer)) != -1) {
				digest.update(buffer, 0, len);
			}
			BigInteger bigInt = new BigInteger(1, digest.digest());
			return bigInt.toString(16);
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		} finally {
			try {
				in.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}

	/**
	 * 
	 * 功能描述：创建文件及所有父文件夹
	 *
	 * @param filepath
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月28日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void createFile(String filepath) throws IOException {

		File file = new File(filepath);
		if (!file.getParentFile().exists()) {
			createDir(file.getParent());
		}
		file.createNewFile();
	}

	/**
	 * 
	 * 功能描述：创建文件夹及所有父文件夹
	 *
	 * @param dirpath
	 * 
	 * @author 耿沫然
	 *
	 * @since 2015年11月28日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void createDir(String dirpath) {
		File file = new File(dirpath);
		if (!file.getParentFile().exists() || !file.getParentFile().isDirectory()) {
			createDir(file.getParent());
		}
		file.mkdir();

	}

	/**
	 * 
	 * 功能描述：读取某个文件夹下的所有后缀名为suffix文件
	 *
	 * @param fileList
	 * @param filepath
	 * @param suffix
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static void readFileList(List<File> fileList, String filepath, String suffix) throws IOException {

		try {

			File file = new File(filepath);
			if (!file.isDirectory()) {
				String name = file.getName();
				if (suffix == null) {
					fileList.add(file);
				} else if (name.endsWith(suffix)) {
					fileList.add(file);
				}

			} else if (file.isDirectory()) {
				String[] files = file.list();
				for (int i = 0; i < files.length; i++) {
					File readfile = new File(filepath + "\\" + files[i]);
					if (!readfile.isDirectory()) {
						String name = readfile.getName();
						if (suffix == null) {
							fileList.add(readfile);
						} else if (name.endsWith(suffix)) {
							fileList.add(readfile);
						}
					} else if (readfile.isDirectory()) {
						readFileList(fileList, filepath + "\\" + files[i], suffix);
					}
				}

			}

		} catch (IOException e) {
			throw e;
		}
	}

	/**
	 * 
	 * 功能描述：读取某个文件夹下的所有后缀名为suffix文件
	 *
	 * @param filepath
	 * @param suffix
	 * @return
	 * @throws FileNotFoundException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static List<File> readFileList(String filepath, String suffix) throws FileNotFoundException, IOException {
		ArrayList<File> fileList = new ArrayList<File>();
		readFileList(fileList, filepath, suffix);
		return fileList;
	}

	/**
	 * 
	 * 功能描述：读取某个文件夹下的所有文件
	 *
	 * @param filepath
	 * @return
	 * @throws FileNotFoundException
	 * @throws IOException
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static List<File> readFileList(String filepath) throws FileNotFoundException, IOException {
		return readFileList(filepath, null);
	}

	/**
	 * 
	 * 功能描述：获得文件相对路径
	 *
	 * @param file
	 * @param basePath
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getRelativePath(File file, String basePath) {
		String absolutePath = file.getAbsolutePath();
		File baseDir = new File(basePath);
		String relativePath = formatPath(absolutePath).replace(formatPath(baseDir.getAbsolutePath()), File.separator);
		return formatPath(relativePath);
	}

	/**
	 * 
	 * 功能描述：转为标准路径
	 *
	 * @param path
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月30日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String formatPath(String path) {
		if (path.indexOf(":") == 1) {
			path = path.substring(0, 1).toUpperCase() + path.substring(1);
		}
		return path.replace("\\\\", File.separator).replace("//", File.separator).replace("\\", File.separator)
				.replace("/", File.separator);
	}

	/**
	 * 
	 * 功能描述：获得文件后缀名
	 *
	 * @param file
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getSuffix(File file) {
		String name = file.getName();
		String suffix = name.substring(name.lastIndexOf("."));
		return suffix;
	}

	/**
	 * 
	 * 功能描述：获得没有后缀名的文件名
	 *
	 * @param file
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getFilename(File file) {
		String name = file.getName();
		String filename = name.substring(0, name.lastIndexOf("."));
		return filename;
	}

	/**
	 * 
	 * 功能描述：根据文件获得目录名
	 *
	 * @param filepath
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static String getFilePathFolder(String filepath) {
		return filepath.substring(0, filepath.lastIndexOf(File.separator));
	}

	/**
	 * 
	 * 功能描述：删除文件夹及下边所有文件
	 *
	 * @param dir
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static boolean deleteDir(File dir) {
		return clearDir(dir) && dir.delete();
	}

	/**
	 * 
	 * 功能描述：删除文件夹及下边所有文件
	 *
	 * @param dir
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static boolean deleteDir(String dir) {
		return deleteDir(new File(dir));
	}

	/**
	 * 
	 * 功能描述：清空文件夹
	 *
	 * @param dir
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static boolean clearDir(File dir) {
		if (dir.isDirectory()) {
			String[] children = dir.list();
			for (int i = 0; i < children.length; i++) {
				boolean success = deleteDir(new File(dir, children[i]));
				if (!success) {
					return false;
				}
			}
		}
		return true;
	}

	/**
	 * 
	 * 功能描述：清空文件夹
	 *
	 * @param dir
	 * @return
	 * 
	 * @author 耿沫然
	 *
	 * @since 2016年5月25日
	 *
	 * @update:[变更日期YYYY-MM-DD][更改人姓名][变更描述]
	 */
	public static boolean clearDir(String dir) {
		return clearDir(new File(dir));
	}

	public static void main(String[] args) {

		try {
			List<File> readFileList = readFileList(
					"D:/workspace_template4/code-generator/template/freemarker/misterfat", ".ftl");
			for (File file : readFileList) {
				System.out.println(file.getName());
				System.out.println(file.getPath());
			}
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
