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
            this.Below40GroupBox = new System.Windows.Forms.GroupBox();
            this.InterestBelow40Label = new System.Windows.Forms.Label();
            this.TermBelow40Label = new System.Windows.Forms.Label();
            this.ListBoxBelow40 = new System.Windows.Forms.ListBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ProceedButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBoxLess80 = new System.Windows.Forms.GroupBox();
            this.InterestLabel80Below = new System.Windows.Forms.Label();
            this.TermLabel80Below = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.StartMenuPanel.SuspendLayout();
            this.Below40GroupBox.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.GroupBoxLess80.SuspendLayout();
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
            this.PasswordAttemptSubmitButton.Click += new System.EventHandler(this.PasswordAttemptsubmitButton_Click);
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
            // Below40GroupBox
            // 
            this.Below40GroupBox.BackColor = System.Drawing.SystemColors.Window;
            this.Below40GroupBox.Controls.Add(this.InterestBelow40Label);
            this.Below40GroupBox.Controls.Add(this.TermBelow40Label);
            this.Below40GroupBox.Controls.Add(this.ListBoxBelow40);
            this.Below40GroupBox.Enabled = false;
            this.Below40GroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Below40GroupBox.Location = new System.Drawing.Point(12, 12);
            this.Below40GroupBox.Name = "Below40GroupBox";
            this.Below40GroupBox.Size = new System.Drawing.Size(486, 224);
            this.Below40GroupBox.TabIndex = 1;
            this.Below40GroupBox.TabStop = false;
            this.Below40GroupBox.Text = "Interest Rates Cars Below €40,000";
            this.Below40GroupBox.Visible = false;
            // 
            // InterestBelow40Label
            // 
            this.InterestBelow40Label.AutoSize = true;
            this.InterestBelow40Label.Location = new System.Drawing.Point(206, 59);
            this.InterestBelow40Label.Name = "InterestBelow40Label";
            this.InterestBelow40Label.Size = new System.Drawing.Size(193, 28);
            this.InterestBelow40Label.TabIndex = 2;
            this.InterestBelow40Label.Text = "Interest Rate - APR";
            // 
            // TermBelow40Label
            // 
            this.TermBelow40Label.AutoSize = true;
            this.TermBelow40Label.Location = new System.Drawing.Point(15, 59);
            this.TermBelow40Label.Name = "TermBelow40Label";
            this.TermBelow40Label.Size = new System.Drawing.Size(59, 28);
            this.TermBelow40Label.TabIndex = 1;
            this.TermBelow40Label.Text = "Term";
            // 
            // ListBoxBelow40
            // 
            this.ListBoxBelow40.FormattingEnabled = true;
            this.ListBoxBelow40.ItemHeight = 28;
            this.ListBoxBelow40.Items.AddRange(new object[] {
            "1 Year\t\t6.00%",
            "3 Years\t\t6.50%",
            "5 Years\t\t7.00%",
            "7 Years\t\t7.50%"});
            this.ListBoxBelow40.Location = new System.Drawing.Point(15, 90);
            this.ListBoxBelow40.Name = "ListBoxBelow40";
            this.ListBoxBelow40.Size = new System.Drawing.Size(450, 116);
            this.ListBoxBelow40.TabIndex = 0;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ButtonPanel.Controls.Add(this.button4);
            this.ButtonPanel.Controls.Add(this.button3);
            this.ButtonPanel.Controls.Add(this.button2);
            this.ButtonPanel.Controls.Add(this.ProceedButton);
            this.ButtonPanel.Controls.Add(this.button1);
            this.ButtonPanel.Location = new System.Drawing.Point(866, 255);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(268, 374);
            this.ButtonPanel.TabIndex = 2;
            this.ButtonPanel.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button4.Location = new System.Drawing.Point(78, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "&Exit";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Location = new System.Drawing.Point(78, 240);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "&Clear";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Location = new System.Drawing.Point(78, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = false;
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
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(78, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Display";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // GroupBoxLess80
            // 
            this.GroupBoxLess80.BackColor = System.Drawing.SystemColors.Window;
            this.GroupBoxLess80.Controls.Add(this.InterestLabel80Below);
            this.GroupBoxLess80.Controls.Add(this.TermLabel80Below);
            this.GroupBoxLess80.Controls.Add(this.listBox1);
            this.GroupBoxLess80.Enabled = false;
            this.GroupBoxLess80.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GroupBoxLess80.Location = new System.Drawing.Point(12, 231);
            this.GroupBoxLess80.Name = "GroupBoxLess80";
            this.GroupBoxLess80.Size = new System.Drawing.Size(486, 230);
            this.GroupBoxLess80.TabIndex = 3;
            this.GroupBoxLess80.TabStop = false;
            this.GroupBoxLess80.Text = "Interest Rates Cars Between €40,000 and €80,000";
            this.GroupBoxLess80.Visible = false;
            // 
            // InterestLabel80Below
            // 
            this.InterestLabel80Below.AutoSize = true;
            this.InterestLabel80Below.Location = new System.Drawing.Point(206, 68);
            this.InterestLabel80Below.Name = "InterestLabel80Below";
            this.InterestLabel80Below.Size = new System.Drawing.Size(193, 28);
            this.InterestLabel80Below.TabIndex = 2;
            this.InterestLabel80Below.Text = "Interest Rate - APR";
            // 
            // TermLabel80Below
            // 
            this.TermLabel80Below.AutoSize = true;
            this.TermLabel80Below.Location = new System.Drawing.Point(15, 68);
            this.TermLabel80Below.Name = "TermLabel80Below";
            this.TermLabel80Below.Size = new System.Drawing.Size(59, 28);
            this.TermLabel80Below.TabIndex = 1;
            this.TermLabel80Below.Text = "Term";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 28;
            this.listBox1.Items.AddRange(new object[] {
            "1 Year\t\t8.00%",
            "3 Years\t\t8.50%",
            "5 Years\t\t9.00%",
            "7 Years\t\t9.50%"});
            this.listBox1.Location = new System.Drawing.Point(15, 99);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(450, 116);
            this.listBox1.TabIndex = 0;
            // 
            // Mad4RoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 725);
            this.Controls.Add(this.GroupBoxLess80);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.Below40GroupBox);
            this.Controls.Add(this.StartMenuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mad4RoadForm";
            this.Text = "Mad4Road Ltd.";
            this.StartMenuPanel.ResumeLayout(false);
            this.StartMenuPanel.PerformLayout();
            this.Below40GroupBox.ResumeLayout(false);
            this.Below40GroupBox.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.GroupBoxLess80.ResumeLayout(false);
            this.GroupBoxLess80.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel StartMenuPanel;
        private TextBox PasswordTextBox;
        private Label PasswordLabelMessage;
        private Label WarningPasswordMessage;
        private Button PasswordAttemptSubmitButton;
        private GroupBox Below40GroupBox;
        private Panel ButtonPanel;
        private Button button1;
        private Button ProceedButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label InterestBelow40Label;
        private Label TermBelow40Label;
        private ListBox ListBoxBelow40;
        private GroupBox GroupBoxLess80;
        private ListBox listBox1;
        private Label InterestLabel80Below;
        private Label TermLabel80Below;
    }
}