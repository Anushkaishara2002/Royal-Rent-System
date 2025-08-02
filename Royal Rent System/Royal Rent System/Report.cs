using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Royal_Rent_System
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\MY-PC\Desktop\Royal Rent System\ROYAL Rent DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void Report_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTable";
            SqlDataAdapter sda = new SqlDataAdapter(querycar,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Carlbl.Text = dt.Rows[0][0].ToString();

            string querycustomer = "select Count(*) from CustomerTable";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycustomer, con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Customerlbl.Text = dt1.Rows[0][0].ToString();

            string queryuser = "select Count(*) from UserTable";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Userlbl.Text = dt2.Rows[0][0].ToString();



        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Carlbl_Click(object sender, EventArgs e)
        {

        }

        private void Customerlbl_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }
    }
}
