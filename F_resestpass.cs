using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace WinFormsApp1
{
    public partial class F_resestpass : Form
    {
        public F_resestpass()
        {
            InitializeComponent();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter an email!");
            }
            else
            {
                MessageBox.Show("Password reset request has been sent!");
                F_login f2 = new F_login();
                f2.Show();
                this.Hide();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_login login = new F_login();
            login.Show();
            this.Hide();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, pattern) == false)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Invalid Email");


            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
