using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K,T>: IRepository<K,T>
    {
        protected IList<T> items = new List<T>();

        int GenerateId()
        {
            if (items.Count == 0)
                return 1;
            int id = items.Count;
            return ++id;
        }

        public T Add(T item)
        {
            if (items.Contains(item))
            {
                throw new DuplicateDataFoundException();
            }
            if(typeof(T).Name == "CartItem")
            {
                items.Add(item);
                return item;
            }
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null && idProperty.PropertyType == typeof(int))
            {
                idProperty.SetValue(item, GenerateId());
            }
            else
            {
                throw new InvalidOperationException("Type T must have an integer property named Id.");
            }
            items.Add(item);
            return item;
        }
        public ICollection<T> GetAll()
        {
            List<T> result = items.ToList<T>();
            if(result.Count > 0)
            {
                return result;
            }
            throw new NoDataAvailableException();
        }

        public abstract T Delete(K key);

        public abstract T GetByKey(K key);

        public abstract T Update(T item);
    }
}
