using EventRegistrationApp.Models;
using EventRegistrationApp.Repositories;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace EventRegistrationApp.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            LoadEventsToGrid(); // Always load using one method
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
        }
        private  void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string eventName = textBox_eventName.Text.Trim();
            string description = richTextBox1.Text.Trim();
            DateTime eventDate = dateTimePicker_eventDate.Value;
            string location = textBox_location.Text.Trim();

            if (string.IsNullOrEmpty(eventName))
            {
                MessageBox.Show("Please enter the event name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert Image in PictureBox → Byte[]
            byte[] eventImage = null;

            if (pictureBox_addEventImage.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox_addEventImage.Image.Save(ms, pictureBox_addEventImage.Image.RawFormat);
                    eventImage = ms.ToArray();
                }
            }

            Event newEvent = new Event
            {
                EventName = eventName,
                Description = description,
                EventDate = eventDate,
                Location = location,
                CreatedAt = DateTime.Now,
                EventImage = eventImage   // ← ADD IMAGE HERE
            };

            EventRepository eventRepo = new EventRepository();
            bool added = eventRepo.AddEvent(newEvent);

            if (added)
            {
                MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEventsToGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Failed to add event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Event selectedEvent = GetSelectedEventFromGrid();
            if (selectedEvent == null)
            {
                MessageBox.Show("Select an event first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedEvent.EventName = textBox_eventName.Text;
            selectedEvent.Description = richTextBox1.Text;
            selectedEvent.Location = textBox_location.Text;
            selectedEvent.EventDate = dateTimePicker_eventDate.Value;

            EventRepository repo = new EventRepository();
            bool updated = repo.UpdateEvent(selectedEvent);

            if (updated)
            {
                MessageBox.Show("Event updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEventsToGrid(); // Refresh grid with IDs
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Failed to update event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nameToDelete = textBox_deleteByName.Text.Trim();

            if (string.IsNullOrWhiteSpace(nameToDelete))
            {
                MessageBox.Show("Please enter an Event Name to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EventRepository repo = new EventRepository();

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete all events named '{nameToDelete}'?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int deletedCount = repo.DeleteEventsByName(nameToDelete);
                if (deletedCount > 0)
                {
                    MessageBox.Show($"Deleted {deletedCount} event(s) with the name '{nameToDelete}'.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEventsToGrid(); // refresh DataGridView
                    textBox_deleteByName.Clear();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show($"No events found with the name '{nameToDelete}'.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void LoadEventsToGrid()
        {
            EventRepository eventRepo = new EventRepository();
            var events = eventRepo.GetAllEvents();
            dataGridView1.DataSource = events;

            // Always show EventId column
            if (dataGridView1.Columns["EventId"] != null)
            {
                dataGridView1.Columns["EventId"].Visible = true;
                dataGridView1.Columns["EventId"].HeaderText = "ID";
                dataGridView1.Columns["EventId"].Width = 50;
            }

            if (dataGridView1.Columns["CreatedAt"] != null)
                dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                textBox_eventName.Text = selectedRow.Cells["EventName"].Value.ToString();
                richTextBox1.Text = selectedRow.Cells["Description"].Value?.ToString();
                textBox_location.Text = selectedRow.Cells["Location"].Value?.ToString();
                dateTimePicker_eventDate.Value = (DateTime)selectedRow.Cells["EventDate"].Value;
            }
        }

        private Event GetSelectedEventFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;

            var row = dataGridView1.SelectedRows[0];
            return new Event
            {
                EventId = (int)row.Cells["EventId"].Value,
                EventName = row.Cells["EventName"].Value.ToString(),
                Description = row.Cells["Description"].Value?.ToString(),
                Location = row.Cells["Location"].Value?.ToString(),
                EventDate = (DateTime)row.Cells["EventDate"].Value,
                CreatedAt = (DateTime)row.Cells["CreatedAt"].Value
            };
        }

        private void ClearInputFields()
        {
            textBox_eventName.Clear();
            richTextBox1.Clear();
            textBox_location.Clear();
            dateTimePicker_eventDate.Value = DateTime.Now;
        }

        private void button_downloadParticipants_Click(object sender, EventArgs e)
        {
            // Open a Save File dialog
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "EventParticipants.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Fetch participants from DB
                        var participants = new EventRegistrationApp.Repositories.EventRegistrationRepository().GetAllRegistrations();

                        // Write CSV
                        using (var writer = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // Header
                            writer.WriteLine("RegistrationId,EventId,FirstName,MiddleName,LastName,SuffixName,YearLevel,Section,School,RegisteredAt");

                            foreach (var p in participants)
                            {
                                writer.WriteLine($"{p.RegistrationId},{p.EventId},{p.FirstName},{p.MiddleName},{p.LastName},{p.SuffixName},{p.YearLevel},{p.Section},{p.School},{p.RegisteredAt}");
                            }
                        }

                        MessageBox.Show("Participants exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting participants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBox_addEventImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox_addEventImage.Image = Image.FromFile(ofd.FileName);
                    pictureBox_addEventImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
