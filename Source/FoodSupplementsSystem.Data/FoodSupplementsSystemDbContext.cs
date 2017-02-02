using FoodSupplementsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodSupplementsSystem.Data
{
    public class FoodSupplementsSystemDbContext : IdentityDbContext<User>, IFoodSupplementsSystemDbContext
    {
        public FoodSupplementsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static FoodSupplementsSystemDbContext Create()
        {
            return new FoodSupplementsSystemDbContext();
        }
    }
}
