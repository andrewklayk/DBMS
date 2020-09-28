using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS
{
    class Database
    {
        private string connectionString;
        Database(DBParams dBParams)
        {
            connectionString = BuildConnectionString(dBParams);
        }
        public void CreateDatabase(DBParams dbParams, DBParams masterParams)
        {
            SqlConnection con = new SqlConnection();
            string sqlCreateDbQuery;
            con.ConnectionString = BuildConnectionString(masterParams);
            sqlCreateDbQuery = $" CREATE DATABASE {dbParams.DBName} " +
                $"ON PRIMARY (NAME = {dbParams.DBFileName}, FILENAME = {dbParams.DBFilePath}) " +
                $"LOG ON (NAME = {dbParams.LogFileName}, FILENAME = {dbParams.LogFilePath})";
            SqlCommand createCommand = new SqlCommand(sqlCreateDbQuery, con);
            try
            {
                con.Open();
                createCommand.ExecuteNonQuery();
                MessageBox.Show($"Database {dbParams.DBName} created succesfully!", "DBMS", MessageBoxButtons.OK);
            }
            catch(System.Exception e)
            {
                MessageBox.Show(e.ToString(), "DBMS", MessageBoxButtons.OK);
            }
            finally
            {
                con.Close();
            }
            return;
        }
        private string BuildConnectionString(DBParams dbParams)
        {
            return $"SERVER = {dbParams.ServerName}; DATABASE = {dbParams.DBName}; User ID ={dbParams.UserId}; Pwd = {dbParams.Password}"; ;
        }
    }
}
