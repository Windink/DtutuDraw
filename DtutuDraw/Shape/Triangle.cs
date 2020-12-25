using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DtutuDraw
{
    class Triangle: Shape,IEdgeSet
    {
       private Point[] points=new Point[4];
        public Point[] Points
        {
            get { return points; }
            set { points = value; }
        }

        public Triangle(Color color, float width)
        {
            pen = new Pen(color, width);
        }
        public override void Draw(System.Drawing.Graphics g)
        {
            g.DrawLines(pen, points);
        }
        public void ToStrings()
        {
            foreach (var i in Points)
                Console.Write(i);
        }
    }
}
