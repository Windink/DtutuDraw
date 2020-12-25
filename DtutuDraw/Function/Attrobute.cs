using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DtutuDraw
{
    public partial class Attrobute : Form
    {
        public Size Sizes { get; set; }
        public Attrobute(Size size)
        {
            InitializeComponent();
            textBox1.Text = size.Width.ToString();
            textBox2.Text = size.Height.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
             Sizes=  new Size(int.Parse(textBox1.Text),int.Parse(textBox2.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
