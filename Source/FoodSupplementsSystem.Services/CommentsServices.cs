using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services
{
    public class CommentsServices : ICommentsServices
    {
        private IRepository<Comment> comments;

        public CommentsServices(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }

        public IQueryable<Comment> GetTop(int count)
        {
            return this.comments.All().OrderByDescending(x => x.Likes.Count()).Take(count);
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }

        public void Create(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public void UpdateById(int id, Comment updateComment)
        {
            var commentToUpdate = this.comments.GetById(id);

            commentToUpdate.TopicId = updateComment.TopicId;
            commentToUpdate.Content = updateComment.Content;

            this.comments.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.comments.Delete(id);
            this.comments.SaveChanges();
        }
    }
}
