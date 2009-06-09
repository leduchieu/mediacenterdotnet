using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Collections.Generic;

namespace ProjectDOTNET
{
	public partial class WindowSettings
	{
        private string texto = "";
        FTPFactory ff = null;
        private System.Windows.Threading.DispatcherTimer myDispatcherTimer2;

        public WindowSettings()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
            texto = "Ninguna tarea pendiente";
            StartTimer();
		}

        /// <summary>
        /// Dispatcher para cambiar las imagenes cada 5 segundos
        /// </summary>
        private void StartTimer()
        {
            myDispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 5, 0); // 5 seconds
            myDispatcherTimer2.Tick += new EventHandler(changeText);
            myDispatcherTimer2.Start();
        }

        /// <summary>
        /// Cambia el texto
        /// </summary>
        /// <param name="o"></param>
        /// <param name="sender"></param>
        private void changeText(object o, EventArgs sender)
        {
            this.textoInfo.Text = this.texto;
        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.closeImg.Opacity = 0.9;
        }

        private void closeImg_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.closeImg.Opacity = 0.7;
        }

        private void closeImg_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.WindowState = WindowState.Maximized;
            w2.Show();
            this.Close();
        }

        private void conectarFtp(string user, string password)
        {
            ff = new FTPFactory();
            ff.setDebug(true);
            ff.setRemoteHost("216.148.223.66");
            ff.setRemoteUser(user);
            ff.setRemotePass(password);
            ff.login();
        }

        private void newImages(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*try {
               this.conectarFtp("anonymous","");
               ff.chdir("images");
               bool encontrado = false;
               string[] fileNames = ff.getFileList("*.*");
               List<String> downloads = new List<String>();
               for(int i=0;i < fileNames.Length;i++) {
                   PhotoList Photos = new PhotoList(".\\Images");
                   foreach (ImageFile f in Photos)
                   {
                       if (f.FileName().Equals(fileNames[i]))
                       {
                           encontrado = true;
                           break;
                       }
                   }
                   if (encontrado)
                   {
                       encontrado = false;
                       downloads.Add(fileNames[i]);
                   }
               }
               int imagenesDescargar = downloads.Count + 1;
               int imagenDescargando = 1;
               Environment.CurrentDirectory = ".\\Images";
               foreach (string s in downloads)
               {
                   texto = "Descargando imagen "+ imagenDescargando +" de "+ imagenesDescargar;
                   ff.download(s, false);
               }
               Environment.CurrentDirectory = "..";
               texto = "Ninguna tarea pendiente";
               ff.close();
             } catch(Exception exc) {
               Console.WriteLine("Caught Error :"+exc.Message);
             }*/
            try
            {
                this.conectarFtp("anonymous", "");
                ff.chdir("pub\\WoW\\wallpapers");
                string[] fileNames = ff.getFileList("*.*");
                foreach (string s in fileNames)
                    Console.WriteLine(s);
                ff.download("alliance-1024x.zip");
                ff.close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Caught Error :" + exc.Message);
            }
        }

        private void newSongs(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.conectarFtp("anonymous", "");
                ff.chdir("music");
                bool encontrado = false;
                string[] fileNames = ff.getFileList("*.*");
                List<String> downloads = new List<String>();
                for (int i = 0; i < fileNames.Length; i++)
                {
                    MusicList songs = new MusicList(".\\Music");
                    foreach (MusicFile f in songs)
                    {
                        if (songs.ToString().Equals(fileNames[i]))
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                    {
                        encontrado = false;
                        downloads.Add(fileNames[i]);
                    }
                }
                int imagenesDescargar = downloads.Count + 1;
                int imagenDescargando = 1;
                Environment.CurrentDirectory = ".\\Music";
                foreach (string s in downloads)
                {
                    texto = "Descargando cancion " + imagenDescargando + " de " + imagenesDescargar;
                    ff.download(s, false);
                }
                Environment.CurrentDirectory = "..";
                texto = "Ninguna tarea pendiente";
                ff.close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Caught Error :" + exc.Message);
            }
        }

        private void newVideos(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.conectarFtp("anonymous", "");
                ff.chdir("videos");
                bool encontrado = false;
                string[] fileNames = ff.getFileList("*.*");
                List<String> downloads = new List<String>();
                for (int i = 0; i < fileNames.Length; i++)
                {
                    VideoList videos = new VideoList(".\\Videos");
                    foreach (VideoFile f in videos)
                    {
                        if (f.ToString().Equals(fileNames[i]))
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                    {
                        encontrado = false;
                        downloads.Add(fileNames[i]);
                    }
                }
                int imagenesDescargar = downloads.Count + 1;
                int imagenDescargando = 1;
                Environment.CurrentDirectory = ".\\Videos";
                foreach (string s in downloads)
                {
                    texto = "Descargando video " + imagenDescargando + " de " + imagenesDescargar;
                    ff.download(s, false);
                }
                Environment.CurrentDirectory = "..";
                texto = "Ninguna tarea pendiente";
                ff.close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Caught Error :" + exc.Message);
            }
        }
	}
}