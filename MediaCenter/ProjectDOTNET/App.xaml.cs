using System;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace ProjectDOTNET
{
    public partial class App : System.Windows.Application
    {
        void MediaCenter_Startup(object sender, StartupEventArgs e)
        {
            Window1 window = new Window1();
            window.WindowState = WindowState.Maximized;
            window.Show();
        }
    }
}
