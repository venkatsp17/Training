using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTO;

namespace PizzaShopAPI.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<RegisterReturnDTO> Register(CustomerUserDTO customerDTO);
    }
}
