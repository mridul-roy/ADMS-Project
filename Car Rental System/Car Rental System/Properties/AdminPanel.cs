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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Car_Rental_System.Properties
{
  
    public partial class adminPanel : Form
    {

        OracleConnection con = new OracleConnection(@"uid=scott;password=tiger");
        public adminPanel(string username)
        {
            InitializeComponent();
            lblShowAdminName.Text = username;
            BindGridview4();
            panel001.BringToFront();
            // BindGridview1();
            //  BindGridview3();
            //BindGridview5();
            //  BindGridview2();

        }

        void BindGridview4()
        {
            con.Open();
            string query = "select * from user_info";

            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);




            DataTable data = new DataTable();
            odp.Fill(data);
            dataGridView4.DataSource = data;





            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.RowTemplate.Height = 50;


            con.Close();
        }


        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            BindGridview4();
            panel001.BringToFront();
        }

        private void btnDriverInfo_Click(object sender, EventArgs e)
        {
            BindGridview1();
            panel1.BringToFront();
        }

        void BindGridview1()
        {
            con.Open();
            string query = "select * from driver_info";

            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);




            DataTable data = new DataTable();
            odp.Fill(data);
            dataGridView1.DataSource = data;





            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;

            con.Close();

        }

        private void btnCarDetails_Click(object sender, EventArgs e)
        {
            BindGridview3();
            panel4.BringToFront();
        }

        void BindGridview3()
        {
            con.Open();
            string query = "select * from car_details";

            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);




            DataTable data = new DataTable();
            odp.Fill(data);
            dataGridView3.DataSource = data;





            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.RowTemplate.Height = 50;


            con.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            BindGridview5();
            panel5.BringToFront();
        }

        void BindGridview5()
        {
            con.Open();
            string query = "select * from payment";

            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);

            DataTable data = new DataTable();
            odp.Fill(data);
            dataGridView5.DataSource = data;


            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.RowTemplate.Height = 50;

            con.Close();

        }

        private void btnTripDetails_Click(object sender, EventArgs e)
        {
            BindGridview2();
            panel3.BringToFront();

        }

        void BindGridview2()
        {
            con.Open();
            string query = "select * from trip_details";

            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);




            DataTable data = new DataTable();
            odp.Fill(data);
            dataGridView2.DataSource = data;




            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowTemplate.Height = 50;

            con.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var AdminLogin = new AdminLogin();
            AdminLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
              

                if ( textBox112.Text != "" && textBox113.Text != "" && textBox114.Text != "" && textBox115.Text != "" && textBox116.Text != "" && textBox117.Text != "" )
                {
                  
                        string query = " insert into car_details values (car_seq.nextval,'" + textBox112.Text + "','" + textBox113.Text + "','" + textBox114.Text + "','" + textBox115.Text + "','" + textBox116.Text + "','" + textBox117.Text + "')";
                        con.Open();
                        OracleCommand cmd = new OracleCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Car Successfully added", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        textBox112.Text = ""; textBox113.Text = ""; textBox114.Text = ""; textBox115.Text = ""; textBox116.Text = ""; textBox117.Text = "";
              

                }
                else
                {
                    MessageBox.Show("Fill up all field properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindGridview6();
            panel6.BringToFront();

        }

        void BindGridview6()
        {
            con.Open();

            OracleCommand cmd1 = new OracleCommand("pre_Member", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            string query = "select * from user_info where user_name = (select * from vip_member)";

            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            OracleDataAdapter odp = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            odp.Fill(ds);




            DataTable data = new DataTable();
            odp.Fill(data);
            dataGridView6.DataSource = data;




            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView6.RowTemplate.Height = 50;

            con.Close();

        }
    }
}
