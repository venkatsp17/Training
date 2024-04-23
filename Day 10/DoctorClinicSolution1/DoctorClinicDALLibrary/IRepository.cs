using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeClassDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        T Get(K key);
        List<T> GetAll();
        T Add(T item);
        T Update(T item);
        T Delete(K key);
    }
}
