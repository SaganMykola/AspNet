using System.Collections.Generic;

namespace lab2.Services.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        List<T> Read(T filterBy, string orderBy, string order, int page, int perPage);
        List<T> Read();
        T Read(int id);
        void Update(T entity);
        void Delete(int id);
        int Count(T filterBy);
    }
}
