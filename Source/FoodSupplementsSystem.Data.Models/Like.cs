using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FoodSupplementsSystem.Data.Models.Contracts;


namespace FoodSupplementsSystem.Data.Models
{
    public class Like : ILike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}
