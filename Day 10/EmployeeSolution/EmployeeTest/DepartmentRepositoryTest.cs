using ModeClassDALLibrary;
using ModelClassLib;

namespace EmployeeTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange
            Department department = new Department() { Name = "IT", Department_Head = 1 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.AreEqual(1, result.Id);

        }

        [Test]
        public void AddFailTest()
        {
            //Arrange
            Department department = new Department() { Name = "IT", Department_Head = 1 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 2 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange
            Department department = new Department() { Name = "IT", Department_Head = 1 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 2 };
            //Action
            var result = repository.GetAll();
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllFailTest()
        {
            //Arrange
            //Action
            var result = repository.GetAll();
            //Assert
            Assert.IsNull(result);
        }

        [TestCase(1,"IT",1)]
        [TestCase(1, "ADMIN", 1)]
        public void GetSuccessTest(int id, string department, int departmentId)
        {
            //Arrange
            Department department1 = new Department() { Name = department, Department_Head = departmentId };
            repository.Add(department1);
            //Action
            var result = repository.Get(id);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
    }
}