using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Services.Contracts;
using Microsoft.AspNet.Identity;
using System;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Controls
{
    public partial class LikeHateControl : UserControl
    {
        //[Inject]
        //public ILikesServices LikesServices { get; set; }

        public ILikesServices LikesServices { get; set; } =
            new LikesServices(new GenericRepository<Like>(new FoodSupplementsSystemDbContext()));

        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Page.User.Identity.GetUserId();
            var commentedId = int.Parse(this.Request.QueryString["id"]);
            var like = this.LikesServices.GetByAuthorIdAndCommentId(userId, commentedId);

            if (like == null)
            {
                return;
            }

            (like.Value ? this.btnLike : this.btnHate).Visible = false;
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            this.HandleLikeEvent(true);
        }

        protected void btnHate_Click(object sender, EventArgs e)
        {
            this.HandleLikeEvent(false);
        }

        private void HandleLikeEvent(bool isLike)
        {
            var userId = Page.User.Identity.GetUserId();
            var commentedId = int.Parse(this.Request.QueryString["id"]);
            var like = this.LikesServices.GetByAuthorIdAndCommentId(userId, commentedId);

            if (like != null)
            {
                this.LikesServices.ChangeLike(userId, commentedId);
                (like.Value ? this.btnLike : this.btnHate).Visible = false;
                (!like.Value ? this.btnLike : this.btnHate).Visible = true;
            }
            else
            {
                var createdLike = new Like()
                {
                    AuthorId = Page.User.Identity.GetUserId(),
                    CommentId = int.Parse(this.Request.QueryString["id"]),
                    Value = isLike
                };
                this.LikesServices.CreateLike(createdLike);

                (createdLike.Value ? this.btnLike : this.btnHate).Visible = false;
                (!createdLike.Value ? this.btnLike : this.btnHate).Visible = true;
            }
        }
    }
}