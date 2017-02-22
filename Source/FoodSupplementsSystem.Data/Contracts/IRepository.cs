using System;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        int SaveChanges();
    }
}
