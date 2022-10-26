namespace Mad4Road
{
    partial class Mad4RoadForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mad4RoadForm));
            this.StartMenuPanel = new System.Windows.Forms.Panel();
            this.PasswordAttemptSubmitButton = new System.Windows.Forms.Button();
            this.WarningPasswordMessage = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabelMessage = new System.Windows.Forms.Label();
            this.GroupBoxLength = new System.Windows.Forms.GroupBox();
            this.SevenYearsRadioButton = new System.Windows.Forms.RadioButton();
            this.FiveYearsRadioButton = new System.Windows.Forms.RadioButton();
            this.ThreeYearRadioButton = new System.Windows.Forms.RadioButton();
            this.OneYearRadioButton = new System.Windows.Forms.RadioButton();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.SummaryButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ProceedButton = new System.Windows.Forms.Button();
            this.DisplayButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.PricePictureBox = new System.Windows.Forms.PictureBox();
            this.LoanAmountGroupBox = new System.Windows.Forms.GroupBox();
            this.TextBoxLoan = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.DisplayGroupBox = new System.Windows.Forms.GroupBox();
            this.TotalLoanCostTextBox = new System.Windows.Forms.TextBox();
            this.TotalInterestTextBox = new System.Windows.Forms.TextBox();
            this.MonthlyRepaymentTextBox = new System.Windows.Forms.TextBox();
            this.InterestRateTextBox = new System.Windows.Forms.TextBox();
            this.TotalLoanCostDisplay = new System.Windows.Forms.Label();
            this.TotalInterestPaidDisplay = new System.Windows.Forms.Label();
            this.MonthlyRepaymentLabel = new System.Windows.Forms.Label();
            this.InterestLabelDisplay = new System.Windows.Forms.Label();
            this.ProceedGroupBox = new System.Windows.Forms.GroupBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.TelephoneTextBox = new System.Windows.Forms.TextBox();
            this.PostcodeTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.TelephoneLabel = new System.Windows.Forms.Label();
            this.PostcodeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.StartMenuPanel.SuspendLayout();
            this.GroupBoxLength.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PricePictureBox)).BeginInit();
            this.LoanAmountGroupBox.SuspendLayout();
            this.DisplayGroupBox.SuspendLayout();
            this.ProceedGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartMenuPanel
            // 
            this.StartMenuPanel.BackColor = System.Drawing.SystemColors.Window;
            this.StartMenuPanel.Controls.Add(this.PasswordAttemptSubmitButton);
            this.StartMenuPanel.Controls.Add(this.WarningPasswordMessage);
            this.StartMenuPanel.Controls.Add(this.PasswordTextBox);
            this.StartMenuPanel.Controls.Add(this.PasswordLabelMessage);
            this.StartMenuPanel.Location = new System.Drawing.Point(164, 75);
            this.StartMenuPanel.Name = "StartMenuPanel";
            this.StartMenuPanel.Size = new System.Drawing.Size(838, 150);
            this.StartMenuPanel.TabIndex = 0;
            // 
            // PasswordAttemptSubmitButton
            // 
            this.PasswordAttemptSubmitButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.PasswordAttemptSubmitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PasswordAttemptSubmitButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PasswordAttemptSubmitButton.Location = new System.Drawing.Point(608, 58);
            this.PasswordAttemptSubmitButton.Name = "PasswordAttemptSubmitButton";
            this.PasswordAttemptSubmitButton.Size = new System.Drawing.Size(112, 34);
            this.PasswordAttemptSubmitButton.TabIndex = 3;
            this.PasswordAttemptSubmitButton.Text = "&Submit";
            this.PasswordAttemptSubmitButton.UseVisualStyleBackColor = false;
            this.PasswordAttemptSubmitButton.Click += new System.EventHandler(this.PasswordAttemptSubmitButton_Click);
            // 
            // WarningPasswordMessage
            // 
            this.WarningPasswordMessage.AutoSize = true;
            this.WarningPasswordMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.WarningPasswordMessage.Location = new System.Drawing.Point(177, 106);
            this.WarningPasswordMessage.Name = "WarningPasswordMessage";
            this.WarningPasswordMessage.Size = new System.Drawing.Size(484, 25);
            this.WarningPasswordMessage.TabIndex = 2;
            this.WarningPasswordMessage.Text = "System will shut down after 2nd incorrect password attempt.";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordTextBox.Location = new System.Drawing.Point(377, 58);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(207, 34);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PasswordLabelMessage
            // 
            this.PasswordLabelMessage.AutoSize = true;
            this.PasswordLabelMessage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PasswordLabelMessage.Location = new System.Drawing.Point(32, 57);
            this.PasswordLabelMessage.Name = "PasswordLabelMessage";
            this.PasswordLabelMessage.Size = new System.Drawing.Size(302, 28);
            this.PasswordLabelMessage.TabIndex = 0;
            this.PasswordLabelMessage.Text = "Please Enter System Password:";
            // 
            // GroupBoxLength
            // 
            this.GroupBoxLength.BackColor = System.Drawing.SystemColors.Window;
            this.GroupBoxLength.Controls.Add(this.SevenYearsRadioButton);
            this.GroupBoxLength.Controls.Add(this.FiveYearsRadioButton);
            this.GroupBoxLength.Controls.Add(this.ThreeYearRadioButton);
            this.GroupBoxLength.Controls.Add(this.OneYearRadioButton);
            this.GroupBoxLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GroupBoxLength.Location = new System.Drawing.Point(403, 231);
            this.GroupBoxLength.Name = "GroupBoxLength";
            this.GroupBoxLength.Size = new System.Drawing.Size(265, 527);
            this.GroupBoxLength.TabIndex = 4;
            this.GroupBoxLength.TabStop = false;
            this.GroupBoxLength.Text = "Requested Loan Length";
            this.GroupBoxLength.Visible = false;
            // 
            // SevenYearsRadioButton
            // 
            this.SevenYearsRadioButton.AutoSize = true;
            this.SevenYearsRadioButton.Location = new System.Drawing.Point(90, 215);
            this.SevenYearsRadioButton.Name = "SevenYearsRadioButton";
            this.SevenYearsRadioButton.Size = new System.Drawing.Size(104, 32);
            this.SevenYearsRadioButton.TabIndex = 3;
            this.SevenYearsRadioButton.Text = "7 Years";
            this.SevenYearsRadioButton.UseVisualStyleBackColor = true;
            // 
            // FiveYearsRadioButton
            // 
            this.FiveYearsRadioButton.AutoSize = true;
            this.FiveYearsRadioButton.Location = new System.Drawing.Point(90, 160);
            this.FiveYearsRadioButton.Name = "FiveYearsRadioButton";
            this.FiveYearsRadioButton.Size = new System.Drawing.Size(104, 32);
            this.FiveYearsRadioButton.TabIndex = 2;
            this.FiveYearsRadioButton.Text = "5 Years";
            this.FiveYearsRadioButton.UseVisualStyleBackColor = true;
            // 
            // ThreeYearRadioButton
            // 
            this.ThreeYearRadioButton.AutoSize = true;
            this.ThreeYearRadioButton.Location = new System.Drawing.Point(90, 105);
            this.ThreeYearRadioButton.Name = "ThreeYearRadioButton";
            this.ThreeYearRadioButton.Size = new System.Drawing.Size(104, 32);
            this.ThreeYearRadioButton.TabIndex = 1;
            this.ThreeYearRadioButton.Text = "3 Years";
            this.ThreeYearRadioButton.UseVisualStyleBackColor = true;
            // 
            // OneYearRadioButton
            // 
            this.OneYearRadioButton.AutoSize = true;
            this.OneYearRadioButton.Checked = true;
            this.OneYearRadioButton.Location = new System.Drawing.Point(90, 50);
            this.OneYearRadioButton.Name = "OneYearRadioButton";
            this.OneYearRadioButton.Size = new System.Drawing.Size(95, 32);
            this.OneYearRadioButton.TabIndex = 0;
            this.OneYearRadioButton.TabStop = true;
            this.OneYearRadioButton.Text = "1 Year";
            this.OneYearRadioButton.UseVisualStyleBackColor = true;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ButtonPanel.Controls.Add(this.SummaryButton);
            this.ButtonPanel.Controls.Add(this.ExitButton);
            this.ButtonPanel.Controls.Add(this.ClearButton);
            this.ButtonPanel.Controls.Add(this.ProceedButton);
            this.ButtonPanel.Controls.Add(this.DisplayButton);
            this.ButtonPanel.Location = new System.Drawing.Point(1210, 28);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(243, 468);
            this.ButtonPanel.TabIndex = 2;
            this.ButtonPanel.Visible = false;
            // 
            // SummaryButton
            // 
            this.SummaryButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SummaryButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SummaryButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SummaryButton.Location = new System.Drawing.Point(78, 172);
            this.SummaryButton.Name = "SummaryButton";
            this.SummaryButton.Size = new System.Drawing.Size(112, 34);
            this.SummaryButton.TabIndex = 5;
            this.SummaryButton.Text = "&Summary";
            this.SummaryButton.UseVisualStyleBackColor = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ExitButton.Location = new System.Drawing.Point(78, 308);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(112, 34);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "&Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClearButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ClearButton.Location = new System.Drawing.Point(78, 240);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(112, 34);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ProceedButton
            // 
            this.ProceedButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ProceedButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProceedButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ProceedButton.Location = new System.Drawing.Point(78, 104);
            this.ProceedButton.Name = "ProceedButton";
            this.ProceedButton.Size = new System.Drawing.Size(112, 34);
            this.ProceedButton.TabIndex = 1;
            this.ProceedButton.Text = "&Proceed";
            this.ProceedButton.UseVisualStyleBackColor = false;
            this.ProceedButton.Click += new System.EventHandler(this.ProceedButton_Click);
            // 
            // DisplayButton
            // 
            this.DisplayButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.DisplayButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DisplayButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisplayButton.Location = new System.Drawing.Point(78, 36);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(112, 34);
            this.DisplayButton.TabIndex = 0;
            this.DisplayButton.Text = "&Display";
            this.DisplayButton.UseVisualStyleBackColor = false;
            this.DisplayButton.Click += new System.EventHandler(this.DisplayButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubmitButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SubmitButton.Location = new System.Drawing.Point(197, 255);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(112, 34);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PricePictureBox
            // 
            this.PricePictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.PricePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("PricePictureBox.Image")));
            this.PricePictureBox.Location = new System.Drawing.Point(26, 28);
            this.PricePictureBox.Name = "PricePictureBox";
            this.PricePictureBox.Size = new System.Drawing.Size(357, 730);
            this.PricePictureBox.TabIndex = 3;
            this.PricePictureBox.TabStop = false;
            this.PricePictureBox.Visible = false;
            // 
            // LoanAmountGroupBox
            // 
            this.LoanAmountGroupBox.BackColor = System.Drawing.SystemColors.Window;
            this.LoanAmountGroupBox.Controls.Add(this.TextBoxLoan);
            this.LoanAmountGroupBox.Controls.Add(this.AmountLabel);
            this.LoanAmountGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoanAmountGroupBox.Location = new System.Drawing.Point(403, 28);
            this.LoanAmountGroupBox.Name = "LoanAmountGroupBox";
            this.LoanAmountGroupBox.Size = new System.Drawing.Size(445, 150);
            this.LoanAmountGroupBox.TabIndex = 4;
            this.LoanAmountGroupBox.TabStop = false;
            this.LoanAmountGroupBox.Text = "Requested Loan Amount";
            this.LoanAmountGroupBox.Visible = false;
            // 
            // TextBoxLoan
            // 
            this.TextBoxLoan.Location = new System.Drawing.Point(241, 71);
            this.TextBoxLoan.Name = "TextBoxLoan";
            this.TextBoxLoan.Size = new System.Drawing.Size(169, 34);
            this.TextBoxLoan.TabIndex = 1;
            this.TextBoxLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(6, 74);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(220, 28);
            this.AmountLabel.TabIndex = 0;
            this.AmountLabel.Text = "Loan Total Requested:";
            // 
            // DisplayGroupBox
            // 
            this.DisplayGroupBox.BackColor = System.Drawing.SystemColors.Window;
            this.DisplayGroupBox.Controls.Add(this.TotalLoanCostTextBox);
            this.DisplayGroupBox.Controls.Add(this.TotalInterestTextBox);
            this.DisplayGroupBox.Controls.Add(this.MonthlyRepaymentTextBox);
            this.DisplayGroupBox.Controls.Add(this.InterestRateTextBox);
            this.DisplayGroupBox.Controls.Add(this.TotalLoanCostDisplay);
            this.DisplayGroupBox.Controls.Add(this.TotalInterestPaidDisplay);
            this.DisplayGroupBox.Controls.Add(this.MonthlyRepaymentLabel);
            this.DisplayGroupBox.Controls.Add(this.InterestLabelDisplay);
            this.DisplayGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DisplayGroupBox.Location = new System.Drawing.Point(689, 231);
            this.DisplayGroupBox.Name = "DisplayGroupBox";
            this.DisplayGroupBox.Size = new System.Drawing.Size(515, 256);
            this.DisplayGroupBox.TabIndex = 5;
            this.DisplayGroupBox.TabStop = false;
            this.DisplayGroupBox.Text = "Car Loan Details";
            this.DisplayGroupBox.Visible = false;
            // 
            // TotalLoanCostTextBox
            // 
            this.TotalLoanCostTextBox.Location = new System.Drawing.Point(291, 192);
            this.TotalLoanCostTextBox.Name = "TotalLoanCostTextBox";
            this.TotalLoanCostTextBox.Size = new System.Drawing.Size(187, 34);
            this.TotalLoanCostTextBox.TabIndex = 7;
            this.TotalLoanCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TotalInterestTextBox
            // 
            this.TotalInterestTextBox.Location = new System.Drawing.Point(291, 143);
            this.TotalInterestTextBox.Name = "TotalInterestTextBox";
            this.TotalInterestTextBox.Size = new System.Drawing.Size(187, 34);
            this.TotalInterestTextBox.TabIndex = 6;
            this.TotalInterestTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MonthlyRepaymentTextBox
            // 
            this.MonthlyRepaymentTextBox.Location = new System.Drawing.Point(291, 94);
            this.MonthlyRepaymentTextBox.Name = "MonthlyRepaymentTextBox";
            this.MonthlyRepaymentTextBox.Size = new System.Drawing.Size(187, 34);
            this.MonthlyRepaymentTextBox.TabIndex = 5;
            this.MonthlyRepaymentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InterestRateTextBox
            // 
            this.InterestRateTextBox.Location = new System.Drawing.Point(291, 45);
            this.InterestRateTextBox.Name = "InterestRateTextBox";
            this.InterestRateTextBox.Size = new System.Drawing.Size(187, 34);
            this.InterestRateTextBox.TabIndex = 4;
            this.InterestRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TotalLoanCostDisplay
            // 
            this.TotalLoanCostDisplay.AutoSize = true;
            this.TotalLoanCostDisplay.Location = new System.Drawing.Point(35, 195);
            this.TotalLoanCostDisplay.Name = "TotalLoanCostDisplay";
            this.TotalLoanCostDisplay.Size = new System.Drawing.Size(162, 28);
            this.TotalLoanCostDisplay.TabIndex = 3;
            this.TotalLoanCostDisplay.Text = "Total Loan Cost:";
            // 
            // TotalInterestPaidDisplay
            // 
            this.TotalInterestPaidDisplay.AutoSize = true;
            this.TotalInterestPaidDisplay.Location = new System.Drawing.Point(35, 145);
            this.TotalInterestPaidDisplay.Name = "TotalInterestPaidDisplay";
            this.TotalInterestPaidDisplay.Size = new System.Drawing.Size(190, 28);
            this.TotalInterestPaidDisplay.TabIndex = 2;
            this.TotalInterestPaidDisplay.Text = "Total Interest Paid:";
            // 
            // MonthlyRepaymentLabel
            // 
            this.MonthlyRepaymentLabel.AutoSize = true;
            this.MonthlyRepaymentLabel.Location = new System.Drawing.Point(35, 95);
            this.MonthlyRepaymentLabel.Name = "MonthlyRepaymentLabel";
            this.MonthlyRepaymentLabel.Size = new System.Drawing.Size(210, 28);
            this.MonthlyRepaymentLabel.TabIndex = 1;
            this.MonthlyRepaymentLabel.Text = "Monthly Repayment:";
            // 
            // InterestLabelDisplay
            // 
            this.InterestLabelDisplay.AutoSize = true;
            this.InterestLabelDisplay.Location = new System.Drawing.Point(33, 45);
            this.InterestLabelDisplay.Name = "InterestLabelDisplay";
            this.InterestLabelDisplay.Size = new System.Drawing.Size(218, 28);
            this.InterestLabelDisplay.TabIndex = 0;
            this.InterestLabelDisplay.Text = "Interest Rate Applied:";
            // 
            // ProceedGroupBox
            // 
            this.ProceedGroupBox.BackColor = System.Drawing.SystemColors.Window;
            this.ProceedGroupBox.Controls.Add(this.IDTextBox);
            this.ProceedGroupBox.Controls.Add(this.EmailTextBox);
            this.ProceedGroupBox.Controls.Add(this.SubmitButton);
            this.ProceedGroupBox.Controls.Add(this.TelephoneTextBox);
            this.ProceedGroupBox.Controls.Add(this.PostcodeTextBox);
            this.ProceedGroupBox.Controls.Add(this.NameTextBox);
            this.ProceedGroupBox.Controls.Add(this.IDLabel);
            this.ProceedGroupBox.Controls.Add(this.EmailLabel);
            this.ProceedGroupBox.Controls.Add(this.TelephoneLabel);
            this.ProceedGroupBox.Controls.Add(this.PostcodeLabel);
            this.ProceedGroupBox.Controls.Add(this.NameLabel);
            this.ProceedGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProceedGroupBox.Location = new System.Drawing.Point(689, 493);
            this.ProceedGroupBox.Name = "ProceedGroupBox";
            this.ProceedGroupBox.Size = new System.Drawing.Size(515, 315);
            this.ProceedGroupBox.TabIndex = 6;
            this.ProceedGroupBox.TabStop = false;
            this.ProceedGroupBox.Text = "Client Details";
            this.ProceedGroupBox.Visible = false;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Enabled = false;
            this.IDTextBox.Location = new System.Drawing.Point(197, 198);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(204, 34);
            this.IDTextBox.TabIndex = 9;
            this.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(197, 157);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(204, 34);
            this.EmailTextBox.TabIndex = 8;
            this.EmailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TelephoneTextBox
            // 
            this.TelephoneTextBox.Location = new System.Drawing.Point(197, 116);
            this.TelephoneTextBox.Name = "TelephoneTextBox";
            this.TelephoneTextBox.Size = new System.Drawing.Size(204, 34);
            this.TelephoneTextBox.TabIndex = 7;
            this.TelephoneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PostcodeTextBox
            // 
            this.PostcodeTextBox.Location = new System.Drawing.Point(197, 76);
            this.PostcodeTextBox.Name = "PostcodeTextBox";
            this.PostcodeTextBox.Size = new System.Drawing.Size(204, 34);
            this.PostcodeTextBox.TabIndex = 6;
            this.PostcodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(197, 36);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(204, 34);
            this.NameTextBox.TabIndex = 5;
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(37, 201);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(111, 28);
            this.IDLabel.TabIndex = 4;
            this.IDLabel.Text = "Unique ID:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(37, 160);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(69, 28);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email:";
            // 
            // TelephoneLabel
            // 
            this.TelephoneLabel.AutoSize = true;
            this.TelephoneLabel.Location = new System.Drawing.Point(35, 119);
            this.TelephoneLabel.Name = "TelephoneLabel";
            this.TelephoneLabel.Size = new System.Drawing.Size(114, 28);
            this.TelephoneLabel.TabIndex = 2;
            this.TelephoneLabel.Text = "Telephone:";
            // 
            // PostcodeLabel
            // 
            this.PostcodeLabel.AutoSize = true;
            this.PostcodeLabel.Location = new System.Drawing.Point(37, 79);
            this.PostcodeLabel.Name = "PostcodeLabel";
            this.PostcodeLabel.Size = new System.Drawing.Size(102, 28);
            this.PostcodeLabel.TabIndex = 1;
            this.PostcodeLabel.Text = "Postcode:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(35, 39);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(73, 28);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // Mad4RoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 1050);
            this.Controls.Add(this.ProceedGroupBox);
            this.Controls.Add(this.DisplayGroupBox);
            this.Controls.Add(this.LoanAmountGroupBox);
            this.Controls.Add(this.GroupBoxLength);
            this.Controls.Add(this.PricePictureBox);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.StartMenuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mad4RoadForm";
            this.Text = "Mad4Road Ltd.";
            this.StartMenuPanel.ResumeLayout(false);
            this.StartMenuPanel.PerformLayout();
            this.GroupBoxLength.ResumeLayout(false);
            this.GroupBoxLength.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PricePictureBox)).EndInit();
            this.LoanAmountGroupBox.ResumeLayout(false);
            this.LoanAmountGroupBox.PerformLayout();
            this.DisplayGroupBox.ResumeLayout(false);
            this.DisplayGroupBox.PerformLayout();
            this.ProceedGroupBox.ResumeLayout(false);
            this.ProceedGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel StartMenuPanel;
        private TextBox PasswordTextBox;
        private Label PasswordLabelMessage;
        private Label WarningPasswordMessage;
        private Button PasswordAttemptSubmitButton;
        private Panel ButtonPanel;
        private Button DisplayButton;
        private Button ProceedButton;
        private Button SubmitButton;
        private Button ClearButton;
        private Button ExitButton;
        private PictureBox PricePictureBox;
        private GroupBox GroupBoxLength;
        private RadioButton SevenYearsRadioButton;
        private RadioButton FiveYearsRadioButton;
        private RadioButton ThreeYearRadioButton;
        private RadioButton OneYearRadioButton;
        private GroupBox LoanAmountGroupBox;
        private Label AmountLabel;
        private TextBox TextBoxLoan;
        private GroupBox DisplayGroupBox;
        private Label InterestLabelDisplay;
        private Label MonthlyRepaymentLabel;
        private Label TotalInterestPaidDisplay;
        private TextBox TotalLoanCostTextBox;
        private TextBox TotalInterestTextBox;
        private TextBox MonthlyRepaymentTextBox;
        private TextBox InterestRateTextBox;
        private Label TotalLoanCostDisplay;
        private GroupBox ProceedGroupBox;
        private Label NameLabel;
        private Label PostcodeLabel;
        private Label TelephoneLabel;
        private Label EmailLabel;
        private Label IDLabel;
        private TextBox IDTextBox;
        private TextBox EmailTextBox;
        private TextBox TelephoneTextBox;
        private TextBox PostcodeTextBox;
        private TextBox NameTextBox;
        private Button SummaryButton;
    }
}