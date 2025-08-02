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
    public partial class Rent : Form
    {
        public Rent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\LENOVO\Desktop\Royal Rent System\Royal Rent System\ROYAL Rent DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        //show only available cars
        private void fillcombo()
        {
            
            con.Open();
            string query = "select Regnumber from CarTable where Available='"+"Yes"+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Regnumber", typeof(string));
            dt.Load(reader);
            CarRegCb.ValueMember = "Regnumber";
            CarRegCb.DataSource = dt;
            con.Close(); 
            

        }
        private void fillcustomer()
        {

            con.Open();
            string query = "select CusId from CustomerTable";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(string));
            dt.Load(reader);
            CustCb.ValueMember = "CusId";
            CustCb.DataSource = dt;
            con.Close();


        }
        private void fetchcusname()
        {
            con.Open();
            string query = "select * from CustomerTable where CusId=" + CustCb.SelectedValue.ToString()+ "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtName.Text = dr["CusName"].ToString();
            }
            con.Close();
        }
       
        private void car()
        {
            con.Open();
            string query = "select * from RentTable";
            SqlDataAdapter xy = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(xy);
            var ds = new DataSet();
            xy.Fill(ds);
            DGView3.DataSource = ds.Tables[0];
            con.Close();
        }

         private void UpdateOnRent()
         {
             con.Open();
             string query = "update CarTable set Available='"+"No"+"' where Regnumber='" +CarRegCb.SelectedValue.ToString()+ "';";
             SqlCommand cmd = new SqlCommand(query, con);
             cmd.ExecuteNonQuery();
             //MessageBox.Show("Car updated Successfull");
             con.Close();

         }
         private void UpdateOnRentDelete()
         {
             con.Open();
             string query = "update CarTable set Available='" + "Yes" + "' where Regnumber='" + CarRegCb.SelectedValue.ToString() + "';";
             SqlCommand cmd = new SqlCommand(query, con);
             cmd.ExecuteNonQuery();
             //MessageBox.Show("Car updated Successfull");
             con.Close();

         }
        private void Rent_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillcustomer();
            car();
            
        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchcusname();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into RentTable values(" + txtId.Text + ",'" + CarRegCb.SelectedValue.ToString() + "','" + CustCb.SelectedValue.ToString() + "','" + txtName.Text + "','" + Dtp1.Text + "','" + Dtp2.Text + "'," + txtPrice.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Rented");
                    con.Close();
                    UpdateOnRent();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x,price;
            x = Int32.Parse(txtDistance.Text);
            price = x * 100;
            txtPrice.Text = price.ToString();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                    string query = "delete from RentTable where RentId=" + txtId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfull");
                    con.Close();
                    car();
                    UpdateOnRentDelete();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }


            }
        }

        private void DGView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = DGView3.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.SelectedValue = DGView3.SelectedRows[0].Cells[1].Value.ToString();
            txtName.Text = DGView3.SelectedRows[0].Cells[3].Value.ToString();
            txtPrice.Text = DGView3.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
                    string query = "update RentTable set CarReg='"+CarRegCb.Text+"',CustomerId='"+CustCb.Text+"',RentDate='" + Dtp1.Text + "',ReturnDate='" + Dtp2.Text + "',RentFee=" + txtPrice.Text + " where RentId='" + txtId.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent updated Successfull");
                    con.Close();
                    car();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }



            }
        }

        private void DGView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       


    }
}
