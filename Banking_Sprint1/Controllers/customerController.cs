using System;
using System.Collections.Generic;
using BankingApplication_Sprint1.Models;

namespace Banking_Sprint1.Controllers
{
    internal class CustomerController
    {
        private readonly List<Customer> customers;

        public CustomerController()
        {
            customers = new List<Customer>();
            LoadDefaultCustomers();
        }

        // READ: Returns a copy so the Form cannot directly modify the list.
        public List<Customer> GetAllCustomers()
        {
            return new List<Customer>(customers);
        }

        // READ: Returns customers matching the selected role.
        public List<Customer> GetCustomersByRole(string role)
        {
            List<Customer> matchingCustomers = new List<Customer>();

            foreach (Customer customer in customers)
            {
                if (customer.GetCustomerRole()
                    .Equals(role, StringComparison.OrdinalIgnoreCase))
                {
                    matchingCustomers.Add(customer);
                }
            }

            return matchingCustomers;
        }

        // READ: Finds one customer using the customer number.
        public Customer? GetCustomerByNumber(string customerNumber)
        {
            if (string.IsNullOrWhiteSpace(customerNumber))
            {
                return null;
            }

            foreach (Customer customer in customers)
            {
                if (customer.CustomerNumber.Equals(
                    customerNumber.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return customer;
                }
            }

            return null;
        }

        // CREATE: Creates the correct customer type and assigns three accounts.
        public bool CreateCustomer(
            string customerNumber,
            string customerName,
            string contactDetails,
            string customerRole,
            out string message)
        {
            customerNumber = customerNumber?.Trim() ?? string.Empty;
            customerName = customerName?.Trim() ?? string.Empty;
            contactDetails = contactDetails?.Trim() ?? string.Empty;
            customerRole = customerRole?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(customerNumber) ||
                string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(contactDetails) ||
                string.IsNullOrWhiteSpace(customerRole))
            {
                message = "Please complete all customer fields.";
                return false;
            }

            if (GetCustomerByNumber(customerNumber) != null)
            {
                message =
                    "A customer with number " +
                    customerNumber +
                    " already exists.";

                return false;
            }

            Customer newCustomer;

            if (customerRole.Equals(
                "Regular Customer",
                StringComparison.OrdinalIgnoreCase))
            {
                newCustomer = new RegularCustomer(
                    customerNumber,
                    customerName,
                    contactDetails);
            }
            else if (customerRole.Equals(
                "Bank Staff",
                StringComparison.OrdinalIgnoreCase))
            {
                newCustomer = new BankStaff(
                    customerNumber,
                    customerName,
                    contactDetails);
            }
            else
            {
                message = "Please select a valid customer role.";
                return false;
            }

            string accountSuffix =
                CreateAccountSuffix(customerNumber);

            AddDefaultAccounts(
                newCustomer,
                accountSuffix,
                0m,
                0m,
                0m);

            customers.Add(newCustomer);

            message =
                "Customer " +
                customerName +
                " was added successfully.";

            return true;
        }

        // Keeps your original AddCustomer method for reuse and testing.
        public bool AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerNumber) ||
                string.IsNullOrWhiteSpace(customer.CustomerName) ||
                string.IsNullOrWhiteSpace(customer.ContactDetails))
            {
                return false;
            }

            if (GetCustomerByNumber(customer.CustomerNumber) != null)
            {
                return false;
            }

            customers.Add(customer);
            return true;
        }

        // UPDATE: Updates an existing customer's details.
        public bool UpdateCustomer(
            string customerNumber,
            string newCustomerName,
            string newContactDetails,
            out string message)
        {
            Customer? customer =
                GetCustomerByNumber(customerNumber);

            if (customer == null)
            {
                message = "The selected customer could not be found.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(newCustomerName) ||
                string.IsNullOrWhiteSpace(newContactDetails))
            {
                message =
                    "Customer name and contact details are required.";

                return false;
            }

            customer.CustomerName =
                newCustomerName.Trim();

            customer.ContactDetails =
                newContactDetails.Trim();

            message =
                "Customer " +
                customer.CustomerNumber +
                " was updated successfully.";

            return true;
        }

        // DELETE: Deletes a customer using their customer number.
        public bool DeleteCustomer(
            string customerNumber,
            out string message)
        {
            Customer? customer =
                GetCustomerByNumber(customerNumber);

            if (customer == null)
            {
                message = "The selected customer could not be found.";
                return false;
            }

            customers.Remove(customer);

            message =
                "Customer " +
                customer.CustomerNumber +
                " was deleted successfully.";

            return true;
        }

        private string CreateAccountSuffix(string customerNumber)
        {
            string suffix =
                customerNumber.Trim().ToUpper();

            if (suffix.StartsWith("C"))
            {
                suffix = suffix.Substring(1);
            }

            suffix = suffix.Replace(" ", string.Empty);

            return suffix;
        }

        private void LoadDefaultCustomers()
        {
            customers.Clear();

            RegularCustomer customer1 =
                new RegularCustomer(
                    "C001",
                    "John Smith",
                    "john@email.nz");

            RegularCustomer customer2 =
                new RegularCustomer(
                    "C003",
                    "Emma Wilson",
                    "emma@email.nz");

            RegularCustomer customer3 =
                new RegularCustomer(
                    "C004",
                    "Liam Brown",
                    "liam@email.nz");

            BankStaff staff1 =
                new BankStaff(
                    "C002",
                    "Diya Sharma",
                    "diya@email.nz");

            BankStaff staff2 =
                new BankStaff(
                    "C005",
                    "Sarah Taylor",
                    "sarah@email.nz");

            BankStaff staff3 =
                new BankStaff(
                    "C006",
                    "Michael Chen",
                    "michael@email.nz");

            AddDefaultAccounts(
                customer1,
                "001",
                5000m,
                12000m,
                3000m);

            AddDefaultAccounts(
                customer2,
                "003",
                8500m,
                15000m,
                4500m);

            AddDefaultAccounts(
                customer3,
                "004",
                6200m,
                18000m,
                5200m);

            AddDefaultAccounts(
                staff1,
                "002",
                7000m,
                15000m,
                4000m);

            AddDefaultAccounts(
                staff2,
                "005",
                9500m,
                22000m,
                6000m);

            AddDefaultAccounts(
                staff3,
                "006",
                11000m,
                25000m,
                7500m);

            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            customers.Add(staff1);
            customers.Add(staff2);
            customers.Add(staff3);
        }

        private void AddDefaultAccounts(
            Customer customer,
            string accountNumberSuffix,
            decimal everydayBalance,
            decimal investmentBalance,
            decimal omniBalance)
        {
            customer.AddAccount(
                new EverydayAccount(
                    "EA" + accountNumberSuffix,
                    everydayBalance));

            customer.AddAccount(
                new InvestmentAccount(
                    "IA" + accountNumberSuffix,
                    investmentBalance,
                    0.03m));

            customer.AddAccount(
                new OmniAccount(
                    "OA" + accountNumberSuffix,
                    omniBalance,
                    0.04m,
                    1000m));
        }
    }
}