using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class create_db_form : Form
    {
        public create_db_form()
        {
            InitializeComponent();
        }

        private void create_db_btn_Click(object sender, EventArgs e)
        {
            if (textbox_servername.Text == ""/* || 
                textbox_dbfilename.Text == "" */|| 
                textbox_dbname.Text == ""/* || 
                textbox_userid.Text == "" ||
                textbox_userpwd.Text == ""*/)
            {
                MessageBox.Show("Fill in all the required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DBParams dbParams = new DBParams(textbox_servername.Text, textbox_dbname.Text, textbox_dbname.Text,
                                             textbox_dbfilename.Text, "", "", textbox_userid.Text, textbox_userpwd.Text);
            Database newDB = new Database(dbParams);
            newDB.CreateDatabase(Global.masterParams);
            Global.databases.Add(newDB);
        }

        private void toggle_pwd_btn_Click(object sender, EventArgs e)
        {
            textbox_userpwd.UseSystemPasswordChar = !textbox_userpwd.UseSystemPasswordChar;
        }
    }
}
