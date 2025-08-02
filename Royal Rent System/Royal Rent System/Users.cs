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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        //Make Sql Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\MY-PC\Desktop\Royal Rent System\ROYAL Rent DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void car()
        {
            con.Open();
            string query = "select * from UserTable";
            SqlDataAdapter xy = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(xy);
            var ds = new DataSet();
            xy.Fill(ds);
            DGView1.DataSource = ds.Tables[0];
            con.Close();
        }


      
        //Add data for database
        private void button6_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "" || txtName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into UserTable values(" + txtId.Text + ",'" + txtName.Text + "','" + txtPass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }



            }


        }

        private void Users_Load(object sender, EventArgs e)
        {
            car();
        }

        
        
        //Delete data from database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from UserTable where Id=" + txtId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }


            }


        }

       
        //Update data from database
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update UserTable set Username='" + txtName.Text + "',Userpassword='" + txtPass.Text + "'where Id=" + txtId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated Successfull");
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


        //Get values for text boxes, when click cell
        private void DGView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = DGView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text=DGView1.SelectedRows[0].Cells[1].Value.ToString();
            txtPass.Text = DGView1.SelectedRows[0].Cells[2].Value.ToString();
        }

       
    }

}
