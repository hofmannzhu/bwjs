using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO;
using Aspose.Words;
using iTextSharp.text.pdf;

namespace UtilityHelper
{
    public class MergePDFHelper
    {
        public MergePDFHelper()
        {

        }
        /// <summary>
        /// 把多个PDF文件、word文件、JPG/PNG/jpge图合并成一个PDF文档
        /// </summary>
        /// <param name="fileList">需要合并文件的完整路径列表</param>
        /// <param name="outMergeFile">输出文件完整路径</param>
        /// <param name="msg">警告或错误消息</param>
        public void MergePDFFile(List<string> fileList, string outMergeFile, ref string msg)
        {
            PdfReader reader;
            PdfImportedPage newPage;
            PdfWriter pw;
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            iTextSharp.text.Rectangle re;

            foreach (var itemFile in fileList)
            {
                string fileName = Path.GetFileName(itemFile);
                var ext = Path.GetExtension(itemFile).ToLower();
                if (!File.Exists(itemFile))
                {

                    msg += string.Format("文件打印合并__{0} 文件不存在", fileName);
                    continue;
                }
                FileInfo fInfo = new FileInfo(itemFile);
                if (fInfo.Length < 1)
                {

                    msg += string.Format("文件打印合并__文件内容为空，无法打印，{0}", fileName);
                    return;
                }

                if (".pdf".Equals(ext))
                {
                    reader = new PdfReader(itemFile);
                    int iPageNum = reader.NumberOfPages;
                    for (int j = 1; j <= iPageNum; j++)
                    {
                        //获取Reader的pdf页的打印方向
                        re = reader.GetPageSize(reader.GetPageN(j));
                        //设置合并pdf的打印方向
                        document.SetPageSize(re);
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 0, 0);
                    }
                }
                else if (".doc".Equals(ext) || ".docx".Equals(ext))
                {
                    Aspose.Words.Document doc = new Aspose.Words.Document(itemFile);
                    string newPdf = Path.GetDirectoryName(itemFile) + "\\" + Path.GetFileNameWithoutExtension(itemFile) + ".pdf";
                    doc.Save(newPdf, SaveFormat.Pdf);
                    reader = new PdfReader(newPdf);
                    int iPageNum = reader.NumberOfPages;
                    for (int j = 1; j <= iPageNum; j++)
                    {
                        //获取Reader的pdf页的打印方向
                        re = reader.GetPageSize(reader.GetPageN(j));
                        //设置合并pdf的打印方向
                        document.SetPageSize(re);
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 0, 0);
                    }
                }
                else if (".jpg".Equals(ext) || ".jpeg".Equals(ext) || ".png".Equals(ext) || ".bmp".Equals(ext))
                {
                    FileStream rf = new FileStream(itemFile, FileMode.Open, FileAccess.Read);
                    int size = (int)rf.Length;
                    byte[] imext = new byte[size];
                    rf.Read(imext, 0, size);
                    rf.Close();

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imext);

                    //调整图片大小，使之适合A4
                    var imgHeight = img.Height;
                    var imgWidth = img.Width;
                    if (img.Height > iTextSharp.text.PageSize.A4.Height - 30)
                    {

                        imgHeight = iTextSharp.text.PageSize.A4.Height - 30;
                    }

                    if (img.Width > iTextSharp.text.PageSize.A4.Width - 30)
                    {
                        imgWidth = iTextSharp.text.PageSize.A4.Width - 30;
                    }
                    img.ScaleToFit(imgWidth, imgHeight);

                    //调整图片位置，使之居中
                    img.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;

                    document.NewPage();
                    document.Add(img);

                }
            }
            document.Close();
        }
    }
}