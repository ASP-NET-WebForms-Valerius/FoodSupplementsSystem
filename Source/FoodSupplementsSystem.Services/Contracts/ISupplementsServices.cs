using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodSupplementsSystem.Data.Models;


namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ISupplementsServices
    {
        void Add(Supplement supplement);
        void Delete(Supplement supplement);
        void Delete(int supplementId);
        void Dispose();

        IEnumerable<Supplement> GetAll();
        Supplement GetById(int id);
        IEnumerable<Supplement> GetFilteredByCategory(string categoryName);
        IEnumerable<Supplement> GetFilteredByTopic(string topicName);
        IEnumerable<Supplement> GetFilteredByBrand(string brandName);

        void Update(Supplement supplement);
    }
}
