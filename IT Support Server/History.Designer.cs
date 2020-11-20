namespace Tracking_System
{
    partial class History
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sessionssessioninfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tracking_SystemDataSet = new Tracking_System.Tracking_SystemDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.sessions_session_infoTableAdapter = new Tracking_System.Tracking_SystemDataSetTableAdapters.Sessions_session_infoTableAdapter();
            this.tableAdapterManager1 = new Tracking_System.Tracking_SystemDataSetTableAdapters.TableAdapterManager();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engineernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipaddDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionssessioninfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracking_SystemDataSet)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.engineernameDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.ipaddDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn,
            this.macDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sessionssessioninfoBindingSource;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(6, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(928, 455);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // sessionssessioninfoBindingSource
            // 
            this.sessionssessioninfoBindingSource.DataMember = "Sessions_session_info";
            this.sessionssessioninfoBindingSource.DataSource = this.tracking_SystemDataSet;
            // 
            // tracking_SystemDataSet
            // 
            this.tracking_SystemDataSet.DataSetName = "Tracking_SystemDataSet";
            this.tracking_SystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(444, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 33);
            this.button1.TabIndex = 22;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(951, 25);
            this.fillByToolStrip.TabIndex = 23;
            this.fillByToolStrip.Text = "fillByToolStrip";
            this.fillByToolStrip.Visible = false;
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(23, 22);
            // 
            // sessions_session_infoTableAdapter
            // 
            this.sessions_session_infoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Sessions_session_infoTableAdapter = this.sessions_session_infoTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Tracking_System.Tracking_SystemDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "No.";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 5;
            // 
            // engineernameDataGridViewTextBoxColumn
            // 
            this.engineernameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.engineernameDataGridViewTextBoxColumn.DataPropertyName = "engineer_name";
            this.engineernameDataGridViewTextBoxColumn.HeaderText = "Engineer Name";
            this.engineernameDataGridViewTextBoxColumn.Name = "engineernameDataGridViewTextBoxColumn";
            this.engineernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.engineernameDataGridViewTextBoxColumn.Width = 5;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "user_name";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "User Name";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.usernameDataGridViewTextBoxColumn.Width = 5;
            // 
            // ipaddDataGridViewTextBoxColumn
            // 
            this.ipaddDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ipaddDataGridViewTextBoxColumn.DataPropertyName = "ip_add";
            this.ipaddDataGridViewTextBoxColumn.HeaderText = "IP Address";
            this.ipaddDataGridViewTextBoxColumn.Name = "ipaddDataGridViewTextBoxColumn";
            this.ipaddDataGridViewTextBoxColumn.ReadOnly = true;
            this.ipaddDataGridViewTextBoxColumn.Width = 5;
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            this.dateTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "Date_Time";
            this.dateTimeDataGridViewTextBoxColumn.HeaderText = "Date & Time";
            this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            this.dateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateTimeDataGridViewTextBoxColumn.Width = 5;
            // 
            // macDataGridViewTextBoxColumn
            // 
            this.macDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.macDataGridViewTextBoxColumn.DataPropertyName = "mac";
            this.macDataGridViewTextBoxColumn.HeaderText = "MAC";
            this.macDataGridViewTextBoxColumn.Name = "macDataGridViewTextBoxColumn";
            this.macDataGridViewTextBoxColumn.ReadOnly = true;
            this.macDataGridViewTextBoxColumn.Width = 5;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.Width = 76;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 526);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionssessioninfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracking_SystemDataSet)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private Tracking_SystemDataSet tracking_SystemDataSet;
        private System.Windows.Forms.BindingSource sessionssessioninfoBindingSource;
        private Tracking_SystemDataSetTableAdapters.Sessions_session_infoTableAdapter sessions_session_infoTableAdapter;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private Tracking_SystemDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn engineernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipaddDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn macDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}