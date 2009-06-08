using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace ProjectDOTNET
{
	public partial class Login
	{
		public Login()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void close(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
	}
}