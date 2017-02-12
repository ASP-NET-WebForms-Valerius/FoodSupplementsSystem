using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface ITopic
    {
        ICollection<Comment> Comments { get; set; }

        string Description { get; set; }

        int Id { get; set; }

        string Name { get; set; }

        ICollection<Supplement> Supplements { get; set; }
    }
}