using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PharmacyManagementSystem
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        DataTable dataTable;
        SqlConnection connection;
        string connectionString = "Data Source=.;Initial Catalog=20200305034;Integrated Security=True";
        public void customers()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Customers";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }
        public void txtclear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            customers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            dv.RowFilter = "first_name LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["customer_id"].Value.ToString();
                textBox3.Text = row.Cells["first_name"].Value.ToString();
                textBox4.Text = row.Cells["last_name"].Value.ToString();
                textBox5.Text = row.Cells["phone"].Value.ToString();
                textBox6.Text = row.Cells["email"].Value.ToString();
                textBox7.Text = row.Cells["customer_adress"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["birthday"].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "INSERT INTO Customers (customer_id,first_name, last_name, phone, email, customer_adress, birthday) " +
                               "VALUES (@customer_id,@first_name, @last_name, @phone, @email, @customer_adress, @birthday)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customer_id", textBox2.Text);
                command.Parameters.AddWithValue("@first_name", textBox3.Text);
                command.Parameters.AddWithValue("@last_name", textBox4.Text);
                command.Parameters.AddWithValue("@phone", textBox5.Text);
                command.Parameters.AddWithValue("@email", textBox6.Text);
                command.Parameters.AddWithValue("@customer_adress", textBox7.Text);
                command.Parameters.AddWithValue("@birthday", dateTimePicker1.Value);

                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                customers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                connection.Close();
                txtclear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);


            try
            {
                connection.Open();

                string query = "UPDATE Customers " +
                               "SET first_name = @FirstName, last_name = @LastName, phone = @Phone, email = @Email, customer_adress = @Adress, birthday = @Birthday " +
                               "WHERE customer_id = @CustomerId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", textBox2.Text);
                command.Parameters.AddWithValue("@FirstName", textBox3.Text);
                command.Parameters.AddWithValue("@LastName", textBox4.Text);
                command.Parameters.AddWithValue("@Phone", textBox5.Text);
                command.Parameters.AddWithValue("@Email", textBox6.Text);
                command.Parameters.AddWithValue("@Adress", textBox7.Text);
                command.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value);

                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                customers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                connection.Close();
                txtclear();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            

            try
            {
                connection.Open();

                string query = "DELETE FROM Customers WHERE customer_id = @CustomerId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", textBox2.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                customers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                connection.Close();
                txtclear();

            }
        }
    }
}
    


      