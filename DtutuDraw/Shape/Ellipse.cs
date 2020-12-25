using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DtutuDraw
{
    public class Ellipse : Shape
    {
        public Ellipse(Color color, float width)
        {
            pen = new Pen(color, width);
        }
        public override void Draw(System.Drawing.Graphics g)
        {
                g.DrawEllipse(pen,Shape_Point.X, Shape_Point.Y, Width, Height);
          
        }
    }

}
