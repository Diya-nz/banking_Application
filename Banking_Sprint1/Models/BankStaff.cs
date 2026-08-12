using System;

namespace BankingApplication_Sprint1.Models
{
    internal class BankStaff : Customer
    {
        public BankStaff() : base()
        {
        }

        public BankStaff(string customerNumber, string customerName, string contactDetails)
            : base(customerNumber, customerName, contactDetails)
        {
        }

        public override string GetCustomerRole()
        {
            return "Bank Staff";
        }

        public override decimal GetFeeDiscount()
        {
            return 0.5m;
        }
    }
}