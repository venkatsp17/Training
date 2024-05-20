using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeRequestTrackerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }

        #region Login
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.Get();
            User user = userDB.FirstOrDefault(u => u.UserName == loginDTO.UserName) ?? throw new UnauthorizedUserException("Unable to find the user!"); ;
            HMACSHA512 hMACSHA = new HMACSHA512(user.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, user.Password);
            if (isPasswordSame)
            {
                var customer = await _employeeRepo.Get(user.EmployeeId);
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(customer);
                var userstatus = await _userRepo.Get(customer.Id);
                if(userstatus.Status == "Active")
                    return loginReturnDTO;
                else
                {
                    throw new Exception("User is not Activated");
                }
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }
        #endregion


        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        #region Register
        public async Task<RegisterReturnDTO> Register(EmployeeUserDTO employeeUserDTO)
        {
            Employee employee = null;
            User user = null;
            var userDB = await _userRepo.Get();
            User checkuser = userDB.FirstOrDefault(u => u.UserName == employeeUserDTO.UserName);
            if (checkuser != null)
            {
                throw new UnauthorizedUserException("UserName Already exists!");
            }
            try
            {
                employee = MapEmployeeDTOEmployee(employeeUserDTO);
                user = MapEmployeeUserDTOToUser(employeeUserDTO);
                employee = await _employeeRepo.Add(employee);
                user.EmployeeId = employee.Id;
                user = await _userRepo.Add(user);
                return MapReturnDTORegister(employee, user.UserName);
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }
        #endregion

        private RegisterReturnDTO MapReturnDTORegister(Employee employee, string userName)
        {
            RegisterReturnDTO registerReturnDTO = new RegisterReturnDTO();
            registerReturnDTO.Id = employee.Id;
            registerReturnDTO.UserName = userName;
            registerReturnDTO.Name = employee.Name;

            return registerReturnDTO;
        }

        private Employee MapEmployeeDTOEmployee(EmployeeUserDTO employeeUserDTO)
        {
            Employee employee1 = new Employee();
            employee1.Name = employeeUserDTO.Name;
            employee1.Phone = employeeUserDTO.Phone;
            employee1.DateOfBirth = employeeUserDTO.DateOfBirth;
            employee1.Role = employeeUserDTO.Role;
            employee1.Image = employeeUserDTO.Image;

            return employee1;
        }


        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.Delete(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(EmployeeUserDTO employeeDTO)
        {
            User user = new User();
            user.UserName = employeeDTO.UserName;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }

        public async Task<string> UpdateUserAccountStatus(UpdateUserStatusDTO updateStatusDTO)
        {

            var user = await _userRepo.Get(updateStatusDTO.Id);
            if (user == null)
                throw new NoSuchEmployeeException();
            if (user.Status == updateStatusDTO.Status)
                throw new Exception("User is already in same state");
            user.Status = updateStatusDTO.Status;
            var updatedUser = await _userRepo.Update(user);
            if (updatedUser == null)
            {
                if (updateStatusDTO.Status == "Active")
                {
                    throw new Exception("Unable to Activate user at this moment!");
                }
                throw new Exception("Unable to Deactivate user at this moment!");
            }
            if (updateStatusDTO.Status == "Active")
            {
                return "Account Activated Successfully!";
            }
            return "Account Disabled Successfully!";
        }
    }
}
