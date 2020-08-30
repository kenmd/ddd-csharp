using System;
using static System.Environment;
using Microsoft.Data.SqlClient;


namespace DddInPractice.Repository
{
    public static class Connection
    {
        public static string GetConnString()
        {
            string server = "127.0.0.1";
            string database = "db_example";
            string username = "sa";
            string password = "Password1"; // GetEnvironmentVariable("SA_PASSWORD");

            string str = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
            return String.Format(str, server, database, username, password);
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnString());
        }
    }
}
