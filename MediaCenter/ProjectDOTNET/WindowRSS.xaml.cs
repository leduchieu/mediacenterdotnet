using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProjectDOTNET
{
	public partial class WindowRSS
	{
       // private Image prueba;
        private RssLoader rsss;
        private List<Image> imageRss;
        private Storyboard _myStoryBoardMouseEnter = new Storyboard();
        private Storyboard _myStoryBoardMouseLeave = new Storyboard();
        private DoubleAnimation _doubleAnimationHeightLeave = new DoubleAnimation();
        private DoubleAnimation _doubleAnimationWidthLeave = new DoubleAnimation();          private DoubleAnimation _doubleAnimationWidth = new DoubleAnimation();
        private DoubleAnimation _doubleAnimationHeight = new DoubleAnimation();

		public WindowRSS()
		{
			this.InitializeComponent();
            // Insert code required on object creation below this point.
            //Image prueba;
            //prueba = new Image();
            //BitmapImage myBitmapImage = new BitmapImage();
            //myBitmapImage.BeginInit();

            //myBitmapImage.UriSource = new Uri(@"C:\Documents and Settings\Administrador\Mis documentos\Visual Studio Resources\Iconos\Breathless\128x128\apps\3d.png");
            //myBitmapImage.EndInit();
            //prueba.Source = myBitmapImage;
            //prueba.MouseDown += new System.Windows.Input.MouseButtonEventHandler(prueba_MouseDown);
            //this.PanelRSS.Children.Insert(1, prueba);
            rsss = new RssLoader();
            imageRss = new List<Image>();
            /************************************/
            double height = 70;
            double width = 70;

               _doubleAnimationWidth.To = 80;
               _doubleAnimationWidth.From = width;
               _doubleAnimationWidth.Duration = new Duration(new TimeSpan(0,0,0,3));
               _doubleAnimationWidth.BeginTime = new TimeSpan(0);
               //Storyboard.SetTarget(_doubleAnimationWidth, _rectangle);
               Storyboard.SetTargetProperty(_doubleAnimationWidth, new PropertyPath("(Rectangle.Width)"));
   
               _myStoryBoardMouseEnter.Children.Add(_doubleAnimationWidth);
   
               _doubleAnimationHeight.To = 80;
               _doubleAnimationHeight.From = height;
               _doubleAnimationHeight.Duration = new Duration(new TimeSpan(0, 0, 0, 3));
               _doubleAnimationHeight.BeginTime = new TimeSpan(0);
               _myStoryBoardMouseEnter.Children.Add(_doubleAnimationHeight);
               //Storyboard.SetTarget(_doubleAnimationHeight, _rectangle);
               Storyboard.SetTargetProperty(_doubleAnimationHeight, new PropertyPath("(Rectangle.Height)"));
   
               _doubleAnimationWidthLeave.To = width;
               _doubleAnimationWidthLeave.From = width;
               _doubleAnimationWidthLeave.Duration = new Duration(new TimeSpan(0, 0, 0, 3));
               _doubleAnimationWidthLeave.BeginTime = new TimeSpan(0);
               _myStoryBoardMouseLeave.Children.Add(_doubleAnimationWidthLeave);
             //  Storyboard.SetTarget(_doubleAnimationWidthLeave, _rectangle);
               Storyboard.SetTargetProperty(_doubleAnimationWidthLeave, new PropertyPath("(Rectangle.Width)"));
   
               _doubleAnimationHeightLeave.To = height;
               _doubleAnimationHeightLeave.From = height;
               _doubleAnimationHeightLeave.Duration = new Duration(new TimeSpan(0, 0, 0, 3));
              _doubleAnimationHeightLeave.BeginTime = new TimeSpan(0);
               _myStoryBoardMouseLeave.Children.Add(_doubleAnimationHeightLeave);
              // Storyboard.SetTarget(_doubleAnimationHeightLeave, _rectangle);
               Storyboard.SetTargetProperty(_doubleAnimationHeightLeave, new PropertyPath("(Rectangle.Height)"));
   
              // LayoutRoot.Children.Add(_rectangle);
               LayoutRoot.Resources.Add("leaveStoryBoard", _myStoryBoardMouseLeave);
               LayoutRoot.Resources.Add("enterStoryBoard", _myStoryBoardMouseEnter);

             /***********************************/
            loadNewRss();

            
		}

        private void loadNewRss()
        {                       
            foreach (Rss aux in this.rsss.ListOfRss)
            {
                Image prueba;
                prueba = new Image();
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();

                myBitmapImage.UriSource = new Uri(@aux.Imagen);
                
                myBitmapImage.EndInit();
                prueba.Source = myBitmapImage;
                prueba.Width = 70;
                prueba.Height = 70;
                prueba.MouseDown += new System.Windows.Input.MouseButtonEventHandler(prueba_MouseDown);
                this.PanelRSS.Children.Insert(0, prueba);
                this.imageRss.Add(prueba);
                prueba.MouseEnter+=new System.Windows.Input.MouseEventHandler(prueba_MouseEnter) ;
                prueba.MouseLeave += new System.Windows.Input.MouseEventHandler(prueba_MouseLeave) ;
            }
        }
        void prueba_MouseLeave(object sender, MouseEventArgs e)
           {
               int pos = imageRss.FindIndex(0, imageRss.Count, ((Image)sender).Equals);
               Storyboard.SetTarget(_doubleAnimationHeightLeave, imageRss[pos]);
               Storyboard.SetTarget(_doubleAnimationWidthLeave, imageRss[pos]);
               _doubleAnimationHeightLeave.From = imageRss[pos].Height;
               _doubleAnimationWidthLeave.From = imageRss[pos].Width;
               _myStoryBoardMouseLeave.Begin();
           }

      void prueba_MouseEnter(object sender, MouseEventArgs e)
           {
               int pos = imageRss.FindIndex(0, imageRss.Count, ((Image)sender).Equals);
               Storyboard.SetTarget(_doubleAnimationHeight, imageRss[pos]);
               Storyboard.SetTarget(_doubleAnimationWidth, imageRss[pos]);
               _doubleAnimationHeight.From = imageRss[pos].Height;
               _doubleAnimationWidth.From = imageRss[pos].Width;
              BeginStoryboard( _myStoryBoardMouseEnter);
           }

        void prueba_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int pos = imageRss.FindIndex(0, imageRss.Count, ((Image)sender).Equals);
            
            XmlDataProvider s = (XmlDataProvider)this.FindResource("RSSAZ");
            s.Source = new Uri(this.rsss.ListOfRss[0].Url);

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
            Window2 w1 = new Window2();
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