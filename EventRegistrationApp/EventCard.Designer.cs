namespace EventRegistrationApp
{
    partial class EventCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCard));
            this.label_eventName = new System.Windows.Forms.Label();
            this.label_description = new System.Windows.Forms.Label();
            this.label_location = new System.Windows.Forms.Label();
            this.label_eventDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_eventImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eventImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label_eventName
            // 
            this.label_eventName.AutoSize = true;
            this.label_eventName.BackColor = System.Drawing.Color.AliceBlue;
            this.label_eventName.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_eventName.ForeColor = System.Drawing.Color.Black;
            this.label_eventName.Location = new System.Drawing.Point(15, 240);
            this.label_eventName.Name = "label_eventName";
            this.label_eventName.Size = new System.Drawing.Size(119, 28);
            this.label_eventName.TabIndex = 0;
            this.label_eventName.Text = "Event name";
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.BackColor = System.Drawing.Color.AliceBlue;
            this.label_description.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_description.ForeColor = System.Drawing.Color.Black;
            this.label_description.Location = new System.Drawing.Point(15, 274);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(115, 28);
            this.label_description.TabIndex = 1;
            this.label_description.Text = "Description";
            this.label_description.Click += new System.EventHandler(this.label_description_Click);
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.BackColor = System.Drawing.Color.AliceBlue;
            this.label_location.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_location.ForeColor = System.Drawing.Color.Black;
            this.label_location.Location = new System.Drawing.Point(16, 346);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(89, 28);
            this.label_location.TabIndex = 3;
            this.label_location.Text = "Location";
            this.label_location.Click += new System.EventHandler(this.label_location_Click);
            // 
            // label_eventDate
            // 
            this.label_eventDate.AutoSize = true;
            this.label_eventDate.BackColor = System.Drawing.Color.AliceBlue;
            this.label_eventDate.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_eventDate.ForeColor = System.Drawing.Color.Black;
            this.label_eventDate.Location = new System.Drawing.Point(15, 314);
            this.label_eventDate.Name = "label_eventDate";
            this.label_eventDate.Size = new System.Drawing.Size(110, 28);
            this.label_eventDate.TabIndex = 2;
            this.label_eventDate.Text = "Event Date";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox_eventImage);
            this.panel1.Controls.Add(this.label_description);
            this.panel1.Controls.Add(this.label_location);
            this.panel1.Controls.Add(this.label_eventName);
            this.panel1.Controls.Add(this.label_eventDate);
            this.panel1.Location = new System.Drawing.Point(22, 14);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(291, 392);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox_eventImage
            // 
            this.pictureBox_eventImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_eventImage.Image")));
            this.pictureBox_eventImage.Location = new System.Drawing.Point(15, 13);
            this.pictureBox_eventImage.Name = "pictureBox_eventImage";
            this.pictureBox_eventImage.Size = new System.Drawing.Size(263, 216);
            this.pictureBox_eventImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_eventImage.TabIndex = 4;
            this.pictureBox_eventImage.TabStop = false;
            // 
            // EventCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Name = "EventCard";
            this.Size = new System.Drawing.Size(325, 417);
            this.Load += new System.EventHandler(this.EventCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eventImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_eventName;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.Label label_eventDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_eventImage;
    }
}
