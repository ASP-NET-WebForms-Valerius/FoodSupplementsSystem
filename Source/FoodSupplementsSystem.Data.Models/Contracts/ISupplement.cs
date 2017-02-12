using System;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface ISupplement
    {
        User Author { get; set; }

        string AuthorId { get; set; }

        Brand Brand { get; set; }

        int BrandId { get; set; }

        Category Category { get; set; }

        int CategoryId { get; set; }

        DateTime CreationDate { get; set; }

        string Description { get; set; }
        int Id { get; set; }

        string ImageUrl { get; set; }

        string Ingredients { get; set; }

        string Name { get; set; }

        ICollection<Rating> RatingsReceived { get; set; }

        Topic Topic { get; set; }

        int TopicId { get; set; }

        string Use { get; set; }
    }
}