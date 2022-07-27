using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jatri
{
    public partial class Sign_up : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader cmd;
        public Sign_up()
        {
            InitializeComponent();
        }

        private void box1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "SELECT * FROM jatri.registration	 WHERE Username = '" + txtbox3.Text + "';";
            command = new MySqlCommand(selectQuery, connection);
            cmd = command.ExecuteReader();
            if (cmd.Read())
            {
                MessageBox.Show("Username not available!");

            }
            else
            {

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=jatri;";
                string iquery = "INSERT INTO registration(`First Name`,`Last Name`, `Username`, `Email`,`Password`) VALUES ('" + txtbox1.Text + "', '" + txtbox2.Text + "', '" + txtbox3.Text + "', '" + txtbox4.Text + "', '" + txtbox5.Text + "')";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(iquery, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Account Successfully Created!");
            }

            connection.Close();

            if (string.IsNullOrEmpty(txtbox3.Text) || string.IsNullOrEmpty(txtbox5.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtbox5.PasswordChar = '\0';
            }
            else
            {
                txtbox5.PasswordChar = '*';
            }
        }
    }
    }

