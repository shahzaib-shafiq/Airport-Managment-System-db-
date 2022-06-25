using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WinFormsApp1
{
    public partial class F_airports : Form
    {
        public F_airports()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_managementmenu managementmenu = new F_managementmenu();
            managementmenu.Show();
            this.Hide();
        }

        private void F_airports_Load(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(F_createaccount.constring))
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM AIRPORT", con);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
        }
    }
}
