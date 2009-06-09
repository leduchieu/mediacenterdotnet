using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using HUELLAS;

namespace ProjectDOTNET
{
    public class Telephones
    {
        String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        String apellidos;

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        int dni;

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        String handle;

        public String Handle
        {
            get { return handle; }
            set { handle = value; }
        }
        String telefono;

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        String image;

        public String Image
        {
            get { return image; }
            set { image = value; }
        }                    
    }

    public class TelephoneDB
    {
        String _dbname;
        SQLiteConnection _connection;
        public void setConnection(string dbname)
        {
            if (dbname == null)
                throw new NotDatabaseNameDefine();
            else
                _dbname = dbname;
            _connection = new SQLiteConnection();
            _connection.ConnectionString = "Data Source=" + _dbname;
            try
            {
                openConnection();
                SQLiteCommand mycommand = new SQLiteCommand(_connection);
                mycommand.CommandText = "select * from sqlite_master";
                SQLiteDataReader rdr = mycommand.ExecuteReader();
                bool found = false;
                while (rdr.Read() && !found)
                    if (rdr["name"].ToString() == "telephones") found = true;
                rdr.Close();
                if (!found)
                {
                    mycommand.CommandText = "CREATE  TABLE telephones (dni numeric primary key not null," +
                    " name VARCHAR   NOT NULL , telephone varchar  NOT NULL , handle varchar not null," +
                    "surname varchar,image varchar)";
                    mycommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public List<Telephones> readContacts()
        {
            List<Telephones> result = new List<Telephones>();
            try
            {
                openConnection();
                SQLiteCommand mycommand = new SQLiteCommand(_connection);
                mycommand.CommandText = "select * from telephones";
                SQLiteDataReader rdr = mycommand.ExecuteReader();
                while (rdr.Read())
                {
                    Telephones temp = new Telephones();
                    temp.Apellidos = rdr["surname"].ToString();
                    temp.Dni = Int32.Parse(rdr["dni"].ToString());
                    temp.Handle = rdr["handle"].ToString();
                    temp.Image = rdr["image"].ToString();
                    temp.Nombre = rdr["name"].ToString();
                    temp.Telefono = rdr["telephone"].ToString();
                    result.Add(temp);
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                closeConnection();

            }
            return result;
        }
        public void closeConnection()
        {
            _connection.Close();
        }

        public void openConnection()
        {
            _connection.Open();
        }

    }

}
