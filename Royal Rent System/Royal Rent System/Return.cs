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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\MY-PC\Desktop\Royal Rent System\ROYAL Rent DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void car()
        {
            con.Open();
            string query = "select * from RentTable";
            SqlDataAdapter xy = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(xy);
            var ds = new DataSet();
            xy.Fill(ds);
            DGView4.DataSource = ds.Tables[0];
            con.Close();
        }
        private void carReturn()
        {
            con.Open();
            string query = "select * from ReturnTable";
            SqlDataAdapter xy = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(xy);
            var ds = new DataSet();
            xy.Fill(ds);
            DGView5.DataSource = ds.Tables[0];
            con.Close();
        }
        private void DeleteReturn()
        {
            int rentId;
            rentId=Convert.ToInt32(DGView4.SelectedRows[0].Cells[0].Value.ToString());
            con.Open();
            string query = "delete from RentTable where RentId=" +rentId+ ";";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Deleted Successfull");
            con.Close();
            car();
            //UpdateOnRentDelete();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            car();
            carReturn();

        }

        private void DGView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarId.Text = DGView4.SelectedRows[0].Cells[1].Value.ToString();
            txtName.Text = DGView4.SelectedRows[0].Cells[3].Value.ToString();
            Dtp2.Text = DGView4.SelectedRows[0].Cells[5].Value.ToString();

            DateTime d1 = Dtp2.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int days = Convert.ToInt32(t.TotalDays);
            if (days <= 0)
            {
                txtDelay.Text = "No Delay";
                txtFine.Text = "0";
            }
            else
            {
                txtDelay.Text = ""+days;
                txtFine.Text = ""+(days*1000);

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtFine.Text == "" || txtDelay.Text == "")
            {
                MessageBox.Show("Some values are Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into ReturnTable values(" + txtId.Text + ",'"+CarId.Text+"','"+ txtName.Text + "','" + Dtp2.Text + "','" +txtDelay.Text + "','"+ txtFine.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Returned");
                    con.Close();
                    //UpdateOnRent();
                    carReturn();
                    DeleteReturn();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void DGView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
