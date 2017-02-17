using System;
using System.Linq;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface IExtendedRepository<T> : IDisposable where T : class
    {
        void Detach(T entity);

        IQueryable<T> ExecuteStoredProcedure(string spName, Object firstParamValue);

        IQueryable<T> ExecuteStoredProcedure(string spName, Object firstParamValue, Object secondParamValue);

        int SaveChanges();
    }
}
