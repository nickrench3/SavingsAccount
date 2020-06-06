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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.memoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.enterButton = new System.Windows.Forms.Button();
            this.newBalTextBox = new System.Windows.Forms.TextBox();
            this.amtTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.withdrawlCheckBox = new System.Windows.Forms.CheckBox();
            this.depositCheckBox = new System.Windows.Forms.CheckBox();
            this.currBalTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.adminEnterButton = new System.Windows.Forms.Button();
            this.adminTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.HistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.memoTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.clearButton);
            this.tabPage1.Controls.Add(this.enterButton);
            this.tabPage1.Controls.Add(this.newBalTextBox);
            this.tabPage1.Controls.Add(this.amtTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.withdrawlCheckBox);
            this.tabPage1.Controls.Add(this.depositCheckBox);
            this.tabPage1.Controls.Add(this.currBalTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(482, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Account Manager";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(272, 248);
            this.memoTextBox.MaxLength = 200;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(168, 22);
            this.memoTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Memo";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(92, 298);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 33);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(260, 298);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(129, 33);
            this.enterButton.TabIndex = 10;
            this.enterButton.Text = "ENTER";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // newBalTextBox
            // 
            this.newBalTextBox.Enabled = false;
            this.newBalTextBox.Location = new System.Drawing.Point(273, 363);
            this.newBalTextBox.Name = "newBalTextBox";
            this.newBalTextBox.Size = new System.Drawing.Size(168, 22);
            this.newBalTextBox.TabIndex = 13;
            this.newBalTextBox.TabStop = false;
            // 
            // amtTextBox
            // 
            this.amtTextBox.Location = new System.Drawing.Point(272, 213);
            this.amtTextBox.MaxLength = 6;
            this.amtTextBox.Name = "amtTextBox";
            this.amtTextBox.Size = new System.Drawing.Size(168, 22);
            this.amtTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "New Account Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Amount";
            // 
            // withdrawlCheckBox
            // 
            this.withdrawlCheckBox.AutoSize = true;
            this.withdrawlCheckBox.Location = new System.Drawing.Point(90, 151);
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
            this.depositCheckBox.Location = new System.Drawing.Point(90, 111);
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
            this.currBalTextBox.Location = new System.Drawing.Point(272, 38);
            this.currBalTextBox.Name = "currBalTextBox";
            this.currBalTextBox.Size = new System.Drawing.Size(168, 22);
            this.currBalTextBox.TabIndex = 2;
            this.currBalTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Account Balance";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.adminEnterButton);
            this.tabPage2.Controls.Add(this.adminTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(482, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin Portal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // adminEnterButton
            // 
            this.adminEnterButton.Location = new System.Drawing.Point(156, 159);
            this.adminEnterButton.Name = "adminEnterButton";
            this.adminEnterButton.Size = new System.Drawing.Size(176, 42);
            this.adminEnterButton.TabIndex = 5;
            this.adminEnterButton.Text = "ENTER";
            this.adminEnterButton.UseVisualStyleBackColor = true;
            this.adminEnterButton.Click += new System.EventHandler(this.AdminEnterButton_Click);
            // 
            // adminTextBox
            // 
            this.adminTextBox.Location = new System.Drawing.Point(292, 70);
            this.adminTextBox.Name = "adminTextBox";
            this.adminTextBox.Size = new System.Drawing.Size(135, 22);
            this.adminTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 70);
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
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(482, 424);
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
            this.HistoryDataGridView.Size = new System.Drawing.Size(482, 424);
            this.HistoryDataGridView.TabIndex = 0;
            // 
            // Savings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 450);
            this.Controls.Add(this.tabControl1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.TextBox newBalTextBox;
        private System.Windows.Forms.TextBox amtTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox withdrawlCheckBox;
        private System.Windows.Forms.CheckBox depositCheckBox;
        private System.Windows.Forms.TextBox currBalTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button adminEnterButton;
        private System.Windows.Forms.TextBox adminTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView HistoryDataGridView;
    }
}