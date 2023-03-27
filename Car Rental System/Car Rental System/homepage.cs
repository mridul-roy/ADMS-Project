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
    public partial class homepage : Form
    {
        OracleConnection con = new OracleConnection(@"uid=scott;password=tiger");

        public void getProfile(string Username)
        {
            string query1 = "SELECT FIRST_NAME,LAST_NAME,USER_NAME,E_MALI,CONTACT_NUMBER,ADDRESS,NID_NO from user_info where USER_NAME = '" + Username + "'";
            con.Open();
            OracleCommand cmd = new OracleCommand(query1, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);
            DataTable dt = ds.Tables[0];
            label15.Text = dt.Rows[0]["first_name"].ToString();
            label16.Text = dt.Rows[0]["last_name"].ToString();
            label17.Text = dt.Rows[0]["user_name"].ToString();
            label18.Text = dt.Rows[0]["nid_no"].ToString();
            label19.Text = dt.Rows[0]["e_mali"].ToString();
            label21.Text = dt.Rows[0]["contact_number"].ToString();
            label20.Text = dt.Rows[0]["address"].ToString();
            con.Close();

        }
        public homepage(string UsernamePass)
        {
            InitializeComponent();
            label51.Text = UsernamePass;
            getProfile(label51.Text);
            panel1.BringToFront();

        }

        private void fillgv1(string qu)
        {
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter(qu, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void fillgv5(string qu)
        {
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter(qu, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            con.Close();
        }
        private void fillgv3(string qu)
        {
            con.Close();
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter(qu, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void fillgv4(string qu)
        {
            con.Close();
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter(qu, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
        }

        private void fillgv2(string qu)
        {
            con.Close();
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter(qu, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            getProfile(label51.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qu = "select car_id,model_name,registaion_no, colour, number_of_SEAT as Total_Seat , price_per_day from Car_Details";
            fillgv1(qu);
            panel2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string qu = "select payment_id ,total_amount,due_amount,payment_method,account_number,trxid,status from payment where user_name='"+label51.Text+"' order by payment_id desc";
            fillgv2(qu);
            panel4.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox11.Text = label15.Text;
            textBox10.Text = label16.Text;
            textBox9.Text = label18.Text;
            textBox14.Text = label19.Text;
            textBox13.Text = label21.Text;
            textBox12.Text = label20.Text;
            panel5.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            string query = "select trip_id,trip_starting_loc as Pickup,Distanation as Drop_off, trip_date,Trip_duration as Duration, d.first_name as Driver_name,d.contact_number as phone from trip_details t, driver_info d where t.driver_id=d.driver_id and t.user_name='" + label51.Text + "' order by trip_id desc";
            fillgv3(query);
            panel7.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (textBox11.Text!="" && textBox10.Text!="" &&textBox12.Text!="" &&textBox14.Text!="" &&textBox13.Text!="" && textBox9.Text!="")
            {
                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("update_profile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("firstname", textBox11.Text);
                    cmd.Parameters.AddWithValue("lastname", textBox10.Text);
                    cmd.Parameters.AddWithValue("addressp", textBox12.Text);
                    cmd.Parameters.AddWithValue("email", textBox14.Text);
                    cmd.Parameters.AddWithValue("contact", textBox13.Text);
                    cmd.Parameters.AddWithValue("nid", textBox9.Text);
                    cmd.Parameters.AddWithValue("username", label51.Text);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox11.Text = ""; textBox10.Text = ""; textBox12.Text = ""; textBox14.Text = ""; textBox13.Text = ""; textBox9.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Update error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Contact and NID must be numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Fill Up All Field Properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox8.Text != "" && textBox4.Text != "")
            {
                if (textBox6.Text == textBox8.Text)
                {
                    con.Open();
                    string query1 = "select password from user_info where user_name='" + label51.Text + "'";
                    OracleCommand cmd2 = new OracleCommand(query1, con);
                    cmd2.ExecuteNonQuery();
                    OracleDataAdapter odp = new OracleDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    odp.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows[0]["password"].ToString() == textBox4.Text)
                    {
                        OracleCommand cmd = new OracleCommand("changePass", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("oldpass", textBox4.Text);
                        cmd.Parameters.AddWithValue("username", label51.Text);
                        cmd.Parameters.AddWithValue("newpass", textBox8.Text);
                        cmd.ExecuteNonQuery();
                       
                        MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox6.Text = ""; textBox8.Text = ""; textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Old Password not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Password and confirm passsword not same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Enter all field first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "select * from Car_Details where car_id like'%" + textBox1.Text + "%' or driver_id like'%" + textBox1.Text + "%' or model_name like'%" + textBox1.Text + "%'or colour like'%" + textBox1.Text + "%'";
            fillgv1(query);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox7.Text != "")
            {

                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("booking", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pickup", textBox2.Text);
                    cmd.Parameters.AddWithValue("dropoff", textBox3.Text);
                    cmd.Parameters.AddWithValue("tripdate", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("duration", textBox5.Text);
                    cmd.Parameters.AddWithValue("car_id", textBox7.Text);
                    cmd.Parameters.AddWithValue("username", label51.Text);
                    int num = cmd.ExecuteNonQuery();
                    con.Close();
                    if (num > 0)
                    {
                        MessageBox.Show("Complete Payment to confirm", "Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = ""; textBox3.Text = ""; textBox5.Text = ""; textBox7.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Booking  error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                catch (Exception)
               {
                   MessageBox.Show("Enter Only Number on Duration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
  
            }
            else
            {
                MessageBox.Show("Fill Up all field properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void button15_Click(object sender, EventArgs e)
        {
            con.Open();
            string query1 = "delete from trip_details where trip_id='" + textBox22.Text + "'";
            OracleCommand cmd2 = new OracleCommand(query1, con);
            int num = cmd2.ExecuteNonQuery();
            if (num > 0)
            {
                MessageBox.Show("Booking Canceled", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox22.Text = "";
            }
            else
            {
                MessageBox.Show("Cancellation  error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            con.Close();
            string query = "select trip_id,trip_starting_loc as Pickup,Distanation as Drop_off, trip_date,Trip_duration as Duration, d.first_name as Driver_name,d.contact_number as phone from trip_details t, driver_info d where t.driver_id=d.driver_id and t.user_name='" + label51.Text + "' order by trip_id desc";
            fillgv3(query);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                textBox22.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox22.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                textBox17.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && textBox15.Text != "" && textBox18.Text != "" && textBox17.Text != "" && textBox16.Text != "")
                {
                    if (!textBox16.Text.Equals("0"))
                    {

                        con.Open();
                        string query1 = "update payment set payment_method = '" + comboBox1.Text + "',account_number=" + textBox15.Text + ",trxid='" + textBox18.Text + "', status='paid',due_amount=0 where user_name='" + label51.Text + "' and payment_id=" + textBox17.Text + "";
                        OracleCommand cmd2 = new OracleCommand(query1, con);
                        int num = cmd2.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Payment complete", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comboBox1.Text = "";  textBox15.Text = "";  textBox18.Text = ""; textBox17.Text = "";  textBox16.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Payment error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string qu = "select payment_id ,total_amount,due_amount,payment_method,account_number,trxid,status from payment where user_name='" + label51.Text + "' order by payment_id desc";
                        fillgv2(qu);

                    }

                    else
                    {
                        MessageBox.Show("Already Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Fill up All field properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Enter Only number as Account number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Car Selected", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string query = "select trip_id,trip_starting_loc as Pickup,Distanation as Drop_off, trip_date,Trip_duration as Duration, d.first_name as Driver_name,d.contact_number as phone from dtrip_details t, driver_info d where t.driver_id=d.driver_id and t.user_name='" + label51.Text + "' order by trip_id desc";
            fillgv4(query);
            panel8.BringToFront();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string qu = "select lo_id as LOG_ID,event,time as Date_time from log where user_name='" + label51.Text + "' order by lo_id desc";
            fillgv5(qu);
            panel9.BringToFront();
        }
    }
}
