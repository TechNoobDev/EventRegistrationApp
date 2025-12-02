using System;

namespace EventRegistrationApp.Models
{
    internal class Registration
    {
        public int RegistrationId { get; set; }     // Primary Key
        public int UserId { get; set; }             // Foreign Key to Users
        public int EventId { get; set; }            // Foreign Key to Events
        public DateTime RegistrationDate { get; set; }  // When registration happened
        public string Status { get; set; }          // Pending / Confirmed / Cancelled
    }
}
