using System;
using System.Collections.Generic;

namespace CustomersApp
{
    class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {

            if ( y == null || x == null ||x.ID > y.ID)
            {
                return 1;
            }
            else if (x.ID < y.ID)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
