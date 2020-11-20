using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tracking_System
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        string connetionString = @"Data Source=130.7.1.24;Initial Catalog=Tracking_System;User ID=sa;Password=zxc-1234";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connetionString);
                string sql = "SELECT name FROM Tracking_System.dbo.Engineers_engineers WHERE domain_id='" + user_txt_box.Text + "' ";
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                SqlCommand sqlcom = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader sdr = sqlcom.ExecuteReader();
                sdr.Read();
                string ID = sdr["name"].ToString();
                conn.Close();
                if (ID != null)
                {
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    Hide();
                    try
                    {
                        Server_Form srv_form = new Server_Form();
                        srv_form.password = password_txt_box.Text;
                        srv_form.username = user_txt_box.Text;
                        srv_form.Show();
                    }
                    catch (Exception)
                    {
                        Server_Form srv_form = new Server_Form();
                        srv_form.username = user_txt_box.Text;
                        srv_form.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid username or password");
            }
            
        }
        private void TxetBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        private void TxetBox2_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxetBox_tab(this, new KeyEventArgs(Keys.Tab));
            }
        }
        private void TxetBox_tab(object sender, KeyEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

