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
    public partial class SellingForm : Form
    {
        DBConnection dBcon = new DBConnection();
        public SellingForm()
        {
            InitializeComponent();
        }
        private void getCategory()
        {
            string selectQuerry = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbCategory.DataSource = table;
            cmbCategory.ValueMember = "CatName";

        }
        private void cmbCategory_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            string selectQuerry = "SELECT ProdName, ProdPrice FROM Product WHERE ProdCat='" + cmbCategory.SelectedValue.ToString() + "'";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvProduct.DataSource = table;
        }
        private void getTable()
        {
            string selectQuerry = "SELECT ProdName, ProdPrice FROM Product";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvProduct.DataSource = table;
        }
        private void getSellTable()
        {
            string selectQuerry = "SELECT * FROM Bill";
            SqlCommand command = new SqlCommand(selectQuerry, dBcon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvSellList.DataSource = table;
        }
        private void SellingForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.ToShortDateString();
            getTable();
            getCategory();
            getSellTable();
        }

        private void dgvProduct_Click(object sender, EventArgs e)
        {
            txtNameSelling.Text = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();
            txtpriceSelling.Text = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();
        }

        int grandTotal = 0, n = 0;

        private void btnAddSelling_Click(object sender, EventArgs e)
        {

            try
            {
                string insertQuery = "INSERT INTO Bill VALUES(" + lblSellerName.Text + "','" + lblDate.Text + "'," + grandTotal.ToString() + ")";
                SqlCommand command = new SqlCommand(insertQuery, dBcon.GetCon());
                dBcon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Order Added Successfully", "Order Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBcon.CloseCon();
                getSellTable();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddOrder_Click(object sender, EventArgs e)
        {

            if (txtNameSelling.Text == "" || txtQuantitySelling.Text == "")
            {
                MessageBox.Show("Missing Information", "Information Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int Total = Convert.ToInt32(txtpriceSelling.Text) * Convert.ToInt32(txtQuantitySelling.Text);
                DataGridViewRow addRow = new DataGridViewRow();
                addRow.CreateCells(dgvOrder);
                addRow.Cells[0].Value = ++n;
                addRow.Cells[1].Value = txtNameSelling.Text;
                addRow.Cells[2].Value = txtpriceSelling.Text;
                addRow.Cells[3].Value = txtQuantitySelling.Text;
                addRow.Cells[4].Value = Total;
                dgvOrder.Rows.Add(addRow);
                grandTotal += Total;
                label_amount.Text = grandTotal + " TK";
            }
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblExitP_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            RefreshContent();
        }

        private void lblLogoutSelling_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

       

        private void RefreshContent()
        { 
            this.txtNameSelling.Clear();
            this.txtpriceSelling.Clear();
            this.txtQuantitySelling.Clear();
          
        }


    }
}
