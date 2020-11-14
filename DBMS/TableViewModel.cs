using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public class TableViewModel
    {
        public int index;
        public string TableName { get; set; }
        public string PrimaryKeyColumn { get; set; }

        public List<string> ColumnNames { get; set; }
        public List<string> ColumnTypes { get; set; }
        public int RowCount { get; set; }

        public TableViewModel(Table t)
        {
            index = t.Database.Tables.IndexOf(t);
            TableName = t.TableName;
            PrimaryKeyColumn = t.PrimaryKeyName;
            ColumnNames = t.Cols.Select(x => x.Name).ToList();
            ColumnTypes = t.Cols.Select(x => x.SqlType).ToList();
            RowCount = t.Rows.Count;
        }
    }
}
