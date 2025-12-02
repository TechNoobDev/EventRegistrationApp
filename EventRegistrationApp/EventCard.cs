using EventRegistrationApp.Forms;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;
using System.Drawing;


namespace EventRegistrationApp
{
    public partial class EventCard : UserControl
    {
        public int EventId { get; set; }

        public string EventName
        {
            get => label_eventName.Text;
            set => label_eventName.Text = value;
        }

        public string EventDate
        {
            get => label_eventDate.Text;
            set => label_eventDate.Text = value;
        }


        public string Description
        {
            get => label_description.Text;
            set => label_description.Text = value;
        }

        public string EventImagePath
        {
            get => pictureBox_eventImage.ImageLocation;
            set => pictureBox_eventImage.ImageLocation = value;
        }
        public string EventLocation
        {
            get => label_location.Text;
            set => label_location.Text = value;
        }
        public Image EventImage
        {
            get => pictureBox_eventImage.Image;
            set => pictureBox_eventImage.Image = value;
        }



        public EventCard()
        {
            InitializeComponent();

            this.Click += EventCard_Click;

            foreach (Control c in this.Controls)
                c.Click += EventCard_Click;
        }

        private void EventCard_Click(object sender, EventArgs e)
        {
            EventRegistration frm = new EventRegistration(this.EventId);
            frm.ShowDialog();
        }

        private void EventCard_Load(object sender, EventArgs e) { }

        private void label_location_Click(object sender, EventArgs e) { }

        private void label_description_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
