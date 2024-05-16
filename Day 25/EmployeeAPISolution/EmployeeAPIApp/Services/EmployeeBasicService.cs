using EmployeeAPIApp.Exceptions;
using EmployeeAPIApp.Models;
using EmployeeAPIApp.Repositories;

namespace EmployeeAPIApp.Services
{
    public class EmployeeBasicService : IEmployeeServices
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeBasicService(IRepository<int, Employee> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoEmployeeFoundException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeeFoundException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new NoEmployeeFoundException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
