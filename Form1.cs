// Name - Kian Sweeney
// ID - 22220670
// MS806 Assignment 3
// Your client Mad4Money Bank Corp is a financial services company that offers various financial
// products to its customers. One of these is a car loan product called ‘Mad4Road’, in which a client can
// borrow between €10,000 and €100,000 over terms of up to 7 years. The interest rate offered to each
// client depends on the amount and term of the loan requested. Your company has been commissioned to
// create a well-designed application for employees to process client transactions for this product.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Mad4Road
{
    public partial class Mad4RoadForm : Form
    {
        public Mad4RoadForm()
        {
            InitializeComponent();
        }
        // constants
        // file we will write details to
        private const String DataFile = "ClientLoanDetails.txt";
        // password for system
        const String PASSWORD = "2Fast4U#";
        // apr rates for under 40k
        const decimal APR_1YEAR_UNDER40 = 6.00m;
        const decimal APR_3YEAR_UNDER40 = 6.50m;
        const decimal APR_5YEAR_UNDER40 = 7.00m;
        const decimal APR_7YEAR_UNDER40 = 7.50m;
        // between 40k and 80k apr
        const decimal APR_1YEAR_OVER40 = 8.00m;
        const decimal APR_3YEAR_OVER40 = 8.50m;
        const decimal APR_5YEAR_OVER40 = 9.00m;
        const decimal APR_7YEAR_OVER40 = 9.50m;
        // over 80k less than 100k
        const decimal APR_1YEAR_OVER80 = 8.50m;
        const decimal APR_3YEAR_OVER80 = 8.75m;
        const decimal APR_5YEAR_OVER80 = 9.10m;
        const decimal APR_7YEAR_OVER80 = 9.25m;
        // months in x number years for maths
        const int MONTHYEAR = 12;
        const int MONTHTHREEYEARS = 36;
        const int MONTHFIVEYEARS = 60;
        const int MONTHSEVENYEARS = 84;
        // max attempts for password
        const int MAXATTEMPTS = 2;

        // changeable variables
        private decimal LoanPreTotal, MonthlyRepay, TotalInterestPaid,
            LoanOverallTotal, InterestRateApplied, TermYears;
        // TermYears needs to be decimal for our calculations regarding average loan length
        // in the summary tab
        int PasswordAttempts = 1;

        private void PasswordAttemptSubmitButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text != PASSWORD & PasswordAttempts < MAXATTEMPTS)
            {
                int AttemptsLeft = MAXATTEMPTS - 1;
                MessageBox.Show("Incorrect Password. Please Check Again.\nNumber of attempts left: " + AttemptsLeft.ToString(), 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTextBox.Clear();
                PasswordTextBox.Focus();
                PasswordAttempts += 1;
            }
            else if (PasswordTextBox.Text == PASSWORD & PasswordAttempts < MAXATTEMPTS)
            {
                StartMenuPanel.Visible = false;
                ButtonPanel.Visible = true;
                LogoPictureBox.Visible = true;
                LoanAmountGroupBox.Visible = true;
                this.Text = "Loan Calculator/Approval";
                this.TextBoxLoan.Focus();
                PasswordAttempts += 1;
            }
            else if (PasswordTextBox.Text != PASSWORD & PasswordAttempts >= MAXATTEMPTS)
            {
                MessageBox.Show("Access Denied. No More Password Attempts Remaining.\nClosing the Application", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(TextBoxLoan.Text, out LoanPreTotal) || 10000 <= LoanPreTotal &&
                LoanPreTotal <= 100000)
            {
                // no need to check for greater than equal 10k done already
                if(LoanPreTotal < 40000)
                {
                    decimal TotalInterestPaidYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_UNDER40) - LoanPreTotal;
                    decimal MonthlyRepayYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_UNDER40) / MONTHYEAR;
                    decimal InterestRateAppliedYear1 = APR_1YEAR_UNDER40;
                    decimal LoanOverallTotalYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_UNDER40);
                    // populate textboxes
                    this.InterestRateTextBox.Text = InterestRateAppliedYear1 + "%";
                    this.MonthlyRepaymentTextBox.Text = MonthlyRepayYear1.ToString("C");
                    this.TotalInterestTextBox.Text = TotalInterestPaidYear1.ToString("C");
                    this.TotalLoanCostTextBox.Text = LoanOverallTotalYear1.ToString("C");
                    // 3 year less than40k
                    decimal TotalInterestPaidYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_UNDER40) - LoanPreTotal;
                    decimal MonthlyRepayYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_UNDER40) / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_UNDER40;
                    decimal LoanOverallTotalYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_UNDER40);
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text= LoanOverallTotalYear3.ToString("C");
                    // 5 year less than40k
                    decimal TotalInterestPaidYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_UNDER40) - LoanPreTotal;
                    decimal MonthlyRepayYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_UNDER40) / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_UNDER40;
                    decimal LoanOverallTotalYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_UNDER40);
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year less than40k
                    decimal TotalInterestPaidYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_UNDER40) - LoanPreTotal;
                    decimal MonthlyRepayYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_UNDER40) / MONTHSEVENYEARS;
                    decimal InterestRateAppliedYear7 = APR_7YEAR_UNDER40;
                    decimal LoanOverallTotalYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_UNDER40);
                    // populate textboxes
                    this.AppliedInterest7YearTextBox.Text = InterestRateAppliedYear7 + "%";
                    this.Monthly7YearTextBox.Text = MonthlyRepayYear7.ToString("C");
                    this.Interest7YearTextBox.Text = TotalInterestPaidYear7.ToString("C");
                    this.TotalLoan7YearTextBox.Text = LoanOverallTotalYear7.ToString("C");
                }
                else if(LoanPreTotal < 80000 && LoanPreTotal >= 40000)
                {
                    decimal TotalInterestPaidYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER40) - LoanPreTotal;
                    decimal MonthlyRepayYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER40) / MONTHYEAR;
                    decimal InterestRateAppliedYear1 = APR_1YEAR_OVER40;
                    decimal LoanOverallTotalYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER40);
                    // populate textboxes
                    this.InterestRateTextBox.Text = InterestRateAppliedYear1 + "%";
                    this.MonthlyRepaymentTextBox.Text = MonthlyRepayYear1.ToString("C");
                    this.TotalInterestTextBox.Text = TotalInterestPaidYear1.ToString("C");
                    this.TotalLoanCostTextBox.Text = LoanOverallTotalYear1.ToString("C");
                    // 3 year greater than40k
                    decimal TotalInterestPaidYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER40) - LoanPreTotal;
                    decimal MonthlyRepayYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER40) / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_OVER40;
                    decimal LoanOverallTotalYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER40);
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text = LoanOverallTotalYear3.ToString("C");
                    // 5 year greater than40k
                    decimal TotalInterestPaidYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER40) - LoanPreTotal;
                    decimal MonthlyRepayYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER40) / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_OVER40;
                    decimal LoanOverallTotalYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER40);
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year greater than40k
                    decimal TotalInterestPaidYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER40) - LoanPreTotal;
                    decimal MonthlyRepayYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER40) / MONTHSEVENYEARS;
                    decimal InterestRateAppliedYear7 = APR_7YEAR_OVER40;
                    decimal LoanOverallTotalYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER40);
                    // populate textboxes
                    this.AppliedInterest7YearTextBox.Text = InterestRateAppliedYear7 + "%";
                    this.Monthly7YearTextBox.Text = MonthlyRepayYear7.ToString("C");
                    this.Interest7YearTextBox.Text = TotalInterestPaidYear7.ToString("C");
                    this.TotalLoan7YearTextBox.Text = LoanOverallTotalYear7.ToString("C");
                }
                else
                // again no need to check for greater than equal 100k done already
                {
                    decimal TotalInterestPaidYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER80) - LoanPreTotal;
                    decimal MonthlyRepayYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER80) / MONTHYEAR;
                    decimal InterestRateAppliedYear1 = APR_1YEAR_OVER80;
                    decimal LoanOverallTotalYear1 = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER80);
                    // populate textboxes
                    this.InterestRateTextBox.Text = InterestRateAppliedYear1 + "%";
                    this.MonthlyRepaymentTextBox.Text = MonthlyRepayYear1.ToString("C");
                    this.TotalInterestTextBox.Text = TotalInterestPaidYear1.ToString("C");
                    this.TotalLoanCostTextBox.Text = LoanOverallTotalYear1.ToString("C");
                    // 3 year greater than 80k
                    decimal TotalInterestPaidYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER80) - LoanPreTotal;
                    decimal MonthlyRepayYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER80) / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_OVER80;
                    decimal LoanOverallTotalYear3 = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER80);
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text = LoanOverallTotalYear3.ToString("C");
                    // 5 year greater than 80k
                    decimal TotalInterestPaidYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER80) - LoanPreTotal;
                    decimal MonthlyRepayYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER80) / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_OVER80;
                    decimal LoanOverallTotalYear5 = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER80);
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year greater than 80k
                    decimal TotalInterestPaidYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER80) - LoanPreTotal;
                    decimal MonthlyRepayYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER80) / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear7 = APR_7YEAR_OVER80;
                    decimal LoanOverallTotalYear7 = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER80);
                    // populate textboxes
                    this.AppliedInterest7YearTextBox.Text = InterestRateAppliedYear7 + "%";
                    this.Monthly7YearTextBox.Text = MonthlyRepayYear7.ToString("C");
                    this.Interest7YearTextBox.Text = TotalInterestPaidYear7.ToString("C");
                    this.TotalLoan7YearTextBox.Text = LoanOverallTotalYear7.ToString("C");
                }
                this.DisplayGroupBox.Visible = true;
                GroupBoxLength.Visible = true;
            }
            else
            {
                MessageBox.Show("Please check value for Loan Total." +
    "\nPlease ensure there are no negative numbers inputted." +
    "\nLoan must be between €10,000 and €100,000.",
    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxLoan.Focus();
            }
        }

        //Method 1 - EMI Values
        private decimal CalculateLoanTotal(int Term, decimal Loan, decimal IntRate)
        {
            // EMI calculator
            decimal LoanInterest, MonthlyLoanAmount, MonthlyInt, Exponent = 1;
            int MonthlyTerm;

            MonthlyTerm = Term * MONTHYEAR;

            MonthlyInt = ((IntRate / MONTHYEAR) / 100);

            for (int i = 0; i < MonthlyTerm; i++)
            {
                Exponent = Exponent * (1 + MonthlyInt);
            }

            MonthlyLoanAmount = Loan * ((MonthlyInt * Exponent) / (Exponent - 1));

            LoanInterest = MonthlyLoanAmount * MonthlyTerm;

            return LoanInterest;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // no empty string for name
            if (NameTextBox.Text.Length >= 1)
            {
                // likewise for postcode
                if(PostcodeTextBox.Text.Length >= 1)
                {
                    String PhoneNumber = TelephoneTextBox.Text;
                    // make sure phone number in an actual format
                    // i went with a typical 10 digit number found in Ireland
                    // also checked to make sure characters are numeric only
                    if(PhoneNumber.Length == 10 && IsDigitsOnly(PhoneNumber) == true)
                    {
                        // generic email check, cannot be empty must contain an @
                        // has to also end in .com, this could be extended to further endings if needed (.ie etc)
                        if (EmailTextBox.Text != "" & (EmailTextBox.Text.Contains("@") | EmailTextBox.Text.EndsWith(".com")))
                        {
                            // string details for confirmation message box
                            string Details = "Name of Client:\t\t" + NameTextBox.Text + "\nMembership ID:\t\t" + IDTextBox.Text + "\nTelephone Number:\t" + TelephoneTextBox.Text + 
                                "\nEmail Address:\t\t" + EmailTextBox.Text + "\nPostcode:\t\t" + PostcodeTextBox.Text +  "\nTotal Price:\t\t" +
                                LoanOverallTotal.ToString("C") + "\nInterest to be Paid:\t" + TotalInterestPaid.ToString("C") + "\nNumber Years Loan:\t" + TermYears.ToString() +
                                "\nInterest Rate Applied:\t" + InterestRateApplied.ToString() + "\nMonthy Repayments:\t" + MonthlyRepay.ToString("C");
                            if (MessageBox.Show("Do you wish to Proceed?\n" + Details, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    // write necessary values to file
                                    // 9 in total
                                    StreamWriter InputFile = File.AppendText(DataFile);
                                    InputFile.WriteLine(IDTextBox.Text);
                                    InputFile.WriteLine(EmailTextBox.Text);
                                    InputFile.WriteLine(NameTextBox.Text);
                                    InputFile.WriteLine(TelephoneTextBox.Text);
                                    InputFile.WriteLine(TermYears.ToString());
                                    InputFile.WriteLine(TotalInterestPaid.ToString("0.00"));
                                    InputFile.WriteLine(MonthlyRepay.ToString("0.00"));
                                    InputFile.WriteLine(InterestRateApplied.ToString());
                                    InputFile.WriteLine(LoanOverallTotal.ToString("0.00"));
                                    InputFile.Close();
                                    MessageBox.Show("Details Saved Successfully.\nClient Loan has Been Approved", "Loan Success");
                                    // reset form for next user
                                    ClearButton_Click(sender, e);
                                }
                                catch
                                {
                                    MessageBox.Show("File not found.\nCheck details again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                ClearButton.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Valid Email of the Client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            EmailTextBox.Clear();
                            EmailTextBox.Focus();
                        }
                    }
                    else
                    {
                        TelephoneTextBox.Focus();
                        MessageBox.Show("Invalid/Empty Phone Number Inputted.", "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    PostcodeTextBox.Focus();
                    MessageBox.Show("Invalid/Empty Postcode Inputted.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                NameTextBox.Focus();
                MessageBox.Show("Invalid/Empty Name Inputted.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            // proceed button generates actual values based on loan length
            // this does if statements to populate our global variables
            this.ProceedGroupBox.Visible = true;
            TransactionIDGenerator();
            try
            {
                if (LoanPreTotal < 40000)
                {
                    // make sure radio button clicked
                    if (OneYearRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_UNDER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_UNDER40) / MONTHYEAR;
                        InterestRateApplied = APR_1YEAR_UNDER40;
                        LoanOverallTotal = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_UNDER40);
                        TermYears = 1;
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_UNDER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(3, LoanPreTotal, APR_1YEAR_UNDER40) / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_UNDER40;
                        LoanOverallTotal = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_UNDER40);
                        TermYears = 3;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_UNDER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_UNDER40) / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_UNDER40;
                        LoanOverallTotal = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_UNDER40);
                        TermYears = 5;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_UNDER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_UNDER40) / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_UNDER40;
                        LoanOverallTotal = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_UNDER40);
                        TermYears = 7;
                    }
                }
                else if (LoanPreTotal < 80000 && LoanPreTotal >= 40000)
                {
                    // make sure radio button clicked
                    if (OneYearRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER40) / MONTHYEAR;
                        InterestRateApplied = APR_1YEAR_OVER40;
                        LoanOverallTotal = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER40);
                        TermYears = 1;
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER40) / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_OVER40;
                        LoanOverallTotal = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER40);
                        TermYears = 3;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER40) / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_OVER40;
                        LoanOverallTotal = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER40);
                        TermYears = 5;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER40) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER40) / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_OVER40;
                        LoanOverallTotal = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER40);
                        TermYears = 7;
                    }
                }
                else
                // again no need to check for greater than equal 100k done already
                {
                    if (OneYearRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER80) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER80) / MONTHYEAR;
                        InterestRateApplied = APR_1YEAR_OVER80;
                        LoanOverallTotal = CalculateLoanTotal(1, LoanPreTotal, APR_1YEAR_OVER80);
                        TermYears = 1;
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER80) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER80) / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_OVER80;
                        LoanOverallTotal = CalculateLoanTotal(3, LoanPreTotal, APR_3YEAR_OVER80);
                        TermYears = 3;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER80) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER80) / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_OVER80;
                        LoanOverallTotal = CalculateLoanTotal(5, LoanPreTotal, APR_5YEAR_OVER80);
                        TermYears = 5;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER80) - LoanPreTotal;
                        MonthlyRepay = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER80) / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_OVER80;
                        LoanOverallTotal = CalculateLoanTotal(7, LoanPreTotal, APR_7YEAR_OVER80);
                        TermYears = 7;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid File. Does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // METHOD 2 - returing method
        // we need to count total lines in files to ensure we generate a unique
        // number everytime. requirements mean we cannot use readlines or built-in
        // functions like count so we have to manually count each line.
        private int CalculateFileLines()
        {
            // lines count is variable for iterating through
            // this is set as 1 due to it only being used if file does exist
            int LinesCount = 1, TotalLines;
            try
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                while(OutputFile.ReadLine() != null)
                {
                    LinesCount++;
                }
                TotalLines = LinesCount;
                OutputFile.Close();
            }
            catch
            {
                // assign zero lines to this
                // an error message is unncessary
                TotalLines = 0;
            }
            return TotalLines;
        }

        // method3 - generate ID - non value returning
        private void TransactionIDGenerator()
        {
            int FileLines = CalculateFileLines();
            Random Rand = new Random();
            int rand = Rand.Next(0, 99999);
            if(FileLines >= 1)
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                while(OutputFile.ReadLine() != null)
                {
                    for (int i = 1; i <= FileLines; i++)
                    {
                        if (OutputFile.ReadLine() == rand.ToString("D5"))
                        {
                            // call function again to try generate a new unique number
                            TransactionIDGenerator();
                        }
                        else
                        {
                            // generates random number if not on file
                            this.IDTextBox.Text = rand.ToString("D5");
                        }
                    }
                }
                OutputFile.Close();
            }
            else
            {
                // handle when file is empty to start
                // if we leave an error message our id wont be generated. this addresses this.
                this.IDTextBox.Text = rand.ToString("D5");
            }
        }

        // method 4 - check numbers only in string for telephone number
        private bool IsDigitsOnly(string str)
        {
            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];
                if (c < '0' || c > '9')
                {
                    return false;
                    break;
                }
            }
            return true;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // only to be used if there is input on file
            int ClientLineFiles = CalculateFileLines();
            if(ClientLineFiles >= 1)
            {
                this.SearchGroupBox.Visible = true;
                this.DisplayGroupBox.Visible = false;
                this.ProceedGroupBox.Visible = false;
                this.SummaryGroupBox.Visible = false;
                this.GroupBoxLength.Visible = false;
                this.Text = "Search Previous Transaction";
            }
            else
            {
                MessageBox.Show("No previous transactions.\nPlease ensure there has been data inputted.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchIDButton_Click(object sender, EventArgs e)
        {
            int TotalLinesFile = CalculateFileLines();
            // clear for next search if user wants to check another ID
            SearchListBox.Items.Clear();
            String TransactIDString = this.SearchIDTextBox.Text;
            // transaction ID's are only length 5 and digits so make sure
            // these conditions are met
            if (TransactIDString.Length == 5 && IsDigitsOnly(TransactIDString) == true)
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                string LineRead = OutputFile.ReadLine();
                while (LineRead != null)
                {
                    //Debug.WriteLine(LineRead);
                    //Debug.WriteLine(TotalLinesFile.ToString());
                    if (LineRead == TransactIDString)
                    {
                        // strings to clarify user what the returned results are
                        SearchListBox.Items.Add("ID is: " + LineRead);
                        SearchListBox.Items.Add("Email is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Name is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Telephone is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Term in Years is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Total Interest is: €" + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Monthly Repayment is: €" + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Interest Rate Applied is: " + OutputFile.ReadLine() + "%");
                        SearchListBox.Items.Add("Total Loan Cost is: €" + OutputFile.ReadLine());
                        SearchListBox.Visible = true;
                        // break as one ID per transaction - unique
                        break;
                    }
                    else
                    {
                        LineRead = OutputFile.ReadLine();
                    }
                }
                OutputFile.Close();
                if(LineRead == null)
                {
                    MessageBox.Show("ID inputted not on file", "Info",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.SearchIDTextBox.Focus();
                    // if already visible from an initial check - hide
                    SearchListBox.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Please input a valid ID.\nPlease ensure 5 numeric characters are inputted.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.SearchIDTextBox.Focus();
                // if already visible from an initial check - hide
                SearchListBox.Visible = false;
            }
        }

        private void SearchEmailButton_Click(object sender, EventArgs e)
        {
            int TotalLinesFile = CalculateFileLines();
            // clear for next search if user wants to check another email
            SearchListBox.Items.Clear();
            String UserEmail = this.SearchEmailTextBox.Text;
            String Prev = "";
            // check inputted email is valid and meets conditions in earlier function
            if (UserEmail.Length >= 1 & (UserEmail.Contains("@") | UserEmail.EndsWith(".com")))
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                string LineRead = OutputFile.ReadLine();
                while (LineRead != null)
                {
                    if (LineRead == UserEmail)
                    {
                        // strings to clarify user what the returned results are
                        SearchListBox.Items.Add("ID is: " + Prev);
                        SearchListBox.Items.Add("Email is: " + LineRead);
                        SearchListBox.Items.Add("Name is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Telephone is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Term in Years is: " + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Total Interest is: €" + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Monthly Repayment is: €" + OutputFile.ReadLine());
                        SearchListBox.Items.Add("Interest Rate Applied is: " + OutputFile.ReadLine() + "%");
                        SearchListBox.Items.Add("Total Loan Cost is: €" + OutputFile.ReadLine());
                        SearchListBox.Visible = true;
                        // dont break this time - might be multiple transactions for an email
                        LineRead = OutputFile.ReadLine();
                    }
                    else
                    {
                        Prev = LineRead;
                        LineRead = OutputFile.ReadLine();
                    }
                }
                OutputFile.Close();
                if (LineRead == null && SearchListBox.Items.Count == 0)
                {
                    MessageBox.Show("Email inputted not on file", "Info",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.SearchEmailTextBox.Focus();
                    // if already visible from an initial check - hide
                    SearchListBox.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Please input a valid Email.\nPlease ensure a valid email ending in .com is inputted.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.SearchEmailTextBox.Focus();
                // if already visible from an initial check - hide
                SearchListBox.Visible = false;
            }
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            this.ProceedGroupBox.Visible = false;
            this.DisplayGroupBox.Visible = false;
            this.GroupBoxLength.Visible = false;
            this.SearchGroupBox.Visible = false;
            this.SummaryGroupBox.Visible = true;
            this.Text = "Company Transaction History Summary";
            int TotalLines = CalculateFileLines();
            // rounds down/up to actual number of transactions and make decimal
            decimal NumberTransactions = Decimal.Round((TotalLines) / 9);
            decimal TotalLoans = CalculateSummary(9);
            decimal TotalInterest = CalculateSummary(6);
            // errors here
            decimal TotalYears = CalculateSummary(5);
            TotalIncomeTextBox.Text = TotalLoans.ToString("C");
            InterestOverallTextBox.Text = TotalInterest.ToString("C");
            AverageLoanTextBox.Text = (TotalLoans / NumberTransactions).ToString("C");
            AverageLoanLengthTextBox.Text = (TotalYears / NumberTransactions).ToString("0.00");
        }

        private decimal CalculateSummary(int CalculateLines)
        {
            int TotalLines = CalculateFileLines();
            string LineRead;
            decimal Total = 0m, LineValueDecimal;

            //Debug.WriteLine(TotalLines.ToString());
            // if number of lines greater than 1 it can be presumed there should be 9 for a transaction
            if (TotalLines >= 1)
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                while (!OutputFile.EndOfStream)
                {
                    for (int i = 1; i <= TotalLines - 1; i++)
                    {
                        // if 5th value needed then modulus 9 5-5 would equal 0
                        // this should as long as order aligns get a match
                        // if next value is 14 then 14-5 % 9 is again 0 and so forth
                        if((i - CalculateLines) % 9 == 0)
                        {
                            LineRead = OutputFile.ReadLine();
                            // VS underlines above line as potentially null deal with this case
                            // avoids any runtime errors
                            if(LineRead != null)
                            {
                                LineValueDecimal = decimal.Parse(LineRead);
                                Total += LineValueDecimal;
                            }
                            else
                            {
                                OutputFile.ReadLine();
                            }
                            
                        }
                        else
                        {
                            OutputFile.ReadLine();
                        }                       
                    }
                }
                OutputFile.Close();
            }
            // nothing wrote to file yet if no lines
            else
            {
                MessageBox.Show("No Information Available\nContact Admin",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Total;
     
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.TextBoxLoan.Clear();
            this.DisplayGroupBox.Visible = false;
            this.ProceedGroupBox.Visible = false;
            this.OneYearRadioButton.Checked = true;
            this.ThreeYearRadioButton.Checked = false;
            this.FiveYearsRadioButton.Checked = false;
            this.SevenYearsRadioButton.Checked = false;
            this.SearchGroupBox.Visible = false;
            this.SearchListBox.Visible = false;
            this.GroupBoxLength.Visible = false;
            this.SummaryGroupBox.Visible = false;
            this.Text = "Loan Calculator/Approval";
            // ensure proceed groupboxs are cleared
            this.NameTextBox.Clear();
            this.TelephoneTextBox.Clear();
            this.EmailTextBox.Clear();
            this.PostcodeTextBox.Clear();
            // search text boxes cleared
            this.SearchIDTextBox.Clear();
            this.SearchEmailTextBox.Clear();
            SearchListBox.Items.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}