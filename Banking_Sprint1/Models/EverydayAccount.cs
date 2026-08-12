using System;
using BankingApplication_Sprint1.Exceptions;

namespace BankingApplication_Sprint1.Models
{
    // Child class of Account for an everyday banking account
    internal class EverydayAccount : Account
    {
        public EverydayAccount() : base()
        {
            accountName = "Everyday Account";
            interestRate = 0m;
        }

        // Uses the base constructor from Account.cs
        public EverydayAccount(string accountId, decimal balance)
            : base(accountId, "Everyday Account", balance, 0m)
        {
        }

        // Everyday account has no overdraft and no transaction fee
        public override string Withdraw(decimal amount, Customer customer)
        {
            if (amount <= 0)
            {
                lastTransactionStatus =
                    "Everyday Account withdrawal failed because the amount must be greater than zero.";
            }
            else if (amount > balance)
            {
                lastTransactionStatus =
                    "Everyday Account withdrawal failed because the requested amount exceeds the available balance.";

                throw new BankingException(
                    "Everyday Account",
                    lastTransactionStatus);
            }
            else
            {
                balance -= amount;

                lastTransactionStatus =
                    $"Everyday Account withdrawal successful. Amount withdrawn: ${amount:F2}";
            }

            return lastTransactionStatus;
        }

        // Everyday account does not earn interest
        public override string CalculateInterest()
        {
            lastTransactionStatus =
                "Everyday Account does not earn interest.";

            return lastTransactionStatus;
        }
    }
}