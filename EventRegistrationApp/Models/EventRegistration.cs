using System;

namespace EventRegistrationApp.Models
{
    public class EventRegistration
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }

        public string YearLevel { get; set; }
        public string Section { get; set; }
        public string School { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
