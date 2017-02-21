using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.MVP.ViewCategories
{
    public class ViewCategoriesViewModel
    {
        public IQueryable<Category> Categories { get; set; }
    }
}
