using FoodSupplementsSystem.Data.Models;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ICommentsServices
    {
        IEnumerable<Comment> GetTop(int count);

        IEnumerable<Comment> GetAll();

        Comment GetById(int id);

        void UpdateById(int id, Comment updateComment);

        void DeleteById(int id);

        void Create(Comment comment);
    }
}
