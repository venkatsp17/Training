using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return 
                "\nId           : " + Id +
                "\nName         : " + Name +
                "\nPhone        : $" + Phone +
                "\nAge          : " + Age;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }

        public Customer()
        {

        }

        public Customer(int id, string phone, int age, string name)
        {
            Id = id;
            Phone = phone;
            Age = age;
            Name = name;
        }
    }
}
