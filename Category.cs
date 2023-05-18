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
    public partial class Category : Form
    {
        DBConnection dBcon = new DBConnection();
        public Category()
        {
            InitializeComponent();
        }

        private void getTable()
        {
            string selectQuerry = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvCategoryMaintining.DataSource = table;
        }
        private void btnAddCategory1_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Category VALUES(" + txtIdCategory.Text + ",'" + txtNameCategory.Text + "','" + txtDescriptionCategory.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, dBcon.GetCon());
                dBcon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBcon.CloseCon();
                getTable();
                Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Category_Load(object sender, EventArgs e)
        {
            getTable();
        }
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdCategory.Text == "" || txtNameCategory.Text == "" || txtDescriptionCategory.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string updateQuery = "UPDATE Category SET CatName='" + txtNameCategory.Text + "', CatDes='" + txtDescriptionCategory.Text + "'WHERE CatId=" + txtIdCategory.Text + " ";
                    SqlCommand command = new SqlCommand(updateQuery, dBcon.GetCon());
                    dBcon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Updated Successfully", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBcon.CloseCon();
                    getTable();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvCategoryMaintining_DoubleClick(object sender, EventArgs e)
        {
            txtIdCategory.Text = dgvCategoryMaintining.SelectedRows[0].Cells[0].Value.ToString();
            txtNameCategory.Text = dgvCategoryMaintining.SelectedRows[0].Cells[1].Value.ToString();
            txtDescriptionCategory.Text = dgvCategoryMaintining.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void Clear()
        {
            txtIdCategory.Clear();
            txtNameCategory.Clear();
            txtDescriptionCategory.Clear();
        }
        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        { 
            try
            {
                string deleteQuery = "DELETE FROM Category WHERE CatId = " + txtIdCategory.Text + "";
                SqlCommand command = new SqlCommand(deleteQuery, dBcon.GetCon());
                dBcon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Category Deleted Successfully", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBcon.CloseCon();
                getTable();
                Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }

        private void lblExitP_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
