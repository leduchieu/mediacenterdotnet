using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using HUELLAS;
using System.Data.Common;

namespace ProjectDOTNET
{
    class configSQL : IConfig
    {
        #region Miembros de IConfig
        String _dbname;
        SQLiteConnection _connection;
        public void setConnection(string dbname, string host, string user, string password, int port, int options)
        {
            if (dbname == null)
                throw new NotDatabaseNameDefine();
            else
                _dbname = dbname;
            _connection = new SQLiteConnection();
            _connection.ConnectionString = "Data Source=" + _dbname;
            
        }

        public void closeConnection()
        {
            _connection.Close();
        }

        public void openConnection()
        {
            _connection.Open();
        }

        public void setConnection(string dbname)
        {
            if (dbname == null)
                throw new NotDatabaseNameDefine();
            else
                _dbname = dbname;
            _connection = new SQLiteConnection();
            _connection.ConnectionString = "Data Source=" + _dbname;
        }

        public void Execute(DbCommand query)
        {
            try
            {
                this.openConnection();
                query.Connection = _connection;
                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {                         

            }
            finally
            {                
                this.closeConnection();
            }
        }

        public List<List<object>> Consult(DbCommand query)
        {
            List<List<object>> result = new List<List<object>>();
            try
            {
                this.openConnection();
                query.Connection = _connection;
                SQLiteDataReader rdr = (SQLiteDataReader)query.ExecuteReader();
                while (rdr.Read())
                {
                    List<object> aux = new List<object>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                        aux.Add(rdr[i]);
                    result.Add(aux);
                }
                rdr.Close(); 
            }
            catch (Exception e)
            {             
             
            }
            finally
            {
                this.closeConnection();
            }
            return result;
        }

        #endregion
    }
}
