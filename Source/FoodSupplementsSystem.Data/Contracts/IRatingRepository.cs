using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface IRatingRepository : IRepository<Rating>, IExtendedRepository<Rating>
    {
        //bool PlaceHolder { get; }
    }
}