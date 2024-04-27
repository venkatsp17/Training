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
    public class CustomerBLUpdateTest
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
        public async Task UpdateCustomerNameSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 32, Name = "John", Phone = "9535353252" };
             await _customerServices.CreateNewCustomer(customer);
            //Action
            var result = await _customerServices.UpdateCustomerName("John S", 1);
            //Assert
            Assert.That(result.Name, Is.EqualTo("John S"));
        }

        [Test]
        public async Task UpdateCustomerPhSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 32, Name = "John", Phone = "9535353252" };
             await _customerServices.CreateNewCustomer(customer);
            //Action
            var result = await _customerServices.UpdateCustomerPhNumber("2223334440", 1);
            //Assert
            Assert.That(result.Phone, Is.EqualTo("2223334440"));
        }

        [Test]
        public async Task UpdateCustomerNotFoundExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() { Id = 1, Age = 32, Name = "John", Phone = "9535353252" };
            await _customerServices.CreateNewCustomer(customer);
            //Action
            var exception = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => _customerServices.UpdateCustomerName("John P",2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Customer with the given Id is not present"));
        }
    }
}
