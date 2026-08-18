using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MaDlamini_Library.Form1;

namespace MaDlamini_Library
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            textBox2.Text = UserSession.AmountDue.ToString("F2");

            radioButton1.Checked = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            textBox3.Text = "";

            Books books = new Books();
            BooksBooking booksBooking = new BooksBooking();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = true;
                textBox1.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {

                textBox1.Enabled = false;
                textBox1.Text = textBox2.Text;
                textBox3.Text = "0.00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amountDue = UserSession.AmountDue;

                if (radioButton2.Checked)
                {
                    MessageBox.Show("Transaction complete! Payment of R " + amountDue.ToString("F2") + " processed via Credit Card.",
                        "Payment Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ResetAndReturnToMain();
                    return;
                }

                decimal amountPaid;

                if (!decimal.TryParse(textBox1.Text, out amountPaid))
                {
                    MessageBox.Show("Please enter a valid amount.",
                        "Invalid Amount",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBox1.Focus();
                    return;
                }

                if (amountPaid < amountDue)
                {
                    decimal shortage = amountDue - amountPaid;

                    MessageBox.Show("Amount is short by R " + shortage.ToString("F2") + ". Please enter the correct amount.",
                        "Insufficient Amount",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBox1.Focus();
                    return;
                }

                decimal change = amountPaid - amountDue;

                MessageBox.Show("Transaction complete!\n\nAmount Due:  R " + amountDue.ToString("F2") +
                                "\nAmount Paid: R " + amountPaid.ToString("F2") +
                                "\nChange:      R " + change.ToString("F2"),
                    "Payment Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ResetAndReturnToMain();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during payment processing: " + ex.Message,
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ResetAndReturnToMain()
        {
            // Find Main form
            Main mainForm = null;

            foreach (Form f in Application.OpenForms)
            {
                if (f is Main)
                {
                    mainForm = (Main)f;
                    break;
                }
            }

            if (mainForm != null)
            {
                // Look for Books form inside the panel and call its ResetCart
                foreach (Control control in mainForm.panel1.Controls)
                {
                    if (control is Books books)
                    {
                        books.ResetCart();
                        break;
                    }

                    // Also reset BooksBooking if that was the active form
                    if (control is BooksBooking booking)
                    {
                        booking.ResetForm();
                        break;
                    }
                }


                mainForm.Enabled = true;

                mainForm = new Main();
                mainForm.Show();
            }

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            decimal amountPaid;
            decimal amountDue = UserSession.AmountDue;

            if (decimal.TryParse(textBox1.Text, out amountPaid))
            {
                decimal change = amountPaid - amountDue;
                textBox3.Text = change >= 0
                    ? change.ToString("F2")
                    : "Short by R " + Math.Abs(change).ToString("F2");
            }
            else
            {
                textBox3.Text = "";
            }

        }
    }
}
