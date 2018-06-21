using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace Helper
{
    public class ZipFileHelper
    {
        public static string BackUpPath;

        /// <summary>
        /// 压缩文件及文件夹
        /// </summary>
        /// <param name="FileToZip">需要放置压缩文件的文件夹的绝对路径："C:\\Users\\liuu\\Desktop\\"</param>
        /// <param name="ZipedFile">压缩文件的存放路径："C:\\Users\\liuu\\Desktop\\yasuo.zip"</param>
        /// <param name="Password">解压缩密码</param>
        /// <param name="separate">指示当压缩一个文件夹时，是否基于文件夹压缩文件</param>
        /// <param name="files">要压缩的文件路径</param>
        /// <param name="dirs">要压缩的文件夹路径</param>
        /// <returns></returns>
        public static bool Zip(String FileToZip, String ZipedFile, String Password, bool separate, string[] files, string[] dirs)
        {
            BackUpPath = Path.GetDirectoryName(ZipedFile);

            if (Directory.Exists(FileToZip))
            {
                return ZipFileDictory(FileToZip, ZipedFile, Password, separate, files, dirs);
            }
            else if (File.Exists(FileToZip))
            {
                return ZipFile(FileToZip, ZipedFile, Password);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 解压压缩文件
        /// </summary>
        /// <param name="FileToUpZip">压缩文件绝对路径："C:\\Users\\liuu\\Desktop\\yasuo.zip"</param>
        /// <param name="ZipedFolder">将压缩文件解压到路径："C:\\Users\\liuu\\Desktop\\"</param>
        /// <param name="Password"></param>
        public static void UnZip(string FileToUpZip, string ZipedFolder, string Password)
        {
            if (!File.Exists(FileToUpZip))
            {
                return;
            }

            if (!Directory.Exists(ZipedFolder))
            {
                Directory.CreateDirectory(ZipedFolder);
            }

            ZipInputStream s = null;
            ZipEntry theEntry = null;

            string fileName;
            FileStream streamWriter = null;

            try
            {
                s = new ZipInputStream(File.OpenRead(FileToUpZip));

                s.Password = Password;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Name != String.Empty)
                    {
                        fileName = Path.Combine(ZipedFolder, theEntry.Name);

                        if (fileName.EndsWith("/") || fileName.EndsWith("\\"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }

                        streamWriter = File.Create(fileName);
                        int size = 2048;
                        byte[] data = new byte[2048];

                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }

                if (theEntry != null)
                {
                    theEntry = null;
                }

                if (s != null)
                {
                    s.Close();
                    s = null;
                }

                GC.Collect();
                GC.Collect(1);
            }
        }

        #region 私有方法

        /// <summary>
        /// 调用第三方类库实现文件和文件夹的压缩功能
        /// </summary>
        private static bool ZipFileDictory(string FolderToZip, string ZipedFile, String Password, bool separate, string[] files, string[] dirs)
        {
            bool res;

            if (!Directory.Exists(FolderToZip))
            {
                return false;
            }

            ZipOutputStream s = new ZipOutputStream(File.Create(ZipedFile));
            s.SetLevel(6);
            s.Password = Password;

            res = ZipFileDictory(FolderToZip, s, "", separate, files, dirs);

            s.Finish();
            s.Close();

            return res;
        }

        private static bool ZipFileDictory(string FolderToZip, ZipOutputStream s, string ParentFolderName, bool separate, string[] files, string[] dirs)
        {
            bool res = true;
            string[] folders, filenames;
            ZipEntry entry = null;
            FileStream fs = null;
            Crc32 crc = new Crc32();

            try
            {
                //创建当前文件夹
                entry = new ZipEntry(Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip) + "/")); //加上 “/” 才会当成是文件夹创建
                s.PutNextEntry(entry);
                s.Flush();

                //先压缩文件，再递归压缩文件夹 
                if (separate)
                {
                    filenames = files;
                }
                else
                {
                    filenames = Directory.GetFiles(FolderToZip);
                }

                foreach (string file in filenames)
                {
                    //打开压缩文件
                    fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string p = Path.GetFileName(FolderToZip);

                    if (p.Length < 1)
                    {
                        p = Path.GetFileName(file);
                    }
                    else
                    {
                        p += "/" + Path.GetFileName(file);
                    }

                    entry = new ZipEntry(Path.Combine(ParentFolderName, p));

                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();

                    crc.Reset();
                    crc.Update(buffer);

                    entry.Crc = crc.Value;

                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                res = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }

                if (entry != null)
                {
                    entry = null;
                }

                GC.Collect();
                GC.Collect(1);
            }

            if (separate)
            {
                folders = dirs;
            }
            else
            {
                folders = Directory.GetDirectories(FolderToZip);
            }

            foreach (string folder in folders)
            {
                if (folder.Equals(BackUpPath, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                else if (!ZipFileDictory(folder, s, Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip)), false, null, null))
                {
                    return false;
                }
            }

            return res;
        }


        /// <summary>
        /// 单个压缩文件方法
        /// </summary>
        /// <param name="FileToZip">压缩后的文件保存文件夹路径："C:\\Users\\liuu\\Desktop\\"</param>
        /// <param name="ZipedFile">压缩后文件存放路径："C:\\Users\\liuu\\Desktop\\yasuo.zip"</param>
        /// <param name="Password">压缩密码</param>
        /// <returns></returns>
        private static bool ZipFile(string FileToZip, string ZipedFile, String Password)
        {
            //如果文件没有找到，则报错
            if (!File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + FileToZip + " 不存在!");
            }

            FileStream ZipFile = null;
            ZipOutputStream ZipStream = null;
            ZipEntry ZipEntry = null;

            bool res = true;

            try
            {
                ZipFile = File.OpenRead(FileToZip);
                byte[] buffer = new byte[ZipFile.Length];
                ZipFile.Read(buffer, 0, buffer.Length);
                ZipFile.Close();

                ZipFile = File.Create(ZipedFile);
                ZipStream = new ZipOutputStream(ZipFile);
                ZipStream.Password = Password;
                ZipEntry = new ZipEntry(Path.GetFileName(FileToZip));
                ZipStream.PutNextEntry(ZipEntry);
                ZipStream.SetLevel(6);

                ZipStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                res = false;
            }
            finally
            {
                if (ZipEntry != null)
                {
                    ZipEntry = null;
                }

                if (ZipStream != null)
                {
                    ZipStream.Finish();
                    ZipStream.Close();
                }

                if (ZipFile != null)
                {
                    ZipFile.Close();
                    ZipFile = null;
                }

                GC.Collect();
                GC.Collect(1);
            }

            return res;
        }

        #endregion


    }
}
