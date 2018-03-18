using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace UtilityHelper
{
    public class QRHelper
    {
        #region 生成二维码 方式1 

        #region 生成二维码 不带Logo

        /// <summary>
        /// Description：生成二维码
        /// </summary>
        /// <param name="qrurl"></param>
        /// <param name="savePath">/upload/dqcccQR/</param>
        /// <param name="imgName"></param>
        /// <returns>返回二维码的图片地址 不带域名</returns>
        public string CreateQRNoLogo(string qrurl, string savePath, string imgName, string qrColor = "#000000")
        {
            string imgurl = "";
            try
            {
                Bitmap bt;
                string enCodeString = qrurl;
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                qrCodeEncoder.QRCodeScale = 10;
                qrCodeEncoder.QRCodeVersion = 12;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeForegroundColor = colorHx16toRGB(qrColor);

                bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);

                string path = HttpContext.Current.Server.MapPath("~" + savePath) + imgName + ".jpg";
                bt.Save(path);

                imgurl = savePath + imgName + ".jpg";
            }
            catch
            {
                imgurl = "地址返回错误";
            }
            return imgurl;

        }

        #endregion

        #region 生成二维码，带Logo

        /// <summary>
        /// Description：生成二维码，带Logo
        /// <para>Editor： 之前调用该方法的接口，都已经改成新版二维码</para>
        /// </summary>
        /// <param name="qrurl">要生成二维码的连接地址，带Http</param>
        /// <param name="savePath">/upload/dqcccQR/</param>
        /// <param name="imgName">二维码的图片名称</param>
        /// <param name="logoPath">二维码中间的图片地址</param>
        /// <param name="qrColor">二维码的底色</param>
        /// <returns>返回二维码的图片地址 不带域名</returns>
        public string CreateQR_Member(string qrurl, string savePath, string imgName, string logoPath, string qrColor = "#000000")
        {
            string imgurl = "";

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 8;
            qrCodeEncoder.QRCodeVersion = 10;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeForegroundColor = colorHx16toRGB(qrColor);

            System.Drawing.Image image = qrCodeEncoder.Encode(qrurl);

            CombinImage(image, HttpContext.Current.Server.MapPath("~" + logoPath)).Save(HttpContext.Current.Server.MapPath("~" + savePath) + imgName + ".jpg");

            imgurl = savePath + imgName + ".jpg";

            return imgurl;
        }

        #endregion

        #region 生成二维码 带logo

        /// <summary>
        /// Description：生成二维码，带Logo
        /// </summary>
        /// <param name="qrurl">要生成二维码的连接地址，带Http</param>
        /// <param name="savePath">/upload/dqcccQR/</param>
        /// <param name="imgName">二维码的图片名称</param>
        /// <param name="logoPath">二维码中间的图片地址</param>
        /// <returns>返回二维码的图片地址 不带域名</returns>
        public string CreateQR(string qrurl, string savePath, string imgName, string logoPath)
        {
            string imgurl = "";

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 8;

            //C#生成二维码(ThoughtWorks.QRCode.dll)时字符串稍长一些就报异常"索引超出范围，将QRCodeVersion 改为0
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeForegroundColor = colorHx16toRGB("#000000");

            System.Drawing.Image image = qrCodeEncoder.Encode(qrurl);

            CombinImage(image, HttpContext.Current.Server.MapPath("~" + logoPath)).Save(HttpContext.Current.Server.MapPath("~" + savePath) + imgName + ".jpg");

            imgurl = savePath + imgName + ".jpg";

            return imgurl;
        }

        #endregion

        #region 辅助方法

        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    /Upload/User/Gravatar/128.jpg
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg);        //照片图片      
            if (img.Height != 120 || img.Width != 120)
            {
                img = KiResizeImage(img, 120, 120, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }



        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>  
        /// [颜色：16进制转成RGB]  
        /// </summary>  
        /// <param name="strColor">设置16进制颜色(#FFFFFF) </param>  
        /// <returns></returns>  
        public static System.Drawing.Color colorHx16toRGB(string strHxColor)
        {
            return System.Drawing.Color.FromArgb(System.Int32.Parse(strHxColor.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier), System.Int32.Parse(strHxColor.Substring(3, 2), System.Globalization.NumberStyles.AllowHexSpecifier), System.Int32.Parse(strHxColor.Substring(5, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
        }

        #endregion

        #endregion

        #region 生成二维码 方式2 测试。。。。

        public string CCLCreateQR_Member(string qrurl, string savePath, string imgName, string logoPath, int QRCodeScale = 5, int QRCodeVersion = 0, int size = 200, int border = 5, string qrColor = "#000000")
        {
            string imgurl = ""; 
            string content = qrurl; 
            System.Drawing.Image image2 = CreateQRCode(content,
                QRCodeEncoder.ENCODE_MODE.BYTE,
                QRCodeEncoder.ERROR_CORRECTION.M,
                QRCodeVersion,
                QRCodeScale,
                size,
                border); 
            CombinImage(image2, HttpContext.Current.Server.MapPath(logoPath)).Save(HttpContext.Current.Server.MapPath(savePath) + imgName + ".jpg");

            imgurl = savePath + imgName + ".jpg";

            return imgurl;
        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="Content">内容文本</param>
        /// <param name="QRCodeEncodeMode">二维码编码方式</param>
        /// <param name="QRCodeErrorCorrect">纠错码等级</param>
        /// <param name="QRCodeVersion">二维码版本号 0-40</param>
        /// <param name="QRCodeScale">每个小方格的预设宽度（像素），正整数</param>
        /// <param name="size">图片尺寸（像素），0表示不设置</param>
        /// <param name="border">图片白边（像素），当size大于0时有效</param>
        /// <returns></returns>
        public System.Drawing.Image CreateQRCode(string Content, QRCodeEncoder.ENCODE_MODE QRCodeEncodeMode, QRCodeEncoder.ERROR_CORRECTION QRCodeErrorCorrect, int QRCodeVersion, int QRCodeScale, int size, int border)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncodeMode;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeErrorCorrect;
            qrCodeEncoder.QRCodeScale = QRCodeScale;
            qrCodeEncoder.QRCodeVersion = QRCodeVersion;

            System.Drawing.Image image = qrCodeEncoder.Encode(Content);

            #region 根据设定的目标图片尺寸调整二维码QRCodeScale设置，并添加边框
            if (size > 0)
            {
                //当设定目标图片尺寸大于生成的尺寸时，逐步增大方格尺寸
                #region 当设定目标图片尺寸大于生成的尺寸时，逐步增大方格尺寸
                while (image.Width < size)
                {
                    qrCodeEncoder.QRCodeScale++;
                    System.Drawing.Image imageNew = qrCodeEncoder.Encode(Content);
                    if (imageNew.Width < size)
                    {
                        image = new System.Drawing.Bitmap(imageNew);
                        imageNew.Dispose();
                        imageNew = null;
                    }
                    else
                    {
                        qrCodeEncoder.QRCodeScale--; //新尺寸未采用，恢复最终使用的尺寸
                        imageNew.Dispose();
                        imageNew = null;
                        break;
                    }
                }
                #endregion

                //当设定目标图片尺寸小于生成的尺寸时，逐步减小方格尺寸
                #region 当设定目标图片尺寸小于生成的尺寸时，逐步减小方格尺寸
                while (image.Width > size && qrCodeEncoder.QRCodeScale > 1)
                {
                    qrCodeEncoder.QRCodeScale--;
                    System.Drawing.Image imageNew = qrCodeEncoder.Encode(Content);
                    image = new System.Drawing.Bitmap(imageNew);
                    imageNew.Dispose();
                    imageNew = null;
                    if (image.Width < size)
                    {
                        break;
                    }
                }
                #endregion

                //如果目标尺寸大于生成的图片尺寸，则为图片增加白边
                #region 如果目标尺寸大于生成的图片尺寸，则为图片增加白边
                if (image.Width <= size)
                {
                    //根据参数设置二维码图片白边的最小宽度
                    #region 根据参数设置二维码图片白边的最小宽度
                    if (border > 0)
                    {
                        while (image.Width <= size && size - image.Width < border * 2 && qrCodeEncoder.QRCodeScale > 1)
                        {
                            qrCodeEncoder.QRCodeScale--;
                            System.Drawing.Image imageNew = qrCodeEncoder.Encode(Content);
                            image = new System.Drawing.Bitmap(imageNew);
                            imageNew.Dispose();
                            imageNew = null;
                        }
                    }
                    #endregion

                    //当目标图片尺寸大于二维码尺寸时，将二维码绘制在目标尺寸白色画布的中心位置
                    if (image.Width < size)
                    {
                        //新建空白绘图
                        System.Drawing.Bitmap panel = new System.Drawing.Bitmap(size, size);
                        System.Drawing.Graphics graphic0 = System.Drawing.Graphics.FromImage(panel);
                        int p_left = 0;
                        int p_top = 0;
                        if (image.Width <= size) //如果原图比目标形状宽
                        {
                            p_left = (size - image.Width) / 2;
                        }
                        if (image.Height <= size)
                        {
                            p_top = (size - image.Height) / 2;
                        }

                        //将生成的二维码图像粘贴至绘图的中心位置
                        graphic0.DrawImage(image, p_left, p_top, image.Width, image.Height);
                        image = new System.Drawing.Bitmap(panel);
                        panel.Dispose();
                        panel = null;
                        graphic0.Dispose();
                        graphic0 = null;
                    }
                }
                #endregion
            }
            #endregion
            return image;
        }

        #endregion

    }
}
