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
	public partial class WindowGames
	{
		public WindowGames()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            closeImg.Opacity = 1;
        }

        private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            closeImg.Opacity = 0.65;
        }

        private void closeImg_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.WindowState = WindowState.Maximized;
            w1.Show();
            this.Close();
        }

        private void imgShinju_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowBrowser wb = new WindowBrowser("http://games.mochiads.com/c/g/shinju/shellgame.swf","Games");
            wb.WindowState = WindowState.Maximized;
            wb.Show();
            this.Close();
        }

        private void imgShinju_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            imgShinju.Opacity = 1;
        }

        private void imgShinju_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            imgShinju.Opacity = 0.85;
        }

	}
}