using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CartItemRepositoryTest
    {
        AbstractRepository<int, CartItem> cartitemRepository;
        [SetUp]
        public void Setup()
        {
            cartitemRepository = new CartItemRepository();
        }

        [Test]
        public void GetCartItemByIdSuccessTest()
        {
            //Arrange
            Product product = new Product() {Id=1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 2, Price = 400, PriceExpiryDate = Convert.ToDateTime("2024-05-21"), Product = product, ProductId = 1, Quantity = 5 };
            cartitemRepository.Add(cartItem);
            //Action
            var result = cartitemRepository.GetByKey(1);
            //Assert
            Assert.That(result.Product.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetCartItemByIdNoCartWithGivenIdExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 2, Price = 400, PriceExpiryDate = Convert.ToDateTime("2024-05-21"), Product = product, ProductId = 1, Quantity = 5 };
            cartitemRepository.Add(cartItem);
            //Action
            var exception = Assert.Throws<NoCartItemWithGivenIdException>(()=> cartitemRepository.GetByKey(2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart Item with the given Id is not present"));
        }

        [Test]
        public void DeleteCartItemByIdSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 2, Price = 400, PriceExpiryDate = Convert.ToDateTime("2024-05-21"), Product = product, ProductId = 1, Quantity = 5 };
            cartitemRepository.Add(cartItem);
            //Action
            var result = cartitemRepository.Delete(1);
            //Assert
            Assert.That(result.Product.Id, Is.EqualTo(1));
        }
        [Test]
        public void DeleteCartItemByIdExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 2, Price = 400, PriceExpiryDate = Convert.ToDateTime("2024-05-21"), Product = product, ProductId = 1, Quantity = 5 };
            cartitemRepository.Add(cartItem);
            cartitemRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoCartItemWithGivenIdException>(() => cartitemRepository.Delete(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart Item with the given Id is not present"));
        }

        [Test]
        public void UpdateCartItemSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 2, Price = 400, PriceExpiryDate = Convert.ToDateTime("2024-05-21"), Product = product, ProductId = 1, Quantity = 5 };
            cartitemRepository.Add(cartItem);
            //Action
            cartItem.Price = 500;
            var result = cartitemRepository.Update(cartItem);
            //Assert
            Assert.That(result.Price, Is.EqualTo(500));
        }
        [Test]
        public void UpdateCartItemExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            CartItem cartItem = new CartItem() { CartId = 1, Discount = 2, Price = 400, PriceExpiryDate = Convert.ToDateTime("2024-05-21"), Product = product, ProductId = 1, Quantity = 5 };
            cartitemRepository.Add(cartItem);
            cartitemRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoCartItemWithGivenIdException>(() => cartitemRepository.Update(cartItem));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart Item with the given Id is not present"));
        }
    }
}
