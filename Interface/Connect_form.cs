﻿using DBMS;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Interface
{
    public partial class Connect_form : Form
    {
        public Connect_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection masterConnection = new SqlConnection();
            try
            {
                masterConnection.ConnectionString = $"SERVER = {textbox_servername.Text}; User ID = {textbox_userid.Text}; Pwd = {textbox_userpwd.Text}";
                masterConnection.Open();
                GlobalContext.masterParams = new DBParams(textbox_servername.Text, "master", "", "", "", "", textbox_userid.Text, textbox_userpwd.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            finally
            {
                masterConnection.Close();
            }
        }

        private void toggle_pwd_btn_Click(object sender, EventArgs e)
        {
            textbox_userpwd.UseSystemPasswordChar = !textbox_userpwd.UseSystemPasswordChar;
        }
    }
}
