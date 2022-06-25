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
    public partial class F_removecutomer : Form
    {
        public F_removecutomer()
        {
            InitializeComponent();
        }

        private void F_removecutomer_Load(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(F_createaccount.constring))
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM Passenger", con);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_managementmenu managementmenu = new F_managementmenu();
            managementmenu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CID.Text == "")
            {
                MessageBox.Show("Please enter the CID!");
            }
            else
            {
                try
                { 
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q = "SELECT COUNT(*) as COUNT FROM PASSENGER WHERE C_ID='" + CID.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if (var != 1)
                {
                    MessageBox.Show("Customer not found!");
                }
                else
                {
                    string query = "DELETE FROM passenger WHERE C_ID='" + CID.Text + "'";
                    OracleCommand cmd2 = new OracleCommand(query, conn);
                    cmd2.Connection = conn;
                    OracleDataReader reader2 = cmd2.ExecuteReader();

                    MessageBox.Show("Customer record Deleted!");

                    F_managementmenu managementmenu = new F_managementmenu();
                    managementmenu.Show();
                    this.Hide();
                }
            }
                catch
                {
                    MessageBox.Show("Invalid CID");
                }
                }
        }
    }
}
