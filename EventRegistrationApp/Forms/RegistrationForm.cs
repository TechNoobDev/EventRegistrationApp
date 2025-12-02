using System;
using System.Windows.Forms;
using EventRegistrationApp.Models;
using EventRegistrationApp.Helpers;
using EventRegistrationApp.Repositories;

namespace EventRegistrationApp.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text.Trim();
            string password = textBox_password.Text;
            string confirmPassword = textBox_confirmPassword.Text;

            // 1. Validate inputs
            if (!ValidationHelper.IsValidUsername(username))
            {
                MessageBox.Show("Username must be 3-20 alphanumeric characters.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters, include 1 uppercase letter and 1 number.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hash password
            string hashedPassword = HashHelper.ComputeHash(password);

            // 3. Create account object
            Account newAccount = new Account
            {
                Username = username,
                PasswordHash = hashedPassword,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            // 4. Save to database using AccountRepository
            AccountRepository accountRepo = new AccountRepository();
            bool added = accountRepo.AddAccount(newAccount);

            if (added)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open User Home Page
                UserForm userForm = new UserForm();
                userForm.Show();
                this.Hide(); // Optional: hide registration form
            }
            else
            {
                MessageBox.Show("Registration failed. Username may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
