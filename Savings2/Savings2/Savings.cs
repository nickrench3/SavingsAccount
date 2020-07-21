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
using System.Runtime.CompilerServices;

namespace Savings2
{
    public partial class Savings : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=NICKRENTSCHLER\SQLEXPRESS01;Initial Catalog=Savings;Integrated Security=True;Pooling=False");
        private SqlCommand cmd;
        public int beforeBalance = 0;

        public Savings()
        {
            string userName;

            InitializeComponent();

            depositCheckBox.Checked = true;

            con.Open();
            //Select's balance from table for preset
            cmd = new SqlCommand("SELECT Balance, Cash, Bank FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                currBalTextBox.AppendText(balance + ".00");
                beforeBalance = Convert.ToInt32(balance);
                string bank = (dr["Bank"].ToString());
                BankTextBox.AppendText(bank + ".00");
                string cash = (dr["Cash"].ToString());
                CashTextBox.AppendText(cash + ".00");
            }
            con.Close();

            //Gets userName from the Login page and determines if tabPage should be removed
            userName = Login.userName;
            if (userName != "nickrench3")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            }
            //Gets the history from the EventLog
            GetHistory();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int amount;
            int finalBalance;
            int newBalance = 0;
            int cashBalance = 0;
            int bankBalance = 0;

