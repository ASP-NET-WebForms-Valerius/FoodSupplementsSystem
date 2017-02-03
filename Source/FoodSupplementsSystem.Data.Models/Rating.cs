using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSupplementsSystem.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating cannot be less than 1 or more than 5 inclusive")]
        public int Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int SupplementId { get; set; }

        [ForeignKey("SupplementId")]
        public virtual Supplement Supplement { get; set; }
    }
}
