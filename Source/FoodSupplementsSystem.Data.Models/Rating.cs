using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FoodSupplementsSystem.Data.Models.Contracts;
using FoodSupplementsSystem.Data.Models.Constants;


namespace FoodSupplementsSystem.Data.Models
{
    public class Rating : IRating
    {
        public int Id { get; set; }

        [Required]
        [Range(Consts.Rating.Value.Min, Consts.Rating.Value.Max, ErrorMessage = Consts.Rating.Value.ErrorMessage)]
        public int Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int SupplementId { get; set; }

        [ForeignKey("SupplementId")]
        public virtual Supplement Supplement { get; set; }
    }
}
