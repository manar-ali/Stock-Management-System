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
    public partial class Manage_Users : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        public Manage_Users()
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

        private void Manage_Users_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 3 && textBox3.TextLength > 3)
            {
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var ruselt = DB.TBL_USERS.SingleOrDefault(x => x.ID == id);
                ruselt.ID = textBox1.Text;
                ruselt.PWD = textBox2.Text;
                ruselt.USER_TYPE = textBox3.Text;
                DB.SaveChanges();
                dataGridView1.DataSource = DB.TBL_USERS.ToList();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label5.Text = " ";
                label6.Text = " ";
            }
            else
            {
                MessageBox.Show("Must insert all fields with corecct data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var ruselt = DB.TBL_USERS.Find(id);

            DB.TBL_USERS.Remove(ruselt);
            DB.SaveChanges();

            dataGridView1.DataSource = DB.TBL_USERS.ToList();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label5.Text = " ";
            label6.Text = " ";
        }
    }
}
