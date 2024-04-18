using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public interface IDepartmentServices
    {
        public int AddDepartment(Department department);

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName);

        public Department GetDepartmentById(int id);

        public Department GetDepartmentByName(string departmentName);

        public int GetDepartmentHeadId(int departmentId);

        public List<Department> GetDepartmentList();
}
