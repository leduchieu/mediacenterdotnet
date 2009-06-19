using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows;


namespace HUELLAS
{
    class Sqlite : IDB
    {
        #region Miembros de IDB
        String _dbname;
        SQLiteConnection _connection;

        public void setConnection(string dbname, string host, string user, string password, int port, int options)
        {
            if (dbname == null)
                throw new NotDatabaseNameDefine();
            else
                _dbname = dbname;
            _connection = new SQLiteConnection();
            _connection.ConnectionString="Data Source="+_dbname;
            try
            {
            openConnection();
            SQLiteCommand mycommand = new SQLiteCommand(_connection);
            mycommand.CommandText = "select * from sqlite_master";
            SQLiteDataReader rdr =mycommand.ExecuteReader();
            bool found = false;
            while (rdr.Read() && !found)
                if (rdr["name"].ToString() == "users") found = true;
            rdr.Close();
            if (!found)
            {
                mycommand.CommandText = "CREATE  TABLE users (name VARCHAR PRIMARY KEY  NOT NULL , fingerprint TEXT NOT NULL )";
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

        public void closeConnection()
        {
            _connection.Close();
        }

        public void openConnection()
        {
            _connection.Open();
        }

        public void insertUser(string name, string fingerprint)
        {
            try 
            {
                openConnection();
                SQLiteCommand mycommand = new SQLiteCommand(_connection);
                mycommand.CommandText = "insert into users (name, fingerprint) values (" +
          "@Name, @Fingerprint)";
                mycommand.Parameters.AddWithValue("@Name", name);
                mycommand.Parameters.AddWithValue("@Fingerprint", fingerprint);
                mycommand.ExecuteNonQuery();
                MessageBox.Show(mycommand.CommandText);
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

        public void deleteUser(string name)
        {
            try
            {
            openConnection();
            SQLiteCommand mycommand = new SQLiteCommand(_connection);
            mycommand.CommandText = "delete from users where name = @Name";
            mycommand.Parameters.AddWithValue("@Name", name);            
            mycommand.ExecuteNonQuery();
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

        public List<string> getUsersFingerPrint()
        {
            List<String> result = new List<string>();
            try 
            {
            openConnection();
            SQLiteCommand mycommand = new SQLiteCommand(_connection);
            mycommand.CommandText = "select fingerprint from users";
            SQLiteDataReader rdr = mycommand.ExecuteReader();
            while (rdr.Read())
                result.Add(rdr["fingerprint"].ToString());
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
        public List<String> getUsers()
        {
            List<String> result = new List<string>();
            try
            {
                openConnection();
                SQLiteCommand mycommand = new SQLiteCommand(_connection);
                mycommand.CommandText = "select name from users";
                SQLiteDataReader rdr = mycommand.ExecuteReader();
                while (rdr.Read())
                    result.Add(rdr["name"].ToString());
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


        public String getUser(String fingerprint)
        {
            String result =null;
            try
            {
                openConnection();
                SQLiteCommand mycommand = new SQLiteCommand(_connection);
                mycommand.CommandText = "select name from users where fingerprint = @Fingerprint";
                mycommand.Parameters.AddWithValue("@Fingerprint", fingerprint);
                SQLiteDataReader rdr = mycommand.ExecuteReader();
                if (rdr.Read())
                    result = rdr["name"].ToString();
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
        #endregion
    }
}
