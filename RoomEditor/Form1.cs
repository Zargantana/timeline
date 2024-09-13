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
        private Dictionary<string, ObjectType> objectTypesList;
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
            PreloadObjectTypes();

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
            deleteTileType(GODLastKnownPosition);
            insertTileType((TileType)listBox1.Items[listBox1.SelectedIndex], GODLastKnownPosition);
            PaintFrame();
        }

        private const string OOP2_QUERYSTRING = "DELETE FROM TILES WHERE ROOM_TILE_GRID_X = @X AND ROOM_TILE_GRID_Y = @Y";
        private void deleteTileType(Position pos)
        {
            SqlCommand command = new SqlCommand(OOP2_QUERYSTRING, connection);
            command.Parameters.AddWithValue("@X", pos.X);
            command.Parameters.AddWithValue("@Y", pos.Y);

            command.ExecuteNonQuery();
        }

        private void insertTileType(TileType tileType, Position position)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[TILES] ([UID]" + 
                ", [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [TYPE_DEFINITION], [IMAGE], " + 
                "[CUTVIEW], [DARKNESS], [TRASPASSABLE]) " +
                "VALUES (@uid, @roomgridx, @roomgridy, @tiletypeuid, @image, " + 
                "@cutview, @darkness, @traspassable)", connection);
            command.Parameters.AddWithValue("@uid", Guid.NewGuid().ToString());
            command.Parameters.AddWithValue("@roomgridx", position.X);
            command.Parameters.AddWithValue("@roomgridy", position.Y);
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
            deleteTileType(GODLastKnownPosition);
            PaintFrame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Position start, end;
            var last = new Position(GODLastKnownPosition.X, GODLastKnownPosition.Y);
            ReadGODPosition();            
            if (GODLastKnownPosition.X < last.X)
            {
                if (GODLastKnownPosition.Y < last.Y)
                {
                    start = new Position(GODLastKnownPosition.X, GODLastKnownPosition.Y);
                    end = new Position(last.X, last.Y);
                }
                else
                {
                    start = new Position(GODLastKnownPosition.X, last.Y);
                    end = new Position(last.X, GODLastKnownPosition.Y);
                }
            } else
            {
                if (GODLastKnownPosition.Y < last.Y)
                {
                    start = new Position(last.X, GODLastKnownPosition.Y);
                    end = new Position(GODLastKnownPosition.X, last.Y);
                }
                else
                {
                    start = new Position(last.X, last.Y);
                    end = new Position(GODLastKnownPosition.X, GODLastKnownPosition.Y);
                }
            }
            for(int x = start.X; x <= end.X; x++)
            {
                for (int y = start.Y; y <= end.Y; y++)
                {
                    var pos = new Position(x, y);
                    deleteTileType(pos);
                    insertTileType((TileType)listBox1.Items[listBox1.SelectedIndex], pos);
                }
            }
            PaintFrame();
        }

        private void PreloadObjectTypes()
        {
            ReadObjectTypes();

            listBox2.Items.Clear();
            listBox2.Items.AddRange(objectTypesList.Values.ToArray());
        }

        private void ReadObjectTypes()
        {
            objectTypesList = new Dictionary<string, ObjectType>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT [UID],[NAME],[PV],[INVULNERABLE] FROM [TimeMachine2].[dbo].[OBJECT_TYPES]", connection);
                SqlDataReader objectsReader = command.ExecuteReader();
                try
                {
                    ObjectType objectType;
                    while (objectsReader.Read())//Por row
                    {
                        objectType = new ObjectType();

                        objectType.UID = ((Guid)objectsReader[0]).ToString();
                        objectType.NAME = (string)objectsReader[1];
                        objectType.PV = (int)objectsReader[2];
                        objectType.INVULNERABLE = Types.DBBoolToBoolean((string)objectsReader[3]);

                        objectTypesList.Add(objectType.UID, objectType);
                    }
                }
                finally
                {
                    try
                    {
                        objectsReader.Close();
                        objectsReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectTypesList.TryGetValue(((ObjectType)listBox2.Items[listBox2.SelectedIndex]).UID, out var value))
            {
                textBox6.Text = value.NAME;
                textBox5.Text = value.PV.ToString();

                checkBox3.Checked = value.INVULNERABLE;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadGODPosition();
            var objectUid = getObject();
            deleteObject(objectUid);
            PaintFrame();
        }

        private const string OOP3_QUERYSTRING = "DELETE FROM OBJECTS WHERE UID = @uid";
        private const string OOP4_QUERYSTRING = "DELETE FROM OBJECT_PARTS WHERE UID IN (SELECT OBJECT_PART FROM REL_OBJECTS_AND_PARTS WHERE OBJECT = @uid)";
        private void deleteObject(Guid objectUid)
        {
            SqlCommand command = new SqlCommand(OOP4_QUERYSTRING, connection);
            command.Parameters.AddWithValue("@uid", objectUid);

            command.ExecuteNonQuery();

            command = new SqlCommand(OOP3_QUERYSTRING, connection);
            command.Parameters.AddWithValue("@uid", objectUid);

            command.ExecuteNonQuery();
        }
        private const string OOP6_QUERYSTRING = "SELECT UID FROM OBJECTS WHERE ROOM_TILE_GRID_X = @X AND ROOM_TILE_GRID_Y = @Y";
        private Guid getObject()
        {

            Guid objectUid = Guid.Empty;
            try
            {
                SqlCommand command = new SqlCommand(OOP6_QUERYSTRING, connection);
                command.Parameters.AddWithValue("@X", GODLastKnownPosition.X);
                command.Parameters.AddWithValue("@Y", GODLastKnownPosition.Y);
                
                SqlDataReader objectsReader = command.ExecuteReader();
                try
                {
                    
                    if (objectsReader.Read())//Por row
                    {
                        objectUid = (Guid)objectsReader[0];
                    }
                }
                finally
                {
                    try
                    {
                        objectsReader.Close();
                        objectsReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return objectUid;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReadGODPosition();
            var objectUid = getObject();
            deleteObject(objectUid);
            var objectType = (ObjectType)listBox2.Items[listBox2.SelectedIndex];
            var objectGuid = insertObject(objectType);
            var partTypes = readObjectPartTypes(objectType);
            foreach (var partType in partTypes)
            {
                insertObjectPart(objectGuid, objectType, partType);
            }
            PaintFrame();
        }

        private IEnumerable<ObjectPartType> readObjectPartTypes(ObjectType objectType)
        {
            var objectPartTypesList = new List<ObjectPartType>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT [UID], [NAME], [OFFSET_X], [OFFSET_Y], [IMAGE], [PV], " +
                    "[INVULNERABLE], [CUTVIEW], [LIGHTNING], [LIGHTNING_TILES], [LIGHTNING_FACTOR], [LIGHTSWITCH], [TRASPASSABLE] " + 
                    "FROM [TimeMachine2].[dbo].[OBJECT_PART_TYPES] PART INNER JOIN " +
                    "[TimeMachine2].[dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES] REL ON PART.UID = REL.OBJECT_PART_TYPE " + 
                    "WHERE REL.OBJECT_TYPE = @uid", connection);
                command.Parameters.AddWithValue("@uid", objectType.UID);
                SqlDataReader objectsReader = command.ExecuteReader();
                try
                {
                    ObjectPartType objectPartType;
                    while (objectsReader.Read())//Por row
                    {
                        objectPartType = new ObjectPartType();

                        objectPartType.UID = ((Guid)objectsReader[0]).ToString();
                        objectPartType.NAME = (string)objectsReader[1];
                        objectPartType.OFFSET_X = (int)objectsReader[2];
                        objectPartType.OFFSET_Y = (int)objectsReader[3];
                        objectPartType.IMAGE = (string)objectsReader[4];
                        objectPartType.PV = (int)objectsReader[5];
                        objectPartType.INVULNERABLE = Types.DBBoolToBoolean((string)objectsReader[6]);
                        objectPartType.CUTVIEW = Types.DBBoolToBoolean((string)objectsReader[7]);
                        objectPartType.LIGHTNING = (int)objectsReader[8];
                        objectPartType.LIGHTNING_TILES = (int)objectsReader[9];
                        objectPartType.LIGHTNING_FACTOR = (string)objectsReader[10];
                        objectPartType.LIGHTSWITCH = Types.DBBoolToBoolean((string)objectsReader[11]);
                        objectPartType.TRASPASSABLE = Types.DBBoolToBoolean((string)objectsReader[12]);

                        objectPartTypesList.Add(objectPartType);
                    }
                }
                finally
                {
                    try
                    {
                        objectsReader.Close();
                        objectsReader = null;
                    }
                    catch { }//TODO: Viene de un finally, veamos que esto no corte el raise de la excepcion de la que venimos....
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return objectPartTypesList;
        }

        private Guid insertObject(ObjectType objectType)
        {
            var objectGuid = Guid.NewGuid();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[OBJECTS] ([UID]" +
                ", [NAME], [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [TYPE_DEFINITION], [PV], [INVULNERABLE]) " +
                "VALUES (@uid, @name, @roomgridx, @roomgridy, @typeuid, @pv, @invulnerable)", connection);
            command.Parameters.AddWithValue("@uid", objectGuid);
            command.Parameters.AddWithValue("@name", objectType.NAME);
            command.Parameters.AddWithValue("@roomgridx", GODLastKnownPosition.X);
            command.Parameters.AddWithValue("@roomgridy", GODLastKnownPosition.Y);
            command.Parameters.AddWithValue("@typeuid", objectType.UID);
            command.Parameters.AddWithValue("@pv", objectType.PV);
            command.Parameters.AddWithValue("@invulnerable", objectType.INVULNERABLE);
            
            command.ExecuteNonQuery();

            return objectGuid;
        }

        private void insertObjectPart(Guid objectGuid, ObjectType objectType, ObjectPartType objectPartType)
        {
            var objectPartGuid = Guid.NewGuid();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[OBJECT_PARTS] ([UID]" +
                ", [NAME], [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [TYPE_DEFINITION], [IMAGE], [PV], " +
                "[INVULNERABLE], [CUTVIEW], [LIGHTNING], [LIGHTNING_TILES], [LIGHTNING_FACTOR], " +
                "[LIGHTSWITCH], [LIGHTSWITCH_STATUS], [TRASPASSABLE]) " +
                "VALUES (@uid, @name, @roomgridx, @roomgridy, @typeuid, @image, @pv, @invulnerable," +
                "@cutview, @lightning, @lightning_tiles, @lightning_factor, @lightswitch, " + 
                "@lightswitch_status, @traspassable)", connection);
            command.Parameters.AddWithValue("@uid", objectPartGuid.ToString());
            command.Parameters.AddWithValue("@name", objectPartType.NAME);
            command.Parameters.AddWithValue("@roomgridx", GODLastKnownPosition.X + objectPartType.OFFSET_X);
            command.Parameters.AddWithValue("@roomgridy", GODLastKnownPosition.Y + objectPartType.OFFSET_Y);
            command.Parameters.AddWithValue("@typeuid", objectPartType.UID);
            command.Parameters.AddWithValue("@image", objectPartType.IMAGE);
            command.Parameters.AddWithValue("@pv", objectPartType.PV);
            command.Parameters.AddWithValue("@invulnerable", objectPartType.INVULNERABLE);
            command.Parameters.AddWithValue("@cutview", objectPartType.CUTVIEW);
            command.Parameters.AddWithValue("@lightning", objectPartType.LIGHTNING);
            command.Parameters.AddWithValue("@lightning_tiles", objectPartType.LIGHTNING_TILES);
            command.Parameters.AddWithValue("@lightning_factor", objectPartType.LIGHTNING_FACTOR);
            command.Parameters.AddWithValue("@lightswitch", objectPartType.LIGHTSWITCH);
            command.Parameters.AddWithValue("@lightswitch_status", false);
            command.Parameters.AddWithValue("@traspassable", objectPartType.TRASPASSABLE);

            command.ExecuteNonQuery();

            command = new SqlCommand("INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS] ([OBJECT], [OBJECT_PART])" +
               "VALUES (@objectuid, @partuid)", connection);
            command.Parameters.AddWithValue("@objectuid", objectGuid.ToString());
            command.Parameters.AddWithValue("@partuid", objectPartGuid.ToString());

            command.ExecuteNonQuery();
        }
    }
}
