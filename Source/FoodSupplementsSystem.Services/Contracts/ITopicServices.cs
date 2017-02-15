using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ITopicsServices
    {
        IQueryable<Topic> GetAll();

        Topic GetById(int id);

        void UpdateById(int id, Topic updateBrand);

        void DeleteById(int id);

        void Create(Topic brand);
    }
}