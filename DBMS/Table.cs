using System.Collections.Generic;

namespace DBMS
{
    public class Table
    {
        public string name;
        //public int index;
        public string dbName;
        public List<Column> columns;

        public Table(string name, int index, string dbName)
        {
            this.name = name;
            //this.index = index;
            this.dbName = dbName;
            columns = new List<Column>();
        }

        public Table(string name, int index, string dbName, List<Column> columns) : this(name, index, dbName)
        {
            this.columns = columns;
        }

        /*public void AddColumn<T>(Column<T> a)
        {
            columns.Add(a);
            SqlConnection con = new SqlConnection();
            string sqlAddTableQuery;
            con.ConnectionString = BuildConnectionString(dbParams);
            sqlAddTableQuery = $"CREATE TABLE {a.name}"
        }*/
    }
}
