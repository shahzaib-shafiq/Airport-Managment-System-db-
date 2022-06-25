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

    public partial class F_login : Form
    {
        static public string loginID;

        public F_login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //form1.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginID = textBox1.Text;
            try
            {
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q = "SELECT COUNT (*) as COUNT FROM Passenger WHERE CNIC='" + textBox1.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                cmd.Parameters.Add(new OracleParameter("user", textBox1.Text));
                cmd.Parameters.Add(new OracleParameter("pass", textBox2.Text));
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if (var != 1)
                {
                    if (textBox1.Text == "admin" && textBox2.Text == "123")
                    {
                        F_managementmenu managementmenu = new F_managementmenu();
                        managementmenu.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Invalid Username/Password");
                }
                else
                {
                    F_customermenu F3 = new F_customermenu();
                    F3.Show();
                    this.Hide();
                }
            }
            catch 
            {
                //throw new YourCustomException("Put your error message here.", e);
                MessageBox.Show("Invalid!");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_aboutus aboutus = new F_aboutus("login");
            aboutus.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_help help = new F_help("login");
            help.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_createaccount F3 = new F_createaccount("login");
            F3.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F_resestpass F1 = new F_resestpass();
            F1.Show();
            this.Hide();
        }
    }
}
