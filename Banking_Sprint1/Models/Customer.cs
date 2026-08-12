using System;
using System.Collections.Generic;

namespace BankingApplication_Sprint1.Models
{
    internal abstract class Customer
    {
        protected string customerNumber;
        protected string customerName;
        protected string contactDetails;
        protected List<Account> accounts;

        public string CustomerNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string ContactDetails
        {
            get { return contactDetails; }
            set { contactDetails = value; }
        }



        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public Customer()
        {
            customerNumber = "C001";
            customerName = "Unknown";
            contactDetails = "Not Provided";
            accounts = new List<Account>();
        }

        public Customer(string customerNumber, string customerName, string contactDetails)
        {
            this.customerNumber = customerNumber;
            this.customerName = customerName;
            this.contactDetails = contactDetails;
            accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public abstract string GetCustomerRole();

        public abstract decimal GetFeeDiscount();


        public virtual string GetCustomerInfo()
        {
            return
                $"Customer Number : {customerNumber}\r\n" +
                $"Customer Name   : {customerName}\r\n" +
                $"Contact Details : {contactDetails}\r\n" +
                $"Customer Role   : {GetCustomerRole()}";
        }

        public override string ToString()
        {
            return customerName + " - " + GetCustomerRole();
        }
    }
}