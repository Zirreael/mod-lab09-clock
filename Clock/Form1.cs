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

namespace Clock
{
    public partial class Form1 : Form
    {
        int x = 0, y = 0;
        int R = 150;
        const double Gr = Math.PI / 180;
        int i = 0;
        int secHAND = 150, minHAND = 130, hrHAND = 105;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Invalidate();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private int[] msCoord(int val, int len)
        {
            int[] coord = new int[2];
            val *= 6;
            if(val >=0 && val <= 180)
            {
                coord[0] = (int)(len * Math.Sin(Gr * val));
                coord[1] = -(int)(len * Math.Cos(Gr * val));
            }
            else
            {
                coord[0] = - (int)(len * -Math.Sin(Gr * val));
                coord[1] = - (int)(len * Math.Cos(Gr * val));
            }
            return coord;
        }
        private int[] hrCoord(int h, int m, int len)
        {
            int[] coord = new int[2];
            int val = (int)((h * 30) + (m * 0.5));
            if (val >= 0 && val <= 180)
            {
                coord[0] = (int)(len * Math.Sin(Gr * val));
                coord[1] = - (int)(len * Math.Cos(Gr * val));
            }
            else
            {
                coord[0] = - (int)(len * -Math.Sin(Gr * val));
                coord[1] = - (int)(len * Math.Cos(Gr * val));
            }
            return coord;
        }
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            int sec = DateTime.Now.Second;
            int min = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            Pen cir_pen = new Pen(Color.Black, 4);
            Pen cir_pen1 = new Pen(Color.Black, 2);
            Pen pen_hour = new Pen(Color.Red, 4f);
            Pen pen_min = new Pen(Color.DarkOrange, 3f);
            Pen pen_sec = new Pen(Color.DarkRed, 2f);
            Graphics g = e.Graphics;
            GraphicsState gs;
            int w = this.Width;
            int h = this.Height;
            g.TranslateTransform(w / 2, h / 2);
            g.DrawEllipse(cir_pen, 0, 0, 5, 5);
            g.DrawEllipse(cir_pen1, -R, -R, 2 * R, 2 * R);
            string[] s = { "XII", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI" };
            Font font = new Font("Tahoma", 15);
            Brush brush = Brushes.Black;
            g.DrawString(s[0], font, brush, -15, -145);
            g.DrawString(s[1], font, brush, 62, -127);
            g.DrawString(s[2], font, brush, 105, -80);
            g.DrawString(s[3], font, brush, 115, -14);
            g.DrawString(s[4], font, brush, 105, 53);
            g.DrawString(s[5], font, brush, 58, 104);
            g.DrawString(s[6], font, brush, -13, 120);
            g.DrawString(s[7], font, brush, -80, 105);
            g.DrawString(s[8], font, brush, -135, 50);
            g.DrawString(s[9], font, brush, -140, -14);
            g.DrawString(s[10], font, brush, -125, -78);
            g.DrawString(s[11], font, brush, -85, -125);
            for (int i = 0; i < 60; i++)
            {
                x = (int)(R * Math.Sin(-i * 360 / 60 * Gr));
                y = (int)(R * Math.Cos(i * 360 / 60 * Gr));
                float x0 = (float)0.75 * x;
                float y0 = (float)0.75 * y;
                float x1 = (float)0.9 * x0;
                float y1 = (float)0.9 * y0;
                if (i % 5 == 0)
                {
                    x1 = (float)0.8 * x0;
                    y1 = (float)0.8 * y0;
                }
                g.DrawLine(cir_pen1, x0, y0, x1, y1);
            }
            int[] coord = new int[2];
            if(timer1.Enabled == true)
            {
                coord = hrCoord(hour % 12, min, hrHAND);
                g.DrawLine(pen_hour, 0, 0, coord[0], coord[1]);
                coord = msCoord(min, minHAND);
                g.DrawLine(pen_min, 0, 0, coord[0], coord[1]);
                coord = msCoord(sec, secHAND);
                g.DrawLine(pen_sec, 0, 0, coord[0], coord[1]);
                i++;
            }
            gs = g.Save();
            coord = hrCoord(hour % 12, min, hrHAND);
            g.DrawLine(pen_hour, 0, 0, coord[0], coord[1]);
            coord = msCoord(min, minHAND);
            g.DrawLine(pen_min, 0, 0, coord[0], coord[1]);
            coord = msCoord(sec, secHAND);
            g.DrawLine(pen_sec, 0, 0, coord[0], coord[1]);
            g.Restore(gs);
        }
    }
}
