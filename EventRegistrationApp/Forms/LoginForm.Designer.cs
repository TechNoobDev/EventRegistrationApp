namespace EventRegistrationApp.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.button_userForm = new System.Windows.Forms.Button();
            this.button_adminForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_userForm
            // 
            this.button_userForm.Font = new System.Drawing.Font("Copperplate Gothic Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_userForm.Location = new System.Drawing.Point(174, 55);
            this.button_userForm.Name = "button_userForm";
            this.button_userForm.Size = new System.Drawing.Size(207, 58);
            this.button_userForm.TabIndex = 0;
            this.button_userForm.Text = "User";
            this.button_userForm.UseVisualStyleBackColor = true;
            this.button_userForm.Click += new System.EventHandler(this.button_userForm_Click);
            // 
            // button_adminForm
            // 
            this.button_adminForm.Font = new System.Drawing.Font("Copperplate Gothic Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_adminForm.Location = new System.Drawing.Point(174, 139);
            this.button_adminForm.Name = "button_adminForm";
            this.button_adminForm.Size = new System.Drawing.Size(207, 58);
            this.button_adminForm.TabIndex = 1;
            this.button_adminForm.Text = "Admin";
            this.button_adminForm.UseVisualStyleBackColor = true;
            this.button_adminForm.Click += new System.EventHandler(this.button_adminForm_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(562, 263);
            this.Controls.Add(this.button_adminForm);
            this.Controls.Add(this.button_userForm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_userForm;
        private System.Windows.Forms.Button button_adminForm;
    }
}

