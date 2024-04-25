﻿using ShoppingBL;
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
        public void UpdateCustomerNameSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 32, Name = "John", Phone = "9535353252" };
            _customerServices.CreateNewCustomer(customer);
            //Action
            var result = _customerServices.UpdateCustomerName("John S", 1);
            //Assert
            Assert.That(result.Name, Is.EqualTo("John S"));
        }

        [Test]
        public void UpdateCustomerPhSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 32, Name = "John", Phone = "9535353252" };
            _customerServices.CreateNewCustomer(customer);
            //Action
            var result = _customerServices.UpdateCustomerPhNumber("2223334440", 1);
            //Assert
            Assert.That(result.Phone, Is.EqualTo("2223334440"));
        }

        [Test]
        public void UpdateCustomerNotFoundExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() { Id = 1, Age = 32, Name = "John", Phone = "9535353252" };
            _customerServices.CreateNewCustomer(customer);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => _customerServices.UpdateCustomerName("John P",2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Customer with the given Id is not present"));
        }
    }
}
