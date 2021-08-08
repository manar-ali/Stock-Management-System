using Stock_Management_System.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System.Screens
{
    public partial class Add_New_User : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        public Add_New_User()
        {
            InitializeComponent();
        }

        public void show()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            dataGridView1.DataSource = DB.TBL_USERS.ToList();
            this.BringToFront();
        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.TextLength > 2 && textBox2.TextLength > 2) && (textBox3.Text.ToLower() == "user" || textBox3.Text.ToLower() == "admin"))
            {

                TBL_USERS obj = new TBL_USERS();
                obj.ID = textBox1.Text;
                obj.PWD = textBox2.Text;
                obj.USER_TYPE = textBox3.Text;
                DB.TBL_USERS.Add(obj);
                DB.SaveChanges();

                dataGridView1.DataSource = DB.TBL_USERS.ToList();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label4.Text = " ";
                label5.Text = " ";
                label6.Text = " ";
            }
            else
            {
                MessageBox.Show("Must insert all fields with corecct data");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.ToLower() == "user" || textBox3.Text.ToLower() == "admin")
            {
                label6.Text = "";
            }
            else
            {
                label6.Text = "Type must be user or admin !!";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 3)
            {
                label5.Text = " ";
            }
            else
            {
                label5.Text = "Passwerd must be more than 3 characters !!";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 3)
            {
                label4.Text = " ";
            }
            else
            {
                label4.Text = "ID must be more than 3 characters !!";
            }
        }
    }
}
