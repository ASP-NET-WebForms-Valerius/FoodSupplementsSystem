using System;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Models.Contracts
{
    public interface IComment
    {
        User Author { get; set; }

        string AuthorId { get; set; }

        string Content { get; set; }

        DateTime CreationDate { get; set; }

        int Id { get; set; }

        ICollection<Like> Likes { get; set; }

        Topic Topic { get; set; }

        int TopicId { get; set; }
    }
}