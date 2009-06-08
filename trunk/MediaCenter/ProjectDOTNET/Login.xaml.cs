using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using HUELLAS;

namespace ProjectDOTNET
{
    
	public partial class Login
	{
        private IFinger fingerprintReader;
		public Login()
		{
			this.InitializeComponent();
            this.fingerprintReader = new Nitgen();
            this.fingerprintReader.setupDB("SQLITE3", "users.db", null, null, null, 0, 0);
            this.fingerprintReader.initDevice("Auto_Detect");
			// Insert code required on object creation below this point.
		}

        private void close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*Window2 w = new Window2();
            w.WindowState = WindowState.Maximized;
            w.Show();*/
            this.Close();
        }

        private void settingsClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void detectarHuella(object sender, RoutedEventArgs e)
        {
            String aux = this.fingerprintReader.readFinger();
            if (aux != null)
            {
                Settings.UserName = aux;
                Window2 w = new Window2();
                w.WindowState = WindowState.Maximized;
                w.Show();
                this.Close();
            }
        }
	}
}