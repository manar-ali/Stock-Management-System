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
    public partial class Manage_Orders : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        public Manage_Orders()
        {
            InitializeComponent();
        }

        public void show()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            numericUpDown1.Value = 0;
            dataGridView1.DataSource = DB.CUSTOMERS.ToList();
            dataGridView1.Columns[5].Visible = false;
            dataGridView2.DataSource = DB.PRODUCTS.ToList();
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView3.DataSource = DB.ORDERS.ToList();
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            this.BringToFront();
        }

        private void Manage_Orders_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 1 && textBox3.TextLength >= 1 && textBox1.TextLength >= 1)
            {
                ORDER obj = new ORDER();
                obj.ID_CUSTOMER = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                obj.ID_ORDER = int.Parse(textBox1.Text);
                obj.ProductNname = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.Price = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
                obj.QTE = int.Parse(numericUpDown1.Value.ToString());
                obj.TPrice = (obj.Price * obj.QTE);
                obj.DATE_ORDER = dateTimePicker1.Value;
                DB.ORDERS.Add(obj);
                DB.SaveChanges();
                dataGridView3.DataSource = DB.ORDERS.ToList();
            }
            else
            {
                MessageBox.Show("Must insert Order");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderReport myreport = new OrderReport();
            FormReport myform = new FormReport();
            myform.crystalReportViewer1.ReportSource = myreport;
            myform.ShowDialog();
        }
    }
}
