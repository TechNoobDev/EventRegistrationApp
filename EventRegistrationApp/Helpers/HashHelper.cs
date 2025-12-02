using System;
using System.Security.Cryptography;
using System.Text;

namespace EventRegistrationApp.Helpers
{
    internal static class HashHelper
    {
        // Hash a plain text password
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // convert to hex
                }
                return builder.ToString();
            }
        }

        // Verify a plain text password against a hashed password
        public static bool VerifyHash(string input, string hash)
        {
            string inputHash = ComputeHash(input);
            return string.Equals(inputHash, hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
