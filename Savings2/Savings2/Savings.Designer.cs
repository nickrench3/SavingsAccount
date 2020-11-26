namespace Savings2
{
    partial class Savings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Savings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CashCheckbox = new System.Windows.Forms.CheckBox();
            this.CashTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BankTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.memoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.amtTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.withdrawlCheckBox = new System.Windows.Forms.CheckBox();
            this.depositCheckBox = new System.Windows.Forms.CheckBox();
            this.currBalTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AdminBank = new System.Windows.Forms.TextBox();
            this.AdminCash = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.adminEnterButton = new System.Windows.Forms.Button();
            this.AdminTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.HistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 446);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CashCheckbox);
            this.tabPage1.Controls.Add(this.CashTextBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.BankTextBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.memoTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.clearButton);
            this.tabPage1.Controls.Add(this.enterButton);
            this.tabPage1.Controls.Add(this.amtTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.withdrawlCheckBox);
            this.tabPage1.Controls.Add(this.depositCheckBox);
            this.tabPage1.Controls.Add(this.currBalTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(678, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Account Manager";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CashCheckbox
            // 
            this.CashCheckbox.AutoSize = true;
            this.CashCheckbox.Location = new System.Drawing.Point(359, 261);
            this.CashCheckbox.Name = "CashCheckbox";
            this.CashCheckbox.Size = new System.Drawing.Size(58, 20);
            this.CashCheckbox.TabIndex = 19;
            this.CashCheckbox.Text = "Cash";
            this.CashCheckbox.UseVisualStyleBackColor = true;
            // 
            // CashTextBox
            // 
            this.CashTextBox.Enabled = false;
            this.CashTextBox.Location = new System.Drawing.Point(303, 89);
            this.CashTextBox.Name = "CashTextBox";
            this.CashTextBox.Size = new System.Drawing.Size(168, 22);
            this.CashTextBox.TabIndex = 18;
            this.CashTextBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Cash";
            // 
            // BankTextBox
            // 
            this.BankTextBox.Enabled = false;
            this.BankTextBox.Location = new System.Drawing.Point(304, 56);
            this.BankTextBox.Name = "BankTextBox";
            this.BankTextBox.Size = new System.Drawing.Size(168, 22);
            this.BankTextBox.TabIndex = 16;
            this.BankTextBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Bank";
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(303, 289);
            this.memoTextBox.MaxLength = 200;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(168, 22);
            this.memoTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Memo";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(115, 330);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 33);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(288, 330);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(129, 33);
            this.enterButton.TabIndex = 10;
            this.enterButton.Text = "ENTER";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // amtTextBox
            // 
            this.amtTextBox.Location = new System.Drawing.Point(303, 233);
            this.amtTextBox.MaxLength = 6;
            this.amtTextBox.Name = "amtTextBox";
            this.amtTextBox.Size = new System.Drawing.Size(168, 22);
            this.amtTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Amount";
            // 
            // withdrawlCheckBox
            // 
            this.withdrawlCheckBox.AutoSize = true;
            this.withdrawlCheckBox.Location = new System.Drawing.Point(115, 193);
            this.withdrawlCheckBox.Name = "withdrawlCheckBox";
            this.withdrawlCheckBox.Size = new System.Drawing.Size(85, 20);
            this.withdrawlCheckBox.TabIndex = 4;
            this.withdrawlCheckBox.Text = "Withdrawl";
            this.withdrawlCheckBox.UseVisualStyleBackColor = true;
            this.withdrawlCheckBox.CheckedChanged += new System.EventHandler(this.withdrawlCheckBox_CheckedChanged);
            // 
            // depositCheckBox
            // 
            this.depositCheckBox.AutoSize = true;
            this.depositCheckBox.Location = new System.Drawing.Point(115, 153);
            this.depositCheckBox.Name = "depositCheckBox";
            this.depositCheckBox.Size = new System.Drawing.Size(74, 20);
            this.depositCheckBox.TabIndex = 3;
            this.depositCheckBox.Text = "Deposit";
            this.depositCheckBox.UseVisualStyleBackColor = true;
            this.depositCheckBox.CheckedChanged += new System.EventHandler(this.depositCheckBox_CheckedChanged);
            // 
            // currBalTextBox
            // 
            this.currBalTextBox.Enabled = false;
            this.currBalTextBox.Location = new System.Drawing.Point(304, 22);
            this.currBalTextBox.Name = "currBalTextBox";
            this.currBalTextBox.Size = new System.Drawing.Size(168, 22);
            this.currBalTextBox.TabIndex = 2;
            this.currBalTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Account Balance";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AdminBank);
            this.tabPage2.Controls.Add(this.AdminCash);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.adminEnterButton);
            this.tabPage2.Controls.Add(this.AdminTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(637, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin Portal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AdminBank
            // 
            this.AdminBank.Location = new System.Drawing.Point(304, 56);
            this.AdminBank.Name = "AdminBank";
            this.AdminBank.Size = new System.Drawing.Size(168, 22);
            this.AdminBank.TabIndex = 1;
            // 
            // AdminCash
            // 
            this.AdminCash.Location = new System.Drawing.Point(304, 89);
            this.AdminCash.Name = "AdminCash";
            this.AdminCash.Size = new System.Drawing.Size(168, 22);
            this.AdminCash.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Bank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cash";
            // 
            // adminEnterButton
            // 
            this.adminEnterButton.Location = new System.Drawing.Point(198, 152);
            this.adminEnterButton.Name = "adminEnterButton";
            this.adminEnterButton.Size = new System.Drawing.Size(176, 42);
            this.adminEnterButton.TabIndex = 3;
            this.adminEnterButton.Text = "ENTER";
            this.adminEnterButton.UseVisualStyleBackColor = true;
            this.adminEnterButton.Click += new System.EventHandler(this.AdminEnterButton_Click);
            // 
            // AdminTextBox
            // 
            this.AdminTextBox.Location = new System.Drawing.Point(304, 22);
            this.AdminTextBox.Name = "AdminTextBox";
            this.AdminTextBox.Size = new System.Drawing.Size(168, 22);
            this.AdminTextBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "If balance is know, enter here";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.HistoryDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(637, 420);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "History";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // HistoryDataGridView
            // 
            this.HistoryDataGridView.AllowUserToAddRows = false;
            this.HistoryDataGridView.AllowUserToDeleteRows = false;
            this.HistoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.HistoryDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.HistoryDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.HistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryDataGridView.Location = new System.Drawing.Point(0, 0);
            this.HistoryDataGridView.Name = "HistoryDataGridView";
            this.HistoryDataGridView.ReadOnly = true;
            this.HistoryDataGridView.RowHeadersWidth = 82;
            this.HistoryDataGridView.Size = new System.Drawing.Size(632, 424);
            this.HistoryDataGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Savings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Savings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.TextBox amtTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox withdrawlCheckBox;
        private System.Windows.Forms.CheckBox depositCheckBox;
        private System.Windows.Forms.TextBox currBalTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button adminEnterButton;
        private System.Windows.Forms.TextBox AdminTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView HistoryDataGridView;
        private System.Windows.Forms.CheckBox CashCheckbox;
        private System.Windows.Forms.TextBox CashTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BankTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AdminBank;
        private System.Windows.Forms.TextBox AdminCash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}