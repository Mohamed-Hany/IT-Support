using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomAlertBoxDemo
{
    public partial class Form_Alert : Form
    {
        public Form_Alert()
        {
            InitializeComponent();
        }
        public string ip { get; set; }

        private void Form_Alert_Load(object sender, EventArgs e)
        {
            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
            lblMsg.Text = ip + "  trying to connect";
            this.BackColor = Color.RoyalBlue;
            this.Show();
        }
    }
}
