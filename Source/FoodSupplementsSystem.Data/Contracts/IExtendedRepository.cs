using System;
using System.Data.SqlClient;
using System.Linq;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface IExtendedRepository<T> : IDisposable where T : class
    {
        void Detach(T entity);

        IQueryable<T> ExecuteStoredProcedure(string spName, SqlParameter sqlParam1);

        IQueryable<T> ExecuteStoredProcedure(string spName, SqlParameter sqlParam1, SqlParameter sqlParam2);
    }
}
