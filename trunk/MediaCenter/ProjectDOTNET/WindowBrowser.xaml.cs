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
	public partial class WindowBrowser
	{
        private String aim;
        
        public WindowBrowser()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            browser.Source = new Uri("http://www.arenazero.net");
        }

        public WindowBrowser(String link)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            browser.Source = new Uri(link);
            aim = "";
        }

        public WindowBrowser(String link, String aim)
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.
            browser.Source = new Uri(link);
            this.aim = aim;
        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            closeImg.Opacity = 1;
        }

        private void closeImg_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            closeImg.Opacity = 0.7;
        }

        private void closeImg_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (aim.Equals("Games"))
            {
                WindowGames wg = new WindowGames();
                wg.WindowState = WindowState.Maximized;
                wg.Show();
            }
            this.Close();
        }
	}
}