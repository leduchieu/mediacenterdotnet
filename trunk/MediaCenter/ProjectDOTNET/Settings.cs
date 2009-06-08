
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDOTNET
{
    class Settings
    {
        private static string userName;

        public static string UserName
        {
            get { return Settings.userName; }
            set { Settings.userName = value; }
        }
    }
}
