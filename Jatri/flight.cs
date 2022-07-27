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
    public partial class flight : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader cmd;
        public flight()
        {
            InitializeComponent();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "SELECT * FROM jatri.flight WHERE passenger_name = '" + txtbox3.Text + "';";
            command = new MySqlCommand(selectQuery, connection);
            cmd = command.ExecuteReader();
            if (cmd.Read())
            {
                MessageBox.Show("Username not available!");

            }
            else
            {

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=jatri;";
                string iquery = "INSERT INTO flight(`Boarding_point`,`Depurture_time`, `Passenger_name`, `Passenger_phone`,`Passenger_email`) VALUES ('" + txtbox1.Text + "', '" + combobox1.Text + "', '" + txtbox3.Text + "', '" + txtbox4.Text + "', '" + txtbox5.Text + "')";

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


        }

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

