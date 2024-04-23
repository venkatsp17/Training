using EmployeeBL;
using EmployeeBLLibrary;
using EmployeeBLLibrary.Exceptions;
using ModeClassDALLibrary;
using ModelClassLib;

namespace BLTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        IDepartmentServices departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            departmentService = new DepartmentBL(repository);
        }

        [Test]
        public void GetDepartmnetByNameTest()
        {
            //Action
            var department = departmentService.GetDepartmentByName("IT");
            //Assert
            Assert.AreEqual(1, department.Id);
        }
        [Test]
        public void GetDepartmnetByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DepartmentNotFoundException>(() => departmentService.GetDepartmentByName("Admin"));
            //Assert
            Assert.AreEqual("Department Not Found", exception.Message);
        }
    }
}