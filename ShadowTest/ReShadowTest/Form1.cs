using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace ReShadowTest
{
    public partial class Form1 : Form
    {
        public const int SCREEN_TILES_SIZE = 7; //Numero de tiles antes y numero de tiles despuñes del PJ de E a O y de N a S. Cuadrado centrado.        
        public const int TILE_SIZE = 28; //Tamaño en pixels de una tile
        private const int SCREEN_PIXEL_SIZE = (SCREEN_TILES_SIZE * TILE_SIZE * 2) + TILE_SIZE;

        public static class GODmESUREITOR
        {
            public static DateTime a, b;
            private static DateTime lastUse = DateTime.Now;
            private static int count = 0;
            private static int last_count = 0;

            public static void StartMesure()
            {
                a = DateTime.Now;
                if (lastUse.Second != a.Second)
                {
                    last_count = count;
                    count = 1;
                }
                else
                {
                    count++;
                }
                lastUse = a;
            }

            public static void StopMesure()
            {
                b = DateTime.Now;
                long elapsedTicks = b.Ticks - a.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                //Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100);
                //Console.WriteLine("   {0:N0} ticks", elapsedTicks);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GODmESUREITOR.StartMesure();
            shadowMask(5, 5, 200, 5, 0.5f);
            shadowMask2(5, 5, 200, 5, 0.5f);
            GODmESUREITOR.StopMesure();
        }

        private int YfX(int fixedX, double m)
        {
            return (int)Math.Floor((double)fixedX * m);
        }

        private int XfY(int fixedY, double m)
        {
            return (int)Math.Floor((double)fixedY / m);
        }

        private void shadowMask(int ElementX, int ElementY, int LStrength, int LTiles, double Factor)
        {
            int refX = ElementX - SCREEN_TILES_SIZE;
            int refY = ElementY - SCREEN_TILES_SIZE;

            int size = TILE_SIZE;
            Bitmap PixelBase = new Bitmap(SCREEN_TILES_SIZE * 2 + 1, SCREEN_TILES_SIZE * 2 + 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Bitmap PixelBase = new Bitmap((SCREEN_TILES_SIZE * 2 + 1) * size, (SCREEN_TILES_SIZE * 2 + 1) * size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Bitmap Lienzo = new Bitmap(SCREEN_PIXEL_SIZE, SCREEN_PIXEL_SIZE, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            /*Color p = Color.FromArgb(255, 0, 0, 0);
            SolidBrush brush = new SolidBrush(p);
            Pen lapiz = new Pen(brush, 2.0f);*/


            List<DBTile> CutviewTiles = DBAccess.GetScreenTiles(ElementX - SCREEN_TILES_SIZE, ElementY - SCREEN_TILES_SIZE, ElementX + SCREEN_TILES_SIZE, ElementY + SCREEN_TILES_SIZE);

            using (Graphics g = Graphics.FromImage(PixelBase))
            {
                foreach (DBTile a in CutviewTiles)
                {
                    //Que no sean bordes
                    if ((a.SX(refX) != 0) && (a.SY(refY) != 0) && 
                        (a.SX(refX) != SCREEN_TILES_SIZE * 2) && (a.SY(refY) != SCREEN_TILES_SIZE * 2) &&
                        (a.CX(ElementX) != 0) && (a.CY(ElementY) != 0)) //ni rectas
                    {
                        double pendiente = (double)a.CY(ElementY) / (double)a.CX(ElementX);
                        if (a.WX <= ElementX)
                        {
                            if (a.WY < ElementY)
                            {
                                //Q2
                                if (pendiente >= -1)
                                {
                                    //Fijar x pantalla = 0
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(ScreenToCalcCoords.X(0, ElementX, refX), ElementX, refX)
                                        , CalcToScreenCoords.Y(YfX(ScreenToCalcCoords.X(0, ElementX, refX), pendiente), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                                else
                                {
                                    //Fijar y pantalla = 0
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(XfY(ScreenToCalcCoords.Y(0, ElementY, refY), pendiente), ElementX, refX)
                                        , CalcToScreenCoords.Y(ScreenToCalcCoords.Y(0, ElementY, refY), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                            }
                            else
                            {
                                //Q3
                                if (pendiente <= 1)
                                {
                                    //Fijar x pantalla = 0
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(ScreenToCalcCoords.X(0, ElementX, refX), ElementX, refX)
                                        , CalcToScreenCoords.Y(YfX(ScreenToCalcCoords.X(0, ElementX, refX), pendiente), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                                else
                                {
                                    //Fijar y pantalla = SCREEN_TILES_SIZE * 2
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(XfY(ScreenToCalcCoords.Y(SCREEN_TILES_SIZE * 2, ElementY, refY), pendiente), ElementX, refX)
                                        , CalcToScreenCoords.Y(ScreenToCalcCoords.Y(SCREEN_TILES_SIZE * 2, ElementY, refY), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                            }
                        }
                        else
                        {
                            if (a.WY < ElementY)
                            {
                                //Q1
                                if (pendiente <= 1)
                                {
                                    //Fijar x pantalla = SCREEN_TILES_SIZE * 2
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(ScreenToCalcCoords.X(SCREEN_TILES_SIZE * 2, ElementX, refX), ElementX, refX)
                                        , CalcToScreenCoords.Y(YfX(ScreenToCalcCoords.X(SCREEN_TILES_SIZE * 2, ElementX, refX), pendiente), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                                else
                                {
                                    //Fijar y pantalla = 0
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(XfY(ScreenToCalcCoords.Y(0, ElementY, refY), pendiente), ElementX, refX)
                                        , CalcToScreenCoords.Y(ScreenToCalcCoords.Y(0, ElementY, refY), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                            }
                            else
                            {
                                //Q4
                                if (pendiente <= -1)
                                {
                                    //Fijar y pantalla = SCREEN_TILES_SIZE * 2
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(XfY(ScreenToCalcCoords.Y(SCREEN_TILES_SIZE * 2, ElementY, refY), pendiente), ElementX, refX)
                                        , CalcToScreenCoords.Y(ScreenToCalcCoords.Y(SCREEN_TILES_SIZE * 2, ElementY, refY), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                                else
                                {
                                    //Fijar x pantalla = SCREEN_TILES_SIZE * 2
                                    int sourceX = a.CX(ElementX);
                                    Point p1 = new Point(CalcToScreenCoords.X(sourceX, ElementX, refX), CalcToScreenCoords.Y(YfX(sourceX, pendiente), ElementY, refY));
                                    Point p2 = new Point(CalcToScreenCoords.X(ScreenToCalcCoords.X(SCREEN_TILES_SIZE * 2, ElementX, refX), ElementX, refX)
                                        , CalcToScreenCoords.Y(YfX(ScreenToCalcCoords.X(SCREEN_TILES_SIZE * 2, ElementX, refX), pendiente), ElementY, refY));
                                    DrawLine(g, p1, p2, TILE_SIZE);
                                }
                            }
                        }
                    }
                    else
                    {
                        //Lineas de los ejes (rectas)
                        if (a.WX == ElementX) //Vertical
                        {
                            if (a.WY < ElementY) //Superior
                            {
                                Point p1 = new Point(a.SX(refX), a.SY(refY));
                                Point p2 = new Point(a.SX(refX), 0);
                                DrawLine(g, p1, p2, TILE_SIZE);
                            }
                            else if (a.WY > ElementY)//Inferior
                            {
                                Point p1 = new Point(a.SX(refX), a.SY(refY));
                                Point p2 = new Point(a.SX(refX), SCREEN_TILES_SIZE * 2);
                                DrawLine(g, p1, p2, TILE_SIZE);
                            }
                        }
                        else if (a.WY == ElementY) //Horizontal
                        {
                            if (a.WX < ElementX) //Izquierda
                            {
                                Point p1 = new Point(a.SX(refX), a.SY(refY));
                                Point p2 = new Point(0, a.SY(refY));
                                DrawLine(g, p1, p2, TILE_SIZE);
                            }
                            else if (a.WX > ElementX) //Derecha
                            {
                                Point p1 = new Point(a.SX(refX), a.SY(refY));
                                Point p2 = new Point(SCREEN_TILES_SIZE * 2, a.SY(refY));
                                DrawLine(g, p1, p2, TILE_SIZE);
                            }
                        }
                    }
                    //SetPixel(g, a.SX(refX), a.SY(refY), TILE_SIZE);                    
                    //PixelBase.SetPixel(a.SX(refX), a.SY(refY), Color.White);
                }
            }

            using (Graphics g = Graphics.FromImage(Lienzo))
            {               
                g.DrawImage(PixelBase, 0, 0, SCREEN_PIXEL_SIZE, SCREEN_PIXEL_SIZE);
                
                SolidBrush brush = new SolidBrush(Color.Red);
                Pen lapiz = new Pen(brush, 1.0f);
                foreach (DBTile a in CutviewTiles)
                {
                    g.DrawRectangle(lapiz, a.SX(refX) * TILE_SIZE, a.SY(refY) * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                }
                brush = new SolidBrush(Color.Blue);
                lapiz = new Pen(brush, 1.0f);
                g.DrawRectangle(lapiz, WorldToScreenCoords.X(ElementX, refX) * TILE_SIZE, WorldToScreenCoords.Y(ElementY, refY) * TILE_SIZE, TILE_SIZE, TILE_SIZE);
            }

            pictureBox1.Image = Lienzo;
            pictureBox2.Image = PixelBase;
        }

        private void DrawLine(Graphics g, Point p1, Point p2, int size)
        {
            Draw1Line(g, p1, p2);
            /*
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen lapiz = new Pen(brush, (int)Math.Floor((double)size * 1.5f));
            g.FillRectangle(brush, (p1.X * size) - (int)Math.Floor(((double)size * ((double)p1.X / (((double)SCREEN_TILES_SIZE * 2) + 1)))),
                (p1.Y * size) - (int)Math.Floor(((double)size * ((double)p1.Y / (((double)SCREEN_TILES_SIZE * 2) + 1)))), size, size);
            g.DrawLine(lapiz, new Point((p1.X * size) + (int)Math.Floor(((double)size * ((double)p1.X/(((double)SCREEN_TILES_SIZE * 2) + 1)))), 
                (p1.Y * size) + (int)Math.Floor(((double)size * ((double)p1.Y / (((double)SCREEN_TILES_SIZE * 2) + 1))))),
                new Point((p2.X * size) + (int)Math.Floor(((double)size * ((double)p2.X / (((double)SCREEN_TILES_SIZE * 2) + 1)))),
                (p2.Y * size) + (int)Math.Floor(((double)size * ((double)p2.Y / (((double)SCREEN_TILES_SIZE * 2) + 1))))));
                */
        }

        private void Draw1Line(Graphics g, Point p1, Point p2)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen lapiz;
            if ((Math.Abs(p1.X - SCREEN_TILES_SIZE) >= 5) || (Math.Abs(p1.Y - SCREEN_TILES_SIZE) >= 5))
                lapiz = new Pen(brush, 3.0f);
            else if ((Math.Abs(p1.X - SCREEN_TILES_SIZE) >= 3) || (Math.Abs(p1.Y - SCREEN_TILES_SIZE) >= 3))
                lapiz = new Pen(brush, 2.0f);
            else
                lapiz = new Pen(brush, 1.0f);
            g.DrawLine(lapiz, p1, p2);
        }

        private void SetPixel(Graphics g, int X, int Y, int size)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, X * size, Y * size, size, size);
        }

        
        

        private void shadowMask2(int ElementX, int ElementY, int LStrength, int LTiles, double Factor)
        {
            Bitmap PixelBase = new Bitmap(SCREEN_TILES_SIZE * 2 + 1, SCREEN_TILES_SIZE * 2 + 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Bitmap Lienzo = new Bitmap(SCREEN_PIXEL_SIZE, SCREEN_PIXEL_SIZE, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Color p = Color.FromArgb(255, 0, 0, 0);

            List<DBTile> CutviewTiles = DBAccess.GetScreenTiles(ElementX - SCREEN_TILES_SIZE, ElementY - SCREEN_TILES_SIZE, ElementX + SCREEN_TILES_SIZE, ElementY + SCREEN_TILES_SIZE);

            int z = ElementX - SCREEN_TILES_SIZE;
            int k = ElementY - SCREEN_TILES_SIZE;

            foreach (DBTile a in CutviewTiles)
            {
                PixelBase.SetPixel((int)a.WX - z, (int)a.WY - k, p);
            }

            using (Graphics g = Graphics.FromImage(Lienzo))
            {
                g.DrawImage(PixelBase, 0, 0, SCREEN_PIXEL_SIZE, SCREEN_PIXEL_SIZE);
            }

            pictureBox3.Image = PixelBase;

        }
    }
}
