using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DtutuDraw
{
    class Circle:Shape
    {
        private int radius;
        public int Radius
        {
            get {radius= (int)Math.Sqrt(Math.Pow(MouseDown_Point.X - MouseUp_Point.X, 2) + Math.Pow(MouseDown_Point.Y - MouseUp_Point.Y, 2));
                return radius;  }
        }
        public Circle(Color color, float width)
        {
            pen = new Pen(color, width);
        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, MouseDown_Point.X-Radius, MouseDown_Point.Y-Radius, Radius*2, Radius*2);

        }
    }
}
