using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TimeMachine.DB;
using TimeMachine.DB.Model;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace TimeMachine
{
    public class EditorViewEngine
    {
        // at class level
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        //private const int SCREEN_TILES_TOTAL_ROW = (FrameDBReader.SCREEN_TILES_SIZE * 2) + 1; //Numero de tiles de izquierda a derecha o de arriba a bajo.
        private const int SCREEN_PIXEL_SIZE = (FrameDBReader.SCREEN_TILES_SIZE * FrameDBReader.TILE_SIZE * 2) + FrameDBReader.TILE_SIZE;

        Dictionary<string, Image> Preloaded;
        Dictionary<string, Image[]> PreloadedObjectsAnimationImages;
        Image Blank = Image.FromFile("D:\\Olles\\TimeLine\\TimeLine\\Images\\Tiles\\Bases\\Blank.gif");//Para cuando no existe.

        protected FrameDBReader frameDBReader;
        protected string PlayerUID;
        protected string _world;


        //Not in the interface, but needs to know them to properly adapt to the GameConnection
        public EditorViewEngine(string player, string world) 
        {
            string ConnectionString = "";
            //TODO: Contactar con el HOST Master para pedir la connectionString a BD de WorldInstance a cambio de asignar el PJ a ese WorldInstance y escribir su template
            //TODO: También nos tiene que dar la info para pintar al PJ: Animation sprites, ...
            //El player UID que se usará a partir de ahora   
            PlayerUID = player;
            _world = world;
            if (world == "World1") ConnectionString = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine;Integrated Security=true;";
            else if (world == "World2") ConnectionString = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine2;Integrated Security=true;";


            frameDBReader = new FrameDBReader(PlayerUID, ConnectionString);
            frameDBReader.PreloadImages(out Preloaded);
            frameDBReader.PreloadObjectPartImages(out PreloadedObjectsAnimationImages);
        }

        public Bitmap PaintFrame()
        {
            frameDBReader.ReadFrameData();
            //Lienzo
            //Bitmap Frame = null;
            Bitmap Lienzo = new Bitmap(SCREEN_PIXEL_SIZE, SCREEN_PIXEL_SIZE, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(Lienzo))
            {
                PaintFloor(g);
                //Paint floor efects 
                //Paint Objects (Happens in PalintFloor for optimization)
                //PaintOtherPlayers(g);
                //Paint mobs
                //PlayerFrame playerFrame = PaintPJ(g);
                //Paint object parts with always_on_top=true
                PaintObjectsAbove(g);
                //Paint object efects
                //Paint mob efects
                //Paint other player efects
                //Paint PJ efects
                //Frame = DoScroll(Lienzo);                
            }
            return Lienzo;
        }

        protected void PaintFloor(Graphics g)
        {
            //Paint floor
            DBTile[] Tiles = frameDBReader.screenTilesReader.dBTiles.ToArray();
            DBObject[] Objects = frameDBReader.objectsReader.dBObjects.ToArray();
            int currentTile = 0, currentObject = 0;//Contador que avanza solo si es la tile que buscamos. Ya vienen preordenadas como esperamos a falta de que no existan.


            int iFrom = frameDBReader.playerPositionReader.dBPlayer.Player_Y - FrameDBReader.SCREEN_TILES_SIZE;
            int iTo = frameDBReader.playerPositionReader.dBPlayer.Player_Y + FrameDBReader.SCREEN_TILES_SIZE;
            int jFrom = frameDBReader.playerPositionReader.dBPlayer.Player_X - FrameDBReader.SCREEN_TILES_SIZE;
            int jTo = frameDBReader.playerPositionReader.dBPlayer.Player_X + FrameDBReader.SCREEN_TILES_SIZE;

            //Las tiles vienen ordenadas de menor a mayor por filas luego columnas
            for (int i = iFrom, y = 0; i <= iTo; i++, y++)
            {
                for (int j = jFrom, x = 0; j <= jTo; j++, x++)
                {
                    DBTile dBTile = null;
                    DBObject dBObject = null;
                    Image Tile;
                    Image ImgObject;
                    int darkenn = 0;

                    Tile = Blank;
                    if (currentTile < Tiles.Length)
                    {
                        dBTile = Tiles[currentTile];
                        if ((dBTile.X == j) && (dBTile.Y == i))
                        {
                            darkenn = dBTile.Darkness;
                            Tile = Preloaded[Tiles[currentTile].Image];
                            Tiles[currentTile] = null;//Freeing at the same time.
                            currentTile++;
                        }
                    }
                    g.DrawImage(Tile, new Point(x * FrameDBReader.TILE_SIZE, y * FrameDBReader.TILE_SIZE));

                    //Paint objects in tile.
                    if (currentObject < Objects.Length)
                    {
                        dBObject = Objects[currentObject];
                        if ((dBObject.X == j) && (dBObject.Y == i))
                        {
                            ImgObject = GetObjectFrame(dBObject);
                            Objects[currentObject] = null;//Freeing at the same time.
                            using (Bitmap TransparentObj = new Bitmap(ImgObject))
                            {
                                TransparentObj.MakeTransparent(Color.White);
                                int displaciaX = (ImgObject.Width - FrameDBReader.TILE_SIZE) / 2;
                                int displaciaY = ImgObject.Height - FrameDBReader.TILE_SIZE;
                                g.DrawImage(TransparentObj, new Point(x * FrameDBReader.TILE_SIZE - displaciaX, 
                                    y * FrameDBReader.TILE_SIZE - displaciaY));
                            }
                            currentObject++;
                        }
                    }

                    //Do Shadowing
                    /* 
                    Color p = Color.FromArgb(darkenn, 0, 0, 0);
                    SolidBrush brush = new SolidBrush(p);
                    g.FillRectangle(brush, new Rectangle(x * FrameDBReader.TILE_SIZE, y * FrameDBReader.TILE_SIZE, FrameDBReader.TILE_SIZE, FrameDBReader.TILE_SIZE));
                    */

                    //Player Tile illumination                    
                    if ((x == FrameDBReader.SCREEN_TILES_SIZE) && (y == FrameDBReader.SCREEN_TILES_SIZE))
                    {
                        Color p2 = Color.FromArgb(65, 205, 205, 255);
                        SolidBrush brush2 = new SolidBrush(p2);
                        g.FillRectangle(brush2, new Rectangle(x * FrameDBReader.TILE_SIZE, y * FrameDBReader.TILE_SIZE, FrameDBReader.TILE_SIZE, FrameDBReader.TILE_SIZE));

                        Color p3 = Color.FromArgb(125, 50, 50, 255);
                        SolidBrush brush3 = new SolidBrush(p3);
                        g.DrawRectangle(new Pen(brush3,1.0f), new Rectangle(x * FrameDBReader.TILE_SIZE, y * FrameDBReader.TILE_SIZE, FrameDBReader.TILE_SIZE - 1, FrameDBReader.TILE_SIZE - 1));
                    }
                    
                }
            }
        }

        protected void PaintObjectsAbove(Graphics g)
        {
            //Paint floor
            DBObject[] Objects = frameDBReader.objectsReader.dBObjects.ToArray();
            int currentObject = 0;//Contador que avanza solo si es la tile que buscamos. Ya vienen preordenadas como esperamos a falta de que no existan.


            int iFrom = frameDBReader.playerPositionReader.dBPlayer.Player_Y - FrameDBReader.SCREEN_TILES_SIZE;
            int iTo = frameDBReader.playerPositionReader.dBPlayer.Player_Y + FrameDBReader.SCREEN_TILES_SIZE;
            int jFrom = frameDBReader.playerPositionReader.dBPlayer.Player_X - FrameDBReader.SCREEN_TILES_SIZE;
            int jTo = frameDBReader.playerPositionReader.dBPlayer.Player_X + FrameDBReader.SCREEN_TILES_SIZE;

            //Las tiles vienen ordenadas de menor a mayor por filas luego columnas
            for (int i = iFrom, y = 0; i <= iTo; i++, y++)
            {
                for (int j = jFrom, x = 0; j <= jTo; j++, x++)
                {

                    DBObject dBObject = null;
                    Image ImgObject;

                    //Paint objects in tile.
                    if (currentObject < Objects.Length)
                    {
                        dBObject = Objects[currentObject];
                        if ((dBObject.X == j) && (dBObject.Y == i))
                        {
                            if (dBObject.Above)
                            {
                                ImgObject = GetObjectFrame(dBObject);
                                Objects[currentObject] = null;//Freeing at the same time.
                                using (Bitmap TransparentObj = new Bitmap(ImgObject))
                                {
                                    TransparentObj.MakeTransparent(Color.White);
                                    int displaciaX = (ImgObject.Width - FrameDBReader.TILE_SIZE) / 2;
                                    int displaciaY = ImgObject.Height - FrameDBReader.TILE_SIZE;
                                    g.DrawImage(TransparentObj, new Point(x * FrameDBReader.TILE_SIZE - displaciaX,
                                        y * FrameDBReader.TILE_SIZE - displaciaY));
                                }
                            }
                            currentObject++;
                        }
                    }
                }
            }
        }

        private Image GetObjectFrame(DBObject dBObject)
        {
            int frameNumber = 0;

            Image[] _local;
            try
            {
                _local = PreloadedObjectsAnimationImages[dBObject.Lightswitch ? (dBObject.Lightswitch_status ? dBObject.Animation_light_on : dBObject.Animation) : dBObject.Animation];
            }
            catch
            {
                _local = new Image[] { Blank };
            }

            return GetObjectAnimationFrame(dBObject.Animation_timestamp, dBObject.Animation_speed, _local, out frameNumber);
        }

        private Image GetObjectAnimationFrame(DateTime AnimationStart, double AnimationSpeed, Image[] ObjectAnimation, out int frameNumber)
        {
            double Lapse = (DateTime.Now - AnimationStart).TotalMilliseconds % (((AnimationSpeed * 1000.0f) / ObjectAnimation.Length) * (double)ObjectAnimation.Length);

            //TODO: Update timestamps for not having too many TotalMilliseconds.

            int i = ObjectAnimation.Length;
            frameNumber = 1;
            while ((i > 0) && ((((AnimationSpeed * 1000.0f) / ObjectAnimation.Length) * (double)frameNumber) < Lapse)) { frameNumber++; i--; }
            if (i == 0) frameNumber = ObjectAnimation.Length;
            return ObjectAnimation[frameNumber - 1];
        }


        private Bitmap DoScroll(Bitmap Lienzo)
        {
            return Lienzo.Clone(new Rectangle(new Point(FrameDBReader.TILE_SIZE, FrameDBReader.TILE_SIZE), new Size(new Point(FrameDBReader.TILE_SIZE * (FrameDBReader.SCREEN_TILES_SIZE - 1) * 2, FrameDBReader.TILE_SIZE * (FrameDBReader.SCREEN_TILES_SIZE - 1) * 2))), Lienzo.PixelFormat);
        }        

        

    }
}

