using System;

namespace EventRegistrationApp.Models
{
    internal class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public byte[] EventImage { get; set; }

        // NEW PROPERTIES
        public DateTime CreatedAt { get; set; }
        public string Organizer { get; set; }
        public string Category { get; set; }
    }
}
