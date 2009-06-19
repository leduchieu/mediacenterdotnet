using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace ProjectDOTNET
{
    public interface IConfig
    {
        void setConnection(String dbname, String host, String user, String password, int port, int options);
        void closeConnection();
        void openConnection();
        void setConnection(String dbname);
        void Execute(DbCommand  query);
        List<List<Object>> Consult(DbCommand  query);
    }
}
