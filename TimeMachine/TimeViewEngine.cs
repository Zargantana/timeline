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
    public delegate DBPlayersImages PersonajesImages(string world);

    public class TimeViewEngine : GameViewEngine
    {
        // at class level
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        //private const int SCREEN_TILES_TOTAL_ROW = (FrameDBReader.SCREEN_TILES_SIZE * 2) + 1; //Numero de tiles de izquierda a derecha o de arriba a bajo.
        private const int SCREEN_PIXEL_SIZE = (FrameDBReader.SCREEN_TILES_SIZE * FrameDBReader.TILE_SIZE * 2) + FrameDBReader.TILE_SIZE;

        Dictionary<string, Image> Preloaded;
        Image Blank = Image.FromFile("D:\\Olles\\TimeLine\\TimeLine\\Images\\Tiles\\Bases\\Blank.gif");//Para cuando no existe.

        PersonajesImages personajesImagesAdapter;
        DBPlayersImages personajesImages;
        DBPlayersImages _serverPointer;
        DBPlayersImages _localPointer;
        bool copy_started = false;
        Thread copieitor;


        //Not in the interface, but needs to know them to properly adapt to the GameConnection
        public TimeViewEngine(string player, string world, FrameMultiBuffer frameBuffer, PersonajesImages delegateFunc) : base(frameBuffer)
        {
            //Funcion para obtener las imagenes y animaciones de los personajes.
            personajesImagesAdapter = delegateFunc;

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
        }

        //Read from DB and, by a logic, draw a frame for the player in the buffer (_player).
        protected override void GameTick()
        {//Esto será un engine, no la connection...
            //Aqui se verá según la visión lo que se pinta,...
            GODmESUREITOR.StartMesure();
            //Obtener los objetos de BD en forma de modelo
            frameDBReader.ReadFrameData();
            //Obtener un puntero a las imágenes de animaciones de personajes en "personajesImages"
            SetPersonajesImages();
            
            //Paint each tile
            using (Bitmap Frame = PaintFrame())
            {
                //Insert to the _frameBuffer the painting.
                WriteToFrameBuffer(Frame);
            }
            GC.Collect();
            GODmESUREITOR.StopMesure();
        }

        //Copies all the sky locally. Will rule your mind.
        private void StarCopy()
        {
            DBPlayersImages _local = (DBPlayersImages)_serverPointer.Clone();
            _localPointer = _local;
        }

        private void SetPersonajesImages()
        {

            DBPlayersImages _local = personajesImagesAdapter(_world);
            if (!ReferenceEquals(_local, _serverPointer) || copy_started)
            {
                copy_started = true;
                _serverPointer = _local;

                //Start a copy
                if (personajesImages == null)
                {
                    /* Sync */
                    //Call copy
                    StarCopy();
                    //Change pointers
                    personajesImages = _localPointer;
                    copy_started = false;
                }
                else
                {
                    /* Assync */
                    //Check if already started
                    if (copieitor == null)
                    {//NO: Start copy                        

                        copieitor = new Thread(new ThreadStart(StarCopy));
                        copieitor.Start();
                    }
                    else
                    {//YES: Check if finished
                        if (copieitor.Join(0))
                        {//YES: Change pointers and free thread                            
                            personajesImages = _localPointer;
                            copieitor = null;
                            copy_started = false;
                        }
                        //NO: continue
                    }
                }
            }
        }

        protected Bitmap PaintFrame()
        {
            //Lienzo
            Bitmap Frame = null;
            Bitmap Lienzo = new Bitmap(SCREEN_PIXEL_SIZE, SCREEN_PIXEL_SIZE, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(Lienzo))
            {
                PaintFloor(g);
                //Paint floor efects 
                //Paint Objects (Happens in PalintFloor for optimization)
                PaintOtherPlayers(g);
                //Paint mobs
                PlayerFrame playerFrame = PaintPJ(g);
                //Paint object parts with always_on_top=true                
                //Paint object efects
                //Paint mob efects
                //Paint other player efects
                //Paint PJ efects
                Frame = DoScroll(Lienzo, playerFrame);                
            }
            return Frame;
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
                            ImgObject = Preloaded[Objects[currentObject].Image];
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

        protected PlayerFrame PaintPJ(Graphics g)
        {
            DBPlayer dBPlayer = frameDBReader.playerPositionReader.dBPlayer;
            PlayerFrame playerFrame = GetPlayerFrame(dBPlayer);

            using (Bitmap TransparentPJ = new Bitmap(playerFrame.Sprite))
            {
                TransparentPJ.MakeTransparent(Color.White);
                int displaciaX = (playerFrame.Sprite.Width - FrameDBReader.TILE_SIZE) / 2;
                int displaciaY = playerFrame.Sprite.Height - FrameDBReader.TILE_SIZE;
                g.DrawImage(TransparentPJ, new Point((FrameDBReader.SCREEN_TILES_SIZE * FrameDBReader.TILE_SIZE) + playerFrame.X_Offset - displaciaX, 
                    (FrameDBReader.SCREEN_TILES_SIZE * FrameDBReader.TILE_SIZE) + playerFrame.Y_Offset - displaciaY)); 
            }
            return playerFrame;
        }

        protected void PaintOtherPlayers(Graphics g)
        {
            DBPlayer dBPlayer = frameDBReader.playerPositionReader.dBPlayer;
            List<DBPlayer> OtherPlayers = frameDBReader.playerPositionReader.dBOtherPlayers;            
            foreach (DBPlayer dbOtherPlayer in OtherPlayers)
            {
                PlayerFrame otherPlayerFrame = GetPlayerFrame(dbOtherPlayer);
                using (Bitmap TransparentPJ = new Bitmap(otherPlayerFrame.Sprite))
                {
                    TransparentPJ.MakeTransparent(Color.White);
                    //Coords:
                    int worldCoord_screenX0 = (dBPlayer.Player_X - FrameDBReader.SCREEN_TILES_SIZE);
                    int worldCoord_screenY0 = (dBPlayer.Player_Y - FrameDBReader.SCREEN_TILES_SIZE);
                    int screenCoord_OtherPlayerX = dbOtherPlayer.Player_X - worldCoord_screenX0;
                    int screenCoord_OtherPlayerY = dbOtherPlayer.Player_Y - worldCoord_screenY0;
                    int displaciaX = (otherPlayerFrame.Sprite.Width - FrameDBReader.TILE_SIZE) / 2;
                    int displaciaY = otherPlayerFrame.Sprite.Height - FrameDBReader.TILE_SIZE;
                    g.DrawImage(TransparentPJ, new Point((screenCoord_OtherPlayerX * FrameDBReader.TILE_SIZE) + otherPlayerFrame.X_Offset - displaciaX,
                        (screenCoord_OtherPlayerY * FrameDBReader.TILE_SIZE) + otherPlayerFrame.Y_Offset - displaciaY));
                }
            }
        }

        private PlayerFrame GetPlayerFrame(DBPlayer dBPlayer)
        {
            int frameNumber = 0;
            PlayerFrame result = new PlayerFrame();

            DBPlayerImages _local;
            try
            {
               _local = personajesImages[dBPlayer.UID];
            }
            catch
            {
                _local = personajesImages[Guid.Empty.ToString()];
            }

            switch (dBPlayer.Movement)
            {
                case 0:
                    {
                        result.Sprite = GetPlayerFacingFrame(dBPlayer);
                        break;
                    }
                case 1:
                    {
                        Image[] PersonajeAnimationUp = _local.PersonajeAnimationUp;
                        result.Sprite = GetPlayerAnimationFrame(dBPlayer.MovementStart, dBPlayer.PlayerMoveSpeed, PersonajeAnimationUp, out frameNumber);
                        if (dBPlayer.Moved) result.Y_Offset += FrameDBReader.TILE_SIZE - ((FrameDBReader.TILE_SIZE / PersonajeAnimationUp.Length) * (frameNumber));
                        else result.Y_Offset -= ((FrameDBReader.TILE_SIZE / PersonajeAnimationUp.Length) * (frameNumber));
                        break;
                    }
                case 2:
                    {
                        Image[] PersonajeAnimationRight = _local.PersonajeAnimationRight;
                        result.Sprite = GetPlayerAnimationFrame(dBPlayer.MovementStart, dBPlayer.PlayerMoveSpeed, PersonajeAnimationRight, out frameNumber);
                        if (dBPlayer.Moved) result.X_Offset -= FrameDBReader.TILE_SIZE - ((FrameDBReader.TILE_SIZE / PersonajeAnimationRight.Length) * (frameNumber));
                        else result.X_Offset += ((FrameDBReader.TILE_SIZE / PersonajeAnimationRight.Length) * (frameNumber));
                        break;
                    }
                case 3: 
                    {
                        Image[] PersonajeAnimationDown = _local.PersonajeAnimationDown;
                        result.Sprite = GetPlayerAnimationFrame(dBPlayer.MovementStart, dBPlayer.PlayerMoveSpeed, PersonajeAnimationDown, out frameNumber);
                        if (dBPlayer.Moved) result.Y_Offset -= FrameDBReader.TILE_SIZE -((FrameDBReader.TILE_SIZE / PersonajeAnimationDown.Length) * (frameNumber));
                        else result.Y_Offset += ((FrameDBReader.TILE_SIZE / PersonajeAnimationDown.Length) * (frameNumber));
                        break;
                    }
                case 4: 
                    {
                        Image[] PersonajeAnimationLeft = _local.PersonajeAnimationLeft;
                        result.Sprite = GetPlayerAnimationFrame(dBPlayer.MovementStart, dBPlayer.PlayerMoveSpeed, PersonajeAnimationLeft, out frameNumber);
                        if (dBPlayer.Moved) result.X_Offset += FrameDBReader.TILE_SIZE - ((FrameDBReader.TILE_SIZE / PersonajeAnimationLeft.Length) * (frameNumber));
                        else result.X_Offset -= ((FrameDBReader.TILE_SIZE / PersonajeAnimationLeft.Length) * (frameNumber));
                        break;
                    }
            }
            return result;
        }

        private Image GetPlayerAnimationFrame(DateTime MovementStart, double PlayerMoveSpeed, Image[] PersonajeAnimation, out int frameNumber)
        {
            double Lapse = (DateTime.Now - MovementStart).TotalMilliseconds;

            int i = PersonajeAnimation.Length;
            frameNumber = 1;
            while ((i > 0) && ( (((PlayerMoveSpeed * 1000.0f) / PersonajeAnimation.Length) * (double)frameNumber) < Lapse )) { frameNumber++; i--; }
            if (i == 0) frameNumber = PersonajeAnimation.Length;
            return PersonajeAnimation[frameNumber-1];
        }

        private Image GetPlayerFacingFrame(DBPlayer dBPlayer)
        {
            switch (dBPlayer.Facing)
            {
                case 1: return personajesImages[dBPlayer.UID].PersonajeUp;
                case 2: return personajesImages[dBPlayer.UID].PersonajeRight;
                case 4: return personajesImages[dBPlayer.UID].PersonajeLeft;
                default: return personajesImages[dBPlayer.UID].PersonajeDown;  
            }
        }

        private Bitmap DoScroll(Bitmap Lienzo, PlayerFrame playerFrame)
        {
            return Lienzo.Clone(new Rectangle(new Point(FrameDBReader.TILE_SIZE + playerFrame.X_Offset, FrameDBReader.TILE_SIZE + playerFrame.Y_Offset), new Size(new Point(FrameDBReader.TILE_SIZE * (FrameDBReader.SCREEN_TILES_SIZE - 1) * 2, FrameDBReader.TILE_SIZE * (FrameDBReader.SCREEN_TILES_SIZE - 1) * 2))), Lienzo.PixelFormat);
        }        

        protected void WriteToFrameBuffer(Bitmap Frame)
        {
            //Convert to GIF
            GifBitmapEncoder gEnc = new GifBitmapEncoder();
            IntPtr bmp = Frame.GetHbitmap();

            var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bmp,
                        IntPtr.Zero,
                        System.Windows.Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
            gEnc.Frames.Add(BitmapFrame.Create(src));
            MemoryStream fs = new MemoryStream();
            gEnc.Save(fs);

            DeleteObject(bmp);

            //Convert to B64 and set into the buffer
            FrameBuf _local = new FrameBuf();
            _local._buffer = System.Convert.ToBase64String(fs.ToArray());
            FrameBuffer.writeNew(_local);
        }

        public override void Dispose()
        {
            Thread _local = copieitor;
            try
            {
                if (_local != null)
                    if (!_local.Join(1000)) _local.Abort();
            }
            catch { }
            finally { _local = null; copieitor = null; }

            personajesImagesAdapter = null;
            personajesImages = null;
            _localPointer = null;
            _serverPointer = null;

            base.Dispose();
        }

    }
}

