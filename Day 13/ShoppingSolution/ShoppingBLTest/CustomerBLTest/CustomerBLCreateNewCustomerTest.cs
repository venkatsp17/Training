using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest.CustomerBLTest
{
    public class CustomerBLCreateNewCustomerTest
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
        public async Task CreateNewCustomerSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 32, Name = "John", Phone = "9535353252" };
            //Action
            var result = await _customerServices.CreateNewCustomer(customer);
            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void CreateNewCustomerDuplicatDataExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() {Id=1, Age = 32, Name = "John", Phone = "9535353252" };
            _customerServices.CreateNewCustomer(customer);
            //Action
            var exception = Assert.ThrowsAsync<DuplicateDataFoundException>(() => _customerServices.CreateNewCustomer(customer));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Duplicate Data Found!"));
        }
    }
}
