using System;
using BankingApplication_Sprint1.Exceptions;

namespace BankingApplication_Sprint1.Models
{
    internal class InvestmentAccount : Account
    {
        private decimal failedTransactionFee;

        public InvestmentAccount() : base()
        {
            accountName = "Investment Account";
            interestRate = 0.03m;
            failedTransactionFee = 10m;
        }

        public InvestmentAccount(string accountId, decimal balance, decimal interestRate)
            : base(accountId, "Investment Account", balance, interestRate)
        {
            failedTransactionFee = 10m;
        }

        public override string Withdraw(decimal amount, Customer customer)
        {
            if (amount <= 0)
            {
                lastTransactionStatus =
                    "Investment Account withdrawal failed because the amount must be greater than zero.";
            }
            else if (amount > balance)
            {
                decimal discount = customer.GetFeeDiscount();
                decimal feeCharged = failedTransactionFee - (failedTransactionFee * discount);

                balance -= feeCharged;

                lastTransactionStatus =
                    $"Investment Account withdrawal failed because the requested amount exceeds the available balance. A failed transaction fee of ${feeCharged:F2} was charged.";

                throw new BankingException(
                    "Investment Account",
                    lastTransactionStatus);
            }
            else
            {
                balance -= amount;

                lastTransactionStatus =
                    $"Investment Account withdrawal successful. Amount withdrawn: ${amount:F2}";
            }

            return lastTransactionStatus;
        }

        public override string CalculateInterest()
        {
            decimal interestAmount = balance * interestRate;

            balance += interestAmount;

            lastTransactionStatus =
                $"Interest added: ${interestAmount:F2}";

            return lastTransactionStatus;
        }
    }
}