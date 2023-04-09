using System.Collections.Generic;

namespace lab1.Services.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        List<T> Read();
        T Read(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
