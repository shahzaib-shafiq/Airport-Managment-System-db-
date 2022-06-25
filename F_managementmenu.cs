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
    public partial class F_managementmenu : Form
    {
        public F_managementmenu()
        {
            InitializeComponent();
        }

        private void F_managementmenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_addstaff addstaff = new F_addstaff();
            addstaff.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            F_aboutus aboutus = new F_aboutus("managementmenu");
            aboutus.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_login login = new F_login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_removestaff removestaff = new F_removestaff();
            removestaff.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_searchstaff searchstaff = new F_searchstaff();
            searchstaff.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            F_updatestaff updatestaff = new F_updatestaff();
            updatestaff.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            F_createaccount createaccount = new F_createaccount("managementmenu");
            createaccount.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            F_removecutomer removecutomer = new F_removecutomer();
            removecutomer.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            F_searchcustomer searchcustomer = new F_searchcustomer();
            searchcustomer.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            F_aeroplanes aeroplanes = new F_aeroplanes();
            aeroplanes.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            F_addplane addplane = new F_addplane();
            addplane.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            F_removeplane removeplane = new F_removeplane();
            removeplane.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            F_airports airports = new F_airports();
            airports.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            F_buyticket buyticket = new F_buyticket("managementmenu");
            buyticket.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            F_cancelticket cancelticket = new F_cancelticket("managementmenu");
            cancelticket.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            F_ticketsinfo ticketsinfo = new F_ticketsinfo();
            ticketsinfo.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            F_login login = new F_login();
            login.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            F_updatecutomer updatecutomer = new F_updatecutomer();
            updatecutomer.Show();
            this.Hide();
        }
    }
}
