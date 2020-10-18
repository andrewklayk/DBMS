using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS
{
    static class Global
    {
        public static DBParams masterParams;
        public static List<Database> databases;
        public static List<string> databaseNames;
        public static int currentDb;
        public static int currentTable;

        public static void PopulateDatabaseList()
        {
            if (databases == null)
            {
                databases = new List<Database>();
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
                try
                {
                    masterConnection.Open();
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            if (name == "msdb" || name == "model" || name == "master" || name == "tempdb")
                                continue;
                            DBParams dp = new DBParams(Global.masterParams.ServerName, name, "", "", "", "", Global.masterParams.UserId, Global.masterParams.Password);
                            Database d = new Database(dp);
                            d.PopulateTableList();
                            
                            Global.databases.Add(d);
                        }
                    }
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
    }
}
