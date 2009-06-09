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
        FTPFactory ff = null;

        public WindowSettings()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
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
            ff.setRemoteHost("192.168.145.86");
            ff.setRemoteUser(user);
            ff.setRemotePass(password);
            ff.login();
        }

        private void newImages(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            textoInfo.Text = "Conectado al FTP";
            try {
               this.conectarFtp("prueba","prueba");
               ff.chdir("images");
               bool encontrado = false;
               textoInfo.Text = "Obteniendo lista de imagenes";
               string[] fileNames = ff.getFileList("*.*");
               List<String> downloads = new List<String>();
               PhotoList Photos = new PhotoList(".\\Images");
               string fn = "";
               for(int i=0;i < fileNames.Length-1;i++) {
                   foreach (ImageFile f in Photos)
                   {
                       fn = fileNames[i];
                       if (fn.EndsWith("\r"))
                           fn = fn.Remove(fn.Length - 1);
                       if (f.FileName().Equals(fn))
                       {
                           encontrado = true;
                           break;
                       }
                   }
                   if (encontrado)
                       encontrado = false;
                   else
                       downloads.Add(fn);
               }
               if (downloads.Count > 0)
               {
                   int imagenesDescargar = downloads.Count;
                   int imagenDescargando = 1;
                   Environment.CurrentDirectory = ".\\Images";
                   foreach (string s in downloads)
                   {
                       textoInfo.Text = "Descargando imagen " + imagenDescargando + " de " + imagenesDescargar;
                       ff.download(s);
                   }
                   Environment.CurrentDirectory = ".."; 
               }
               textoInfo.Text = "Tarea terminada correctamente";
               ff.close();
             } catch(Exception exc) {
                    Console.WriteLine("Caught Error :"+exc.Message);
                    textoInfo.Text = "Error de conexion FTP";
             }
        }

        private void newSongs(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                textoInfo.Text = "Conectado al FTP";
                this.conectarFtp("prueba", "prueba");
                ff.chdir("music");
                bool encontrado = false;
                textoInfo.Text = "Obteniendo lista de canciones";
                string[] fileNames = ff.getFileList("*.*");
                List<String> downloads = new List<String>();
                PhotoList Photos = new PhotoList(".\\Music");
                string fn = "";
                for (int i = 0; i < fileNames.Length - 1; i++)
                {
                    foreach (ImageFile f in Photos)
                    {
                        fn = fileNames[i];
                        if (fn.EndsWith("\r"))
                            fn = fn.Remove(fn.Length - 1);
                        if (f.ToString().Equals(fn))
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                        encontrado = false;
                    else
                        downloads.Add(fn);
                }
                if (downloads.Count > 0)
                {
                    int imagenesDescargar = downloads.Count;
                    int imagenDescargando = 1;
                    Environment.CurrentDirectory = ".\\Music";
                    foreach (string s in downloads)
                    {
                        textoInfo.Text = "Descargando cancion " + imagenDescargando + " de " + imagenesDescargar;
                        ff.download(s);
                    }
                    Environment.CurrentDirectory = "..";
                    textoInfo.Text = "Ninguna tarea pendiente";
                }
                ff.close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Caught Error :" + exc.Message);
                textoInfo.Text = "Error de conexion FTP";
            }
        }

        private void newVideos(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                textoInfo.Text = "Conectado al FTP";
                this.conectarFtp("prueba", "prueba");
                ff.chdir("videos");
                bool encontrado = false;
                textoInfo.Text = "Obteniendo lista de videos";
                string[] fileNames = ff.getFileList("*.*");
                List<String> downloads = new List<String>();
                VideoList Videos = new VideoList(".\\Images");
                string fn = "";
                for (int i = 0; i < fileNames.Length - 1; i++)
                {
                    foreach (VideoFile f in Videos)
                    {
                        fn = fileNames[i];
                        if (fn.EndsWith("\r"))
                            fn = fn.Remove(fn.Length - 1);
                        if (f.ToString().Equals(fn))
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado)
                        encontrado = false;
                    else
                        downloads.Add(fn);
                }
                if (downloads.Count > 0)
                {
                    int imagenesDescargar = downloads.Count;
                    int imagenDescargando = 1;
                    Environment.CurrentDirectory = ".\\Videos";
                    foreach (string s in downloads)
                    {
                        textoInfo.Text = "Descargando video " + imagenDescargando + " de " + imagenesDescargar;
                        ff.download(s);
                    }
                    Environment.CurrentDirectory = "..";
                    textoInfo.Text = "Ninguna tarea pendiente";
                }
                ff.close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Caught Error :" + exc.Message);
                textoInfo.Text = "Error de conexion FTP";
            }
        }
	}
}