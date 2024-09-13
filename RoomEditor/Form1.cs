using DataBaseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TimeMachine;
using static System.Net.Mime.MediaTypeNames;

namespace RoomEditor
{


    public partial class Form1 : Form
    {
        private const string GODUID = "479F256B-6327-4301-9824-D37713ABD472";
        private SqlConnection connection;
        private EditorViewEngine pepe;
        private Dictionary<string, TileType> tileTypesList;
        private Position GODLastKnownPosition;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connectionString = "data source=(local)\\SQLEXPRESS2K14;initial catalog=TimeMachine2;Integrated Security=true;";
            connection = new SqlConnection(connectionString);
            connection.Open();

            PreloadTilesTypes();

            //insertGOD();
            pepe = new EditorViewEngine(GODUID, "World2");
            ReadGODPosition();

            PaintFrame();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 'a')
            {
                MoveGOD_Left();
            }

            if (c == 's')
            {
                MoveGOD_Down();
            }

            if (c == 'd')
            {
                MoveGOD_Right();
            }

            if (c == 'w')
            {
                MoveGOD_Up();
            }

            PaintFrame();
        }

        private void MoveGOD_Right()
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand("UPDATE [dbo].[PLAYERS] SET ROOM_TILE_GRID_X = ROOM_TILE_GRID_X + 1 WHERE NAME LIKE 'GOD'", connection);
            command.ExecuteNonQuery();
        }

        private void MoveGOD_Left()
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand("UPDATE [dbo].[PLAYERS] SET ROOM_TILE_GRID_X = ROOM_TILE_GRID_X - 1 WHERE NAME LIKE 'GOD'", connection);
            command.ExecuteNonQuery();
        }

        private void MoveGOD_Up()
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand("UPDATE [dbo].[PLAYERS] SET ROOM_TILE_GRID_Y = ROOM_TILE_GRID_Y - 1 WHERE NAME LIKE 'GOD'", connection);
            command.ExecuteNonQuery();
        }

        private void MoveGOD_Down()
        {
            //Escribir los datos de Player para un move que empieza.
            SqlCommand command = new SqlCommand("UPDATE [dbo].[PLAYERS] SET ROOM_TILE_GRID_Y = ROOM_TILE_GRID_Y + 1 WHERE NAME LIKE 'GOD'", connection);
            command.ExecuteNonQuery();
        }

        private void PaintFrame()
        {
            var bitomapo = pepe.PaintFrame();
            panel2.BackgroundImage = bitomapo;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
        }
        
        //private void insertGOD()
        //{
        //    if (!ExistsGOD())
        //    {
        //        //Escribir los datos de Player para un move que empieza.
        //        SqlCommand command = new SqlCommand("", connection);
        //        command.Parameters.AddWithValue("@UID", "479F256B-6327-4301-9824-D37713ABD472");
        //        command.Parameters.AddWithValue("@Status", switchStatus ? "true" : "false");
        //        command.ExecuteNonQuery();
        //    }
        //}
        //

        private void PreloadTilesTypes()
        {
            ReadTilesTypes();

            listBox1.Items.Clear();
            listBox1.Items.AddRange(tileTypesList.Values.ToArray());
        }

        private void ReadTilesTypes()
        {
            tileTypesList = new Dictionary<string, TileType>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT [UID],[NAME],[IMAGE],[CUTVIEW],[DARKNESS],[TRASPASSABLE] FROM [TimeMachine2].[dbo].[TILE_TYPES]", connection);
                SqlDataReader tilesReader = command.ExecuteReader();
                try
                {
                    TileType tileType;
                    while (tilesReader.Read())//Por row
                    {
                        tileType = new TileType();

                        tileType.UID = ((Guid)tilesReader[0]).ToString();
                        tileType.NAME = (string)tilesReader[1];
                        tileType.IMAGE = (string)tilesReader[2];
                        tileType.CUTVIEW = Types.DBBoolToBoolean((string)tilesReader[3]);
                        tileType.DARKNESS = (int)tilesReader[4];
                        tileType.TRASPASSABLE = Types.DBBoolToBoolean((string)tilesReader[5]);

                        tileTypesList.Add(tileType.UID, tileType);
                    }                    
                }
                finally
                {
                    try
                    {
                        tilesReader.Close();
                        tilesReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tileTypesList.TryGetValue(((TileType)listBox1.Items[listBox1.SelectedIndex]).UID, out var value))
            {
                textBox1.Text = value.NAME;
                textBox2.Text = value.IMAGE;
                textBox3.Text = value.DARKNESS.ToString();

                checkBox1.Checked = value.TRASPASSABLE;
                checkBox2.Checked = value.CUTVIEW;
            }
        }

        private void InsertTyleTypeBtn_Click(object sender, EventArgs e)
        {
            ReadGODPosition();
            deleteTileType();
            insertTileType((TileType)listBox1.Items[listBox1.SelectedIndex]);
            PaintFrame();
        }

        private const string OOP2_QUERYSTRING = "DELETE FROM TILES WHERE ROOM_TILE_GRID_X = @X AND ROOM_TILE_GRID_Y = @Y";
        private void deleteTileType()
        {
            SqlCommand command = new SqlCommand(OOP2_QUERYSTRING, connection);
            command.Parameters.AddWithValue("@X", GODLastKnownPosition.X);
            command.Parameters.AddWithValue("@Y", GODLastKnownPosition.Y);

            command.ExecuteNonQuery();
        }

        private void insertTileType(TileType tileType)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[TILES] ([UID]" + 
                ", [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [TYPE_DEFINITION], [IMAGE], " + 
                "[CUTVIEW], [DARKNESS], [TRASPASSABLE]) " +
                "VALUES (@uid, @roomgridx, @roomgridy, @tiletypeuid, @image, " + 
                "@cutview, @darkness, @traspassable)", connection);
            command.Parameters.AddWithValue("@uid", Guid.NewGuid().ToString());
            command.Parameters.AddWithValue("@roomgridx", GODLastKnownPosition.X);
            command.Parameters.AddWithValue("@roomgridy", GODLastKnownPosition.Y);
            command.Parameters.AddWithValue("@tiletypeuid", tileType.UID);
            command.Parameters.AddWithValue("@image", tileType.IMAGE); 
            command.Parameters.AddWithValue("@cutview", tileType.CUTVIEW);
            command.Parameters.AddWithValue("@darkness", tileType.DARKNESS);
            command.Parameters.AddWithValue("@traspassable", tileType.TRASPASSABLE);

            command.ExecuteNonQuery();
        }


        private const string OOP_QUERYSTRING = "SELECT ROOM_TILE_GRID_X, ROOM_TILE_GRID_Y FROM PLAYERS WHERE UID = @uid";
        public void ReadGODPosition()
        {
            //Read from DB.
            SqlCommand command = new SqlCommand(OOP_QUERYSTRING, connection);
            command.Parameters.AddWithValue("@uid", GODUID);
            try
            {
                SqlDataReader CanReader = command.ExecuteReader();
                try
                {
                    if (CanReader.Read())
                    {
                        GODLastKnownPosition = new Position((int)CanReader[0], (int)CanReader[1]);
                    }
                }
                finally
                {
                    try
                    {
                        CanReader.Close();
                        CanReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadGODPosition();
            deleteTileType();
            PaintFrame();
        }
    }
}
