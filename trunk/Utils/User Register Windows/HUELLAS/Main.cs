using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;


namespace HUELLAS
{
    class Principal
    {
        [STAThread]
        static void Main(String[] args)
        {
            /*
            Sqlite x = new Sqlite();
           // SQLiteConnection.CreateFile("prueba.db");
            x.setConnection("prueba.db",null,null,null,0,0);
            x.insertUser("Prueba", "borrar");
            x.insertUser("david", "SS");
            if (x.getUsersFingerPrint().Count == 2) x.deleteUser("Prueba") ;
            */
            Nitgen x = new Nitgen();
            x.setupDB("SQLITE3", "prueba.db", null, null, null, 0, 0);
            x.initDevice("Auto_Detect");
            x.enrollUser("Borrar");
            String user = x.readFinger();
            Sqlite y = new Sqlite();
            y.setConnection("prueba.db", null, null, null, 0, 0);
            y.deleteUser(user);
         /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }
    }
}
