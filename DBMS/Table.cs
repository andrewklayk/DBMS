using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace DBMS
{
    public class Table
    {

        //public int index;
        private Database database;
        public int recordNumber;
        public string TableName { get; set; }
        public string PrimaryKeyName { get; set; }

        public List<TableRow> Rows { get; set; }
        public List<TableColumn> Cols { get; set; }
        [JsonIgnore]
        public Database Database { get => database; set => database = value; }

        public Table() { }

        public Table(string tableName, int index, Database db)
        {
            this.TableName = tableName;
            //this.index = index;
            this.Database = db;
            recordNumber = 0;
            Cols = new List<TableColumn>();
            Rows = new List<TableRow>();
        }
        public Table(string tableName, Database database, List<TableRow> rows, List<TableColumn> cols)
        {
            this.TableName = tableName;
            this.Database = database;
            Rows = rows;
            Cols = cols;
        }

        /*public bool TryDeleteRow(int i, SqlConnection con)
        {
            this.Rows.RemoveAt(i);
            
        }*/

        public void AddRow(TableRow r, SqlConnection con)
        {
            /*for(int i = 0; i < Rows.Count; i++)
            {
                if(r.Values)
            }*/
            //using(SqlCommand com = new SqlCommand(con, $"UPDATE TABLE {TableName} "))
        }

        public bool TryRead(SqlConnection con)
        {
            recordNumber = 0;
            string sql = "SELECT ColumnName = col.column_name " +
                "FROM information_schema.table_constraints tc " +
                "INNER JOIN information_schema.key_column_usage col " +
                    "ON col.Constraint_Name = tc.Constraint_Name " +
                "AND col.Constraint_schema = tc.Constraint_schema " +
                $"WHERE tc.Constraint_Type = 'Primary Key' AND col.Table_name = '{TableName}'";
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                try
                {
                    var reader = com.ExecuteReader();
                    while (reader.Read())
                        PrimaryKeyName = ((IDataRecord)reader).GetString(0);
                    reader.Close();
                }
                catch
                {
                    return false;
                }
            }
            using (SqlCommand com = new SqlCommand($"SELECT * FROM {TableName}", con))
            {
                try
                {
                    var reader = com.ExecuteReader();
                    //var values = new List<List<object>>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var datarecord = ((IDataRecord)reader);
                        bool isPK = datarecord.GetName(i) == PrimaryKeyName;
                        Cols.Add(new TableColumn(i, datarecord.GetFieldType(i), datarecord.GetDataTypeName(i), datarecord.GetName(i), isPK));
                        //values.Add(new List<object>());
                    }
                    while (reader.Read())
                    {
                        var datarecord = ((IDataRecord)reader);
                        var a = new object[reader.FieldCount];
                        datarecord.GetValues(a);
                        /*for (int i = 0; i < reader.FieldCount; i++)
                        {
                            values[i].Add(datarecord.GetValue(i));
                        }*/
                        Rows.Add(new TableRow(a, this));
                        recordNumber++;
                    }
                    reader.Close();
                    /*
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns.Add(ColumnFactory.CreateColumn(((IDataRecord)reader).GetDataTypeName(i), this, ((IDataRecord)reader).GetName(i), values[i], i));
                    }*/
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool TryInsertIntoColumn<T>(Column<T> a, SqlConnection con, T value)
        {
            string sqlAddTableQuery = $"INSERT INTO {a.name} ";
            using (SqlCommand com = new SqlCommand(sqlAddTableQuery, con))
            {
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /*public bool TryAddColumn(Column a, SqlConnection con)
        {
            string sqlAddColumnQuery = $"ALTER TABLE {this.tableName} ADD COLUMN {a.name} {a.dataType}";
            using (SqlCommand com = new SqlCommand(sqlAddColumnQuery, con))
            {
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }*/

        public bool TryDropColumn(Column a, SqlConnection con)
        {
            string sqlAddTableQuery = $"ALTER TABLE {TableName} DROP COLUMN {a.name}";
            using (SqlCommand com = new SqlCommand(sqlAddTableQuery, con))
            {
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool TryDropRow(object pkey, SqlConnection con)
        {
            string sqlAddTableQuery = $"DELETE FROM {TableName} WHERE {PrimaryKeyName} = {pkey}";
            int ind = Cols.IndexOf(Cols.Where(c => c.Name == PrimaryKeyName).First());
            var row = Rows.RemoveAll(r => r.Values[ind].ToString() == pkey.ToString());
            using (SqlCommand com = new SqlCommand(sqlAddTableQuery, con))
            {
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public static Table Difference(Table a, Table b)
        {
            if (a.Cols.Count != b.Cols.Count)
                throw new Exception("Cannot compare tables with different column count");
            if (!a.Cols.Select(x => x.DataType).ToList().SequenceEqual(b.Cols.Select(x => x.DataType).ToList()))
                throw new Exception("Cannot compare tables with different column types");
            Table dif = new Table($"{a.TableName} diff {b.TableName}", GlobalContext.currentDb, new List<TableRow>(), a.Cols);
            for (int i = 0; i < a.Rows.Count; i++)
            {
                if (i >= b.Rows.Count)
                {
                    dif.Rows.Add(a.Rows[i]);
                }
                if (!a.Rows[i].Equals(b.Rows[i]))
                {
                    dif.Rows.Add(a.Rows[i]);
                    dif.Rows.Add(b.Rows[i]);
                }
            }
            if (a.Rows.Count < b.Rows.Count)
            {
                for (int i = a.Rows.Count; i < b.Rows.Count; i++)
                {
                    dif.Rows.Add(b.Rows[i]);
                }
            }
            return dif;
        }

        public DataTable ToDataTable()
        {
            DataTable table = new DataTable(TableName);
            foreach (TableColumn column in Cols)
            {
                table.Columns.Add(column.Name);
            }
            foreach (TableRow row in Rows)
            {
                DataRow dRow = table.Rows.Add();
                for (int i = 0; i < Cols.Count; i++)
                {
                    dRow[i] = row.Values[i];
                }
            }
            return table;
        }
    }
}
