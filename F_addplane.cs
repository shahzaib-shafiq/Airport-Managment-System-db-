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
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class F_addplane : Form
    {
        public F_addplane()
        {
            InitializeComponent();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string pattern1 = "^[0-9]{5}-[0-9]{7}-[0-9]{1}$";
        string pattern2 = "^[0-9]{11}$";
        string pattern3 = "^[0-9]{5}$";
        string pattern4 = "^[0-9]{2}$";
        string pattern5 = "^[0-9]{2}$";
        string pattern6 = "^([A-Z][a-z-A-z]+)$";
        private void F_addplane_Load(object sender, EventArgs e)
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
            string mdate = dateTimePicker1.Text;
            if(name.Text=="" || pcapac.Text=="" || fcapac.Text=="" || mdate=="")
            {
                MessageBox.Show("Please fill all the fields.");
            }
            else
            {
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string query = "insert into aeroplanes (P_Name,Pasenger_Capicity,Fuel_Capicity,Manufacture_Date) VALUES ('" + name.Text + "','" + pcapac.Text + "','" + fcapac.Text + "','" + mdate + "')";
                OracleCommand cmd2 = new OracleCommand(query, conn);
                cmd2.Connection = conn;
                OracleDataReader reader2 = cmd2.ExecuteReader();
                MessageBox.Show("Plane Added!");

                F_managementmenu managementmenu = new F_managementmenu();
                managementmenu.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_addplane addplane = new F_addplane();
            addplane.Show();
            this.Hide();
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(name.Text, pattern6) == false)
            {
                name.Focus();
                errorProvider1.SetError(this.name, "Invalid Name Format");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void pcapac_Leave(object sender, EventArgs e)
        {

            if (Regex.IsMatch(pcapac.Text, pattern3) == false)
            {
                pcapac.Focus();
                errorProvider2.SetError(this.pcapac, "Invalid Salary Format");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void fcapac_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(fcapac.Text, pattern3) == false)
            {
                fcapac.Focus();
                errorProvider3.SetError(this.fcapac, "Invalid Salary Format");

            }
            else
            {
                errorProvider3.Clear();
            }
        }
    }
}
