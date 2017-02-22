using Bytes2you.Validation;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private IRepository<Category> categories;

        public CategoriesServices(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories.All();
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public Category Create(string name)
        {
            Guard.WhenArgument(name, "name").IsNull().Throw();

            var category = new Category() { Name = name };

            this.categories.Add(category);

            this.categories.SaveChanges();

            return category;
        }

        public void UpdateNameById(int id, string name)
        {
            this.categories.GetById(id).Name = name;

            this.categories.SaveChanges();
        }

        public void DeleteId(int id)
        {
            this.categories.Delete(id);

            this.categories.SaveChanges();
        }
    }
}
