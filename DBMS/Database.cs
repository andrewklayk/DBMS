using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS
{
    public class Database
    {
        public string name;
        private DBParams dbParams;
        public List<Table> tables;
        public Database(DBParams _dbParams)
        {
            name = _dbParams.DBName;
            dbParams = _dbParams;
            tables = new List<Table>();
        }

        public void AddColumn(Table t, Column c)
        {
            tables.Add(t);
            SqlConnection con = new SqlConnection();
            string sqlCreateTableQuery;
            con.ConnectionString = BuildConnectionString(dbParams);
            sqlCreateTableQuery = $" ALTER TABLE {t} ADD COLUMN {c.name} {c.type}";
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

        public void AddTable (Table t)
        {
            tables.Add(t);
            SqlConnection con = new SqlConnection();
            string sqlCreateTableQuery;
            con.ConnectionString = BuildConnectionString(dbParams);
            sqlCreateTableQuery = $" CREATE TABLE {t.name}";
            if (t.columns.Count != 0)
            {
                sqlCreateTableQuery += " (\n";
                foreach (Column c in t.columns)
                {
                    sqlCreateTableQuery += $"{c.name} {c.type}, \n";
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
            SqlConnection masterConnection = new SqlConnection();
            masterConnection.ConnectionString = BuildConnectionString(masterParams);
            using (SqlCommand createCommand = new SqlCommand(sqlDeleteQuery, masterConnection))
            {
                try
                {
                    masterConnection.Open();
                    createCommand.ExecuteNonQuery();
                    MessageBox.Show($"Database {dbParams.DBName} dropped succesfully!", "DBMS", MessageBoxButtons.OK);
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
    }
}
