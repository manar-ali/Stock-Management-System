using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Stock_Management_System.DB;

namespace Stock_Management_System.Screens
{
    public partial class Add_New_Product : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        string imagepath = "";
        public Add_New_Product()
        {
            
            InitializeComponent();
        }
        public void show()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            pictureBox1.Image = null;
            comboBox1.DataSource = DB.CATEGORIES.ToList();
            comboBox1.DisplayMember = "DESCRIPTION_CAT";
            comboBox1.ValueMember = "ID_CAT";
            dataGridView1.DataSource = DB.PRODUCTS.ToList();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            this.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_New_Product_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = dialog.FileName;
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 1 && textBox2.TextLength >= 1)
            {
                PRODUCT obj = new PRODUCT();
                obj.ID_PRODUCT = int.Parse(textBox1.Text);
                obj.LABEL_PRODUCT = textBox2.Text;
                obj.QTE_IN_STOCK = int.Parse(numericUpDown2.Text);
                obj.PRICE = numericUpDown1.Text;
                obj.ID_CAT = Convert.ToInt32(comboBox1.SelectedValue);
                DB.PRODUCTS.Add(obj);
                DB.SaveChanges();
                if (imagepath != "")
                {
                    string newpath = Environment.CurrentDirectory + "\\Imgs\\" + obj.ID_PRODUCT + ".jpg";
                    File.Copy(imagepath, newpath);
                    obj.IMAGE_PRODUCT = newpath;
                    DB.SaveChanges();
                }
                dataGridView1.DataSource = DB.PRODUCTS.ToList();

                textBox1.Text = "";
                textBox2.Text = "";
                numericUpDown1.Text = "";
                numericUpDown2.Text = "";
                pictureBox1.ImageLocation = "";
            }
            else
            {
                MessageBox.Show("Must insert Data to Add  !!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
