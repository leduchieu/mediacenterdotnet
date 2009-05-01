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
	public partial class Window1
	{
        /// <summary>Variable para el reloj
        /// </summary>
        public System.Windows.Threading.DispatcherTimer myDispatcherTimer;

		public Window1()
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

        private void images_Click(object sender, RoutedEventArgs e)
        {
            WindowImages wi = new WindowImages();
            wi.WindowState = WindowState.Maximized;
            wi.Show();
            this.Close();
        }

        private void ResumeTimer(object sender, EventArgs e)
        {
            if (myDispatcherTimer != null)
                myDispatcherTimer.Start();
        }

        private void telefono_Click(object sender, RoutedEventArgs e)
        {
            WindowPhone wp = new WindowPhone();
            wp.WindowState = WindowState.Maximized;
            wp.Show();
            this.Close();
        }

        private void music_Click(object sender, RoutedEventArgs e)
        {
            WindowMusic wm = new WindowMusic();
            wm.WindowState = WindowState.Maximized;
            wm.Show();
            this.Close();
        }

        private void video_Click(object sender, RoutedEventArgs e)
        {
            WindowVideo wv = new WindowVideo();
            wv.WindowState = WindowState.Maximized;
            wv.Show();
            this.Close();
        }

        private void RSS_Click(object sender, RoutedEventArgs e)
        {
            WindowRSS wr = new WindowRSS();
            wr.WindowState = WindowState.Maximized;
            wr.Show();
            this.Close();
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            WindowCredits wc = new WindowCredits();
            wc.WindowState = WindowState.Maximized;
            wc.Show();
            this.Close();
        }

        private void juegos_Click(object sender, RoutedEventArgs e)
        {
            WindowGames wg = new WindowGames();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            this.Close();
        }
	}
}