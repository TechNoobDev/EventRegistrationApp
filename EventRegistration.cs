using System;
using System.Windows.Forms;

namespace EventRegistrationApp
{
    public partial class EventRegistration : Form
    {
        private int eventId;

        // Constructor accepting an eventId parameter
        public EventRegistration(int eventId)
        {
            InitializeComponent();
            this.eventId = eventId;
        }

        private void EventRegistration_Load(object sender, EventArgs e)
        {
            // Add logic to handle the eventId if needed
        }
      

    }
}
