using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeServices
    {
        private readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL()
        {
            IRepository<int, Employee> EmployeeRepo = new EmployeeRepository(new RequestTrackerContext());
            _employeeRepository = EmployeeRepo;
        }

        public async Task<Employee> GetEmployeeByID(int id)
        {
            try
            {
                Employee employee = await _employeeRepository.Get(id);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Employee Not Found!");
            }
        }
    }
}
