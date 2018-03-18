//using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Core;

namespace UtilityHelper
{
    public sealed class FileToZip
    {
        /// <summary>   
        /// 创建一个Zip文件
        /// </summary>
        /// <param name="filesPath">需要打包的文件目录</param>
        /// <param name="zipFilePath">Zip文件保存路径</param>
        /// <param name="password">解压密码</param>
        public static void CreateZipFile(string filesPath, string zipFilePath, string password = "")
        {

            if (!Directory.Exists(filesPath))
            {
                throw new DirectoryNotFoundException(string.Format("Cannot find directory '{0}'", filesPath));
            }

            try
            {
                CreateZipFile(Directory.GetFiles(filesPath), zipFilePath, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建一个Zip文件
        /// </summary>
        /// <param name="files">需要打包的文件完整路径名称</param>
        /// <param name="zipFilePath">Zip文件保存路径</param>
        /// <param name="password">解压密码</param>
        public static void CreateZipFile(string[] fileNames, string zipFilePath, string password = "")
        {
            try
            {
                byte[] zipData = CreateZipFile(fileNames, password);
                if (zipData != null)
                {
                    using (var fs = new FileStream(zipFilePath, FileMode.OpenOrCreate))
                    {
                        fs.Write(zipData, 0, zipData.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建一个Zip文件流
        /// </summary>
        /// <param name="fileNames">压缩的文件集合</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] CreateZipFile(string[] fileNames, string password = "")
        {
            byte[] data = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (ZipOutputStream s = new ZipOutputStream(ms))
                    {

                        s.SetLevel(9); // 压缩级别 0-9
                        if (password.Length > 0)
                            s.Password = password; //Zip压缩文件密码
                        byte[] buffer = new byte[4096]; //缓冲区大小
                        foreach (string file in fileNames)
                        {
                            ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);
                            using (FileStream fs = File.OpenRead(file))
                            {
                                int sourceBytes;
                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    s.Write(buffer, 0, sourceBytes);
                                } while (sourceBytes > 0);
                            }
                        }
                        s.Finish();
                        s.Close();
                    }
                    data = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        /// <summary>
        /// 创建一个Zip文件流
        /// </summary>
        /// <param name="fileInfo">压缩的文件集合,key 文件名，value 完整路径</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] CreateZipFile(Dictionary<string, string> fileInfo, string password = "")
        {
            byte[] data = null;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (ZipOutputStream s = new ZipOutputStream(ms))
                    {

                        s.SetLevel(9); // 压缩级别 0-9
                        if (password.Length > 0)
                            s.Password = password; //Zip压缩文件密码
                        byte[] buffer = new byte[4096]; //缓冲区大小
                        foreach (var file in fileInfo)
                        {
                            ZipEntry entry = new ZipEntry(file.Key);
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);
                            using (FileStream fs = File.OpenRead(file.Value))
                            {
                                int sourceBytes;
                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    s.Write(buffer, 0, sourceBytes);
                                } while (sourceBytes > 0);
                            }
                        }
                        s.Finish();
                        s.Close();
                    }
                    data = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }


        public static List<byte[]> UnZipFileToByte(Stream inputStream, string password = "")
        {
            List<byte[]> fileData = new List<byte[]>();
            using (ZipInputStream s = new ZipInputStream(inputStream))
            {
                if (!string.IsNullOrEmpty(password))
                    s.Password = password; //Zip压缩文件密码
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Name != String.Empty)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            s.CopyTo(ms);
                            fileData.Add(ms.ToArray());
                        }
                    }
                }
            }
            return fileData;
        }

        public static void UnZipFile(Stream inputStream, string unZipPath, string password = "")
        {
            // 解压路径如果不存在，创建
            if (!Directory.Exists(unZipPath))
                Directory.CreateDirectory(unZipPath);
            using (ZipInputStream s = new ZipInputStream(inputStream))
            {
                if (!string.IsNullOrEmpty(password))
                    s.Password = password; //Zip压缩文件密码
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Name != String.Empty)
                    {
                        using (FileStream streamWriter = new FileStream(Path.Combine(unZipPath, theEntry.Name), FileMode.OpenOrCreate))
                        {
                            byte[] data = new byte[2048];
                            int sourceBytes;
                            do
                            {
                                sourceBytes = s.Read(data, 0, data.Length);
                                streamWriter.Write(data, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 解压Zip文件
        /// </summary>
        /// <param name="zipFileName">zip文件完整路径名</param>
        /// <param name="unZipPath">解压保存路径</param>
        /// <param name="password"></param>
        public static void UnZipFile(string zipFileName, string unZipPath, string password = "")
        {
            if (!File.Exists(zipFileName))
            {
                throw new FileNotFoundException(string.Format("Cannot find file '{0}'", zipFileName));
            }
            UnZipFile(new FileStream(zipFileName, FileMode.Open), unZipPath, password);

        }
    }
}
