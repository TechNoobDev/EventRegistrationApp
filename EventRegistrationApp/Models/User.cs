using System;

namespace EventRegistrationApp.Models
{
    internal class User
    {
        public int UserId { get; set; }           // maps to UserId column
        public string UserName { get; set; }
        public string FullName { get; set; }      // maps to FullName column
        public string Email { get; set; }         // maps to Email column
        public string PasswordHash { get; set; }  // maps to PasswordHash column
        public string Role { get; set; }          // maps to Role column
        public DateTime CreatedAt { get; set; }   // maps to CreatedAt column
        public bool IsActive { get; set; }        // maps to IsActive column
    }
}
