using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Contracts
{
    public interface ICommentsServices
    {
        IQueryable<Comment> GetTop(int count);

        IQueryable<Comment> GetAll();

        Comment GetById(int id);

        void UpdateById(int id, Comment updateComment);

        void DeleteById(int id);

        void Create(Comment comment);
    }
}
