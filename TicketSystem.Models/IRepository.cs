using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Domain
{
    public interface IRepository<T>
    {
        void Load();
        void Save();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> Get();
        T Get(int id);
    }
}
