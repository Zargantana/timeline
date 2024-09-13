namespace RoomEditor
{
    public class ObjectType
    {
        public string UID;
        public string NAME;
        public int PV;
        public bool INVULNERABLE;

        public override string ToString()
        {
            return NAME;
        }
    }
}