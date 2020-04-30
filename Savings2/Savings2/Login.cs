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
        private SqlConnection conSecure = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS;Initial Catalog=Security;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;
        public static string userName;

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
            userName = usernameTextBox.Text;
            bool result;
            conSecure.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT UserID FROM [dbo].[Login] WHERE LoginName='" + usernameTextBox.Text + "' AND PasswordHash=HASHBYTES('SHA2_512', N'" + passwordTextBox.Text + "') AND Added='Y'", conSecure);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                cmd = new SqlCommand("INSERT LOGINEVENTLOG VALUES('" + usernameTextBox.Text.Trim() + "', '" + DateTime.Now + "', 'Savings App')", conSecure);
                cmd.ExecuteNonQuery();
                conSecure.Close();
                Savings savings = new Savings();
                savings.Show();
                this.Owner = savings;
                this.Hide();
            }
            else
            {
                result = wrongPassword();
                if (result == true)
                {
                    MessageBox.Show("Your password is incorrect", "Error");
                }
                else
                {
                    MessageBox.Show("You do not have an account or the account still needs approval. ", "Error");
                }
            }
            conSecure.Close();
        }

        private Boolean wrongPassword()
        {
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT UserID FROM [dbo].[Login] WHERE LoginName='" + usernameTextBox.Text + "'", conSecure);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT UserID FROM [dbo].[Login] WHERE LoginName='" + usernameTextBox.Text + "' AND PasswordHash = HASHBYTES('SHA2_512', N'" + passwordTextBox.Text + "')", conSecure);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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
