namespace Mad4Road
{
    public partial class Mad4RoadForm : Form
    {
        public Mad4RoadForm()
        {
            InitializeComponent();
        }
        // constants
        const String PASSWORD = "2Fast4U#";
        const int MAXATTEMPTS = 3;
        // changeable variables
        int PasswordAttempts = 1;

        private void PasswordAttemptsubmitButton_Click(object sender, EventArgs e)
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
                    Below40GroupBox.Visible = true;
                    GroupBoxLess80.Visible = true;
                    break;
                }
            } while (PasswordAttempts >= MAXATTEMPTS);

        }
    }
}