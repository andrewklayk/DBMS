using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DBMS
{
    public class Table
    {
        public string tableName;
        //public int index;
        public Database database;
        public List<Column> columns;
        public int recordNumber;
        List<Row> rows;
        List<TableColumn> cols;

        public Table(string tableName, int index, Database db)
        {
            this.tableName = tableName;
            //this.index = index;
            this.database = db;
            columns = new List<Column>();
            recordNumber = 0;
            cols = new List<TableColumn>();
            rows = new List<Row>();
        }

        public Table(string name, int index, Database db, List<Column> columns) : this(name, index, db)
        {
            this.columns = columns;
        }

        /*public Column GetColumn(string columnName, SqlConnection con)
        {
            string sqlGetColumnQuery = $"SELECT {columnName} FROM {tableName}";

        }*/
        public void PopulateColumns()
        {

        }

        public bool TryRead(SqlConnection con)
        {
            using (SqlCommand com = new SqlCommand($"SELECT * FROM {tableName}", con))
            {
                try
                {
                    SqlDataReader reader = com.ExecuteReader();
                    var values = new List<List<object>>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var datarecord = ((IDataRecord)reader);
                        cols.Add(new TableColumn(i, datarecord.GetFieldType(i), datarecord.GetDataTypeName(i), datarecord.GetName(i)));
                        values.Add(new List<object>());
                    }
                    while (reader.Read())
                    {
                        var datarecord = ((IDataRecord)reader);
                        recordNumber++;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var a = new object[reader.FieldCount];
                            datarecord.GetValues(a);
                            rows.Add(new Row(0, a, this));
                            values[i].Add(datarecord.GetValue(i));
                        }
                    }
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columns.Add(ColumnFactory.CreateColumn(((IDataRecord)reader).GetDataTypeName(i), this, ((IDataRecord)reader).GetName(i), values[i], i));
                    }
                    reader.Close();
                    return true;
                }
                catch(Exception e)
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

        public bool TryAddColumn(Column a, SqlConnection con)
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
        }

        public bool TryDropColumn(Column a, SqlConnection con)
        {
            string sqlAddTableQuery = $"ALTER TABLE {this.tableName} DROP COLUMN {a.name}";
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

        public Table Difference(Table a, Table b)
        {
            if (a.columns.Count != b.columns.Count)
                throw new Exception("Cannot compare tables with different column count");
            return null;
        }

        class Row
        {
            int index;
            List<object> values;
            Table ownerTable;

            public Row(int index, List<object> values, Table ownerTable)
            {
                this.index = index;
                this.values = values;
                this.ownerTable = ownerTable;
            }
            public Row(int index, object[] values, Table ownerTable)
            {
                this.index = index;
                this.values = values.ToList();
                this.ownerTable = ownerTable;
            }
        }

        class TableColumn
        {
            int index;
            Type type;
            string sqlType;
            string name;

            public TableColumn(int index, Type type, string sqlType, string name)
            {
                this.index = index;
                this.type = type;
                this.sqlType = sqlType;
                this.name = name;
            }
        }
    }
}
