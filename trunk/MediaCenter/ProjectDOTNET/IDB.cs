using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HUELLAS
{
    public interface IDB
    {
        void setConnection(String dbname,String host, String user, String password, int port, int options);
        void closeConnection();
        void openConnection();
        void insertUser(String name, String fingerprint);
        void deleteUser(String name);
        List<String> getUsersFingerPrint();
        String getUser(String fingerprint);
        List<String> getUsers();
    }
}
