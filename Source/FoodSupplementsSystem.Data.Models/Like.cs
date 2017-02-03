using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSupplementsSystem.Data.Models
{
    public class Like
    {
        public int Id { get; set; }

        public bool Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}
