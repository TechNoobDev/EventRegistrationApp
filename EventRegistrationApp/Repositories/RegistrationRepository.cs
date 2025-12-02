using EventRegistrationApp.Helpers;
using EventRegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EventRegistrationApp.Repositories
{
    internal class RegistrationRepository
    {
        private readonly string _connectionString;

        public RegistrationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add new registration
        public bool AddRegistration(Registration registration)
        {
            string query = @"INSERT INTO tbRegistrations 
                             (UserId, EventId, RegistrationDate, Status) 
                             VALUES (@UserId, @EventId, @RegistrationDate, @Status)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", registration.UserId);
                cmd.Parameters.AddWithValue("@EventId", registration.EventId);
                cmd.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                cmd.Parameters.AddWithValue("@Status", registration.Status);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get all registrations
        public List<Registration> GetAllRegistrations()
        {
            List<Registration> registrations = new List<Registration>();
            string query = "SELECT * FROM tbRegistrations";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Registration reg = new Registration
                        {
                            RegistrationId = (int)reader["RegistrationId"],
                            UserId = (int)reader["UserId"],
                            EventId = (int)reader["EventId"],
                            RegistrationDate = (DateTime)reader["RegistrationDate"],
                            Status = reader["Status"].ToString()
                        };
                        registrations.Add(reg);
                    }
                }
            }

            return registrations;
        }

        // Update registration
        public bool UpdateRegistration(Registration registration)
        {
            string query = @"UPDATE tbRegistrations SET 
                             UserId=@UserId, EventId=@EventId, RegistrationDate=@RegistrationDate, Status=@Status
                             WHERE RegistrationId=@RegistrationId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", registration.UserId);
                cmd.Parameters.AddWithValue("@EventId", registration.EventId);
                cmd.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                cmd.Parameters.AddWithValue("@Status", registration.Status);
                cmd.Parameters.AddWithValue("@RegistrationId", registration.RegistrationId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete registration
        public bool DeleteRegistration(int registrationId)
        {
            string query = "DELETE FROM tbRegistrations WHERE RegistrationId=@RegistrationId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationId", registrationId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete all events by name
        public int DeleteEventsByName(string eventName)
        {
            string query = "DELETE FROM tbEvents WHERE EventName = @EventName";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventName", eventName);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected; // returns how many rows were deleted
            }
        }


        // Get registration by ID
        public Registration GetRegistrationById(int registrationId)
        {
            string query = "SELECT * FROM tbRegistrations WHERE RegistrationId=@RegistrationId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationId", registrationId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Registration
                        {
                            RegistrationId = (int)reader["RegistrationId"],
                            UserId = (int)reader["UserId"],
                            EventId = (int)reader["EventId"],
                            RegistrationDate = (DateTime)reader["RegistrationDate"],
                            Status = reader["Status"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // Get all registrations for a specific user
        public List<Registration> GetRegistrationsByUser(int userId)
        {
            List<Registration> registrations = new List<Registration>();
            string query = "SELECT * FROM tbRegistrations WHERE UserId=@UserId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        registrations.Add(new Registration
                        {
                            RegistrationId = (int)reader["RegistrationId"],
                            UserId = (int)reader["UserId"],
                            EventId = (int)reader["EventId"],
                            RegistrationDate = (DateTime)reader["RegistrationDate"],
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }

            return registrations;
        }
    }
}
