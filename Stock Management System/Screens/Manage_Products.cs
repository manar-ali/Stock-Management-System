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
using Tulpep.NotificationWindow;

namespace Stock_Management_System.Screens
{
    public partial class Manage_Products : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        string imagepath = "";
        public Manage_Products()
        {
            InitializeComponent();
        }
        public void show()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
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

        private void Manage_Products_Load(object sender, EventArgs e)
        {
            if (DB.PRODUCTS.Any())
            {
                dataGridView1.DataSource = DB.PRODUCTS.ToList();
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.pp;
                popup.TitleText = "Notification from stock";
                popup.ContentText = "the stock is empty..!!";
                popup.Popup();
            }
        }

       
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.TextLength >= 1 && textBox1.TextLength >= 1)
            {
                PRODUCT obj = new PRODUCT();
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var ruselt = DB.PRODUCTS.SingleOrDefault(x => x.ID_PRODUCT == id);
                ruselt.ID_PRODUCT = int.Parse(textBox1.Text);
                ruselt.LABEL_PRODUCT = textBox2.Text;
                ruselt.QTE_IN_STOCK = int.Parse(numericUpDown2.Text);
                ruselt.PRICE = numericUpDown1.Text;
                ruselt.ID_CAT = Convert.ToInt32(comboBox1.SelectedValue);
                ruselt.IMAGE_PRODUCT = pictureBox1.ImageLocation;
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
                MessageBox.Show("Must insert  data to Edit");
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            numericUpDown1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value;

            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ruselt = DB.PRODUCTS.SingleOrDefault(x => x.ID_PRODUCT == id);
            pictureBox1.ImageLocation = ruselt.IMAGE_PRODUCT;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (DB.PRODUCTS.Any())
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var ruselt = DB.PRODUCTS.Find(id);


                DB.PRODUCTS.Remove(ruselt);
                DB.SaveChanges();

                dataGridView1.DataSource = DB.PRODUCTS.ToList();
                textBox1.Text = "";
                textBox2.Text = "";
                numericUpDown1.Text = "";
                numericUpDown2.Text = "";
                pictureBox1.ImageLocation = "";
               
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.information;
                popup.TitleText = "Notification from stock";
                popup.ContentText = "the stock is empty..!!";
                popup.Popup();
            }

            if (!DB.PRODUCTS.Any())
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.information;
                popup.TitleText = "Notification from stock";
                popup.ContentText = "the stock is empty..!!";
                popup.Popup();
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
               dataGridView1.DataSource = DB.PRODUCTS.Where(x => x.PRICE == textBox4.Text).ToList();

            }
            else if (textBox4.Text == "")
            {
                dataGridView1.DataSource = DB.PRODUCTS.Where(x => x.LABEL_PRODUCT.Contains(textBox3.Text)).ToList();

            }
            else
            {
                dataGridView1.DataSource = DB.PRODUCTS.Where(x => x.LABEL_PRODUCT.Contains(textBox3.Text) || x.PRICE == textBox4.Text).ToList();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductReport  myreport = new ProductReport();
            FormReport myform = new FormReport();
            myform.crystalReportViewer1.ReportSource = myreport;
            myform.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB.PRODUCTS.ToList();
        }
    }
}
