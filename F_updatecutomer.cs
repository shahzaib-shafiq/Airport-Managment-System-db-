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
    public partial class F_updatecutomer : Form
    {
        public F_updatecutomer()
        {
            InitializeComponent();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string pattern1 = "^[0-9]{5}-[0-9]{7}-[0-9]{1}$";
        string pattern2 = "^[0-9]{11}$";
        string pattern3 = "^[0-9]$";
        string pattern4 = "^[0-9]{2}$";
        string pattern5 = "^[0-9]{2}$";
        string patternname = "^([A-Z][a-z-A-z]+)$";
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_managementmenu managementmenu = new F_managementmenu();
            managementmenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                gender = radioButton1.Text;
            else
                gender = radioButton2.Text;

            if (fname.Text == "" || lname.Text == "" || email.Text == "" || cnic.Text == "" || age.Text == "" || phone.Text=="" || gender=="")
            {
                MessageBox.Show("Please fill all the fields.");
            }
            else
            {
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();

                string q = "SELECT COUNT(*) as COUNT FROM Passenger WHERE C_ID='" + PID.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if (var != 1)
                {
                    MessageBox.Show("CID NOT FOUND!");
                }
                else
                {

                    OracleConnection conn2 = new OracleConnection(F_createaccount.constring);
                    conn2.Open();
                    string query = "UPDATE passenger set F_Name=:fname,L_Name=:lname,Phone=:phon,Email=:emai,Age=:age,CNIC=:cni,gender=:gen where C_ID=:CID";
                    OracleCommand cmd2 = new OracleCommand(query, conn2);
                    cmd2.Connection = conn2;

                    cmd2.Parameters.Add(new OracleParameter("fname", fname.Text));
                    cmd2.Parameters.Add(new OracleParameter("lname", lname.Text));
                    cmd2.Parameters.Add(new OracleParameter("emai", email.Text));
                    cmd2.Parameters.Add(new OracleParameter("phon", phone.Text));
                    cmd2.Parameters.Add(new OracleParameter("age", age.Text));
                    cmd2.Parameters.Add(new OracleParameter("cni", cnic.Text));
                    cmd2.Parameters.Add(new OracleParameter("gen", radioButton1.Text));
                    cmd2.Parameters.Add(new OracleParameter("CID",PID.Text));

                    cmd2.ExecuteReader();
                    MessageBox.Show("Record Updated!");

                    F_managementmenu managementmenu = new F_managementmenu();
                    managementmenu.Show();
                    this.Hide();

                }
            }
        }

        private void F_updatecutomer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_updatecutomer updatecutomer = new F_updatecutomer();
            updatecutomer.Show();
            this.Hide();
        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void fname_Leave(object sender, EventArgs e)
        {
         
        }

        private void lname_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(lname.Text, patternname) == false)
            {
                lname.Focus();
                errorProvider2.SetError(this.lname, "Invalid Name Format");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider4.SetError(this.email, "Invalid Email");


            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void cnic_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(cnic.Text, pattern1) == false)
            {
                cnic.Focus();
                errorProvider6.SetError(this.cnic, "Invalid CNIC FORMAT");


            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void age_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(age.Text, pattern4) == false)
            {
                age.Focus();
                errorProvider5.SetError(this.age, "Invalid Age Format");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void phone_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(phone.Text, pattern2) == false)
            {
                phone.Focus();
                errorProvider3.SetError(this.phone, "Invalid Phone Nummber Format");


            }
            else
            {
                errorProvider3.Clear();
            }
        }
    }
}
