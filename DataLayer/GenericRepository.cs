using Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : BaseEntity<K>
    {
        protected readonly MainDbContext _context;

        protected GenericRepository(MainDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T,K> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return this;
        }

        public IGenericRepository<T,K> Delete(K id)
        {
            T entity = _context.Set<T>().FirstOrDefault((e) => e.id.Equals(id));
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
            return this;
        }

        public T Get(K id)
        {
            return _context.Set<T>().Find(id);
        }

        public IGenericRepository<T,K> Update(T modifiedEntity)
        {
	        T dbEntity = _context.Set<T>().Find(modifiedEntity.id);
	        
	        _context.Entry(dbEntity)?.CurrentValues.SetValues(modifiedEntity);
            return this;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool SaveChanges() => _context.SaveChanges() > 0;
    }
}
