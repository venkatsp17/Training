using ShoppingBL;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingDALLibrary;

namespace ShoppingBLTest.ProductBLTest
{
    public class ProductBLCreateProductTest
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
        public async Task CreateNewProductSuccessTest()
        {
            // Arrange
            Product product = new Product() { Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            // Action
            var result = await _productServices.CreateNewProduct(product);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task CreateNewProductDuplicateDataExceptionTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            await _productServices.CreateNewProduct(product);
            // Action and Assert
            var exception = Assert.ThrowsAsync<DuplicateDataFoundException>(() => _productServices.CreateNewProduct(product));
            Assert.That(exception.Message, Is.EqualTo("Duplicate Data Found!"));
        }
    }
}
