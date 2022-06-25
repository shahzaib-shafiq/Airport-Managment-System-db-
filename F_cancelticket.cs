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
    public partial class F_cancelticket : Form
    {
        private string target;
        public F_cancelticket(string str)
        {
            InitializeComponent();
            target = str;
        }

        private void F_cancelticket_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(target=="managementmenu")
            {
                F_managementmenu managementmenu = new F_managementmenu();
                managementmenu.Show();
                this.Hide();
            }
            else if(target=="customermenu")
            {
                F_customermenu customermenu = new F_customermenu();
                customermenu.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(cnic.Text=="" || TID.Text=="")
            {
                MessageBox.Show("Please fill all fields!");
            }
            else

            {
                try
                { 
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q = "SELECT COUNT(*) as COUNT FROM passenger WHERE CNIC='" + cnic.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());
                if (var != 1)
                {
                    MessageBox.Show("CNIC not found!");
                }
                else
                {
                    string q2 = "SELECT COUNT(*) as COUNT FROM TICKET WHERE Ticket_NO=:tid";
                    OracleCommand cmd2 = new OracleCommand(q2, conn);
                    cmd2.Connection = conn;
                    cmd2.Parameters.Add(new OracleParameter("tid", TID.Text));
                    OracleDataReader reader2 = cmd2.ExecuteReader();
                    int var2 = Convert.ToInt32(cmd2.ExecuteScalar());
                    if (var2 == 0)
                    {
                        MessageBox.Show("NO RECORD FOUND!");
                    }
                    else
                    {
                        string query = "DELETE FROM TICKET WHERE Ticket_NO='" + TID.Text + "'";
                        OracleCommand cmd3 = new OracleCommand(query, conn);
                        cmd3.Connection = conn;
                        OracleDataReader reader3 = cmd3.ExecuteReader();

                        MessageBox.Show("Ticket Cancelled!");

                        if (target == "managementmenu")
                        { 
                            F_managementmenu managementmenu = new F_managementmenu();
                            managementmenu.Show();
                            this.Hide();
                        }
                        else if (target == "customermenu")
                        {
                            F_customermenu customermenu = new F_customermenu();
                            customermenu.Show();
                            this.Hide();
                        }
                    }
                }
            }
                catch
                {
                    MessageBox.Show("Invalid TID");
                }
            }
          
        }
    }
}
