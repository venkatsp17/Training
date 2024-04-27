using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest.CustomerBLTest
{
    public class CustomerBLDeleteCustomerTest
    {
        AbstractRepository<int, Customer> _customerRepository;
        ICustomerServices _customerServices;
        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customerServices = new CustomerBL(_customerRepository);
        }

        [Test]
        public async Task DeleteCustomerSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 32, Name = "John", Phone = "9535353252" };
            await _customerServices.CreateNewCustomer(customer);
            //Action
            var result = await _customerServices.DeleteCustomer(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void DeleteCustomerNotFoundExceptionTest()
        {
            //Arrange

            //Action
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => _customerServices.DeleteCustomer(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Customer with the given Id is not present"));
        }
    }
}
