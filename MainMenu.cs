using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medicines medicines = new Medicines();
            medicines.Show();
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customers = new Customers();
            customers.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selling selling = new Selling();
            selling.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
