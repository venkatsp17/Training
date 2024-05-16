using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces.Repositories;
using PizzaShopAPI.Models;

namespace PizzaShopAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaShopContext _context;
        public CustomerRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync(true);
                return customer;
            }
            throw new NoSuchCustomerException();
        }

        public async Task<Customer> Get(int key)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(e => e.Id == key);
            if(customer!=null)
                return customer;
            throw new NoSuchCustomerException();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            if (customers != null)
                return customers;
            throw new NoSuchCustomerException();

        }

        public async Task<Customer> Update(Customer item)
        {
            var customer = await Get(item.Id);
            if (customer != null)
            {
                _context.Update(item);
                 await _context.SaveChangesAsync(true);
                return customer;
            }
            throw new NoSuchCustomerException();
        }
    }
}
