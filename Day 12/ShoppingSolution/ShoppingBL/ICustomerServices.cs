using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public interface ICustomerServices
    {
        public int CreateNewCustomer(Customer customer);

        public Customer UpdateCustomerName(string customerName, int CustomerId);

        public Customer UpdateCustomerPhNumber(string phoneNumber, int CustomerId);

        public Customer DeleteCustomer(int CustomerId);
    }
}
