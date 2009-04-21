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
	public partial class WindowRSS
	{
		public WindowRSS()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}


        private void mvImg_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            XmlDataProvider s = (XmlDataProvider)this.FindResource("RSSAZ");
            s.Source = new Uri("http://feeds2.feedburner.com/mediavida/actualidad.rss");
        }

        private void AZImg_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            XmlDataProvider s = (XmlDataProvider)this.FindResource("RSSAZ");
            s.Source = new Uri("http://www.arenazero.net/feed/noticias.rss");
        }

        private void CloseImg_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseImg.Opacity = 1;
        }

        private void CloseImg_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseImg.Opacity = 0.70;
        }

        private void CloseImg_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.WindowState = WindowState.Maximized;
            w1.Show();
            this.Close();
        }

        private void meneameImg_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            XmlDataProvider s = (XmlDataProvider)this.FindResource("RSSAZ");
            s.Source = new Uri("http://feedproxy.google.com/MeneamePublicadas.rss");
        }

        private void listBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)listBox.SelectedItem;
            String link = xe.InnerXml.ToString();
            string[] substrings;
            char[] splitter = { '>','<' };
            substrings = link.Split(splitter);
            int i=0;
            foreach (String s in substrings)
            {
                if (s == "link")
                    break;
                else
                    i++;
            }
            WindowBrowser wb = new WindowBrowser(substrings[i+1]);
            wb.WindowState = WindowState.Maximized;
            wb.Show();
        }
	}
}