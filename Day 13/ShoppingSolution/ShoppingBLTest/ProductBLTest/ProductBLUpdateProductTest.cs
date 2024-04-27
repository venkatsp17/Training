using ShoppingBL;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest.ProductBLTest
{
    public class ProductBLUpdateProductTest
    {
        AbstractRepository<int, Product> _productRepository;
        IProductServices _productServices;
        [SetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository();
            _productServices = new ProductBL(_productRepository);
        }

        [Test]
        public async Task UpdateProductPriceSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            await _productServices.CreateNewProduct(product);
            // Action
            var updatedProduct =await _productServices.UpdateProductPrice(60.99, 1);
            // Assert
            Assert.That(updatedProduct.Price, Is.EqualTo(60.99));
        }

        [Test]
        public async Task UpdateProductQuantitySuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            await _productServices.CreateNewProduct(product);
            // Action
            var updatedProduct = await _productServices.UpdateProductQuantity(15, 1);
            // Assert
            Assert.That(updatedProduct.QuantityInHand, Is.EqualTo(15));
        }

        [Test]
        public async Task UpdateProductNotFoundExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            await _productServices.CreateNewProduct(product);
            //Action
            var exception = Assert.ThrowsAsync<NoProductWithGivenIdException>(() => _productServices.UpdateProductPrice(52.43, 2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Product with the given Id is not present"));
        }
    }
}
