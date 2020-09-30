using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBMS
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
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
            serv_label.Text += Global.masterParams.ServerName;
            Global.PopulateDatabaseList();
            DatabasesListBox.DataSource = Global.databaseNames;
            //DatabasesListView.
            /*foreach(Database db in Global.databases)
            {
                //DatabasesListView.Items.Add(new ListViewItem(Global.masterParams.ServerName));
                DatabasesListView.Items.Add(new ListViewItem(db.name));
            }*/
        }

        private void DatabasesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = DatabasesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                //string name = Global.databaseNames[index];
                //Global.databases[index].DeleteDatabase(Global.masterParams);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Column c1 = new Column<int>("Col1", 0, "INT");
            Column c2 = new Column<string>("Col2", 0, "VARCHAR(255)");
            List<Column> lc = new List<Column>
            {
                c1,
                c2
            };
            Table t = new Table("test", 0, Global.databaseNames[9], lc);
            Global.databases[8].AddTable(t);
        }
    }
}
