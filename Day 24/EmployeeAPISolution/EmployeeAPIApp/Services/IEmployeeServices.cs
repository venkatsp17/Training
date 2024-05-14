using EmployeeAPIApp.Models;

namespace EmployeeAPIApp.Services
{
    public interface IEmployeeServices
    {
        public Task<Employee> GetEmployeeByPhone(string phoneNumber);
        public Task<Employee> UpdateEmployeePhone(int id, string phoneNumber);
        public Task<IEnumerable<Employee>> GetEmployees();

    }
}
