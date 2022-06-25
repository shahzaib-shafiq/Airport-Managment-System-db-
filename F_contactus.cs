using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class F_contactus : Form
    {
        private string target;
        public F_contactus(string str)
        {
            InitializeComponent();
            target = str;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.facebook.com/HeathrowAirport/") { UseShellExecute = true });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://twitter.com/heathrowairport") { UseShellExecute = true });
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/user/LHRHeathrow") { UseShellExecute = true });
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void F_contactus_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(target=="login")
            {
                F_login login = new F_login();
                login.Show();
                this.Hide();
            }
            else if(target=="customermenu")
            {
                F_customermenu customermenu = new F_customermenu();
                customermenu.Show();
                this.Hide();
            }
            else if(target=="help")
            {
                F_login login = new F_login();
                login.Show();
                this.Hide();
            }
        }
    }
}
