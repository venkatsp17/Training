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
    public class ProductRepositoryTest
    {
        AbstractRepository<int, Product> productRepository;
        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository();
        }

        [Test]
        public void GetProductByIdSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            //Action
            var result = productRepository.GetByKey(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void GetProductByIdNoProductWithGivenIdExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            //Action
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => productRepository.GetByKey(2));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Product with the given Id is not present"));
        }

        [Test]
        public void DeleteProductByIdSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            //Action
            var result = productRepository.Delete(1);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
        [Test]
        public void DeleteProductByIdExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            productRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => productRepository.Delete(1));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Product with the given Id is not present"));
        }

        [Test]
        public void UpdateProductSuccessTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            //Action
            product.Name = "Puma";
            var result = productRepository.Update(product);
            //Assert
            Assert.That(result.Name, Is.EqualTo("Puma"));
        }
        [Test]
        public void UpdateProductExceptionTest()
        {
            //Arrange
            Product product = new Product() { Id = 1, Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            productRepository.Delete(1);
            //Action
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => productRepository.Update(product));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Product with the given Id is not present"));
        }
    }
}
