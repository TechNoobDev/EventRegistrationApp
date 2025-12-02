using EventRegistrationApp.Helpers;
using EventRegistrationApp.Models;
using EventRegistrationApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EventRegistrationApp.Forms
{
    public partial class UserHomePage : Form
    {
        public UserHomePage()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void UserHomePage_Load(object sender, EventArgs e)
        {

        }
        private void LoadEvents()
        {
            flowLayoutPanel_events.Controls.Clear();

            EventRepository repo = new EventRepository();
            List<Event> events = repo.GetAllEvents();

            foreach (var evt in events)
            {
                EventCard card = new EventCard
                {
                    EventId = evt.EventId,
                    EventName = evt.EventName,
                    EventDate = evt.EventDate.ToString("MMMM dd, yyyy"),
                    EventLocation = evt.Location,
                    Description = evt.Description,
                    EventImage = ImageHelper.ByteArrayToImage(evt.EventImage) // ← Set image here
                };

                flowLayoutPanel_events.Controls.Add(card);
            }

        }
    }

}
