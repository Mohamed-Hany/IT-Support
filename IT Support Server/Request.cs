using System;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Tracking_System
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();
            LDAPDomainName = GetDomainDN(IPGlobalProperties.GetIPGlobalProperties().DomainName);
            GetAllUsers();
        }
        public string Requster_name { get; set; }
        public string eng_name { get; set; }
        public int sql_id { get; set; }
        private string LDAPDomainName = string.Empty;


        string connetionString = @"Data Source=130.7.1.24;Initial Catalog=Tracking_System;User ID=sa;Password=zxc-1234";
        public async void post()
        {
            var content = "INPUT_DATA={operation:{details:{requester:" + comboBox2.Text + ",subject:" + comboBox1.Text + ",description:" + description_Box1.Text + ",technician:" + txt_eng_name.Text + ",status:" + com_box_req_status.Text + ",service:Email}}}&OPERATION_NAME=ADD_REQUEST&TECHNICIAN_KEY=26A52060-A548-4C00-A58A-8AA95AEDBFAC&format=json";
            string baseUrl = "http://130.7.1.24:8080/sdpapi/request";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            string responseAsString = await responseMessage.Content.ReadAsStringAsync();
            if (responseAsString.Contains("successfully"))
            {
                //MessageBox.Show("Your request saved successfully");
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }
        public void Save_session_comment()
        {
            if (sql_id != 0)
            {
                SqlConnection conn = new SqlConnection(connetionString);
                string sql =
                "UPDATE Tracking_System.dbo.Sessions_session_info SET comment='" + description_Box1.Text + "' WHERE id ='" + sql_id + "'";
                SqlCommand sqlcom = new SqlCommand(sql, conn);
                conn.Open();
                sqlcom.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(connetionString);
                string sql = "insert into Tracking_System.dbo.Sessions_session_info(engineer_name,ip_add,mac,user_name,comment) output INSERTED.ID values(@engineer_name,@ip_add,@mac,@user_name,@comment)";
                using (SqlCommand sqlcom = new SqlCommand(sql, con))
                {
                    sqlcom.Parameters.AddWithValue("@engineer_name", txt_eng_name.Text);
                    sqlcom.Parameters.AddWithValue("@ip_add", "0.0.0.0");
                    sqlcom.Parameters.AddWithValue("@mac", "ffffffffffff");
                    sqlcom.Parameters.AddWithValue("@user_name", comboBox2.Text);
                    sqlcom.Parameters.AddWithValue("@comment", description_Box1.Text);
                    con.Open();
                    sqlcom.ExecuteScalar();
                    con.Close();
                }
            }

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            Save_session_comment();
            if (Dup_txt_box.Text == "" || Dup_txt_box.Text == "0")
            {
                Dup_txt_box.Text = "1";
                for (int i = 0; i < int.Parse(Dup_txt_box.Text); i++)
                {
                    post();
                }
                MessageBox.Show("Your request saved successfully");
            }
            else
            {
                for (int i = 0; i < int.Parse(Dup_txt_box.Text); i++)
                {
                    post();
                }
                MessageBox.Show("Your request saved successfully");
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Request_Load(object sender, EventArgs e)
        {
            comboBox2.Text = Requster_name;
            txt_eng_name.Text = eng_name;
        }
        private string GetDomainDN(string domain)
        {
            DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain, domain);
            Domain d = Domain.GetDomain(context);
            DirectoryEntry de = d.GetDirectoryEntry();
            return de.Properties["DistinguishedName"].Value.ToString();
        }
        private void GetAllUsers()
        {
            SearchResultCollection results;
            DirectorySearcher ds = null;
            DirectoryEntry de = new
            DirectoryEntry("LDAP://" + LDAPDomainName);

            ds = new DirectorySearcher(de);
            ds.Filter = "(&(objectCategory=User)(objectClass=person))";

            results = ds.FindAll();
            foreach (SearchResult sr in results)
            {
                comboBox2.Items.Add(sr.Properties["name"][0].ToString());
            }
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        //public DirectoryEntry GetUser(string userName)
        //{
        //    DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + LDAPDomainName);
        //    DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
        //    directorySearcher.Filter = "(&(objectCategory=person)(sAMAccountName=" + userName + "))";
        //    DirectoryEntry result = directorySearcher.FindOne().GetDirectoryEntry();
        //    return result;
        //}
        //public static bool UserExists(string userName)
        //{
        //    using (var pc = new PrincipalContext(ContextType.Domain))
        //    using (var p = Principal.FindByIdentity(pc, IdentityType.SamAccountName, userName))
        //    {
        //        return p != null;
        //    }
        //}
        //private void GetUser()
        //{
        //    if (UserExists(txt_requester_name.Text))
        //    {
        //        username = txt_requester_name.Text;
        //        user = GetUser(username);
        //        fullname = String.Format("{0} {1}", user.Properties["givenName"].Value.ToString(), user.Properties["sn"].Value.ToString());
        //        txt_requester_name.Text = fullname;
        //    }
        //    else
        //    {
        //        txt_requester_name.Text = string.Empty;
        //        MessageBox.Show("User doesn't exist.");
        //    }
        //}
    }
    
}
