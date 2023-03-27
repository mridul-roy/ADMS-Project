using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient; 

namespace Car_Rental_System
{
    public partial class Registration : Form
    {
        OracleConnection con = new OracleConnection(@"uid=scott;password=tiger");
        string errormsg = "";
        public Registration()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "Select * from user_Info where User_Name='" + textBox3.Text + "'";
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(query1, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter odp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                odp.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0]["User_Name"].ToString() == textBox3.Text)
                {
                    errormsg = "Username already exist";
                }
            }
            catch (Exception)
            {
                errormsg = "";
                if (textBox8.Text != textBox9.Text)
                {
                    errormsg = "Password and Confirm Password are not same";
                }

            }
            finally
            {
                con.Close();
            }

            if (textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!=""&&textBox4.Text!=""&&textBox5.Text!=""&&textBox6.Text!=""&&textBox7.Text!=""&&textBox8.Text!=""&&textBox9.Text!="")
            {
                if (errormsg == "")
                {
                    string query = " insert into user_Info values (User_seq.nextval,'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
                    con.Open();
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = "";
                }
                else
                {
                    MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
            else
            {
                MessageBox.Show("Fill up all field properly","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

    }
}
