using Stock_Management_System.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System.Screens
{
    public partial class Manage_Customers : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        string pattern = "^[a-zA-Z][\\w\\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
        public Manage_Customers()
        {
            InitializeComponent();
        }

        public void show()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            label8.Text = "0";
            label10.Text = "0";
            label11.Text = "DD/MM/YYYY";
            dataGridView1.DataSource = DB.CUSTOMERS.ToList();
            dataGridView1.Columns[5].Visible = false;
            this.BringToFront();
        }

        private void Manage_Customers_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 3)
            {
                label16.Text = " ";
            }
            else
            {
                label16.Text = "First name must be 3 or more charecters";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.TextLength >= 3)
            {
                label15.Text = " ";
            }
            else
            {
                label15.Text = "Last name must be 3 or more charecters";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var txt = textBox4.Text;
            if ((txt.StartsWith("0114") || txt.StartsWith("0115") || txt.StartsWith("010") || txt.StartsWith("012") || txt.StartsWith("015")) && textBox4.TextLength == 11)
            {
                label14.Text = " ";
            }
            else
            {
                label14.Text = "Phone must have a valid format";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox5.Text, pattern))
            {
                label13.Text = " ";
            }
            else
            {
                label13.Text = "Email must have a valid format";
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            var txt1 = int.Parse(textBox1.Text);
            var query1 = DB.ORDERS
                        .Where(o => o.ID_CUSTOMER == txt1)
                        .Count();
            label8.Text = query1.ToString();

            var txt2 = int.Parse(textBox1.Text);
            var query2 = DB.ORDERS
                        .Where(o => o.ID_CUSTOMER == txt2)
                        .Sum(o => o.TPrice);
            label10.Text = query2.ToString();

            var txt3 = int.Parse(textBox1.Text);
            var query3 = DB.ORDERS
                        .Where(o => o.ID_CUSTOMER == txt2)
                        .Max(o => o.DATE_ORDER);
            label11.Text = query3.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 3 && textBox3.TextLength >= 3 && textBox4.TextLength >= 11 && Regex.IsMatch(textBox5.Text, pattern))
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var ruselt = DB.CUSTOMERS.SingleOrDefault(x => x.ID_CUSTOMER == id);
                ruselt.FIRST_NAME = textBox2.Text;
                ruselt.LAST_NAME = textBox3.Text;
                ruselt.TEL = textBox4.Text;
                ruselt.EMAIL = textBox5.Text;
                DB.SaveChanges();
                dataGridView1.DataSource = DB.CUSTOMERS.ToList();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                label16.Text = " ";
                label15.Text = " ";
                label14.Text = " ";
                label13.Text = " ";
            }
            else
            {
                MessageBox.Show("Must insert all fields with correct data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ruselt = DB.CUSTOMERS.Find(id);

            DB.CUSTOMERS.Remove(ruselt);
            DB.SaveChanges();

            dataGridView1.DataSource = DB.CUSTOMERS.ToList();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label16.Text = " ";
            label15.Text = " ";
            label14.Text = " ";
            label13.Text = " ";
        }
    }
}
