using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Tracking_System
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tracking_SystemDataSet.Sessions_session_info' table. You can move, or remove it, as needed.
            this.sessions_session_infoTableAdapter.Fill(this.tracking_SystemDataSet.Sessions_session_info);

        }
        public string VNC_password { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ip = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string vnc = @"""C:\\Program Files\\RealVNC\\VNC Viewer\\vncviewer.exe""";
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = string.Format("/c " + vnc + " " + ip);
            process.Start();
            Clipboard.SetText(VNC_password.ToString());
        }
    }
}
