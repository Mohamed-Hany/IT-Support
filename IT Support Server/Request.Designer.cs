namespace Tracking_System
{
    partial class Request
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Request));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_requester_name = new System.Windows.Forms.TextBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.txt_eng_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.description_Box1 = new System.Windows.Forms.RichTextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.com_box_req_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Dup_txt_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "General Problems",
            "HIS Problems",
            "Internet Problems",
            "Network Problems",
            "PACS Problems",
            "PC Problems",
            "Printer Problems",
            "Software Problems"});
            this.comboBox1.Location = new System.Drawing.Point(141, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(276, 24);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Please type or select category";
            // 
            // txt_requester_name
            // 
            this.txt_requester_name.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_requester_name.Location = new System.Drawing.Point(141, 46);
            this.txt_requester_name.Name = "txt_requester_name";
            this.txt_requester_name.Size = new System.Drawing.Size(275, 23);
            this.txt_requester_name.TabIndex = 20;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.Location = new System.Drawing.Point(12, 49);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(119, 16);
            this.lbl_user.TabIndex = 19;
            this.lbl_user.Text = "Requester name";
            // 
            // txt_eng_name
            // 
            this.txt_eng_name.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_eng_name.Location = new System.Drawing.Point(141, 76);
            this.txt_eng_name.Name = "txt_eng_name";
            this.txt_eng_name.Size = new System.Drawing.Size(275, 23);
            this.txt_eng_name.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Engineer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Request Subject";
            // 
            // description_Box1
            // 
            this.description_Box1.Location = new System.Drawing.Point(12, 166);
            this.description_Box1.Name = "description_Box1";
            this.description_Box1.Size = new System.Drawing.Size(402, 27);
            this.description_Box1.TabIndex = 27;
            this.description_Box1.Text = "";
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(98, 199);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(104, 33);
            this.btn_start.TabIndex = 28;
            this.btn_start.Text = "Save";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(218, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 33);
            this.button1.TabIndex = 29;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Requester Description";
            // 
            // com_box_req_status
            // 
            this.com_box_req_status.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.com_box_req_status.FormattingEnabled = true;
            this.com_box_req_status.Items.AddRange(new object[] {
            "closed",
            "open"});
            this.com_box_req_status.Location = new System.Drawing.Point(141, 107);
            this.com_box_req_status.Name = "com_box_req_status";
            this.com_box_req_status.Size = new System.Drawing.Size(102, 24);
            this.com_box_req_status.Sorted = true;
            this.com_box_req_status.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Request Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(263, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Duplication";
            // 
            // Dup_txt_box
            // 
            this.Dup_txt_box.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dup_txt_box.Location = new System.Drawing.Point(359, 107);
            this.Dup_txt_box.MaxLength = 2;
            this.Dup_txt_box.Name = "Dup_txt_box";
            this.Dup_txt_box.Size = new System.Drawing.Size(57, 23);
            this.Dup_txt_box.TabIndex = 33;
            this.Dup_txt_box.UseWaitCursor = true;
            this.Dup_txt_box.WordWrap = false;
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 240);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Dup_txt_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.com_box_req_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.description_Box1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_eng_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_requester_name);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Request";
            this.Text = "Request ";
            this.Load += new System.EventHandler(this.Request_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_requester_name;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TextBox txt_eng_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox description_Box1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox com_box_req_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Dup_txt_box;
    }
}