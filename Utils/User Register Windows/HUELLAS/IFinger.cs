using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HUELLAS
{
    public interface IFinger
    {
        string readFinger();
        void enrollUser(string user);
        string enrollUser();
        void setupDB(string type, string db, string host, string user, string pass, int port, int options);
        void initDevice(string options);
        void stopDevice();
        void setOptions(string options);
        string getOptions();
    }
}
