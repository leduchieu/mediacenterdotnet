using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Linq;
using System.Windows.Media.Imaging;

namespace ProjectDOTNET
{
	public partial class WindowPhone2
	{
        // Atributos declarados por mi
        private SKYPE4COMLib.Skype skype;
        private SKYPE4COMLib.Call llamada;
        private static TelefonosDataContext dataDC = new TelefonosDataContext();
        private ObservableTelefono listaTels;

        public SKYPE4COMLib.Skype Skype
        {
            get { return skype; }
            set { skype = value; }
        }

		public WindowPhone2()
		{
			this.InitializeComponent();
			// Insert code required on object creation below this point.
            skype = new SKYPE4COMLib.Skype();
            if (skype.Client.IsRunning == false)
            {
                skype.Client.Start(true, true);
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 15));
            }
            skype.Attach(9,true);       
            skype.SilentMode = true;
            llamada = null;
            // Base de datos
            listaTels = new ObservableTelefono(dataDC);
            foreach (Telefono t in listaTels)
                listaTelefonos.ItemsSource = listaTels;
		}

        private void updateBox(String text)
        {
            if (boxNumero.Text.Contains("Introduzca"))
                boxNumero.Text = text;
            else
                boxNumero.AppendText(text);
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("1");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("3");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("4");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("5");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("6");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("7");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("8");
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("9");
        }

        private void ButtonAst_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("*");
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("0");
        }

        private void ButtonAlm_Click(object sender, RoutedEventArgs e)
        {
            this.updateBox("#");
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            boxNumero.Text = "Introduzca número";
        }

        private void ButtonCall_Click(object sender, RoutedEventArgs e)
        {
            if (llamada == null)
            {
                if (boxNumero.Text.Contains("Introduzca"))
                    boxNumero.IsReadOnly = false;
                else
                {
                    if (boxNumero.IsReadOnly == true)
                        llamada = skype.PlaceCall(boxNumero.Text, "", "", "");
                    else
                        llamada = skype.PlaceCall(boxNumero.Text, "", "", "");
                    boxNumero.IsReadOnly = true;
                    
                }
            }
        }

        private void listaTelefonos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Telefono t = listaTels[listaTelefonos.SelectedIndex];
            try
            {
                if (skype.get_User(t.Handle).OnlineStatus == SKYPE4COMLib.TOnlineStatus.olsOnline)
                    boxNumero.Text = t.Handle;
                else
                    boxNumero.Text = t.Telefono1;
                BitmapSource img = BitmapFrame.Create(new Uri(".\\Contacts\\" + t.Image,UriKind.Relative));
                contactPic.Source = img;
            }
            catch (Exception ex)
            {
                // Tratamiento aqui
            }            
        }

        private void ButtonHang_Click(object sender, RoutedEventArgs e)
        {
            if (llamada != null)
            {
                llamada.Finish();
                llamada = null;
            }
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
            Window1 w1 = new Window1();
            w1.WindowState = WindowState.Maximized;
            w1.Show();
            this.Close();
        }

	}
}