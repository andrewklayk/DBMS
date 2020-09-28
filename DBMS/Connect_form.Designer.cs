namespace DBMS
{
    partial class Connect_form
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
            this.toggle_pwd_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_userpwd = new System.Windows.Forms.TextBox();
            this.textbox_userid = new System.Windows.Forms.TextBox();
            this.textbox_servername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(8, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(374, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toggle_pwd_btn
            // 
            this.toggle_pwd_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.toggle_pwd_btn.FlatAppearance.BorderSize = 0;
            this.toggle_pwd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toggle_pwd_btn.Location = new System.Drawing.Point(88, 95);
            this.toggle_pwd_btn.Name = "toggle_pwd_btn";
            this.toggle_pwd_btn.Size = new System.Drawing.Size(40, 20);
            this.toggle_pwd_btn.TabIndex = 19;
            this.toggle_pwd_btn.Text = "*";
            this.toggle_pwd_btn.UseVisualStyleBackColor = true;
            this.toggle_pwd_btn.Click += new System.EventHandler(this.toggle_pwd_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(5, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "User ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Server Name";
            // 
            // textbox_userpwd
            // 
            this.textbox_userpwd.Location = new System.Drawing.Point(135, 95);
            this.textbox_userpwd.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_userpwd.Name = "textbox_userpwd";
            this.textbox_userpwd.Size = new System.Drawing.Size(247, 20);
            this.textbox_userpwd.TabIndex = 15;
            this.textbox_userpwd.UseSystemPasswordChar = true;
            // 
            // textbox_userid
            // 
            this.textbox_userid.Location = new System.Drawing.Point(135, 54);
            this.textbox_userid.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_userid.Name = "textbox_userid";
            this.textbox_userid.Size = new System.Drawing.Size(247, 20);
            this.textbox_userid.TabIndex = 14;
            // 
            // textbox_servername
            // 
            this.textbox_servername.Location = new System.Drawing.Point(135, 13);
            this.textbox_servername.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_servername.Name = "textbox_servername";
            this.textbox_servername.Size = new System.Drawing.Size(247, 20);
            this.textbox_servername.TabIndex = 13;
            this.textbox_servername.Text = "localhost";
            // 
            // Connect_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 180);
            this.Controls.Add(this.toggle_pwd_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_userpwd);
            this.Controls.Add(this.textbox_userid);
            this.Controls.Add(this.textbox_servername);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Connect_form";
            this.ShowIcon = false;
            this.Text = "Connect to a server";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button toggle_pwd_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_userpwd;
        private System.Windows.Forms.TextBox textbox_userid;
        private System.Windows.Forms.TextBox textbox_servername;
    }
}