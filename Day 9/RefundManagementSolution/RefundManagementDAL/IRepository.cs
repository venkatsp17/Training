using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementDAL
{
    public interface IRepository<K, T> where T : class
    {
        List<T> GetAll();
        T Get(K key);
        T Add(T item);
        T Delete(K key);
        T Update(T item);

    }
}
