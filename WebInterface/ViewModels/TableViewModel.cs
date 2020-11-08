using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBMS;

namespace WebInterface.ViewModels
{
    public class TableViewModel
    {
        public string primaryKeyName;
        public string tableName;

        public string DatabaseName;
        public int RecordNumber;

        public List<RowViewModel> Rows { get; set; }
        public List<ColumnViewModel> Cols { get; set; }

        public TableViewModel(Table t)
        {
            primaryKeyName = t.PrimaryKeyName;
            tableName = t.TableName;
            DatabaseName = t.Database.DbParams.DBName;
            RecordNumber = t.recordNumber;
            Rows = t.Rows.Select(r => new RowViewModel(r)).ToList();
            Cols = t.Cols.Select(c => new ColumnViewModel(c)).ToList();
        }

        public Table GetTable(Database db)
        {
            Table t = new Table(tableName, 0, db);
            t.Rows = Rows.Select(r => r.ToTableRow(t)).ToList();
            t.Cols = Cols.Select(r => r.ToTableColumn()).ToList();
            return t;
        }
    }
}
