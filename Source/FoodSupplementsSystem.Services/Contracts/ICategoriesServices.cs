using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ICategoriesServices
    {
        IQueryable<Category> GetAll();

        Category Create(string name);

        void UpdateNameById(int id, string name);

        void DeleteId(int id);
    }
}