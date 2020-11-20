﻿using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Tracking_System
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();
        }
        public string Requster_name { get; set; }
        public string eng_name { get; set; }
        public int sql_id { get; set; }

        string connetionString = @"Data Source=130.7.1.24;Initial Catalog=Tracking_System;User ID=sa;Password=zxc-1234";
        public async void post()
        {
            var content = "INPUT_DATA={operation:{details:{requester:" + txt_requester_name.Text + ",subject:" + comboBox1.Text + ",description:" + description_Box1.Text + ",technician:" + txt_eng_name.Text + ",status:"+ com_box_req_status.Text +",service:Email}}}&OPERATION_NAME=ADD_REQUEST&TECHNICIAN_KEY=26A52060-A548-4C00-A58A-8AA95AEDBFAC&format=json";
            string baseUrl = "http://130.7.1.24:8080/sdpapi/request";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            string responseAsString = await responseMessage.Content.ReadAsStringAsync();
            if (responseAsString.Contains("successfully"))
            {
                MessageBox.Show("Your request saved successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }
        public void Save_session_comment()
        {
                SqlConnection conn = new SqlConnection(connetionString);
                string sql =
                "UPDATE Tracking_System.dbo.Sessions_session_info SET comment='" + description_Box1.Text +"' WHERE id ='" + sql_id + "'";
                SqlCommand sqlcom = new SqlCommand(sql, conn);
                conn.Open();
                sqlcom.ExecuteNonQuery();
                conn.Close();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            Save_session_comment();
            post();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Request_Load(object sender, EventArgs e)
        {
            txt_requester_name.Text = Requster_name;
            txt_eng_name.Text = eng_name;
        }
    }
    
}