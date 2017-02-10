using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using FoodSupplementsSystem.Data.Models.Contracts;
using FoodSupplementsSystem.Data.Models.Constants;

namespace FoodSupplementsSystem.Data.Models
{
    public class Brand : IBrand
    {
        private ICollection<Supplement> supplements;

        public Brand()
        {
            this.supplements = new HashSet<Supplement>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(Consts.Brand.NameMaxLength.Value)]
        public string Name { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Supplement> Supplements
        {
            get { return this.supplements; }
            set { this.supplements = value; }
        }
    }
}
