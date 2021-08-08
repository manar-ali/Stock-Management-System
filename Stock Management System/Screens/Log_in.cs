using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock_Management_System.DB;

namespace Stock_Management_System.Screens
{
    public partial class Log_in : UserControl
    {
        product_DBEntities1 DB = new product_DBEntities1();
        Product_Managment frm;
        public Log_in()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = DB.TBL_USERS.Where(u => u.ID == txtID.Text && u.PWD == txtPass.Text).ToList();
            var type1 = DB.TBL_USERS.Where(t => t.ID == txtID.Text && t.USER_TYPE.ToLower() == "user").ToList();
            var type2 = DB.TBL_USERS.Where(t => t.ID == txtID.Text && t.USER_TYPE.ToLower() == "admin").ToList();
            if (result.Count() > 0 && type2.Count() > 0)
            {
                frm = (Product_Managment)this.Parent;
                frm.Invoke(new Action(() =>
                {
                    frm.button3.Enabled = true;
                    frm.button5.Enabled = true;
                    frm.button4.Enabled = true;
                    frm.button6.Enabled = true;
                    frm.button7.Enabled = true;
                    frm.button20.Enabled = true;
                    frm.button3.PerformClick();
                    frm.button8.PerformClick();
                }));
                txtID.Text = "";
                txtPass.Text = "";
            }
            else if (result.Count() > 0 && type1.Count() > 0)
            {
                frm = (Product_Managment)this.Parent;
                frm.Invoke(new Action(() =>
                {
                    frm.button3.Enabled = true;
                    frm.button5.Enabled = true;
                    frm.button6.Enabled = true;
                    frm.button7.Enabled = true;
                    frm.button20.Enabled = true;
                    frm.button3.PerformClick();
                    frm.button8.PerformClick();
                }));
                txtID.Text = "";
                txtPass.Text = "";
            }
            else if(txtID.Text == "")
            {
                MessageBox.Show("     ID field is required  !     ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("     Password field is required  !     ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtID.Text == "" && txtPass.Text == "")
            {
                MessageBox.Show("     ID and Password are required  !     ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("     ID or password is incorrect  !     ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Log_in_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
