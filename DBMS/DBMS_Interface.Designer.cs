namespace DBMS
{
    partial class Form1
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
            this.btn_newdb = new System.Windows.Forms.Button();
            this.DatabasesListBox = new System.Windows.Forms.ListBox();
            this.serv_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.DatabasesListBox.FormattingEnabled = true;
            this.DatabasesListBox.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d"});
            this.DatabasesListBox.Location = new System.Drawing.Point(12, 34);
            this.DatabasesListBox.Name = "DatabasesListBox";
            this.DatabasesListBox.Size = new System.Drawing.Size(92, 485);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 531);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serv_label);
            this.Controls.Add(this.DatabasesListBox);
            this.Controls.Add(this.btn_newdb);
            this.Name = "Form1";
            this.Text = "DBMS Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_newdb;
        private System.Windows.Forms.ListBox DatabasesListBox;
        private System.Windows.Forms.Label serv_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

