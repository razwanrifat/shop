using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Shop_Management_System
{
    public partial class Login : Form
    {
        public static string Seller;
        DBConnection dBcon = new DBConnection();
        public Login()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-363K8PB\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=Ture";
       

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Red;

        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Goldenrod;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter Username and Password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cmbRole.SelectedIndex > -1)
                {
                    if (cmbRole.SelectedItem.ToString() == "ADMIN")
                    {
                        if (txtUsername.Text == "Admin" && txtPassword.Text == "123")
                        {
                            ProductForm product = new ProductForm();
                            product.Show();
                            this.Hide();
                        }
                        else   
                        {
                            MessageBox.Show("If you are Admin, Please Enter the corret Id and Password", "Miss Id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        string selectQuery = "SELECT * FROM Seller WHERE SellerName='" + txtUsername.Text + "' AND SellerPass='" + txtPassword.Text + "'";

                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, dBcon.GetCon());
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {                     
                            SellingForm selling = new SellingForm();
                            selling.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please Select Role", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
       
    }
}
