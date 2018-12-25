using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Helper
{
    /// <summary>
    /// 2013年10月16日，添加水印和处理图片操作。
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// 为图片添加上水印。
        /// </summary>
        /// <param name="path">图片路径。</param>
        /// <param name="font">字体样式。</param>
        /// <param name="brush">字体边框样式。</param>
        /// <param name="addText">水印文本。</param>
        /// <param name="xOffset">水印相对于图片的x轴的偏移量。</param>
        /// <param name="yOffset">水印相对于图片的y轴的偏移量。</param>
        /// <returns>返回一个imge的内存流，默认格式为Png。</returns>
        public static Stream Watermark(string path, Font font, Brush brush, string addText, int xOffset, int yOffset)
        {
            MemoryStream result = new MemoryStream();
            Image image = Image.FromFile(path);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            g.DrawString(addText, font, brush, xOffset, yOffset);
            g.Dispose();
            image.Save(result, ImageFormat.Png);
            image.Dispose();
            return result;
        }

       /// <summary>
        /// 从流中获取图片，并为图片添加水印。
        /// </summary>
        /// <param name="stream">内存流</param>
        /// <param name="font">字体样式。</param>
        /// <param name="brush">字体边框样式。</param>
        /// <param name="addText">水印文本。</param>
        /// <param name="xOffset">水印相对于图片的x轴的偏移量。</param>
        /// <param name="yOffset">水印相对于图片的y轴的偏移量。</param>
        /// <returns>返回一个imge的内存流，默认格式为Png。</returns>
        public static Stream Watermark(Stream stream, Font font, Brush brush, string addText, int xOffset, int yOffset)
        {
            MemoryStream result = new MemoryStream();
            Image image = Image.FromStream(stream);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            g.DrawString(addText, font, brush, xOffset, yOffset);
            g.Dispose();
            image.Save(stream, ImageFormat.Png);
            image.Dispose();
            return stream;
        }

        /// <summary>
        /// 为图片添加上，图片类型的水印。
        /// </summary>
        /// <param name="path">图片路径。</param>
        /// <param name="waterPath">水印图片路径。</param>
        /// <returns>返回一个imge的内存流，默认格式为Png。</returns>
        public static Stream PicWatermark(string path,string waterPath)
        {
            Image image = Image.FromFile(path);
            Image copyImage = Image.FromFile(waterPath);
            MemoryStream result = new MemoryStream();
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(copyImage, new Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
            g.Dispose();
            image.Save(result,ImageFormat.Png);
            image.Dispose();
            return result;
        }


        // 生成验证码
        public static Stream VerifyImg(string code)
        {
            MemoryStream result = new MemoryStream();
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue }; //颜色列表，用于验证码、噪线、噪点
            string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" }; //字体列表，用于验证码
            Random rnd = new Random();
            Bitmap bmp = new Bitmap(100, 40);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //画噪线
            for (int i = 0; i < 10; i++)
            {
                int x1 = rnd.Next(100);
                int y1 = rnd.Next(40);
                int x2 = rnd.Next(100);
                int y2 = rnd.Next(40);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码字符串
            for (int i = 0; i < code.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, 18);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(code[i].ToString(), ft, new SolidBrush(clr), (float)i * 20 + 8, (float)8);
            }
            //画噪点
            for (int i = 0; i < 100; i++)
            {
                int x = rnd.Next(bmp.Width);
                int y = rnd.Next(bmp.Height);
                Color clr = color[rnd.Next(color.Length)];
                bmp.SetPixel(x, y, clr);
            }
            try
            {
                bmp.Save(result, ImageFormat.Png);
            }
            finally
            {
                bmp.Dispose();
                g.Dispose();
            }
            return result;
        }

        // 生成验证码
        public static Stream NewVerifyImg(string vstr)
        {

            string[] FontFamilyArray = new string[] { "Tahoma", "Arial", "Times New Roman" };

            Random rnd = new Random(DateTime.Now.Second);
            string fontfamily = FontFamilyArray[rnd.Next(0, FontFamilyArray.Length)];
            FontStyle fontstyle = FontStyle.Regular;

            int WHeight = 25;
            int Gheight = vstr.Length * 20 + 5;

            System.Drawing.Bitmap Img = new System.Drawing.Bitmap(Gheight, WHeight);
            Graphics g = Graphics.FromImage(Img);

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, Img.Width, Img.Height);

            int seed = rnd.Next(0, 100);

            float x = 2;
            for (int i = 0; i < vstr.Length; i++)
            {
                int fontsize = rnd.Next(12, 18);
                Font font = new Font(fontfamily, fontsize, fontstyle);
                float y = (WHeight - font.Height) - 1;
                g.DrawString(vstr[i].ToString(), font, new System.Drawing.SolidBrush(RandomColor(seed + i + 1)), x, y);
                x += fontsize + 3;
            }

            System.IO.MemoryStream result = new System.IO.MemoryStream();
            Img.Save(result, System.Drawing.Imaging.ImageFormat.Png);
            Img.Dispose();
            g.Dispose();
            return result;
        }


        // 随机生成颜色。
        private static Color RandomColor(int seed)
        {
            Color[] colors = new Color[] { Color.Black, Color.Red, Color.Blue, Color.DarkRed, Color.DarkGreen, Color.DarkOrange };
            Random rnd = new Random(seed);
            Color srcColor = colors[rnd.Next(0, colors.Length)];
            int alpha = (int)srcColor.A;
            int blue = (int)srcColor.B;
            int red = (int)srcColor.R;
            int green = (int)srcColor.G;
            blue = blue + rnd.Next(10, 50);
            if (blue > 255)
                blue = blue - 255;
            return Color.FromArgb(rnd.Next(200, 250), red, green, blue);
        }

        //  随机生成汉字。
        /// 可以随机生成一个长度为2的十六进制字节数组，
        /// 使用GetString ()方法对其进行解码就可以得到汉字字符了。
        /// 不过对于生成中文汉字验证码来说，因为第15区也就是AF区以前都没有汉字，
        /// 只有少量符号，汉字都从第16区B0开始，并且从区位D7开始以后的汉字都是和很难见到的繁杂汉字，
        /// 所以这些都要排出掉。所以随机生成的汉字十六进制区位码第1位范围在B、C、D之间，
        /// 如果第1位是D的话，第2位区位码就不能是7以后的十六进制数。
        /// 在来看看区位码表发现每区的第一个位置和最后一个位置都是空的，没有汉字，
        /// 因此随机生成的区位码第3位如果是A的话，第4位就不能是0；第3位如果是F的话，第4位就不能是F
        public static string GetRandomChinese(int strlength)
        {
            // 获取GB2312编码页（表） 
            Encoding gb = Encoding.GetEncoding("gb2312");

            object[] bytes = ImageHelper.CreateRegionCode(strlength);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < strlength; i++)
            {
                string temp = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                sb.Append(temp);
            }

            return sb.ToString();
        }

        // 获取简体中文
        public static object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素 
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            Random rnd = new Random();

            //定义一个object数组用来 
            object[] result = new object[strlength];

            /**
             每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bytes数组中 
             每个汉字有四个区位码组成 
             区位码第1位和区位码第2位作为字节数组第一个元素 
             区位码第3位和区位码第4位作为字节数组第二个元素 
            **/
            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位 
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i); // 更换随机数发生器的 种子避免产生重复值 
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                // 定义两个字节变量存储产生的随机汉字区位码 
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                // 将两个字节变量存储在字节数组中 
                byte[] str_r = new byte[] { byte1, byte2 };

                // 将产生的一个汉字的字节数组放入object数组中 
                result.SetValue(str_r, i);
            }

            return result;
        }
    }
}
