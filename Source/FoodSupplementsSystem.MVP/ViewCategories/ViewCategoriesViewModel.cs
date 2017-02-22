using FoodSupplementsSystem.Data.Models;
using System.Collections.Generic;

namespace FoodSupplementsSystem.MVP.ViewCategories
{
    public class ViewCategoriesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
