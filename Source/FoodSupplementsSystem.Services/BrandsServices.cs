using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services
{
    public class BrandsServices : IBrandsServices
    {
        private IRepository<Brand> brands;

        public BrandsServices(IRepository<Brand> brands)
        {
            this.brands = brands;
        }

        public IQueryable<Brand> GetAll()
        {
            return this.brands.All();
        }

        public Brand GetById(int id)
        {
            return this.brands.GetById(id);
        }

        public void Create(Brand brand)
        {
            this.brands.Add(brand);
            this.brands.SaveChanges();
        }

        public void UpdateById(int id, Brand updateBrand)
        {
            var brandToUpdate = this.brands.GetById(id);

            brandToUpdate.Name = updateBrand.Name;
            brandToUpdate.WebSite = updateBrand.WebSite;

            this.brands.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.brands.Delete(id);
            this.brands.SaveChanges();
        }
    }
}
