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
    /// <summary>Clase que llama la aplicación al comenzar
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>Metodo al iniciar la aplicacion
        /// <para>Crea una ventana principal y la muestra a pantalla completa <see cref="System.Console.WindowState"/> para mas informacion sobre el estado de la ventana.</para>
        /// </summary>
        void MediaCenter_Startup(object sender, StartupEventArgs e)
        {
            //Window1 window = new Window1();
            Window2 window = new Window2();
            window.WindowState = WindowState.Maximized;
            window.Show();
        }
    }
}
