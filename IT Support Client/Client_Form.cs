using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.DirectoryServices.AccountManagement;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Tracking_System_Client
{
    public partial class Client_Form : Form
    {
        public Client_Form()
        {
            InitializeComponent();
        }

        string connetionString = @"Data Source=130.7.1.24;Initial Catalog=Tracking_System;User ID=sa;Password=zxc-1234";
        public string host , username, macAddresses, ip , eng_name,status;
        private static readonly HttpClient client = new HttpClient();

        public string get_host()
        {
            host = Dns.GetHostEntry(ip).HostName;
            return host;
        }
        private string Get_eng_name()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connetionString);
                string sql = "SELECT name FROM Tracking_System.dbo.Engineers_engineers WHERE Engineer_id = '" + txt_1.Text + "'";
                SqlCommand sqlcom = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader sdr = sqlcom.ExecuteReader();
                sdr.Read();
                eng_name = sdr["name"].ToString();
                conn.Close();
            }
            catch (Exception)
            {

            }
            return eng_name;
        }

        public  string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ips in host.AddressList)
            {
                if (ips.AddressFamily == AddressFamily.InterNetwork && ips.ToString().Contains("130.7."))
                {
                     ip = ips.ToString();
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private string GetMAC()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.Name.Contains("Ethernet") && (nic.OperationalStatus == OperationalStatus.Up))
                {
                    macAddresses = nic.GetPhysicalAddress().ToString();
                }
            }
            return macAddresses;
        }
        private string Get_username()
        {
             var name = UserPrincipal.Current;
            return name.ToString();
        }
        private string Server_Ip()
        {
            string engineer_id = txt_1.Text;
            SqlConnection conn = new SqlConnection(connetionString);
            string sql = "SELECT ip_add FROM Tracking_System.dbo.Engineers_engineers WHERE engineer_id = '" + engineer_id + "'";
            SqlCommand sqlcom = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader sdr = sqlcom.ExecuteReader();
            sdr.Read();
            string server = sdr["ip_add"].ToString();
            conn.Close();
            return server;
        }
        private int  Server_port()
        {
            string engineer_id = txt_1.Text;
            SqlConnection conn = new SqlConnection(connetionString);
            string sql = "SELECT port FROM Tracking_System.dbo.Engineers_engineers WHERE engineer_id = '" + engineer_id + "'";
            SqlCommand sqlcom = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader sdr = sqlcom.ExecuteReader();
            sdr.Read();
            string server_port = sdr["port"].ToString();
            conn.Close();
            return int.Parse(server_port);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (Thread.CurrentThread.IsAlive==false&&lbl_Eng.Text != "")
            {
                lbl_Eng.Text = "";
            }
            else //if(status == "disconnected")
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (status == "connected" && Thread.CurrentThread.IsAlive)
            {
                lbl_Eng.Text = "Engineer : " + Get_eng_name();
                
            }
            else //if(status == "disconnected")
            {

            }

        }

        public void Client_side()
        {
            try
            {
                //---data to send to the server---
                string textToSend = GetLocalIPAddress() + ":" + Get_username() + ":" + get_host() + ":" + GetMAC();

                //---create a TCPClient object at the IP and port no.---
                TcpClient client = new TcpClient(Server_Ip(), Server_port());
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = Encoding.Default.GetBytes(textToSend);

                //---send the text---
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.Default.GetString(buffer, 0, bytesRead);
                //MessageBox.Show(dataReceived);
                if (dataReceived.Contains("yes"))
                {
                    MessageBox.Show("Your request has been accepted");
                    status = "connected";
                    client.Close();
                }
                else if (dataReceived.Contains("no"))
                {
                    MessageBox.Show("Your request has been cancelled");
                    status = "disconnected";
                    client.Close();
                }

            }
            catch (Exception)
            {
               MessageBox.Show("Please Call 1010 To Get Support ID!");
            }
        }
        public void ClientTask()
        {
            Thread client_Task = new Thread(Client_side);
            client_Task.Start();
            Thread.Sleep(100);    
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            timer2.Start();
            if (txt_1.Text!=""&&lbl_Eng.Text=="")
            {
                ClientTask();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Please Call 1010 To Get Support ID!");   
            }

        }

        private void TxetBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_1_Click(this, new EventArgs());
            }
        }
    }
}







////---data to send to the server---
//string textToSend = "I need to connect " + GetLocalIPAddress();

////---create a TCPClient object at the IP and port no.---
//TcpClient client = new TcpClient(Server_Ip(), port);
//NetworkStream nwStream = client.GetStream();
//byte[] bytesToSend = Encoding.ASCII.GetBytes(textToSend);

////---send the text---
////MessageBox.Show(string.Format("I need to connect {0}",textToSend));
//nwStream.Write(bytesToSend, 0, bytesToSend.Length);

////---read back the text---
//byte[] bytesToRead = new byte[client.ReceiveBufferSize];
//int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
//MessageBox.Show("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
//client.Close();
//TcpClient client = new TcpClient(Server_Ip(), port);


//Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//clientSocket.Connect(Server_Ip(), port);
//clientSocket.Send(Encoding.ASCII.GetBytes("  need to connect"));
//int receiveLength = clientSocket.Receive(result);
//MessageBox.Show("Received : " + Encoding.ASCII.GetString(result, 0, receiveLength));
//string sendMessage = "client send Message Hello" + DateTime.Now;
//clientSocket.Send(Encoding.Default.GetBytes(sendMessage));