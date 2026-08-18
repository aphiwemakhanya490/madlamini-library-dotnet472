using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaDlamini_Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static class UserSession
        {
            public static string FullName { get; set; }
            public static string Role { get; set; }
            public static decimal AmountDue { get; set; }
        }
        public class User
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }

        private readonly List<User> users = new List<User>
        {
          new User { FullName = "Amahle Dlamini",  Email = "amahleD@madlaminiLib.co.za",  Password = "amahle@1",  Role = "Admin"   },
          new User { FullName = "Zama Mthembu",    Email = "zamaM@madlaminiLib.co.za",    Password = "123zam3",    Role = "Admin"   },
          new User { FullName = "Bandile Msweli", Email = "bandileM@madlaminiLib.co.za",  Password = "12aphiwe3",  Role = "Manager" },
        };

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBox1.Text.Trim().ToLower();
                string password = textBox2.Text.Trim();

                User loggedInUser = users.Find(u => u.Email == email && u.Password == password);

                if (loggedInUser != null)
                {
                    UserSession.FullName = loggedInUser.FullName;
                    UserSession.Role = loggedInUser.Role;

                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid email or password. Please try again.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred during login: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
