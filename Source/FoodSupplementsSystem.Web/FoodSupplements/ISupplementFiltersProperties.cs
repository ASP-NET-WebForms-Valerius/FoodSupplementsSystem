using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public interface ISupplementFiltersProperties
    {
        bool BrandEnabled { get; set; }
        string BrandName { get; set; }
        bool CategoryEnabled { get; set; }
        string CategoryName { get; set; }
        bool TopicEnabled { get; set; }
        string TopicName { get; set; }
    }
}
