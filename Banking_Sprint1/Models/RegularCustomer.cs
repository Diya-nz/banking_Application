using System;

namespace BankingApplication_Sprint1.Models
{
    internal class RegularCustomer : Customer
    {
        public RegularCustomer() : base()  
        {
        }

        public RegularCustomer(string customerNumber, string customerName, string contactDetails)
            : base(customerNumber, customerName, contactDetails)
        {
        }

        public override string GetCustomerRole()
        {
            return "Regular Customer";
        }

        public override decimal GetFeeDiscount()
        {
            return 0m;
        }
    }
}