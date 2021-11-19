using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // new

namespace TenQLoginDB
{
    public partial class lgnForm : Form
    {
        

        public lgnForm()
        {
            InitializeComponent();
        }

        private void lgnForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mazid\source\repos\TenQLoginDB\DB\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");

            string query = "select * from LOGIN_TBL where username='" + txtUsername.Text.Trim() + "' and pass='" + txtPassword.Text.Trim() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

            DataTable dtbl = new DataTable();

            sda.Fill(dtbl);

            if (dtbl.Rows.Count==1)
            {
                Dashboard dashboard = new Dashboard();
                this.Hide();
                dashboard.Show();
            }

            else
            {
                MessageBox.Show("Invalid username or password!");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
