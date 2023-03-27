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
    public partial class Login : Form
    {
        OracleConnection con = new OracleConnection(@"uid=scott;password=tiger"); 
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var registration = new Registration();
            registration.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select * from user_Info where User_Name='" + textBox1.Text + "'";

            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter odp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                odp.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0]["User_Name"].ToString() == textBox1.Text && dt.Rows[0]["Password"].ToString() == textBox2.Text)
                {
                    MessageBox.Show("Login Successful", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    var homepage = new homepage(textBox1.Text);
                    homepage.Show();

                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var AdminLogin = new AdminLogin();
            AdminLogin.Show();

        }
    }
}
