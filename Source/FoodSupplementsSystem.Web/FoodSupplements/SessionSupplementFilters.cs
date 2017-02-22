using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public class SessionSupplementFilters : ISupplementFiltersProperties
    {
        public SessionSupplementFilters()
        {
            this.BrandName = string.Empty;
            this.CategoryName = string.Empty;
            this.TopicName = string.Empty;
        }

        public bool BrandEnabled { get; set; }
        public string BrandName { get; set; }

        public bool CategoryEnabled { get; set; }
        public string CategoryName { get; set; }

        public bool TopicEnabled { get; set; }
        public string TopicName { get; set; }
    }
}