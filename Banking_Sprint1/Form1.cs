using System.Collections.Generic;
using BankingApplication_Sprint1.Models;
using BankingApplication_Sprint1.Exceptions;
using Banking_Sprint1.Controllers;
using System.Drawing.Drawing2D;

namespace Banking_Sprint1
{
    public partial class Form1 : Form
    {
        private readonly CustomerController customerController;

        private Customer selectedCustomer = null!;
        private Account selectedAccount = null!;

        public Form1()
        {
            InitializeComponent();

            customerController = new CustomerController();
        }

        private void LoadCustomersByRole(string role)
        {
            CustomerComboBox.Items.Clear();

            List<Customer> customersByRole =
                customerController.GetCustomersByRole(role);

            foreach (Customer customer in customersByRole)
            {
                CustomerComboBox.Items.Add(customer);
            }

            CustomerComboBox.SelectedIndex = -1;

            selectedCustomer = null!;
            selectedAccount = null!;

            ClearCustomerDisplay();
        }

        private void ClearCustomerDisplay()
        {
            lblCustomerNumberValue.Text = "Customer Number Value";
            lblCustomerNameTitle.Text = "Customer Name";
            lblContactValue.Text = "Contact Value";
            lblRoleValue.Text = "Role Value";

            FeeDisocuntValue.Text = "No Fee Discount";
            FeeDisocuntValue.ForeColor = Color.Gray;
        }

        private void UpdateAccountCards()
        {
            EverydayCurrentBalance.Text =
                "Current Balance: $" + selectedCustomer.Accounts[0].Balance;

            InvestmentCurrentBalance.Text =
                "Current Balance: $" + selectedCustomer.Accounts[1].Balance;

            OmniCurrentBalance.Text =
                "Current Balance: $" + selectedCustomer.Accounts[2].Balance;
        }

        private void UpdateAllAccountDisplays(string result)
        {
            UpdateAccountCards();

            lblAccountIdValue.Text = selectedAccount.AccountId;
            lblAccountNameValue.Text = selectedAccount.AccountName;
            lblBalanceValue.Text = "$" + selectedAccount.Balance;
            lblInterestRateValue.Text =
                selectedAccount.InterestRate.ToString();

            lblLastTransactionValue.Text =
                selectedAccount.LastTransactionStatus;

            lblSummaryCustomerValue.Text =
                selectedCustomer.CustomerName;

            lblSummaryAccountTypeValue.Text =
                selectedAccount.AccountName;

            lblSummaryAccountNoValue.Text =
                selectedAccount.AccountId;

            lblSummaryBalanceValue.Text =
                "$" + selectedAccount.Balance;

            StatusLabel.Text = "STATUS: " + result;

            lsttransactionhistory.Items.Add(
                DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                " - " +
                result);
        }

        private void UpdateNavbar(string activePage)
        {
            btnCustomer.UseVisualStyleBackColor = false;
            btnAccounts.UseVisualStyleBackColor = false;
            btnTransactions.UseVisualStyleBackColor = false;

            btnCustomer.BackColor = Color.FromArgb(30, 41, 59);
            btnAccounts.BackColor = Color.FromArgb(30, 41, 59);
            btnTransactions.BackColor = Color.FromArgb(30, 41, 59);

            btnCustomer.ForeColor = Color.White;
            btnAccounts.ForeColor = Color.White;
            btnTransactions.ForeColor = Color.White;

            if (activePage == "Customer")
            {
                btnCustomer.BackColor =
                    Color.FromArgb(8, 145, 178);
            }
            else if (activePage == "Accounts")
            {
                btnAccounts.BackColor =
                    Color.FromArgb(8, 145, 178);
            }
            else if (activePage == "Transactions")
            {
                btnTransactions.BackColor =
                    Color.FromArgb(8, 145, 178);
            }
        }

        private void SetButtonRadius(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                btn.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                btn.Width - radius,
                btn.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                btn.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            btn.Region = new Region(path);
        }

        private void textBox1_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void EverydayAccountLabel_Click(
            object sender,
            EventArgs e)
        {
        }

        private void label6_Click(
            object sender,
            EventArgs e)
        {
        }

        private void AccountPagePanel_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void ClickAccountCardLabel_Click(
            object sender,
            EventArgs e)
        {
        }

        private void panel3_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.");

                return;
            }

            selectedAccount =
                selectedCustomer.Accounts[0];

            panel3.BackColor =
                Color.FromArgb(220, 255, 255);

