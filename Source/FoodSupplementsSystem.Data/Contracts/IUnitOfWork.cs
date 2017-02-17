using FoodSupplementsSystem.Data.Repositories;

namespace FoodSupplementsSystem.Data.Contracts
{
    public interface IUnitOfWork
    {
        SupplementRepository SupplementRepository { get; }

        RatingRepository RatingRepository { get; }

        void Save();
    }
}