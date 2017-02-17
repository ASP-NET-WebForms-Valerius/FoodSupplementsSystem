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

        public virtual IEnumerable<Supplement> GetFilteredByCategory(string categoryName)
        {
            IEnumerable<Supplement> supplementsToReturn = null;

            supplementsToReturn = this.DbSet.Where(s => s.Category.Name == categoryName).Select(s => s);

            return supplementsToReturn;
        }

        public virtual IEnumerable<Supplement> GetFilteredByTopic(string topicName)
        {
            IEnumerable<Supplement> supplementsToReturn = null;

            supplementsToReturn = this.DbSet.Where(s => s.Topic.Name == topicName).Select(s => s);

            return supplementsToReturn;
        }

        public virtual IEnumerable<Supplement> GetFilteredByBrand(string brandName)
        {
            IEnumerable<Supplement> supplementsToReturn = null;

            supplementsToReturn = this.DbSet.Where(s => s.Brand.Name == brandName).Select(s => s);

            return supplementsToReturn;
        }
    }
}
