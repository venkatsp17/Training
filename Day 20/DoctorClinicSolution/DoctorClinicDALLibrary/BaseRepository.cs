using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorClinicDALLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ModeClassDALLibrary
{
    public class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class
    {
        protected readonly DoctorClinicContext _context;

        public BaseRepository(DoctorClinicContext context)
        {
            _context = context;
        }

        public async virtual Task<TEntity> Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async virtual Task<TEntity> Delete(TKey key)
        {
            var entity = await Get(key);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async virtual Task<TEntity> Get(TKey key)
        {
            return await _context.Set<TEntity>().FindAsync(key);
        }

        public async virtual Task<IList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
