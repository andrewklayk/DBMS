using System;
using System.Collections.Generic;
using System.Linq;
using DBMS;
using System.Threading.Tasks;

namespace WebInterface.ViewModels
{
    public class RowViewModel
    {
        public List<object> Values { get; set; }
        public string OwnerTableName { get; set; }

        public RowViewModel(TableRow r)
        {
            this.Values = r.Values;
            this.OwnerTableName = r.OwnerTable.TableName;
        }

        public TableRow ToTableRow(Table t)
        {
            return new TableRow(Values, t);
        }
    }
}
