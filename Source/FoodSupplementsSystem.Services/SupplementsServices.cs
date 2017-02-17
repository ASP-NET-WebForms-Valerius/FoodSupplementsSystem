using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;

namespace FoodSupplementsSystem.Services
{
    public class SupplementsServices : ISupplementsServices
    {
        private readonly SupplementRepository supplementRepository;

        public SupplementsServices(SupplementRepository supplementRepository)
        {
            this.supplementRepository = supplementRepository;
        }

        public Supplement GetById(int id)
        {
            Supplement supplementToReturn = this.supplementRepository.GetById(id);

            return supplementToReturn;
        }

        public IEnumerable<Supplement> GetAll()
        {
            IEnumerable<Supplement> supplementsToReturn = this.supplementRepository.All();

            return supplementsToReturn;
        }

        public virtual IEnumerable<Supplement> GetFilteredByCategory(string categoryName)
        {
            IEnumerable<Supplement> supplementsToReturn = this.supplementRepository.GetFilteredByCategory(categoryName);

            return supplementsToReturn;
        }

        public virtual IEnumerable<Supplement> GetFilteredByTopic(string topicName)
        {
            IEnumerable<Supplement> supplementsToReturn = this.supplementRepository.GetFilteredByTopic(topicName);

            return supplementsToReturn;
        }

        public virtual IEnumerable<Supplement> GetFilteredByBrand(string brandName)
        {
            IEnumerable<Supplement> supplementsToReturn = this.supplementRepository.GetFilteredByBrand(brandName);

            return supplementsToReturn;
        }

        public virtual void Add(Supplement supplement)
        {
            this.supplementRepository.Add(supplement);

            this.supplementRepository.SaveChanges();
        }

        public virtual void Update(Supplement supplement)
        {
            this.supplementRepository.Update(supplement);

            this.supplementRepository.SaveChanges();
        }

        public virtual void Delete(Supplement supplement)
        {
            this.supplementRepository.Delete(supplement);

            this.supplementRepository.SaveChanges();
        }

        public virtual void Delete(int supplementId)
        {
            this.supplementRepository.Delete(supplementId);

            this.supplementRepository.SaveChanges();
        }

        public virtual void Dispose()
        {
            this.supplementRepository.Dispose();
        }
    }
}
