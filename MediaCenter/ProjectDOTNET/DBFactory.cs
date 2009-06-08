using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HUELLAS
{
    class DBFactory
    {
        public static IDB createDB(string type)
        {
            switch (type)
            {
                case "SQLITE3":
                    return new Sqlite();
                default:
                    return new Sqlite();
            }
        }
    }
}
