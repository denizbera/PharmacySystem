using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmacyManagementSystem
{
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }
        DataTable dataTable;
        SqlConnection connection;
        string connectionString = "Data Source=.;Initial Catalog=20200305034;Integrated Security=True";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                label7.Text = row.Cells["medication_id"].Value.ToString();
                label8.Text = row.Cells["medication_name"].Value.ToString();                
                label10.Text = row.Cells["stock_quantity"].Value.ToString();
                label9.Text = row.Cells["price"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            dv.RowFilter = " medication_name LIKE '" + textBox1.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        public void medicines()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT m.medication_id, m.medication_name, mt.MedicationType_name, mf.Manufacturer_name,m.stock_quantity,m.price
                FROM Medicines m
                JOIN MedicationTypes mt ON m.MedicationType_id = mt.MedicationType_id
                JOIN Manufacturer mf ON m.Manufacturer_id = mf.Manufacturer_id";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }
        public void bill()
        {
            string query = @"SELECT b.bill_id,m.medication_id, m.medication_name, b.customer_id, b.quantity, b.total_price 
                 FROM Bill b 
                 JOIN Medicines m ON b.medication_id = m.medication_id ";
                 
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }
        public void getbill(int billid)
        {            
                      
            string query = @"SELECT b.bill_id,m.medication_id, m.medication_name, b.customer_id, b.quantity, b.total_price 
                 FROM Bill b 
                 JOIN Medicines m ON b.medication_id = m.medication_id 
                 WHERE b.bill_id = @billid";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@billid", billid);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;


            decimal totalPriceSum = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                decimal totalPrice;
                if (row.Cells["total_price"].Value != null && decimal.TryParse(row.Cells["total_price"].Value.ToString(), out totalPrice))
                {
                    totalPriceSum += totalPrice;
                }
            }


            label13.Text ="Total Price: "+ totalPriceSum.ToString();

        }
        public void getcustomer(int customerid)
        {

            string query = @"SELECT b.bill_id,m.medication_id, m.medication_name, b.customer_id, b.quantity, b.total_price 
                 FROM Bill b 
                 JOIN Medicines m ON b.medication_id = m.medication_id 
                 WHERE b.customer_id = @customerid ";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid", customerid);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;


            decimal totalPriceSum = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                decimal totalPrice;
                if (row.Cells["total_price"].Value != null && decimal.TryParse(row.Cells["total_price"].Value.ToString(), out totalPrice))
                {
                    totalPriceSum += totalPrice;
                }
            }


            label13.Text = "Total Price: " + totalPriceSum.ToString();

        }

        private void Selling_Load(object sender, EventArgs e)
        {
            medicines();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(textBox3.Text);
            int stock = Convert.ToInt32(label10.Text);



            if (quantity>stock)
            {
                MessageBox.Show("insufficient stock!");
            }
            else if(quantity<=stock)
            {
                double total_price = double.Parse(label9.Text) * quantity;

                
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand billCommand = new SqlCommand();
                billCommand.Connection = connection;
                billCommand.CommandText = "INSERT INTO Bill (bill_id, medication_id, customer_id, quantity, total_price) " +
                                          "VALUES (@billId, @medicationId, @customerId, @quantity, @total_price)";
                billCommand.Parameters.AddWithValue("@billId", int.Parse(textBox4.Text));
                billCommand.Parameters.AddWithValue("@medicationId", int.Parse(label7.Text));
                billCommand.Parameters.AddWithValue("@customerId", int.Parse(textBox2.Text));
                billCommand.Parameters.AddWithValue("@quantity", quantity);
                billCommand.Parameters.AddWithValue("@total_price", total_price);

               

               
                SqlCommand stockUpdateCommand = new SqlCommand();
                stockUpdateCommand.Connection = connection;
                stockUpdateCommand.CommandText = "UPDATE Medicines SET stock_quantity = stock_quantity - @quantity " +
                                                 "WHERE medication_id = @medicationId";
                stockUpdateCommand.Parameters.AddWithValue("@medicationId", int.Parse(label7.Text));
                stockUpdateCommand.Parameters.AddWithValue("@quantity", quantity);

                try
                {
                    connection.Open();                    
                    billCommand.ExecuteNonQuery();                                   
                    stockUpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Successful!");
                    medicines();
                    getbill(int.Parse(textBox4.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                label21.Text =  row.Cells["bill_id"].Value.ToString();
                label23.Text = row.Cells["medication_name"].Value.ToString();
                label24.Text =  row.Cells["medication_id"].Value.ToString();
                label22.Text = row.Cells["customer_id"].Value.ToString();
                textBox5.Text = row.Cells["quantity"].Value.ToString();
                label25.Text = row.Cells["quantity"].Value.ToString();
               
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getbill(int.Parse(textBox6.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bill();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getcustomer(int.Parse(textBox7.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int billId = int.Parse(label21.Text);
            int medicationId = int.Parse(label24.Text);
            int new_quantity = int.Parse(textBox5.Text);

            string deleteQuery = "DELETE FROM Bill WHERE bill_id = @billId AND medication_id = @medicationId";
            string updateQuery = "UPDATE Medicines SET stock_quantity = stock_quantity +@new_quantity  WHERE medication_id = @medicationId";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

            deleteCommand.Parameters.AddWithValue("@billId", billId);
            deleteCommand.Parameters.AddWithValue("@medicationId", medicationId);
            updateCommand.Parameters.AddWithValue("@billId", billId);
            updateCommand.Parameters.AddWithValue("@medicationId", medicationId);
            updateCommand.Parameters.AddWithValue("@new_quantity", new_quantity);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                updateCommand.ExecuteNonQuery();                
                MessageBox.Show("Successful!");
                getbill(int.Parse(label21.Text));
                medicines();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                connection.Close();
                deleteCommand.Dispose();
                updateCommand.Dispose();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int billId = int.Parse(label21.Text);
            int medicationId = int.Parse(label24.Text);
            int quantity = int.Parse(textBox5.Text);
            int new_quantity = 0;
            string updateMedicinesQuery;
            string updateBillQuery;


            if (int.Parse(label25.Text)>quantity)
            {
                new_quantity = int.Parse(label25.Text) - quantity;
                updateMedicinesQuery = "UPDATE Medicines SET stock_quantity = stock_quantity + @new_quantity WHERE medication_id = @medicationId";
                updateBillQuery = "UPDATE Bill SET quantity = @quantity, total_price=total_price-@totalprice WHERE bill_id = @billId AND medication_id = @medicationId";
            }
            else
            {
                new_quantity = quantity - int.Parse(label25.Text);
                updateMedicinesQuery = "UPDATE Medicines SET stock_quantity = stock_quantity - @new_quantity WHERE medication_id = @medicationId";
                updateBillQuery = "UPDATE Bill SET quantity = @quantity, total_price=total_price+@totalprice WHERE bill_id = @billId AND medication_id = @medicationId";
            }

            double total_price = new_quantity *double.Parse(label9.Text);

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand updateBillCommand = new SqlCommand(updateBillQuery, connection);
                SqlCommand updateMedicinesCommand = new SqlCommand(updateMedicinesQuery, connection);

                updateBillCommand.Parameters.AddWithValue("@quantity", quantity);
                updateBillCommand.Parameters.AddWithValue("@billId", billId);
                updateBillCommand.Parameters.AddWithValue("@medicationId", medicationId);
                updateBillCommand.Parameters.AddWithValue("@totalprice", total_price);

                updateMedicinesCommand.Parameters.AddWithValue("@new_quantity", new_quantity);
                updateMedicinesCommand.Parameters.AddWithValue("@medicationId", medicationId);

                try
                {
                    connection.Open();
                    updateBillCommand.ExecuteNonQuery();
                    updateMedicinesCommand.ExecuteNonQuery();
                    MessageBox.Show("Successful!");
                    medicines();
                    getbill(int.Parse(textBox4.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu =  new  MainMenu();
            mainMenu.Show();
        }
    }
    }

