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
using System.Net;
using System.Net.Sockets;

namespace Savings2
{
    public partial class Login : Form
    {
        private SqlConnection conSecure = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS01;Initial Catalog=Security;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;
        private string LastIP = "";
        private string HostName = "";
        public static string userName;
        public bool result;

        public Login()
        {
            InitializeComponent();
            LastIP = GetLocalIPAddress();
            HostName = Dns.GetHostName();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            userName = usernameTextBox.Text;
            conSecure.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT UserID FROM [dbo].[Login] WHERE LoginName='" + usernameTextBox.Text + "' AND PasswordHash=HASHBYTES('SHA2_512', N'" + passwordTextBox.Text + "') AND Added='Y' and Savings = 1", conSecure);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                cmd = new SqlCommand("INSERT LOGINEVENTLOG VALUES('" + usernameTextBox.Text.Trim() + "', '" + DateTime.Now + "', 'Savings App', '"+LastIP+"', '"+HostName+"')", conSecure);
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
                    MessageBox.Show("You do not have an account or you do not have access. ", "Error");
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

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Owner = register;
            this.Hide();
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
