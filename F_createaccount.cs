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
    public partial class F_createaccount : Form
    {
        static public string constring = "USER ID=System;Password=1236;DATA SOURCE=DESKTOP-HG6LLLN:1521;";
        private string target;
        public F_createaccount(string str)
        {
            InitializeComponent();
            target = str;
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string pattern1 = "^[0-9]{5}-[0-9]{7}-[0-9]{1}$";
        string pattern2 = "^[0-9]{11}$";
        string pattern3 = "^[0-9]$";
        string pattern4 = "^[0-9]{2}$";
        string pattern5 = "^[0-9]{2}$";
        string patternname = "^([A-Z][a-z-A-z]+)$";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                gender = radioButton1.Text;
            else
                gender = radioButton2.Text;

            if (textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || gender == "" || textBox5.Text == "" || textBox6.Text == "" || gender == "")
            {
                MessageBox.Show("Please fill all the fields.");
            }
            else
            {
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q = "SELECT COUNT(*) as COUNT FROM Passenger WHERE CNIC='" + textBox6.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if (var == 1)
                {
                    MessageBox.Show("CNIC already exists!");
                }
                else
                {
           
                    string query = "insert into passenger (F_Name,L_Name,Phone,Email,Age,CNIC,gender) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + gender + "')";
                    OracleCommand cmd2 = new OracleCommand(query,conn);
                    cmd2.Connection = conn;
                    OracleDataReader reader2 = cmd2.ExecuteReader();

                    if(target=="login")
                    {
                        MessageBox.Show("Account Created! Check your mail for credentials");
                        F_login login = new F_login();
                        login.Show();
                        this.Hide();
                    }
                    else if (target == "managementmenu")
                    {
                        MessageBox.Show("Account Created!");
                        F_managementmenu managementmenu = new F_managementmenu();
                        managementmenu.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //F_aboutus aboutus = new F_aboutus("createaccount");
            //aboutus.Show();
            //this.Hide();
        }

        private void F_createaccount_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;         
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(target=="login")
            {
                F_login login = new F_login();
                login.Show();
                this.Hide();
            }
            else if(target=="managementmenu")
            {
                F_managementmenu managementmenu = new F_managementmenu();
                managementmenu.Show();
                this.Hide();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text,patternname) == false)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Invalid Name Format");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text,patternname) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Invalid Name Format");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, pattern2) == false)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Invalid Phone Nummber Format");


            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, pattern) == false)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Invalid Email");


            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox5.Text, pattern4) == false)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Invalid Age Format");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox6.Text, pattern1) == false)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Invalid CNIC FORMAT");


            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
