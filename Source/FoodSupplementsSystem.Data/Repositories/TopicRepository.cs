using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Data.Contracts;

namespace FoodSupplementsSystem.Data.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, IRepository<Topic>, ITopicRepository
    {
        public TopicRepository(FoodSupplementsSystemDbContext context) 
            : base(context)
        {
        }
    }
}
