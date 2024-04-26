using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadowTest
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image BMP = Image.FromFile("D:\\Olles\\TimeLine\\TimeLine\\Images\\Tiles\\Bases\\Suelo2.gif");
            Bitmap Lienzo = new Bitmap(BMP.Width * 2, BMP.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Color p = Color.FromArgb(0, 0, 0, 0);
            SolidBrush brush = new SolidBrush(p);

            using (Graphics g = Graphics.FromImage(Lienzo))
            {
                g.DrawImage(BMP, new Point(0, 0));
                g.DrawImage(BMP, new Point(BMP.Width, 0));
                g.FillRectangle(brush, new Rectangle(0, 0, BMP.Width, BMP.Height));
            }
            pictureBox1.Image = Lienzo;
        }
    }
}
