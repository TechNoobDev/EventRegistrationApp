using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EventRegistrationApp.Models;

namespace EventRegistrationApp.Repositories
{
    internal class PaymentRepository
    {
        private readonly string _connectionString;

        public PaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add new payment
        public bool AddPayment(Payment payment)
        {
            string query = @"INSERT INTO Payments 
                             (RegistrationId, Amount, PaymentStatus, PaidDate) 
                             VALUES (@RegistrationId, @Amount, @PaymentStatus, @PaidDate)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RegistrationId", payment.RegistrationId);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);
                cmd.Parameters.AddWithValue("@PaidDate", (object)payment.PaidDate ?? DBNull.Value);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get all payments
        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            string query = "SELECT * FROM Payments";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Payment payment = new Payment
                        {
                            PaymentId = (int)reader["PaymentId"],
                            RegistrationId = (int)reader["RegistrationId"],
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            PaymentStatus = reader["PaymentStatus"].ToString(),
                            PaidDate = reader["PaidDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["PaidDate"]
                        };
                        payments.Add(payment);
                    }
                }
            }

            return payments;
        }

        // Update payment
        public bool UpdatePayment(Payment payment)
        {
            string query = @"UPDATE tbPayments SET 
                             Amount=@Amount, PaymentStatus=@PaymentStatus, PaidDate=@PaidDate 
                             WHERE PaymentId=@PaymentId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);
                cmd.Parameters.AddWithValue("@PaidDate", (object)payment.PaidDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentId", payment.PaymentId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete payment
        public bool DeletePayment(int paymentId)
        {
            string query = "DELETE FROM tbPayments WHERE PaymentId=@PaymentId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get single payment by ID
        public Payment GetPaymentById(int paymentId)
        {
            string query = "SELECT * FROM tbPayments WHERE PaymentId=@PaymentId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Payment
                        {
                            PaymentId = (int)reader["PaymentId"],
                            RegistrationId = (int)reader["RegistrationId"],
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            PaymentStatus = reader["PaymentStatus"].ToString(),
                            PaidDate = reader["PaidDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["PaidDate"]
                        };
                    }
                }
            }
            return null;
        }
    }
}
