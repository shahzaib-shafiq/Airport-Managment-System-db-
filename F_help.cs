using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class F_help : Form
    {
        private string target;

        public F_help(string str)
        {
            InitializeComponent();
            target = str;
        }

        private void F_help_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(target=="customermenu")
            {
                F_customermenu customermenu = new F_customermenu();
                customermenu.Show();
                this.Hide();
            }
            else if(target=="login")
            {
                F_login login = new F_login();
                login.Show();
                this.Hide();
            }
            else if(target=="contactus")
            {
                F_contactus contactus = new F_contactus("help");
                contactus.Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_contactus contactus = new F_contactus("help");
            contactus.Show();
            this.Hide();
        }
    }
}
