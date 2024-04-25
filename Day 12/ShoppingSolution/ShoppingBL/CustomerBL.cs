using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public class CustomerBL : ICustomerServices
    {
        readonly AbstractRepository<int, Customer>  _customerRepository;
        public CustomerBL(AbstractRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int CreateNewCustomer(Customer customer)
        {
            var result = _customerRepository.Add(customer);
            if(result!=null)
            {
                return result.Id;
            }
            throw new DuplicateDataFoundException();
        }

        public Customer DeleteCustomer(int CustomerId)
        {
            var result = _customerRepository.GetByKey(CustomerId);
            if (result != null)
            {
                return _customerRepository.Delete(CustomerId);
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer UpdateCustomerName(string customerName, int CustomerId)
        {
            var result = _customerRepository.GetByKey(CustomerId);
            if (result != null)
            {
                result.Name = customerName;
                return _customerRepository.Update(result);
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer UpdateCustomerPhNumber(string phoneNumber, int CustomerId)
        {
            var result = _customerRepository.GetByKey(CustomerId);
            if (result != null)
            {
                result.Phone = phoneNumber;
                return _customerRepository.Update(result);
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
