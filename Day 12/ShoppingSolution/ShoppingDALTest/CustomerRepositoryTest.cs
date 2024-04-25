using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CustomerRepositoryTest
    {
        AbstractRepository<int, Customer> customerRepository;
        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
        }

        [Test]
        public void GetCustomerByIdSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age=30, Name="John", Phone="9434383824" };
            customerRepository.Add(customer);
            //Action
            var result = customerRepository.GetByKey(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetCustomerByIdNoCustomerWithGivenIdExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            customerRepository.Add(customer);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepository.GetByKey(2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Customer with the given Id is not present"));
        }

        [Test]
        public void DeleteCustomerByIdSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            customerRepository.Add(customer);
            //Action
            var result = customerRepository.Delete(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
        [Test]
        public void DeleteCustomerByIdExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            customerRepository.Add(customer);
            customerRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepository.Delete(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Customer with the given Id is not present"));
        }

        [Test]
        public void UpdateCustomerSuccessTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            customerRepository.Add(customer);
            //Action
            customer.Age = 45;
            var result = customerRepository.Update(customer);
            //Assert
            Assert.That(result.Age, Is.EqualTo(45));
        }
        [Test]
        public void UpdateCustomerExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            customerRepository.Add(customer);
            customerRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepository.Update(customer));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Customer with the given Id is not present"));
        }
    }
}
