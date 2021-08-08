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
    public partial class Add_New_Customer : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        string pattern = "^[a-zA-Z][\\w\\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
        public Add_New_Customer()
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
            dataGridView1.DataSource = DB.CUSTOMERS.ToList();
            dataGridView1.Columns[5].Visible = false;
            this.BringToFront();
        }

        private void Add_New_Customer_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var txt = textBox4.Text;
            if ((txt.StartsWith("0114") || txt.StartsWith("0115") || txt.StartsWith("010") || txt.StartsWith("012") || txt.StartsWith("015")) && textBox4.TextLength == 11)
            {
                label10.Text = " ";
            }
            else
            {
                label10.Text = "Phone must have a valid format";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 1 && textBox2.TextLength >= 2 && textBox3.TextLength >= 2 && textBox4.TextLength >= 10 && Regex.IsMatch(textBox5.Text, pattern))
            {

                CUSTOMER obj = new CUSTOMER();
                obj.ID_CUSTOMER = int.Parse(textBox1.Text);
                obj.FIRST_NAME = textBox2.Text;
                obj.LAST_NAME = textBox3.Text;
                obj.TEL = textBox4.Text;
                obj.EMAIL = textBox5.Text;
                DB.CUSTOMERS.Add(obj);
                DB.SaveChanges();

                dataGridView1.DataSource = DB.CUSTOMERS.ToList();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                label6.Text = " ";
                label8.Text = " ";
                label9.Text = " ";
                label10.Text = " ";
                label11.Text = " ";
            }
            else
            {
                MessageBox.Show("Must insert all fields with correct data !!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox5.Text, pattern))
            {
                label11.Text = " ";
            }
            else
            {
                label11.Text = "Email must have a valid format";
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 1)
            {
                label6.Text = " ";
            }
            else
            {
                label6.Text = "Required !!";
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 3)
            {
                label8.Text = " ";
            }
            else
            {
                label8.Text = "First name must be 3 or more charecters";
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox3.TextLength >= 3)
            {
                label9.Text = " ";
            }
            else
            {
                label9.Text = "Last name must be 3 or more charecters";
            }
        }
    }
}
