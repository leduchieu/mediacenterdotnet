using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;

namespace ProjectDOTNET
{
    class Rss
    {
        private String url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }
        private String imagen;

        public String Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    class RssLoader
    {
        private List<Rss> listOfRss;
        private IConfig configFile;
        public List<Rss> ListOfRss
        {
            get { return listOfRss; }
            set { listOfRss = value; }
        }
        public RssLoader()
        {
            listOfRss = new List<Rss>();
            
            configFile = new configSQL();
            configFile.setConnection("rss.db");
            try
            {
                SQLiteCommand mycommand = new SQLiteCommand();
                mycommand.CommandText = "select * from sqlite_master where name = @Name ";
                mycommand.Parameters.AddWithValue("@Name", "rss");
                
                if (configFile.Consult((DbCommand)mycommand).Count == 0 )
                {
                    mycommand.CommandText = "CREATE  TABLE rss (name VARCHAR PRIMARY KEY  NOT NULL , url VARCHAR NOT NULL , image VARCHAR NOT NULL )";
                    configFile.Execute(mycommand);
                }
                else
                    LoadRss();
            }
            catch (Exception e)
            {
            }
            finally
            {
            }
        }
        void LoadRss()
        {
            try
            {
                SQLiteCommand mycommand = new SQLiteCommand();
                mycommand.CommandText = "select * from rss";
                //List<List<object>> aux = configFile.Consult(mycommand);
                for (int i = 0; i < configFile.Consult((DbCommand)mycommand).Count; i++)
                       {
                        Rss temp = new Rss();
                        temp.Name = configFile.Consult(mycommand)[i][0].ToString();
                        temp.Imagen = configFile.Consult(mycommand)[i][2].ToString();
                        temp.Url = configFile.Consult(mycommand)[i][1].ToString();
                        listOfRss.Add(temp);
                    }
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}
