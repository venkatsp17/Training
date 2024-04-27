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
        public Task<int> CreateNewCustomer(Customer customer);

        public Task<Customer> UpdateCustomerName(string customerName, int CustomerId);

        public Task<Customer> UpdateCustomerPhNumber(string phoneNumber, int CustomerId);

        public Task<Customer> DeleteCustomer(int CustomerId);
    }
}
