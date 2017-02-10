using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FoodSupplementsSystem.Data.Models.Contracts;


namespace FoodSupplementsSystem.Data.Models
{
    public class Category : ICategory
    {
        private ICollection<Supplement> supplements;

        public Category()
        {
            this.supplements = new HashSet<Supplement>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Supplement> Supplements
        {
            get { return this.supplements; }
            set { this.supplements = value; }
        }
    }
}
