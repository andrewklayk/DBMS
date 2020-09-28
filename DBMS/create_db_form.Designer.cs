namespace DBMS
{
    partial class create_db_form
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
            this.button1 = new System.Windows.Forms.Button();
            this.textbox_dbname = new System.Windows.Forms.TextBox();
            this.textbox_servername = new System.Windows.Forms.TextBox();
            this.textbox_dbfilename = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textbox_userid = new System.Windows.Forms.TextBox();
            this.textbox_userpwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textbox_dbname
            // 
            this.textbox_dbname.Location = new System.Drawing.Point(67, 38);
            this.textbox_dbname.Name = "textbox_dbname";
            this.textbox_dbname.Size = new System.Drawing.Size(100, 20);
            this.textbox_dbname.TabIndex = 1;
            // 
            // textbox_servername
            // 
            this.textbox_servername.Location = new System.Drawing.Point(67, 12);
            this.textbox_servername.Name = "textbox_servername";
            this.textbox_servername.Size = new System.Drawing.Size(100, 20);
            this.textbox_servername.TabIndex = 2;
            // 
            // textbox_dbfilename
            // 
            this.textbox_dbfilename.Location = new System.Drawing.Point(67, 64);
            this.textbox_dbfilename.Name = "textbox_dbfilename";
            this.textbox_dbfilename.Size = new System.Drawing.Size(100, 20);
            this.textbox_dbfilename.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(67, 90);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // textbox_userid
            // 
            this.textbox_userid.Location = new System.Drawing.Point(67, 116);
            this.textbox_userid.Name = "textbox_userid";
            this.textbox_userid.Size = new System.Drawing.Size(100, 20);
            this.textbox_userid.TabIndex = 5;
            // 
            // textbox_userpwd
            // 
            this.textbox_userpwd.Location = new System.Drawing.Point(67, 142);
            this.textbox_userpwd.Name = "textbox_userpwd";
            this.textbox_userpwd.Size = new System.Drawing.Size(100, 20);
            this.textbox_userpwd.TabIndex = 6;
            // 
            // create_db_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textbox_userpwd);
            this.Controls.Add(this.textbox_userid);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textbox_dbfilename);
            this.Controls.Add(this.textbox_servername);
            this.Controls.Add(this.textbox_dbname);
            this.Controls.Add(this.button1);
            this.Name = "create_db_form";
            this.Text = "New Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textbox_dbname;
        private System.Windows.Forms.TextBox textbox_servername;
        private System.Windows.Forms.TextBox textbox_dbfilename;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textbox_userid;
        private System.Windows.Forms.TextBox textbox_userpwd;
    }
}