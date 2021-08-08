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
    public partial class Product_Managment : Form
    {
        public Product_Managment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;
            panel4.BringToFront();
            panel4.Visible = true;
            button8.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Height = button5.Height;
            panel3.Top = button5.Top;
            panel5.BringToFront();
            panel5.Visible = true;
            button15.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Height = button4.Height;
            panel3.Top = button4.Top;
            panel6.BringToFront();
            panel6.Visible = true;
            button18.PerformClick();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Height = button6.Height;
            panel3.Top = button6.Top;
            manage_Orders1.show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Height = button7.Height;
            panel3.Top = button7.Top;
           DialogResult  dd = MessageBox.Show("Are you sure you want to logout ?!", "logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dd == DialogResult.Yes)
            {
                log_in1.BringToFront();
                button3.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button20.Enabled = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel9.Visible = false;
            }


        }

        private void log_in1_Load(object sender, EventArgs e)
        {

        }

        private void Product_Managment_Load(object sender, EventArgs e)
        {
            log_in1.BringToFront();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            manage_Users1.show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            add_New_User1.show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Product_Managment_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        private void Product_Managment_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            add_New_Product1.show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            manage_Products1.show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            add_New_Category1.show();
        }

        private void manage_Products1_Load(object sender, EventArgs e)
        {

        }

        private void add_New_Category1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void add_New_Product1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel3.Height = button20.Height;
            panel3.Top = button20.Top;
            panel9.BringToFront();
            panel9.Visible = true;
            button10.PerformClick();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            add_New_Category1.show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            manage_Categories1.show();
        }

        private void add_New_User1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            add_New_Customer2.show();
        }

        private void add_New_Customer2_Load(object sender, EventArgs e)
        {

        }

        private void manage_Customers1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            manage_Customers1.show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void manage_Orders1_Load(object sender, EventArgs e)
        {

        }
    }
}
