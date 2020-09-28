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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 531);
            this.Controls.Add(this.btn_newdb);
            this.Name = "Form1";
            this.Text = "DBMS Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_newdb;
    }
}

