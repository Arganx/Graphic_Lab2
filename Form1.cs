using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab2_grafic
{
    public partial class Form1 : Form
    {

        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new Pen(Color.Blue, 1);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        void Circle(float r,int moves)
        {
            float x = 150;
            float y = 150;
            float theta = 0;
            float increase = 2*(float)Math.PI / moves;
            for(int i=0;i< moves;i++)
            {
                g.DrawLine(pen1, x + r * (float)Math.Cos(theta+increase*i), y + r * (float)Math.Sin(theta+increase*i), x+r * (float)Math.Cos(theta+increase*(i+1)),y+r * (float)Math.Sin(theta+increase*(i+1)));
            }
        }

        void Circle(float r, int moves,float increase)
        {
            float x = 150;
            float y = 150;
            float theta = 0;
            for (int i = 0; i < moves; i++)
            {
                g.DrawLine(pen1, x + r * (float)Math.Cos(theta + increase * i), y + r * (float)Math.Sin(theta + increase * i), x + r * (float)Math.Cos(theta + increase * (i + 1)), y + r * (float)Math.Sin(theta + increase * (i + 1)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Circle(100, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Circle(100, 100, (float)4.007);
        }

        void Circle2(float r1,float r2, int moves)
        {
            float x = 150;
            float y = 150;
            float theta = 0;
            float increase = 2 * (float)Math.PI / moves;
            for (int i = 0; i < moves; i++)
            {
                g.DrawLine(pen1, x + r1 * (float)Math.Cos(theta + increase * i), y + r2 * (float)Math.Sin(theta + increase * i), x + r1 * (float)Math.Cos(theta + increase * (i + 1)), y + r2 * (float)Math.Sin(theta + increase * (i + 1)));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            float tmp;
            float r1 = 50;
            float r2 = 25;
            for(int i=0;i<3;i++)
            {
                Circle2(r1, r2, 100);
                Circle2(r2, r1, 100);
                tmp = r1 - r2;
                r1 += tmp;
                r2 += tmp;
            }
            Circle(r1-25, 100);
        }

        void Spiral(float max_r,float segments,float moves,float angle)
        {
            float x = 150;
            float y = 150;
            float theta = angle;
            float actual_r_increas;
            float increase = 2 * (float)Math.PI / moves;
            float all = segments * moves;
            float r_increase = max_r / all;
            for(int i=0;i< all;i++)
            {
                actual_r_increas = r_increase * i;
                g.DrawLine(pen1, x + actual_r_increas * (float)Math.Cos(theta + increase * i), y + actual_r_increas * (float)Math.Sin(theta + increase * i), x + actual_r_increas * (float)Math.Cos(theta + increase * (i + 1)), y + actual_r_increas * (float)Math.Sin(theta + increase * (i + 1)));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Spiral(100, 6, 100,0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            float angle=0;
            for(int i=0;i<4;i++)
            {
                angle += (float)67.5;
                Spiral(100, 3, 100,angle);
            }
            Circle(100, 100);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            float r = 100;
            g.Clear(Color.White);
            float x = 200;
            float y = 200;
            float theta = 0;
            int steps = 20;
            float increase = 2 * (float)Math.PI / steps;
            for (int i = 0; i < steps; i++)
            {
                g.DrawLine(pen1, x + r * (float)Math.Cos(theta + increase * i), y + r * (float)Math.Sin(theta + increase * i), x + r * (float)Math.Cos(theta + increase * (i + 1)), y + r * (float)Math.Sin(theta + increase * (i + 1)));
                for (int j = 0; j < steps; j++)
                {
                    g.DrawLine(pen1, x + r * (float)Math.Cos(theta + increase * i), y + r * (float)Math.Sin(theta + increase * i), x + r * (float)Math.Cos(theta + increase * (j)), y + r * (float)Math.Sin(theta + increase * (j)));
                }
            }

        }

        void mySquere(float size,float ratio)
        {
            float x = 100;
            float y = 100;
            float rmu = 1 - ratio;
            PointF[] T = { new PointF(x, y), new PointF(x + size, y), new PointF(x + size, y + size), new PointF(x, y + size) };
            PointF[] N = { new PointF(x, y), new PointF(x + size, y), new PointF(x + size, y + size), new PointF(x, y + size) };
            for (int j = 0; j < 21; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    g.DrawLine(pen1, T[i], T[(i + 1) % 4]);
                    N[i].X = rmu * T[i].X + ratio * T[(i+1)%4].X;
                    N[i].Y = rmu * T[i].Y + ratio * T[(i+1)%4].Y;
                }
                for(int i=0;i<4;i++)
                {
                    T[i] = N[i];
                }
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            mySquere(200,(float)0.1);
        }
    }
}
