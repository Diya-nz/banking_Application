using System;
using BankingApplication_Sprint1.Exceptions;

namespace BankingApplication_Sprint1.Models
{
    internal class OmniAccount : Account
    {
        private decimal overdraftLimit;
        private decimal failedTransactionFee;

        public OmniAccount() : base()
        {
            accountName = "Omni Account";
            interestRate = 0.04m;
            overdraftLimit = 1000m;
            failedTransactionFee = 15m;
        }

        public OmniAccount(
            string accountId,
            decimal balance,
            decimal interestRate,
            decimal overdraftLimit)
            : base(accountId, "Omni Account", balance, interestRate)
        {
            this.overdraftLimit = overdraftLimit;
            failedTransactionFee = 15m;
        }

        public decimal OverdraftLimit
        {
            get { return overdraftLimit; }
        }

        public override string Withdraw(decimal amount, Customer customer)
        {
            decimal availableFunds = balance + overdraftLimit;

            if (amount <= 0)
            {
                lastTransactionStatus =
                    "Omni Account withdrawal failed because the amount must be greater than zero.";
            }
            else if (amount > availableFunds)
            {
                decimal discount = customer.GetFeeDiscount();

                decimal feeCharged =
                    failedTransactionFee -
                    (failedTransactionFee * discount);

                balance -= feeCharged;

                lastTransactionStatus =
                    $"Omni Account withdrawal failed because the requested amount exceeds the available funds and overdraft limit. A failed transaction fee of ${feeCharged:F2} was charged.";

                throw new BankingException(
                    "Omni Account",
                    lastTransactionStatus);
            }
            else
            {
                balance -= amount;

                lastTransactionStatus =
                    $"Omni Account withdrawal successful. Amount withdrawn: ${amount:F2}";
            }

            return lastTransactionStatus;
        }

        public override string CalculateInterest()
        {
            if (balance > 1000m)
            {
                decimal interestAmount = balance * interestRate;

                balance += interestAmount;

                lastTransactionStatus =
                    $"Interest added: ${interestAmount:F2}";
            }
            else
            {
                lastTransactionStatus =
                    "No interest added because the balance is not over $1000.00.";
            }

            return lastTransactionStatus;
        }
    }
}