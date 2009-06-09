using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using HUELLAS;

namespace ProjectDOTNET
{
	public partial class LoginSettings
	{
        public IFinger bd;
		public LoginSettings()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
            // Cargar la lista
            bd = new Nitgen();
            try
            {
                bd.setupDB("SQLITE3", "users.db", null, null, null, 0, 0);
                loadData();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
		}

        private void loadData()
        {
            this.listaUsers.Items.Clear();
            foreach (String aux in bd.getUsers())
            {
                ListBoxItem li = new ListBoxItem();
                li.Padding = new Thickness(4);
                li.Content = aux;
                this.listaUsers.Items.Add(li);
            }
        }

        private void addClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (tbUsers.Text.Trim() != "")
            {
                try
                {
                    bd.initDevice("auto_detect");
                    bd.enrollUser(this.tbUsers.Text);
                    this.tbUsers.Text = "";
                    this.listaUsers.Items.Clear();
                    loadData();
                    bd.stopDevice();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            else
                MessageBox.Show("Por favor, introduzca su nombre", "Falta nombre", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void removeClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            String user = listaUsers.SelectedItem.ToString();
            string[] substrings;
            char[] splitter = { ':' };
            substrings = user.Split(splitter);
            bd.removeUser(substrings[1].Trim());
            loadData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bd.stopDevice();
        }
	}
}