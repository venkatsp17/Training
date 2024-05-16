using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interfaces.Services
{
    public interface ITokenServices
    {
        public string GenerateToken(Customer customer);
    }
}
