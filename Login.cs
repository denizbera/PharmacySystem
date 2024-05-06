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

namespace PharmacyManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        SqlConnection connection;
        string connectionString = "Data Source=.;Initial Catalog=20200305034;Integrated Security=True";

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT * FROM Admin WHERE AdminName = @AdminName AND Password = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminName", textBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    this.Hide();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
                reader.Close();
            connection.Close();
            
            
          

        }
    }
}
