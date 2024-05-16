using PizzaShopAPI.Models;

namespace PizzaShopAPI.Interfaces.Services
{
    public interface IPizzaServices
    {
        public Task<IEnumerable<Pizza>> GetPizzas();
    }
}
