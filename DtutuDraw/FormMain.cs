using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace DtutuDraw
{

    public partial class FormMain : Form
    {
        #region 枚举图形
        public enum Shapes:int
        {
            shapes,//    共有
            Rectangles,//    矩形
            Line,//    直线
            Ellipse,//    椭圆
            Lines,//    铅笔
            Rubber,//    橡皮
            DrawWord, //    插入文字
            Circle,//    圆
            Heart,//  心
            Pentagon,// 五边形
            Hexagon,//六边形
            Triangle,//三角形
            Fivestar,//变化图形
            SelectMove,//选择移动
            Change//画板改变
        }
        #endregion

        #region 变量
        private FreeDoc mydraw;
        private Backgrounds backgrounds = new Backgrounds();
        private Shapes state = Shapes.shapes;
        private Shapes states;
        private int widthh = 1;
        private DashStyle liness = DashStyle.Solid;
        private Color colo=Color.Black;
        private  Line l;             //2
        private Lines bi;           //4
        private Rectangles r;        //1
        private Ellipse c; //3,7
        private Circle circle;
        private Dstring d;   //6
        private bool mouseIsDown;
        private FiveStar fiveStar;
        private Hexagon p;//9
        private Triangle t;
        private TextBox text=new TextBox();
        private int flag1=0;
        private int flag = 0;
        private Font font=new Font("宋体",10);
        private Arcnothing a;//8
        private Pentagon pe;//10
        private ToolStripButton earname =new ToolStripButton();//
        private Bitmap bit;
        private Move move;
        private Lagrer lagrer = new Lagrer();
        private PictureBox pictureBox;
        private Bitmap bitmaps;
        private Graphics graphicses;
        #endregion

        #region 构造函数，窗体初始函数
        public FormMain()
        {
            InitializeComponent();   
        }
        public FreeDoc MyDraw{ get {return mydraw;}}
        private void FormMain_Load(object sender, EventArgs e)
        {
            mydraw = new FreeDoc();
            bit = new Bitmap(pictureBox1.Width,pictureBox1.Height);       
            mydraw.graphic = Graphics.FromImage(bit);
            backgrounds.Initiaimage(pictureBox1);
            mydraw.Shapes.Add(backgrounds);
            panel2.Size = new Size(Screen.PrimaryScreen.Bounds.Width-panel2.Location.X-2, Screen.PrimaryScreen.Bounds.Height-panel2.Location.Y-70);
            bitmaps = new Bitmap(panel2.Width, panel2.Height);
            graphicses = Graphics.FromImage(bitmaps);
            //mydraw.graphic.Clear(pictureBox1.BackColor);           
            //编辑ToolStripMenuItem.DropDownItems[2].Enabled = false;
            //编辑ToolStripMenuItem.DropDownItems[1].Enabled = false;
        }
        #endregion

        #region 颜色，按钮
        private void toolStripButton1_Click(object sender, EventArgs e) 
        {
            earname.Checked = false;
           Button1.Checked = true;
            earname = Button1;
            state = Shapes.Rectangles; 
            this.Cursor =Cursors.Cross; 
        }
       
        private void toolStripButton1_Click_1(object sender, EventArgs e)   
        {
            earname.Checked = false;
            toolStripButton1.Checked = true;
            earname = toolStripButton1;
            state = Shapes.Line; 
            this.Cursor = System.Windows.Forms.Cursors.Cross; 
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            earname.Checked = false;
            toolStripButton2.Checked = true;
            earname = toolStripButton2;
            state = Shapes.shapes; 
            this.Cursor = System.Windows.Forms.Cursors.Arrow; 
        }
        private void toolStripButton3_Click(object sender, EventArgs e)   
        {
            earname.Checked = false;
            toolStripButton3.Checked = true;
            earname =toolStripButton3;
            state = Shapes.Ellipse;
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            earname.Checked = false;
            toolStripButton5.Checked = true;
            earname = toolStripButton5;
            state = Shapes.Rubber;
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void toolStripButton6_Click(object sender, EventArgs e) 
        {
            earname.Checked = false;
            toolStripButton6.Checked = true;
            earname = toolStripButton6;
            state = Shapes.Lines; 
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }   
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            earname.Checked = false;
            toolStripButton12.Checked = true;
            earname = toolStripButton12;
            state = Shapes.Circle;        
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            earname.Checked = false;
            toolStripButton8.Checked = true;
            earname = toolStripButton8;
            state = Shapes.DrawWord; 
        }
        private void toolStripButton10_Click(object sender, EventArgs e) 
        {
            earname.Checked = false;
            toolStripButton10.Checked = true;
            earname = toolStripButton10;
            state = Shapes.Heart;
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            earname.Checked = false;
            toolStripButton11.Checked = true;
            earname = toolStripButton11;
            state = Shapes.Pentagon;
        }  
          private void toolStripButton13_Click(object sender, EventArgs e)
          {
              earname.Checked = false;
              toolStripButton13.Checked = true;
              earname = toolStripButton13;
              state = Shapes.Hexagon;
          }
        private void toolStripButton14_Click(object sender, EventArgs e) 
        {
            earname.Checked = false;
            toolStripButton14.Checked = true;
            earname = toolStripButton14;
            state=Shapes.Triangle; 
        }
        private void toolStripButton16_Click(object sender, EventArgs e)
        {
             earname.Checked = false;
            toolStripButton16.Checked = true;
            earname = toolStripButton16;
            state = Shapes.Fivestar;
        }
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            earname.Checked = false;
            toolStripButton15.Checked = true;
            earname = toolStripButton15;
            state = Shapes.SelectMove;
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)   {widthh = 2;}
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e) { widthh = 1; }
        private void toolStripButton4_Click(object sender, EventArgs e) { }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)   { widthh = 3;}
        private void toolStripMenuItem5_Click(object sender, EventArgs e)   {widthh = 4;}
        private void toolStripMenuItem6_Click(object sender, EventArgs e)   { widthh = 5; }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)   {widthh = 6;}
        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)  { colo = Color.Red; }
        private void 蓝色ToolStripMenuItem_Click(object sender, EventArgs e)  {colo = Color.Blue; }
        private void 黑色ToolStripMenuItem_Click(object sender, EventArgs e)  {colo = Color.Black;}
        private void 白色ToolStripMenuItem_Click(object sender, EventArgs e)  { colo = Color.White; }
        private void 绿色ToolStripMenuItem_Click(object sender, EventArgs e)  {colo = Color.Green;}
        private void 灰色ToolStripMenuItem_Click(object sender, EventArgs e)  {colo = Color.Gray; }
        private void 黄色ToolStripMenuItem_Click(object sender, EventArgs e)  { colo = Color.Yellow;}
        private void 直线ToolStripMenuItem_Click(object sender, EventArgs e) { liness = DashStyle.Solid; }
        private void 虚线ToolStripMenuItem_Click(object sender, EventArgs e) { liness = DashStyle.Dash; }
        private void 点线ToolStripMenuItem_Click(object sender, EventArgs e) { liness = DashStyle.Dot; }
        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colo = colorDialog1.Color;
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;
            }
        }

        /// <summary>
        /// 画板属性窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attrobute attrobute = new Attrobute(pictureBox1.Size);
            //  attrobute.Show();
            // attrobute.ShowDialog();
            if (attrobute.ShowDialog() == DialogResult.OK)
            {
                if (attrobute.Sizes.Height == 0 || attrobute.Sizes.Width == 0)
                {
                    MessageBox.Show("文本框只可以输入数字");
                    attrobute.ShowDialog();
                }
                else
                { 
                pictureBox1.Size = attrobute.Sizes;
                panel1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y + pictureBox1.Height);
               }
            }
        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.YesNoCancel;
            DialogResult dr = MessageBox.Show("确定是否要保存图像吗?", "保存", messButton);
            if (dr == DialogResult.Yes)
            {
                this.保存ToolStripMenuItem_Click(sender,e);
                earname.Checked = false;
                mydraw.Remove();
                mydraw.graphic.Clear(pictureBox1.BackColor);
                state = Shapes.shapes;
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.pictureBox1.Refresh();
                backgrounds.Initiaimage(pictureBox1);
                mydraw.Shapes.Add(backgrounds);
            }
            else if(dr==DialogResult.No)
            {
                earname.Checked = false;
                mydraw.Remove();
                mydraw.graphic.Clear(pictureBox1.BackColor);
                state = Shapes.shapes;
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.pictureBox1.Refresh();
                backgrounds.Initiaimage(pictureBox1);
                mydraw.Shapes.Add(backgrounds);
            }
            else
            {
                flag1 = 1;
                //取消
            }
        }
        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            states = state;
            try {  mydraw.RemoveShape();}
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            mydraw.graphic.Clear(pictureBox1.BackColor);
            state = Shapes.shapes;
            this.pictureBox1.Refresh();
            mydraw.Draw();
            this.pictureBox1.Refresh();
            state = states;
        }
        private void 重复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            states = state;
            try { mydraw.AddShapes();}
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            mydraw.graphic.Clear(pictureBox1.BackColor);
            state = Shapes.shapes;
            this.pictureBox1.Refresh();
            mydraw.Draw();
            this.pictureBox1.Refresh();
            state = states;

        }

        #endregion

        #region 打开保存
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.清除ToolStripMenuItem_Click(sender, e); 
            if(flag1==1)
            {

            }
            else
            {
                try
                { 
                Open open = new Open();
                open.Functions();
                 pictureBox1.Size = open.Bitmap.Size;
                 panel1.Location = new Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y + pictureBox1.Height);
                 bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                 mydraw.graphic = Graphics.FromImage(bit);
                 backgrounds.Images = open.Bitmap;
                 mydraw.Shapes.Insert(0, backgrounds);
                 backgrounds.Draw(mydraw.graphic);
                 pictureBox1.Refresh();
                 }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saves saves = new Saves();
            saves.PictureBox = pictureBox1;
            saves.Functions();
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }
        #endregion

        #region 鼠标事件
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
         
            switch (state)
            {
                case Shapes.Rectangles:
                    r = new Rectangles(colo, widthh);
                    r.pen.DashStyle = liness;
                    r.MouseDown_Point=new Point(e.X,e.Y);
                    mouseIsDown = true;
                    break;

                case Shapes.Line:

                    l = new Line(colo, widthh, liness);
                    l.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Ellipse:
                    c = new Ellipse(colo, widthh);
                    c.pen.DashStyle = liness;
                    c.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Lines:
                    bi = new Lines(colo, widthh);
                    bi.points[bi.points.Length - 1] = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Rubber:
                    bi = new Lines(Color.White,  4* widthh);
                    bi.points[bi.points.Length - 1] = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.DrawWord:
                    if (flag1 == 0)
                    {
                        text.Location = new Point(e.X + pictureBox1.Location.X, e.Y + pictureBox1.Location.Y);
                        text.Size = new Size(78, 20);
                        pictureBox1.Controls.Add(text);
                        text.Font = fontDialog1.Font;
                        text.BringToFront();
                        text.TextChanged += textBox1_TextChanged;
                        flag1 = 1;
                        break;
                    }
                    if (flag1 == 1)
                    {
                        d = new Dstring
                        {
                            MouseDown_Point = new Point(text.Location.X - pictureBox1.Location.X, text.Location.Y - pictureBox1.Location.Y),
                            S = text.Text,
                            Brush = new SolidBrush(colo),
                            Font = font
                        };
                        text.TextChanged -= textBox1_TextChanged;
                        pictureBox1.Controls.Remove(text);
                        flag1 = 2;
                        this.pictureBox1.Refresh();
                        mouseIsDown = true;
                    }
                    break;
                case Shapes.Circle:
                    circle = new Circle(colo, widthh);
                    circle.pen.DashStyle = liness;
                    circle.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Heart:
                    a = new Arcnothing(colo, widthh);
                    a.pen.DashStyle = liness;
                    a.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Pentagon:
                    p = new Hexagon(colo, widthh);
                    p.pen.DashStyle = liness;
                    p.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Hexagon:
                    pe = new Pentagon(colo, widthh);
                    pe.pen.DashStyle = liness;
                    pe.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Triangle:
                    t = new Triangle(colo, widthh);
                    t.pen.DashStyle = liness;
                    t.Points[0] = new Point(e.X, e.Y);
                    t.Points[1] = new Point(e.X, e.Y);
                    t.Points[2] = new Point(t.Points[0].X, t.Points[1].Y);
                    mouseIsDown = true;
                    break;
                case Shapes.Fivestar:
                    fiveStar = new FiveStar(colo, widthh);
                    fiveStar.pen.DashStyle = liness;
                    fiveStar.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                case Shapes.SelectMove:
                    if(flag==1)
                    {
                    try
                    {
                        flag1 = 1;
                        pictureBox.Refresh();
                        pictureBox1.Controls.Remove(pictureBox);
                        move.Draw(mydraw.graphic);
                        mydraw.Shapes.Add(move);
                        pictureBox.MouseDown -= pictureBox_MouseDown;
                        pictureBox.MouseMove -= pictureBox_MouseMove;
                        pictureBox.MouseUp -= pictureBox_MouseUp;
                        pictureBox.Paint -= pictureBox_Paint;
                        MouseClick -= FormMain_MouseClick;
                        toolStrip1.ItemClicked -= toolStrip1_ItemClicked;
                    }
                    catch { }
                    finally { flag = 0;flag1 = 0; }
                    }
                    move = new Move(Color.Black, 1);
                    move.MouseDown_Point = new Point(e.X, e.Y);
                    mouseIsDown = true;
                    break;
                default: break;
            }
        }
        
        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
             label1.Text = "X="+e.X+",Y="+e.Y;
            label2.Text = " ";
            if (mouseIsDown)
            {
                switch (state)
                {
                    case Shapes.Rectangles:
                        r.MouseUp_Point = new Point(e.X, e.Y);
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Line:
                        l.MouseUp_Point = new Point(e.X, e.Y);
                        this.pictureBox1.Refresh(); 
                        break;
                    case Shapes.Ellipse:
                        c.MouseUp_Point = new Point(e.X, e.Y);;
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Lines:
                    case Shapes.Rubber:
                      
                        Array.Resize(ref bi.points, bi.points.Length + 1);
                        bi.points[bi.points.Length - 1] = new Point(e.X, e.Y);
                        if ( bi.points.Length > 2)
                        {
                            this.pictureBox1.Refresh();
                            bi.Draw(mydraw.graphic);
                            mouseIsDown = true; 
                        }
                        
                        break;
                    case Shapes.DrawWord:
                        break;
                    case Shapes.Circle:
                        circle.MouseUp_Point = new Point(e.X, e.Y);
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Heart:
                        a.MouseUp_Point= new Point(e.X, e.Y);
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Pentagon:
                        p.MouseUp_Point = new Point(e.X, e.Y);
                        p.AddPoint();
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Hexagon:
                        pe.MouseUp_Point= new Point(e.X, e.Y);
                        pe.AddPoint();
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Triangle:
                        t.Points[1] = new Point(e.X, e.Y);
                        t.Points[2] = new Point(t.Points[0].X, t.Points[1].Y);
                        t.Points[3] = t.Points[0];
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.Fivestar:
                        fiveStar.MouseUp_Point = new Point(e.X, e.Y);
                        fiveStar.AddPoint();
                        this.pictureBox1.Refresh();
                        break;
                    case Shapes.SelectMove:;
                        move.MouseUp_Point = new Point(e.X, e.Y);
                        this.pictureBox1.Refresh();
                        break;
                    default: break;
                }
            }
        }
        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {  
            mouseIsDown = false;  
            switch (state)
            {
                case Shapes.Rectangles:
                
                    mydraw.Shapes.Add(r);
                    r.Draw(mydraw.graphic);
                    break;
                case Shapes.Line:
                    mydraw.Shapes.Add(l);
                    l.Draw(mydraw.graphic);
                    break;
                case Shapes.Ellipse:
                    mydraw.Shapes.Add(c);
                    c.Draw(mydraw.graphic);
                    break;
                case Shapes.Circle:
                    mydraw.Shapes.Add(circle);
                    circle.Draw(mydraw.graphic);
                    break;
                case Shapes.Lines:
                case Shapes.Rubber:
                    if(bi.points.Length>=2)
                    {
                    mydraw.Shapes.Add(bi);
                    bi.Draw(mydraw.graphic);
                    }
                    break;
                case Shapes.DrawWord:
                    if (flag1 == 2)
                    {
                        mydraw.Shapes.Add(d);
                        d.Draw(mydraw.graphic);
                        flag1 = 0;
                        text.Text = null;
                    }
                    break;
               
                case Shapes.Heart:
                    mydraw.Shapes.Add(a);
                    a.Draw(mydraw.graphic);
                    break;
                case Shapes.Pentagon:
                    mydraw.Shapes.Add(p);
                    p.Draw(mydraw.graphic);
                    break;
                case Shapes.Hexagon:
                    mydraw.Shapes.Add(pe);
                    pe.Draw(mydraw.graphic);
                    break;
                case Shapes.Fivestar:
                    mydraw.Shapes.Add(fiveStar);
                    fiveStar.Draw(mydraw.graphic);
                    break;
                case Shapes.Triangle:
                    mydraw.Shapes.Add(t);
                    t.Draw(mydraw.graphic);
                    break;
                case Shapes.SelectMove:
                    if (move.MouseDown_Point.X.Equals(move.MouseUp_Point.X)||move.MouseDown_Point.Y.Equals(move.MouseUp_Point.Y))
                        break;
                    this.pictureBox=  move.InitilaPicture(pictureBox1);
                    pictureBox1.Controls.Add(pictureBox);
                    move.DrawWhile(mydraw.graphic);
                    flag = 1;
                    pictureBox1.Refresh();
                    pictureBox.MouseDown += pictureBox_MouseDown;
                    pictureBox.MouseMove += pictureBox_MouseMove;
                    pictureBox.MouseUp += pictureBox_MouseUp;
                    pictureBox.Paint += pictureBox_Paint;
                    toolStrip1.ItemClicked += toolStrip1_ItemClicked;
                    MouseClick += FormMain_MouseClick;
                    pictureBox.BringToFront();
                    flag1 = 0;
                    pictureBox.Refresh(); 
                    break;
                default: break;
            }
        }
        
       
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        
            Graphics g = e.Graphics;
            g.DrawImage(bit, 0, 0);
            Pen pen=new Pen(colo,widthh);
            pen.DashStyle = liness;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            switch (state)
            {

                case Shapes.Rectangles: 
                    g.DrawRectangle(pen, r.Shape_Point.X, r.Shape_Point.Y, r.Width, r.Height);
                    break;
                case Shapes.Line:
                    g.DrawLine(pen, l.MouseDown_Point, l.MouseUp_Point);
                    break; 
                case Shapes.Circle:
                    g.DrawEllipse(pen, circle.MouseDown_Point.X - circle.Radius, circle.MouseDown_Point.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
                    break;
                case Shapes.Ellipse:
                   g.DrawEllipse(pen, c.Shape_Point.X, c.Shape_Point.Y,c.Width,c.Height);
                    break;
                case Shapes.Lines:
                    try { 
                    if (bi.points.Length < 2)
                        break;
                    g.DrawLines(new Pen(Color.Transparent,  widthh), bi.points);
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                    break;
                case Shapes.Rubber:
                    if (bi.points.Length < 2)
                        break;
                    g.DrawLines(new Pen(pictureBox1.BackColor, 4 * widthh), bi.points);
                    break;
                case Shapes.DrawWord:
                    if (text.Text.Length <3 )
                        break;
                    if(flag1==2)
                    {
                        try
                        {
                            g.DrawString(d.S, d.Font, d.Brush, d.MouseDown_Point);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case Shapes.Heart:
                    if (a.Width < 10 || a.Height < 10)
                        break;

                    g.DrawArc(pen, a.Shape_Point.X, a.Shape_Point.Y, a.Width / 2, a.Height / 2, a.StartAngle, a.SweepAngle);
                   g.DrawArc(pen, (a.MouseDown_Point.X + a.MouseUp_Point.X) / 2f, a.Shape_Point.Y, a.Width / 2, a.Height / 2, a.StartAngle, a.SweepAngle);
                    g.DrawBezier(pen, new Point(a.Shape_Point.X, a.Shape_Point.Y + a.Height / 4), new Point(a.Shape_Point.X + a.Width / 10, a.Shape_Point.Y + a.Height / 4 * 3), new Point(a.Shape_Point.X + a.Width / 10 * 4, a.Shape_Point.Y + a.Height ), new Point(a.Width / 2 + a.Shape_Point.X, a.Shape_Point.Y + a.Height ));
                    g.DrawBezier(pen, new Point(a.Shape_Point.X + a.Width, a.Shape_Point.Y + a.Height / 4), 
                        new Point(a.Shape_Point.X + a.Width - a.Width / 10, a.Shape_Point.Y + a.Height / 4 * 3), 
                        new Point(a.Shape_Point.X + a.Width - a.Width / 10 * 4, a.Shape_Point.Y + a.Height), 
                        new Point(a.Width / 2 + a.Shape_Point.X, a.Shape_Point.Y+a.Height));
                    break;
                case Shapes.Pentagon:
                    try { 
                    g.DrawPolygon(pen,p.Points);}
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Shapes.Hexagon:
                    try { 
                    g.DrawPolygon(pen, pe.Points);
                        }
                     catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case Shapes.Fivestar:
                    g.TranslateTransform(fiveStar.Shape_Point.X +fiveStar.Width / 2,fiveStar.Shape_Point.Y + fiveStar.Height / 2);
                    for (int i = 0; i < 5; i++)
                    {
                        g.RotateTransform(72f);
                        g.DrawLines(pen,fiveStar.Points);
                    }
                    g.TranslateTransform(-(fiveStar.Shape_Point.X + fiveStar.Width / 2), -(fiveStar.Shape_Point.Y + fiveStar.Height / 2));
                    break;
                case Shapes.Triangle:
                    g.DrawLines(pen, t.Points);
                    break;
                case Shapes.SelectMove:
                    if (move == null)
                        break;
                    if(flag==0)
                    {
                        pen.Color = Color.Black;
                        pen.Width = 1;
                        pen.DashStyle = DashStyle.Dash;
                        g.DrawRectangle(pen, move.Shape_Point.X-2 , move.Shape_Point.Y-2 , move.Width+2, move.Height+2);
                    }
                    if(flag==1)
                    { 
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.Clear(Color.White);
                    g.DrawImage(bitmap, new Rectangle(move.Shape_Point.X , move.Shape_Point.Y , move.Width, move.Height),
                    new Rectangle(0, 0, bitmap.Width ,bitmap.Height), GraphicsUnit.Pixel);  
                    }
                    break;
                case Shapes.Change:
                    pen.DashStyle = DashStyle.Dash;
                    pen.Width = 1;
                    g.DrawRectangle(pen, 0, 0, panel1.Location.X + (panel1.Width / 2), panel1.Location.Y + (panel1.Height / 2));
                    break;
                default:break;

            }
          
       }



        #endregion


        #region 移动的点击事件
        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                flag1 = 1;
                pictureBox.Refresh();
                //flag1 = 0;
                pictureBox1.Controls.Remove(pictureBox);
                move.Draw(mydraw.graphic);
                mydraw.Shapes.Add(move);
                pictureBox.MouseDown -= pictureBox_MouseDown;
                pictureBox.MouseMove -= pictureBox_MouseMove;
                pictureBox.MouseUp -= pictureBox_MouseUp;
                pictureBox.Paint -= pictureBox_Paint;
                MouseClick -= FormMain_MouseClick;
                toolStrip1.ItemClicked -= toolStrip1_ItemClicked;
                flag = 0;
                flag1 = 0;
                //pictureBox1.Refresh();
            }
            catch
            {

            }
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                flag1 = 1;
                pictureBox.Refresh();
                pictureBox1.Controls.Remove(pictureBox);
                move.Draw(mydraw.graphic);
                mydraw.Shapes.Add(move);
                pictureBox.MouseDown -= pictureBox_MouseDown;
                pictureBox.MouseMove -= pictureBox_MouseMove;
                pictureBox.MouseUp -= pictureBox_MouseUp;
                pictureBox.Paint -= pictureBox_Paint;
                MouseClick -= FormMain_MouseClick;
                toolStrip1.ItemClicked -= toolStrip1_ItemClicked;
                state = Shapes.shapes;
                pictureBox1.Refresh();
                flag = 0;
                flag1 = 0;
            }
            catch
            {

            }
        }
        #endregion

        #region picture的移动方法
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            move.ShapePoint_Start = new Point(e.X,e.Y);
            mouseIsDown = true;
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseIsDown)
            {
                flag1 = 1;
                pictureBox.Refresh();
                move.ShapePoint_End = new Point(e.X, e.Y);
                pictureBox.Location = new Point(pictureBox.Location.X + (move.ShapePoint_End.X - move.ShapePoint_Start.X), pictureBox.Location.Y + (move.ShapePoint_End.Y - move.ShapePoint_Start.Y));
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            flag1 = 0;
            pictureBox.Refresh();
            mouseIsDown = false;
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(flag1==0)
            { 
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.Dash;
            e.Graphics.DrawRectangle(pen, pictureBox.DisplayRectangle);
            }
        }



        #endregion

        /// <summary>
        /// 窗体坐标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = "X=" + e.X + ",Y=" + e.Y;
            label1.Text = " ";
        }

        #region 画板增减 Panel1移动事件
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //bitmaps = new Bitmap(panel2.Width, panel2.Height);
            //graphicses = Graphics.FromImage(bitmaps);
            lagrer.GetPoint1 = new Point(e.X, e.Y);
            states = state;
            state = Shapes.Change;
            mouseIsDown = true;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseIsDown)
            {
                lagrer.GetPoint = new Point(e.X, e.Y);
                flag1 = 1;
                panel2.Refresh();
                pictureBox1.Refresh();
                panel1.Location = new Point(panel1.Location.X + (lagrer.GetPoint.X - lagrer.GetPoint1.X), panel1.Location.Y + (lagrer.GetPoint.Y - lagrer.GetPoint1.Y)); 
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag1 = 0;
            panel2.Refresh();
            state = states;
            pictureBox1.Refresh();
            mouseIsDown = false;
            //panel1.Location = new Point(panel1.Location.X + (lagrer.GetPoint.X - lagrer.GetPoint1.X), panel1.Location.Y + (lagrer.GetPoint.Y - lagrer.GetPoint1.Y));
            pictureBox1.Width = panel1.Location.X - pictureBox1.Location.X;
            pictureBox1.Height = panel1.Location.Y - pictureBox1.Location.Y;
            bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            mydraw.graphic = Graphics.FromImage(bit);
            mydraw.Draw();
        }
        #endregion

        #region 字板自动增加事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //}
            if (text.Text.Length*text.Font.Size >= 117)
               text.Width += (int)text.Font.Size-3;
            
            //MessageBox.Show(+" "+text.Text.Length+" "+ text.Width+" "+text.Font.Size.ToString());
        }
        #endregion

        #region panel2移动事件
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = "X=" + e.X + ",Y=" + e.Y;
            label1.Text = " ";
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            // graphics.DrawImage(bitmaps,0,0);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            Pen pen = new Pen(Color.Black);
           
            pen.DashStyle =DashStyle.Dash;
            if (flag1==1)
            {
                graphics.DrawRectangle(pen, 0, 0, panel1.Location.X + (panel1.Width / 2)+1, panel1.Location.Y + (panel1.Height / 2)+1);
            }
        }

        #endregion

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }




}



















































