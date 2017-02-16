using System.Collections.Generic;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface ISupplementRepository
    {
        IEnumerable<Supplement> GetFiltered(string categoryName);
    }
}