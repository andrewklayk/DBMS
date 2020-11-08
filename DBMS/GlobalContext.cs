using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DBMS
{
    public static class GlobalContext
    {
        public static DBParams masterParams;
        public static List<string> databaseNames;
        public static Database currentDb;
        public static Table currentTable;

        public static List<Database> Databases { get; set; }

        public static int CreateDatabase(Database db)
        {
            SqlConnection masterConnection = new SqlConnection
            {
                ConnectionString = Database.BuildConnectionString(masterParams)
            };
            string sqlCreateDbQuery = $" CREATE DATABASE {db.DbParams.DBName}";/* +
                $"LOG ON (NAME = {dbParams.LogFileName}, FILENAME = {dbParams.LogFilePath})";*/
            int result = -1;
            using (SqlCommand createCommand = new SqlCommand(sqlCreateDbQuery, masterConnection))
            {
                try
                {
                    masterConnection.Open();
                    result = createCommand.ExecuteNonQuery();
                    Databases.Add(db);
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    masterConnection.Close();
                }
            }
            return result;
        }

        public static int DropDatabase(int id)
        {
            SqlConnection masterConnection = new SqlConnection
            {
                ConnectionString = Database.BuildConnectionString(masterParams)
            };
            string sqlDropDbQuery = $"DROP DATABASE {Databases[id].DbParams.DBName}";
            int result = -1;
            using (SqlCommand createCommand = new SqlCommand(sqlDropDbQuery, masterConnection))
            {
                masterConnection.Open();
                result = createCommand.ExecuteNonQuery();
                masterConnection.Close();
                Databases.RemoveAt(id);
            }
            return result;
        }

        public static void PopulateDatabaseList()
        {
            if (Databases == null)
            {
                Databases = new List<Database>();
            }
            if (databaseNames == null)
            {
                databaseNames = new List<string>();
            }
            SqlConnection masterConnection = new SqlConnection
            {
                ConnectionString = Database.BuildConnectionString(masterParams)
            };
            string sqlGetAllDatabasesQuery = "SELECT name FROM master.sys.databases";
            using (SqlCommand com = new SqlCommand(sqlGetAllDatabasesQuery, masterConnection))
            {
                masterConnection.Open();
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        if (name == "msdb" || name == "model" || name == "master" || name == "tempdb")
                            continue;
                        DBParams dp = new DBParams(masterParams.ServerName, name, "", "", "", "", GlobalContext.masterParams.UserId, GlobalContext.masterParams.Password);
                        Database d = new Database(dp);
                        d.PopulateTableList();

                        GlobalContext.Databases.Add(d);
                    }
                }
                masterConnection.Close();
            }
            return;
        }
    }
}
