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

namespace Savings2
{
    public partial class Savings : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS;Initial Catalog=Savings;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;

        public Savings()
        {
            InitializeComponent();
            con.Open();
            cmd = new SqlCommand("SELECT Balance FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                currBalTextBox.AppendText(balance + ".00");

            }
            con.Close();
            con.Open();
            cmd = new SqlCommand("SELECT TOP 1 * FROM LoginEventLog ORDER BY ExecutionTime desc", con);
            SqlDataReader dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                string userName = (dr2["username"].ToString());
                if (userName != "nickrench3")
                {
                    tabControl1.TabPages.Remove(tabPage2);
                }

            }
            con.Close();
           
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string amountInput;
            int amount;
            int finalBalance;
            int newBalance = 0;
            string yes = "true";
            string no = "false";

            newBalTextBox.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT Balance FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                newBalance = Convert.ToInt32(balance);

            }
            con.Close();


            if (depositCheckBox.Checked == true)
            {
                depositCheckBox.Checked = true;
                withdrawlCheckBox.Checked = false;
                con.Open();
                amountInput = amtTextBox.Text;
                amount = Convert.ToInt32(amountInput);
                finalBalance = newBalance + amount;
                newBalTextBox.AppendText(finalBalance.ToString("0.00"));
                cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {

            }


            if (withdrawlCheckBox.Checked == true)
            {
                depositCheckBox.Checked = false;
                withdrawlCheckBox.Checked = true;
                con.Open();
                amountInput = amtTextBox.Text;
                amount = Convert.ToInt32(amountInput);
                finalBalance = newBalance - amount;
                newBalTextBox.AppendText(finalBalance.ToString("0.00"));
                cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {

            }
            RecordEvent();
        }

        private void RecordEvent()
        {
            con.Open();;
            string beforeAmount = currBalTextBox.Text;
            string amountChanged = amtTextBox.Text;
            string newAmount = newBalTextBox.Text;
            if (depositCheckBox.Checked == true)
            {
                cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'D', '" + amountChanged + "', '" + newAmount + "', '" + DateTime.Now + "')", con);
            }
            else
            {
                if (withdrawlCheckBox.Checked == true)
                {
                    cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'W', '" + amountChanged + "', '" + newAmount + "', '" + DateTime.Now + "')", con);
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            currBalTextBox.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT Balance FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                currBalTextBox.AppendText(balance);
            }
            con.Close();
            amtTextBox.Text = "";
            newBalTextBox.Text = "";
            adminTextBox.Text = "";
        }

        private void DepositCheckBox_Click_1(object sender, EventArgs e)
        {
            if (depositCheckBox.Checked == true)
            {
                depositCheckBox.Checked = true;
                withdrawlCheckBox.Checked = false;
            }
        }

        private void WithdrawlCheckBox_Click_1(object sender, EventArgs e)
        {
            if (withdrawlCheckBox.Checked == true)
            {
                depositCheckBox.Checked = false;
                withdrawlCheckBox.Checked = true;
            }
        }

        private void AdminEnterButton_Click(object sender, EventArgs e)
        {
            string message = "Balance updated";
            string title = "Savings Account Admin";
            MessageBox.Show(message, title);
            currBalTextBox.Clear();
            con.Open();
            string amountInput = adminTextBox.Text;
            int amount = Convert.ToInt32(amountInput);
            currBalTextBox.AppendText(amount.ToString("0.00"));
            cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + amount + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
