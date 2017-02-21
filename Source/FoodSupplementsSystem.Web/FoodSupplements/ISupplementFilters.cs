using System.Collections.Generic;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public interface ISupplementFilters
    {
        bool AnyEnabled { get; }
        bool BrandEnabled { get; set; }
        string BrandName { get; set; }
        bool CategoryEnabled { get; set; }
        string CategoryName { get; set; }
        ISupplementsServices SupplementsServices { get; }
        bool TopicEnabled { get; set; }
        string TopicName { get; set; }

        IEnumerable<Supplement> GetFilteredSupplements();
    }
}