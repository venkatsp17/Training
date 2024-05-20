using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<RegisterReturnDTO> Register(EmployeeUserDTO employeeDTO);
        public Task<string> UpdateUserAccountStatus(UpdateUserStatusDTO updateStatusDTO);
    }
}
