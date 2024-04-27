using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBL.Exceptions.CartItemExceptions;

namespace ShoppingBLTest.CartBLTest
{
    public class CartBLRemoveCartItemTest
    {
        AbstractRepository<int, Cart> _cartRepository;
        ICartServices _cartServices;
        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 20, QuantityInHand = 100 };
            Product product1 = new Product() { Id = 2, Image = "img2.jpg", Name = "Puma Bag", Price = 30, QuantityInHand = 200 };
            Product product2 = new Product() { Id = 3, Image = "img3.jpg", Name = "Addidas Bag", Price = 20, QuantityInHand = 300 };
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            List<CartItem> cartItems = new List<CartItem> {
                new CartItem{ CartId=1, Discount=0, Price=60, PriceExpiryDate=DateTime.Now, Product=product, ProductId=1, Quantity=3},
                new CartItem{ CartId=1, Discount=0, Price=90, PriceExpiryDate=DateTime.Now, Product=product1, ProductId=2, Quantity=3},
                new CartItem{ CartId=1, Discount=0, Price=60, PriceExpiryDate=DateTime.Now, Product=product2, ProductId=3, Quantity=3},
                 };
            Cart cart = new Cart()
            {
                Customer = customer,
                CustomerId = 1,
                CartItems = cartItems
            };
            _cartRepository.Add(cart);
            _cartServices = new CartBL(_cartRepository);
        }

        [Test]
        public async Task RemoveFromCartSuccessTest()
        {
            //Arrange
            //Action
            var result = await _cartServices.RemoveItemFromCart(1, 1);
            //Assert
            Assert.That(result.CartItems.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemoveFromCartItemNotExceptionTest()
        {
            //Arrange
            _cartServices.RemoveItemFromCart(1, 1);
            //Action
            var exception = Assert.ThrowsAsync<CartItemNotFoundException>(() => _cartServices.RemoveItemFromCart(1, 1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart Item Not Found!"));
        }

        [Test]
        public void RemoveFromCartNoCartFoundExceptionTest()
        {
            //Arrange

            var exception = Assert.ThrowsAsync<NoCartWithGiveIdException>(() => _cartServices.RemoveItemFromCart(1, 2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart with the given Id is not present"));
        }
    }
}
