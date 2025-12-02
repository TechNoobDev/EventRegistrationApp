using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EventRegistrationApp.Models;
using EventRegistrationApp.Helpers;

namespace EventRegistrationApp.Repositories
{
    internal class UserRepository
    {
        public UserRepository()
        {
            // No connection string here; Database.cs handles it
        }

        // Add a new user
        public bool AddUser(User user)
        {
            string query = @"INSERT INTO tbUsers 
                             (FullName, Email, PasswordHash, Role, CreatedAt, IsActive)
                             VALUES (@FullName, @Email, @PasswordHash, @Role, @CreatedAt, @IsActive)";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Validate login using Email
        public User ValidateLogin(string email, string password)
        {
            string query = "SELECT * FROM tbUsers WHERE Email=@Email AND IsActive=1";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["PasswordHash"].ToString();
                        if (HashHelper.VerifyHash(password, storedHash))
                        {
                            return new User
                            {
                                UserId = (int)reader["UserId"],
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Role = reader["Role"].ToString(),
                                CreatedAt = (DateTime)reader["CreatedAt"],
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                    }
                }
            }

            return null; // invalid login
        }

        // Get all users
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM tbUsers";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = (int)reader["UserId"],
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Role = reader["Role"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }

            return users;
        }

        // Update user
        public bool UpdateUser(User user)
        {
            string query = @"UPDATE tbUsers SET 
                             FullName=@FullName, Email=@Email, PasswordHash=@PasswordHash, Role=@Role, IsActive=@IsActive
                             WHERE UserId=@UserId";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Soft delete user
        public bool DeleteUser(int userId)
        {
            string query = "UPDATE tbUsers SET IsActive=0 WHERE UserId=@UserId";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get user by ID
        public User GetUserById(int userId)
        {
            string query = "SELECT * FROM tbUsers WHERE UserId=@UserId";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserId = (int)reader["UserId"],
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Role = reader["Role"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }

            return null;
        }
    }
}
