﻿using System;
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
	public partial class Window2
	{
        /// <summary>Variable para el reloj
        /// </summary>
        public System.Windows.Threading.DispatcherTimer myDispatcherTimer;

        /// <summary>
        /// Variable para saber qué esta cargado
        /// </summary>
        private string selected = "images";

        /// <summary>
        /// Constructor de window2
        /// </summary>
		public Window2()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        /// <summary>Metodo al iniciar la ventana principal
        /// <para>Obtiene la fecha y la muestra en el reloj <see cref="System.DateTime"/> para mas informacion sobre la hora.</para>
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            String seconds;
            if (dt.Second < 10)
                seconds = "0" + dt.Second;
            else seconds = "" + dt.Second;
            String minutes;
            if (dt.Minute < 10)
                minutes = "0" + dt.Minute;
            else minutes = "" + dt.Minute;
            String hours;
            if (dt.Hour < 10)
                hours = "0" + dt.Hour;
            else hours = "" + dt.Hour;
            this.textTime.Text = hours + ":" + minutes + ":" + seconds;
        }

        /// <summary>Metodo para iniciar el dispatcher
        /// <para>Cada segundo llama a la funcion changeTime <see cref="System.Windows.Threading.DispatcherTimer"/> para mas informacion sobre dispatchers.</para>
        /// </summary>
        private void StartTimer(object o, RoutedEventArgs sender)
        {
            myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0); // 1 second
            myDispatcherTimer.Tick += new EventHandler(changeTime);
            myDispatcherTimer.Start();
        }

        /// <summary>Metodo para cambiar la hora mostrada
        /// </summary>
        private void changeTime(object o, EventArgs sender)
        {
            DateTime dt = DateTime.Now;
            String seconds;
            if (dt.Second < 10)
                seconds = "0" + dt.Second;
            else seconds = ""+dt.Second;
            String minutes;
            if (dt.Minute < 10)
                minutes = "0" + dt.Minute;
            else minutes = "" + dt.Minute;
            String hours;
            if (dt.Hour < 10)
                hours = "0" + dt.Hour;
            else hours = "" + dt.Hour;
            this.textTime.Text = hours+":"+minutes+":"+seconds;
        }

        private void close_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ResumeTimer(object sender, EventArgs e)
        {
            if (myDispatcherTimer != null)
                myDispatcherTimer.Start();
        }

        private void text_Click(object sender, RoutedEventArgs e)
        {
            Window wg = null;
            switch (selected)
            {
                case "images": wg = new WindowImages(); break;
                case "music": wg = new WindowMusic(); break;
                case "videos": wg = new WindowVideo(); break;
                case "news": wg = new WindowRSS(); break;
                case "phone": wg = new WindowPhone(); break;
                case "games": wg = new WindowGames(); break;
            }
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            this.Close();
        }

        private void actionUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Storyboard s = null;
            if (selected == "images")
            {
                s = (Storyboard)this.FindResource("imagesUp");
                selected = "music";
            }
            else if (selected == "music")
            {
                s = (Storyboard)this.FindResource("musicUp");
                selected = "videos";
            }
            else if (selected == "videos")
            {
                s = (Storyboard)this.FindResource("videoUp");
                selected = "news";
            }
            else if (selected == "news")
            {
                s = (Storyboard)this.FindResource("newsUp");
                selected = "phone";
            }
            else if (selected == "phone")
            {
                s = (Storyboard)this.FindResource("phoneUp");
                selected = "games";
            }
            if (s != null)
                this.BeginStoryboard(s);
        }

        private void actionDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Storyboard s = null;
            if (selected == "music")
            {
                s = (Storyboard)this.FindResource("musicDown");
                selected = "images";
            }
            else if (selected == "videos")
            {
                s = (Storyboard)this.FindResource("videoDown");
                selected = "music";
            }
            else if (selected == "news")
            {
                s = (Storyboard)this.FindResource("newsDown");
                selected = "videos";
            }
            else if (selected == "phone")
            {
                s = (Storyboard)this.FindResource("phoneDown");
                selected = "news";
            }
            else if (selected == "games")
            {
                s = (Storyboard)this.FindResource("gamesDown");
                selected = "phone";
            }
            if (s != null)
                this.BeginStoryboard(s);
        }
	}
}