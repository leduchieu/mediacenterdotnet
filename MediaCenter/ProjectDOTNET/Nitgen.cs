using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NITGEN.SDK.NBioBSP;

namespace HUELLAS
{
    class Nitgen : IFinger
    {
        NBioAPI m_NBioAPI;

        short m_OpenedDeviceID;
        //NBioAPI.Type.HFIR m_hNewFIR;

        NBioAPI.Type.FIR m_biFIR;
        NBioAPI.Type.FIR_TEXTENCODE m_textFIR;
        IDB db;

        #region Miembros de IFinger
        public Nitgen()
        {
            m_NBioAPI = new NBioAPI();
            m_textFIR = new NBioAPI.Type.FIR_TEXTENCODE();
        }
        public string readFinger()
        {
            uint ret;
            bool result = false;
            NBioAPI.Type.HFIR m_hNewFIR = new NBioAPI.Type.HFIR();
            List<String> listFingerprint = db.getUsersFingerPrint();
            foreach (String fingerprint in listFingerprint)
            {
                m_textFIR.TextFIR = fingerprint;
               
                ret = m_NBioAPI.Verify(m_textFIR, out result, null);
                if (ret == NBioAPI.Error.NONE && result)
                {
                    return db.getUser(fingerprint);
                }             
            }
            return null;
        }

        public void enrollUser(string user)
        {
            NBioAPI.Type.HFIR m_hNewFIR = new NBioAPI.Type.HFIR();
            NBioAPI.Type.FIR_PAYLOAD myPayload = new NBioAPI.Type.FIR_PAYLOAD();
            //myPayload.Data = textPayload.Text;

            uint ret = m_NBioAPI.Enroll(ref m_hNewFIR, out m_hNewFIR, null, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);

            if (ret == NBioAPI.Error.NONE)
            {
                // If you want to save fir data then this FIR data write to DB or File.

                // Get binary encoded FIR data
                m_NBioAPI.GetFIRFromHandle(m_hNewFIR, out m_biFIR);

                // Get text encoded FIR data
                m_NBioAPI.GetTextFIRFromHandle(m_hNewFIR, out m_textFIR, true);
                db.insertUser(user, m_textFIR.TextFIR);
                

            }
            else
            {
                throw new EnrollFail() ;
            }
        }

        public string enrollUser()
        {
            throw new NotImplementedException();
        }

        public void setupDB(string type, string db, string host, string user, string pass, int port, int options)
        {
            this.db = DBFactory.createDB(type);
            this.db.setConnection(db, host, user, pass, port, options);
        }

        #endregion

        #region Miembros de IFinger


        public void initDevice(string options)
        {
            short iDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;

            // Select device type
            string deviceName = options;
       
            switch (deviceName)
            {
                case "Auto_Detect":
                    iDeviceID = NBioAPI.Type.DEVICE_ID.AUTO;
                    break;
                case "FDP02":
                    iDeviceID = NBioAPI.Type.DEVICE_NAME.FDP02;
                    break;
                case "FDU01":
                    iDeviceID = NBioAPI.Type.DEVICE_NAME.FDU01;
                    break;
                case "OSU02":
                    iDeviceID = NBioAPI.Type.DEVICE_NAME.OSU02;
                    break;
                case "FDU11":
                    iDeviceID = NBioAPI.Type.DEVICE_NAME.FDU11;
                    break;
                case "FSC01":
                    iDeviceID = NBioAPI.Type.DEVICE_NAME.FSC01;
                    break;
                /*case "FDU03":
                    iDeviceID = NBioAPI.Type.DEVICE_NAME.FDU03;
                    break;*/
            }

            // Close Device if before opened
            m_NBioAPI.CloseDevice(m_OpenedDeviceID);
            
        
            // Open device
            uint ret = m_NBioAPI.OpenDevice(iDeviceID);
            if (ret == NBioAPI.Error.NONE)
            {
                m_OpenedDeviceID = iDeviceID;
                
            }
            else
            {
                throw new OpenFailed();
            }
        }

        public void stopDevice()
        {
            m_NBioAPI.CloseDevice(m_OpenedDeviceID);
        }

        public void setOptions(string options)
        {
            throw new NotImplementedException();
        }

        public string getOptions()
        {
            throw new NotImplementedException();
        }
        public List<String> getUsers()
        {
            return db.getUsers();
        }
        public void removeUser(String user)
    {
        db.deleteUser(user);
    }
        #endregion
    }
}
