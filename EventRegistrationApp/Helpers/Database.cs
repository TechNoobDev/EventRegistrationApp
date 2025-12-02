using System;
using System.Data.SqlClient;

namespace EventRegistrationApp.Helpers
{
    internal static class Database
    {
        // Change this connection string to match your SQL Server
        private static readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbEventRegistration;Integrated Security=True";

        // Get a new SQL connection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
