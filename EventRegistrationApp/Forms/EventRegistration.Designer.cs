namespace EventRegistrationApp.Forms
{
    partial class EventRegistration
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
            this.textBox_firstName = new System.Windows.Forms.TextBox();
            this.textBox_middleName = new System.Windows.Forms.TextBox();
            this.textBox_lastName = new System.Windows.Forms.TextBox();
            this.textBox_yearLevel = new System.Windows.Forms.TextBox();
            this.textBox_section = new System.Windows.Forms.TextBox();
            this.textBox_suffixName = new System.Windows.Forms.TextBox();
            this.textBox_school = new System.Windows.Forms.TextBox();
            this.button_submitRegistration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.Location = new System.Drawing.Point(91, 54);
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.Size = new System.Drawing.Size(213, 22);
            this.textBox_firstName.TabIndex = 0;
            // 
            // textBox_middleName
            // 
            this.textBox_middleName.Location = new System.Drawing.Point(91, 100);
            this.textBox_middleName.Name = "textBox_middleName";
            this.textBox_middleName.Size = new System.Drawing.Size(213, 22);
            this.textBox_middleName.TabIndex = 1;
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.Location = new System.Drawing.Point(91, 155);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.Size = new System.Drawing.Size(213, 22);
            this.textBox_lastName.TabIndex = 2;
            // 
            // textBox_yearLevel
            // 
            this.textBox_yearLevel.Location = new System.Drawing.Point(91, 277);
            this.textBox_yearLevel.Name = "textBox_yearLevel";
            this.textBox_yearLevel.Size = new System.Drawing.Size(213, 22);
            this.textBox_yearLevel.TabIndex = 3;
            // 
            // textBox_section
            // 
            this.textBox_section.Location = new System.Drawing.Point(91, 334);
            this.textBox_section.Name = "textBox_section";
            this.textBox_section.Size = new System.Drawing.Size(213, 22);
            this.textBox_section.TabIndex = 4;
            // 
            // textBox_suffixName
            // 
            this.textBox_suffixName.Location = new System.Drawing.Point(91, 215);
            this.textBox_suffixName.Name = "textBox_suffixName";
            this.textBox_suffixName.Size = new System.Drawing.Size(213, 22);
            this.textBox_suffixName.TabIndex = 5;
            // 
            // textBox_school
            // 
            this.textBox_school.Location = new System.Drawing.Point(91, 379);
            this.textBox_school.Name = "textBox_school";
            this.textBox_school.Size = new System.Drawing.Size(213, 22);
            this.textBox_school.TabIndex = 6;
            // 
            // button_submitRegistration
            // 
            this.button_submitRegistration.Location = new System.Drawing.Point(91, 436);
            this.button_submitRegistration.Name = "button_submitRegistration";
            this.button_submitRegistration.Size = new System.Drawing.Size(213, 56);
            this.button_submitRegistration.TabIndex = 7;
            this.button_submitRegistration.Text = "Submit";
            this.button_submitRegistration.UseVisualStyleBackColor = true;
            this.button_submitRegistration.Click += new System.EventHandler(this.button_submitRegistration_Click);
            // 
            // EventRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 618);
            this.Controls.Add(this.button_submitRegistration);
            this.Controls.Add(this.textBox_school);
            this.Controls.Add(this.textBox_suffixName);
            this.Controls.Add(this.textBox_section);
            this.Controls.Add(this.textBox_yearLevel);
            this.Controls.Add(this.textBox_lastName);
            this.Controls.Add(this.textBox_middleName);
            this.Controls.Add(this.textBox_firstName);
            this.Name = "EventRegistration";
            this.Text = "EventRegistration";
            this.Load += new System.EventHandler(this.EventRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_firstName;
        private System.Windows.Forms.TextBox textBox_middleName;
        private System.Windows.Forms.TextBox textBox_lastName;
        private System.Windows.Forms.TextBox textBox_yearLevel;
        private System.Windows.Forms.TextBox textBox_section;
        private System.Windows.Forms.TextBox textBox_suffixName;
        private System.Windows.Forms.TextBox textBox_school;
        private System.Windows.Forms.Button button_submitRegistration;
    }
}