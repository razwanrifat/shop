using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Shop_Management_System
{
    public partial class SellerForm : Form
    {
        DBConnection dBcon = new DBConnection();
        public SellerForm()
        {
            InitializeComponent();
        }
        private void getTable()
        {
            string selectQuerry = "SELECT * FROM Seller";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvSellerMaintining.DataSource = table;
        }

        private void clear()
        {
            txtIdSeller.Clear();
            txtNameSeller.Clear();
            txtAgeSeller.Clear();
            txtPhoneNo.Clear();
            txtPasswordSeller.Clear();

        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Seller VALUES(" + txtIdSeller.Text + ",'" + txtNameSeller.Text + "','" + txtAgeSeller.Text + "','" + txtPhoneNo.Text + "','" + txtPasswordSeller.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, dBcon.GetCon());
                dBcon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBcon.CloseCon();
                getTable();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SellerForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void dgvSellerMaintining_Click(object sender, EventArgs e)
        {
            txtIdSeller.Text = dgvSellerMaintining.SelectedRows[0].Cells[0].Value.ToString();
            txtNameSeller.Text = dgvSellerMaintining.SelectedRows[0].Cells[1].Value.ToString();
            txtAgeSeller.Text = dgvSellerMaintining.SelectedRows[0].Cells[2].Value.ToString();
            txtPhoneNo.Text = dgvSellerMaintining.SelectedRows[0].Cells[3].Value.ToString();
            txtPasswordSeller.Text = dgvSellerMaintining.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtIdSeller.Text == "")
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        string deleteQuery = "DELETE FROM Seller WHERE SellerId=" + txtIdSeller.Text + "";
                        SqlCommand command = new SqlCommand(deleteQuery, dBcon.GetCon());
                        dBcon.OpenCon();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Seller Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dBcon.CloseCon();
                        getTable();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdSeller.Text == "" || txtNameSeller.Text == "" || txtAgeSeller.Text == "" || txtPhoneNo.Text == "" || txtPasswordSeller.Text == "")
                {
                    MessageBox.Show("Missing Information", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string updateQuery = "UPDATE Seller SET SellerName='" + txtNameSeller.Text + "',SellerAge='" + txtAgeSeller.Text + "',SellerPhone='" + txtPhoneNo.Text + "',SellerPass='" + txtPasswordSeller.Text + "'WHERE SellerId=" + txtIdSeller.Text + "";
                    SqlCommand command = new SqlCommand(updateQuery, dBcon.GetCon());
                    dBcon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated Successfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBcon.CloseCon();
                    getTable();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }
        private void lblLogoutS_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void lblExitS_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
