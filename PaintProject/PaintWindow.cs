using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PaintProject
{
    public partial class PaintWindow : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        int w, h;
        bool moving = false;
        Pen pen;
        public PaintWindow()
        {
            //default color will be black
            InitializeComponent();
            g = canvas_panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 2);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            //when you click on a color the pen color will change to the color of the box
        }

        private void canvas_panel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            canvas_panel.Cursor = Cursors.Cross;
            //when you're using the cursor to draw it will go into cross form
        }

        private void canvas_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                //drawing lines will follow pen/cursor
            }
        }

        private void canvas_panel_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            canvas_panel.Cursor = Cursors.Default;
            //when not using the cursor to draw, cursor will st default
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //e.location();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Application.Restart();
            //clears the windows paint app
        }
    }
        
}
