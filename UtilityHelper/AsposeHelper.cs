using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;
using System.Text.RegularExpressions;
using Kaliko.ImageLibrary;
using System.IO;
using System.Data;
using Aspose.Words.Tables;
using Aspose.BarCode;
using System.Drawing;
using System.Drawing.Imaging;


namespace UtilityHelper
{
    /// <summary>
    /// 生成word、pdf
    /// </summary>
    public class AsposeHelper
    {
        private int createType = 0;
        /// <summary>
        /// 创建类型1：预览2：下载
        /// </summary>
        public int CreateType
        {
            get
            {
                return createType;
            }

            set
            {
                createType = value;
            }
        }
        
        /// <summary>
        /// 协议网站临时目录
        /// </summary>
        public string TempPath { get; set; }

        private string SealPath = "";//章的全路径 替换的时候赋值，不需要改动之前调用代码,不盖章的情况下为空。

        public void OpenDocuemt(string fileTemplate)
        {
            OpenWithTemplate(fileTemplate);
        }
        public void Save(List<WordReplaceConfig> relpaceConfig, string savePath)
        {
            Replace(relpaceConfig);
            ReplaceAll();
            SaveAs(savePath);
        }
        public void SaveDocument(List<WordReplaceConfig> relpaceConfig, string fileTemplate, string savePath)
        {
            OpenWithTemplate(fileTemplate);
            Replace(relpaceConfig);
            ReplaceAll();
            SaveAs(savePath);
        }


        private DocumentBuilder oWordApplic; //   a   reference   to   Word   application   
        private Aspose.Words.Document oDoc; //   a   reference   to   the   document   


        public void OpenWithTemplate(string strFileName)
        {
            if (!string.IsNullOrEmpty(strFileName))
            {
                oDoc = new Aspose.Words.Document(strFileName);
            }
        }

        public void Open()
        {
            oDoc = new Aspose.Words.Document();
        }

        public void Builder()
        {
            oWordApplic = new DocumentBuilder(oDoc);

        }

        /// <summary>
        /// 带签章的pdf保存
        /// </summary>
        /// <param name="fileTemp">doc模板</param>
        /// <param name="signatureImag">签章图片</param>
        /// <param name="outFilePath">输出路径</param>
        public void SavAsPdf(string fileTemp, string signatureImag, string outFilePath)
        {
            oDoc = new Document(fileTemp);
            Bookmark bKGetDate = oDoc.Range.Bookmarks["GetDate"];
            if (bKGetDate != null)
            {
                oDoc.Range.Bookmarks["GetDate"].Text = DateTime.Now.ToString("yyyy年MM月dd日");
            }
            Bookmark bKsignatureImage = oDoc.Range.Bookmarks["signatureImage"];
            if (bKsignatureImage != null)
            {
                Aspose.Words.DocumentBuilder dbuilder = new Aspose.Words.DocumentBuilder(oDoc);
                dbuilder.MoveToBookmark("signatureImage");
                dbuilder.InsertImage(signatureImag, Aspose.Words.Drawing.RelativeHorizontalPosition.Character, -130,
                Aspose.Words.Drawing.RelativeVerticalPosition.BottomMargin, 0, 120, 120, Aspose.Words.Drawing.WrapType.None);
            }
            int pageCount = oDoc.PageCount;
            if (pageCount > 1 && bKsignatureImage != null)
            {
                SealPath = signatureImag;
                AddPageSeal(outFilePath, pageCount);
            }
            else//直接生成pdf
            {
                oDoc.Save(outFilePath, SaveFormat.Pdf);
            }
        }

