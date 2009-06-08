using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

using System.Windows.Documents;
using System.Windows.Shapes;
using System.Collections;
using System.Windows.Media.Imaging;

namespace ProjectDOTNET
{
	public partial class WindowImages
	{
        /// <summary>
        /// Lista para cargar las fotografias
        /// </summary>
        private PhotoList Photos;
        /// <summary>
        /// Fotografía mostrada en un momento concreto
        /// </summary>
        private int currentPic;
        /// <summary>
        /// Dispatcher para pasar de fotos cada 5 segundos
        /// </summary>
        private System.Windows.Threading.DispatcherTimer myDispatcherTimer2;
        /// <summary>
        /// Indica si la transicion esta activa o no
        /// </summary>
        private bool playing = false;

        /// <summary>Constructor de la clase WindowImages
        /// <para>Carga la carpeta \Images en la lista</para>
        /// </summary>
        public WindowImages()
		{
			this.InitializeComponent();
			// Insert code required on object creation below this point
            this.Photos = new PhotoList(".\\Images");

		}


        /// <summary>
        /// Al crear la ventana de imagenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void loadImages(object sender, RoutedEventArgs e)
        {
            BitmapSource img = BitmapFrame.Create(new Uri(Photos[0].Path.ToString()));
            image1.Source = img;
            currentPic = 1;
            StartTimer();
        }

        /// <summary>
        /// Dispatcher para cambiar las imagenes cada 5 segundos
        /// </summary>
        private void StartTimer()
        {
            myDispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 5, 0); // 5 seconds
            myDispatcherTimer2.Tick += new EventHandler(UpdatePhoto);
            myDispatcherTimer2.Start();
            playing = true;
        }

        /// <summary>
        /// Llama a UpdatePicture
        /// </summary>
        /// <param name="o"></param>
        /// <param name="sender"></param>
        private void UpdatePhoto(object o, EventArgs sender) 
        {
            this.UpdatePicture();
        }

        /// <summary>
        /// Crea una imagen de la foto en curso y le suma uno
        /// <para>Llama a la animacion para cambiar la transicion de fotos y modifica el valor de currentPic</para>
        /// </summary>
        private void UpdatePicture()
        {
            BitmapSource img = BitmapFrame.Create(new Uri(Photos[currentPic].Path.ToString()));
            if ((currentPic % 2) == 0)
            {
                image1.Source = img;
                Storyboard s;
                s = (Storyboard)this.FindResource("Storyboardimg2");
                this.BeginStoryboard(s);
            }
            else
            {
                image2.Source = img;
                Storyboard s;
                s = (Storyboard)this.FindResource("Storyboardimg1");
                this.BeginStoryboard(s);
            }
            if (currentPic == (Photos.Count - 1))
                currentPic = 0;
            else
                currentPic = currentPic + 1;
        }

        /// <summary>
        /// Aumenta la visibilidad del boton Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Stop.Opacity = 1;
        }

        /// <summary>
        /// Disminuye la visibilidad del boton Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Stop.Opacity = 0.65;
        }

        /// <summary>
        /// Pone en visible el menu al hacer doble clic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuLoad(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Play.Visibility == Visibility.Collapsed)
            {
                Play.Visibility = Visibility.Visible;
                Stop.Visibility = Visibility.Visible;
                Next.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                Cancel.Visibility = Visibility.Visible;
            }
            else
            {
                Play.Visibility = Visibility.Collapsed;
                Stop.Visibility = Visibility.Collapsed;
                Next.Visibility = Visibility.Collapsed;
                Back.Visibility = Visibility.Collapsed;
                Cancel.Visibility = Visibility.Collapsed;
            }
        }

        private void cancelEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cancel.Opacity = 1;
        }

        private void cancelLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cancel.Opacity = 0.65;
        }

        /// <summary>
        /// Crea una ventana principal y cierra la actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.WindowState = WindowState.Maximized;
            w1.Show();
            this.Close();
        }

        private void backEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Back.Opacity = 1;
        }

        private void backLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Back.Opacity = 0.65;
        }

        private void playEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Play.Opacity = 1;
        }

        private void playLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (playing == false)
                Play.Opacity = 0.65;
        }

        private void nextEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Next.Opacity = 1;
        }

        private void nextLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Next.Opacity = 0.65;
        }

        private void stopImgs(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDispatcherTimer2.Stop();
            Play.Opacity = 0.65;
            playing = false;
        }

        private void playImgs(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDispatcherTimer2.Start();
            Play.Opacity = 1;
            playing = true;
        }

        private void nextImg(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.UpdatePicture();
        }

        private void backImg(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (currentPic == 1)
                currentPic = Photos.Count - 1;
            else if (currentPic == 0)
            {
                if (Photos.Count > 1)
                    currentPic = Photos.Count - 2;
                else
                    currentPic = Photos.Count - 1;
            }
            else
            {
                currentPic = currentPic - 2;
            }
            this.UpdatePicture();
        }
	}
}