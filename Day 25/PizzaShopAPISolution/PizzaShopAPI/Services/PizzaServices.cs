using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces.Repositories;
using PizzaShopAPI.Interfaces.Services;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly IRepository<int, Pizza> _pizzaRepository;

        public PizzaServices(IRepository<int, Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        #region GetAllPizzaFunction
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            var pizzas = await _pizzaRepository.Get();
            IList<Pizza> result = new List<Pizza>();  
            if(pizzas != null)
            {
                foreach (var pizza in pizzas)
                {
                    if (pizza.Stock > 0)
                    {
                        result.Add(pizza);
                    }
                }
                if (result.Count > 0)
                {
                    return result;
                }
                throw new PizzaOutOfStockException("No Stock Available!");
            }
            throw new NoSuchPizzaException();
        }
        #endregion
    }
}
