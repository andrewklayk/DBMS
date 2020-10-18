using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Markup;

namespace DBMS
{
    public abstract class Column
    {
        public string name;
        public int index;
        public DbDataTypes dataType;
        public Table table;
        public Type type;

        protected Column(string name, int index, DbDataTypes dataType, Table table)
        {
            this.name = name;
            this.index = index;
            this.dataType = dataType;
            this.table = table;
        }
    }
    public class Column<T> : Column
    {
        public List<T> values;

        public Column(string name, int index, DbDataTypes type1, Table table, List<T> v, Type t = null) : base(name, index, type1, table)
        {
            type = t;
            values = v;
            
        }
    }

    public static class ColumnFactory
    {
        public static Column CreateColumn(string type, Table table, string name, List<object> values, int index)
        {
            switch (type)
            {
                case "smallint":
                case "int":
                    List<int> intList = values.Select(x => (int)x).ToList();
                    var integerColumn = new Column<int>(name, 1, DbDataTypes.integer, table, intList);
                    return integerColumn;
                case "real":
                case "float":
                    List<double> floatList = values.Select(x => (double)x).ToList();
                    var floatColumn = new Column<double>(name, 1, DbDataTypes.real, table, floatList);
                    return floatColumn;
                case "char":
                case "nchar":
                    var ncharList = values.Select(x => (string)x).ToList();
                    var ncharColumn = new Column<string>(name, 1, DbDataTypes.character, table, ncharList);
                    return ncharColumn;
                case "varchar":
                case "nvarchar":
                    List<string> strList = values.Select(x => x.ToString()).ToList();
                    var stringColumn = new Column<string>(name, 1, DbDataTypes.varchar, table, strList);
                    return stringColumn;
                case "datetime2":
                case "datetime":
                    strList = values.Select(x => x.ToString()).ToList();
                    stringColumn = new Column<string>(name, 1, DbDataTypes.varchar, table, strList);
                    return stringColumn;
                /*case DbDataTypes.dbenum:
                    var enumColumn = new Column<Dictionary<string, string>>(name, 1, DbDataTypes.dbenum, table);
                    return enumColumn;*/
                default: 
                    throw new Exception("Unable to detect type: " + type.ToString());
            }
        }
    }
}
