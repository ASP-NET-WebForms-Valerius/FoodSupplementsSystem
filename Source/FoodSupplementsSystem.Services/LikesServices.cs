using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services
{
    public class LikesServices : ILikesServices
    {
        private IRepository<Like> likes;

        public LikesServices(IRepository<Like> likes)
        {
            this.likes = likes;
        }

        public void ChangeLike(string userId, int commentId)
        {
            var like = this.GetByAuthorIdAndCommentId(userId, commentId);

            like.Value = !like.Value;

            this.likes.SaveChanges();
        }

        public void CreateLike(Like like)
        {
            this.likes.Add(like);
            this.likes.SaveChanges();
        }

        public Like GetByAuthorIdAndCommentId(string userId, int commentId)
        {
            return this.likes.All().FirstOrDefault(x => x.AuthorId == userId && x.CommentId == commentId);
        }
    }
}
