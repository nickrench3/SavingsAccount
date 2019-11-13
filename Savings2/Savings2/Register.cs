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
using System.Security.Cryptography;

namespace Savings2
{
    public partial class Register : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS;Initial Catalog=Savings;Integrated Security=True;Pooling=False");

        public Register()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT LoginName FROM Login WHERE LoginName =' " + usernameTextBox.Text.Trim() + " ' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Username is already taken, please try again");
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                string message = "Success";
                string title = "Registration";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                SqlCommand cmd = new SqlCommand("dbo.uspAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pLogin", usernameTextBox.Text);
                cmd.Parameters.AddWithValue("@pPassword", passwordTextBox.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Login form1 = new Login();
                form1.Show();
                this.Owner = form1;
                this.Hide();
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