            panel2.BackColor = Color.White;
            panel1.BackColor = Color.White;

            lblAccountIdValue.Text =
                selectedAccount.AccountId;

            lblAccountNameValue.Text =
                selectedAccount.AccountName;

            lblBalanceValue.Text =
                "$" + selectedAccount.Balance;

            lblInterestRateValue.Text =
                selectedAccount.InterestRate.ToString();

            lblLastTransactionValue.Text =
                selectedAccount.LastTransactionStatus;

            lblOverdraftValue.Text =
                "Not Available";
        }

        private void panel2_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.");

                return;
            }

            selectedAccount =
                selectedCustomer.Accounts[1];

            panel3.BackColor = Color.White;

            panel2.BackColor =
                Color.FromArgb(220, 255, 255);

            panel1.BackColor = Color.White;

            lblAccountIdValue.Text =
                selectedAccount.AccountId;

            lblAccountNameValue.Text =
                selectedAccount.AccountName;

            lblBalanceValue.Text =
                "$" + selectedAccount.Balance;

            lblInterestRateValue.Text =
                selectedAccount.InterestRate.ToString();

            lblLastTransactionValue.Text =
                selectedAccount.LastTransactionStatus;

            lblOverdraftValue.Text =
                "Not Available";
        }

        private void panel1_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.");

                return;
            }

            selectedAccount =
                selectedCustomer.Accounts[2];

            panel3.BackColor = Color.White;
            panel2.BackColor = Color.White;

            panel1.BackColor =
                Color.FromArgb(220, 255, 255);

            lblAccountIdValue.Text =
                selectedAccount.AccountId;

            lblAccountNameValue.Text =
                selectedAccount.AccountName;

            lblBalanceValue.Text =
                "$" + selectedAccount.Balance;

            lblInterestRateValue.Text =
                selectedAccount.InterestRate.ToString();

            lblLastTransactionValue.Text =
                selectedAccount.LastTransactionStatus;

            if (selectedAccount is OmniAccount omniAccount)
            {
                lblOverdraftValue.Text =
                    "$" + omniAccount.OverdraftLimit.ToString("F2");
            }
            else
            {
                lblOverdraftValue.Text =
                    "Not Available";
            }
        }

        private void Form1_Load(
            object sender,
            EventArgs e)
        {
            CustomerPagePanel.Visible = true;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = false;
            CustomerManagementPanel.Visible = false;

            UpdateNavbar("Customer");

            RegularCustomerBtn.Checked = true;

            LoadCustomersByRole(
                "Regular Customer");

            lsttransactionhistory.Items.Clear();

            lsttransactionhistory.Items.Add(
                "System ready.");

            SetButtonRadius(
                depositbutton,
                20);

            SetButtonRadius(
                withdrawbutton,
                20);

            SetButtonRadius(
                CalculateInterestBtn,
                20);

            SetButtonRadius(
                btnCustomer,
                20);

            SetButtonRadius(
                btnAccounts,
                20);

            SetButtonRadius(
                btnTransactions,
                20);
            LoadManagementCustomerList();
        }

        private void ContinueBtn_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer before continuing.");

                return;
            }

            UpdateAccountCards();
            UpdateNavbar("Accounts");

            CustomerPagePanel.Visible = false;
            AccountPagePanel.Visible = true;
            Transactionpagepanel.Visible = false;
        }

        private void ExitBtn_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerComboBox_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (CustomerComboBox.SelectedItem is Customer customer)
            {
                selectedCustomer = customer;
                selectedAccount = null!;

                lblCustomerNumberValue.Text =
                    selectedCustomer.CustomerNumber;

                lblCustomerNameTitle.Text =
                    selectedCustomer.CustomerName;

                lblContactValue.Text =
                    selectedCustomer.ContactDetails;

                lblRoleValue.Text =
                    selectedCustomer.GetCustomerRole();

                if (selectedCustomer is BankStaff)
                {
                    FeeDisocuntValue.Text =
                        "✓ 50% Fee Discount";

                    FeeDisocuntValue.ForeColor =
                        Color.Green;
                }
                else
                {
                    FeeDisocuntValue.Text =
                        "No Fee Discount";

                    FeeDisocuntValue.ForeColor =
                        Color.Gray;
                }
            }
        }

        private void RegularCustomerBtn_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (RegularCustomerBtn.Checked)
            {
                LoadCustomersByRole(
                    "Regular Customer");
            }
        }

        private void BankStaffBtn_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (BankStaffBtn.Checked)
            {
                LoadCustomersByRole(
                    "Bank Staff");
            }
        }

        private void ContinueBtnAccount_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.");

                return;
            }

            if (selectedAccount == null)
            {
                MessageBox.Show(
                    "Please select an account before continuing.");

                return;
            }

            lblSummaryCustomerValue.Text =
                selectedCustomer.CustomerName;

            lblSummaryAccountTypeValue.Text =
                selectedAccount.AccountName;

            lblSummaryAccountNoValue.Text =
                selectedAccount.AccountId;

            lblSummaryBalanceValue.Text =
                "$" + selectedAccount.Balance;

            if (selectedAccount is EverydayAccount)
            {
                CalculateInterestBtn.Enabled = true;

                CalculateInterestBtn.Text =
                    "INTEREST NOT AVAILABLE";

                CalculateInterestBtn.BackColor =
                    Color.Gray;

                CalculateInterestBtn.ForeColor =
                    Color.White;
            }
            else
            {
                CalculateInterestBtn.Enabled = true;

                CalculateInterestBtn.Text =
                    "CALCULATE INTEREST";

                CalculateInterestBtn.BackColor =
                    Color.FromArgb(51, 65, 85);

                CalculateInterestBtn.ForeColor =
                    Color.White;
            }

            UpdateNavbar("Transactions");

            CustomerPagePanel.Visible = false;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = true;
        }

        private void BackBtnAccount_Click(
            object sender,
            EventArgs e)
        {
            UpdateNavbar("Customer");

            CustomerPagePanel.Visible = true;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = false;
        }

        private void finishBtn_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(
            object sender,
            EventArgs e)
        {
            UpdateNavbar("Accounts");

            CustomerPagePanel.Visible = false;
            AccountPagePanel.Visible = true;
            Transactionpagepanel.Visible = false;
        }

        private void panel1_Paint_1(
            object sender,
            PaintEventArgs e)
        {
        }

        private void CalculateInterestBtn_Click(
            object sender,
            EventArgs e)
        {
            if (selectedAccount == null)
            {
                MessageBox.Show(
                    "Please select an account first.",
                    "Account Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string result =
                selectedAccount.CalculateInterest();

            UpdateAllAccountDisplays(result);
        }

        private void depositbutton_Click(
            object sender,
            EventArgs e)
        {
            if (selectedAccount == null)
            {
                MessageBox.Show(
                    "Please select an account before making a deposit.",
                    "Account Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal amount;

            if (!decimal.TryParse(
                textBox2.Text,
                out amount))
            {
                MessageBox.Show(
                    "Please enter a valid numeric amount.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show(
                    "Deposit amount must be greater than zero.",
                    "Invalid Deposit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string result =
                selectedAccount.Deposit(amount);

            UpdateAllAccountDisplays(result);

            textBox2.Clear();
        }

        private void textBox2_TextChanged(
            object sender,
            EventArgs e)
        {
            decimal amount;

            bool validAmount =
                decimal.TryParse(
                    textBox2.Text,
                    out amount) &&
                amount > 0;

            depositbutton.Enabled =
                validAmount;

            withdrawbutton.Enabled =
                validAmount;
        }

        private void withdrawbutton_Click(
            object sender,
            EventArgs e)
        {
            if (selectedAccount == null ||
                selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer and account first.",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal amount;

            if (!decimal.TryParse(
                textBox2.Text,
                out amount))
            {
                MessageBox.Show(
                    "Please enter a valid numeric amount.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show(
                    "Withdrawal amount must be greater than zero.",
                    "Invalid Withdrawal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string result =
                    selectedAccount.Withdraw(
                        amount,
                        selectedCustomer);

                UpdateAllAccountDisplays(result);
            }
            catch (BankingException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    ex.AccountType + " Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                UpdateAllAccountDisplays(
                    ex.Message);
            }
            finally
            {
                textBox2.Clear();
            }
        }

        private void btnCustomer_Click(
            object sender,
            EventArgs e)
        {
            UpdateNavbar("Customer");

            CustomerPagePanel.Visible = true;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = false;
        }

        private void btnAccounts_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.");

                return;
            }

            UpdateAccountCards();
            UpdateNavbar("Accounts");

            CustomerPagePanel.Visible = false;
            AccountPagePanel.Visible = true;
            Transactionpagepanel.Visible = false;
        }

        private void btnTransactions_Click(
            object sender,
            EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show(
                    "Please select a customer first.");

                return;
            }

            if (selectedAccount == null)
            {
                MessageBox.Show(
                    "Please select an account first.");

                return;
            }

            UpdateNavbar("Transactions");

            CustomerPagePanel.Visible = false;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = true;
        }

        private void transactionheaderlabel_Click(
            object sender,
            EventArgs e)
        {
        }

        private void amountselectionlabel_Click(
            object sender,
            EventArgs e)
        {
        }

        private void pictureBox1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lstManageCustomers.SelectedItem is not Customer customerToDelete)
            {
                MessageBox.Show(
                    "Please select a customer first.",
                    "Customer Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this customer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            bool deleted = customerController.DeleteCustomer(
                customerToDelete.CustomerNumber,
                out string message);

            if (deleted)
            {
                MessageBox.Show(
                    message,
                    "Customer Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadManagementCustomerList();
                ClearManagementFields();

                LoadCustomersByRole(
                    RegularCustomerBtn.Checked
                        ? "Regular Customer"
                        : "Bank Staff");
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void lstManageCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstManageCustomers.SelectedItem is not Customer customer)
            {
                return;
            }

            txtManageCustomerNumber.Text = customer.CustomerNumber;
            txtManageCustomerName.Text = customer.CustomerName;
            txtManageContactDetails.Text = customer.ContactDetails;
            cmbManageCustomerRole.SelectedItem = customer.GetCustomerRole();

            txtManageCustomerNumber.ReadOnly = true;

        }
        private void LoadManagementCustomerList()
        {
            lstManageCustomers.Items.Clear();

            foreach (Customer customer in customerController.GetAllCustomers())
            {
                lstManageCustomers.Items.Add(customer);
            }

            lstManageCustomers.SelectedIndex = -1;
        }
        private void ClearManagementFields()
        {
            txtManageCustomerNumber.Clear();
            txtManageCustomerName.Clear();
            txtManageContactDetails.Clear();

            cmbManageCustomerRole.SelectedIndex = -1;
            lstManageCustomers.ClearSelected();

            txtManageCustomerNumber.ReadOnly = false;
            txtManageCustomerNumber.Focus();
        }
        private void txtManageCustomerNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClearCustomerFields_Click(object sender, EventArgs e)
        {
            ClearManagementFields();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            LoadManagementCustomerList();
            ClearManagementFields();

            CustomerPagePanel.Visible = false;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = false;
            CustomerManagementPanel.Visible = true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string customerNumber =
        txtManageCustomerNumber.Text.Trim();

            string customerName =
                txtManageCustomerName.Text.Trim();

            string contactDetails =
                txtManageContactDetails.Text.Trim();

            string customerRole =
                cmbManageCustomerRole.SelectedItem?.ToString() ?? string.Empty;

            bool customerCreated =
                customerController.CreateCustomer(
                    customerNumber,
                    customerName,
                    contactDetails,
                    customerRole,
                    out string message);
            if (customerCreated)
            {
                MessageBox.Show(
                    message,
                    "Customer Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadManagementCustomerList();
                ClearManagementFields();

                LoadCustomersByRole(
                    RegularCustomerBtn.Checked
                        ? "Regular Customer"
                        : "Bank Staff");
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Unable to Add Customer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (lstManageCustomers.SelectedItem is not Customer selectedCustomerToUpdate)
            {
                MessageBox.Show(
                    "Please select a customer from the list first.",
                    "Customer Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string customerNumber =
                selectedCustomerToUpdate.CustomerNumber;

            string newCustomerName =
                txtManageCustomerName.Text.Trim();

            string newContactDetails =
                txtManageContactDetails.Text.Trim();

            bool customerUpdated =
                customerController.UpdateCustomer(
                    customerNumber,
                    newCustomerName,
                    newContactDetails,
                    out string message);

            if (customerUpdated)
            {
                MessageBox.Show(
                    message,
                    "Customer Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadManagementCustomerList();
                ClearManagementFields();

                LoadCustomersByRole(
                    RegularCustomerBtn.Checked
                        ? "Regular Customer"
                        : "Bank Staff");
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Unable to Update Customer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnBackManagement_Click(object sender, EventArgs e)
        {
            ClearManagementFields();

            CustomerManagementPanel.Visible = false;
            AccountPagePanel.Visible = false;
            Transactionpagepanel.Visible = false;
            CustomerPagePanel.Visible = true;

            UpdateNavbar("Customer");

            LoadCustomersByRole(
                RegularCustomerBtn.Checked
                    ? "Regular Customer"
                    : "Bank Staff");
        }
    }

}