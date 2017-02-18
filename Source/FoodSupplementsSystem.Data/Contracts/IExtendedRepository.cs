using System;
using System.Linq;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface IExtendedRepository<T> : IDisposable where T : class
    {
        void Detach(T entity);

        IQueryable<T> ExecuteStoredProcedure(string spName, Object param1Value);

        IQueryable<T> ExecuteStoredProcedure(string spName, Object param1Value, Object param2Value);

        int SaveChanges();
    }
}