        /// <summary>  
        /// 保存文件  
        /// </summary>  
        /// <param name="strFileName"></param>  
        public void SaveAs(string strFileName)
        {
            //路径存在的情况下需要添加骑缝章
            if (SealPath.Length > 0)
            {
                int pageCount = GetDocumentPageCount(); //获取当前页数
                if (pageCount > 1)
                {
                    AddPageSeal(strFileName, pageCount);
                }
                else
                {
                    if (createType == 1)
                    {
                        string strFileNamet = strFileName.Substring(0,strFileName.LastIndexOf("."))+"doc";

                        oDoc.Save(strFileNamet, SaveFormat.Doc);
                    }
                    else
                    {
                        oDoc.Save(strFileName, SaveFormat.Pdf);
                    }
                    
                }
            }
            else
            {
                if (createType == 1)
                {
                    string strFileNamet = strFileName.Substring(0, strFileName.LastIndexOf(".")) ;
                    oDoc.Save(strFileNamet+".doc", SaveFormat.Doc);
                    //存储world
                    oDoc.Save(strFileNamet+".pdf", SaveFormat.Pdf);
                }
                else
                {
                    oDoc.Save(strFileName, SaveFormat.Pdf);
                }
            }
        }

        /// <summary>
        /// 添加骑缝章
        /// 新添加方式，需要word生成多张图片-图片盖章后再转PDF
        /// </summary>
        private void AddPageSeal(string strFileName, int pageCount)
        {
            List<string> sealImageList = new List<string>(); //章的图片列表
            List<string> fileImageList = new List<string>(); //word生成的图片列表，盖好章的

            string directoryName = System.IO.Path.GetDirectoryName(strFileName);//获取文件路径
            if (!string.IsNullOrEmpty(TempPath))
            {
                //directoryName = TempPath;
            }
            if (pageCount > 1)
            {
                sealImageList = kalikoImage(pageCount);

                Aspose.Words.Saving.ImageSaveOptions iso = new Aspose.Words.Saving.ImageSaveOptions(SaveFormat.Jpeg);
                iso.Resolution = 256;
                iso.PrettyFormat = true;
                iso.UseAntiAliasing = true;

                for (int i = 0; i < pageCount; i++)
                {
                    iso.PageIndex = i;
                    string imgPath = directoryName + "\\IMG\\" + i + ".jpg"; //图片路径
                    oDoc.Save(imgPath, iso);  //保存多张图片


                    Bitmap bm1 = new Bitmap(imgPath);
                    Bitmap bm2 = new Bitmap(sealImageList[i]);
                    Graphics g = Graphics.FromImage(bm1);

                    //盖章操作,需要根据页数计算X轴位置 256 像素下生成图片像素为 2117*2993 
                    //完整章图片像素为425*425，需要根据页数计算X轴位置，Y轴固定中间位置
                    int x = 2117 - (425 / pageCount);
                    g.DrawImage(bm2, x, 1284, 425 / pageCount, 425);
                    string finishImgPath = Path.GetDirectoryName(imgPath) + "\\Finish\\" + Path.GetFileName(imgPath);


                    if (!System.IO.Directory.Exists(finishImgPath.Substring(0, finishImgPath.LastIndexOf("\\"))))
                    {
                        System.IO.Directory.CreateDirectory(finishImgPath.Substring(0, finishImgPath.LastIndexOf("\\")));//不存在就创建目录 
                    }


                    bm1.Save(finishImgPath, ImageFormat.Jpeg);
                    bm2.Dispose();
                    g.Dispose();
                    bm1.Dispose();

                    fileImageList.Add(finishImgPath);
                }
                MergePDFHelper mpHelper = new MergePDFHelper();
                string msg = "";
                mpHelper.MergePDFFile(fileImageList, strFileName, ref msg);//多张图片合并到PDF
            }

        }

        /// <summary>
        /// 切割图片
        /// </summary>
        /// <param name="pageCount">切成几张</param>
        /// <returns></returns>
        private List<string> kalikoImage(int pageCount)
        {
            List<string> imageList = new List<string>();
            for (var n = 0; n < pageCount; n++)
            {
                KalikoImage ki = new KalikoImage(SealPath);
                var w = ki.Width / pageCount; // 计算每张图片的宽度

                ki.Crop(w * n, 0, w, ki.Height);
                //string path = System.IO.Path.Combine(config.Value.Substring(0, config.Value.LastIndexOf(".")), string.Format("{0}{1}.png", count, n));
                //if (!System.IO.Directory.Exists(config.Value.Substring(0, config.Value.LastIndexOf("."))))
                //{
                //    System.IO.Directory.CreateDirectory(config.Value.Substring(0, config.Value.LastIndexOf(".")));//不存在就创建目录 
                //}
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("{0}{1}.png", pageCount, n));
                ki.SavePng(path);
                ki.Dispose();
                imageList.Add(path);
            }
            return imageList;
        }



