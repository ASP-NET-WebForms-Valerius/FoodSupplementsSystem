using FoodSupplementsSystem.Data.Models;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ICategoriesServices
    {
        IEnumerable<Category> GetAll();

        Category Create(string name);

        void UpdateNameById(int id, string name);

        void DeleteId(int id);

        Category GetById(int id);
    }
}