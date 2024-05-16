using PizzaShopAPI.Interfaces.Repositories;
using PizzaShopAPI.Models.DTO;
using PizzaShopAPI.Models;
using System.Security.Cryptography;
using System.Text;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace PizzaShopAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Customer> _customerRepo;
        private readonly ITokenServices _tokenservices;

        public UserServices(IRepository<int, User> userRepo, IRepository<int, Customer> customerRepo, ITokenServices tokenservices)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
            _tokenservices = tokenservices;
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
                var customer = await _customerRepo.Get(user.CustomerId);
                LoginReturnDTO loginReturnDTO = MapCustomerToLoginReturn(customer);
                return loginReturnDTO;
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }
        #endregion

        #region ComparePassword
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
        #endregion

        #region Register
        public async Task<RegisterReturnDTO> Register(CustomerUserDTO customerDTO)
        {
            Customer customer = null;
            User user = null;
            var userDB = await _userRepo.Get();
            User checkuser = userDB.FirstOrDefault(u => u.UserName == customerDTO.UserName);
            if (checkuser != null)
            {
                throw new UnauthorizedUserException("UserName Already exists!");
            }
            try
            {
                customer = customerDTO;
                user = MapCustomerUserDTOToUser(customerDTO);
                customer = await _customerRepo.Add(customer);
                user.CustomerId = customer.Id;
                user = await _userRepo.Add(user);
                return MapReturnDTORegister(customer,user.UserName);
            }
            catch (Exception) { }
            if (customer != null)
                await RevertCustomerInsert(customer);
            if (user != null && customer == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }
        #endregion
        private async Task RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.CustomerId);
        }

        private async Task RevertCustomerInsert(Customer customer)
        {
            await _customerRepo.Delete(customer.Id);
        }

        private User MapCustomerUserDTOToUser(CustomerUserDTO customerDTO)
        {
            User user = new User();
            user.CustomerId = customerDTO.Id;
            user.Status = "Disabled";
            user.UserName = customerDTO.UserName;
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customerDTO.Password));
            return user;
        }

        public RegisterReturnDTO MapReturnDTORegister(Customer customer, string userName)
        {
            RegisterReturnDTO customerReturnDTO = new RegisterReturnDTO();
            customerReturnDTO.Id = customer.Id;
            customerReturnDTO.UserName = userName;
            customerReturnDTO.Name = customer.Name;

            return customerReturnDTO;
        }

        private LoginReturnDTO MapCustomerToLoginReturn(Customer customer)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.CustomerID = customer.Id;
            returnDTO.Token = _tokenservices.GenerateToken(customer);
            return returnDTO;
        }
    }
}
