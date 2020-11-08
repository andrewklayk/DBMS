namespace Interface
{
    partial class InterfaceForm
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
            this.btn_newdb = new System.Windows.Forms.Button();
            this.DatabasesListBox = new System.Windows.Forms.ListBox();
            this.serv_label = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TablesListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.addTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_newdb
            // 
            this.btn_newdb.Location = new System.Drawing.Point(808, 12);
            this.btn_newdb.Name = "btn_newdb";
            this.btn_newdb.Size = new System.Drawing.Size(94, 33);
            this.btn_newdb.TabIndex = 0;
            this.btn_newdb.Text = "New Database";
            this.btn_newdb.UseVisualStyleBackColor = true;
            this.btn_newdb.Click += new System.EventHandler(this.btn_newdb_Click);
            // 
            // DatabasesListBox
            // 
            this.DatabasesListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabasesListBox.FormattingEnabled = true;
            this.DatabasesListBox.ItemHeight = 17;
            this.DatabasesListBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d"});
            this.DatabasesListBox.Location = new System.Drawing.Point(12, 34);
            this.DatabasesListBox.Name = "DatabasesListBox";
            this.DatabasesListBox.Size = new System.Drawing.Size(106, 480);
            this.DatabasesListBox.TabIndex = 2;
            this.DatabasesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DatabasesListView_MouseDoubleClick);
            // 
            // serv_label
            // 
            this.serv_label.AutoSize = true;
            this.serv_label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serv_label.Location = new System.Drawing.Point(9, 9);
            this.serv_label.Name = "serv_label";
            this.serv_label.Size = new System.Drawing.Size(52, 17);
            this.serv_label.TabIndex = 3;
            this.serv_label.Text = "Server: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(808, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TablesListBox
            // 
            this.TablesListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.TablesListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.ItemHeight = 17;
            this.TablesListBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d"});
            this.TablesListBox.Location = new System.Drawing.Point(124, 34);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(106, 480);
            this.TablesListBox.TabIndex = 6;
            this.TablesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TablesListBox_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTableToolStripMenuItem,
            this.addTableToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // deleteTableToolStripMenuItem
            // 
            this.deleteTableToolStripMenuItem.Name = "deleteTableToolStripMenuItem";
            this.deleteTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteTableToolStripMenuItem.Text = "Delete table";
            this.deleteTableToolStripMenuItem.Click += new System.EventHandler(this.deleteTableToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(236, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(532, 480);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // addTableToolStripMenuItem
            // 
            this.addTableToolStripMenuItem.Name = "addTableToolStripMenuItem";
            this.addTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addTableToolStripMenuItem.Text = "Add table";
            this.addTableToolStripMenuItem.Click += new System.EventHandler(this.addTableToolStripMenuItem_Click);
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 531);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TablesListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serv_label);
            this.Controls.Add(this.DatabasesListBox);
            this.Controls.Add(this.btn_newdb);
            this.Name = "InterfaceForm";
            this.Text = "DBMS Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_newdb;
        private System.Windows.Forms.ListBox DatabasesListBox;
        private System.Windows.Forms.Label serv_label;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox TablesListBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteTableToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem addTableToolStripMenuItem;
    }
}

