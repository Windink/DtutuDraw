using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Saves:IFunctionFrom
    {
        public PictureBox PictureBox { get; set;}

        public Bitmap Bitmap { get; set; }

         public void Functions()
        {
            PictureBox.BorderStyle = BorderStyle.None;
            Bitmap = new Bitmap(PictureBox.Width,PictureBox.Height);
            PictureBox.DrawToBitmap(Bitmap, PictureBox.ClientRectangle);
            if (Bitmap == null)
            {
                return;
            }
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            saveDlg.OverwritePrompt = true;
            saveDlg.Filter = "BMP文件(*.bmp)|*.bmp|" +
                "JPEG文件(*.jpg)|*.jpg|" + "PNG文件(*.png)|*.png";
            saveDlg.ShowHelp = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDlg.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp":
                        Bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        Bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "tif":
                        Bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        Bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
