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
    public partial class F_addstaff : Form
    {
        public F_addstaff()
        {
            InitializeComponent();
        }
        string pattern =  "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string pattern1 = "^[0-9]{5}-[0-9]{7}-[0-9]{1}$";
        string pattern2 = "^[0-9]{11}$";
        string pattern3 = "^[0-9]{5}$";
        string pattern4 = "^[0-9]{2}$";
        string pattern5 = "^[0-9]{2}$";
        string pattern6 = "^([A-Z][a-z-A-z]+)$"; 


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            F_managementmenu managementmenu = new F_managementmenu();
            managementmenu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_addstaff addstaff = new F_addstaff();
            addstaff.Show();
            this.Hide();
        }
        //
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


            // string f_name_Regex = "^[A-Z]{1}[A-Za-z]{6,}$";
            //s/tring l_name = "^[A-Z]{1}[A-Za-z]{6,}$";
            //string EMAIL = "^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+[@][a-zA-z]+[.][a-zA-Z]{2,3}([a-zA-Z]{2,3}){0,1}";

         /*  public bool ValidateFirstName()
            {
                return Regex.IsMatch(fname.Text, f_name_Regex);
            }*/




            if (fname.Text=="" || lname.Text=="" || email.Text=="" || cnic.Text=="" || address.Text=="" || age.Text=="" || pos=="" || gender=="" || scale.Text=="" || phone.Text=="" || jdate=="" || salary.Text=="")
            {
                MessageBox.Show("Please fill all the fields.");          
                
               

            
            }
            else
            {



                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q= "SELECT COUNT(*) as COUNT FROM STAFF WHERE CNIC='" + cnic.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if(var==1)
                {
                    MessageBox.Show("CNIC already exists!");
                }
                else
                {
                    
                    string query = "insert into staff (F_Name,L_Name,Phone,Email,Age,CNIC,gender,positionn,scalee,joining_date,salary,address,A_ID) values ('" +fname.Text + "','" + lname.Text + "','" + phone.Text + "','" + email.Text + "','" + age.Text + "','" + cnic.Text + "','" + gender + "','" + pos + "','" + scale.Text + "','" + jdate + "','" + salary.Text + "','" + address.Text + "','" + 1 + "')";
                    OracleCommand cmd2 = new OracleCommand(query, conn);
                    cmd2.Connection = conn;
                    OracleDataReader reader2 = cmd2.ExecuteReader();
                    MessageBox.Show("Staff Added!");

                    F_managementmenu managementmenu = new F_managementmenu();
                    managementmenu.Show();
                    this.Hide();
                }
            }
            //
          //  isvalid_cnic(cnic.Text);
            //
        
        }

        /*      public bool isvalid_cnic(string c)
              {
                  Regex check = new Regex(@"^[0-9]{5}-[0-9]{7}-[0-9]{1}$");
                  bool valid = false;
                  valid check.IsMatch(c);
                  if (valid==true)
                  {
                      return valid;

                  }
                  else
                  {
                      MessageBox.Show("Invalid CNIC Format");
                  }

              }*/
        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {
        //    
            
        }

        private void fname_Leave(object sender, EventArgs e)
        {

            if (Regex.IsMatch(fname.Text, pattern6) == false)
            {
                fname.Focus();
                errorProvider1.SetError(this.fname, "Invalid Name Format");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void email_Leave(object sender, EventArgs e)
        {
           
            if(Regex.IsMatch(email.Text,pattern)==false)
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

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if  (!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Phone Format");
                 
            }*/
        }

        private void phone_DragLeave(object sender, EventArgs e)
        {
          
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

        private void F_addstaff_Load(object sender, EventArgs e)
        {

        }

        private void F_addstaff_Load_1(object sender, EventArgs e)
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

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
