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
        bool moving = false;
        Pen pen;
        public PaintWindow()
        {
            InitializeComponent();
            g = canvas_panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 2); //Sets default pen color as black
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e) //Changes color of pen to color of box clicked
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void canvas_panel_MouseDown(object sender, MouseEventArgs e) //Changes the appearance of the cursor to a cross when drawing
        {
            moving = true;
            x = e.X;
            y = e.Y;
            canvas_panel.Cursor = Cursors.Cross;
        }

        private void canvas_panel_MouseMove(object sender, MouseEventArgs e) //Draws lines that follow the mouse cursor
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void canvas_panel_MouseUp(object sender, MouseEventArgs e) //When cursor not being used to draw, it will reset to default position
        {
            moving = false;
            x = -1;
            y = -1;
            canvas_panel.Cursor = Cursors.Default;
        }

        private void clearButton_Click(object sender, EventArgs e) //Restarts application; clears canvas
        {
            Application.Restart();
        }

        private void rectButton_Click(object sender, EventArgs e) {
            g.DrawRectangle(pen, 10, 10, 50, 50);
        }
    }  
}
