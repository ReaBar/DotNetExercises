using System;

namespace CustomersApp
{
    public delegate bool CustomFilter(Customer customer);

    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ID { get; set; }

        public int CompareTo(Customer other)
        {
            if(this == null && other == null)
            {
                return 0;
            }

            else if(this == null)
            {
                return -1;
            }

            else if(other == null)
            {
                return 1;
            }
            return String.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(Customer other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.ID.Equals(other.ID) && this.Name.Equals(other.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Customer)
            {
                return Equals((Customer)obj);
            }
            else
            {
                return false;
            }
        }
    }
}
