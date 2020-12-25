using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DtutuDraw
{
    interface IEdgeSet
    {
        Point[] Points { get; set; }
        void ToStrings();
    }
}
