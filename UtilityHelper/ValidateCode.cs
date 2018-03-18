using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace UtilityHelper
{
    public class ValidateCode
    {
        public const string COOKIES_CODE_INFO = "wi8c13ijge";
        public const string COOKIE_CODE_NAME = "kt6k14cvlg";
        /// <summary>
        /// Validation Code generated fromt these charaters.
        /// </summary>
        private const string strValidateCodeBound = "abcdefghijkmnpqrstuvwxyz23456789"; // ABCDEFGHIJKLMNPQRSTUVWXYZ
        private static string[] Fonts = new string[] {  "Helvetica",
                                                 "Geneva",
                                                 "sans-serif",
                                                 "Verdana",
                                                 "Times New Roman",
                                                 "Courier New",
                                                 "Arial"
                                             };
        /// <summary>
        /// 输出二进制验证码
        /// </summary>
        /// <param name="validateCode"></param>
        /// <param name="str_ValidateCode"></param>
        /// <returns></returns>
        private byte[] OutputCode(string validateCode, ref string str_ValidateCode)
        {
            str_ValidateCode = GetRandomString(Convert.ToInt32(validateCode));
            return CreateImage(str_ValidateCode);
        }
        //颜色列表，用于验证码、噪线、噪点 
        Color[] color ={ Color.Tomato, Color.OrangeRed, Color.Olive, Color.Gold, Color.GreenYellow,
                          Color.Blue, Color.LawnGreen, Color.Lime, Color.MediumSpringGreen, Color.Aqua, Color.RoyalBlue, Color.MediumBlue,
                          Color.BlueViolet, Color.MediumOrchid, Color.Fuchsia, Color.DeepPink, Color.HotPink };
        Random rnd = new Random();
        /// <summary>
        /// 生成随机数
        /// </summary>
        private string GetRandomString(int int_NumberLength)
        {
            string valString = string.Empty;
            Random theRandomNumber = new Random((int)DateTime.Now.Ticks);

            for (int int_index = 0; int_index < int_NumberLength; int_index++)
                valString += strValidateCodeBound[theRandomNumber.Next(strValidateCodeBound.Length - 1)].ToString();

            return valString;
        }

        /// <summary>
        /// 生成随机颜色
        /// </summary>
        private Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);

            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);


            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;

            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        private byte[] CreateImage(string str_ValidateCode)
        {
            int int_ImageWidth = str_ValidateCode.Length * 22;
            Random newRandom = new Random();

            Bitmap theBitmap = new Bitmap(int_ImageWidth + 6, 38);
            Graphics theGraphics = Graphics.FromImage(theBitmap);

            theGraphics.Clear(ColorTranslator.FromHtml("#ffffff"));

            drawLine(theGraphics, theBitmap, newRandom);
            theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, theBitmap.Width - 1, theBitmap.Height - 1);

            for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
            {
                Matrix X = new Matrix();
                X.Shear((float)newRandom.Next(0, 300) / 1000 - 0.25f, (float)newRandom.Next(0, 100) / 1000 - 0.05f);
                theGraphics.Transform = X;
                string str_char = str_ValidateCode.Substring(int_index, 1);
                // System.Drawing.Drawing2D.LinearGradientBrush newBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, theBitmap.Width, theBitmap.Height), ColorTranslator.get, Color.DarkRed, 1.2f, true);
                System.Drawing.Drawing2D.LinearGradientBrush newBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, theBitmap.Width, theBitmap.Height), ColorTranslator.FromHtml("#FF0505"), ColorTranslator.FromHtml("#FF0505"), 1.2f, true);
                Point thePos = new Point(int_index * 21 + 1 + newRandom.Next(3), 1 + newRandom.Next(13));

                Font theFont = new Font(Fonts[newRandom.Next(Fonts.Length - 1)], newRandom.Next(14, 18), FontStyle.Bold);

                theGraphics.DrawString(str_char, theFont, newBrush, thePos);
            }

            MemoryStream ms = new MemoryStream();
            theBitmap.Save(ms, ImageFormat.Png);
            drawPoint(theBitmap, newRandom);

            theGraphics.Dispose();
            theBitmap.Dispose();
            return ms.ToArray();
        }

        /// <summary>
        ///划线
        /// </summary>
        private void drawLine(Graphics gfc, Bitmap img, Random ran)
        {
            for (int i = 0; i < 15; i++)
            {
                int x1 = ran.Next(img.Width);
                int y1 = ran.Next(img.Height);
                int x2 = ran.Next(img.Width);
                int y2 = ran.Next(img.Height);
                // gfc.DrawLine(new Pen(color[rnd.Next(color.Length)]), x1, y1, x2, y2);
                gfc.DrawLine(new Pen(ColorTranslator.FromHtml("#d6d6d6")), x1, y1, x2, y2);
            }
        }

        /// <summary>
        ///划点
        /// </summary>
        private void drawPoint(Bitmap img, Random ran)
        {
            for (int i = 0; i < 30; i++)
            {
                int x = ran.Next(img.Width);
                int y = ran.Next(img.Height);
                img.SetPixel(x, y, Color.FromArgb(ran.Next()));
            }

        }


        public ImageValidateCode GetValidateImage(int codeLenght = 6)
        {
            string str_ValidateCode = string.Empty;
            string BaseStrValidateCode = Convert.ToBase64String(OutputCode(codeLenght.ToString(), ref str_ValidateCode));
            //保存验证码的Cookie 
            //HttpContext.Current.Response.Cookies.Remove(COOKIES_CODE_INFO);
            //HttpCookie anycookie = new HttpCookie(COOKIES_CODE_INFO);

            //anycookie.Values.Add(COOKIE_CODE_NAME, str_ValidateCode);
            //anycookie.Expires.AddMinutes(1);
            HttpContext.Current.Response.Cookies[COOKIES_CODE_INFO].Values[COOKIE_CODE_NAME] = str_ValidateCode;
            HttpContext.Current.Response.Cookies[COOKIES_CODE_INFO].Expires = DateTime.Now.AddMinutes(1);
            var json = new ImageValidateCode() { Code = BaseStrValidateCode, Key = str_ValidateCode };
            return json;
        }
        //短信验证码
        public string SendCode(int codeLenght = 6)
        { 
            string str_ValidateCode = string.Empty;
            string BaseStrValidateCode = Convert.ToBase64String(OutputCode(codeLenght.ToString(), ref str_ValidateCode));
            //保存验证码的Cookie
            HttpContext.Current.Response.Cookies[COOKIES_CODE_INFO].Values[COOKIE_CODE_NAME] = str_ValidateCode;
            HttpContext.Current.Response.Cookies[COOKIES_CODE_INFO].Expires = DateTime.Now.AddMinutes(1);
            return str_ValidateCode;
        }

    }

    public class ImageValidateCode
    {
        /// <summary>
        /// 图片Base64码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 验证的Key
        /// </summary>
        public string Key { get; set; }

        public string GUID { get; set; }

        /// <summary>
        /// 失效时间，单位秒
        /// </summary>
        public int Time { get; set; }

        public ImageValidateCode()
        {
            Time = 60;
        }
    }

}
