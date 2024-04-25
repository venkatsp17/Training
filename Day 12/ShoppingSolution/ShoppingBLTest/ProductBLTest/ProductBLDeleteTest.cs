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
    public class ProductBLDeleteTest
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
        public void DeleteProductSuccessTest()
        {
            // Arrange
            Product product = new Product() { Id = 1, Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            _productServices.CreateNewProduct(product);
            // Action
            var deletedProduct = _productServices.DeleteProduct(1);
            // Assert
            Assert.That(deletedProduct, Is.Not.Null);
        }

        [Test]
        public void DeleteProductNotFoundExceptionTest()
        {
            //Arrange
            //Product product = new Product() { Id = 1, Name = "Product A", Price = 50.99, QuantityInHand = 10 };
            //_productServices.DeleteProduct(1);
            //Action
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => _productServices.DeleteProduct(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Product with the given Id is not present"));
        }
    }
}
