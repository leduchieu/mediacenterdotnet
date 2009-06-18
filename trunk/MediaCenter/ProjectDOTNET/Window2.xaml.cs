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

namespace ProjectDOTNET
{
	public partial class Window2
	{
        /// <summary>Variable para el reloj
        /// </summary>
        public System.Windows.Threading.DispatcherTimer myDispatcherTimer;
        private int horas;
        private int minutos;
        private int segundos;
        private int inactivo;

        /// <summary>
        /// Variable para saber qué esta cargado
        /// </summary>
        private string selected = "images";

        /// <summary>
        /// Variable para saber sonido
        /// </summary>
        private bool sonido = true;

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
            this.segundos = dt.Second;
            this.minutos = dt.Minute;
            this.horas = dt.Hour;
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
            inactivo = 0;
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
            if (segundos == 59)
            {
                segundos = 0;
                if (minutos == 59)
                {
                    minutos = 0;
                    if (horas == 23)
                        horas = 0;
                    else
                        horas++;
                }
                else
                    minutos++;
            }
            else
                segundos++;

            String seconds;
            if (segundos < 10)
                seconds = "0" + segundos;
            else seconds = "" + segundos;
            String minutes;
            if (minutos < 10)
                minutes = "0" + minutos;
            else minutes = "" + minutos;
            String hours;
            if (horas < 10)
                hours = "0" + horas;
            else hours = "" + horas;
            this.textTime.Text = hours+":"+minutes+":"+seconds;
            if (inactivo == 10)
            {
                myDispatcherTimer.Stop();
                WindowScreenSaver wsc = new WindowScreenSaver(this.sonido);
                wsc.WindowState = WindowState.Maximized;
                wsc.Show();
                this.Close();
            }
            else
                inactivo++;
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
            myDispatcherTimer.Stop();
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
            }//added
            else if (selected == "games")
            {
                Console.WriteLine("PASE");
                s = (Storyboard)this.FindResource("gamesUp");
                selected = "images";
            }
            if (s != null)
                this.BeginStoryboard(s);
        }

        private void actionDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Storyboard s = null;
            if (selected == "images")
            {
                s = (Storyboard)this.FindResource("imagesDown");
                selected = "games";
            }
            else if (selected == "music")
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

        private void noInactive(object sender, System.Windows.Input.MouseEventArgs e)
        {
            inactivo = 0;
        }

        private void changeVol(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            BitmapSource img = null;
            if (sonido)
                img = BitmapFrame.Create(new Uri(".\\Utils\\audio-volume-muted.png",UriKind.Relative));
            else
                img = BitmapFrame.Create(new Uri(".\\Utils\\stock_volume-max.png",UriKind.Relative));
            sonido = !sonido;
            this.imgVol.Source = img;
        }

        private void configClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowSettings ws = new WindowSettings();
            ws.WindowState = WindowState.Maximized;
            ws.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

  
        private void showMedicacion(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           // this.panelDrugs
            this.panelDrugs.Opacity = 100;
            this.panelDrugs.Visibility = Visibility.Visible;
        }

        private void imageClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selected != "images") return;
            Window wg = null;
            wg = new WindowImages();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

        private void musicClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selected != "music") return;
            Window wg = null;
            wg = new WindowMusic();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

        private void imageVideo_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selected != "video") return;
            Window wg = null;
            wg = new WindowVideo();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

        private void imageRSS_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selected != "news") return;
            Window wg = null;
            wg = new WindowRSS();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

        private void imagePhone_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selected != "phone") return;
            Window wg = null;
            wg = new WindowPhone();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

        private void imagePac_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void imagePac_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selected != "games") return;
            Window wg = null;
            wg = new WindowGames();
            wg.WindowState = WindowState.Maximized;
            wg.Show();
            myDispatcherTimer.Stop();
            this.Close();
        }

        /*
         *            Window wg = null;
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
            myDispatcherTimer.Stop();
            this.Close();
         * */
    }
}