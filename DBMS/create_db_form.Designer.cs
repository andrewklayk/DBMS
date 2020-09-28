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
            this.create_db_btn = new System.Windows.Forms.Button();
            this.textbox_dbname = new System.Windows.Forms.TextBox();
            this.textbox_servername = new System.Windows.Forms.TextBox();
            this.textbox_dbfilename = new System.Windows.Forms.TextBox();
            this.textbox_userid = new System.Windows.Forms.TextBox();
            this.textbox_userpwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toggle_pwd_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // create_db_btn
            // 
            this.create_db_btn.Location = new System.Drawing.Point(7, 205);
            this.create_db_btn.Margin = new System.Windows.Forms.Padding(4);
            this.create_db_btn.Name = "create_db_btn";
            this.create_db_btn.Size = new System.Drawing.Size(531, 42);
            this.create_db_btn.TabIndex = 0;
            this.create_db_btn.Text = "Create database";
            this.create_db_btn.UseVisualStyleBackColor = true;
            this.create_db_btn.Click += new System.EventHandler(this.create_db_btn_Click);
            // 
            // textbox_dbname
            // 
            this.textbox_dbname.Location = new System.Drawing.Point(117, 65);
            this.textbox_dbname.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_dbname.Name = "textbox_dbname";
            this.textbox_dbname.Size = new System.Drawing.Size(421, 22);
            this.textbox_dbname.TabIndex = 1;
            // 
            // textbox_servername
            // 
            this.textbox_servername.Location = new System.Drawing.Point(117, 15);
            this.textbox_servername.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_servername.Name = "textbox_servername";
            this.textbox_servername.Size = new System.Drawing.Size(421, 22);
            this.textbox_servername.TabIndex = 2;
            this.textbox_servername.Text = "localhost";
            // 
            // textbox_dbfilename
            // 
            this.textbox_dbfilename.Location = new System.Drawing.Point(117, 97);
            this.textbox_dbfilename.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_dbfilename.Name = "textbox_dbfilename";
            this.textbox_dbfilename.Size = new System.Drawing.Size(421, 22);
            this.textbox_dbfilename.TabIndex = 3;
            // 
            // textbox_userid
            // 
            this.textbox_userid.Enabled = false;
            this.textbox_userid.Location = new System.Drawing.Point(117, 143);
            this.textbox_userid.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_userid.Name = "textbox_userid";
            this.textbox_userid.Size = new System.Drawing.Size(421, 22);
            this.textbox_userid.TabIndex = 5;
            // 
            // textbox_userpwd
            // 
            this.textbox_userpwd.Enabled = false;
            this.textbox_userpwd.Location = new System.Drawing.Point(117, 175);
            this.textbox_userpwd.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_userpwd.Name = "textbox_userpwd";
            this.textbox_userpwd.Size = new System.Drawing.Size(421, 22);
            this.textbox_userpwd.TabIndex = 6;
            this.textbox_userpwd.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Database name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Database path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "User ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(4, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // toggle_pwd_btn
            // 
            this.toggle_pwd_btn.Enabled = false;
            this.toggle_pwd_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.toggle_pwd_btn.FlatAppearance.BorderSize = 0;
            this.toggle_pwd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toggle_pwd_btn.Location = new System.Drawing.Point(88, 175);
            this.toggle_pwd_btn.Name = "toggle_pwd_btn";
            this.toggle_pwd_btn.Size = new System.Drawing.Size(22, 22);
            this.toggle_pwd_btn.TabIndex = 12;
            this.toggle_pwd_btn.Text = "*";
            this.toggle_pwd_btn.UseVisualStyleBackColor = true;
            this.toggle_pwd_btn.Click += new System.EventHandler(this.toggle_pwd_btn_Click);
            // 
            // create_db_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(548, 254);
            this.Controls.Add(this.toggle_pwd_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_userpwd);
            this.Controls.Add(this.textbox_userid);
            this.Controls.Add(this.textbox_dbfilename);
            this.Controls.Add(this.textbox_servername);
            this.Controls.Add(this.textbox_dbname);
            this.Controls.Add(this.create_db_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "create_db_form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_db_btn;
        private System.Windows.Forms.TextBox textbox_dbname;
        private System.Windows.Forms.TextBox textbox_servername;
        private System.Windows.Forms.TextBox textbox_dbfilename;
        private System.Windows.Forms.TextBox textbox_userid;
        private System.Windows.Forms.TextBox textbox_userpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button toggle_pwd_btn;
    }
}