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

        private void button1_Click(object sender, EventArgs e)
        {
            DBParams dbParams = new DBParams(textbox_servername.Text, textbox_dbname.Text, textbox_dbname.Text, textbox_dbfilename.Text, "", "", textbox_userid.Text, textbox_userpwd.Text);
            DBParams masterDbParams = new DBParams(textbox_servername.Text, "master", "", "", "", "", textbox_userid.Text, textbox_userpwd.Text);
            Database newDB = new Database(dbParams);
            newDB.CreateDatabase(dbParams, masterDbParams);
        }
    }
}
