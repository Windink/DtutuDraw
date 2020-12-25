using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace DtutuDraw
{
    class Dstring:Shape
    {
        private string s;
        private Font font;
        private Brush brush;
        public string S
        {
            get { return s; }
            set { s = value; }
        }
        public Font Font
        { 
            get{return font;}
            set { font = value; }
        }
        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }
        public Dstring(){ }
        public override void Draw(System.Drawing.Graphics g)
        {
            g.DrawString(s,font,brush,MouseDown_Point);
        }
    }
}
