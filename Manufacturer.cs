using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmacyManagementSystem
{
    public partial class Manufacturer : Form
    {
        public Manufacturer()
        {
            InitializeComponent();
        }

        DataTable dataTable;
        SqlConnection connection;
        string connectionString = "Data Source=.;Initial Catalog=20200305034;Integrated Security=True";
        public void manufacturer()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Manufacturer";
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
            label4.Text = "";
        }

        private void Manufacturer_Load(object sender, EventArgs e)
        {
            manufacturer();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            dv.RowFilter = "manufacturer_name LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["Manufacturer_id"].Value.ToString();
                textBox3.Text = row.Cells["Manufacturer_name"].Value.ToString();
                textBox4.Text = row.Cells["Manufacturer_adress"].Value.ToString();
                label4.Text = row.Cells["joindate"].Value.ToString();
                textBox5.Text = row.Cells["phone"].Value.ToString();
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "INSERT INTO Manufacturer (Manufacturer_id,Manufacturer_name, Manufacturer_adress, joindate, phone) " +
                                "VALUES (@ID,@Name, @Adress, @JoinDate, @Phone)";

                SqlCommand  command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", textBox2.Text);
                command.Parameters.AddWithValue("@Name", textBox3.Text);                
                command.Parameters.AddWithValue("@Adress", textBox4.Text);
                command.Parameters.AddWithValue("@JoinDate",DateTime.Now );
                command.Parameters.AddWithValue("@Phone", textBox5.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                manufacturer();
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


                string query = "UPDATE Manufacturer SET Manufacturer_name = @Name, Manufacturer_adress = @Adress, " +
                               "phone = @Phone WHERE Manufacturer_id = @ManufacturerId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ManufacturerId", textBox2.Text);                
                command.Parameters.AddWithValue("@Name", textBox3.Text);
                command.Parameters.AddWithValue("@Adress", textBox4.Text);                
                command.Parameters.AddWithValue("@Phone", textBox5.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                manufacturer();
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

                string query = "DELETE FROM Manufacturer WHERE Manufacturer_id = @ManufacturerId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ManufacturerId", textBox2.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                manufacturer();
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
