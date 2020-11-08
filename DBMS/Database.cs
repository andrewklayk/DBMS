using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace DBMS
{
    [DataContract]
    public class Database
    {
        //public string name;
        private DBParams dbParams;

        public List<Table> Tables { get; set; }
        public DBParams DbParams { get => dbParams; set => dbParams = value; }

        public Database()
        {

        }
        public Database(DBParams _dbParams)
        {
            //name = _dbParams.DBName;
            DbParams = _dbParams;
            Tables = new List<Table>();
        }

        public Database(string name, List<Table> tables)
        {
            //name = _dbParams.DBName;
            DbParams = new DBParams { DBName = name };
            Tables = tables;
        }

        public void PopulateTableList()
        {
            string sqlGetTablesQuery = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            using (SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(DbParams)
            })
            {
                using (SqlCommand com = new SqlCommand(sqlGetTablesQuery, con))
                {
                    con.Open();
                    var reader = com.ExecuteReader();
                    List<string> tableNames = new List<string>();
                    while (reader.Read())
                    {
                        int nameIndex = ((IDataRecord)reader).GetOrdinal("TABLE_NAME");
                        if (((IDataRecord)reader).GetString(nameIndex) != "sysdiagrams")
                        {
                            tableNames.Add(((IDataRecord)reader).GetString(nameIndex));
                        }
                    }
                    reader.Close();
                    foreach (string tn in tableNames)
                    {
                        Table t = new Table(tn, 0, this);
                        t.TryRead(con);
                        Tables.Add(t);
                    }
                }
                con.Close();
                
            }
        }

        public void DropTable(string tableName)
        {
            SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(DbParams)
            };
            string sqlDropTableQuery = $"DROP TABLE {tableName}";
            using (SqlCommand createCommand = new SqlCommand(sqlDropTableQuery, con))
            {
                con.Open();
                createCommand.ExecuteNonQuery();
                Tables.RemoveAll(x => x.TableName == tableName);
                con.Close();
            }
            return;
        }

        public void AddTable(Table t)
        {
            Tables.Add(t);
            SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(DbParams)
            };
            string sqlCreateTableQuery = $" CREATE TABLE {t.TableName}";
            if (t.Cols.Count != 0)
            {
                sqlCreateTableQuery += "(";
                foreach (TableColumn c in t.Cols)
                {
                    sqlCreateTableQuery += $"{c.Name} {c.SqlType} ";
                    if (t.PrimaryKeyName == c.Name)
                        sqlCreateTableQuery += "PRIMARY KEY";
                    sqlCreateTableQuery += ",";
                }
                sqlCreateTableQuery = sqlCreateTableQuery.Remove(sqlCreateTableQuery.Length-1,1);
                sqlCreateTableQuery += ");";
            }
            using (SqlCommand createCommand = new SqlCommand(sqlCreateTableQuery, con))
            {
                con.Open();
                createCommand.ExecuteNonQuery();
                con.Close();
            }
            return;
        }

        public void CreateDatabase(DBParams masterParams)
        {
            SqlConnection masterConnection = new SqlConnection();
            masterConnection.ConnectionString = BuildConnectionString(masterParams);
            string sqlCreateDbQuery = $" CREATE DATABASE {DbParams.DBName}";/* +
                $"LOG ON (NAME = {dbParams.LogFileName}, FILENAME = {dbParams.LogFilePath})";*/
            using (SqlCommand createCommand = new SqlCommand(sqlCreateDbQuery, masterConnection))
            {
                masterConnection.Open();
                createCommand.ExecuteNonQuery();
                masterConnection.Close();
            }
            return;
        }

        public void DeleteDatabase(DBParams masterParams)
        {
            string sqlDeleteQuery = $"DROP DATABASE {DbParams.DBName}";
            SqlConnection masterConnection = new SqlConnection
            {
                ConnectionString = BuildConnectionString(masterParams)
            };
            using (SqlCommand createCommand = new SqlCommand(sqlDeleteQuery, masterConnection))
            {
                masterConnection.Open();
                createCommand.ExecuteNonQuery();
                GlobalContext.Databases.Remove(this);
                GlobalContext.databaseNames.Remove(this.DbParams.DBName);
                masterConnection.Close();
            }
            return;
        }
        public static string BuildConnectionString(DBParams dbParams)
        {
            return $"SERVER = {dbParams.ServerName}; DATABASE = {dbParams.DBName}; User ID ={dbParams.UserId}; Pwd = {dbParams.Password}; Pooling=false";
        }

        /*public void OpenConnection(DBParams dBParams)
        {
            BuildConnectionString(dbParams);
        }*/
    }
}
