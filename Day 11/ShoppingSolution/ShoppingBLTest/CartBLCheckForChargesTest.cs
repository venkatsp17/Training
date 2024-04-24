using ShoppingBL;
using ShoppingBL.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLTest
{
    public class Tests
    {
        AbstractRepository<int, Cart> _cartRepository;
        ICartServices _cartServices;
        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
        }

        [Test]
        public void CheckForChargesSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 20, QuantityInHand = 100 };
            Product product1 = new Product() { Id = 2, Image = "img2.jpg", Name = "Puma Bag", Price = 30, QuantityInHand = 200 };
            Product product2 = new Product() { Id = 3, Image = "img3.jpg", Name = "Addidas Bag", Price = 20, QuantityInHand = 300 };
            Customer customer = new Customer() { Age = 30, Name = "John", Phone = "9434383824" };
            List<CartItem> cartItems = new List<CartItem> {
                new CartItem{ CartId=1, Discount=0, Price=60, PriceExpiryDate=DateTime.Now, Product=product, ProductId=1, Quantity=3},
                new CartItem{ CartId=2, Discount=0, Price=90, PriceExpiryDate=DateTime.Now, Product=product1, ProductId=2, Quantity=3},
                new CartItem{ CartId=3, Discount=0, Price=60, PriceExpiryDate=DateTime.Now, Product=product2, ProductId=3, Quantity=3},
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
            var result = _cartServices.CheckForCharges(1);
            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CheckForChargesEmptyCartExceptionTest()
        {
            //Arrange
            Cart cart = new Cart() { Customer = new Customer(), CustomerId = 1, CartItems = new List<CartItem>() };
            _cartRepository.Add(cart);
            _cartServices = new CartBL(_cartRepository);
            //Action
            var exception = Assert.Throws<EmptyCartException>(() => _cartServices.CheckForCharges(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart is Empty"));
        }

        [Test]
        public void CheckForChargesNoCartFoundExceptionTest()
        {
            //Arrange
            _cartServices = new CartBL(_cartRepository);
            //Action
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => _cartServices.CheckForCharges(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Cart with the given Id is not present"));
        }
    }
}