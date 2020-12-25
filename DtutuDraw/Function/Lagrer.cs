using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Lagrer
    {
        private Point point;
        private Point point1;
        public Point GetPoint
        {
            get { return point; }
            set { point = value; }
        }
        public Point GetPoint1
        {
            get { return point1; }
            set { point1 = value; }
        }
        


        public void Draw(Graphics g,Panel panel)
        {
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            g.DrawRectangle( pen,0,0,panel.Location.X+(panel.Width/2),panel.Location.Y+(panel.Height/2));
        }
    }
}
