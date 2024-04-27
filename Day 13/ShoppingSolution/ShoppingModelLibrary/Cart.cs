using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//Navigation property
        public double Total { get; set; } = 0;
        public List<CartItem> CartItems { get; set; }//Navigation property.

        public override string ToString()
        {
            string result =
            "\nCart ID            : " + Id +
            "\nCustomer ID          : " + CustomerId +
            "\nCustomer Name             : " + Customer.Name +
            "\nTotal                     : " + Total +
            "\nCart Items:";
            foreach (var item in CartItems)
            {
                result += item.ToString();
            }
            return result;
        }
        public Cart() { }

        public Cart(int id, int customerId, Customer customer, List<CartItem> cartItems)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
        }
    }
}
