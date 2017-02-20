using System.Collections.Generic;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface IRatingsServices
    {
        IEnumerable<Rating> GetAll();

        IEnumerable<Rating> ExecuteStoredProcedure(string spName, int param1Value);

        IEnumerable<Rating> ExecuteStoredProcedure(string spName, string param1Value, int param2Value);

        Rating GetById(int id);

        void Update(Rating rating);

        void Add(Rating rating);

        void Delete(Rating rating);

        void Delete(int ratingId);

        void Dispose();
    }  
}