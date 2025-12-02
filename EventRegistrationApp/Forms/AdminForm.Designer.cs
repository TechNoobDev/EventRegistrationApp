namespace EventRegistrationApp.Forms
{
    partial class AdminForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.textBox_eventName = new System.Windows.Forms.TextBox();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker_eventDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_deleteByName = new System.Windows.Forms.TextBox();
            this.button_downloadParticipants = new System.Windows.Forms.Button();
            this.pictureBox_addEventImage = new System.Windows.Forms.PictureBox();
            this.textBox_deleteById = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_addEventImage)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_eventName
            // 
            this.textBox_eventName.Location = new System.Drawing.Point(12, 74);
            this.textBox_eventName.Name = "textBox_eventName";
            this.textBox_eventName.Size = new System.Drawing.Size(275, 22);
            this.textBox_eventName.TabIndex = 0;
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(12, 219);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(276, 22);
            this.textBox_location.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 119);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(275, 80);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // dateTimePicker_eventDate
            // 
            this.dateTimePicker_eventDate.Location = new System.Drawing.Point(13, 259);
            this.dateTimePicker_eventDate.Name = "dateTimePicker_eventDate";
            this.dateTimePicker_eventDate.Size = new System.Drawing.Size(275, 22);
            this.dateTimePicker_eventDate.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(275, 44);
            this.button2.TabIndex = 5;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(955, 307);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(275, 44);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(351, 74);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 207);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox_deleteByName
            // 
            this.textBox_deleteByName.Location = new System.Drawing.Point(954, 261);
            this.textBox_deleteByName.Name = "textBox_deleteByName";
            this.textBox_deleteByName.Size = new System.Drawing.Size(276, 22);
            this.textBox_deleteByName.TabIndex = 8;
            // 
            // button_downloadParticipants
            // 
            this.button_downloadParticipants.Location = new System.Drawing.Point(1328, 616);
            this.button_downloadParticipants.Name = "button_downloadParticipants";
            this.button_downloadParticipants.Size = new System.Drawing.Size(217, 44);
            this.button_downloadParticipants.TabIndex = 10;
            this.button_downloadParticipants.Text = "Download";
            this.button_downloadParticipants.UseVisualStyleBackColor = true;
            this.button_downloadParticipants.Click += new System.EventHandler(this.button_downloadParticipants_Click);
            // 
            // pictureBox_addEventImage
            // 
            this.pictureBox_addEventImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_addEventImage.Image")));
            this.pictureBox_addEventImage.Location = new System.Drawing.Point(13, 301);
            this.pictureBox_addEventImage.Name = "pictureBox_addEventImage";
            this.pictureBox_addEventImage.Size = new System.Drawing.Size(274, 201);
            this.pictureBox_addEventImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_addEventImage.TabIndex = 11;
            this.pictureBox_addEventImage.TabStop = false;
            this.pictureBox_addEventImage.Click += new System.EventHandler(this.pictureBox_addEventImage_Click);
            // 
            // textBox_deleteById
            // 
            this.textBox_deleteById.Location = new System.Drawing.Point(954, 219);
            this.textBox_deleteById.Name = "textBox_deleteById";
            this.textBox_deleteById.Size = new System.Drawing.Size(276, 22);
            this.textBox_deleteById.TabIndex = 9;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 672);
            this.Controls.Add(this.pictureBox_addEventImage);
            this.Controls.Add(this.button_downloadParticipants);
            this.Controls.Add(this.textBox_deleteById);
            this.Controls.Add(this.textBox_deleteByName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker_eventDate);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox_location);
            this.Controls.Add(this.textBox_eventName);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_addEventImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_eventName;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_eventDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_deleteByName;
        private System.Windows.Forms.Button button_downloadParticipants;
        private System.Windows.Forms.PictureBox pictureBox_addEventImage;
        private System.Windows.Forms.TextBox textBox_deleteById;
    }
}