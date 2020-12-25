using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace DtutuDraw
{
    class Pentagon :Shape,IAddPoint,IEdgeSet
    {
 
        private Point[] points = new Point[5];
        public Point[] Points
        {
            get { return points; }
            set { points = value; }
        }

        public void AddPoint()
        {
          points[0]=  new Point((MouseUp_Point.X + MouseDown_Point.X) / 2, Shape_Point.Y);
          points[1] = new Point(Shape_Point.X, Height / 3 + Shape_Point.Y);
          points[2] = new Point(Shape_Point.X + Width/ 5, Shape_Point.Y+Height);
          points[3] = new Point(Shape_Point.X+Width - Width/ 5, Shape_Point.Y+Height);
          points[4] = new Point(Shape_Point.X+Width, Height / 3 + Shape_Point.Y);

        }
        public  Pentagon(Color color, float width)
        {
            pen = new Pen(color, width); 
        }
        public override void Draw(System.Drawing.Graphics g)
        {

            g.DrawPolygon(pen, points);
        }
        public void ToStrings()
        {
            foreach (var i in Points)
                Console.Write(i);
        }
    }
}