        /// <summary>
        /// 获取文档的页码
        /// </summary>
        /// <returns></returns>
        public int GetDocumentPageCount()
        {
            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("wenshu.docx"));
            //oDoc.Save(path);
            //Aspose.Words.Document doc = new Document(path);

            //int a= doc.BuiltInDocumentProperties.Pages;
            //Aspose.Words.Document doc = oDoc.Clone();
            //return doc.PageCount;

            return oDoc.PageCount;
        }

        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="multipleReplace"></param>
        public void Replace(List<WordReplaceConfig> multipleReplace)
        {
            foreach (var keyValue in multipleReplace)
            {
                if (keyValue == null)
                {
                    continue;
                }
                switch (keyValue.RelpaceType)
                {
                    case WordRelpaceType.Text:
                        ReplaceText(keyValue.Key, keyValue.Value);
                        break;
                    case WordRelpaceType.Image:
                        ReplaceImage(keyValue.Key, keyValue.Value, keyValue.ImageHeight, keyValue.ImageWidth, false, keyValue.ImageVerticalPosition, keyValue.ImageHorizontalPosition, keyValue.IsLikeStart);
                        break;
                    case WordRelpaceType.CheckBox:
                        ReplaceCheckBox(keyValue.Key, keyValue.Value);
                        break;
                    case WordRelpaceType.MonyCompanySign:
                        AddCompanySign(keyValue);
                        break;

                    case WordRelpaceType.Brand:
                        break;

                    case WordRelpaceType.Paragraph:
                        InsertText(keyValue.Value, keyValue.PContent);
                        break;
                    case WordRelpaceType.Table:
                        ReplaceTable(keyValue.Key, keyValue.TableInfo, keyValue.ImageHeight, keyValue.Value);
                        break;
                    case WordRelpaceType.TableImage:
                        ReplaceImage(keyValue.Key, keyValue.Value, keyValue.ImageHeight, keyValue.ImageWidth, true);
                        break;
                    case WordRelpaceType.DeleteParagraph:
                        DeleteParagraph(keyValue.Value);
                        break;
                    case WordRelpaceType.Bookmark:
                        oDoc.Range.Bookmarks[keyValue.Key].Text = keyValue.Value;
                        break;
                }
            }
        }

        public void ReplaceAll()
        {
            Regex reg = new Regex(@"({.*?})");
            oDoc.Range.Replace(reg, "");
        }

        /// <summary>
        /// 在段落后添加内容
        /// </summary>
        /// <param name="patentList"></param>
        public void InsertText(string paragraphIndex, List<ParagraphContent> PContent)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(paragraphIndex);
            }
            catch (Exception)
            { }

            Paragraph p = oDoc.FirstSection.Body.Paragraphs[index];//根据段落进行查找
            foreach (var item in PContent)
            {
                p.AppendChild(GetRun(item.Content, item.Underline));
            }
        }

        private Run GetRun(string text, bool ul)
        {
            Underline under = Underline.None;
            if (ul)
                under = Underline.Single;

            Run run = new Run(oDoc);
            run.Text = text;
            run.Font.Name = "宋体";
            run.Font.Size = 10.5;
            run.Font.Underline = under;
            return run;
        }

        /// <summary>
        /// 删除空的段落标签
        /// </summary>
        /// <param name="patentList"></param>
        public void DeleteParagraph(string paragraphIndex)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(paragraphIndex);
            }
            catch (Exception)
            { }

            Paragraph p = oDoc.FirstSection.Body.Paragraphs[index];//根据段落进行查找
            p.Remove();
        }
        private void AddCompanySign(WordReplaceConfig config)
        {
            ReplaceCompanySignImage(config.Key, config.Value);
            SealPath = config.Value;
            //List<string> imageList = new List<string>();
            //int count = Convert.ToInt32(config.ImageHeight);
            //if (count == 0)
            //{
            //    count = GetDocumentPageCount();
            //}
            //if (count > 1)
            //{
            //    for (var n = 0; n < count; n++)
            //    {
            //        KalikoImage ki = new KalikoImage(config.Value);
            //        var w = ki.Width / count; // 计算每张图片的宽度

            //        ki.Crop(w * n, 0, w, ki.Height);
            //        //string path = System.IO.Path.Combine(config.Value.Substring(0, config.Value.LastIndexOf(".")), string.Format("{0}{1}.png", count, n));
            //        //if (!System.IO.Directory.Exists(config.Value.Substring(0, config.Value.LastIndexOf("."))))
            //        //{
            //        //    System.IO.Directory.CreateDirectory(config.Value.Substring(0, config.Value.LastIndexOf(".")));//不存在就创建目录 
            //        //}
            //        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("{0}{1}.png", count, n));
            //        ki.SavePng(path);
            //        ki.Dispose();
            //        imageList.Add(path);
            //    }
            //    InsertImageSeal(imageList);
            //}
        }


        /// <summary>
        /// 商标确认函 动态表格
        /// </summary>
        /// <param name="key"></param>
        /// <param name="table"></param>
        /// <param name="value">table列宽字符串集合，如“50,50,50”，注意个数与列数一致</param>
        public void ReplaceTableBrandRegisterConfirm(string key, DataTable nameList)
        {
            try
            {
                Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(oDoc);

                List<double> widthList = new List<double>(nameList.Columns.Count);

                for (int i = 0; i < nameList.Columns.Count; i++)
                {
                    builder.MoveToCell(0, 0, i, 0); //移动单元格
                    double width = builder.CellFormat.Width;//获取单元格宽度
                    widthList.Add(width);
                }


                builder.MoveToBookmark(key);
                //开始添加值
                for (var i = 0; i < nameList.Rows.Count; i++)
                {
                    builder.RowFormat.Height = 60;
                    for (var j = 0; j < nameList.Columns.Count; j++)
                    {
                        builder.InsertCell();// 添加一个单元格                    
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                        builder.CellFormat.Borders.Color = System.Drawing.Color.FromArgb(192, 192, 192);
                        builder.CellFormat.Width = widthList[j];
                        builder.CellFormat.TopPadding = 2;
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                        builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;//水平居中对齐
                        builder.Font.Size = 10.5;
                        builder.Font.Bold = false;
                        builder.Write(nameList.Rows[i][j].ToString());
                    }
                    builder.EndRow();
                }

                builder.RowFormat.Height = 25;
                builder.InsertCell();// 添加一个单元格                    
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.FromArgb(192, 192, 192);
                builder.CellFormat.Width = widthList[0];
                builder.CellFormat.TopPadding = 2;
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;//水平居中对齐
                builder.Font.Size = 10.5;
                builder.Font.Bold = false;
                builder.Write("其他：");


                builder.InsertCell();// 添加一个单元格                    
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.FromArgb(192, 192, 192);
                builder.CellFormat.Width = widthList[1];
                builder.CellFormat.TopPadding = 2;
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;//水平居中对齐
                builder.Font.Size = 10.5;
                builder.Font.Bold = false;
                builder.Write("申请人提供申请资料是否符合法律要求。");

                builder.Font.Name = "Wingdings 2";
                builder.Write("\u0052");

                builder.Font.Name = "宋体";
                builder.Write("是");

                builder.Font.Name = "Wingdings 2";
                builder.Write("\u00A3");

                builder.Font.Name = "宋体";
                builder.Write("否");
                builder.EndRow();


                oDoc.Range.Bookmarks[key].Text = "";    // 清掉标示  
            }
            catch (Exception ex)
            {
                return;
            }
        }


        /// <summary>
        /// 替换table
        /// </summary>
        /// <param name="key">模板里标签字符串</param>
        /// <param name="table">要添加的表对象</param>
        /// <param name="height"></param>
        /// <param name="value">table列宽字符串集合，如“50,50,50”，注意个数与列数一致</param>
        private void ReplaceTable(string key, DataTable table, int height, string value)
        {
            try
            {
                Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(oDoc);

                DataTable nameList = table;


                List<double> widthList = new List<double>(nameList.Columns.Count);
                string[] strList = value.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strList.Length; i++)
                {
                    widthList.Add(Convert.ToDouble(strList[i]));
                }
                builder.MoveToBookmark(key);        //开始添加值


                for (var j = 0; j < nameList.Columns.Count; j++)
                {
                    builder.InsertCell();// 添加一个单元格                    
                    builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                    builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                    builder.CellFormat.Width = widthList[j];
                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                    builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                    builder.Write(nameList.Columns[j].ColumnName.ToString());
                }
                builder.EndRow();

                for (var i = 0; i < nameList.Rows.Count; i++)
                {
                    if (height != 0)
                        builder.RowFormat.Height = height + 4;
                    for (var j = 0; j < nameList.Columns.Count; j++)
                    {
                        builder.InsertCell();// 添加一个单元格                    
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                        builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                        builder.CellFormat.Width = widthList[j];
                        builder.CellFormat.TopPadding = 2;
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                        builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                        //if (nameList.Columns[j].ColumnName == "作品名称")
                        //    builder.Font.Name = "Times New Roman";
                        //else
                        //    builder.Font.Name = "宋体";
                        builder.Write(nameList.Rows[i][j].ToString());
                    }
                    builder.EndRow();
                }

                //oDoc.Range.Bookmarks[key].Text = "";    // 清掉标示  
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// 替换文本
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void ReplaceText(string key, string value)
        {
            if (value.Contains("\r\n"))
            {
                Regex reg = new Regex(key);
                oDoc.Range.Replace(reg, new ReplaceAndInsertText(value), false);
            }
            else
            {
                oDoc.Range.Replace(key, value, false, false);
            }
        }

        /// <summary>
        /// 替换图片 还没有设置图片宽、高、是否悬浮 等参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void ReplaceImage(string key, string value, double imgHeight, double imgWidth, bool IsTable = false)
        {
            ReplaceImage(key, value, imgHeight, imgWidth, IsTable, 0, 0, false);
        }

        /// <summary>
        /// 替换图片 还没有设置图片宽、高、是否悬浮 等参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void ReplaceImage(string key, string value, double imgHeight, double imgWidth, bool IsTable, double top, double left, bool isCenter)
        {
            try
            {
                Regex reg = new Regex(key);
                if (value != null && value.Length > 0)
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(value);
                    double mark = imgHeight > 0 ? imgHeight : imgWidth;
                    double newHei = mark, newWid = mark;

                    if (mark > 0)
                    {
                        int hei = image.Height;
                        int wid = image.Width;
                        if (hei > wid)
                        {
                            newWid = (mark / image.Height) * image.Width;
                        }
                        else
                        {
                            newHei = (mark / image.Width) * image.Height;
                        }
                    }
                    image.Dispose();
                    if (isCenter)
                    {
                        if (newWid < imgWidth)
                        {
                            left = (imgWidth - newWid + left) / 2;
                        }
                        if (newHei < imgHeight)
                        {
                            top = (imgHeight - newHei + top) / 2;
                        }
                    }

                    oDoc.Range.Replace(reg, new ReplaceAndInsertImage(value, newWid, newHei, left, top, IsTable), false);
                }
            }
            catch (Exception)
            {
            }
        }

        private void ReplaceCompanySignImage(string key, string value)
        {
            Regex reg = new Regex(key);
            oDoc.Range.Replace(reg, new ReplaceAndInsertCompanySignImage(value), false);

        }

        /// <summary>
        /// 替换checkbox
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void ReplaceCheckBox(string key, string value)
        {
            Regex reg = new Regex(key);
            oDoc.Range.Replace(reg, new ReplaceAndInsertCheckBox(value), false);
        }

        public void InsertImageSeal(List<string> images)
        {
            var index = 0;

            foreach (var path in images)
            {
                Regex reg = new Regex("{page" + index + "}");
                oDoc.Range.Replace(reg, new InsertImageSealCallback(path, images.Count), false);
                index++;
            }

        }

        /// <summary>
        /// 创建一个条形码图片
        /// </summary>
        /// <param name="txt">条形码内容</param>
        /// <param name="saveFile">保存的地址</param>
        public void CreateBarCode(string txt, string saveFile)
        {
            BarCodeBuilder bb = new BarCodeBuilder();

            //Set the Code text for the barcode
            bb.CodeText = txt;

            //Set the symbology type to Code39Standard
            bb.SymbologyType = Symbology.Code128;

            //Set the width of the bars to 1 millimeter
            //bb.xDimension = 1f;
            // 设置条码的显示质量
            //bb.Resolution = new Resolution(200f, 400f, ResolutionMode.Printer);
            // bb.ImageQuality = ImageQualityMode.AntiAlias;

            //Set the bar height to 3 points
            bb.BarHeight = 15.0f;

            //Set the measuring unit of barcode to point
            bb.GraphicsUnit = System.Drawing.GraphicsUnit.Point;

            //Save the image to your system and set its image format to Jpeg
            bb.Save(saveFile, System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        /// <summary>
        ///  创建一个条形码图片
        /// </summary>
        /// <param name="txt">文本</param>
        /// <param name="mStream">输出流</param>
        public void CreateBarCode(string txt, System.IO.Stream mStream)
        {
            BarCodeBuilder bb = new BarCodeBuilder();

            //Set the Code text for the barcode
            bb.CodeText = txt;

            //Set the symbology type to Code39Standard
            bb.SymbologyType = Symbology.Code128;

            //Set the width of the bars to 1 millimeter
            //bb.xDimension = 1f;
            // 设置条码的显示质量
            //bb.Resolution = new Resolution(200f, 400f, ResolutionMode.Printer);
            // bb.ImageQuality = ImageQualityMode.AntiAlias;

            //Set the bar height to 3 points
            bb.BarHeight = 15.0f;

            //Set the measuring unit of barcode to point
            bb.GraphicsUnit = System.Drawing.GraphicsUnit.Point;

            //Save the image to your system and set its image format to Jpeg
            bb.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);

        }


        /// <summary>
        /// 替换带有换行符号“\r\n”的文本
        /// </summary>
        private class ReplaceAndInsertText : IReplacingCallback
        {
            /// <summary>
            /// 需要替换的文本
            /// </summary>
            public string text { get; set; }
            public ReplaceAndInsertText(string text)
            {
                this.text = text;
            }
            public ReplaceAction Replacing(ReplacingArgs e)
            {
                //获取当前节点
                var node = e.MatchNode;
                //获取当前文档
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                //将光标移动到指定节点
                builder.MoveTo(node);
                builder.Write(text);
                return ReplaceAction.Replace;
            }
        }

        /// <summary>
        /// 骑缝章
        /// </summary>
        public class InsertImageSealCallback : IReplacingCallback
        {
            /// <summary>
            /// 需要插入的图片路径
            /// </summary>
            public string url { get; set; }
            public int pageCount { get; set; }
            public InsertImageSealCallback(string url, int pagecount)
            {
                this.url = url;
                this.pageCount = pagecount;
            }
            public ReplaceAction Replacing(ReplacingArgs e)
            {
                //获取当前节点
                var node = e.MatchNode;
                //获取当前文档
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                //将光标移动到指定节点
                builder.MoveTo(node);
                //System.Drawing.Image image = System.Drawing.Image.FromFile(url);
                //插入图片
                var top = (builder.PageSetup.PageHeight / 2) - 60;
                var left = builder.PageSetup.PageWidth - 120 / pageCount;
                var shape = builder.InsertImage(url, Aspose.Words.Drawing.RelativeHorizontalPosition.Page, left, Aspose.Words.Drawing.RelativeVerticalPosition.Page,
               top, 120 / pageCount, 120, Aspose.Words.Drawing.WrapType.None);
                return ReplaceAction.Replace;
            }
        }

        /// <summary>
        /// 添加盖章图片
        /// </summary>
        public class ReplaceAndInsertCompanySignImage : IReplacingCallback
        {
            /// <summary>
            /// 需要插入的图片路径
            /// </summary>
            public string url { get; set; }
            public ReplaceAndInsertCompanySignImage(string url)
            {
                this.url = url;
            }
            public ReplaceAction Replacing(ReplacingArgs e)
            {
                //获取当前节点
                var node = e.MatchNode;
                //获取当前文档
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                //将光标移动到指定节点
                builder.MoveTo(node);
                //插入图片
                //Aspose.Words.Drawing.Shape s = 
                //50 相对位置 pagecount
                builder.InsertImage(url, Aspose.Words.Drawing.RelativeHorizontalPosition.Column, 90, Aspose.Words.Drawing.RelativeVerticalPosition.Paragraph,
                    0, 120, 120, Aspose.Words.Drawing.WrapType.None);
                return ReplaceAction.Replace;
            }
        }

        public class ReplaceAndInsertImage : IReplacingCallback
        {
            /// <summary>
            /// 需要插入的图片路径
            /// </summary>
            public string url { get; set; }
            public double width { get; set; }
            public double height { get; set; }

            public double left { get; set; }
            public double top { get; set; }
            public bool IsTable { get; set; }

            public ReplaceAndInsertImage(string url, double wid, double hei, bool istable = false)
            {
                this.url = url;
                this.width = wid;
                this.height = hei;
                this.IsTable = istable;
            }
            /// <summary>
            /// 构造函数赋值
            /// </summary>
            /// <param name="url">图片地址</param>
            /// <param name="wid">图片宽度</param>
            /// <param name="hei">图片高度</param>
            /// <param name="left">距左侧位置</param>
            /// <param name="top">距上边距位置，默认0为当前标签位置 可为正数或负数</param>
            public ReplaceAndInsertImage(string url, double wid, double hei, double left, double top, bool istable)
            {
                this.url = url;
                this.width = wid;
                this.height = hei;
                this.left = left;
                this.top = top;
                this.IsTable = istable;
            }

            public ReplaceAction Replacing(ReplacingArgs e)
            {
                //获取当前节点
                var node = e.MatchNode;
                //获取当前文档
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                //将光标移动到指定节点
                builder.MoveTo(node);
                //插入图片
                //Aspose.Words.Drawing.Shape s = 
                //50 相对位置 pagecount
                if (!IsTable)
                    builder.InsertImage(url, Aspose.Words.Drawing.RelativeHorizontalPosition.Character, left, Aspose.Words.Drawing.RelativeVerticalPosition.Paragraph,
                    top, width, height, Aspose.Words.Drawing.WrapType.None);
                else
                    builder.InsertImage(url, Aspose.Words.Drawing.RelativeHorizontalPosition.Column, 0, Aspose.Words.Drawing.RelativeVerticalPosition.TableDefault,
    2, width, height, Aspose.Words.Drawing.WrapType.None);
                return ReplaceAction.Replace;
            }
        }

        public class ReplaceAndInsertCheckBox : IReplacingCallback
        {
            /// <summary>
            /// 添加checkbox的值  1 选中  0未勾选
            /// </summary>
            public string value { get; set; }
            public ReplaceAndInsertCheckBox(string value)
            {
                this.value = value;
            }
            public ReplaceAction Replacing(ReplacingArgs e)
            {
                //获取当前节点
                var node = e.MatchNode;
                //获取当前文档
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                //将光标移动到指定节点
                builder.MoveTo(node);
                builder.Font.Name = "Wingdings 2";

                if (value == "1")
                    builder.Write("\u0052");
                else
                    builder.Write("\u00A3");
                return ReplaceAction.Replace;
            }
        }

    }
}
