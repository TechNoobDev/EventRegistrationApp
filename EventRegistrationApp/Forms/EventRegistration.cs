using System;
using System.Windows.Forms;

namespace EventRegistrationApp.Forms
{
    public partial class EventRegistration : Form
    {
        private int _eventId; // Event ID for this registration

        // ✅ Constructor that accepts the event ID
        public EventRegistration(int eventId)
        {
            InitializeComponent();
            _eventId = eventId; // Assign the passed event ID
        }

        private void EventRegistration_Load(object sender, EventArgs e)
        {
            // Optional: you can load event details here using _eventId
        }

        private void button_submitRegistration_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(textBox_firstName.Text) ||
                string.IsNullOrWhiteSpace(textBox_lastName.Text) ||
                string.IsNullOrWhiteSpace(textBox_yearLevel.Text) ||
                string.IsNullOrWhiteSpace(textBox_section.Text) ||
                string.IsNullOrWhiteSpace(textBox_school.Text))
            {
                MessageBox.Show("Please fill in all required fields (First Name, Last Name, Year Level, Section, School).",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create registration model
            EventRegistrationApp.Models.EventRegistration reg = new EventRegistrationApp.Models.EventRegistration
            {
                EventId = _eventId,
                FirstName = textBox_firstName.Text.Trim(),
                MiddleName = textBox_middleName.Text.Trim(), // optional
                LastName = textBox_lastName.Text.Trim(),
                SuffixName = textBox_suffixName.Text.Trim(), // optional
                YearLevel = textBox_yearLevel.Text.Trim(),
                Section = textBox_section.Text.Trim(),
                School = textBox_school.Text.Trim(),
                RegisteredAt = DateTime.Now
            };

            // Save to DB
            EventRegistrationApp.Repositories.EventRegistrationRepository repo =
                new EventRegistrationApp.Repositories.EventRegistrationRepository();

            bool success = repo.Register(reg);

            if (success)
            {
                MessageBox.Show("Registration submitted successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // close form after submit
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
