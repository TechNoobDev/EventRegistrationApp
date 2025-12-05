using System;
using System.Data.SqlClient;
using EventRegistrationApp.Helpers;
using EventRegistrationApp.Models;

namespace EventRegistrationApp.Repositories
{
    internal class AccountRepository
    {
        public bool AddAccount(Account account)
        {
            string query = @"INSERT INTO tbAccounts 
                             (Username, PasswordHash, CreatedAt, IsActive)
                             VALUES (@Username, @PasswordHash, @CreatedAt, @IsActive)";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", account.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", account.PasswordHash);
                cmd.Parameters.AddWithValue("@CreatedAt", account.CreatedAt);
                cmd.Parameters.AddWithValue("@IsActive", account.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Account ValidateLogin(string username, string password)
        {
            string query = "SELECT * FROM tbAccounts WHERE Username=@Username AND IsActive=1";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["PasswordHash"].ToString();

                        // Compare stored hash with user input
                        if (HashHelper.VerifyHash(password, storedHash))
                        {
                            return new Account
                            {
                                AccountId = (int)reader["AccountId"],
                                Username = reader["Username"].ToString(),
                                PasswordHash = storedHash,
                                CreatedAt = (DateTime)reader["CreatedAt"],
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
