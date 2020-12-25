using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DtutuDraw
{
    class FiveStar:Shape,IAddPoint
    {

        private PointF[] points = new PointF[3];
        public PointF[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public void AddPoint()
        {
            points[0] = new PointF(-Width*0.11f,-Height*0.17f);
            points[1] = new PointF(0,-Height*0.5f );
            points[2] = new PointF(Width * 0.11f,-Height * 0.17f);
        }
        public FiveStar(Color color, float width)
        {
            pen = new Pen(color, width);
        }

        public override void Draw(Graphics g)
        {
            g.TranslateTransform(Shape_Point.X+Width/2,Shape_Point.Y+Height/2);
            for(int i=0;i<5;i++)
            { 
                g.RotateTransform(72f);
                g.DrawLines(pen, Points);
            }
            g.TranslateTransform(-(Shape_Point.X + Width / 2), -(Shape_Point.Y + Height / 2));
        }
    }
}
