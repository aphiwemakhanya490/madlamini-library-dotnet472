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
    public partial class Books : Form
    {
        int qtyBakers = 0;
        int aqty = 0;
        int bqty = 0;
        int cqty = 0;
        int dqty = 0;
        int eqty = 0;
        int fqty = 0;
        int gqty = 0;
        int hqty = 0;
        int iqty = 0;
        int jqty = 0;
        int kqty = 0;
        public Books()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                qtyBakers++;
                textBox2.Text = qtyBakers.ToString();

                decimal price = 210m * qtyBakers;
                UpdateOrAddRow("Diplomatic Ties", qtyBakers, price);

                button3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                aqty--;
                textBox1.Text = aqty.ToString();

                if (aqty <= 0)
                {
                    aqty = 0;
                    textBox1.Text = "0";
                    RemoveRow("Patrice Motsepe: An Appetite for Disruption");
                    button1.Enabled = false;
                }
                else
                {
                    decimal price = 200m * aqty;
                    UpdateOrAddRow("Patrice Motsepe: An Appetite for Disruption", aqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }
        private void UpdateOrAddRow(string productName, int qty, decimal price)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString() == productName)
                {
                    row.Cells[1].Value = qty;
                    row.Cells[2].Value = price.ToString("F2");
                    return;
                }
            }

            dataGridView1.Rows.Add(productName, qty, price.ToString("F2"));
            CalculateSubTotal();
        }

        private void RemoveRow(string productName)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString() == productName)
                {
                    dataGridView1.Rows.Remove(row);
                    return;
                }
            }
            CalculateSubTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                aqty++;
                textBox1.Text = aqty.ToString();

                decimal price = 200m * aqty;
                UpdateOrAddRow("Patrice Motsepe: An Appetite for Disruption", aqty, price);
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                qtyBakers--;
                textBox2.Text = qtyBakers.ToString();

                if (qtyBakers <= 0)
                {
                    qtyBakers = 0;
                    textBox2.Text = "0";
                    RemoveRow("Diplomatic Ties");
                    button3.Enabled = false;
                }
                else
                {
                    decimal price = 210m * qtyBakers;
                    UpdateOrAddRow("Diplomatic Ties", qtyBakers, price);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bqty++;
                textBox3.Text = bqty.ToString();

                decimal price = 240m * bqty;
                UpdateOrAddRow("Black Skin, White Masks", bqty, price);
                button6.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,

                    MessageBoxIcon.Error);
            }
            }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                bqty--;
                textBox3.Text = bqty.ToString();

                if (bqty <= 0)
                {
                    bqty = 0;
                    textBox3.Text = "0";
                    RemoveRow("Black Skin, White Masks");
                    button6.Enabled = false;
                }
                else
                {
                    decimal price = 240m * bqty;
                    UpdateOrAddRow("Black Skin, White Masks", bqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            { 
            cqty++;
            textBox4.Text = cqty.ToString();

            decimal price = 400m * cqty;
            UpdateOrAddRow("Malema: Money. Power. Patronage", cqty, price);

            button8.Enabled = true;
                }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                cqty--;
                textBox4.Text = cqty.ToString();

                if (cqty <= 0)
                {
                    cqty = 0;
                    textBox4.Text = "0";
                    RemoveRow("Malema: Money. Power. Patronage");
                    button8.Enabled = false;
                }
                else
                {
                    decimal price = 400m * cqty;
                    UpdateOrAddRow("Malema: Money. Power. Patronage", cqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                dqty--;
                textBox8.Text = dqty.ToString();

                if (dqty <= 0)
                {
                    dqty = 0;
                    textBox8.Text = "0";
                    RemoveRow("1984: A Novel");
                    button16.Enabled = false;
                }
                else
                {
                    decimal price = 360m * dqty;
                    UpdateOrAddRow("1984: A Novel", dqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            { 
            dqty++;
            textBox8.Text = dqty.ToString();

            decimal price = 360m * dqty;
            UpdateOrAddRow("1984: A Novel", dqty, price);
            button16.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                eqty++;
                textBox7.Text = eqty.ToString();

                decimal price = 340m * eqty;
                UpdateOrAddRow("Animal Farm", eqty, price);
                button14.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                eqty--;
                textBox7.Text = eqty.ToString();

                if (eqty <= 0)
                {
                    eqty = 0;
                    textBox7.Text = "0";
                    RemoveRow("Animal Farm");
                    button14.Enabled = false;
                }
                else
                {
                    decimal price = 340m * eqty;
                    UpdateOrAddRow("Animal Farm", eqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                fqty++;
                textBox6.Text = fqty.ToString();

                decimal price = 500m * fqty;
                UpdateOrAddRow("White Nights", fqty, price);

                button12.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                fqty--;
                textBox6.Text = fqty.ToString();

                if (fqty <= 0)
                {
                    fqty = 0;
                    textBox6.Text = "0";
                    RemoveRow("White Nights");
                    button12.Enabled = false;
                }
                else
                {
                    decimal price = 500m * fqty;
                    UpdateOrAddRow("White Nights", fqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                gqty++;
                textBox5.Text = gqty.ToString();

                decimal price = 600m * gqty;
                UpdateOrAddRow("The Idiot", gqty, price);
                button10.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                gqty--;
                textBox5.Text = gqty.ToString();

                if (gqty <= 0)
                {
                    gqty = 0;
                    textBox5.Text = "0";
                    RemoveRow("The Idiot");
                    button10.Enabled = false;
                }
                else
                {
                    decimal price = 600m * gqty;
                    UpdateOrAddRow("The Idiot", gqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                hqty++;
                textBox12.Text = hqty.ToString();

                decimal price = 540m * hqty;
                UpdateOrAddRow("Oracle Database 12c SQL", hqty, price);
                button24.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                hqty--;
                textBox12.Text = hqty.ToString();

                if (hqty <= 0)
                {
                    hqty = 0;
                    textBox12.Text = "0";
                    RemoveRow("Oracle Database 12c SQL");
                    button24.Enabled = false;
                }
                else
                {
                    decimal price = 540m * hqty;
                    UpdateOrAddRow("Oracle Database 12c SQL", hqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                iqty++;
                textBox11.Text = iqty.ToString();

                decimal price = 520m * iqty;
                UpdateOrAddRow("Learning Python: Powerful Object-Oriented Programming", iqty, price);
                button22.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                iqty--;
                textBox11.Text = iqty.ToString();

                if (iqty <= 0)
                {
                    iqty = 0;
                    textBox11.Text = "0";
                    RemoveRow("Learning Python: Powerful Object-Oriented Programming");
                    button22.Enabled = false;
                }
                else
                {
                    decimal price = 520m * iqty;
                    UpdateOrAddRow("Learning Python: Powerful Object-Oriented Programming", iqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                jqty++;
                textBox10.Text = jqty.ToString();

                decimal price = 700m * jqty;
                UpdateOrAddRow("HTML and CSS: Design and Build Websites", jqty, price);
                button20.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                jqty--;
                textBox10.Text = jqty.ToString();

                if (jqty <= 0)
                {
                    jqty = 0;
                    textBox10.Text = "0";
                    RemoveRow("HTML and CSS: Design and Build Websites");
                    button20.Enabled = false;
                }
                else
                {
                    decimal price = 700m * jqty;
                    UpdateOrAddRow("HTML and CSS: Design and Build Websites", jqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                kqty++;
                textBox9.Text = kqty.ToString();

                decimal price = 900m * kqty;
                UpdateOrAddRow("PHP & MySQL: Server-side Web Development", kqty, price);
                button18.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding item to cart: " + ex.Message,
                    "Add to Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                kqty--;
                textBox9.Text = kqty.ToString();

                if (kqty <= 0)
                {
                    kqty = 0;
                    textBox9.Text = "0";
                    RemoveRow("PHP & MySQL: Server-side Web Development");
                    button18.Enabled = false;
                }
                else
                {
                    decimal price = 900m * kqty;
                    UpdateOrAddRow("PHP & MySQL: Server-side Web Development", kqty, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while removing item from cart: " + ex.Message,
                    "Remove from Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            }
        private void CalculateSubTotal()
        {
            decimal subTotal = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    decimal rowPrice;
                    if (decimal.TryParse(row.Cells[2].Value.ToString(), out rowPrice))
                    {
                        subTotal += rowPrice;
                    }
                }
            }

            decimal tax = subTotal * 0.15m;
            decimal totalBeforeTax = subTotal - tax;

            textBox15.Text = totalBeforeTax.ToString("F2");
            textBox14.Text = tax.ToString("F2");
            textBox13.Text = subTotal.ToString("F2");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.SelectedRows[0].Cells[0].Value == null ||
                   dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Please select a valid item to remove.",
                        "Invalid Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string productName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                switch (productName)
                {
                    case "Patrice Motsepe: An Appetite for Disruption":
                        aqty = 0; textBox1.Text = "0"; button1.Enabled = false;
                        break;
                    case "Diplomatic Ties":
                        qtyBakers = 0; textBox2.Text = "0"; button3.Enabled = false;
                        break;
                    case "Black Skin, White Masks":
                        bqty = 0; textBox3.Text = "0"; button6.Enabled = false;
                        break;
                    case "Malema: Money. Power. Patronage":
                        cqty = 0; textBox4.Text = "0"; button8.Enabled = false;
                        break;
                    case "1984: A Novel":
                        dqty = 0; textBox8.Text = "0"; button16.Enabled = false;
                        break;
                    case "Animal Farm":
                        eqty = 0; textBox7.Text = "0"; button14.Enabled = false;
                        break;
                    case "White Nights":
                        fqty = 0; textBox6.Text = "0"; button12.Enabled = false;
                        break;
                    case "The Idiot":
                        gqty = 0; textBox5.Text = "0"; button10.Enabled = false;
                        break;
                    case "Oracle Database 12c SQL":
                        hqty = 0; textBox12.Text = "0"; button24.Enabled = false;
                        break;
                    case "Learning Python: Powerful Object-Oriented Programming":
                        iqty = 0; textBox11.Text = "0"; button22.Enabled = false;
                        break;
                    case "HTML and CSS: Design and Build Websites":
                        jqty = 0; textBox10.Text = "0"; button20.Enabled = false;
                        break;
                    case "PHP & MySQL: Server-side Web Development":
                        kqty = 0; textBox9.Text = "0"; button18.Enabled = false;
                        break;
                    default:
                        MessageBox.Show("Item not recognised.",
                            "Unknown Item",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                }

                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                CalculateSubTotal();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred While removing item from cart: " + ex.Message,
                    "Remove Item Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show(
            "Are you sure you want to remove all items?",
            "Clear All",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    ResetCart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clear Cart failed error: " + ex.Message,
                    "Clear Cart Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            }
        public void ResetCart()
        {
            dataGridView1.Rows.Clear();


            qtyBakers = 0; aqty = 0; bqty = 0; cqty = 0;
            dqty = 0; eqty = 0; fqty = 0; gqty = 0;
            hqty = 0; iqty = 0; jqty = 0; kqty = 0;


            textBox1.Text = "0"; textBox2.Text = "0";
            textBox3.Text = "0"; textBox4.Text = "0";
            textBox5.Text = "0"; textBox6.Text = "0";
            textBox7.Text = "0"; textBox8.Text = "0";
            textBox9.Text = "0"; textBox10.Text = "0";
            textBox11.Text = "0"; textBox12.Text = "0";


            button1.Enabled = false; button3.Enabled = false;
            button6.Enabled = false; button8.Enabled = false;
            button10.Enabled = false; button12.Enabled = false;
            button14.Enabled = false; button16.Enabled = false;
            button18.Enabled = false; button20.Enabled = false;
            button22.Enabled = false; button24.Enabled = false;


            CalculateSubTotal();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to proceed to payment?",
                        "Confirm Booking",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count == 1)
                    {
                        MessageBox.Show("No items in cart. Please add items before proceeding.",
                            "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    decimal totalAmount;
                    decimal.TryParse(textBox13.Text, out totalAmount);
                    UserSession.AmountDue = totalAmount;


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
            catch (Exception ex)
            {
                MessageBox.Show("An error occured when proceeding to Payment: " + ex.Message,
                    "Proceed to Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Books_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Click to add Patrice Motsepe to cart.");
            toolTip1.SetToolTip(button4, "Click to add Diplomatic Ties to cart.");
            toolTip1.SetToolTip(button5, "Click to add Black Skin, White Masks to cart.");
            toolTip1.SetToolTip(button7, "Click to add Malema: Money. Power. Patronage to cart.");
            toolTip1.SetToolTip(button15, "Click to add 1984: A Novel to cart.");
            toolTip1.SetToolTip(button13, "Click to add Animal Farm to cart.");
            toolTip1.SetToolTip(button11, "Click to add White Nights to cart.");
            toolTip1.SetToolTip(button9, "Click to add The Idiot to cart.");
            toolTip1.SetToolTip(button23, "Click to add Oracle Database 12c SQL to cart.");
            toolTip1.SetToolTip(button21, "Click to add Learning Python to cart.");
            toolTip1.SetToolTip(button19, "Click to add HTML and CSS: Design and Build Websites to cart.");
            toolTip1.SetToolTip(button17, "Click to add PHP & MySQL: Server-side Web Development to cart.");


            toolTip1.SetToolTip(button1, "Click to remove one Patrice Motsepe from cart.");
            toolTip1.SetToolTip(button3, "Click to remove one Diplomatic Ties from cart.");
            toolTip1.SetToolTip(button6, "Click to remove one Black Skin, White Masks from cart.");
            toolTip1.SetToolTip(button8, "Click to remove one Malema: Money. Power. Patronage from cart.");
            toolTip1.SetToolTip(button16, "Click to remove one 1984: A Novel from cart.");
            toolTip1.SetToolTip(button14, "Click to remove one Animal Farm from cart.");
            toolTip1.SetToolTip(button12, "Click to remove one White Nights from cart.");
            toolTip1.SetToolTip(button10, "Click to remove one The Idiot from cart.");
            toolTip1.SetToolTip(button24, "Click to remove one Oracle Database 12c SQL from cart.");
            toolTip1.SetToolTip(button22, "Click to remove one Learning Python from cart.");
            toolTip1.SetToolTip(button20, "Click to remove one HTML and CSS: Design and Build Websites from cart.");
            toolTip1.SetToolTip(button18, "Click to remove one PHP & MySQL: Server-side Web Development from cart.");


            toolTip1.SetToolTip(button25, "Click to remove the selected item from the cart.");
            toolTip1.SetToolTip(button26, "Click to clear all items from the cart.");
            toolTip1.SetToolTip(button27, "Click to proceed to payment. Cart must not be empty.");

        }
    }
}
