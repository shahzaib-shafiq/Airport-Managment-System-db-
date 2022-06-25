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
    public partial class F_updatestaff : Form
    {
        public F_updatestaff()
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
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_managementmenu managementmenu = new F_managementmenu();
            managementmenu.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void SID_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                gender = radioButton1.Text;
            else
                gender = radioButton2.Text;

            string jdate = dateTimePicker1.Text;
            string pos = comboBox1.Text;

            if (fname.Text == "" || lname.Text == "" || email.Text == "" || cnic.Text == "" || address.Text == "" || age.Text == "" || comboBox1.Text == "" || gender == "" || scale.Text == "" || phone.Text == "" || dateTimePicker1.Text == "" || salary.Text == "" || SID.Text == "" || AID.Text == "")
            {
                MessageBox.Show("Please fill all the fields.");
            }
            else
            {
                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();

                string q = "SELECT COUNT(*) as COUNT FROM STAFF WHERE S_ID='" + SID.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if (var != 1)
                {
                    MessageBox.Show("SID NOT FOUND!");
                }
                else
                {

                }
                {
                    string q2 = "SELECT COUNT(*) FROM AIRPORT WHERE A_ID='" + AID.Text + "'";
                    OracleCommand cmd3 = new OracleCommand(q2, conn);
                    cmd3.Connection = conn;
                    OracleDataReader reader3 = cmd3.ExecuteReader();
                    int var2 = Convert.ToInt32(cmd3.ExecuteScalar());
                    //int var2=1;
                    if (var2==1)
                    {
                        OracleConnection conn2 = new OracleConnection(F_createaccount.constring);
                        conn2.Open();
                        //string query = "UPDATE STAFF set F_Name=:fname,L_Name=:lname,Phone=:phon,Email=:emai,Age=:age,positionn=:pos,scalee=:scal,joining_date=:jdate,A_ID=:AID,salary=:sal,address=:ad,CNIC=:cni,gender=:gen where S_ID=:ssid";
                        string query = "UPDATE STAFF SET F_Name = '"+ fname.Text + "',L_Name = '" + lname.Text + "',Phone = '" + phone.Text + "',Email = '" + email.Text + "',Age = '" + age.Text + "',positionn = '" + comboBox1.Text + "',scalee = '" + scale.Text + "',joining_date = '" + dateTimePicker1.Text + "',A_ID = '" + AID.Text + "',salary = '" + salary.Text + "',address = '" + address.Text + "',CNIC = '" + cnic.Text + "',gender = '" + gender + "' WHERE S_ID = '" + SID.Text + "'";
                        OracleCommand cmd2 = new OracleCommand(query, conn2);
                        cmd2.Connection = conn2;
                            
                        cmd2.Parameters.Add(new OracleParameter("fname", fname.Text));
                        cmd2.Parameters.Add(new OracleParameter("lname", lname.Text));
                        cmd2.Parameters.Add(new OracleParameter("emai", email.Text));
                        cmd2.Parameters.Add(new OracleParameter("phon", phone.Text));
                        cmd2.Parameters.Add(new OracleParameter("age", age.Text));
                        cmd2.Parameters.Add(new OracleParameter("cni", cnic.Text));
                        cmd2.Parameters.Add(new OracleParameter("scal", scale.Text));
                        cmd2.Parameters.Add(new OracleParameter("ad", address.Text));
                        cmd2.Parameters.Add(new OracleParameter("ssid", SID.Text));
                        cmd2.Parameters.Add(new OracleParameter("AID", AID.Text));
                        cmd2.Parameters.Add(new OracleParameter("sal", salary.Text));
                        cmd2.Parameters.Add(new OracleParameter("pos", comboBox1.Text));
                        cmd2.Parameters.Add(new OracleParameter("jdate", dateTimePicker1.Text));
                        cmd2.Parameters.Add(new OracleParameter("gen", radioButton1.Text));

                        cmd2.ExecuteReader();
                        MessageBox.Show("Record Updated!");

                        F_managementmenu managementmenu = new F_managementmenu();
                        managementmenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("SUCH AID DOES NOT EXIST!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_updatestaff updatestaff = new F_updatestaff();
            updatestaff.Show();
            this.Hide();
        }

        private void F_updatestaff_Load(object sender, EventArgs e)
        {

        }

        private void lname_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(lname.Text, pattern6) == false)
            {
                lname.Focus();
                errorProvider8.SetError(this.lname, "Invalid Name Format");
            }
            else
            {
                errorProvider8.Clear();
            }
        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void fname_Leave(object sender, EventArgs e)
        {
            
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                errorProvider2.SetError(this.email, "Invalid Email");


            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void cnic_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(cnic.Text, pattern1) == false)
            {
                cnic.Focus();
                errorProvider3.SetError(this.cnic, "Invalid CNIC FORMAT");


            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void address_Leave(object sender, EventArgs e)
        {

        }

        private void salary_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(salary.Text, pattern3) == false)
            {
                salary.Focus();
                errorProvider5.SetError(this.salary, "Invalid Salary Format");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void age_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(age.Text, pattern4) == false)
            {
                age.Focus();
                errorProvider6.SetError(this.age, "Invalid Age Format");

            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void phone_DragLeave(object sender, EventArgs e)
        {

        }

        private void scale_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(scale.Text, pattern5) == false)
            {
                scale.Focus();
                errorProvider7.SetError(this.scale, "Invalid Scale Format");

            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void phone_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(phone.Text, pattern2) == false)
            {
                phone.Focus();
                errorProvider4.SetError(this.phone, "Invalid Phone Nummber Format");


            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
