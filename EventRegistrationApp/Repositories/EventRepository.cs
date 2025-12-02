using EventRegistrationApp.Helpers;
using EventRegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace EventRegistrationApp.Repositories
{
    internal class EventRepository
    {
        // Using Database helper for connection
        public EventRepository()
        {
        }

        // Add new event
        public bool AddEvent(Event evt)
        {
            string query = @"INSERT INTO tbEvents 
                     (EventName, Description, EventDate, Location, CreatedAt, EventImage) 
                     VALUES (@EventName, @Description, @EventDate, @Location, @CreatedAt, @EventImage)";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventName", evt.EventName);
                cmd.Parameters.AddWithValue("@Description", (object)evt.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EventDate", evt.EventDate);
                cmd.Parameters.AddWithValue("@Location", (object)evt.Location ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedAt", evt.CreatedAt);

                // 👇 EVENT IMAGE PARAMETER
                cmd.Parameters.Add("@EventImage", SqlDbType.VarBinary)
                    .Value = (object)evt.EventImage ?? DBNull.Value;

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }


        // Deletes all events with the given name and returns the number of rows deleted
        public int DeleteEventsByName(string eventName)
        {
            string query = "DELETE FROM tbEvents WHERE EventName = @EventName";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventName", eventName);
                conn.Open();
                int deletedRows = cmd.ExecuteNonQuery();
                return deletedRows;
            }
        }


        // Get all events
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM tbEvents";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event evt = new Event
                        {
                            EventId = (int)reader["EventId"],
                            EventName = reader["EventName"].ToString(),
                            Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                            EventDate = (DateTime)reader["EventDate"],
                            Location = reader["Location"] == DBNull.Value ? null : reader["Location"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            EventImage = reader["EventImage"] == DBNull.Value ? null : (byte[])reader["EventImage"]  // ✅ add this
                        };
                        events.Add(evt);
                    }
                }
            }

            return events;
        }

        // Update event
        public bool UpdateEvent(Event evt)
        {
            string query = @"UPDATE tbEvents SET 
                             EventName=@EventName, Description=@Description, EventDate=@EventDate, Location=@Location
                             WHERE EventId=@EventId";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventName", evt.EventName);
                cmd.Parameters.AddWithValue("@Description", (object)evt.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EventDate", evt.EventDate);
                cmd.Parameters.AddWithValue("@Location", (object)evt.Location ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EventId", evt.EventId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete event
        public bool DeleteEvent(int eventId)
        {
            string query = "DELETE FROM tbEvents WHERE EventId=@EventId";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventId", eventId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get single event by ID
        public Event GetEventById(int eventId)
        {
            string query = "SELECT * FROM tbEvents WHERE EventId=@EventId";

            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EventId", eventId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Event
                        {
                            EventId = (int)reader["EventId"],
                            EventName = reader["EventName"].ToString(),
                            Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                            EventDate = (DateTime)reader["EventDate"],
                            Location = reader["Location"] == DBNull.Value ? null : reader["Location"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        };
                    }
                }
            }

            return null;
        }


    }
}
