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

namespace Mad4Road
{
    public partial class Mad4RoadForm : Form
    {
        private decimal LoanPreTotal, MonthlyRepay, TotalInterestPaid,
            LoanOverallTotal, InterestRateApplied;

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
                    PricePictureBox.Visible = true;
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
                    // 3 year less than40k
                    decimal TotalInterestPaidYear3 = LoanPreTotal * (APR_3YEAR_OVER40 / 100);
                    decimal MonthlyRepayYear3 = TotalInterestPaidYear3 / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_OVER40;
                    decimal LoanOverallTotalYear3 = TotalInterestPaidYear3 + LoanPreTotal;
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text = LoanOverallTotalYear3.ToString("C");
                    // 5 year less than40k
                    decimal TotalInterestPaidYear5 = LoanPreTotal * (APR_5YEAR_OVER40 / 100);
                    decimal MonthlyRepayYear5 = TotalInterestPaidYear5 / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_OVER40;
                    decimal LoanOverallTotalYear5 = TotalInterestPaidYear5 + LoanPreTotal;
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year less than40k
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
                    // 3 year less than40k
                    decimal TotalInterestPaidYear3 = LoanPreTotal * (APR_3YEAR_OVER80 / 100);
                    decimal MonthlyRepayYear3 = TotalInterestPaidYear3 / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                    decimal InterestRateAppliedYear3 = APR_3YEAR_OVER80;
                    decimal LoanOverallTotalYear3 = TotalInterestPaidYear3 + LoanPreTotal;
                    // populate textboxes
                    this.Interest3YearTextBox.Text = InterestRateAppliedYear3 + "%";
                    this.Monthly3YearTextBox.Text = MonthlyRepayYear3.ToString("C");
                    this.TotalInterest3YearTextBox.Text = TotalInterestPaidYear3.ToString("C");
                    this.TotalLoanCost3YearTextBox.Text = LoanOverallTotalYear3.ToString("C");
                    // 5 year less than40k
                    decimal TotalInterestPaidYear5 = LoanPreTotal * (APR_5YEAR_OVER80 / 100);
                    decimal MonthlyRepayYear5 = TotalInterestPaidYear5 / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                    decimal InterestRateAppliedYear5 = APR_5YEAR_OVER80;
                    decimal LoanOverallTotalYear5 = TotalInterestPaidYear5 + LoanPreTotal;
                    // populate textboxes
                    this.FiveYearInterestRateTextBox.Text = InterestRateAppliedYear5 + "%";
                    this.Monthly5YearRepayTextBox.Text = MonthlyRepayYear5.ToString("C");
                    this.TotalInterest5YearTextBox.Text = TotalInterestPaidYear5.ToString("C");
                    this.TotalLoan5YearsTextBox.Text = LoanOverallTotalYear5.ToString("C");
                    // 7 year less than40k
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
    "\nLoan must be between €10,000 and €100,000.",
    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxLoan.Focus();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text.Length >= 1)
            {
                if(PostcodeTextBox.Text.Length >= 1)
                {
                    String PhoneNumber = TelephoneTextBox.Text;
                    if(PhoneNumber.Length == 10 && IsDigitsOnly(PhoneNumber) == true)
                    {
                        if (EmailTextBox.Text != "" & (EmailTextBox.Text.Contains("@") | EmailTextBox.Text.EndsWith(".com") | EmailTextBox.Text.EndsWith(".in") | EmailTextBox.Text.EndsWith(".ie")))
                        {
                            string Details = "Name of Client:\t\t" + NameTextBox.Text + "\nMembership ID:\t\t" + IDTextBox.Text + "\nTelephone Number:\t" + TelephoneTextBox.Text + 
                                "\nEmail Address:\t\t" + EmailTextBox.Text + "\nTotal Price:\t\t" +
                                TotalLoanCostTextBox.Text + "\nInterest to be Paid:\t\t" + TotalInterestTextBox.Text;
                            if (MessageBox.Show("Do you wish to Proceed?\n" + Details, "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    StreamWriter InputFile = File.AppendText(DataFile);
                                    InputFile.WriteLine(IDTextBox.Text);
                                    InputFile.WriteLine(NameTextBox.Text);
                                    InputFile.WriteLine(TelephoneTextBox.Text);
                                    InputFile.WriteLine(EmailTextBox.Text);
                                    InputFile.WriteLine(TotalLoanCostTextBox.Text);
                                    InputFile.WriteLine(TotalInterestTextBox.Text);
                                    InputFile.WriteLine(MonthlyRepaymentTextBox.Text);
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
                    EmailTextBox.Focus();
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
            this.ProceedGroupBox.Visible = true;
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
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_3YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_5YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_7YEAR_UNDER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_UNDER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
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
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_3YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_5YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_7YEAR_OVER40 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_OVER40;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
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
                    }
                    else if (ThreeYearRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_3YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHTHREEYEARS + LoanPreTotal / MONTHTHREEYEARS;
                        InterestRateApplied = APR_3YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                    else if (FiveYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_5YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHFIVEYEARS + LoanPreTotal / MONTHFIVEYEARS;
                        InterestRateApplied = APR_5YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                    else if (SevenYearsRadioButton.Checked)
                    {
                        TotalInterestPaid = LoanPreTotal * (APR_7YEAR_OVER80 / 100);
                        MonthlyRepay = TotalInterestPaid / MONTHSEVENYEARS + LoanPreTotal / MONTHSEVENYEARS;
                        InterestRateApplied = APR_7YEAR_OVER80;
                        LoanOverallTotal = TotalInterestPaid + LoanPreTotal;
                    }
                }
                TransactionIDGenerator();
            }
            catch
            {
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // we need to count total lines in files to ensure we generate a unique
        // number everytime. requirements mean we cannot use readlines or built-in
        // functions like count so we have to manually count each line.
        private int CalculateFileLines()
        {
            // create file if it doesn't exist
            if (!File.Exists(DataFile))
            {
                var FileCreated = File.Create(DataFile);
                FileCreated.Close();
            }
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
                            //Console.WriteLine(IDTextBox.Text.ToString());
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
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.TextBoxLoan.Clear();
            this.DisplayGroupBox.Visible = false;
            this.ProceedGroupBox.Visible = false;
            this.OneYearRadioButton.Checked = true;
            this.ThreeYearRadioButton.Checked = false;
            this.FiveYearsRadioButton.Checked = false;
            this.SevenYearsRadioButton.Checked = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}