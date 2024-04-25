using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBL.Exceptions.CartExceptions;

namespace ShoppingBLTest.CartBLTest
{
    public class CartBLCheckForDiscountTest
    {
        AbstractRepository<int, Cart> _cartRepository;
        ICartServices _cartServices;
        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
        }

        [Test]
        public void CheckForDiscountSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            Product product1 = new Product() { Id = 2, Image = "img2.jpg", Name = "Puma Bag", Price = 300, QuantityInHand = 200 };
            Product product2 = new Product() { Id = 3, Image = "img3.jpg", Name = "Addidas Bag", Price = 200, QuantityInHand = 300 };
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            List<CartItem> cartItems = new List<CartItem> {
                new CartItem{ CartId=1, Discount=0, Price=2000, PriceExpiryDate=DateTime.Now, Product=product, ProductId=1, Quantity=1},
                new CartItem{ CartId=2, Discount=0, Price=900, PriceExpiryDate=DateTime.Now, Product=product1, ProductId=2, Quantity=3},
                new CartItem{ CartId=3, Discount=0, Price=600, PriceExpiryDate=DateTime.Now, Product=product2, ProductId=3, Quantity=3},
                 };
            Cart cart = new Cart()
            {
                Customer = customer,
                CustomerId = 1,
                CartItems = cartItems
            };
            _cartRepository.Add(cart);
            _cartServices = new CartBL(_cartRepository);
            //Action
            var result = _cartServices.CheckForDiscount(1);
            //Assert
            Assert.That(result, Is.EqualTo(cart));
        }

        [Test]
        public void CheckForDiscountEmptyCartExceptionTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            _cartRepository.Add(cart);
            _cartServices = new CartBL(_cartRepository);
            //Action
            var exception = Assert.Throws<EmptyCartException>(() => _cartServices.CheckForDiscount(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart is Empty"));
        }

        [Test]
        public void CheckForDiscountNoCartFoundExceptionTest()
        {
            //Arrange
            _cartServices = new CartBL(_cartRepository);
            //Action
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => _cartServices.CheckForDiscount(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart with the given Id is not present"));
        }
    }
}
