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
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        
        //Make Sql Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\LENOVO\Desktop\Royal Rent System\Royal Rent System\ROYAL Rent DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void car()
        {
            con.Open();
            string query = "select * from CarTable";
            SqlDataAdapter xy = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(xy);
            var ds = new DataSet();
            xy.Fill(ds);
            DGView2.DataSource = ds.Tables[0];
            con.Close();
        }


        //Add car to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtReg.Text == "" || txtOwner.Text == "" || cmbBrand.Text == "" || txtModel.Text == "" || txtKm.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into CarTable values('" + txtReg.Text + "','" + txtOwner.Text + "','" + cmbBrand.SelectedItem.ToString() + "','" + txtModel.Text + "','" + cmbAvailable.SelectedItem.ToString() + "'," + txtKm.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Added Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }


        }

        private void Car_Load(object sender, EventArgs e)
        {
            car();
        }

        //Stop application
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Delete car from database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtReg.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from CarTable where Regnumber='" + txtReg.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Car Successfull");
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
        private void DGView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReg.Text = DGView2.SelectedRows[0].Cells[0].Value.ToString();
            txtOwner.Text = DGView2.SelectedRows[0].Cells[1].Value.ToString();
            cmbBrand.SelectedItem = DGView2.SelectedRows[0].Cells[2].Value.ToString();
            txtModel.Text = DGView2.SelectedRows[0].Cells[3].Value.ToString();
            cmbAvailable.SelectedItem = DGView2.SelectedRows[0].Cells[4].Value.ToString();
            txtKm.Text = DGView2.SelectedRows[0].Cells[5].Value.ToString();
        }

        //update car information
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtReg.Text == "" || txtOwner.Text == "" || cmbBrand.Text == "" || txtModel.Text == "" || txtKm.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update CarTable set Owner='" + txtOwner.Text + "',Brand='" + cmbBrand.SelectedItem.ToString() + "',Model='" +txtModel.Text+ "',Available='" + cmbAvailable.SelectedItem.ToString() + "',Price=" + txtKm.Text + " where Regnumber='" + txtReg.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car updated Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }



            }
        }

        //Go to main form
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }
         
      

        
    }
}
