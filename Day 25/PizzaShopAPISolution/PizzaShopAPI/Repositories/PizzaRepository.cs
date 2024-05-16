using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces.Repositories;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class PizzaRepository : IRepository<int,  Pizza>
    {
        private readonly PizzaShopContext _context;
        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync(true);
                return pizza;
            }
            throw new NoSuchPizzaException();
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(e => e.PizzaId == key);
            if (pizza != null)
                return pizza;
            throw new NoSuchPizzaException();
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            if (pizzas != null)
                return pizzas;
            throw new NoSuchPizzaException();

        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.PizzaId);
            if (pizza != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return pizza;
            }
            throw new NoSuchPizzaException();
        }
    }
}
