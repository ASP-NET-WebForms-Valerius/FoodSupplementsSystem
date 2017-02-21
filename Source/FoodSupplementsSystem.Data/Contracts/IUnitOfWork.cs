using FoodSupplementsSystem.Data.Repositories;

namespace FoodSupplementsSystem.Data.Contracts
{
    public interface IUnitOfWork
    {
        SupplementRepository SupplementRepository { get; }

        RatingRepository RatingRepository { get; }

        CategoryRepository CategoryRepository { get; }

        TopicRepository TopicRepository { get; }
        
        BrandRepository BrandRepository { get; }

        void Save();
    }
}