            if (amtTextBox.Text == "")
            {
                MessageBox.Show("No Amount Entered.");
            }
            else
            {
                //Gets the balance, cash and bank amounts from table
                con.Open();
                cmd = new SqlCommand("SELECT Balance, Cash, Bank FROM SavingsAcct", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string balance = (dr["Balance"].ToString());
                    newBalance = Convert.ToInt32(balance);
                    beforeBalance = Convert.ToInt32(balance);
                    string bank = (dr["Bank"].ToString());
                    bankBalance = Convert.ToInt32(bank);
                    string cash = (dr["Cash"].ToString());
                    cashBalance = Convert.ToInt32(cash);
                }
                con.Close();

                con.Open();

                //Looks at if the transacation will be a deposit and cash
                if (depositCheckBox.Checked == true && CashCheckbox.Checked == true)
                {
                    depositCheckBox.Checked = true;
                    withdrawlCheckBox.Checked = false;
                    amount = Convert.ToInt32(amtTextBox.Text);
                    finalBalance = newBalance + amount;
                    cashBalance = cashBalance + amount;
                    CashTextBox.AppendText(cashBalance.ToString("0.00"));
                    cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "', Cash = '"+cashBalance+"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    //Looks at if the transacation will be a deposit and not cash
                    if (depositCheckBox.Checked == true && CashCheckbox.Checked == false)
                    {
                        depositCheckBox.Checked = true;
                        withdrawlCheckBox.Checked = false;
                        amount = Convert.ToInt32(amtTextBox.Text);
                        finalBalance = newBalance + amount;
                        bankBalance = bankBalance + amount;
                        BankTextBox.AppendText(bankBalance.ToString("0.00"));
                        cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "', Bank = '" + bankBalance + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        //Looks at if the transacation will be a withdrawl and cash
                        if (withdrawlCheckBox.Checked == true && CashCheckbox.Checked == true)
                        {
                            depositCheckBox.Checked = false;
                            withdrawlCheckBox.Checked = true;
                            amount = Convert.ToInt32(amtTextBox.Text);
                            finalBalance = newBalance - amount;
                            cashBalance = cashBalance - amount;
                            CashTextBox.AppendText(cashBalance.ToString("0.00"));
                            cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "', Cash = '"+cashBalance + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            //Looks at if the transacation will be a withdrawl and not cash
                            if (withdrawlCheckBox.Checked == true && CashCheckbox.Checked == false)
                            {
                                depositCheckBox.Checked = false;
                                withdrawlCheckBox.Checked = true;
                                amount = Convert.ToInt32(amtTextBox.Text);
                                finalBalance = newBalance - amount;
                                bankBalance = bankBalance - amount;
                                BankTextBox.AppendText(bankBalance.ToString("0.00"));
                                cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "', Bank = '" + bankBalance + "'", con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
            }
            //Loads the values of the textboxes
            LoadValues();
            //Inserts event into the EventLog
            RecordEvent();
            //Gets the history from the EventLog
            GetHistory();
            ClearBoxes();
        }

        private void GetHistory()
        {
            string SQL = "SELECT BeforeBalance as [Before], [Transfer], Amount, NewBalance as New, CONVERT(date, ExecutionTime) as [Date], Memo, CASE Cash WHEN 1 THEN 'Y' ELSE 'N' END AS Cash FROM SavingsEventLog ORDER BY ExecutionTime DESC";
            cmd = new SqlCommand(SQL, con);
            con.Open();
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            HistoryDataGridView.DataSource = table;
            HistoryDataGridView.AutoResizeColumns();
            con.Close();
        }

        public void RecordEvent()
        {
            con.Open();;
            int beforeAmount = beforeBalance;
            string amountChanged = amtTextBox.Text;
            string newAmount = currBalTextBox.Text;
            string memoText = memoTextBox.Text;
            bool Cash = CashCheckbox.Checked;
            if (depositCheckBox.Checked == true)
            {
                cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'D', '" + amountChanged + "', '" + newAmount + "', '" + DateTime.Now + "', '" + memoText + "', '" + Cash + "')", con);
            }
            else
            {
                if (withdrawlCheckBox.Checked == true)
                {
                    cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'W', '" + amountChanged + "', '" + newAmount + "', '" + DateTime.Now + "', '" + memoText + "', '" + Cash + "')", con);
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            memoTextBox.Clear();
            amtTextBox.Text = "";
            adminTextBox.Text = "";
            depositCheckBox.Checked = false;
            withdrawlCheckBox.Checked = false;
            CashCheckbox.Checked = false;
        }

        private void LoadValues()
        {
            currBalTextBox.Clear();
            CashTextBox.Clear();
            BankTextBox.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT Balance, Cash, Bank FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                currBalTextBox.AppendText(balance + ".00");
                string bank = (dr["Bank"].ToString());
                BankTextBox.AppendText(bank + ".00");
                string cash = (dr["Cash"].ToString());
                CashTextBox.AppendText(cash + ".00");
            }
            con.Close();
        }

        private void AdminEnterButton_Click(object sender, EventArgs e)
        {
            string message = "Balance updated";
            string title = "Savings Account Admin";
            string beforeAmount = currBalTextBox.Text;
            MessageBox.Show(message, title);

            //Clears the textboxes
            ClearBoxes();

            //Getting the amount inputs
            string amountInput = adminTextBox.Text;
            int amount = Convert.ToInt32(amountInput);
            currBalTextBox.AppendText(amount.ToString("0.00"));
            int cash = Convert.ToInt32(AdminCash.Text);
            CashTextBox.AppendText(cash.ToString("0.00"));
            int bank = Convert.ToInt32(AdminBank.Text);
            BankTextBox.AppendText(bank.ToString("0.00"));

            //Update balance and insert into EventLog
            con.Open();
            cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + amount + "', Bank = '"+bank+"', Cash = '"+cash+"'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + beforeAmount + "', 'A', '" + "" + "', '" + amountInput + "', '" + DateTime.Now + "', 'Admin Entry', 'N')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ClearBoxes()
        {
            memoTextBox.Clear();
            amtTextBox.Text = "";
            adminTextBox.Text = "";
            depositCheckBox.Checked = false;
            withdrawlCheckBox.Checked = false;
            CashCheckbox.Checked = false;
        }

        private void depositCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            withdrawlCheckBox.Checked = !depositCheckBox.Checked;
        }

        private void withdrawlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            depositCheckBox.Checked = !withdrawlCheckBox.Checked;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depositCheckBox.Checked = true;
            ClearBoxes();
            con.Open();
            //Select's balance from table for preset
            cmd = new SqlCommand("SELECT Balance, Cash, Bank FROM SavingsAcct", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string balance = (dr["Balance"].ToString());
                currBalTextBox.AppendText(balance + ".00");
                beforeBalance = Convert.ToInt32(balance);
                string bank = (dr["Bank"].ToString());
                BankTextBox.AppendText(bank + ".00");
                string cash = (dr["Cash"].ToString());
                CashTextBox.AppendText(cash + ".00");
            }
            con.Close();
            GetHistory();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
