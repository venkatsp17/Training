using EmployeeAPIApp.Models.DTOs;
using EmployeeAPIApp.Models;

namespace EmployeeAPIApp.Services
{
    public interface IUserServices
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
