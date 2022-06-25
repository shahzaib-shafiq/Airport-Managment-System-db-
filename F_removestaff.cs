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
    public partial class F_removestaff : Form
    {
        public F_removestaff()
        {
            InitializeComponent();
        }

        private void F_removestaff_Load(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(F_createaccount.constring))
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM Staff", con);
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
            if(SID.Text=="")
            {
                MessageBox.Show("Please enter the SID!");
            }
            else
            {
                try
                {
                    OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q = "SELECT COUNT(*) as COUNT FROM STAFF WHERE S_ID='" + SID.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if(var!=1)
                {
                    MessageBox.Show("Staff SID not found!");
                }
                else
                {
                    
                    string query = "DELETE FROM staff WHERE S_ID='" + SID.Text + "'";
                    OracleCommand cmd2 = new OracleCommand(query, conn);
                    cmd2.Connection = conn;
                    OracleDataReader reader2 = cmd2.ExecuteReader();
                    
                    MessageBox.Show("Staff record Deleted!");

                    F_managementmenu managementmenu = new F_managementmenu();
                    managementmenu.Show();
                    this.Hide();
                }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid SID");
                    }


            }
        }

        private void SID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
