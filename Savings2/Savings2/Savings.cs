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
        private SqlConnection con = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS01;Initial Catalog=Savings;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;

        public Savings()
        {
            //userName variable to be used to determine access to Admin tab
            string userName;
            InitializeComponent();
            depositCheckBox.Checked = true;
            con.Open();
            //Select's balance from table for preset
            cmd = new SqlCommand("SELECT Balance FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                currBalTextBox.AppendText(balance + ".00");
            }
            con.Close();
            //Gets userName from the Login page and determines if tabPage should be removed
            userName = Login.userName;
            if (userName != "nickrench3")
            {
                tabControl1.TabPages.Remove(tabPage2);
            }   
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int amount;
            int finalBalance;
            int newBalance = 0;

            if (amtTextBox.Text == "")
            {
                MessageBox.Show("No Amount Entered.");
            }
            else
            {
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
                    amount = Convert.ToInt32(amtTextBox.Text);
                    finalBalance = newBalance + amount;
                    newBalTextBox.AppendText(finalBalance.ToString("0.00"));
                    cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    if (withdrawlCheckBox.Checked == true)
                    {
                        depositCheckBox.Checked = false;
                        withdrawlCheckBox.Checked = true;
                        con.Open();
                        amount = Convert.ToInt32(amtTextBox.Text);
                        finalBalance = newBalance - amount;
                        newBalTextBox.AppendText(finalBalance.ToString("0.00"));
                        cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            RecordEvent();
        }

        private void RecordEvent()
        {
            con.Open();;
            string beforeAmount = currBalTextBox.Text;
            string amountChanged = amtTextBox.Text;
            string newAmount = newBalTextBox.Text;
            string memoText = memoTextBox.Text;
            if (depositCheckBox.Checked == true)
            {
                cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'D', '" + amountChanged + "', '" + newAmount + "', '" + DateTime.Now + "', '" + memoText + "')", con);
            }
            else
            {
                if (withdrawlCheckBox.Checked == true)
                {
                    cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'W', '" + amountChanged + "', '" + newAmount + "', '" + DateTime.Now + "', '" + memoText + "')", con);
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            currBalTextBox.Clear();
            memoTextBox.Clear();
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
            depositCheckBox.Checked = false;
            withdrawlCheckBox.Checked = false;
        }

        private void AdminEnterButton_Click(object sender, EventArgs e)
        {
            string message = "Balance updated";
            string title = "Savings Account Admin";
            string beforeAmount = currBalTextBox.Text;
            MessageBox.Show(message, title);
            currBalTextBox.Clear();
            con.Open();
            string amountInput = adminTextBox.Text;
            int amount = Convert.ToInt32(amountInput);
            currBalTextBox.AppendText(amount.ToString("0.00"));
            cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + amount + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'A', '" + "" + "', '" + amountInput + "', '" + DateTime.Now + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void depositCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            withdrawlCheckBox.Checked = !depositCheckBox.Checked;
        }

        private void withdrawlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            depositCheckBox.Checked = !withdrawlCheckBox.Checked;
        }
    }
}
