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
    public partial class F_offers : Form
    {
        public F_offers()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.facebook.com/HeathrowAirport/") { UseShellExecute = true });

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            F_customermenu customermenu = new F_customermenu();
            customermenu.Show();
            this.Hide();
                
        }
    }
}
