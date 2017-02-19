using FoodSupplementsSystem.Data.Contracts;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, IRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(FoodSupplementsSystemDbContext context) 
            : base(context)
        {

        }
    }
}
