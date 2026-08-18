using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MaDlamini_Library.Form1;

namespace MaDlamini_Library
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadForm(new Books());
            SetupHeader();
            this.Text = "User Logged In: " + UserSession.FullName + "       " + "Role: " + UserSession.Role + "      " + DateTime.Now.ToString("dd-MMM-yyyy");
            

            string role = UserSession.Role;
            string fullName = UserSession.FullName;

            if (role == "Manager")
            {
                menuStrip1.BackColor = Color.LightGreen;
            }
        }

        private void SetupHeader()
        {

            string role = UserSession.Role;
            string fullName = UserSession.FullName;



        }


        private void LoadForm(Form form)
        {
            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Add(form);
            panel1.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to log out?",
                    "Log Out",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UserSession.FullName = null;
                    UserSession.Role = null;

                    Form1 login = new Form1();
                    login.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging out: " + ex.Message, 
                "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void booksCatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new Books());
        }

        private void booksBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new BooksBooking());
        }

    }
}
