﻿using System;
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
            // Insert code required on object creation below this point.
            this.fingerprintReader = new Nitgen();
            this.fingerprintReader.setupDB("SQLITE3", "users.db", null, null, null, 0, 0);
            this.fingerprintReader.initDevice("Auto_Detect");
		}

        private void close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void settingsClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            LoginSettings ls = new LoginSettings();
            ls.Show();
        }

        private void detectarHuella(object sender, RoutedEventArgs e)
        {
            this.fingerprintReader.initDevice("auto_detect");
            String aux = this.fingerprintReader.readFinger();
            if (aux != null)
            {
                Settings.UserName = aux;
                Window2 w = new Window2();
                w.WindowState = WindowState.Maximized;
                w.Show();
                this.Close();
            }
            this.fingerprintReader.stopDevice();
        }
	}
}