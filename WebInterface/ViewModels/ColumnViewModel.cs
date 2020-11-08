using DBMS;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebInterface.ViewModels
{
    public class ColumnViewModel
    {
        private int index;
        private string sqlType;
        public string TypeName;

        public ColumnViewModel(TableColumn col)
        {
            this.index = col.index;
            this.TypeName = col.DataType.ToString();
            this.sqlType = col.SqlType;
            this.Name = col.Name;
        }

        public string Name { get; set; }
        //public Type DataType { get; set; }
        public TableColumn ToTableColumn()
        {
            return new TableColumn(index, Type.GetType(TypeName), sqlType, Name,false);
        }

    }
}
