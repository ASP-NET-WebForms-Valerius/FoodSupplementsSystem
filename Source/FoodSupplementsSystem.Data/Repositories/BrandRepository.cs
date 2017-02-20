using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Contracts;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;

namespace FoodSupplementsSystem.Data.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IRepository<Brand>, IBrandRepository
    {
        public BrandRepository(FoodSupplementsSystemDbContext context) 
            : base(context)
        {
        }
    }
}
