using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Royal_Rent_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rent rent = new Rent();
            rent.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return Return = new Return();
            Return.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users user = new Users();
            user.Show();

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report report = new Report();
            report.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.Show();
            this.Hide();
        }
    }
}
