
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDOTNET
{
    class Settings
    {
        private static string userName;
        private static bool volumen=true;

        public static bool Volumen
        {
            get { return Settings.volumen; }
            set { Settings.volumen = value; }
        }
        public static string UserName
        {
            get { return Settings.userName; }
            set { Settings.userName = value; }
        }
        public static void loadSettings()
        {

        }
        public static void saveSettings()
        {

        }
    }
}
