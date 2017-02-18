using System.Collections.Generic;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services
{
    public interface IRatingsServices
    {
        void Add(Rating rating);
        void Delete(Rating rating);
        void Delete(int ratingId);
        void Dispose();
        IEnumerable<Rating> GetAll();
        Rating GetById(int id);
        void Update(Rating rating);
    }
}