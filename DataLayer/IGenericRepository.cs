using System.Collections.Generic;

namespace DataLayer
{
    public interface IGenericRepository<T, K>
    {
        IGenericRepository<T,K> Add(T entity);
        IGenericRepository<T,K> Update(T entity);
        T Get(K id);
        IGenericRepository<T,K> Delete(K id);
        List<T> GetAll();

        bool SaveChanges();
    }
}
