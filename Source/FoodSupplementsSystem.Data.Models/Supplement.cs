using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSupplementsSystem.Data.Models
{
    public class Supplement
    {
        private ICollection<Rating> ratingsReceived;

        public Supplement()
        {
            this.ratingsReceived = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
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
