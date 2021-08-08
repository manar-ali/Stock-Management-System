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
    public partial class Add_New_Category : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        public Add_New_Category()
        {
            InitializeComponent();
        }

        public void show()
        {
            textBox2.Text = null;
            dataGridView1.DataSource = DB.CATEGORIES.ToList();
            dataGridView1.Columns[2].Visible = false;
            this.BringToFront();
        }

        private void Add_New_Category_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 1)
            {

                CATEGORy obj = new CATEGORy();
                obj.DESCRIPTION_CAT = textBox2.Text;
                DB.CATEGORIES.Add(obj);
                DB.SaveChanges();

                dataGridView1.DataSource = DB.CATEGORIES.ToList();
                textBox2.Text = "";
                label4.Text = " ";
            }
            else
            {
                MessageBox.Show("You Must insert name");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
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
    }
}
