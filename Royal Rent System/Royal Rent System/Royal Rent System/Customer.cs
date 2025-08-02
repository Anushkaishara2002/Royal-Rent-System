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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        
        //Make Sql Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\LENOVO\Desktop\Royal Rent System\Royal Rent System\ROYAL Rent DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void car()
        {
            con.Open();
            string query = "select * from CustomerTable";
            SqlDataAdapter xy = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(xy);
            var ds = new DataSet();
            xy.Fill(ds);
            DGView3.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        //Add customers to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CustomerTable values(" + txtId.Text + ",'" + txtName.Text + "','" + txtAddress.Text + "','"+ txtPhone.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            car();
        }

        //Delete Customer information from database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from CustomerTable where CusId=" + txtId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Customer Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }

            }
           
        }

        //Get values for text boxes, when click cell
        private void DGView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = DGView3.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = DGView3.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = DGView3.SelectedRows[0].Cells[2].Value.ToString();
            txtPhone.Text = DGView3.SelectedRows[0].Cells[3].Value.ToString();


        }

        //update Customer information
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CustomerTable set CusName='" + txtName.Text + "',CusAddress='" + txtAddress.Text + "',CusPhone='" +txtPhone.Text+"' where CusId="+txtId.Text+";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer updated Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }



            }
        }
    }
}
