using System;
using System.Windows.Forms;
using EventRegistrationApp.Models;
using EventRegistrationApp.Repositories;
using EventRegistrationApp.Helpers;

namespace EventRegistrationApp.Forms
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // Optional: pre-fill for testing
            // textBox_username.Text = "testuser";
            // textBox_password.Text = "Password123";
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text.Trim();
            string password = textBox_password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AccountRepository accountRepo = new AccountRepository();
            Account account = accountRepo.ValidateLogin(username, password);

            if (account != null)
            {
                MessageBox.Show($"Welcome {account.Username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open User Home Page
                UserHomePage userHomePage = new UserHomePage();
                userHomePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            // Open registration form
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }
    }
}
