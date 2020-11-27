using System;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Windows.Forms;

namespace Tracking_System
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        string connetionString = @"Data Source=130.7.1.24;Initial Catalog=Tracking_System;User ID=sa;Password=zxc-1234";

        int ID = 0;
        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tracking_SystemDataSet1.Engineers_engineers' table. You can move, or remove it, as needed.
            this.engineers_engineersTableAdapter.Fill(this.tracking_SystemDataSet1.Engineers_engineers);

        }

        private void ClearData()
        {
            txt_name.Text = "";
            txt_id.Text = "";
            txt_domain.Text = "";
            txt_ip.Text = "";
            txt_port.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connetionString);
            string sql = "insert into Tracking_System.dbo.Engineers_engineers(name, ip_add, engineer_id, domain_id, port) values(@name,@ip_add,@engineer_id,@domain_id,@port)";
                using (SqlCommand sqlcom = new SqlCommand(sql, con))
                {
                    sqlcom.Parameters.AddWithValue("@name", txt_name.Text);
                    sqlcom.Parameters.AddWithValue("@ip_add",txt_ip.Text);
                    sqlcom.Parameters.AddWithValue("@engineer_id", txt_id.Text);
                    sqlcom.Parameters.AddWithValue("@domain_id", txt_domain.Text);
                    sqlcom.Parameters.AddWithValue("@port", txt_port.Text);
                    con.Open();
                    sqlcom.ExecuteScalar();
                    con.Close();
                }
            MessageBox.Show("New Engineer add Successfully!");
            this.engineers_engineersTableAdapter.Fill(this.tracking_SystemDataSet1.Engineers_engineers);
            ClearData();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_domain.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_ip.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_port.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connetionString);
            if (ID != 0)
            {
                SqlCommand cmd = new SqlCommand("delete from Tracking_System.dbo.Engineers_engineers where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                this.engineers_engineersTableAdapter.Fill(this.tracking_SystemDataSet1.Engineers_engineers);
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connetionString);
            string sql =
                "UPDATE Tracking_System.dbo.Engineers_engineers SET name='" + txt_name.Text +
                "',ip_add ='"+ txt_ip.Text + "',engineer_id ='" + txt_id.Text+ "',domain_id ='" + txt_domain.Text +
                "',port='"+ txt_port.Text + "' WHERE id ='" + ID + "'";
            SqlCommand sqlcom = new SqlCommand(sql, con);
            con.Open();
            sqlcom.ExecuteScalar();
            con.Close();
            MessageBox.Show("Record Updated Successfully!");
            this.engineers_engineersTableAdapter.Fill(this.tracking_SystemDataSet1.Engineers_engineers);
            ClearData();
        }

        private void txt_port_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_port.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_port.Text = txt_port.Text.Remove(txt_port.Text.Length - 1);
            }
        }
    }
}
