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
    public partial class F_aboutus : Form
    {
        private string target;

        public F_aboutus(string str)
        {
            InitializeComponent();
            target = str;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (target == "customermenu")
            {
                F_customermenu obj1 = new F_customermenu();
                obj1.Show();
                this.Hide();
            }
            else if (target=="login")
            {
                F_login login = new F_login();
                login.Show();
                this.Hide();
            }
            else if(target=="createaccount")
            {
                F_createaccount createaccount = new F_createaccount("aboutus");
                createaccount.Show();
                this.Hide();
            }
            else if (target == "managementmenu")
            {
                F_managementmenu managementmenu = new F_managementmenu();
                managementmenu.Show();
                this.Hide();
            }
            
        }
    }
}
