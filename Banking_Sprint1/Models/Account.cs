using System;

namespace BankingApplication_Sprint1.Models
{
    // Abstract parent used for the account.
    // I used this so Everyday, Investment and Omni accounts can share common details.
    internal abstract class Account
    {
        protected string accountId;
        protected string accountName;
        protected decimal balance;
        protected decimal interestRate;
        protected string lastTransactionStatus;

        public string AccountId
        {
            get { return accountId; }
        }

        public string AccountName
        {
            get { return accountName; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        public string LastTransactionStatus
        {
            get { return lastTransactionStatus; }
        }

        // Default constructor gives basic values.
        public Account()
        {
            accountId = "Unknown";
            accountName = "Unknown Account";
            balance = 0;
            interestRate = 0;
            lastTransactionStatus = "No transactions yet";
        }

        // Constructor with parameters 
        public Account(string accountId, string accountName, decimal balance, decimal interestRate)
        {
            this.accountId = accountId;
            this.accountName = accountName;
            this.balance = balance;
            this.interestRate = interestRate;
            this.lastTransactionStatus = "No transaction yet";
        }

        
        public virtual string Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                lastTransactionStatus = "Deposit failed because amount must be greater than zero";
            }
            else
            {
                balance = balance + amount;
                lastTransactionStatus = "Deposit successful. Amount deposited: $" + amount;
            }

            return lastTransactionStatus;
        }

        // Withdraw is abstract because each account type has different withdrawal rules.
        public abstract string Withdraw(decimal amount, Customer customer);

        // Interest is abstract because each account type calculates interest differently.
        public abstract string CalculateInterest();

        // This method returns account details to display later in the form.
        public virtual string GetAccountInfo()
        {
            return "Account ID      : " + accountId +
                   "\r\nAccount Name    : " + accountName +
                   "\r\nBalance         : $" + balance +
                   "\r\nInterest Rate   : " + interestRate +
                   "\r\nLast Transaction: " + lastTransactionStatus;
        }

        public override string ToString()
        {
            return accountName + " - Balance: $" + balance;
        }
    }
}