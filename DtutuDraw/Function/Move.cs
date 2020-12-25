using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Move : Shape
    {
        
        private Point shapepoint_start;
        private Point shapepoint_end;
        private PictureBox pictureBox;
        private Rectangle origReg;
        private Rectangle destReg;
        private Rectangle destrect;
        private Rectangle origrect;
        public Bitmap bitmap { get; set; }
        public Rectangle DestRect
        {
            get { return destrect; }
            set
            {
                //if (value.X < 0)
                //    value.X = 0;
                //if(value.Y<0)
                //    value.Y = 0;
                destrect = value;
            }
        }
        public Rectangle OrigRect
        {
            get { return origrect; }
            set { origrect = value; }
        }
        public PictureBox PictureBoxs
        {
            get { return pictureBox; }
            set { pictureBox = value; }
        }
        
        public Point ShapePoint_Start
        {
            get { return shapepoint_start; }
            set { shapepoint_start = value; }
        }
        public Point ShapePoint_End
        {
            get { return shapepoint_end; }
            set { shapepoint_end = value; }
        }
        public Rectangle GetOrigReg
        {
            get {
              origReg= new Rectangle(Shape_Point.X+1, Shape_Point.Y+1, PictureBoxs.Width, PictureBoxs.Height);
                return origReg; }
        }
        public Rectangle GetDestReg
        {
            get {destReg= new Rectangle(0, 0, PictureBoxs.Width, PictureBoxs.Height);
                return destReg; }
        }
        public Move(Color color,float width)
        {
            pen = new Pen(color, width);
        }
        public override void Draw(Graphics g)
        {
            this.InitialDraw();
            this.DrawWhile(g);
            g.DrawImage(bitmap, DestRect, OrigRect, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="g">画笔</param>
        public void DrawWhile(Graphics g)
        {
            Bitmap bitmaps = new Bitmap(PictureBoxs.Width, PictureBoxs.Height);
            Graphics graphics = Graphics.FromImage(bitmaps);
            graphics.Clear(Color.White);
            g.DrawImage(bitmaps,new Rectangle(Shape_Point.X,Shape_Point.Y,Width,Height),new Rectangle(0,0,Width,Height),GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 初始化picturebox
        /// </summary>
        /// <param name="pictureBox1">获取参数的图像</param>
        /// <returns></returns>
        public PictureBox InitilaPicture( PictureBox pictureBox1)
        {
            PictureBoxs = new PictureBox();
            PictureBoxs.Location = new Point(Shape_Point.X,Shape_Point.Y);
            PictureBoxs.Size = new Size(Width, Height);
            PictureBoxs.BorderStyle = BorderStyle.None;
            PictureBoxs.Cursor = Cursors.SizeAll;
            PictureBoxs.Image = Capturegraph(pictureBox1);
            return PictureBoxs;
        }

        /// <summary>
        /// 初始化Draw的数据
        /// </summary>
        public void InitialDraw()
        {
            PictureBoxs.DrawToBitmap(bitmap, PictureBoxs.ClientRectangle);
            DestRect = new Rectangle(PictureBoxs.Location.X,
            PictureBoxs.Location.Y, PictureBoxs.Width, PictureBoxs.Height);
            OrigRect = new Rectangle(0, 0, PictureBoxs.Width, PictureBoxs.Height);
        }

        /// <summary>
        /// 获取pictureBox1指定的图像
        /// </summary>
        /// <param name="pictureBox1">需要获取的图像</param>
        /// <returns></returns>
        public Bitmap Capturegraph(PictureBox pictureBox1)
        {
            bitmap = new Bitmap(Width,Height);
            Bitmap bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bitmap1, pictureBox1.ClientRectangle);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(bitmap1, GetDestReg, GetOrigReg, GraphicsUnit.Pixel);
            return bitmap;
        }

    }
}
