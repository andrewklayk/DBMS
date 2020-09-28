using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    static class Global
    {
        public static DBParams masterParams;
        public static List<Database> databases;
        public static List<string> databaseNames;

        public static void PopulateDatabaseList()
        {
            if(databases == null)
            {
                databases = new List<Database>();
            }
            if(databaseNames == null)
            {
                databaseNames = new List<string>();
            }
            SqlConnection masterConnection = new SqlConnection();
            masterConnection.ConnectionString = Database.BuildConnectionString(masterParams);
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
                            DBParams dp = new DBParams(Global.masterParams.ServerName, name, "", "", "", "", Global.masterParams.UserId, Global.masterParams.Password);
                            Global.databases.Add(new Database(dp));
                            Global.databaseNames.Add(name);
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
