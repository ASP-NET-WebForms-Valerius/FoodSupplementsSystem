using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;

namespace FoodSupplementsSystem.Data.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRepository<Rating>, IExtendedRepository<Rating>
    {
        public RatingRepository(FoodSupplementsSystemDbContext context)
            : base(context)
        {
        }       
    }
}
