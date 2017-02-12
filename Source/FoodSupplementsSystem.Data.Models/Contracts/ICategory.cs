using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<Supplement> Supplements { get; set; }
    }
}