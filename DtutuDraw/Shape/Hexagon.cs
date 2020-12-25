using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace DtutuDraw
{
    class Hexagon:Shape,IAddPoint,IEdgeSet
    {

        private Point[] points=new Point[6];
        public Point[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public void AddPoint()
        {

            points[0] = new Point((MouseDown_Point.X + MouseUp_Point.X) / 2, Shape_Point.Y);
            points[1] = new Point(Shape_Point.X + Width, Height / 4 + Shape_Point.Y);
            points[2] = new Point(Shape_Point.X + Width, Shape_Point.Y+Height -Height / 4);
            points[3] = new Point((MouseDown_Point.X + MouseUp_Point.X) / 2, Shape_Point.Y+Height);
            points[4] = new Point(Shape_Point.X, Shape_Point.Y+Height - Height / 4);
            points[5] = new Point(Shape_Point.X, Height / 4 +Shape_Point.Y);

        }


       public Hexagon(Color color, float width)
       {
           pen = new Pen(color,width);
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
