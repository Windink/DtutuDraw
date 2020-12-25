using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace DtutuDraw
{
    public abstract class Shape 
    {
        private Point mousedown_point;//鼠标点击的坐标
        private Point mouseup_point;//鼠标释放的坐标
        private Point shape_point;//图形的左上角坐标
        private int width;//图形宽度
        private int height;//图形高度

        public int Width
        {
            get {
                width = Math.Abs(MouseDown_Point.X - MouseUp_Point.X);
                return width;
          
            }
        }
        public int Height
        {
            get {
                height= Math.Abs(MouseDown_Point.Y - MouseUp_Point.Y);
                return height;
                    
            }
        }

        public Point Shape_Point
        {
            get {     
               
                shape_point.X = Math.Min(MouseDown_Point.X,MouseUp_Point.X);
                shape_point.Y = Math.Min(MouseDown_Point.Y, MouseUp_Point.Y);       
                return shape_point;            
            }
         
        }
        public Point MouseDown_Point
        {
            get { return mousedown_point; }
            set { mousedown_point = value; }     
         }
        public Point MouseUp_Point
        {
            get { return mouseup_point; }
            set {  mouseup_point = value;}
        }

        public Pen pen;
        /// <summary>
        /// 在graphic对象上绘制图形
        /// </summary>
        /// <param name="g">绘制的graphic对象</param>
        public virtual void Draw(Graphics g)
        {
            throw new System.NotImplementedException();
        }
    }
}
