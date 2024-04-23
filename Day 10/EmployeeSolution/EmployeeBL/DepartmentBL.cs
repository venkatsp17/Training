using EmployeeBLLibrary;
using EmployeeBLLibrary.Exceptions;
using ModeClassDALLibrary;
using ModelClassLib;

namespace EmployeeBL
{
    public class DepartmentBL: IDepartmentServices
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        //Function to Add Department
        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        //Function to Change Department Name
        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var departments = _departmentRepository.GetAll();
            if(departments != null)
            {
               foreach(var department in departments)
                {
                    if(department.Name == departmentOldName)
                    {
                        department.Name = departmentNewName;
                        _departmentRepository.Update(department);
                    }
                }
            }
            throw new DepartmentNotFoundException();
        }

        //Function to Get Department By ID
        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if(department != null)
            {
                return department;
            }
            throw new DepartmentNotFoundException();
        }

        //Function to Get Department By Name
        public Department GetDepartmentByName(string departmentName)
        {
            var departments = _departmentRepository.GetAll();
            if (departments != null)
            {
                foreach (var department in departments)
                {
                    if (department.Name == departmentName) { return department; }
                }
            }
            throw new DepartmentNotFoundException();
        }

        //Function to Get List of all Departments
        public List<Department> GetDepartmentList()
        {
            var departments = _departmentRepository.GetAll();
            if (departments != null)
            {
                return new List<Department>(departments);
            }
            throw new NoDataAvailableException();
        }

        //Function to Delete Department By Name
        public Department DeleteDepartmentByName(string name) {

            var departments = _departmentRepository.GetAll();
            if(departments != null)
            {
                foreach (var department in departments)
                {
                    if (department.Name == name) {
                        return _departmentRepository.Delete(department.Id);
                    }
                }
            }
            throw new DepartmentNotFoundException();
        }

        //Function to Get Department Head ID
        public int GetDepartmentHeadId(int departmentId)
        {
           var department = _departmentRepository.Get(departmentId);
            if (department != null)
            {
                return department.Department_Head;
            }
            throw new DepartmentNotFoundException();
        }
    }
}
