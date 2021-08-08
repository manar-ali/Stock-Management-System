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
    public partial class Manage_Categories : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        public Manage_Categories()
        {
            InitializeComponent();
        }

        public void show()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            dataGridView1.DataSource = DB.CATEGORIES.ToList();
            dataGridView1.Columns[2].Visible = false;
            this.BringToFront();
        }

        private void Manage_Categories_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 1 && textBox2.TextLength > 1)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var ruselt = DB.CATEGORIES.SingleOrDefault(x => x.ID_CAT == id);
                ruselt.ID_CAT = int.Parse(textBox1.Text);
                ruselt.DESCRIPTION_CAT = textBox2.Text;
                DB.SaveChanges();
                dataGridView1.DataSource = DB.CATEGORIES.ToList();
                textBox1.Text = "";
                textBox2.Text = "";
                label3.Text = " ";
                label4.Text = " ";

            }
            else
            {
                MessageBox.Show("All fields are required");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ruselt = DB.CATEGORIES.Find(id);

            DB.CATEGORIES.Remove(ruselt);
            DB.SaveChanges();

            dataGridView1.DataSource = DB.CATEGORIES.ToList();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 1)
            {
                label3.Text = " ";
            }
            else
            {
                label3.Text = " Required !! ";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 1)
            {
                label4.Text = " ";
            }
            else
            {
                label4.Text = " Required !! ";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
