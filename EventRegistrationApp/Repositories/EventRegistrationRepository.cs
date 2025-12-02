using EventRegistrationApp.Helpers;
using EventRegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EventRegistrationApp.Repositories
{
    public class EventRegistrationRepository
    {
        public bool Register(EventRegistration reg)
        {
            string query = @"INSERT INTO tbEventRegistrations
                            (EventId, FirstName, MiddleName, LastName, SuffixName,
                             YearLevel, Section, School, RegisteredAt)
                            VALUES
                            (@EventId, @FirstName, @MiddleName, @LastName, @SuffixName,
                             @YearLevel, @Section, @School, @RegisteredAt)";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventId", reg.EventId);
                cmd.Parameters.AddWithValue("@FirstName", reg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", (object)reg.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", reg.LastName);
                cmd.Parameters.AddWithValue("@SuffixName", (object)reg.SuffixName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@YearLevel", reg.YearLevel);
                cmd.Parameters.AddWithValue("@Section", reg.Section);
                cmd.Parameters.AddWithValue("@School", reg.School);
                cmd.Parameters.AddWithValue("@RegisteredAt", reg.RegisteredAt);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<EventRegistration> GetAllRegistrations()
        {
            List<EventRegistration> list = new List<EventRegistration>();
            string query = "SELECT * FROM tbEventRegistrations";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EventRegistration reg = new EventRegistration
                        {
                            RegistrationId = (int)reader["RegistrationId"],
                            EventId = (int)reader["EventId"],
                            FirstName = reader["FirstName"].ToString(),
                            MiddleName = reader["MiddleName"] == DBNull.Value ? null : reader["MiddleName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            SuffixName = reader["SuffixName"] == DBNull.Value ? null : reader["SuffixName"].ToString(),
                            YearLevel = reader["YearLevel"].ToString(),
                            Section = reader["Section"].ToString(),
                            School = reader["School"].ToString(),
                            RegisteredAt = (DateTime)reader["RegisteredAt"]
                        };
                        list.Add(reg);
                    }
                }
            }
            return list;
        }

    }
}
