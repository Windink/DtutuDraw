using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DtutuDraw
{
    interface IFunctionFrom
    {
       PictureBox PictureBox { get; set; }
       Bitmap Bitmap { get; set; }
        void Functions();
    }
}
