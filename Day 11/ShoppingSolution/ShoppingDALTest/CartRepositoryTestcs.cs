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
    public class CartRepositoryTestcs
    {
        AbstractRepository<int, Cart> cartRepository;
        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
        }

        [Test]
        public void GetCartByIdSuccessTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer= new Customer(), CustomerId= 1, CartItems= new List<CartItem>() };
            cartRepository.Add(cart);
            //Action
            var result = cartRepository.GetByKey(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetCartByIdNoCartWithGivenIdExceptionTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            //Action
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => cartRepository.GetByKey(2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart with the given Id is not present"));
        }

        [Test]
        public void DeleteCartByIdSuccessTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            //Action
            var result = cartRepository.Delete(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
        [Test]
        public void DeleteCartByIdExceptionTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            cartRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => cartRepository.Delete(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart with the given Id is not present"));
        }

        [Test]
        public void UpdateCartSuccessTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            //Action
            cart.CustomerId = 2;
            var result = cartRepository.Update(cart);
            //Assert
            Assert.That(result.CustomerId, Is.EqualTo(2));
        }
        [Test]
        public void UpdateCartExceptionTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            cartRepository.Add(cart);
            cartRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => cartRepository.Update(cart));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart with the given Id is not present"));
        }
    }
}
