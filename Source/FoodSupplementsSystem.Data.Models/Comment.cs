using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSupplementsSystem.Data.Models
{
    public class Comment
    {
        private ICollection<Like> likes;

        public Comment()
        {
            this.likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
