using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingDALTest
{
    public class Tests
    {
        AbstractRepository<int, Product> productRepository;
        [SetUp]
        public void Setup()
        {
           productRepository = new ProductRepository();
        }

        [Test]
        public void AddSuccessTest()
        {   //Arrange
            Product product = new Product() { Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            //Action
            var result = productRepository.Add(product);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));   
        }
        [Test]
        public void AddFailTest()
        {   //Arrange
            Product product = new Product() { Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            //Action
            var result = productRepository.Add(product);
            //Assert
            Assert.AreNotEqual(result.Id, 2);
        }
        [Test]
        public void AddDuplicateDataFoundExceptionTest()
        {
            //Arrange
            Product product = new Product() { Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            //Action
            var exception = Assert.Throws<DuplicateDataFoundException>(()=>productRepository.Add(product));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Duplicate Data Found!"));
        }
        [Test]
        public void AddInvalidOperationExceptionTest()
        {
            //Arrange
            var repository = new TestRepository();
            var itemWithoutId = new ItemWithoutId();
            //Action
            var exception = Assert.Throws<InvalidOperationException>(() => repository.Add(itemWithoutId));
            //Assert
            Assert.That(exception.Message, Is.EqualTo("Type T must have an integer property named Id."));
        }

        [Test]
        public void GetAllSuccessTest()
        {   //Arrange
            Product product = new Product() { Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            product = new Product() { Image = "img1.jpg", Name = "Nike Bag", Price = 2000, QuantityInHand = 100 };
            productRepository.Add(product);
            //Action
            var result = productRepository.GetAll();
            //Assert
            Assert.That(result.FirstOrDefault(p => p.Id == 2), Is.EqualTo(product));
        }

        [Test]
        public void GetAllNoDataAvailableExceptionTest()
        {   //Arrange
       
            //Action
            var exception = Assert.Throws<NoDataAvailableException>(() => productRepository.GetAll());
            //Assert
            Assert.That(exception.Message, Is.EqualTo("No Data Available!"));
        }
    }
    [ExcludeFromCodeCoverage]
    public class TestRepository : AbstractRepository<int, ItemWithoutId>
    {
        public override ItemWithoutId Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override ItemWithoutId GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public override ItemWithoutId Update(ItemWithoutId item)
        {
            throw new NotImplementedException();
        }
    }
    [ExcludeFromCodeCoverage]
    // A dummy class representing an item without an Id property
    public class ItemWithoutId
    {
        public int SomeProperty { get; set; }

        public ItemWithoutId() { 
        
        }
    }
}