using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace DtutuDraw
{
    class Lines : Shape
    {

        public Point[] points=new Point[1];

        
        public Lines(Color color, float width)
        {
            pen = new Pen(color, width);
        }
        public override void Draw(System.Drawing.Graphics g)
        {

            g.DrawLines(pen, points);
        }
    }
}
