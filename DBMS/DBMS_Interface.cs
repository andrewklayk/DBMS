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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_newdb_Click(object sender, EventArgs e)
        {
            create_db_form createDbForm = new create_db_form();
            createDbForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect_form connectForm = new Connect_form();
            if (connectForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
        }
    }
}
