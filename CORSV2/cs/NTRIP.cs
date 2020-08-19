using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace CORSV2
{
    public class NTRIPClient : IDisposable
    {
        private Socket sckt;
        private string _username;
        private string _password;
        private IPEndPoint _broadcaster;
        byte[] rtcmDataBuffer = new byte[128];
        //IAsyncResult m_asynResult;
        public AsyncCallback pfnCallBack;
        public bool IsEnable;

        /// <summary>
        /// NTRIP server Username
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// NTRIP server password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// NTRIP Server
        /// </summary>
        public IPEndPoint BroadCaster
        {
            get { return _broadcaster; }
            set { _broadcaster = value; }
        }

        public NTRIPClient(IPEndPoint Server)
        {
            //Initialization...
            BroadCaster = Server;
            //InitializeSocket();
        }

        public NTRIPClient(IPEndPoint Server, string strUserName, string strPassword)
        {
            BroadCaster = Server;
            _username = strUserName;
            _password = strPassword;
            IsEnable = true;
            //InitializeSocket();
        }

        private void InitializeSocket()
        {
            sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }



        /// <summary>
        /// Creates request to NTRIP server
        /// </summary>
        /// <param name="strRequest">Resource to request. Leave blank to get NTRIP service data</param>
        private byte[] CreateRequest(string strRequest)
        {
            //Build request message
            string msg = "GET /" + strRequest + " HTTP/1.1\r\n";
            msg += "User-Agent: NTRIP Client\r\n";
            //If password/username is specified, send login details
            if (_username != null && _username != "")
            {
                string auth = ToBase64(_username + ":" + _password);
                msg += "Authorization: Basic " + auth + "\r\n";
            }
            msg += "Accept: */*\r\nConnection: close\r\n";
            msg += "\r\n";

            return System.Text.Encoding.ASCII.GetBytes(msg);
        }

        private void Connect()
        {
            //Connect to server	   
            if (!sckt.Connected)
                sckt.Connect(BroadCaster);
        }

        private void Close()
        {
            sckt.Shutdown(SocketShutdown.Both);
            sckt.Close();
        }

        public SourceTable GetSourceTable()
        {
            this.InitializeSocket();
            sckt.Blocking = true;
            this.Connect();
            sckt.Send(CreateRequest(""));
            //////自己试验
            //byte[] myresule = new Byte[1024];
            //NetworkStream nws = new NetworkStream(sckt);
            //StringBuilder sb = new StringBuilder();
            //int numobr = 0;
            //System.Threading.Thread.Sleep(1000);
            //do
            //{
            //    numobr = nws.Read(myresule, 0, myresule.Length);
            //    sb.Append( Encoding.ASCII.GetString(myresule, 0, myresule.Length));
            //}
            //while (nws.DataAvailable);

            //////

            string responseData = "";
            while (true)
            {
                byte[] buffer = new byte[1];
                int bytesRec = sckt.Receive(buffer);
                if (bytesRec == 0)
                {
                    break;
                }
                responseData += Encoding.ASCII.GetString(buffer, 0, bytesRec);
            }
            this.Close();

            if (!responseData.StartsWith("SOURCETABLE 200 OK"))
                return null;
            if (responseData.ToString().CompareTo("ENDSOURCETABLE") < 1)
                return null;

            SourceTable result = new SourceTable();
            foreach (string line in responseData.Split('\n'))
            {
                if (line.StartsWith("STR"))
                    result.DataStreams.Add(SourceTable.NTRIPDataStream.ParseFromString(line));
                else if (line.StartsWith("CAS"))
                    result.Casters.Add(SourceTable.NTRIPCaster.ParseFromString(line));
                else if (line.StartsWith("NET"))
                    result.Networks.Add(SourceTable.NTRIPNetwork.ParseFromString(line));
            }
            return result;
        }


        /// <summary>
        /// Opens the connection to the NTRIP server and starts receiving
        /// </summary>
        /// <param name="MountPoint">ID of Stream</param>
        private FileStream fs;
        private StreamWriter wr;
        private string RTCMSavePath;


        /// <summary>
        /// Stops receiving data from the NTRIP server
        /// </summary>
        public void StopNTRIP()
        {
            this.Close();
        }

        /// <summary>
        /// Apply AsciiEncoding to user name and password to obtain it as an array of bytes
        /// </summary>
        /// <param name="str">username:password</param>
        /// <returns>Base64 encoded username/password</returns>
        private string ToBase64(string str)
        {
            Encoding asciiEncoding = Encoding.ASCII;
            byte[] byteArray = new byte[asciiEncoding.GetByteCount(str)];
            byteArray = asciiEncoding.GetBytes(str);
            return Convert.ToBase64String(byteArray, 0, byteArray.Length);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Close();
        }

        #endregion
    }
}