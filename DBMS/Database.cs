using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS
{
    public class Database
    {
        public string name;
        public DBParams dbParams;
        public List<Table> tables;
        public Database(DBParams _dbParams)
        {
            name = _dbParams.DBName;
            dbParams = _dbParams;
            tables = new List<Table>();
        }

        public void FillTableFromDb(Table t)
        {
            SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(dbParams)
            };
        }

        public void PopulateTableList()
        {
            string sqlGetTablesQuery = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(dbParams)
            };
            using (SqlCommand com = new SqlCommand(sqlGetTablesQuery, con))
            {
                try
                {
                    con.Open();
                    var reader = com.ExecuteReader();
                    List<string> tableNames = new List<string>();
                    while(reader.Read())
                    {
                        int nameIndex = ((IDataRecord)reader).GetOrdinal("TABLE_NAME");
                        if (((IDataRecord)reader).GetString(nameIndex) != "sysdiagrams")
                        {
                            tableNames.Add(((IDataRecord)reader).GetString(nameIndex));
                        }
                    }
                    reader.Close();
                    foreach(string tn in tableNames)
                    {
                        Table t = new Table(tn, 0, this);
                        t.TryRead(con);
                        tables.Add(t);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "DBMS", MessageBoxButtons.OK);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        /*public void AddColumn(Table t, Column c)
        {
            tables.Add(t);
            SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(dbParams)
            };
            string sqlCreateTableQuery = $" ALTER TABLE {t.tableName} ADD COLUMN {c.name} {c.type}";
            using (SqlCommand createCommand = new SqlCommand(sqlCreateTableQuery, con))
            {
                try
                {
                    con.Open();
                    createCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "DBMS", MessageBoxButtons.OK);
                }
                finally
                {
                    con.Close();
                }
            }
            return;
        }*/

        public void AddTable(Table t)
        {
            tables.Add(t);
            SqlConnection con = new SqlConnection
            {
                ConnectionString = BuildConnectionString(dbParams)
            };
            string sqlCreateTableQuery = $" CREATE TABLE {t.tableName}";
            if (t.columns.Count != 0)
            {
                sqlCreateTableQuery += " (\n";
                foreach (Column c in t.columns)
                {
                    sqlCreateTableQuery += $"{c.name} {c.dataType}, \n";
                }
                sqlCreateTableQuery += " );";
            }
            using (SqlCommand createCommand = new SqlCommand(sqlCreateTableQuery, con))
            {
                try
                {
                    con.Open();
                    createCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "DBMS", MessageBoxButtons.OK);
                }
                finally
                {
                    con.Close();
                }
            }
            return;
        }

        public void CreateDatabase(DBParams masterParams)
        {
            SqlConnection masterConnection = new SqlConnection();
            string sqlCreateDbQuery;
            masterConnection.ConnectionString = BuildConnectionString(masterParams);
            sqlCreateDbQuery = $" CREATE DATABASE {dbParams.DBName} " +
                $"ON PRIMARY (NAME = {dbParams.DBFileName}, FILENAME = '{dbParams.DBFilePath}')";/* +
                $"LOG ON (NAME = {dbParams.LogFileName}, FILENAME = {dbParams.LogFilePath})";*/
            using (SqlCommand createCommand = new SqlCommand(sqlCreateDbQuery, masterConnection))
            {
                try
                {
                    masterConnection.Open();
                    createCommand.ExecuteNonQuery();
                    MessageBox.Show($"Database {dbParams.DBName} created succesfully!", "DBMS", MessageBoxButtons.OK);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "DBMS", MessageBoxButtons.OK);
                }
                finally
                {
                    masterConnection.Close();
                }
            }
            return;
        }

        public void DeleteDatabase(DBParams masterParams)
        {
            string sqlDeleteQuery = $"DROP DATABASE {dbParams.DBName}";
            SqlConnection masterConnection = new SqlConnection
            {
                ConnectionString = BuildConnectionString(masterParams)
            };
            using (SqlCommand createCommand = new SqlCommand(sqlDeleteQuery, masterConnection))
            {
                try
                {
                    masterConnection.Open();
                    createCommand.ExecuteNonQuery();
                    MessageBox.Show($"Database {dbParams.DBName} dropped succesfully!", "DBMS", MessageBoxButtons.OK);
                    Global.databases.Remove(this);
                    Global.databaseNames.Remove(this.name);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "DBMS", MessageBoxButtons.OK);
                }
                finally
                {
                    masterConnection.Close();
                }
            }
            return;
        }
        public static string BuildConnectionString(DBParams dbParams)
        {
            return $"SERVER = {dbParams.ServerName}; DATABASE = {dbParams.DBName}; User ID ={dbParams.UserId}; Pwd = {dbParams.Password}";
        }

        /*public void OpenConnection(DBParams dBParams)
        {
            BuildConnectionString(dbParams);
        }*/
    }
}
