using DBMS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();
        }

        private void btn_newdb_Click(object sender, EventArgs e)
        {
            using (create_db_form createDbForm = new create_db_form())
            {
                createDbForm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Connect_form connectForm = new Connect_form())
            {
                if (connectForm.ShowDialog() == DialogResult.Cancel)
                {
                    Close();
                }
            }
            serv_label.Text += GlobalContext.masterParams.ServerName;
            GlobalContext.PopulateDatabaseList();
            DatabasesListBox.DataSource = GlobalContext.Databases.Select(x => x.DbParams.DBName).ToList();
        }

        private void DatabasesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = DatabasesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                GlobalContext.currentDb = GlobalContext.Databases[index];
                TablesListBox.DataSource = GlobalContext.Databases[index].Tables.Select(t => t.TableName).ToList(); ;
            }
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            Table t = new Table("dbo.Customers", 0, Global.databases[4]);
            t.TryRead(new SqlConnection(Database.BuildConnectionString(Global.databases[4].dbParams)));
        }*/

        private void TablesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = TablesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                GlobalContext.currentTable = GlobalContext.currentDb.Tables[index];
                dataGridView1.DataSource = GlobalContext.currentDb.Tables[index].ToDataTable();
                /*MessageBox.Show(Global.databases[Global.currentDb].tables[index].Rows[0].Values[1].ToString());
                //int rowCount = Global.databases[Global.currentDb].tables[index].columns[0].vales
                var columnNames = Global.databases[Global.currentDb].tables[index].columns.Select(x => x.name);
                List<List<object>> vals = new List<List<object>>();
                foreach (public TableColumn column in Global.databases[Global.currentDb].tables[index].Cols)
                {
                    table.Columns.Add()
                }*/
                //var cols = Global.databases[Global.currentDb].tables[index].columns;
                //var colsNumber = cols.Count;
                //foreach (Column col in cols)
                //{
                //    col.GetType();
                //    table.Columns.Add(col.name);
                //}
                //for(int i = 0; i < Global.databases[Global.currentDb].tables[index].recordNumber; i++)
                //{

                //    var row = table.Rows.Add();
                //    for (var j = 0; j < colsNumber; j++) 
                //    {
                //        var c = cols[j];
                //        switch (c.dataType.ToString())
                //        {
                //            case "integer":
                //                row[cols[j].name] = (cols[j] as Column<int>).values[i];
                //                break;
                //            case "varchar":
                //                row[cols[j].name] = (cols[j] as Column<string>).values[i];
                //                break;
                //            case "nvarchar":
                //                row[cols[j].name] = (cols[j] as Column<string>).values[i];
                //                break;
                //            case "char":
                //                row[cols[j].name] = (cols[j] as Column<char>).values[i];
                //                break;
                //            case "nchar":
                //                row[cols[j].name] = (cols[j] as Column<char>).values[i];
                //                break;
                //            case "float":
                //            case "real":
                //                row[cols[j].name] = (cols[j] as Column<double>).values[i];
                //                break;
                //            default: throw new Exception("Cannot parse type: " + c.dataType.ToString());
                //        }
                //    }
                //}
                //dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            object primaryKey = e.Row.Cells[GlobalContext.currentTable.PrimaryKeyName].Value;
            SqlConnection con = new SqlConnection(Database.BuildConnectionString(GlobalContext.currentTable.Database.DbParams));
            if (!GlobalContext.currentTable.TryDropRow(primaryKey, con))
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
        }

        private void deleteTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Delete table {TablesListBox.SelectedItem} ?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    GlobalContext.currentDb.DropTable(TablesListBox.SelectedItem.ToString());
                    TablesListBox.Refresh();
                    GlobalContext.currentTable = null;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Failed to drop table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new addTableForm();
            f.ShowDialog();
        }
    }
}
