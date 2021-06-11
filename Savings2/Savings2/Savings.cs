using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            //Get Last Updated Date
            GetLastUpdated();
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
                amount = Convert.ToInt32(amtTextBox.Text);
                if (depositCheckBox.Checked == true && CashCheckbox.Checked == true)
                {
                    depositCheckBox.Checked = true;
                    withdrawlCheckBox.Checked = false;
                    finalBalance = newBalance + amount;
                    cashBalance = cashBalance + amount;
                    cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "', Cash = '" + cashBalance + "'", con);
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
                        finalBalance = newBalance + amount;
                        bankBalance = bankBalance + amount;
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
                            finalBalance = newBalance - amount;
                            cashBalance = cashBalance - amount;
                            cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + finalBalance + "', Cash = '" + cashBalance + "'", con);
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
                                finalBalance = newBalance - amount;
                                bankBalance = bankBalance - amount;
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
            //Clears the boxes to ensure a clean experience
            ClearBoxes();
            //Gets the last time the balance was updated
            GetLastUpdated();
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

        private void GetLastUpdated()
        {
            string SQL = "SELECT TOP 1 CONVERT(varchar, ExecutionTime, 1) AS LastUpdated FROM SavingsEventLog ORDER BY ExecutionTime DESC";
            cmd = new SqlCommand(SQL, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string lastUpdated = (dr["LastUpdated"].ToString());
                LastUpdated.AppendText(lastUpdated);
            }
            con.Close();
        }

        public void RecordEvent()
        {
            con.Open();
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
            AdminTextBox.Text = "";
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
            double convertBefore = Convert.ToDouble(beforeAmount);
            int before = (int)convertBefore;
            MessageBox.Show(message, title);

            //Getting the amount inputs
            string amountInput = AdminTextBox.Text;
            int amount = Convert.ToInt32(amountInput);
            amountInput = amountInput + ".00";
            int cash = Convert.ToInt32(AdminCash.Text);
            int bank = Convert.ToInt32(AdminBank.Text);
            int difference;

            if (before < amount)
            {
                difference = amount - before;
            }
            else
            {
                difference = before - amount;
            }

            //Update balance and insert into EventLog
            con.Open();
            cmd = new SqlCommand("UPDATE SavingsAcct set Balance='" + amount + "', Bank = '" + bank + "', Cash = '" + cash + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("INSERT INTO SavingsEventLog VALUES('" + before + "', 'A', '" + difference +  "', '" + amountInput + "', '" + DateTime.Now + "', 'Admin Entry', '0')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            LoadValues();
            AdminTextBox.Clear();
            AdminBank.Clear();
            AdminCash.Clear();
            GetHistory();
            GetLastUpdated();
        }

        private void ClearBoxes()
        {
            memoTextBox.Clear();
            amtTextBox.Text = "";
            AdminTextBox.Text = "";
            LastUpdated.Text = "";
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
            /**Method to:
             * Set the Deposit Checkbox to True
             * Clear all of the checkboxes
             * Load initial values again
            **/
            depositCheckBox.Checked = true;
            ClearBoxes();
            LoadValues();
            GetLastUpdated();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminEnterButton2_Click(object sender, EventArgs e)
        {
            string date = DateTextBox.Text.Trim();
            string SQL;
            string firstTotalInput = "";
            string secondTotalInput = "";

            SQL = "SELECT TOP 1 NewBalance FROM SavingsEventLog WHERE ExecutionTime <= '" + date + "' ORDER BY ExecutionTime DESC";
            cmd = new SqlCommand(SQL, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                firstTotalInput = (dr["NewBalance"].ToString());
            }
            con.Close();

            SQL = "SELECT TOP 1 NewBalance FROM SavingsEventLog WHERE ExecutionTime > '" + date + "' ORDER BY ExecutionTime DESC";
            cmd = new SqlCommand(SQL, con);
            con.Open();
            SqlDataReader dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                secondTotalInput = (dr2["NewBalance"].ToString());
            }
            con.Close();


            double firstTotal = Convert.ToDouble(firstTotalInput);
            double secondTotal = Convert.ToDouble(secondTotalInput);
            double total = secondTotal - firstTotal;

            TotalTextBox.Text = total.ToString();
        }

    }
}
