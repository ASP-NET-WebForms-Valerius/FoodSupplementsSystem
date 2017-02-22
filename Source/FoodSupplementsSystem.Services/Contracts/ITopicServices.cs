using FoodSupplementsSystem.Data.Models;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ITopicsServices
    {
        IEnumerable<Topic> GetAll();

        Topic GetById(int id);

        void UpdateById(int id, Topic updateBrand);

        void DeleteById(int id);

        void Create(Topic brand);
    }
}