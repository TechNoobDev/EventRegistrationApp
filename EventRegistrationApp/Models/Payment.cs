using System;

namespace EventRegistrationApp.Models
{
    internal class Payment
    {
        public int PaymentId { get; set; }
        public int RegistrationId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }  // e.g., "Paid", "Pending"
        public DateTime? PaidDate { get; set; }    // Nullable in case payment not yet made
    }
}
