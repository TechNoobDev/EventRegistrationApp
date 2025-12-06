using System;
using System.Windows.Forms;

namespace EventRegistrationApp.Forms
{
    public partial class AdminLogin : Form
    {
        private bool isPasswordVisible = false; 
        // Static admin credentials
        private const string ADMIN_USERNAME = "admin";
        private const string ADMIN_PASSWORD = "Admin123"; 
        public AdminLogin()
        {
            InitializeComponent();
            textBox_password.UseSystemPasswordChar = true; 
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_username.Text.Trim();
            string password = textBox_password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username == ADMIN_USERNAME && password == ADMIN_PASSWORD)
            {
                MessageBox.Show("Welcome Admin!", "Login Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                AdminForm adminPage = new AdminForm();
                adminPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid admin username or password.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_showPassword_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                textBox_password.UseSystemPasswordChar = true;
                label_showPassword.Text = "Show";
                isPasswordVisible = false;
            }
            else
            {
                textBox_password.UseSystemPasswordChar = false;
                label_showPassword.Text = "Hide";
                isPasswordVisible = true;
            }
        }
    }
}
