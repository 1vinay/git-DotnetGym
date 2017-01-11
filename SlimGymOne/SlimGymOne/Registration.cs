using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SlimGymOne
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(Properties.Settings.Default.registerConn);
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            cmd = new SqlCommand("insert into users (firstname,lastname,email,username,password,age) values (@firstname,@lastname,@email,@username,@password,@age)", con);

            cmd.Parameters.AddWithValue("@firstname",first_box.Text);
            cmd.Parameters.AddWithValue("@lastname", last_nameBox.Text);
            cmd.Parameters.AddWithValue("@email", email_text.Text);
            cmd.Parameters.AddWithValue("@username", username_text.Text);
            cmd.Parameters.AddWithValue("@password", textBox1.Text);
            cmd.Parameters.AddWithValue("@age",age_text.Text);


            con.Open();

                if(first_box.Text== string.Empty && last_nameBox.Text== string.Empty && email_text.Text== string.Empty && username_text.Text == string.Empty)
                {

                    validationLabel.Text = "Values are required";
                    
                }

            if(cmd.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Registration Successfull");

            }
            }
            catch (Exception)
            {
                MessageBox.Show("email or username is already exist");

            }

            con.Close();

        }

        
    }
}
