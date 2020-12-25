using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Backgrounds : Shape
    {
        private Image Image;

        //private PictureBox pictureBox;

        //public PictureBox PictureBoxs
        //{
        //    get { return pictureBox; }
        //    set { pictureBox = value; }
        //}

        public Image Images
        {
            get { return Image; }
            set { Image = value; }
        }

        public void Initiaimage(PictureBox pictureBox)
        {
            Images = pictureBox.Image;
            if(Images == null)
            {
                Image images = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics graphics = Graphics.FromImage(images);
                graphics.Clear(pictureBox.BackColor);
                Images = images;
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Images, 0,0);
        }
    }
}
