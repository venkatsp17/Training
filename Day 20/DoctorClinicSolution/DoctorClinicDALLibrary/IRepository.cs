using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeClassDALLibrary
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Get(K key);
        Task<IList<T>> GetAll();
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(K key);
    }
}
