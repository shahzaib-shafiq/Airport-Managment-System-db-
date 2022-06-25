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
    public partial class F_checkticketstatus : Form
    {
        public F_checkticketstatus()
        {
            InitializeComponent();
        }

        private void F_checkticketstatus_Load(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(F_createaccount.constring))
            {
                OracleCommand cmd2 = new OracleCommand("SELECT * FROM Ticket WHERE CNIC=:cnic", con);
                cmd2.Parameters.Add(new OracleParameter("cnic", F_login.loginID));
                OracleDataAdapter oda = new OracleDataAdapter(cmd2);
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
            F_customermenu customermenu = new F_customermenu();
            customermenu.Show();
            this.Hide();
        }
    }
}
