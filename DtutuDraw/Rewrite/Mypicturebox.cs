using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DtutuDraw
{
    class Mypicturebox:PictureBox
    {

        public Mypicturebox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
