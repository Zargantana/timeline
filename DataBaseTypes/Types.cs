using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTypes
{
    public class Types
    {
        public static bool DBBoolToBoolean(string DBBool)
        {
            return ((DBBool != null) && (DBBool == "true")) ? true : false;
        }

        public static double DBDoubleToDouble(string DBDouble, double defaultvalue)
        {
            double moveSpeed = defaultvalue;
            Double.TryParse(DBDouble, out moveSpeed);
            return moveSpeed;
        }
    }
}
