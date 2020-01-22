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
    public partial class Login : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS;Initial Catalog=Savings;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT UserID FROM [dbo].[Login] WHERE LoginName='" + usernameTextBox.Text + "' AND PasswordHash=HASHBYTES('SHA2_512', N'" + passwordTextBox.Text + "') AND Added='Y'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                cmd = new SqlCommand("INSERT LOGINEVENTLOG VALUES('" + usernameTextBox.Text.Trim() + "', '" + DateTime.Now + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Savings savings = new Savings();
                savings.Show();
                this.Owner = savings;
                this.Hide();
            }
            else
            {
                
                MessageBox.Show("Your account has not been activated yet or check your username and password", "Error");
            }
            con.Close();
        }

        private void Savings_FormClosed(object send, FormClosedEventArgs e)
        {
            this.Close();
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Owner = register;
            this.Hide();
        }

    }
}
