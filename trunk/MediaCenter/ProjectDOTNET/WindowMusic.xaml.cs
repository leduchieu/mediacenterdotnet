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
	public partial class WindowMusic
	{
        private MusicList lista;
        private bool sonando;
        private bool block; // Blockea el slider

        // Esta variable dice el número de cancion que está sonando
        private int playingSong;

        // Dispatcher para el tiempo
        private System.Windows.Threading.DispatcherTimer myDispatcherTimer2;

        // Cambiar texto cada segundo
        private void StartTimer()
        {
            myDispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            myDispatcherTimer2.Interval = new TimeSpan(0, 0, 0, 1, 0); // 1 seconds
            myDispatcherTimer2.Tick += new EventHandler(UpdatePositionText);
        }

        private void UpdatePositionText(object o, EventArgs sender)
        {
            // Truco para que no salte la cancion
            block = true;
            sliderPos.Value = (int)MusicPlayer.Position.TotalMilliseconds;
            block = false;
            this.UpdatePositionText();
        }
        private void UpdatePositionText()
        {
            if (MusicPlayer.NaturalDuration != Duration.Automatic)
            {
                int actual = (int)MusicPlayer.Position.TotalSeconds;
                String actualmin = "";
                String actualsec = "";
                if ((actual / 60) < 10)
                    actualmin = "0" + (actual / 60);
                else
                    actualmin = (actual / 60).ToString();
                if ((actual % 60) < 10)
                    actualsec = "0" + (actual % 60);
                else
                    actualsec = (actual % 60).ToString();
                int total = (int)MusicPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                String totalmin = "";
                String totalsec = "";
                if ((total / 60) < 10)
                    totalmin = "0" + (total / 60);
                else
                    totalmin = (total / 60).ToString();
                if ((total % 60) < 10)
                    totalsec = "0" + (total % 60);
                else
                    totalsec = (total % 60).ToString();
                textPos.Text = actualmin + ":" + actualsec + "/" + totalmin + ":" + totalsec;
            }
        }

		public WindowMusic()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void windowLoad(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            this.lista = new MusicList(".\\Music");
            sonando = false;
            playingSong = 0;
            //Añadir los nombres a la lista sin el path
            foreach (MusicFile mf in lista)
            {
                ListBoxItem li = new ListBoxItem();
                //li.HorizontalAlignment = HorizontalAlignment.Center;
                li.Padding = new Thickness(4);
                li.Content = mf.ToString();
                this.listBoxSongs.Items.Add(li);
            }
            //Cargar y seleccionar la primera cancion
            MusicPlayer.Source = new Uri(lista[playingSong].Path, UriKind.Relative);
            listBoxSongs.SelectedIndex = playingSong;
            StartTimer();

        }

        private void nextSong()
        {
            if (playingSong == lista.Count-1)
                playingSong = 0;
            else
                playingSong++;
            listBoxSongs.SelectedIndex = playingSong;
        }

        private void backSong()
        {
            if (playingSong == 0)
                playingSong = lista.Count - 1;
            else
                playingSong--;
            listBoxSongs.SelectedIndex = playingSong;
        }

        private void stopEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StopMusic.Opacity = 1;
        }

        private void stopLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StopMusic.Opacity = 0.65;
        }

        private void cancelEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CancelMusic.Opacity = 1;
        }

        private void cancelLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CancelMusic.Opacity = 0.65;
        }

        private void closeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window2 w1 = new Window2();
            w1.WindowState = WindowState.Maximized;
            w1.Show();
            this.Close();
        }

        private void backEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackMusic.Opacity = 1;
        }

        private void backLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackMusic.Opacity = 0.65;
        }

        private void playEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            PlayMusic.Opacity = 1;
        }

        private void playLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sonando == false)
                PlayMusic.Opacity = 0.65;
        }

        private void nextEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NextMusic.Opacity = 1;
        }

        private void nextLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NextMusic.Opacity = 0.65;
        }

        private void stopSong(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sonando == true)
            {
                MusicPlayer.Stop();
                PlayMusic.Opacity = 0.65;
                sliderPos.Value = 0;
                myDispatcherTimer2.Stop();
                this.UpdatePositionText();
                sonando = false;
            }
        }

        private void backSong(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.backSong();
            MusicPlayer.Source = new Uri(lista[playingSong].Path, UriKind.Relative);
        }

        private void playSong(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sonando == false)
            {
                MusicPlayer.Play();
                sonando = true;
                myDispatcherTimer2.Start();
                listBoxSongs.SelectedIndex = playingSong;
            }
            else
            {
                MusicPlayer.Pause();
                sonando = false;
                myDispatcherTimer2.Stop();
            }
        }

        private void nextSong(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.nextSong();
            MusicPlayer.Source = new Uri(lista[playingSong].Path, UriKind.Relative);
        }

        private void UpdateTimeSlider()
        {
            sliderPos.Value = 0;
            sliderPos.Maximum = MusicPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        }
        private void changePosition(object sender, RoutedEventArgs e)
        {
            if (block != true)
            {
                UpdatePositionText();
                int posValue = (int)sliderPos.Value;
                TimeSpan ts = new TimeSpan(0, 0, 0, 0, posValue);
                MusicPlayer.Position = ts;
            }
        }

        private void changeVolume(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Volume = sliderVol.Value;
        }

        private void nextSongEnd(object sender, RoutedEventArgs e)
        {
            this.nextSong();
            MusicPlayer.Source = new Uri(lista[playingSong].Path, UriKind.Relative);
            MusicPlayer.Play();
        }

        private void MusicPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            UpdateTimeSlider();
        }

        private void listBoxSongs_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            playingSong = listBoxSongs.SelectedIndex;
            MusicPlayer.Source = new Uri(lista[playingSong].Path, UriKind.Relative);
            MusicPlayer.Play();
            PlayMusic.Opacity = 1;
            sonando = true;
            myDispatcherTimer2.Start();
        }
	}
}