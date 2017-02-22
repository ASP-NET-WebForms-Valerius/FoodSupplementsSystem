using System.Collections.Generic;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public interface ISupplementFilters : ISupplementFiltersProperties
    {
        //bool BrandEnabled { get; set; }
        //string BrandName { get; set; }
        //bool CategoryEnabled { get; set; }
        //string CategoryName { get; set; }
        ////bool TopicEnabled { get; set; }
        //string TopicName { get; set; }

        ISupplementsServices SupplementsServices { get; }

        IEnumerable<Supplement> GetFilteredSupplements();

        bool AnyEnabled { get; }

    }
}