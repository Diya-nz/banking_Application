using System;

namespace BankingApplication_Sprint1.Exceptions
{
    public class BankingException : Exception
    {
        public string AccountType { get; }

        public BankingException(string accountType, string message)
            : base(message)
        {
            AccountType = accountType;
        }
    }
}