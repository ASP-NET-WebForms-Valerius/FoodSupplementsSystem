using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FoodSupplementsSystem.Data.Models.Contracts;
using FoodSupplementsSystem.Data.Models.Constants;

namespace FoodSupplementsSystem.Data.Models
{
    public class Supplement : ISupplement
    {
        private ICollection<Rating> ratingsReceived;

        public Supplement()
        {
            this.ratingsReceived = new HashSet<Rating>();
        }

        [Key]
        public int? Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(Consts.Supplement.NameMaxLength.Value)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Use { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Rating> RatingsReceived
        {
            get { return this.ratingsReceived; }
            set { this.ratingsReceived = value; }
        }
    }
}
