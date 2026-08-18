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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaDlamini_Library
{
    public partial class BooksBooking : Form
    {
        public BooksBooking()
        {
            InitializeComponent();
        }   

            List<string> allItems = new List<string>();

            private bool IsTextOnly(string input)
            {
                if (string.IsNullOrWhiteSpace(input)) return false;

                foreach (char c in input)
                {
                    if (!char.IsLetter(c) && c != ' ' && c != '-')
                        return false;
                }
                return true;
            }
            private bool IsValidSAPhone(string number)
            {
                if (string.IsNullOrWhiteSpace(number) ||
                    number.Length != 10 ||
                    !number.All(char.IsDigit))
                    return false;

                if (number[0] != '0')
                    return false;


                char second = number[1];
                if (second != '6' && second != '7' && second != '8')
                    return false;

                return true;
            }


            private bool IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email)) return false;

                int atIndex = email.IndexOf('@');


                if (atIndex <= 0) return false;
                if (email.IndexOf('@', atIndex + 1) >= 0) return false;

                string domain = email.Substring(atIndex + 1);


                int dotIndex = domain.LastIndexOf('.');
                if (dotIndex <= 0 || dotIndex == domain.Length - 1) return false;

                return true;
            }


            private bool IsValidPostalCode(string code)
            {
                if (string.IsNullOrWhiteSpace(code) ||
                    code.Length < 4 ||
                    !code.All(char.IsDigit))
                    return false;

                return true;
            }
            private bool IsValidID(string idNumber)
            {

                if (string.IsNullOrWhiteSpace(idNumber)) return false;
                if (idNumber.Length != 13) return false;
                if (!idNumber.All(char.IsDigit)) return false;


                int year = int.Parse(idNumber.Substring(0, 2));
                int month = int.Parse(idNumber.Substring(2, 2));
                int day = int.Parse(idNumber.Substring(4, 2));


                if (month < 1 || month > 12) return false;
                if (day < 1 || day > 31) return false;


                try
                {
                    DateTime testDate = new DateTime(2000 + year, month, day);
                }
                catch
                {
                    return false;
                }


                int citizenship = int.Parse(idNumber[10].ToString());
                if (citizenship != 0 && citizenship != 1) return false;


                int checkDigit = int.Parse(idNumber[12].ToString());
                return checkDigit == CalculateLuhn(idNumber.Substring(0, 12));
            }

            private int CalculateLuhn(string number)
            {
                int sum = 0;
                bool doubled = false;


                for (int i = number.Length - 1; i >= 0; i--)
                {
                    int digit = int.Parse(number[i].ToString());

                    if (doubled)
                    {
                        digit = digit * 2;


                        if (digit > 9)
                            digit = digit - 9;
                    }

                    sum = sum + digit;
                    doubled = !doubled;
                }

                return (10 - (sum % 10)) % 10;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    string errors = "";

                decimal bookingFee;
                if (!decimal.TryParse(textBox10.Text, out bookingFee) || bookingFee <= -1)
                {
                    errors += "• Booking Fee: must be a valid positive number.\n";
                }

                // Book selected
                if (listBox1.SelectedItem == null || textBox8.Text.Trim() == "")
                        errors += "• Book: please select a book from the list.\n";

                    // Name
                    if (!IsTextOnly(textBox3.Text) || textBox3.Text.Trim().Length < 4)
                        errors += "• Enter a Valid Name.\n";

                    // Surname
                    if (!IsTextOnly(textBox4.Text)|| textBox4.Text.Trim().Length < 4)
                        errors += "• Enter a valid surname.\n";

                    // ID Number
                    if (!IsValidID(textBox5.Text))
                        errors += "• ID Number: must be a valid 13-digit South African ID.\n";

                    // Phone
                    if (!IsValidSAPhone(textBox6.Text))
                        errors += "• Phone Number: must be a valid 10-digit South African number.\n";

                    // Email
                    if (!IsValidEmail(textBox7.Text))
                        errors += "• Enter a valid email\n";

                    //Street Name
                    if (textBox8.Text.Trim() == "" || textBox8.Text.Trim().Length < 4)
                        errors += "• Enter a valid Street Name\n";

                    // Suburb
                    if (!IsTextOnly(textBox9.Text))
                        errors += "• Enter a valid Suburb name\n";
                    // Province
                    if (/*comboBox2.SelectedIndex == 0 ||*/ comboBox2.SelectedItem.ToString() == "Select Province")
                        errors += "• Province: please select a province.\n";

                    // City
                    if (/*comboBox3.SelectedIndex == 0 ||*/ comboBox3.SelectedItem.ToString() == "Select City")
                        errors += "• City: please select a city.\n";


                    // Postal Code
                    if (!IsValidPostalCode(textBox11.Text))
                        errors += "• Postal Code: must be exactly 4 digits.\n";
   

                if (errors.Length > 0)
                    {
                        MessageBox.Show("Please correct the following:\n\n" + errors,
                            "Validation Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                else
                {
                    DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to proceed to payment?",
                        "Confirm Booking",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        
                        decimal.TryParse(textBox10.Text, out bookingFee);
                        UserSession.AmountDue = bookingFee;

                        Form mainForm = this.ParentForm;
                        if (mainForm != null) mainForm.Enabled = false;

                        Payment payment = new Payment();

                        payment.FormClosed += (s, args) =>
                        {
                            if (mainForm != null) mainForm.Enabled = true;
                        };

                        payment.Show();
                    }
                }
            }
                catch(Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

            private void BooksBooking_Load(object sender, EventArgs e)
            {
            try
            {
                foreach (var item in listBox1.Items)
                {
                    allItems.Add(item.ToString());
                }
                dateTimePicker1.MinDate = DateTime.Today;
                dateTimePicker1.MaxDate = DateTime.Today.AddMonths(1);
                textBox13.Text = DateTime.Today.ToString("dd/MMM/yyyy");
                comboBox1.SelectedIndex = 0;
                comboBox3.Enabled = false;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

                toolTip1.SetToolTip(textBox3, "Enter your first name. Letters and hyphens only.");
                toolTip1.SetToolTip(textBox4, "Enter your surname. Letters and hyphens only.");
                toolTip1.SetToolTip(textBox9, "Enter your suburb. Letters and hyphens only.");
                toolTip1.SetToolTip(textBox5, "Enter your 13-digit South African ID number.");
                toolTip1.SetToolTip(textBox12, "Date of birth will auto-fill from your ID number.");
                toolTip1.SetToolTip(textBox6, "Enter a valid 10-digit South African phone number e.g. 0821234567.");
                toolTip1.SetToolTip(textBox7, "Enter a valid email address e.g. amahleD@gmail.com .");
                toolTip1.SetToolTip(textBox1, "Enter your 4-digit South African postal code e.g. 4001.");
                toolTip1.SetToolTip(textBox10, "Booking fee — automatically set when a book is selected.");
                toolTip1.SetToolTip(textBox8, "Enter valid street address.");
                toolTip1.SetToolTip(comboBox1, "Select your province first before choosing a city.");
                toolTip1.SetToolTip(comboBox2, "Select your city. Available after selecting a province.");
                toolTip1.SetToolTip(comboBox3, "Filter books by category.");
                toolTip1.SetToolTip(listBox1, "Click a book to select it for booking.");
                toolTip1.SetToolTip(button1, "Click to proceed to payment. All fields must be filled correctly.");
                toolTip1.SetToolTip(dateTimePicker1, "Select a booking date within the next month.");
                toolTip1.SetToolTip(textBox10, "Enter Valid Booking Fee");

                string Role = UserSession.Role;
                if (Role == "Manager")
                {
                    label18.Visible = true;
                    textBox10.Enabled= true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during form initialization: " + ex.Message,
                    "Initialization Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {
            try
            {
                string search = textBox2.Text.ToLower();

                listBox1.Items.Clear();

                foreach (var item in allItems)
                {
                    if (item.ToLower().Contains(search))
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during search: " + ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

            private void textBox4_TextChanged(object sender, EventArgs e)
            {
                if (IsTextOnly(textBox4.Text))
                {
                    textBox4.ForeColor = Color.Black;
                }
                else
                {
                    textBox4.ForeColor = Color.Red;
                }
            }

            private void textBox3_TextChanged(object sender, EventArgs e)
            {
                if (IsTextOnly(textBox3.Text))
                {
                    textBox3.ForeColor = Color.Black;
                }
                else
                {
                    textBox3.ForeColor = Color.Red;
                }
            }

            private void textBox6_TextChanged(object sender, EventArgs e)
            {
                if (IsValidSAPhone(textBox6.Text))
                {
                    textBox6.ForeColor = Color.Black;
                }
                else
                {
                    textBox6.ForeColor = Color.Red;
                }
            }

            private void textBox7_TextChanged(object sender, EventArgs e)
            {
                if (IsValidEmail(textBox7.Text))
                {
                    textBox7.ForeColor = Color.Black;
                }
                else
                {
                    textBox7.ForeColor = Color.Red;
                }
            }

            private void textBox11_TextChanged(object sender, EventArgs e)
            {
                if (IsValidPostalCode(textBox11.Text))
                {
                    textBox11.ForeColor = Color.Black;
                }
                else
                {
                    textBox11.ForeColor = Color.Red;
                }
            }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {
            try
            {
                if (IsValidID(textBox5.Text))
                {
                    textBox5.ForeColor = Color.Black;


                    int year = int.Parse(textBox5.Text.Substring(0, 2));
                    int month = int.Parse(textBox5.Text.Substring(2, 2));
                    int day = int.Parse(textBox5.Text.Substring(4, 2));


                    int fullYear;
                    if (year > DateTime.Today.Year % 100)
                        fullYear = 1900 + year;
                    else
                        fullYear = 2000 + year;

                    DateTime dob = new DateTime(fullYear, month, day);

                    textBox12.Text = dob.ToString("dd MMM yyyy");
                }
                else
                {
                    textBox5.ForeColor = Color.Red;
                    textBox12.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while validating ID: " + ex.Message,
                    "ID Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

            private void groupBox1_Enter(object sender, EventArgs e)
            {

            }

            private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                comboBox3.Items.Add("Select City");
                comboBox3.SelectedIndex = 0;
                //comboBox3.Items.Clear();

                string province = comboBox2.SelectedItem.ToString();

                if (province == "Select Province")
                {
                    comboBox3.Enabled = false;
                    comboBox3.Items.Add("Select Province");
                    comboBox3.SelectedIndex = 0;
                    return;
                }


                if (province == "Eastern Cape")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Bhisho");
                    comboBox3.Items.Add("Gqeberha");
                    comboBox3.Items.Add("East London");
                    comboBox3.Items.Add("Mthatha");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "Free State")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Bloemfontein");
                    comboBox3.Items.Add("Welkom");
                    comboBox3.Items.Add("Sasolburg");
                    comboBox3.Items.Add("Kroonstad");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "Gauteng")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Johannesburg");
                    comboBox3.Items.Add("Pretoria");
                    comboBox3.Items.Add("Soweto");
                    comboBox3.Items.Add("Randburg");
                    comboBox3.Items.Add("Roodepoort");
                    comboBox3.Items.Add("Benoni");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "KwaZulu-Natal")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Pietermaritzburg");
                    comboBox3.Items.Add("Durban");
                    comboBox3.Items.Add("Richards Bay");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "Limpopo")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Polokwane");
                    comboBox3.Items.Add("Tzaneen");
                    comboBox3.Items.Add("Bela-Bela");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "Mpumalanga")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Mbombela");
                    comboBox3.Items.Add("Emalahleni");
                    comboBox3.Items.Add("Standerton");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "North West")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Mahikeng");
                    comboBox3.Items.Add("Rustenburg");
                    comboBox3.Items.Add("Potchefstroom");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "Northern Cape")
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Kimberley");
                    comboBox3.Items.Add("Upington");
                    comboBox3.Items.Add("Springbok");
                    comboBox3.SelectedIndex = 0;
                }
                else if (province == "Western Cape")
                {

                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Cape Town");
                    comboBox3.Items.Add("George");
                    comboBox3.Items.Add("Paarl");
                    comboBox3.Items.Add("Worcester");
                    comboBox3.SelectedIndex = 0;
                }

                comboBox3.Enabled = true;
            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                //string category = comboBox1.SelectedItem.ToString();

                listBox1.Items.Clear();

                if (comboBox1.SelectedIndex == 0)
                {
                    listBox1.Items.Add("Patrice Motsepe: An Appetite for Disruption");
                    listBox1.Items.Add("Diplomatic Ties");
                    listBox1.Items.Add("Black Skin, White Masks");
                    listBox1.Items.Add("Malema: Money. Power. Patronage");
                    listBox1.Items.Add("The 48 Laws Of Power");
                    listBox1.Items.Add("Oracle Database 12c SQL");
                    listBox1.Items.Add("Learning Python: Powerful Object-Oriented Programming");
                    listBox1.Items.Add("HTML and CSS: Design and Build Websites");
                    listBox1.Items.Add("PHP & MySQL: Server-side Web Development");
                    listBox1.Items.Add("SQL All-in-One For Dummies");
                    listBox1.Items.Add("Nineteen Eighty-Four: A Novel");
                    listBox1.Items.Add("Animal Farm");
                    listBox1.Items.Add("White Nights");
                    listBox1.Items.Add("The Idiot");
                    listBox1.Items.Add("The Karamazov Brothers");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    listBox1.Items.Add("Patrice Motsepe: An Appetite for Disruption");
                    listBox1.Items.Add("Diplomatic Ties");
                    listBox1.Items.Add("Black Skin, White Masks");
                    listBox1.Items.Add("Malema: Money. Power. Patronage");
                    listBox1.Items.Add("The 48 Laws Of Power");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    listBox1.Items.Add("Oracle Database 12c SQL");
                    listBox1.Items.Add("Learning Python: Powerful Object-Oriented Programming");
                    listBox1.Items.Add("HTML and CSS: Design and Build Websites");
                    listBox1.Items.Add("PHP & MySQL: Server-side Web Development");
                    listBox1.Items.Add("SQL All-in-One For Dummies");
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    listBox1.Items.Add("Nineteen Eighty-Four: A Novel");
                    listBox1.Items.Add("Animal Farm");
                    listBox1.Items.Add("White Nights");
                    listBox1.Items.Add("The Idiot");
                    listBox1.Items.Add("The Karamazov Brothers");
                }
            }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBox1.SelectedItem != null)
                {
                    textBox1.Text = listBox1.SelectedItem.ToString();
                    textBox10.Text = "110";
                }
                else
                {
                    textBox1.Text = "";
                    textBox10.Text = "";
                }
            }
            public void ResetForm()
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();

                dateTimePicker1.Value = DateTime.Today;

                comboBox1.SelectedIndex = 0;

                comboBox3.Items.Clear();
                comboBox3.Items.Add("Select Province");
                comboBox3.SelectedIndex = 0;
                comboBox3.Enabled = false;

                comboBox2.Items.Clear();
                comboBox2.SelectedIndex = 0;

                listBox1.ClearSelected();
            }
        }
    }
