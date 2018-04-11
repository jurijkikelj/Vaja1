using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fraktali
{
    public partial class Form1 : Form
    {
        public double x;
        public double y;
        public double a;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*
            Graphics g = e.Graphics;
            x = 0.01; y = 0.1; a = 0;     
            int n = 5;

            double korak = 1 / Math.Pow(3, n);

            Koch(n, korak, g);
            */

            Graphics g = e.Graphics;
            int n = 3;
            Tree(n, 0.5, 0, Math.PI / 2, 0.3, g);

        }

        private int umeriX(double xr)
        {
            return (int)(this.Width * xr);
        }

        private int umeriY(double yr)
        {
            return (int)(this.Height-this.Width * yr);
        }

        private void Premik(double d, Graphics g)
        {
            double stariX = x;
            double stariY = y;

            x = stariX + d*Math.Cos(a * Math.PI / 180);
            y = stariY + d*Math.Sin(a * Math.PI / 180);

            int x1 = umeriX(stariX);
            int y1 = umeriY(stariY);

            int x2 = umeriX(x);
            int y2 = umeriY(y);

            g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
        }

        private void ObratLevo(double kot)
        {
            a += kot;
        }

        private void Koch(int n, double korak, Graphics g)
        {
            if (n == 0)
            {
                Premik(korak, g);
                return;
            }
            Koch(n - 1, korak, g);
            ObratLevo(60);
            Koch(n - 1, korak, g);
            ObratLevo(-120);
            Koch(n - 1, korak, g);
            ObratLevo(60);
            Koch(n - 1, korak, g);
        }

        private void Tree(int n, double x, double y, double a, double dolžinaVeje, Graphics g)
        {
            double kotNagnjenosti = 15;
            double medvejami = 37 * Math.PI / 100;
            double pojemek = 0.65;
            double cx = x + Math.Cos(a) * dolžinaVeje;
            double cy = y + Math.Sin(a) * dolžinaVeje;
            int x1 = umeriX(x);
            int y1 = umeriY(y);
            int x2 = umeriX(cx);
            int y2 = umeriY(cy);
            g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);

            if (n==0)
            {
                return;
            }
            Tree(n - 1, cx, cy, kotNagnjenosti - medvejami, dolžinaVeje*pojemek, g);
            Tree(n - 1, cx, cy, kotNagnjenosti +a+ medvejami, dolžinaVeje * pojemek, g);
            Tree(n - 1, cx, cy, a+kotNagnjenosti, dolžinaVeje *(1-pojemek), g);
        }
    }
}
