using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;

namespace FoodSupplementsSystem.Data.Repositories
{
    public class SupplementRepository : GenericRepository<Supplement>, IRepository<Supplement>, ISupplementRepository
    {
        public SupplementRepository(FoodSupplementsSystemDbContext contex) 
            : base(contex)
        {
        }

        public virtual IEnumerable<Supplement> GetFiltered(string categoryName)
        {
            IEnumerable<Supplement> supplementsToReturn = null;

            supplementsToReturn = this.DbSet.Where(s => s.Category.Name == categoryName).Select(s => s);

            return supplementsToReturn;
        }
    }
}
