using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DtutuDraw
{
    public class Rectangles : Shape
    {
        public Rectangles(Color color, float width)
        {
            pen = new Pen(color, width);
        }
        public override void Draw(Graphics g)
        {
                g.DrawRectangle(pen,Shape_Point.X, Shape_Point.Y, Width, Height);
        }

    }
}
