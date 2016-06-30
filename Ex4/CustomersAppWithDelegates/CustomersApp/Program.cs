using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            List<Customer> customerArray = new List<Customer>();
            Customer customer1 = new Customer("Rea","Tel Aviv",1234);
            Customer customer2 = new Customer("Bar","Kfar Saba", 4321);
            Customer customer3 = new Customer("test","test",1);
            Customer customer4 = new Customer("rea","Jerusalem",123);

            customerArray.Add(customer2);
            customerArray.Add(customer4);
            customerArray.Add(customer3);
            customerArray.Add(customer1);

            Console.WriteLine("Customer Array: ");
            program.PrintCustomers(customerArray);
            customer3 = null;

            Console.WriteLine("Filtering customers by name - A to K:");
            CustomFilter filterNameByAtoK = program.FilterCustomersByNameAtoK;
            var filteredCustomers = GetCustomers(customerArray, filterNameByAtoK);
            program.PrintCustomers(filteredCustomers);

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
            program.PrintCustomers(filteredCustomers);

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
            program.PrintCustomers(filteredCustomers);
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

