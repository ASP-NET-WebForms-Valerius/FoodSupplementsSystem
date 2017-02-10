using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FoodSupplementsSystem.Data.Models.Contracts;
using FoodSupplementsSystem.Data.Models.Constants;

namespace FoodSupplementsSystem.Data.Models
{
    public class Category : ICategory
    {
        private ICollection<Supplement> supplements;

        public Category()
        {
            this.supplements = new HashSet<Supplement>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(Consts.Category.NameMaxLength.Value)]
        public string Name { get; set; }

        public virtual ICollection<Supplement> Supplements
        {
            get { return this.supplements; }
            set { this.supplements = value; }
        }
    }
}
