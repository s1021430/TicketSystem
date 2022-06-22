using System.Collections.Generic;

namespace TicketSystem.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> Get();
        T Get(int id);
    }
}
