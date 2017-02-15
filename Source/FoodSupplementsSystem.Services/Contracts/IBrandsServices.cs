using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface IBrandsServices
    {
        IQueryable<Brand> GetAll();

        Brand GetById(int id);

        void UpdateById(int id, Brand updateBrand);

        void DeleteById(int id);

        void Create(Brand brand);
    }
}
