using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementDAL
{
    public class ExpenseRepository : IRepository<int, Expense>
    {
        readonly Dictionary<int, Expense> _expenses;
        public ExpenseRepository()
        {
            _expenses = new Dictionary<int, Expense>();
        }

        int GenerateId()
        {
            if (_expenses.Count == 0)
                return 1;
            int id = _expenses.Keys.Max();
            return ++id;
        }

        public Expense Add(Expense item)
        {
            if (_expenses.ContainsValue(item))
            {
                return null;
            }
            item.ExpenseId = GenerateId();
            _expenses.Add(item.ExpenseId, item);
            return item;
        }

        public Expense Delete(int key)
        {
            if (_expenses.ContainsKey(key))
            {
                var department = _expenses[key];
                _expenses.Remove(key);
                return department;
            }
            return null;
        }

        public Expense Get(int key)
        {
            return _expenses.ContainsKey(key) ? _expenses[key] : null;
        }

        public List<Expense> GetAll()
        {
            if (_expenses.Count == 0)
                return null;
            return _expenses.Values.ToList();
        }

        public Expense Update(Expense item)
        {
            if (_expenses.ContainsKey(item.ExpenseId))
            {
                _expenses[item.ExpenseId] = item;
                return item;
            }
            return null;
        }
    }
}
