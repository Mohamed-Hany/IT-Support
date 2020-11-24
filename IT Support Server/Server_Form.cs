using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading;
using CustomAlertBoxDemo;

namespace Tracking_System
{
    public partial class Server_Form : Form
    {
        string connetionString = @"Data Source=130.7.1.24;Initial Catalog=Tracking_System;User ID=sa;Password=zxc-1234";
        string old_ip ,new_ip , client_mac , client_name , client_pc , eng_name , thread_id , result ;
        public int modified;
        string[] client_data;
        private static readonly HttpClient client = new HttpClient();

        public string password { get; set; }
        public string username { get; set; }
        public Server_Form()
        {
            InitializeComponent();
        }
        
        
        private string Get_username()
        {
            var name = UserPrincipal.Current;
            return name.ToString();
        }
        public void Get_ID()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connetionString);
                string sql = "SELECT engineer_id FROM Tracking_System.dbo.Engineers_engineers WHERE ip_add = '" + GetLocalIPAddress() + "' and " + "domain_id = '" + username + "'";
                SqlCommand sqlcom = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader sdr = sqlcom.ExecuteReader();
                sdr.Read();
                ID.Text = sdr["engineer_id"].ToString();
                conn.Close();
            }
            catch (Exception)
            {
                SqlConnection conn = new SqlConnection(connetionString);
                string sql = "SELECT engineer_id FROM Tracking_System.dbo.Engineers_engineers WHERE ip_add = '" + GetLocalIPAddress() + "'";
                SqlCommand sqlcom = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader sdr = sqlcom.ExecuteReader();
                sdr.Read();
                ID.Text = sdr["engineer_id"].ToString();
                conn.Close();
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString().Contains("130.7.") ) 
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void ServerThread()
        {
            Thread SvrThread = new Thread(server);
            //SvrThread.Name = "server";
            SvrThread.Start();
            thread_id = SvrThread.ThreadState.ToString();
            Thread.Sleep(2000);
        }
        public void Save_session(string en_name,string cl_ip,string cl_mac,string cl_name)
        {
            SqlConnection con = new SqlConnection(connetionString);
            string sql = "insert into Tracking_System.dbo.Sessions_session_info(engineer_name,ip_add,mac,user_name) output INSERTED.ID values(@engineer_name,@ip_add,@mac,@user_name)";
            using (SqlCommand sqlcom = new SqlCommand(sql,con))
            {
                sqlcom.Parameters.AddWithValue("@engineer_name", en_name);
                sqlcom.Parameters.AddWithValue("@ip_add", cl_ip);
                sqlcom.Parameters.AddWithValue("@mac", cl_mac);
                sqlcom.Parameters.AddWithValue("@user_name", cl_name);
                con.Open();
                modified = (int)sqlcom.ExecuteScalar();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        private string Get_eng_name()
        {
            SqlConnection conn = new SqlConnection(connetionString);
            string sql = "SELECT name FROM Tracking_System.dbo.Engineers_engineers WHERE domain_id = '" + username + "'";
            SqlCommand sqlcom = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader sdr = sqlcom.ExecuteReader();
            sdr.Read();
            eng_name = sdr["name"].ToString(); 
            conn.Close();
            return eng_name;
        }

        private string Server_port()
        {
            SqlConnection conn = new SqlConnection(connetionString);
            string sql = "SELECT port FROM Tracking_System.dbo.Engineers_engineers WHERE engineer_id = '" + ID.Text + "'";
            SqlCommand sqlcom = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader sdr = sqlcom.ExecuteReader();
            sdr.Read();
            string server_port = sdr["port"].ToString();
            conn.Close();
            return server_port;
        }
        public void server()
        {
            int port = int.Parse(Server_port());
            ////---listen at the specified IP and port no.---
            IPAddress ipAddr = IPAddress.Any;
            TcpListener listener = new TcpListener(ipAddr, port);
            try
            {
                listener.Start();
            }
            catch (Exception)
            {
                //TcpClient client0 = new TcpClient(GetLocalIPAddress(), port);
                //client0.Close();
                //listener.Stop();
            }
            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();
            string client_ip = client.Client.RemoteEndPoint.ToString();
            string[] remote_ip = client_ip.Split(':');
            new_ip = remote_ip[0];
            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the data received into a string---
            string dataReceived = Encoding.Default.GetString(buffer, 0, bytesRead);
            client_data = dataReceived.Split(':');
            client_ip = client_data[0];
            client_name = client_data[1];
            client_pc = client_data[2];
            client_mac = client_data[3];
            if (lbl_stop.Visible == true)
            {
                client.Close();
                listener.Stop();
            }
            else
            {
                using (Form_Alert frm = new Form_Alert())
                {
                    frm.ip = new_ip;
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        result = "yes";
                    }
                    else
                    {
                        result = "no";
                    }
                }
                if (dataReceived.Contains("130.7."))
                {

                    //DialogResult dialogResult = MessageBox.Show(remote_ip[0] + "  trying to connect", "IT Support", MessageBoxButtons.YesNo);
                    if (result == "yes")//dialogResult == DialogResult.Yes)
                    {
                        byte[] bytesToSend = Encoding.Default.GetBytes("yes");
                        nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                        client.Close();
                        listener.Stop();
                        thread_id = null;
                        Save_session(eng_name, client_ip, client_mac, client_name);
                    }
                    else if (result == "no")//dialogResult == DialogResult.No)
                    {
                        byte[] bytesToSend = Encoding.Default.GetBytes("no");
                        nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                        client.Close();
                        listener.Stop();
                        thread_id = null;
                    }
                }
              }
            }
        
        public void vnc(string ip)
        {
            string vnc = @"""C:\\Program Files\\RealVNC\\VNC Viewer\\vncviewer.exe""";
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = string.Format("/c " + vnc + " " + ip);
            process.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_new_ip.Text = new_ip;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (thread_id != null)
            {
                
            }
            else
            {
                ServerThread();
            }
        }

        private  void btn_1_Click(object sender, EventArgs e)
        {
            //btn_stop.Visible = true;
            btn_stop.Enabled = true;
            txt_new_ip.Text="";
            new_ip = "";
            btn_start.Enabled = false;
            lbl_start.Visible = true;
            lbl_stop.Visible = false;
            lbl_ID.Enabled = true;
            ID.Enabled = true;
            ID.Visible = true;
            Get_ID();
            ServerThread();
            timer1.Start();
            timer2.Start();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }

        private void history_btn_Click(object sender, EventArgs e)
        {
            History his = new History();
            his.Show();
            his.VNC_password =password;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            btn_1_Click(sender,e);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            btn_stop_Click(sender, e);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            new_ip = "";
            timer1.Stop();
            timer2.Stop();
            //btn_stop.Visible = false;
            btn_start.Visible = true;
            btn_stop.Enabled = false;
            lbl_connected.Visible = true;
            btn_start.Enabled = true;
            ID.Enabled = false;
            lbl_stop.Visible = true;
        }

        private void btn_vnc_Click(object sender, EventArgs e)
        {
            if (txt_new_ip.Text != "" )
            {
                try
                {
                    Clipboard.SetText(password);
                }
                catch (Exception)
                {

                }
                vnc(txt_new_ip.Text);
                timer1.Stop();
                old_ip = txt_new_ip.Text;
                if ((Application.OpenForms["Request"] as Request) != null)
                {
                    Application.OpenForms["Request"].Activate();
                    WindowState = FormWindowState.Normal;
                }
                else
                {             
                    try
                    {
                        Request req = new Request();
                        req.Requster_name = client_data[1];
                        req.sql_id = modified;
                        req.eng_name = Get_eng_name();
                        req.Show();
                    }
                    catch (Exception)
                    {
                        Request req = new Request();
                        req.eng_name = Get_eng_name();
                        req.Show();
                    }
               }

            }
            else
            {
                MessageBox.Show("No one connected");
            }
                txt_old_ip.Text = old_ip;
        }

        private void Server_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible=false;
            Environment.Exit(0);
        }

        private void Server_Form_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            Get_eng_name();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Request"] as Request) != null)
            {
                Application.OpenForms["Request"].Activate();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                try
                {
                    Request req = new Request();
                    req.Requster_name = client_data[1];
                    req.eng_name = Get_eng_name();
                    req.Show();
                }
                catch (Exception)
                {
                    Request req = new Request();
                    req.eng_name = Get_eng_name();
                    req.Show();
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Hide();
        }
    }
}
//Process[] kill = Process.GetProcessesByName("server");
//foreach (Process p in kill) p.Kill();
//PopupNotifier pop = new PopupNotifier();
//pop.TitleText = "IT Support Server";
//pop.ContentText = new_ip + " is trying to connect";
//pop.Popup();
//public void server()
//{
//    Process process = new Process();
//    process.StartInfo.UseShellExecute = false;
//    process.StartInfo.CreateNoWindow = true;
//    process.StartInfo.FileName = "c:\\IT Support Server\\server.exe";
//    process.StartInfo.RedirectStandardOutput = true;
//    process.StartInfo.RedirectStandardError = true;
//    process.Start();
//    string output = process.StandardOutput.ReadToEnd();
//    new_ip=output.ToString();
//}
//IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 8081);
//Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
//listener.Bind(localEndPoint);
//listener.Listen(100);
//Socket clientSocket = listener.Accept();
//IPEndPoint client_ip = clientSocket.RemoteEndPoint as IPEndPoint;
//new_ip = client_ip.Address.ToString();
//byte[] buffer = new byte[1];
//int rec = clientSocket.Receive(buffer, 0, buffer.Length, 0);
//string asd = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
//Array.Resize(ref buffer,rec);
//for (int i = 0; i < asd.Length; i++)
//{
//    MessageBox.Show(new_ip + asd.ToString());
//}
//MessageBox.Show("Received from : " + buffer);