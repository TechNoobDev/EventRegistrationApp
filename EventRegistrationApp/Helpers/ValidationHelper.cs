using System;
using System.Text.RegularExpressions;

namespace EventRegistrationApp.Helpers
{
    internal static class ValidationHelper
    {
        // Validate email format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Simple regex for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Validate username (alphanumeric, 3-20 chars)
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            string pattern = @"^[a-zA-Z0-9]{3,20}$";
            return Regex.IsMatch(username, pattern);
        }

        // Validate password strength (min 6 chars, at least 1 number, 1 uppercase)
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return false;

            string pattern = @"^(?=.*[A-Z])(?=.*\d).{6,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
