using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Arcnothing:Shape
    {

        public   float StartAngle = -180f;
        public  float SweepAngle = 180f;

        public Arcnothing(Color color,float width )
        {
            pen = new Pen(color, width);
        }
        public override void Draw(System.Drawing.Graphics g)
        {

                g.DrawArc(pen, Shape_Point.X, Shape_Point.Y, Width/2, Height/2, StartAngle, SweepAngle);
                g.DrawArc(pen, (MouseDown_Point.X + MouseUp_Point.X) / 2,Shape_Point.Y, Width/2, Height/2, StartAngle, SweepAngle);
                g.DrawBezier(pen,new Point(Shape_Point.X,Shape_Point.Y+Height/4),new Point(Shape_Point.X+Width/10,Shape_Point.Y+Height/4*3), new Point(Shape_Point.X + Width / 10*4, Shape_Point.Y + Height),new Point(Width/2+Shape_Point.X,Shape_Point.Y+Height));
                g.DrawBezier(pen, new Point(Shape_Point.X+Width, Shape_Point.Y + Height / 4), new Point(Shape_Point.X+Width - Width / 10, Shape_Point.Y+ Height / 4 * 3), new Point(Shape_Point.X+Width - Width / 10 * 4, Shape_Point.Y + Height), new Point(Width/2 + Shape_Point.X, Shape_Point.Y+Height));

        }
    }
}
