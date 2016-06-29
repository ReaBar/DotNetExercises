using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InnerClass innerClass = new InnerClass();
            List<Customer> customerArray = new List<Customer>();
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Customer customer3 = new Customer();
            Customer customer4 = new Customer();
            customer1.Name = "Rea";
            customer1.ID = 1234;
            customer1.Address = "Tel Aviv";

            customer2.Name = "Bar";
            customer2.ID = 4321;
            customer2.Address = "Kfar Saba";

            customer3.Name = "test";
            customer3.ID = 1;
            customer3.Address = "test";

            customer4.Name = "rea";
            customer4.ID = 123;
            customer4.Address = "Jerusalem";

            customerArray.Add(customer2);
            customerArray.Add(customer4);
            customerArray.Add(customer3);
            customerArray.Add(customer1);

            Console.WriteLine("Customer Array: ");
            innerClass.PrintCustomers(customerArray);
            customer3 = null;

            Console.WriteLine("Filtering customers by name - A to K:");
            CustomFilter filterNameByAtoK = innerClass.FilterCustomersByNameAtoK;
            var filteredCustomers = GetCustomers(customerArray, filterNameByAtoK);
            innerClass.PrintCustomers(filteredCustomers);

            CustomFilter filterNameByLtoZ = delegate (Customer customer)
            {
                var regexItem = new Regex("^[L-Z]");

                if (customer != null && regexItem.IsMatch(customer.Name))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            };
            Console.WriteLine("Filtering customers by name - L to Z:");
            filteredCustomers = GetCustomers(customerArray, filterNameByLtoZ);
            innerClass.PrintCustomers(filteredCustomers);

            CustomFilter filterCustomersById = customer =>
            {
                if (customer != null && customer.ID < 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            Console.WriteLine("Filtering customers by ID lower than 100:");
            filteredCustomers = GetCustomers(customerArray, filterCustomersById);
            innerClass.PrintCustomers(filteredCustomers);
        }

        static ICollection<Customer> GetCustomers(ICollection<Customer> customerCollection, CustomFilter customFilter)
        {
            var filteredCustomers = new List<Customer>();
            foreach (var customer in customerCollection)
            {
                if (customFilter(customer))
                {
                    filteredCustomers.Add(customer);
                }
            }
            return filteredCustomers;
        }
    }

    class InnerClass
    {
        public void PrintCustomers(ICollection<Customer> customersCollection)
        {
            int index = 0;
            if (customersCollection != null)
            {
                foreach (Customer cust in customersCollection)
                {
                    Console.WriteLine("Customer {0} - Name: {1}, ID: {2}, Address: {3}", index++, cust.Name, cust.ID,
                        cust.Address);
                }
            }
        }

        public bool FilterCustomersByNameAtoK(Customer customer)
        {
            var regexItem = new Regex("^[A-K]");

            if (customer != null && regexItem.IsMatch(customer.Name))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}

