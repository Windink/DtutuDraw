using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DtutuDraw
{
    public class Line : Shape
    {

        public Line(Color color, float width,DashStyle a)
        {
            pen = new Pen(color, width);
            pen.DashStyle = a;
        }
  
        public override void Draw(System.Drawing.Graphics g)
        {
            g.DrawLine(pen, MouseDown_Point, MouseUp_Point); 
        }
    }
}
