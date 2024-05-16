using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTO;

namespace PizzaShopAPI.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<Customer> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerUserDTO customerDTO);
    }
}
