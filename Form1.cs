// Name - Kian Sweeney
// ID - 22220670
// MS806 Assignment 3
// Your client Mad4Money Bank Corp is a financial services company that offers various financial
// products to its customers. One of these is a car loan product called �Mad4Road�, in which a client can
// borrow between �10,000 and �100,000 over terms of up to 7 years. The interest rate offered to each
// client depends on the amount and term of the loan requested. Your company has been commissioned to
//create a well-designed application for employees to process client transactions for this product.

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
        private decimal LoanPreTotal, MonthlyRepay, TotalInterestPaid,
            LoanOverallTotal, InterestRateApplied;
        // this needs to be decimal for our calculations regarding average loan length
        // in the summary tab
        private decimal TermYears;

        private const String DataFile = "ClientLoanDetails.txt";
        public Mad4RoadForm()
        {
            InitializeComponent();
        }
        // constants
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
        const int MAXATTEMPTS = 3;

        // changeable variables
        int PasswordAttempts = 1;

        private void PasswordAttemptSubmitButton_Click(object sender, EventArgs e)
        {
            do
            {
                if (PasswordTextBox.Text != PASSWORD & PasswordAttempts < MAXATTEMPTS)
                {
                    int AttemptsLeft = MAXATTEMPTS - PasswordAttempts - 1;
                    MessageBox.Show("Incorrect Password. Please Check Again.\nNumber of attempts left: " + AttemptsLeft.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordTextBox.Clear();
                    PasswordTextBox.Focus();
                    PasswordAttempts += 1;
                }
                else if (PasswordTextBox.Text != PASSWORD & PasswordAttempts >= MAXATTEMPTS)
                {
                    MessageBox.Show("Access Denied. No More Password Attempts Remaining.\nClosing the Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
                }
                else if (PasswordTextBox.Text == PASSWORD & PasswordAttempts <= MAXATTEMPTS)
                {
                    StartMenuPanel.Visible = false;
                    //PricePictureBox.Visible = true;
                    ButtonPanel.Visible = true;
                    LoanAmountGroupBox.Visible = true;
                    this.TextBoxLoan.Focus();
                    break;
                }
            } while (PasswordAttempts >= MAXATTEMPTS);

        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(TextBoxLoan.Text, out LoanPreTotal) || 10000 <= LoanPreTotal &&
                LoanPreTotal <= 100000)
            {
                // no need to check for greater than equal 10k done already
                if(LoanPreTotal < 40000)
                {
                    decimal TotalInterestPaidYear1 = LoanPreTotal * (APR_1YEAR_UNDER40 / 100);
                    decimal MonthlyRepayYear1 = TotalInterestPaidYear1 / MONTHYEAR + LoanPreTotal / MONTHYEAR;
                    decimal InterestRateAppliedYear1 = APR_1YEAR_UNDER40;
                    decimal LoanOverallTotalYear1 = TotalInterestPaidYear1 + LoanPreTotal;
                    // populate textboxes
                    this.InterestRateTextBox.Text = InterestRateAppliedYear1 + "%";
                    this.MonthlyRepaymentTextBox.Text = MonthlyRepayYear1.ToString("C");
                    this.TotalInterestTextBox.Text = TotalInterestPaidYear1.ToString("C");
                    this.TotalLoanCostTextBox.Text = LoanOverallTotalYear1.ToString("C");
                    // 3 year less than40k
                    decimal TotalInterestPaidYear3 = LoanPreTotal * (APR_3YEAR_UNDER40 / 100);
                    decimal MonthlyRepayYear3 = TotalInterestPaidYear3 / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_UNDER40;
                    decimal LoanOverallTotalYear3 = TotalInterestPaidYear3 + LoanPreTotal;
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text= LoanOverallTotalYear3.ToString("C");
                    // 5 year less than40k
                    decimal TotalInterestPaidYear5 = LoanPreTotal * (APR_5YEAR_UNDER40 / 100);
                    decimal MonthlyRepayYear5 = TotalInterestPaidYear5 / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_UNDER40;
                    decimal LoanOverallTotalYear5 = TotalInterestPaidYear5 + LoanPreTotal;
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year less than40k
                    decimal TotalInterestPaidYear7 = LoanPreTotal * (APR_7YEAR_UNDER40 / 100);
                    decimal MonthlyRepayYear7 = TotalInterestPaidYear7 / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                    decimal InterestRateAppliedYear7 = APR_7YEAR_UNDER40;
                    decimal LoanOverallTotalYear7 = TotalInterestPaidYear7 + LoanPreTotal;
                    // populate textboxes
                    this.AppliedInterest7YearTextBox.Text = InterestRateAppliedYear7 + "%";
                    this.Monthly7YearTextBox.Text = MonthlyRepayYear7.ToString("C");
                    this.Interest7YearTextBox.Text = TotalInterestPaidYear7.ToString("C");
                    this.TotalLoan7YearTextBox.Text = LoanOverallTotalYear7.ToString("C");
                }
                else if(LoanPreTotal < 80000 && LoanPreTotal >= 40000)
                {
                    decimal TotalInterestPaidYear1 = LoanPreTotal * (APR_1YEAR_OVER40 / 100);
                    decimal MonthlyRepayYear1 = TotalInterestPaidYear1 / MONTHYEAR + LoanPreTotal / MONTHYEAR;
                    decimal InterestRateAppliedYear1 = APR_1YEAR_OVER40;
                    decimal LoanOverallTotalYear1 = TotalInterestPaidYear1 + LoanPreTotal;
                    // populate textboxes
                    this.InterestRateTextBox.Text = InterestRateAppliedYear1 + "%";
                    this.MonthlyRepaymentTextBox.Text = MonthlyRepayYear1.ToString("C");
                    this.TotalInterestTextBox.Text = TotalInterestPaidYear1.ToString("C");
                    this.TotalLoanCostTextBox.Text = LoanOverallTotalYear1.ToString("C");
                    // 3 year greater than40k
                    decimal TotalInterestPaidYear3 = LoanPreTotal * (APR_3YEAR_OVER40 / 100);
                    decimal MonthlyRepayYear3 = TotalInterestPaidYear3 / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_OVER40;
                    decimal LoanOverallTotalYear3 = TotalInterestPaidYear3 + LoanPreTotal;
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text = LoanOverallTotalYear3.ToString("C");
                    // 5 year greater than40k
                    decimal TotalInterestPaidYear5 = LoanPreTotal * (APR_5YEAR_OVER40 / 100);
                    decimal MonthlyRepayYear5 = TotalInterestPaidYear5 / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_OVER40;
                    decimal LoanOverallTotalYear5 = TotalInterestPaidYear5 + LoanPreTotal;
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year greater than40k
                    decimal TotalInterestPaidYear7 = LoanPreTotal * (APR_7YEAR_OVER40 / 100);
                    decimal MonthlyRepayYear7 = TotalInterestPaidYear7 / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                    decimal InterestRateAppliedYear7 = APR_7YEAR_OVER40;
                    decimal LoanOverallTotalYear7 = TotalInterestPaidYear7 + LoanPreTotal;
                    // populate textboxes
                    this.AppliedInterest7YearTextBox.Text = InterestRateAppliedYear7 + "%";
                    this.Monthly7YearTextBox.Text = MonthlyRepayYear7.ToString("C");
                    this.Interest7YearTextBox.Text = TotalInterestPaidYear7.ToString("C");
                    this.TotalLoan7YearTextBox.Text = LoanOverallTotalYear7.ToString("C");
                }
                else
                // again no need to check for greater than equal 100k done already
                {
                    decimal TotalInterestPaidYear1 = LoanPreTotal * (APR_1YEAR_OVER80 / 100);
                    decimal MonthlyRepayYear1 = TotalInterestPaidYear1 / MONTHYEAR + LoanPreTotal / MONTHYEAR;
                    decimal InterestRateAppliedYear1 = APR_1YEAR_OVER80;
                    decimal LoanOverallTotalYear1 = TotalInterestPaidYear1 + LoanPreTotal;
                    // populate textboxes
                    this.InterestRateTextBox.Text = InterestRateAppliedYear1 + "%";
                    this.MonthlyRepaymentTextBox.Text = MonthlyRepayYear1.ToString("C");
                    this.TotalInterestTextBox.Text = TotalInterestPaidYear1.ToString("C");
                    this.TotalLoanCostTextBox.Text = LoanOverallTotalYear1.ToString("C");
                    // 3 year greater than 80k
                    decimal TotalInterestPaidYear3 = LoanPreTotal * (APR_3YEAR_OVER80 / 100);
                    decimal MonthlyRepayYear3 = TotalInterestPaidYear3 / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_OVER80;
                    decimal LoanOverallTotalYear3 = TotalInterestPaidYear3 + LoanPreTotal;
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text = LoanOverallTotalYear3.ToString("C");
                    // 5 year greater than 80k
                    decimal TotalInterestPaidYear5 = LoanPreTotal * (APR_5YEAR_OVER80 / 100);
                    decimal MonthlyRepayYear5 = TotalInterestPaidYear5 / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_OVER80;
                    decimal LoanOverallTotalYear5 = TotalInterestPaidYear5 + LoanPreTotal;
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year greater than 80k
                    decimal TotalInterestPaidYear7 = LoanPreTotal * (APR_7YEAR_OVER80 / 100);
                    decimal MonthlyRepayYear7 = TotalInterestPaidYear7 / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                    decimal InterestRateAppliedYear7 = APR_7YEAR_OVER80;
                    decimal LoanOverallTotalYear7 = TotalInterestPaidYear7 + LoanPreTotal;
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
    "\nLoan must be between �10,000 and �100,000.",
    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxLoan.Focus();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length >= 1)
            {
                if(PostcodeTextBox.Text.Length >= 1)
                {
                    String PhoneNumber = TelephoneTextBox.Text;
                    if(PhoneNumber.Length == 10 && IsDigitsOnly(PhoneNumber) == true)
                    {
                        if (EmailTextBox.Text != "" & (EmailTextBox.Text.Contains("@") | EmailTextBox.Text.EndsWith(".com")))
                        {
                            string Details = "Name of Client:\t\t" + NameTextBox.Text + "\nMembership ID:\t\t" + IDTextBox.Text + "\nTelephone Number:\t" + TelephoneTextBox.Text + 
                                "\nEmail Address:\t\t" + EmailTextBox.Text + "\nPostcode:\t\t" + PostcodeTextBox.Text +  "\nTotal Price:\t\t" +
                                LoanOverallTotal.ToString("C") + "\nInterest to be Paid:\t" + TotalInterestPaid.ToString("C") + "\nNumber Years Loan:\t" + TermYears.ToString() +
                                "\nInterest Rate Applied:\t" + InterestRateApplied.ToString() + "\nMonthy Repayments:\t" + MonthlyRepay.ToString("C");
                            if (MessageBox.Show("Do you wish to Proceed?\n" + Details, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
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
                        TotalInterestPaid = LoanPreTotal * (APR_1YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHYEAR + LoanPreTotal / MONTHYEAR;
                        InterestRateApplied = APR_1YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 1;
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_3YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 3;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_5YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 5;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_7YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 7;
                    }
                }
                else if (LoanPreTotal < 80000 && LoanPreTotal >= 40000)
                {
                    // make sure radio button clicked
                    if (OneYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_1YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHYEAR + LoanPreTotal / MONTHYEAR;
                        InterestRateApplied = APR_1YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 1;
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_3YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 3;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_5YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 5;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_7YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 7;
                    }
                }
                else
                // again no need to check for greater than equal 100k done already
                {
                    if (OneYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_1YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHYEAR + LoanPreTotal / MONTHYEAR;
                        InterestRateApplied = APR_1YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 1;
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_3YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 3;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_5YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 5;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_7YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                        TermYears = 7;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid File. Does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show("No details to show.\nPlease ensure there has been data inputted.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                TotalLines = 0;
            }
            return TotalLines;
        }

        private void TransactionIDGenerator()
        {
            int FileLines = CalculateFileLines();
            Random Rand = new Random();
            int rand = Rand.Next(0, 99999);
            try
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
            catch
            {
                MessageBox.Show("No details to show.\nPlease ensure there has been data inputted.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach(char c in str)
            {
                if(c < '0' || c > '9')
                    return false;
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
            String TransactIDString = this.SearchIDTextBox.Text;
            if (TransactIDString.Length <= 5 && IsDigitsOnly(TransactIDString) == true)
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                while (OutputFile.ReadLine() != null)
                {
                    for (int i = 1; i <= TotalLinesFile - 1; i++)
                    {
                        string LineRead = OutputFile.ReadLine();
                        if(LineRead != null)
                        {
                            if (LineRead == TransactIDString)
                            {
                                SearchListBox.Items.Add("ID is: " + LineRead);
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Visible = true;
                                break;
                            }
                            else if (i == TotalLinesFile - 1)
                            {
                                MessageBox.Show("ID inputted not on file", "Info", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input a valid ID.\nPlease ensure 5 or less numeric characters are inputted.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchEmailButton_Click(object sender, EventArgs e)
        {
            int TotalLinesFile = CalculateFileLines();
            String UserEmail = this.SearchEmailTextBox.Text;
            if (UserEmail.Length >= 1 & (UserEmail.Contains("@") | UserEmail.EndsWith(".com")))
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                while (OutputFile.ReadLine() != null)
                {
                    for (int i = 1; i <= TotalLinesFile - 1; i++)
                    {
                        string LineRead = OutputFile.ReadLine();
                        if (LineRead != null)
                        {
                            if (LineRead == UserEmail)
                            {
                                SearchListBox.Items.Add("Email is: " + LineRead);
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Items.Add(OutputFile.ReadLine());
                                SearchListBox.Visible = true;
                                break;
                            }
                            else if (i == TotalLinesFile - 1)
                            {
                                MessageBox.Show("Email inputted not on file", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input a valid Email.\nPlease ensure a valid email ending in .com is inputted.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            this.ProceedGroupBox.Visible = false;
            this.SummaryGroupBox.Visible = true;
            int TotalLines = CalculateFileLines();
            // deal with whitespace at end of file  -> rounds down/up to actual number of transactions
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
            if (TotalLines >= 1)
            {
                StreamReader OutputFile = File.OpenText(DataFile);
                while (!OutputFile.EndOfStream)
                {
                    for (int i = 1; i <= TotalLines - 1; i++)
                    {
                        if((i - CalculateLines) % 9 == 0)
                        {
                            LineRead = OutputFile.ReadLine();
                            if(LineRead != null)
                            {
                                // error here input string not in correct format
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
            this.GroupBoxLength.Visible = false;
            this.SummaryGroupBox.Visible = false;
            // ensure proceed groupboxs are cleared
            this.NameTextBox.Clear();
            this.TelephoneTextBox.Clear();
            this.EmailTextBox.Clear();
            this.PostcodeTextBox.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}