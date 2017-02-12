using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface IBrand
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<Supplement> Supplements { get; set; }

        string WebSite { get; set; }
    }
}