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
    public partial class F_ticketsinfo : Form
    {
        public F_ticketsinfo()
        {
            InitializeComponent();
        }

        private void F_ticketsinfo_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_managementmenu managementmenu = new F_managementmenu();
            managementmenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection con2 = new OracleConnection(F_createaccount.constring))
            {
                OracleCommand cmd3 = new OracleCommand("SELECT * FROM Ticket", con2);
                OracleDataAdapter oda2 = new OracleDataAdapter(cmd3);
                DataSet ds2 = new DataSet();
                oda2.Fill(ds2);
                if (ds2.Tables.Count > 0)
                {
                    dataGridView1.DataSource = ds2.Tables[0].DefaultView;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TID.Text == "")
            {
                MessageBox.Show("Please enter the TID!");
            }
            else
            {
                try
                { 
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();

                string q = "SELECT COUNT(*) as COUNT FROM ticket WHERE Ticket_NO='" + TID.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());
                
                
                if (var != 1)
                {
                    MessageBox.Show("Ticket not found!");
                }
                else
                {
                    using (OracleConnection con = new OracleConnection(F_createaccount.constring))
                    {
                        OracleCommand cmd2 = new OracleCommand("SELECT * FROM Ticket WHERE Ticket_NO=:tid", con);
                        cmd2.Parameters.Add(new OracleParameter("tid", TID.Text));
                        OracleDataAdapter oda = new OracleDataAdapter(cmd2);
                        DataSet ds = new DataSet();
                        oda.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            dataGridView1.DataSource = ds.Tables[0].DefaultView;
                        }
                    }
                }
            }
                catch
                {
                    MessageBox.Show("Invalid Ticket ID");
                }
            }
           
        }
    }
}
