using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Data.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
