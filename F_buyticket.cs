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
    public partial class F_buyticket : Form
    {
        private string target;
        public F_buyticket(string str)
        {
            InitializeComponent();
            target = str;
        }

        private void F_buyticket_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(target=="customermenu")
            {
                F_customermenu customermenu = new F_customermenu();
                customermenu.Show();
                this.Hide();
            }
            else if(target=="managementmenu")
            {
                F_managementmenu managementmenu = new F_managementmenu();
                managementmenu.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.Text=="" || comboBox2.Text == "" || comboBox3.Text == "" || dateTimePicker1.Text=="" || cnic.Text=="" || quantity.Value==0)
            {
                MessageBox.Show("Fill all fields!");
            }
            else
            {
                string type = "International";
                string dtime = "", atime = "", dur = "";

                OracleConnection conn = new OracleConnection(F_createaccount.constring);
                conn.Open();
                string q = "SELECT COUNT(*) as COUNT FROM Passenger WHERE CNIC='" + cnic.Text + "'";
                OracleCommand cmd = new OracleCommand(q, conn);
                cmd.Connection = conn;
                OracleDataReader reader = cmd.ExecuteReader();
                int var = Convert.ToInt32(cmd.ExecuteScalar());

                if (var != 1)
                {
                    MessageBox.Show("Passenger does not exist!");
                }
                else
                {
                    {
                        if((comboBox1.Text=="China" && comboBox2.Text=="India") || (comboBox1.Text == "India" && comboBox2.Text == "China") || (comboBox1.Text == "Pakistan" && comboBox2.Text == "China") || (comboBox1.Text == "China" && comboBox2.Text == "Pakistan"))
                        {
                            dtime = "7:00PM"; atime = "10:00PM"; dur = "3 Hrs";
                        }
                        else if ((comboBox1.Text == "Spain" && comboBox2.Text == "Turkey") || (comboBox1.Text == "Turkey" && comboBox2.Text == "Spain") || (comboBox1.Text == "Pakistan" && comboBox2.Text == "Turkey") || (comboBox1.Text == "Turkey" && comboBox2.Text == "Pakistan"))
                        {
                            dtime = "7:00AM"; atime = "1:00PM"; dur = "6 Hrs";
                        }
                        else if ((comboBox1.Text == "Spain" && comboBox2.Text == "Pakistan") || (comboBox1.Text == "Pakistan" && comboBox2.Text == "Spain") || (comboBox1.Text == "Pakistan" && comboBox2.Text == "Malaysia") || (comboBox1.Text == "Malaysia" && comboBox2.Text == "Pakistan"))
                        {
                            dtime = "9:00AM"; atime = "2:00PM"; dur = "5 Hrs";
                        }
                        else if ((comboBox1.Text == "Malaysia" && comboBox2.Text == "China") || (comboBox1.Text == "China" && comboBox2.Text == "Malaysia") || (comboBox1.Text == "Malaysia" && comboBox2.Text == "Turkey") || (comboBox1.Text == "Turkey" && comboBox2.Text == "Malaysia"))
                        {
                            dtime = "4:00PM"; atime = "9:00PM"; dur = "5 Hrs";
                        }

                        //
                        else if ((comboBox1.Text == "China" && comboBox2.Text == "Spain") || (comboBox1.Text == "Spain" && comboBox2.Text == "China") || (comboBox1.Text == "China" && comboBox2.Text == "Turkey") || (comboBox1.Text == "Turkey" && comboBox2.Text == "China"))
                        {
                            dtime = "4:00PM"; atime = "10:00PM"; dur = "6 Hrs";
                        }
                        //

                        else if ((comboBox1.Text == "India" && comboBox2.Text == "Pakistan") || (comboBox1.Text == "Pakistan" && comboBox2.Text == "India") || (comboBox1.Text == "India" && comboBox2.Text == "Malaysia") || (comboBox1.Text == "Malaysia" && comboBox2.Text == "India"))
                        {
                            dtime = "9:00AM"; atime = "1:00PM"; dur = "4 Hrs";
                        }


                        //
                        else if ((comboBox1.Text == "Spain" && comboBox2.Text == "India") || (comboBox1.Text == "India" && comboBox2.Text == "Spain") || (comboBox1.Text == "India" && comboBox2.Text == "Turkey") || (comboBox1.Text == "Turkey" && comboBox2.Text == "India"))
                        {
                            dtime = "9:00AM"; atime = "4:00PM"; dur = "7 Hrs";
                        }

                        //

                        else if ((comboBox1.Text == "Malaysia" && comboBox2.Text == "Spain"))
                        {
                            dtime = "9:00AM"; atime = "3:00PM"; dur = "6 Hrs";
                        }

                    }
                    if(atime=="" || dtime=="" || dur=="")
                    {
                        MessageBox.Show("Flight not available!");
                    }
                    else
                    {
                        string query = "insert into ticket (duration,Arrival,Flight_Type,Departure,class,A_Time,Dep_date,D_Time,CNIC,quantity) values ('" + dur + "','" + comboBox1.Text + "','" +type + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + atime + "','" + dateTimePicker1.Text + "','" + dtime + "','" + cnic.Text + "','" + quantity.Value + "')";
                        OracleCommand cmd2 = new OracleCommand(query, conn);
                        cmd2.Connection = conn;
                        OracleDataReader reader2 = cmd2.ExecuteReader();
                        MessageBox.Show("Ticket Purchased!");

                        if (target == "customermenu")
                        {
                            F_customermenu customermenu = new F_customermenu();
                            customermenu.Show();
                            this.Hide();
                        }
                        else if (target == "managementmenu")
                        {
                            F_managementmenu managementmenu = new F_managementmenu();
                            managementmenu.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }
    }
}
