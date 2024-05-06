using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmacyManagementSystem
{
    public partial class Medicines : Form
    {
        public Medicines()
        {
            InitializeComponent();
        }
        DataTable dataTable;
        SqlConnection connection;
        string connectionString = "Data Source=.;Initial Catalog=20200305034;Integrated Security=True";
        public void medicines()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT m.medication_id, m.medication_name, mt.MedicationType_name, mf.Manufacturer_name,m.stock_quantity,m.price\r\nFROM Medicines m\r\nJOIN MedicationTypes mt ON m.MedicationType_id = mt.MedicationType_id\r\nJOIN Manufacturer mf ON m.Manufacturer_id = mf.Manufacturer_id;";
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
            

        }

        private void Medicines_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı '_20200305034DataSet.Manufacturer' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.manufacturerTableAdapter.Fill(this._20200305034DataSet.Manufacturer);
            // TODO: Bu kod satırı '_20200305034DataSet.MedicationTypes' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.medicationTypesTableAdapter.Fill(this._20200305034DataSet.MedicationTypes);
            // TODO: Bu kod satırı '_20200305034DataSet.MedicationTypes' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.medicationTypesTableAdapter.Fill(this._20200305034DataSet.MedicationTypes);

            medicines();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            dv.RowFilter = " medication_name LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = row.Cells["medication_id"].Value.ToString();
                textBox3.Text = row.Cells["medication_name"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["MedicationType_name"].Value.ToString();
                comboBox2.SelectedItem = row.Cells["Manufacturer_name"].Value.ToString();
                textBox4.Text = row.Cells["stock_quantity"].Value.ToString();
                textBox5.Text = row.Cells["price"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(comboBox1.SelectedValue);
            int y = Convert.ToInt32(comboBox2.SelectedValue);


            string query = "INSERT INTO Medicines (medication_id,medication_name, MedicationType_id, Manufacturer_id, stock_quantity, price) " +
                           "VALUES (@medicationID,@medicationName, @medicationTypeId, @manufacturerId, @stockQuantity, @price)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();               
                command.Parameters.AddWithValue("@medicationID", textBox2.Text);
                command.Parameters.AddWithValue("@medicationName", textBox3.Text);
                command.Parameters.AddWithValue("@medicationTypeId", y);
                command.Parameters.AddWithValue("@manufacturerId", x);
                command.Parameters.AddWithValue("@stockQuantity", Convert.ToInt32(textBox4.Text));
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox5.Text));
                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                medicines();
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
            int x = Convert.ToInt32(comboBox1.SelectedValue);
            int y = Convert.ToInt32(comboBox2.SelectedValue);


            string query = "UPDATE Medicines SET medication_name = @medicationName, MedicationType_id = @medicationTypeId, " +
                   "Manufacturer_id = @manufacturerId, stock_quantity = @stockQuantity, price = @price " +
                   "WHERE medication_id = @medicineId";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@medicationName", textBox3.Text);
                command.Parameters.AddWithValue("@medicationTypeId", y);
                command.Parameters.AddWithValue("@manufacturerId", x);
                command.Parameters.AddWithValue("@stockQuantity", Convert.ToInt32(textBox4.Text));
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox5.Text));
                command.Parameters.AddWithValue("@medicineId", textBox2.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Successful!");
                medicines();
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
            string query = "DELETE FROM Medicines WHERE medication_id = @medicineId";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@medicineId", textBox2.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Successful!");
                medicines();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

        }
    }
}
