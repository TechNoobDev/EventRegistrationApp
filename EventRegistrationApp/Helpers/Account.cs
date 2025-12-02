using System;

namespace EventRegistrationApp.Models
{
    internal class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
