using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Open:IFunctionFrom
    {
        public PictureBox PictureBox { get; set; }

        public Bitmap Bitmap { get; set; }

        private String curFileName;

        public String CurFileName
        {
            get { return curFileName; }
            set { curFileName = value; }
        }

        public void Functions()
        {
           
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件|*.bmp;*.pcx;*.png;*.jpg;*.gif;" +
                "*.tif;*.ico;*.dxf;*.cgm;*.cdr;*.wmf;*.eps;*.emf|" +
                "位图(*.bmp;*.jpg;*.png;...)|*.bmp;*.pcx;*.png;*.jpg;*.gif;*.tif;*.ico|" +
                "矢量图(*.wmf;*.eps;*.emf;..)|*.dxf;*.cgm;*.cdr;*.wmf;*.eps;*.emf";
            opnDlg.Title = "打开图像文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                CurFileName = opnDlg.FileName;
            }
            try
            {
                Bitmap =(Bitmap)Image.FromFile(CurFileName);
            }
            catch (Exception ex)
                {
                throw ex;
                }
             }
    }
}
