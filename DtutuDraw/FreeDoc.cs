using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace DtutuDraw
{
    public class FreeDoc
    {
        private List<Shape> shapes;
        private List<Shape> shapess=new List<Shape>();
        private Graphics g;
        public FreeDoc()
        {
            shapes = new List<Shape>();
        }
        public List<Shape> GetShaess
        {
            get{
            return shapess;
            }
        }
        public List<Shape> Shapes
        {
            get{ return shapes;  }
            
        }
        public Graphics graphic
        {
            get {return g;}
            set {g = value;}
        }
        public void AddShapes()
        {
                shapes.Add(shapess.Last());
                shapess.RemoveAt(shapess.Count - 1);
         
        }
        public void RemoveShape()
        {
            if(Shapes.Count>1)
            { 
                shapess.Add(shapes.Last());
                shapes.RemoveAt(shapes.Count-1);
            }
            else
            {
                try { }
                catch(Exception ex) {throw ex; } 
            }

        }

        public void Draw()
        {
            foreach (Shape s in shapes)
            {
                s.Draw(g);
            }
        }
        public void Remove()
        {

            GetShaess.Clear();
            Shapes.Clear();
           
        } 
   
    }
}
